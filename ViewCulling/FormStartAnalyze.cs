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

            int currFile = 0;
            foreach (FileInfo fileInfo in di.GetFiles())
            {
                if (Path.GetExtension(fileInfo.Name) != ".bmp")
                    continue;

                dgvTestingOfChips.Rows[currFile].Cells[1].Value = "Обрабатывается...";
                dgvTestingOfChips.Rows[currFile].Cells[1].Style.BackColor = Color.Yellow;

                DateTime dtBefore = DateTime.Now;
                Bitmap bmp = vi.CheckNextChip(fileInfo.FullName);
                TimeSpan timeSpan = DateTime.Now - dtBefore;
                double seconds = timeSpan.TotalMilliseconds / 1000.0;
                dgvTestingOfChips.Rows[currFile].Cells[4].Value = String.Format("{0:0.00}", seconds);

                bmp.Save("\\Storage\\results\\" + fileInfo.Name);

                string curRes = "Годный";
                dgvTestingOfChips.Rows[currFile].Cells[1].Style.BackColor = Color.LawnGreen;
                dgvTestingOfChips.Rows[currFile].Cells[2].Value = vi.CurrMark.ToString();
                if (vi.CurrMark >= 500)
                {
                    curRes = "Не годный";
                    dgvTestingOfChips.Rows[currFile].Cells[1].Style.BackColor = Color.Red;
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
                Segmentation segmentation = new Segmentation(_cullingProject.PointsOfColors, _cullingProject.Lim);
                Bitmap res = segmentation.GetSegmentedPicture(innerPic);

                FormShowPicture formShowPicture = new FormShowPicture { TopLevel = false };
                FormMain.Instance.Controls.Add(formShowPicture);
                formShowPicture.Show();
                formShowPicture.SetImage(res);
            }
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread workThread = new Thread(ReleaseTesting);
            workThread.Start();
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

        }
    }
}
