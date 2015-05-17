using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormAnalyzeView : Form
    {
        public static FormAnalyzeView Instance { get; private set; }

        private string _pathToSpritePic;
        private string _pathToOriginalPic;
        private CullingProject _cullingProject;
        private string _nameOfFile;
        private int _pos;
        private int _countOfRows;

        public FormAnalyzeView()
        {
            InitializeComponent();
            Instance = this;
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void LoadData(string nameOfFile, string pathSpritePic, string pathToOriginalPic, CullingProject cullingProject, int pos, int countOfRows)
        {
            _nameOfFile = nameOfFile;
            _pathToOriginalPic = pathToOriginalPic;
            _pathToSpritePic = pathSpritePic;
            _cullingProject = cullingProject;
            _pos = pos;
            _countOfRows = countOfRows;

            pbViewPicture.Image = new Bitmap(_pathToSpritePic);
            lblNameOfChip.Text = Path.GetFileNameWithoutExtension(_nameOfFile);
        }

        public void SetStatus(string verdict)
        {
            if (verdict == Verdict.Good.Name)
                rbGood.Checked = true;
            else
                if (verdict == Verdict.Bad.Name)
                    rbBad.Checked = true;
        }

        private void FormViewPicture_Load(object sender, EventArgs e)
        {

        }

        private void pbViewPicture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pbViewPicture.Image.Save("\\tempPic.bmp");
            Process.Start("\\tempPic.bmp");
        }

        private void сегментацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap innerPic = new Bitmap(_pathToOriginalPic);
            Segmentation segmentation = new Segmentation(_cullingProject.KeyPoints, _cullingProject.Lim);
            Bitmap res = segmentation.GetSegmentedPicture(innerPic);

            pbViewPicture.Image = res;
        }

        private void оригиналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbViewPicture.Image = new Bitmap(_pathToOriginalPic);
        }

        private void спрайтыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbViewPicture.Image = new Bitmap(_pathToSpritePic);
        }

        private void SetVerdictStatus()
        {
            if (rbGood.Checked)
                pbStatus.Image = new Bitmap("assets\\good.png");
            if (rbBad.Checked)
                pbStatus.Image = new Bitmap("assets\\bad.png");
            FormAnalyze.Instance.SetUserCorrectedStatus(_nameOfFile, rbGood.Checked ? Verdict.Good : Verdict.Bad);
        }

        private void rbGood_CheckedChanged(object sender, EventArgs e)
        {
            SetVerdictStatus();
        }

        private void rbBad_CheckedChanged(object sender, EventArgs e)
        {
            SetVerdictStatus();
        }

        private void ключевыеТочкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbViewPicture.Image = Utils.DrawKeyPointsOnImage(new Bitmap(_pathToOriginalPic), _cullingProject.KeyPoints);
        }

        private void краяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap innerPic = new Bitmap(_pathToOriginalPic);
            Segmentation segmentation = new Segmentation(_cullingProject.KeyPoints, _cullingProject.Lim);
            Bitmap res = segmentation.GetSegmentedPicture(innerPic);
            EdgeFinder edgeFinder = new EdgeFinder(res);
            pbViewPicture.Image = edgeFinder.GetEdgePic();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog {FileName = "save.bmp", Filter = "Image (*.bmp)|*.bmp"};
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pbViewPicture.Image.Save(sfd.FileName);
            }
        }

        private void шаблонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbViewPicture.Image = Utils.ByteToBitmapRgb(_cullingProject.UnitedImage);
        }

        private void pbLeftArrow_Click(object sender, EventArgs e)
        {
            if (_pos > 0)
                FormAnalyze.Instance.SendDataToShow(_pos - 1);
        }

        private void pbRightArrow_Click(object sender, EventArgs e)
        {
            if (_pos < _countOfRows - 1)
                FormAnalyze.Instance.SendDataToShow(_pos + 1);
        }
    }
}
