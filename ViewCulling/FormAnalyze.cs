using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormAnalyze : Form
    {
        public static FormAnalyze Instance { get; private set; }

        private readonly Dictionary<string, int> _columns = new Dictionary<string, int>()
        {
            {"Название файла", 0},
            {"Вердикт", 1},
            {"Коэффициент", 2},
            {"Время обработки, с", 3}
        };

        private CullingProject _cullingProject;
        private string _pathToTestingChipsFolder;
        private string _pathToCullingPattern;

        private Thread[] _workThreads;
        private Mutex _mutex = new Mutex();

        private List<string> _pathesToImageFiles = new List<string>();
        private int _currFileIndex;

        const int _countOfAcceptableBadPix = 300;

        public FormAnalyze()
        {
            InitializeComponent();
            Instance = this;
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

            DirectoryInfo di = new DirectoryInfo(_pathToTestingChipsFolder);
            foreach (FileInfo fileInfo in di.GetFiles())
            {
                if (Path.GetExtension(fileInfo.Name) != ".bmp")
                    continue;

                dgvTestingOfChips.RowCount++;
                int currRow = dgvTestingOfChips.RowCount - 2;

                dgvTestingOfChips.Rows[currRow].Cells[_columns["Название файла"]].Value = fileInfo.Name;
                Verdict.SetVerdictCell(dgvTestingOfChips.Rows[currRow].Cells[_columns["Вердикт"]], Verdict.Queue);
            }
            dgvTestingOfChips.ClearSelection();
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
                _mutex.WaitOne();
                if (_currFileIndex >= _pathesToImageFiles.Count)
                {
                    _mutex.ReleaseMutex();
                    return;
                }
                String currFileName = _pathesToImageFiles[_currFileIndex];
                _currFileIndex++;
                _mutex.ReleaseMutex();
                // доступ получен, освободжаем mutex

                int currRow = FindDgvRowByFileName(Path.GetFileName(currFileName));
                Verdict.SetVerdictCell(dgvTestingOfChips.Rows[currRow].Cells[_columns["Вердикт"]], Verdict.Processing);
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
                if (isError)
                    Verdict.SetVerdictCell(dgvcVerdict, Verdict.Error);
                else
                    if (vi.CurrMark >= _countOfAcceptableBadPix)
                        Verdict.SetVerdictCell(dgvcVerdict, Verdict.Bad);
                    else
                        Verdict.SetVerdictCell(dgvcVerdict, Verdict.Good); 
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
                LoadInfoAboutTestingSet();
            }
        }

        private void FormStartAnalyze_Load(object sender, EventArgs e)
        {
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
            SetLoadingImage();

            DirectoryInfo di = new DirectoryInfo(_pathToTestingChipsFolder);
            _pathesToImageFiles =
                di.GetFiles()
                    .Select(fileName => fileName.FullName)
                    .Where(fileName => Path.GetExtension(fileName) == ".bmp")
                    .ToList();

            _pathesToImageFiles.Sort();
            _currFileIndex = 0;

            int countOfThreads = Environment.ProcessorCount;
            _workThreads = new Thread[countOfThreads];
            for (int i = 0; i < countOfThreads; i++)
            {
                _workThreads[i] = new Thread(ReleaseTesting);
                _workThreads[i].Start();
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
                if (_workThreads != null)
                {
                    foreach (Thread thread in _workThreads.Where(thread => thread != null))
                    {
                        thread.Abort();
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
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
    }
}
