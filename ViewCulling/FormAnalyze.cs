﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormAnalyze : Form
    {
        public static FormAnalyze Instance { get; private set; }

        private readonly Dictionary<string, int> _columns = new Dictionary<string, int>()
        {
            {"Номер", 0},
            {"Название файла", 1},
            {"Вердикт", 2},
            {"Коэффициент", 3},
            {"Время обработки, с", 4}
        };

        private readonly StatisticInfo _statInfo = new StatisticInfo();
        
        private CullingProject _cullingProject;
        private string _pathToTestingChipsFolder;
        private string _pathToCullingPattern;

        private Thread[] _workThreads;
        private DateTime _dtStartOfCalculation;
        private DispatcherTimer _mainTimer;

        private List<string> _pathesToImageFiles = new List<string>();
        private int _currFileIndex;

        private const int CountOfAcceptableBadPix = 300;

        public FormAnalyze()
        {
            InitializeComponent();
            Instance = this;
        }

        private void RefreshStatisticControls()
        {
            BeginInvoke(new MethodInvoker(
                delegate
                {
                    lock (_statInfo)
                    {
                        lblCountOfFiles.Text = _statInfo.CountOfFiles.ToString();
                        lblCountOfCalced.Text = _statInfo.CountOfCalced.ToString();
                        if (_statInfo.CountOfGood + _statInfo.CountOfBad > 0)
                            lblPercentOfOut.Text = String.Format("{0:P}",
                                ((double)_statInfo.CountOfGood) /
                                (_statInfo.CountOfGood + _statInfo.CountOfBad));
                        lblCountOfGood.Text = _statInfo.CountOfGood.ToString();
                        lblCountOfBad.Text = _statInfo.CountOfBad.ToString();
                        if (_statInfo.CountOfFiles > 0)
                            lblPercentOfProgress.Text = String.Format("{0:P}",
                                ((double)_statInfo.CountOfCalced) / _statInfo.CountOfFiles);
                        pbProgress.Value = _statInfo.CountOfCalced <= pbProgress.Maximum
                            ? _statInfo.CountOfCalced
                            : pbProgress.Maximum;
                        RefreshTime();
                    }
                }
                ));
        }

        private void EndOfCalculation()
        {
            _mainTimer.Stop();

            BeginInvoke(new MethodInvoker(delegate
            {
                pbLoading.Image = new Bitmap("assets\\done.png");
            }));
        }

        private void ScrollToRow(int currRow)
        {
            if (!автопрокруткаToolStripMenuItem.Checked)
                return;
            BeginInvoke(new MethodInvoker(delegate
            {
                dgvTestingOfChips.FirstDisplayedScrollingRowIndex = Math.Max(0, currRow - 15);
            }));
        }

        public void SetUserCorrectedStatus(string nameOfChip, Verdict.VerdictStructure verdict)
        {
            int indexOfName = _columns["Название файла"];
            int indexOfVerdict =  _columns["Вердикт"];
            for (int i = 0; i < dgvTestingOfChips.Rows.Count - 1; i++)
            {
                if (dgvTestingOfChips.Rows[i].Cells[indexOfName].Value.ToString() != nameOfChip) continue;

                Verdict.SetVerdictCell(dgvTestingOfChips.Rows[i].Cells[indexOfVerdict], verdict);
                break;
            }
        }

        private void InitDgvTestingOfChips()
        {
            dgvTestingOfChips.ColumnCount = _columns.Count;
            foreach (string name in _columns.Keys)
            {
                dgvTestingOfChips.Columns[_columns[name]].Name = name;
            }

            dgvTestingOfChips.ReadOnly = true;
            dgvTestingOfChips.Font = new Font("Microsoft Sans Serif", 9);
            dgvTestingOfChips.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            dgvTestingOfChips.BackgroundColor = SystemColors.Control;
            dgvTestingOfChips.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTestingOfChips.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTestingOfChips.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTestingOfChips.AutoResizeColumns();
            dgvTestingOfChips.Visible = false;
        }

        private void LoadInfoAboutTestingSet()
        {
            dgvTestingOfChips.Visible = true;

            foreach (string path in _pathesToImageFiles)
            {
                string name = Path.GetFileName(path);
                if (Path.GetExtension(name) != ".bmp")
                    continue;

                dgvTestingOfChips.RowCount++;
                int currRow = dgvTestingOfChips.RowCount - 2;

                dgvTestingOfChips.Rows[currRow].Cells[_columns["Номер"]].Value = (currRow + 1).ToString();
                dgvTestingOfChips.Rows[currRow].Cells[_columns["Название файла"]].Value = name;
                Verdict.SetVerdictCell(dgvTestingOfChips.Rows[currRow].Cells[_columns["Вердикт"]], Verdict.Queue);
            }
            dgvTestingOfChips.ClearSelection();
        }

        private void PrepareImageMas()
        {
            DirectoryInfo di = new DirectoryInfo(_pathToTestingChipsFolder);
            _pathesToImageFiles =
                di.GetFiles()
                    .Select(fileName => fileName.FullName)
                    .Where(fileName => Path.GetExtension(fileName) == ".bmp")
                    .ToList();

            _pathesToImageFiles.Sort();
            pbProgress.Maximum = _pathesToImageFiles.Count;
            _statInfo.CountOfFiles = _pathesToImageFiles.Count;
            _currFileIndex = 0;
        }

        private int FindDgvRowByFileName(string fileName)
        {
            int indexOfColumn = _columns["Название файла"];

            int res = -1;
            for (int i = 0; i < dgvTestingOfChips.Rows.Count - 1; i++)
                if (dgvTestingOfChips.Rows[i].Cells[indexOfColumn].Value.ToString() == fileName)
                    res = i;

            return res;
        }

        private void ReleaseTesting()
        {
            VisualInspect vi = new VisualInspect(_cullingProject);

            do
            {
                // синхронизируем получение доступа к файлам для обработки
                String currFileName;
                lock (_pathesToImageFiles)
                {
                    if (_currFileIndex >= _pathesToImageFiles.Count)
                        return;
                    currFileName = _pathesToImageFiles[_currFileIndex];
                    _currFileIndex++;
                }

                int currRow = FindDgvRowByFileName(Path.GetFileName(currFileName));
                Verdict.SetVerdictCell(dgvTestingOfChips.Rows[currRow].Cells[_columns["Вердикт"]], Verdict.Processing);

                ScrollToRow(currRow);

                bool isError = false;
                DateTime dtBefore = DateTime.Now;
                try
                {
                    Bitmap bmp = vi.CheckNextChip(currFileName);
                    bmp.Save("\\Storage\\results\\" + Path.GetFileName(currFileName));
                }
                catch (Exception ex)
                {
                    isError = true;
                    //MessageBox.Show(String.Format("Произошла ошибка при обработке: {0}", ex.Message));
                }

                TimeSpan timeSpan = DateTime.Now - dtBefore;
                double seconds = timeSpan.TotalMilliseconds / 1000.0;
                dgvTestingOfChips.Rows[currRow].Cells[_columns["Время обработки, с"]].Value = String.Format("{0:0.000}", seconds);
                dgvTestingOfChips.Rows[currRow].Cells[_columns["Коэффициент"]].Value = vi.CurrMark.ToString();

                var dgvcVerdict = dgvTestingOfChips.Rows[currRow].Cells[_columns["Вердикт"]];

                lock (_statInfo)
                {
                    if (isError)
                        Verdict.SetVerdictCell(dgvcVerdict, Verdict.Error);
                    else if (vi.CurrMark >= CountOfAcceptableBadPix)
                    {
                        Verdict.SetVerdictCell(dgvcVerdict, Verdict.Bad);
                        _statInfo.CountOfBad++;
                    }
                    else
                    {
                        Verdict.SetVerdictCell(dgvcVerdict, Verdict.Good);
                        _statInfo.CountOfGood++;
                    }
                    _statInfo.CountOfCalced++;
                    _statInfo.CurrFile = Path.GetFileName(currFileName);
                }

                RefreshStatisticControls();
            } 
            while (true);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                SelectedPath = Environment.CurrentDirectory.Substring(0, 2) + "\\Storage"
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                _pathToTestingChipsFolder = fbd.SelectedPath;
                lblPathToTestFolder.Text = fbd.SelectedPath;

                PrepareImageMas();
                LoadInfoAboutTestingSet();
                RefreshStatisticControls();
            }
        }

        private void FormStartAnalyze_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            pbLoading.Image = new Bitmap("assets\\waiting.png");
            InitDgvTestingOfChips();
            InitDgvTestingOfChips();
        }

        public void SendDataToShow(int rowNumber)
        {
            FormAnalyzeView formAnalyzeView;
            if (!Utils.FormIsOpen("FormAnalyzeView"))
            {
                formAnalyzeView = new FormAnalyzeView {TopLevel = false};
                Controls.Add(formAnalyzeView);
                formAnalyzeView.Show();
            }
            else
            {
                formAnalyzeView = FormAnalyzeView.Instance;
            }

            string nameOfFile = dgvTestingOfChips.Rows[rowNumber].Cells[_columns["Название файла"]].Value.ToString();
            string spritePicPath = "\\Storage\\results\\" + nameOfFile;
            string originalPicPath = lblPathToTestFolder.Text + "\\" + nameOfFile;
            formAnalyzeView.LoadData(nameOfFile, spritePicPath, originalPicPath, _cullingProject, rowNumber, dgvTestingOfChips.Rows.Count - 1);
            formAnalyzeView.SetStatus(dgvTestingOfChips.Rows[rowNumber].Cells[_columns["Вердикт"]].Value.ToString());
        }

        private void SetLoadingImage()
        {
            Random rnd = new Random();
            int num = rnd.Next(8) + 1;
            string path = String.Format("assets\\loading{0}.gif", num);
            Image image = new Bitmap(path);
            pbLoading.Image = image;
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_cullingProject == null || _pathToTestingChipsFolder == null)
                return;

            SetLoadingImage();
            _dtStartOfCalculation = DateTime.Now;
            _mainTimer = new DispatcherTimer();
            _mainTimer.Tick += mainTimer_Tick;
            _mainTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            _mainTimer.Start();
            int countOfThreads = Environment.ProcessorCount;
            _workThreads = new Thread[countOfThreads];
            for (int i = 0; i < countOfThreads; i++)
            {
                _workThreads[i] = new Thread(ReleaseTesting) {Name = i.ToString()};
                _workThreads[i].Start();
            }
        }

        private void RefreshTime()
        {
            if (_statInfo.CountOfCalced > 0)
            {
                TimeSpan timeOfCalc = DateTime.Now - _dtStartOfCalculation;
                lblTimeOfCalculation.Text = timeOfCalc.ToString(@"hh\:mm\:ss");

                TimeSpan timeLeft = TimeSpan.FromSeconds((timeOfCalc.TotalSeconds / _statInfo.CountOfCalced) * _statInfo.CountOfFiles - timeOfCalc.TotalSeconds);
                lblTimeLeft.Text = timeLeft.ToString(@"hh\:mm\:ss");
            }
        }

        void mainTimer_Tick(object sender, EventArgs e)
        {
            lock (_statInfo)
            {
                RefreshTime();
                if (_statInfo.CountOfFiles == _statInfo.CountOfCalced)
                {
                    EndOfCalculation();
                }
            }
        }

        private void открытьПроектОтбраковкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\" + Settings.PathToSaveProjects;
            OpenFileDialog ofd = new OpenFileDialog {InitialDirectory = path, Filter = "Culling Project (*.cpr)|*.cpr"};
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _cullingProject = CullingProject.GetSavedProject(ofd.FileName);
                lblProjectOfCulling.Text = Path.GetFileName(ofd.FileName);
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormStartAnalyze_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                StopTesting();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void StopTesting()
        {
            if (_mainTimer != null)
                _mainTimer.Stop();
            if (_workThreads != null)
            {
                foreach (Thread thread in _workThreads.Where(thread => thread != null))
                {
                    thread.Abort();
                }
            }

            _currFileIndex = Math.Max(0, _currFileIndex - Environment.ProcessorCount*2);
        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Map files (*.map)|*.*" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                lblCullingPattern.Text = Path.GetFileName(ofd.FileName);
                _pathToCullingPattern = ofd.FileName;
            }
        }

        private void SaveCullingMap(string pathToSave)
        {
            WaferMap waferMap = new WaferMap(_pathToCullingPattern);

            int indexOfVerdict = _columns["Вердикт"];
            int indexOfNameOfFile = _columns["Название файла"];
            for (int i = 0; i < dgvTestingOfChips.Rows.Count - 1; i++)
            {
                string verdict = dgvTestingOfChips.Rows[i].Cells[indexOfVerdict].Value.ToString();
                string nameOfFile = dgvTestingOfChips.Rows[i].Cells[indexOfNameOfFile].Value.ToString();
                if (verdict == Verdict.Bad.Name)
                    waferMap.SetChipAsCulled(nameOfFile);
            }

            waferMap.SaveCullingPatternFile(pathToSave);
        }

        private void сохранитьТекущуюКартуРаскрояToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Map file (*.map)|*.map",
                FileName =
                    String.Format("{0}_after_visual_culling.map",
                        Path.GetFileNameWithoutExtension(lblCullingPattern.Text))
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveCullingMap(sfd.FileName);
            }
        }

        private void dgvTestingOfChips_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == _columns["Вердикт"])
            {
                SendDataToShow(e.RowIndex);
            }
        }

        private void автопрокруткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem) sender).Checked = !((ToolStripMenuItem) sender).Checked;
        }

        private void остановкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopTesting();
        }

        public void SetNewSegmentationLim(int lim)
        {
            if (_cullingProject != null)
                _cullingProject.Lim = lim;
        }

        private void порогСегментацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCalibrationAndSettings formCalibrationAndSettings = new FormCalibrationAndSettings {TopLevel = false};
            FormMain.Instance.Controls.Add(formCalibrationAndSettings);

            formCalibrationAndSettings.Show();
            formCalibrationAndSettings.LoadInfo(_pathesToImageFiles, _cullingProject.Lim, _cullingProject.KeyPoints);
        }
    }
}
