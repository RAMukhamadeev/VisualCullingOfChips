using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NIIPP.ComputerVision;

namespace ViewCullling
{
    public partial class FormAddNewProject : Form
    {
        public string _currResume = Resume.None;
        private string CurrResume
        {
            get { return _currResume; }
            set
            {
                lblCurrentResume.Text = value;
                _currResume = value;
            }
        }

        private string _pathToGoodChip1;
        private string _pathToGoodChip2;
        private string _pathToGoodChip3;

        private Bitmap _image1;
        private Bitmap _image2;
        private Bitmap _image3;

        private int _widthOfLine = 4;

        private List<Color> backgroundColors = new List<Color>();

        private struct Resume
        {
            public const string Cutting = "Cutting";
            public const string Segmentation = "Segmentation";
            public const string ChooseBackground = "ChooseBackground";
            public const string None = "None";
        }

        public FormAddNewProject()
        {
            InitializeComponent();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetDimensionsOfPositionTrackBars(Bitmap bmp)
        {
            trbLeftPosition.Maximum = bmp.Width / 2;
            trbRightPosition.Maximum = bmp.Width / 2;
            trbUpPosition.Maximum = bmp.Height / 2;
            trbDownPosition.Maximum = bmp.Height / 2;
        }

        private Bitmap DrawFrames(Bitmap bmp, int offsetRight, int offsetLeft, int offsetUp, int offsetDown)
        {
            Bitmap temp = (Bitmap) bmp.Clone();
            Graphics g = Graphics.FromImage(temp);
            Pen pen = new Pen(Brushes.OrangeRed, _widthOfLine);

            if (offsetRight > 0)
                g.DrawLine(pen, bmp.Width - offsetRight, bmp.Height - 1, bmp.Width - offsetRight, 1);
            if (offsetLeft > 0)
                g.DrawLine(pen, offsetLeft, bmp.Height - 1, offsetLeft, 1);
            if (offsetUp > 0)
                g.DrawLine(pen, 1, offsetUp, bmp.Width - 1, offsetUp);
            if (offsetDown > 0)
                g.DrawLine(pen, 1, bmp.Height - offsetDown, bmp.Width - 1, bmp.Height - offsetDown);

            return temp;
        }
     

        private void trbLeftPosition_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Cutting)
            {
                pbGoodChipImage.Image = DrawFrames(_image1, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
                GC.Collect();
            }

            RefreshCuttingLabels();
        }

        private void trbRightPosition_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Cutting)
            {
                pbGoodChipImage.Image = DrawFrames(_image1, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
                GC.Collect();
            }

            RefreshCuttingLabels();
        }

