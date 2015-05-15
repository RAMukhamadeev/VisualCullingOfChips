using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormAnalyze : Form
    {
        public static FormAnalyze Instance { get; private set; }
        private readonly string[] _nameOfColumns = {
                                     "Название файла",
                                     "Вердикт",
                                     "Коэффициент",
                                     "Время обработки, c"
                                 };

        private CullingProject _cullingProject;
        private string _pathToTestingChipsFolder;
        private string _pathToCullingPattern;

        private Thread _workThread;

        public FormAnalyze()
        {
            InitializeComponent();
            Instance = this;
        }

        public void SetUserCorrectedStatus(string nameOfChip, bool isGood)
        {
            for (int i = 0; i < dgvTestingOfChips.Rows.Count - 1; i++)
            {
                if (dgvTestingOfChips.Rows[i].Cells[0].Value.ToString() == nameOfChip)
                {
                    if (isGood)
                    {
                        dgvTestingOfChips.Rows[i].Cells[1].Value = "Годный";
                        dgvTestingOfChips.Rows[i].Cells[1].Style.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        dgvTestingOfChips.Rows[i].Cells[1].Value = "Не годный";
                        dgvTestingOfChips.Rows[i].Cells[1].Style.BackColor = Color.OrangeRed;
                    }
                }
            }
        }

        private int GetIndexOfColumn(string nameOfColumn)
        {
            int res = -1;
            for (int i = 0; i < _nameOfColumns.Length; i++)
                if (_nameOfColumns[i] == nameOfColumn)
                {
                    res = i;
                    break;
                }
            return res;
        }

        private void InitDgvTestingOfChips()
        {
            dgvTestingOfChips.ColumnCount = _nameOfColumns.Length;
            for (int i = 0; i < _nameOfColumns.Length; i++)
                dgvTestingOfChips.Columns[i].Name = _nameOfColumns[i];

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

                dgvTestingOfChips.Rows[currRow].Cells[0].Value = fileInfo.Name;
                dgvTestingOfChips.Rows[currRow].Cells[1].Value = "В очереди...";
                dgvTestingOfChips.Rows[currRow].Cells[3].Value = "<undefined>";
            }
            dgvTestingOfChips.ClearSelection();
        }

        private void ReleaseTesting()
        {
            VisualInspect vi = new VisualInspect(_cullingProject);
            DirectoryInfo di = new DirectoryInfo(_pathToTestingChipsFolder);
            int s = (_cullingProject.UnitedImage.GetUpperBound(0) + 1) *
                       (_cullingProject.UnitedImage.GetUpperBound(1) + 1);
            //int countOfAcceptableBadPix = s / 1000;
            int countOfAcceptableBadPix = 300;

            int currFile = 0;
            foreach (FileInfo fileInfo in di.GetFiles())
            {
                if (Path.GetExtension(fileInfo.Name) != ".bmp")
                    continue;

                dgvTestingOfChips.Rows[currFile].Cells[1].Value = "Обрабатывается...";
                dgvTestingOfChips.Rows[currFile].Cells[1].Style.BackColor = Color.Yellow;

                bool isError = false;
                DateTime dtBefore = DateTime.Now;
                try
                {
                    Bitmap bmp = vi.CheckNextChip(fileInfo.FullName);
                    bmp.Save("\\Storage\\results\\" + fileInfo.Name);
                }
                catch (Exception ex)
                {
                    isError = true;
                    //MessageBox.Show(String.Format("Произошла ошибка при обработке: {0}", ex.Message));
                }
                
                TimeSpan timeSpan = DateTime.Now - dtBefore;
                double seconds = timeSpan.TotalMilliseconds / 1000.0;
                dgvTestingOfChips.Rows[currFile].Cells[3].Value = String.Format("{0:0.000}", seconds);

                string curRes = "Годный";
                dgvTestingOfChips.Rows[currFile].Cells[1].Style.BackColor = Color.LawnGreen;
                dgvTestingOfChips.Rows[currFile].Cells[2].Value = vi.CurrMark.ToString();

                if (vi.CurrMark >= countOfAcceptableBadPix)
                {
                    curRes = "Не годный";
                    dgvTestingOfChips.Rows[currFile].Cells[1].Style.BackColor = Color.OrangeRed;
                }

                if (isError)
                {
                    curRes = "Ошибка при обработке";
                    dgvTestingOfChips.Rows[currFile].Cells[1].Style.BackColor = Color.DarkTurquoise;
                }

                dgvTestingOfChips.Rows[currFile].Cells[1].Value = curRes;

                currFile++;
            }
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


            string nameOfFile = dgvTestingOfChips.Rows[rowNumber].Cells[0].Value.ToString();
            string spritePicPath = "\\Storage\\results\\" + nameOfFile;
            string originalPicPath = lblPathToTestFolder.Text + "\\" + nameOfFile;
            formAnalyzeView.LoadData(nameOfFile, spritePicPath, originalPicPath, _cullingProject, rowNumber, dgvTestingOfChips.Rows.Count - 1);
            formAnalyzeView.SetStatus(dgvTestingOfChips.Rows[rowNumber].Cells[1].Value.ToString());
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
            _workThread = new Thread(ReleaseTesting);
            _workThread.Start();

            SetLoadingImage();
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
                if (_workThread != null)
                    _workThread.Abort();
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

            int indexOfVerdict = GetIndexOfColumn("Вердикт");
            int indexOfNameOfFile = GetIndexOfColumn("Название файла");
            for (int i = 0; i < dgvTestingOfChips.Rows.Count - 1; i++)
            {
                string verdict = dgvTestingOfChips.Rows[i].Cells[indexOfVerdict].Value.ToString();
                string nameOfFile = dgvTestingOfChips.Rows[i].Cells[indexOfNameOfFile].Value.ToString();
                if (verdict == "Не годный")
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

        private void dgvTestingOfChips_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GetIndexOfColumn("Название файла"))
            {
                SendDataToShow(e.RowIndex);
            }
        }
    }
}
