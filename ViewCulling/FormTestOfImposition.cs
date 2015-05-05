using System;
using System.Drawing;
using System.Windows.Forms;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormTestOfImposition : Form
    {
        private string _pathToTestedFile;
        private string _pathToOriginFile;

        public FormTestOfImposition()
        {
            InitializeComponent();
        }

        private void показСовмещенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmpOriginal = new Bitmap(_pathToOriginFile);
            Bitmap bmpTested = new Bitmap(_pathToTestedFile);

            Color backColor = Color.FromArgb(96, 109, 235);
            int lim = 115;

            Segmentation segmentation1 = new Segmentation(bmpTested, backColor, lim);
            var masTested = segmentation1.GetSegmentedMass();

            Segmentation segmentation2 = new Segmentation(bmpOriginal, backColor, lim);
            var masOrigin = segmentation2.GetSegmentedMass();

            SuperImposition superImposition = new SuperImposition(masOrigin);
            Point point = superImposition.FindBestImposition(masTested);

            MessageBox.Show(point.X + " " + point.Y);
        }

        private void тестируемыйФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _pathToTestedFile = ofd.FileName;
            }
        }

        private void годныйФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _pathToOriginFile = ofd.FileName;
            }
        }
    }
}
