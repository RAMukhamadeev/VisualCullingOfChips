using System;
using System.Windows.Forms;

namespace ViewCullling
{
    public partial class FormMain : Form
    {
        public string PathToGoodChipFile { get; private set; }
        public static FormMain Instance { get; private set; }

        public FormMain()
        {
            Instance = this;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void SaveSegmentationPicture()
        //{
        //    // сохраняем сегментированный изображение хорошего чипа
        //    Bitmap bmp = new Bitmap(PathToGoodChipFile);
        //    Segmentation segm = new Segmentation(bmp);
        //    Bitmap segmentedBmp = segm.GetSegmentedPicture();
        //    segmentedBmp.Save("\\Storage\\" + Path.GetFileNameWithoutExtension(PathToGoodChipFile) + "_segmented.bmp");

        //    // сохраняем сегментированные изображения чипов, которые проверяем
        //    DirectoryInfo di = new DirectoryInfo(PathToTestingChipsFolder);
        //    foreach (FileInfo fileInfo in di.GetFiles())
        //    {
        //        if (Path.GetExtension(fileInfo.Name) != ".bmp")
        //            continue;
        //        Bitmap nextPic = new Bitmap(fileInfo.FullName);
        //        Segmentation nextSegm = new Segmentation(nextPic);
        //        nextPic = nextSegm.GetSegmentedPicture();
        //        nextPic.Save(
        //            String.Format("\\Storage\\testFolder_segmented\\{0}_segmented.bmp", Path.GetFileNameWithoutExtension(fileInfo.Name))
        //            );
        //    }
        //}

        private void rGBКомпонентаОбразцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRgbAnalyze formRgbAnalyzeOfGoodChip = new FormRgbAnalyze();
            formRgbAnalyzeOfGoodChip.Show();
        }

        private void запускАнализаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStartAnalyze formStartAnalyze = new FormStartAnalyze();
            formStartAnalyze.Show();
        }

        private void добавитьНовыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNewProject formAddNewProject = new FormAddNewProject();
            formAddNewProject.Show();
        }
    }
}
