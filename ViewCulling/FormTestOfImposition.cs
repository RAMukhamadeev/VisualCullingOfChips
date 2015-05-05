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

        private Bitmap OverlapTwoImage(byte[,,] mas1, byte[,,] mas2, Point offset)
        {
            for (int i = 0; i < mas1.GetUpperBound(0) + 1; i++)
                for (int j = 0; j < mas1.GetUpperBound(1) + 1; j++)
                    if (mas1[i, j, 0] != 0)
                    {
                        mas1[i, j, 0] = 0;
                        mas1[i, j, 1] = Byte.MaxValue;
                        mas1[i, j, 2] = 0;
                    }
            for (int i = 0; i < mas2.GetUpperBound(0) + 1; i++)
                for (int j = 0; j < mas2.GetUpperBound(1) + 1; j++)
                    if (mas2[i, j, 0] != 0)
                    {
                        mas2[i, j, 0] = Byte.MaxValue;
                        mas2[i, j, 1] = 0;
                        mas2[i, j, 2] = 0;
                    }

            for (int i = 0; i < mas2.GetUpperBound(0) + 1; i++)
                for (int j = 0; j < mas2.GetUpperBound(1) + 1; j++)
                {
                    mas1[i + offset.Y, j + offset.X, 0] += mas2[i, j, 0];
                    mas1[i + offset.Y, j + offset.X, 1] += mas2[i, j, 1];
                    mas1[i + offset.Y, j + offset.X, 2] += mas2[i, j, 2];
                }

            return Utils.ByteToBitmapRgb(mas1);
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
            Point offset = superImposition.FindBestImposition(masTested);

            //MessageBox.Show(point.X + " " + point.Y);

            pbImage.Image = OverlapTwoImage(masTested, masOrigin, offset);

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
