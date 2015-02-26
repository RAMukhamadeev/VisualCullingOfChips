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
        public string PathToGoodChipFile { get; private set; }
        public string PathToTestingChipsFolder { get; private set; }
        public static FormMain Instance { get; private set; }

        private readonly string[] _nameOfColumns = {
                                     "Название файла",
                                     "Вердикт",
                                     "Дата тестирования",
                                     "Просмотр"
                                 };

        public FormMain()
        {
            Instance = this;
            InitializeComponent();

            // для отладки
            PathToGoodChipFile = "\\Storage\\exampleOfGoodChip.bmp";
            PathToTestingChipsFolder = "\\Storage\\testFolder";
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitDgvTestingOfChips();

            // для отладки
            lblPathToGoodChip.Text = PathToGoodChipFile;
            lblPathToTestFolder.Text = PathToTestingChipsFolder;
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
                PathToGoodChipFile = ofd.FileName;
                lblPathToGoodChip.Text = Path.GetFileName(ofd.FileName);
            }
        }

        private void btnChooseFolderWithTest_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                PathToTestingChipsFolder = fbd.SelectedPath;
                lblPathToTestFolder.Text = Path.GetFileName(fbd.SelectedPath);
                LoadInfoAboutTestingSet();
            }
        }

        private void btnStartTesting_Click(object sender, EventArgs e)
        {
            //Thread workThread = new Thread(ReleaseTesting);
            //workThread.Start();
            SaveSegmentationPicture();
        }

        private void ReleaseTesting()
        {
            VisualInspect vi = new VisualInspect(PathToGoodChipFile);
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

        private void SaveSegmentationPicture()
        {
            // сохраняем сегментированный изображение хорошего чипа
            Bitmap bmp = new Bitmap(PathToGoodChipFile);
            Segmentation segm = new Segmentation(bmp);
            Bitmap segmentedBmp = segm.GetSegmentedPicture();
            segmentedBmp.Save("\\Storage\\" + Path.GetFileNameWithoutExtension(PathToGoodChipFile) + "_segmented.bmp");

            // сохраняем сегментированные изображения чипов, которые проверяем
            //DirectoryInfo di = new DirectoryInfo(PathToTestingChipsFolder);
            //foreach (FileInfo fileInfo in di.GetFiles())
            //{
            //    if (Path.GetExtension(fileInfo.Name) != ".bmp")
            //        continue;
            //    Bitmap nextPic = new Bitmap(fileInfo.FullName);
            //    Segmentation nextSegm = new Segmentation(nextPic);
            //    nextPic = nextSegm.GetSegmentedPicture();
            //    nextPic.Save(
            //        String.Format("testFolder_segmented\\{0}_segmented.bmp", Path.GetFileNameWithoutExtension(fileInfo.Name))
            //        );
            //}
        }

        private void dgvTestingOfChips_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string nameOfFile = dgvTestingOfChips.Rows[e.RowIndex].Cells[0].Value.ToString();
                Process.Start("\\Storage\\results\\" + nameOfFile);
            }
        }

        private void rGBКомпонентаОбразцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRgbAnalyzeOfGoodChip formRgbAnalyzeOfGoodChip = new FormRgbAnalyzeOfGoodChip();
            formRgbAnalyzeOfGoodChip.Show();
        }
    }
}
