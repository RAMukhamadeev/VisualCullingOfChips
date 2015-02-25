using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using NIIPP.ComputerVision;

namespace ViewCullling
{
    public partial class FormMain : Form
    {
        private string _pathToGoodChipFile = "exampleOfGoodChip.bmp";
        private string _pathToTestingChipsFolder = "testFolder";

        private readonly string[] _nameOfColumns = {
                                     "Название файла",
                                     "Вердикт",
                                     "Дата тестирования",
                                     "Просмотр"
                                 };

        public FormMain()
        {
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
                dgvTestingOfChips.Rows[currRow].Cells[2].Value = "<undefined>";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitDgvTestingOfChips();

            // для отладки
            lblPathToGoodChip.Text = _pathToGoodChipFile;
            lblPathToTestFolder.Text = _pathToTestingChipsFolder;
            LoadInfoAboutTestingSet();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnChooseOfGoodChip_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _pathToGoodChipFile = ofd.FileName;
                lblPathToGoodChip.Text = ofd.FileName;
            }
        }

        private void btnChooseFolderWithTest_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                _pathToTestingChipsFolder = fbd.SelectedPath;
                lblPathToTestFolder.Text = fbd.SelectedPath;
                LoadInfoAboutTestingSet();
            }
        }

        private void btnStartTesting_Click(object sender, EventArgs e)
        {
            VisualInspect vi = new VisualInspect(_pathToGoodChipFile);
            //SaveSegmentationPicture();
            DirectoryInfo di = new DirectoryInfo(_pathToTestingChipsFolder);

            int currFile = 0;
            foreach (FileInfo fileInfo in di.GetFiles())
            {
                if (Path.GetExtension(fileInfo.Name) != ".bmp")
                    continue;

                Bitmap bmp = vi.CheckNextChip(fileInfo.FullName);
                bmp.Save("results\\" + fileInfo.Name);

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
                Application.DoEvents();

                currFile++;
            }
        }

        private void SaveSegmentationPicture()
        {
            // сохраняем сегментированный изображение хорошего чипа
            Bitmap bmp = new Bitmap(_pathToGoodChipFile);
            Segmentation segm = new Segmentation(bmp);
            Bitmap segmentedBmp = segm.GetSegmentedPicture();
            segmentedBmp.Save(Path.GetFileNameWithoutExtension(_pathToGoodChipFile) + "_segmented.bmp");

            // сохраняем сегментированные изображения чипов, которые проверяем
            DirectoryInfo di = new DirectoryInfo(_pathToTestingChipsFolder);
            foreach (FileInfo fileInfo in di.GetFiles())
            {
                if (Path.GetExtension(fileInfo.Name) != ".bmp")
                    continue;
                Bitmap nextPic = new Bitmap(fileInfo.FullName);
                Segmentation nextSegm = new Segmentation(nextPic);
                nextPic = nextSegm.GetSegmentedPicture();
                nextPic.Save(
                    String.Format("testFolder_segmented\\{0}_segmented.bmp", Path.GetFileNameWithoutExtension(fileInfo.Name))
                    );
            }
        }

        private void dgvTestingOfChips_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string nameOfFile = dgvTestingOfChips.Rows[e.RowIndex].Cells[0].Value.ToString();
                Process.Start("results\\" + nameOfFile);
            }
        }
    }
}