        private void trbUpPosition_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Cutting)
            {
                pbGoodChipImage.Image = DrawFrames(_image1, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
                GC.Collect();
            }

            RefreshCuttingLabels();
        }

        private void trbDownPosition_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Cutting)
            {
                pbGoodChipImage.Image = DrawFrames(_image1, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
                GC.Collect();
            }

            RefreshCuttingLabels();
        }

        private void RefreshSegmentationLabels()
        {
            lblRComp.Text = trbRComp.Value.ToString();
            lblGComp.Text = trbGComp.Value.ToString();
            lblBComp.Text = trbBComp.Value.ToString();
            lblLimit.Text = trbToleranceLimit.Value.ToString();
        }

        private void FormAddNewProject_Load(object sender, EventArgs e)
        {
            RefreshSegmentationLabels();
        }

        private void SegmentationWithCurrentParameters()
        {
            Color col = Color.FromArgb(trbRComp.Value, trbGComp.Value, trbBComp.Value);
            Segmentation segmentation = new Segmentation(_image1, col, trbToleranceLimit.Value);
            pbGoodChipImage.Image = segmentation.GetSegmentedPicture();
            GC.Collect();
        }

        private void trbRComp_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Segmentation)
                SegmentationWithCurrentParameters();
            RefreshSegmentationLabels();
        }

        private void trbGComp_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Segmentation)
                SegmentationWithCurrentParameters();
            RefreshSegmentationLabels();
        }

        private void trbBComp_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Segmentation)
                SegmentationWithCurrentParameters();
            RefreshSegmentationLabels();
        }

        private void trbToleranceLimit_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Segmentation)
                SegmentationWithCurrentParameters();
            RefreshSegmentationLabels();
        }

        private Bitmap CutBitmapImage(Bitmap bmp, int left, int right, int up, int down)
        {
            Rectangle rect = new Rectangle(left, up, bmp.Width - (left + right), bmp.Height - (up + down));
            return bmp.Clone(rect, bmp.PixelFormat);
        }

        private void обрезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrResume != Resume.Cutting)
                return;

            _image1 = CutBitmapImage(_image1, trbLeftPosition.Value, trbRightPosition.Value, trbUpPosition.Value,
                trbDownPosition.Value);
            pbGoodChipImage.Image = _image1;

            trbRightPosition.Value = 0;
            trbLeftPosition.Value = 0;
            trbUpPosition.Value = 0;
            trbDownPosition.Value = 0;
            RefreshCuttingLabels();

            SetDimensionsOfPositionTrackBars(_image1);
        }

        private void RefreshCuttingLabels()
        {
            lblRightOffset.Text = String.Format("{0} px", trbRightPosition.Value);
            lblLeftOffset.Text = String.Format("{0} px", trbLeftPosition.Value);
            lblUpOffset.Text = String.Format("{0} px", trbUpPosition.Value);
            lblDownOffset.Text = String.Format("{0} px", trbDownPosition.Value);
        }

        private void сегментироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SegmentationWithCurrentParameters();
        }

        private void показатьОригиналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbGoodChipImage.Image = _image1;
        }

        private void выборОбластиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CurrResume = Resume.Cutting;
            pbGoodChipImage.Image = DrawFrames(_image1, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
            GC.Collect();
        }

        private void сегментацияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CurrResume = Resume.Segmentation;
            SegmentationWithCurrentParameters();
        }

        private void выборЦветаФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrResume = Resume.ChooseBackground;
            pbGoodChipImage.Image = _image1;
        }

        private void нетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrResume = Resume.None;
            pbGoodChipImage.Image = _image1;
        }

        private void показатьСегментациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SegmentationWithCurrentParameters();
        }

        private void добавитьИзображениеГодногоЧипаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _pathToGoodChip1 = ofd.FileName;

                _image1 = new Bitmap(ofd.FileName);
                pbGoodChipImage.Image = _image1;

                SetDimensionsOfPositionTrackBars(_image1);
            }
        }

        private void pbGoodChipImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (CurrResume != Resume.ChooseBackground)
                return;

            Bitmap currImage = _image1;

            double xZoom = ( (double)(e.X) / pbGoodChipImage.Width);
            double yZoom = ( (double)(e.Y) / pbGoodChipImage.Height);
            int x = (int)(xZoom * currImage.Width);
            int y = (int)(yZoom * currImage.Height);
            y = (y >= currImage.Height) ? currImage.Height - 1 : y;
            x = (x >= currImage.Width) ? currImage.Width - 1 : x;

            backgroundColors.Add(_image1.GetPixel(x, y));


            double r = 0, g = 0, b = 0;
            foreach (Color col in backgroundColors)
            {
                r += col.R;
                g += col.G;
                b += col.B;
            }
            r /= backgroundColors.Count;
            g /= backgroundColors.Count;
            b /= backgroundColors.Count;

            trbRComp.Value = (int) r;
            trbGComp.Value = (int) g;
            trbBComp.Value = (int) b;

            pbBackgroundColor.BackColor = Color.FromArgb( (int)r, (int)g, (int)b );

            RefreshSegmentationLabels();
        }

        private void pbGoodChipImage_Click(object sender, EventArgs e)
        {

        }

    }
}
