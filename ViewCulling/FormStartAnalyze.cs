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
    public partial class FormStartAnalyze : Form
    {
        public FormStartAnalyze Instance { get; set; }
        private readonly string[] _nameOfColumns = {
                                     "Название файла",
                                     "Вердикт",
                                     "Коэффициент",
                                     "Дата тестирования",
                                     "Время обработки, c",
                                     "Просмотр",
                                     "Сегментация"
                                 };

        private CullingProject _cullingProject;
        private string _pathToTestingChipsFolder;

        private Thread _workThread;

        public FormStartAnalyze()
        {
            Instance = this;
            InitializeComponent();
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
        }

        private void LoadInfoAboutTestingSet()
        {
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
        }

        private void ReleaseTesting()
        {
            VisualInspect vi = new VisualInspect(_cullingProject);
            DirectoryInfo di = new DirectoryInfo(_pathToTestingChipsFolder);
            int s = (_cullingProject.UnitedImage.GetUpperBound(0) + 1)*
                       (_cullingProject.UnitedImage.GetUpperBound(1) + 1);
            int countOfAcceptableBadPix = s / 1000;

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
                dgvTestingOfChips.Rows[currFile].Cells[4].Value = String.Format("{0:0.00}", seconds);

                string curRes = "Годный";
                dgvTestingOfChips.Rows[currFile].Cells[1].Style.BackColor = Color.LawnGreen;
                dgvTestingOfChips.Rows[currFile].Cells[2].Value = vi.CurrMark.ToString();

                if (vi.CurrMark >= countOfAcceptableBadPix)
                {
                    curRes = "Не годный";
                    dgvTestingOfChips.Rows[currFile].Cells[1].Style.BackColor = Color.Red;
                }

                if (isError)
                {
                    curRes = "Ошибка при обработке";
                    dgvTestingOfChips.Rows[currFile].Cells[1].Style.BackColor = Color.DarkTurquoise;
                }

                dgvTestingOfChips.Rows[currFile].Cells[1].Value = curRes;
                dgvTestingOfChips.Rows[currFile].Cells[3].Value = DateTime.Now.ToString(CultureInfo.CurrentCulture);
                dgvTestingOfChips.Rows[currFile].Cells[5].Value = "Открыть";
                dgvTestingOfChips.Rows[currFile].Cells[6].Value = "Открыть";
                dgvTestingOfChips.Invalidate();

                currFile++;
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Environment.CurrentDirectory.Substring(0, 2) + "\\Storage";

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

        private void dgvTestingOfChips_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                string nameOfFile = dgvTestingOfChips.Rows[e.RowIndex].Cells[0].Value.ToString();
                Process.Start("\\Storage\\results\\" + nameOfFile);
            }

            if (e.ColumnIndex == 6)
            {
                string nameOfFile = dgvTestingOfChips.Rows[e.RowIndex].Cells[0].Value.ToString();
                Bitmap innerPic = new Bitmap(lblPathToTestFolder.Text + "\\" + nameOfFile);
                Segmentation segmentation = new Segmentation(_cullingProject.KeyPoints, _cullingProject.Lim);
                Bitmap res = segmentation.GetSegmentedPicture(innerPic);

                FormShowPicture formShowPicture = new FormShowPicture { TopLevel = false };
                FormMain.Instance.Controls.Add(formShowPicture);
                formShowPicture.Show();
                formShowPicture.SetImage(res);
            }
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _workThread = new Thread(ReleaseTesting);
            _workThread.Start();
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

        private void открытьШаблонФайлаОтбраковкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
            }
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
    }
}
