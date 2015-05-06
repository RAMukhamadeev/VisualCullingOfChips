using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormAddNewProject : Form
    {
        private string _currResume = Resume.None;
        private string CurrResume
        {
            get { return _currResume; }
            set
            {
                lblCurrentResume.Text = value;
                _currResume = value;
            }
        }

        private readonly List<string> _pathToGoodChips = new List<string>();
        private readonly List<Bitmap> _images = new List<Bitmap>();
        private readonly List<Color> _backgroundColors = new List<Color>();
        private Bitmap _currImage;

        private const int WidthOfLine = 4;

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
            Pen pen = new Pen(Brushes.OrangeRed, WidthOfLine);

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

        private void DrawFrame()
        {
            pbGoodChipImage.Image = DrawFrames(_currImage, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
            GC.Collect();
        }

        private void trbLeftPosition_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Cutting)
            {
                DrawFrame();
            }

            RefreshCuttingLabels();
        }

        private void trbRightPosition_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Cutting)
            {
                DrawFrame();
            }

            RefreshCuttingLabels();
        }

        private void trbUpPosition_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Cutting)
            {
                DrawFrame();
            }

            RefreshCuttingLabels();
        }

        private void trbDownPosition_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Cutting)
            {
                DrawFrame();
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

        private void FillColorIndicator()
        {
            pbBackgroundColor.BackColor = Color.FromArgb(trbRComp.Value, trbGComp.Value, trbBComp.Value);
        }

        private void FormAddNewProject_Load(object sender, EventArgs e)
        {
            RefreshSegmentationLabels();
        }

        private void SegmentationWithCurrentParameters()
        {
            Color col = Color.FromArgb(trbRComp.Value, trbGComp.Value, trbBComp.Value);
            Segmentation segmentation = new Segmentation(col, trbToleranceLimit.Value);
            pbGoodChipImage.Image = segmentation.GetSegmentedPicture(_currImage);
            GC.Collect();
        }

        private void trbRComp_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Segmentation)
                SegmentationWithCurrentParameters();
            RefreshSegmentationLabels();
            FillColorIndicator();
        }

        private void trbGComp_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Segmentation)
                SegmentationWithCurrentParameters();
            RefreshSegmentationLabels();
            FillColorIndicator();
        }

        private void trbBComp_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Segmentation)
                SegmentationWithCurrentParameters();
            RefreshSegmentationLabels();
            FillColorIndicator();
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

        private Bitmap CutBitmapImage(Bitmap bmp, Point offset, int width, int height)
        {
            Rectangle rect = new Rectangle(offset.X, offset.Y, width, height);
            return bmp.Clone(rect, bmp.PixelFormat);
        }

        private void обрезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrResume != Resume.Cutting)
                return;

            // определяем позицию текущего изображения на форме
            int pos = _images.IndexOf(_currImage);

            // обрезаем изображение на форме
            _images[pos] = CutBitmapImage(_images[pos], trbLeftPosition.Value, trbRightPosition.Value, trbUpPosition.Value, trbDownPosition.Value);


            Color col = Color.FromArgb(trbRComp.Value, trbGComp.Value, trbBComp.Value);

            Segmentation segmentation = new Segmentation(col, trbToleranceLimit.Value);
            byte[,,] originMas = segmentation.GetSegmentedMass(_images[pos]);

            SuperImposition superImposition = new SuperImposition(originMas);
            for (int i = 0; i < _images.Count; i++)
            {
                if (i == pos)
                    continue;

                byte[, ,] currMas = segmentation.GetSegmentedMass(_images[i]);
                Point offset = superImposition.FindBestImposition(currMas);
                _images[i] = CutBitmapImage(_images[i], offset, _images[pos].Width, _images[pos].Height);
            }

            _currImage = _images[pos];
            pbGoodChipImage.Image = _currImage;

            trbRightPosition.Value = 0;
            trbLeftPosition.Value = 0;
            trbUpPosition.Value = 0;
            trbDownPosition.Value = 0;
            RefreshCuttingLabels();
            SetDimensionsOfPositionTrackBars(_currImage);
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
            pbGoodChipImage.Image = _currImage;
        }

        private void выборОбластиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CurrResume = Resume.Cutting;
            pbGoodChipImage.Image = DrawFrames(_currImage, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
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
            pbGoodChipImage.Image = _currImage;
        }

        private void нетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrResume = Resume.None;
            pbGoodChipImage.Image = _currImage;
        }

        private void показатьСегментациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SegmentationWithCurrentParameters();
        }

        private void добавитьИзображениеГодногоЧипаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGoodChipImage();
        }

        private void CreateUnion()
        {
            Color col = Color.FromArgb(trbRComp.Value, trbGComp.Value, trbBComp.Value);
            Bitmap res = Utils.UnionOfImages(col, trbToleranceLimit.Value, _images);

            FormUnionOfPictures formUnionOfPictures = new FormUnionOfPictures();
            formUnionOfPictures.Show();
            formUnionOfPictures.SetImage(res);
        }

        private void LoadGoodChipImage()
        {
            OpenFileDialog ofd = new OpenFileDialog {Multiselect = true};
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string path in ofd.FileNames)
                {
                    AddImage(path);
                }
                lblPosition.Text = String.Format("{0} из {1}", _images.IndexOf(_currImage) + 1, _images.Count);
                lblNameOfFile.Text = Path.GetFileName(_pathToGoodChips[_images.IndexOf(_currImage)]);
                pbGoodChipImage.Image = _currImage;
                SetDimensionsOfPositionTrackBars(_currImage);
            }
        }

        private void AddImage(string path)
        {
            _pathToGoodChips.Add(path);
            _currImage = new Bitmap(path);
            _images.Add(_currImage);
        }

        private void pbGoodChipImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (CurrResume != Resume.ChooseBackground)
                return;

            double xZoom = ( (double)(e.X) / pbGoodChipImage.Width);
            double yZoom = ( (double)(e.Y) / pbGoodChipImage.Height);
            int x = (int)(xZoom * _currImage.Width);
            int y = (int)(yZoom * _currImage.Height);
            y = (y >= _currImage.Height) ? _currImage.Height - 1 : y;
            x = (x >= _currImage.Width) ? _currImage.Width - 1 : x;

            _backgroundColors.Add(_currImage.GetPixel(x, y));


            double r = 0, g = 0, b = 0;
            foreach (Color col in _backgroundColors)
            {
                r += col.R;
                g += col.G;
                b += col.B;
            }
            r /= _backgroundColors.Count;
            g /= _backgroundColors.Count;
            b /= _backgroundColors.Count;

            trbRComp.Value = (int) r;
            trbGComp.Value = (int) g;
            trbBComp.Value = (int) b;

            RefreshSegmentationLabels();
            FillColorIndicator();
        }

        private void pbGoodChipImage_Click(object sender, EventArgs e)
        {
            if (_currResume == Resume.None)
            {
                LoadGoodChipImage();
            }
        }

        private void pbRightArrow_Click(object sender, EventArgs e)
        {
            int pos = _images.IndexOf(_currImage);
            if (pos < _images.Count - 1)
            {
                pos++;
            }
            else
            {
                pos = 0;
            }

            _currImage = _images[pos];
            pbGoodChipImage.Image = _currImage;

            lblPosition.Text = String.Format("{0} из {1}", pos + 1, _images.Count);
            lblNameOfFile.Text = Path.GetFileName(_pathToGoodChips[pos]);

            if (CurrResume == Resume.Segmentation)
                SegmentationWithCurrentParameters();
            if (CurrResume == Resume.Cutting)
                DrawFrame();
        }

        private void pbLeftArrow_Click(object sender, EventArgs e)
        {
            int pos = _images.IndexOf(_currImage);
            if (pos > 0)
            {
                pos--;
            }
            else
            {
                pos = _images.Count - 1;
            }

            _currImage = _images[pos];
            pbGoodChipImage.Image = _currImage;

            lblPosition.Text = String.Format("{0} из {1}", pos + 1, _images.Count);
            lblNameOfFile.Text = Path.GetFileName(_pathToGoodChips[pos]);

            if (CurrResume == Resume.Segmentation)
                SegmentationWithCurrentParameters();
            if (CurrResume == Resume.Cutting)
                DrawFrame();
        }

        private void создатьОбъединениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUnion();
        }

    }
}
