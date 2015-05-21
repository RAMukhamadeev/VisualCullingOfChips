using System;
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
            {"Просмотрено", 3},
            {"Коэффициент (кластер)", 4},
            {"Коэффициент (пыль)", 5},
            {"Время обработки, с", 6}
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

                DataGridViewCell dgvcVerdict = dgvTestingOfChips.Rows[i].Cells[indexOfVerdict];
                if (dgvcVerdict.Value.ToString() == Verdict.Good.Name && verdict.Name == Verdict.Bad.Name)
                {
                    _statInfo.CountOfGood--;
                    _statInfo.CountOfBad++;
                }
                if (dgvcVerdict.Value.ToString() == Verdict.Bad.Name && verdict.Name == Verdict.Good.Name)
                {
                    _statInfo.CountOfGood++;
                    _statInfo.CountOfBad--;
                }
                Verdict.SetVerdictCell(dgvcVerdict, verdict);

                break;
            }
            RefreshStatisticControls();
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
                dgvTestingOfChips.Rows[currRow].Cells[_columns["Просмотрено"]].Value = "Нет";
                dgvTestingOfChips.Rows[currRow].Cells[_columns["Просмотрено"]].Style.BackColor = Color.Khaki;
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
            VisualInspect vi = new VisualInspect(_cullingProject, Settings.CountOfPixelsInClaster, Settings.SumOfPixelsInClusters)
            {
                EdgeRadius = Settings.EdgeNearArea, 
                ImpositionAcceptablePercent = Settings.ImpositionAcceptablePercent, 
                SegmentationRadiusOfStartFilling = Settings.RadiusOfStartFilling
            };

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
                var dgvcVerdict = dgvTestingOfChips.Rows[currRow].Cells[_columns["Вердикт"]];

                // если уже проверен то не смотрим
                if (dgvcVerdict.Value.ToString() != Verdict.Queue.Name && dgvcVerdict.Value.ToString() != Verdict.Processing.Name)
                    continue;

                Verdict.SetVerdictCell(dgvcVerdict, Verdict.Processing);
                ScrollToRow(currRow);

                bool isError = false;
                DateTime dtBefore = DateTime.Now;
                try
                {
                    vi.CheckNextChip(currFileName);
                    vi.PicWithSprites.Save(String.Format("{0}\\{1}", Settings.PathToCache, Path.GetFileName(currFileName)));
                }
                catch (Exception ex)
                {
                    isError = true;
                    //MessageBox.Show(String.Format("Произошла ошибка при обработке: {0}", ex.Message));
                }

                TimeSpan timeSpan = DateTime.Now - dtBefore;
                double seconds = timeSpan.TotalMilliseconds / 1000.0;
                dgvTestingOfChips.Rows[currRow].Cells[_columns["Время обработки, с"]].Value = String.Format("{0:0.000}", seconds);
                dgvTestingOfChips.Rows[currRow].Cells[_columns["Коэффициент (кластер)"]].Value = vi.CurrMarkIsland.ToString();
                dgvTestingOfChips.Rows[currRow].Cells[_columns["Коэффициент (пыль)"]].Value = vi.CurrMarkDust.ToString();

                lock (_statInfo)
                {
                    if (isError)
                        Verdict.SetVerdictCell(dgvcVerdict, Verdict.Error);
                    else
                    {
                        if (vi.CurrVerdict == Verdict.Bad.Name)
                        {
                            Verdict.SetVerdictCell(dgvcVerdict, Verdict.Bad);
                            _statInfo.CountOfBad++;
                        }
                        if (vi.CurrVerdict == Verdict.Good.Name)
                        {
                            Verdict.SetVerdictCell(dgvcVerdict, Verdict.Good);
                            _statInfo.CountOfGood++;
                        }
                    }
                    _statInfo.CountOfCalced++;
                    _statInfo.CurrFile = Path.GetFileName(currFileName);
                }

                RefreshStatisticControls();
            } 
            while (true);
        }

        private void OpenFolderForTesting()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                SelectedPath = @"\\172.16.1.7\pc001-backup\4LAB\!MEASURING",
                Description = "Выбор папки с микрофотографиями для визуального анализа",
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                _pathToTestingChipsFolder = fbd.SelectedPath;
                Text = fbd.SelectedPath;
                lblNameOfTestFolder.Text = Path.GetFileName(fbd.SelectedPath);

                PrepareImageMas();
                LoadInfoAboutTestingSet();
                RefreshStatisticControls();
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFolderForTesting();
        }

        private void FormStartAnalyze_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            pbLoading.Image = new Bitmap("assets\\waiting.png");
            InitDgvTestingOfChips();
        }

        private string GetVerdict(int row)
        {
            return dgvTestingOfChips.Rows[row].Cells[_columns["Вердикт"]].Value.ToString();
        }

        private int SearchNextChip(int startPoint, bool isNext, string filter)
        {
            int countOfRows = dgvTestingOfChips.Rows.Count - 1;
            int pos = startPoint;

            if (filter == "")
            {
                if (isNext)
                {
                    pos++;
                    while (pos < countOfRows && GetVerdict(pos) != Verdict.Good.Name && GetVerdict(pos) != Verdict.Bad.Name)
                        pos++;
                }
                else
                {
                    pos--;
                    while (pos >= 0 && GetVerdict(pos) != Verdict.Good.Name && GetVerdict(pos) != Verdict.Bad.Name)
                        pos--;
                }
            }
            else
            {
                if (isNext)
                {
                    pos++;
                    while (pos < countOfRows && GetVerdict(pos) != filter)
                        pos++;
                }
                else
                {
                    pos--;
                    while (pos >= 0 && GetVerdict(pos) != filter)
                        pos--;
                }
            }
            if (pos < countOfRows && pos >= 0)
                return pos;

            return startPoint;
        }

        public void SendDataToShow(int rowNumber, bool? isNext = null, string filter = null)
        {
            if (isNext != null && filter != null)
                rowNumber = SearchNextChip(rowNumber, (bool) isNext, filter);

            dgvTestingOfChips.Rows[rowNumber].Cells[_columns["Просмотрено"]].Value = "Да";
            dgvTestingOfChips.Rows[rowNumber].Cells[_columns["Просмотрено"]].Style.BackColor = Color.White;

            FormAnalyzeView formAnalyzeView;
            if (!Utils.FormIsOpen("FormAnalyzeView"))
            {
                formAnalyzeView = new FormAnalyzeView {TopLevel = false};
                FormMain.Instance.Controls.Add(formAnalyzeView);
            }
            else
            {
                formAnalyzeView = FormAnalyzeView.Instance;
            }
            

            string nameOfFile = dgvTestingOfChips.Rows[rowNumber].Cells[_columns["Название файла"]].Value.ToString();
            string coeff = dgvTestingOfChips.Rows[rowNumber].Cells[_columns["Коэффициент (кластер)"]].Value.ToString();
            string spritePicPath = Settings.PathToCache + "\\" + nameOfFile;
            string originalPicPath = _pathToTestingChipsFolder + "\\" + nameOfFile;

            formAnalyzeView.LoadMainData(_cullingProject, dgvTestingOfChips.Rows.Count - 1);
            formAnalyzeView.LoadData(nameOfFile, spritePicPath, originalPicPath, coeff, rowNumber);
            formAnalyzeView.SetStatus(dgvTestingOfChips.Rows[rowNumber].Cells[_columns["Вердикт"]].Value.ToString());

            formAnalyzeView.Show();
        }

        private void SetLoadingImage()
        {
            Random rnd = new Random();
            int num = rnd.Next(8) + 1;
            num = 4;
            string path = String.Format("assets\\loading{0}.gif", num);
            Image image = new Bitmap(path);
            pbLoading.Image = image;
        }

        private void StartCalculating()
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
                _workThreads[i] = new Thread(ReleaseTesting) { Name = i.ToString() };
                _workThreads[i].Start();
            }
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartCalculating();
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

        private void OpenCullingProject()
        {
            string path = Environment.CurrentDirectory + "\\" + Settings.PathToSaveProjects;
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = path,
                Filter = "Culling Project (*.cpr)|*.cpr",
                Title = "Выбор файла проекта отбраковки"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _cullingProject = CullingProject.GetSavedProject(ofd.FileName);
                lblProjectOfCulling.Text = Path.GetFileName(ofd.FileName);
            }
        }

        private void открытьПроектОтбраковкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCullingProject();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormStartAnalyze_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                StopCalculating();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void StopCalculating()
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

            _currFileIndex = Math.Max(0, _currFileIndex - Environment.ProcessorCount * 2);
        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog 
            { 
                Filter = "Map files (*.map)|*.*", 
                Title = "Выбор шаблона карты раскроя", 
                InitialDirectory = @"\\172.16.1.7\pc001-backup\4LAB\!MEASURING" 
            };
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
            if (_pathToCullingPattern == null)
            {
                MessageBox.Show("Не выбран шаблон карты раскроя!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Map file (*.map)|*.map",
                Title = "Сохранение текущей карты раскроя",
                InitialDirectory = @"\\172.16.1.7\pc001-backup\4LAB\!MEASURING",
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
            if (e.ColumnIndex == _columns["Просмотрено"])
            {
                string verdict = dgvTestingOfChips.Rows[e.RowIndex].Cells[_columns["Вердикт"]].Value.ToString();
                if (verdict == Verdict.Good.Name || verdict == Verdict.Bad.Name)
                    SendDataToShow(e.RowIndex);
            }
        }

        private void автопрокруткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem) sender).Checked = !((ToolStripMenuItem) sender).Checked;
        }

        private void остановкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopCalculating();
        }

        public void SetNewSegmentationLim(int lim)
        {
            if (_cullingProject != null)
                _cullingProject.Lim = lim;
        }

        private void порогСегментацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCalibration formCalibrationAndSettings = new FormCalibration {TopLevel = false};
            FormMain.Instance.Controls.Add(formCalibrationAndSettings);

            formCalibrationAndSettings.Show();
            formCalibrationAndSettings.LoadInfo(_pathesToImageFiles, _cullingProject.Lim, _cullingProject.KeyPoints);
        }

        private void pbStart_Click(object sender, EventArgs e)
        {
            StartCalculating();
        }

        private void pbPause_Click(object sender, EventArgs e)
        {
            StopCalculating();
        }

        private void pbStop_Click(object sender, EventArgs e)
        {
            StopCalculating();
        }

        private void pbChooseCullingProject_Click(object sender, EventArgs e)
        {
            OpenCullingProject();
        }

        private void pbChooseFolder_Click(object sender, EventArgs e)
        {
            OpenFolderForTesting();
        }

        private void коэффициентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings {TopLevel = false};
            FormMain.Instance.Controls.Add(formSettings);

            formSettings.Show();
            formSettings.BringToFront();
        }

    }
}
