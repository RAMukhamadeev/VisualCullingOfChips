using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormStartAnalyze : Form
    {
        private string PathToTestingChipsFolder { get; set; }
        private FormStartAnalyze Instance { get; set; }

        private readonly string[] _nameOfColumns = {
                                     "Название файла",
                                     "Вердикт",
                                     "Дата тестирования",
                                     "Просмотр"
                                 };

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
            DirectoryInfo di = new DirectoryInfo(PathToTestingChipsFolder);
            foreach (FileInfo fileInfo in di.GetFiles())
            {
                if (Path.GetExtension(fileInfo.Name) != ".bmp")
                    continue;

                dgvTestingOfChips.RowCount++;
                int currRow = dgvTestingOfChips.RowCount - 2;

                dgvTestingOfChips.Rows[currRow].Cells[0].Value = fileInfo.Name;
                dgvTestingOfChips.Rows[currRow].Cells[1].Value = "В очереди...";
                dgvTestingOfChips.Rows[currRow].Cells[2].Value = "<undefined>";
            }
        }

        private void ReleaseTesting()
        {
            VisualInspect vi = new VisualInspect(Globals.PathToGoodChipFile);
            DirectoryInfo di = new DirectoryInfo(PathToTestingChipsFolder);

            int currFile = 0;
            foreach (FileInfo fileInfo in di.GetFiles())
            {
                if (Path.GetExtension(fileInfo.Name) != ".bmp")
                    continue;

                dgvTestingOfChips.Rows[currFile].Cells[1].Value = "Обрабатывается...";
                dgvTestingOfChips.Rows[currFile].Cells[1].Style.BackColor = Color.Yellow;

                Bitmap bmp = vi.CheckNextChip(fileInfo.FullName);
                bmp.Save("\\Storage\\results\\" + fileInfo.Name);

                string curRes = "Годный";
                dgvTestingOfChips.Rows[currFile].Cells[1].Style.BackColor = Color.LawnGreen;
                if (vi.CurrMark > 500)
                {
                    curRes = "Не годный";
                    dgvTestingOfChips.Rows[currFile].Cells[1].Style.BackColor = Color.Red;
                }
                dgvTestingOfChips.Rows[currFile].Cells[1].Value = curRes;
                dgvTestingOfChips.Rows[currFile].Cells[2].Value = DateTime.Now.ToString();
                dgvTestingOfChips.Rows[currFile].Cells[3].Value = "Открыть";
                dgvTestingOfChips.Invalidate();

                currFile++;
            }
        }

        private void btnStartTesting_Click(object sender, EventArgs e)
        {
            Thread workThread = new Thread(ReleaseTesting);
            workThread.Start();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                PathToTestingChipsFolder = fbd.SelectedPath;
                lblPathToTestFolder.Text = Path.GetFileName(fbd.SelectedPath);
                LoadInfoAboutTestingSet();
            }
        }

        private void FormStartAnalyze_Load(object sender, EventArgs e)
        {
            InitDgvTestingOfChips();
        }

        private void dgvTestingOfChips_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string nameOfFile = dgvTestingOfChips.Rows[e.RowIndex].Cells[0].Value.ToString();
                Process.Start("\\Storage\\results\\" + nameOfFile);
            }
        }
    }
}
