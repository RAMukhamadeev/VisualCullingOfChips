using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewCullling
{
    public partial class FormAddNewProject : Form
    {
        private string PathToGoodChip1;
        private string PathToGoodChip2;
        private string PathToGoodChip3;

        private Bitmap Image1;
        private Bitmap Image2;
        private Bitmap Image3;

        private int _widthOfLine = 7;

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

        private void pbGoodChip1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PathToGoodChip1 = ofd.FileName;

                Image1 = new Bitmap(ofd.FileName);
                pbGoodChip1.Image = Image1;

                SetDimensionsOfPositionTrackBars(Image1);
            }
        }

        private void pbGoodChip2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PathToGoodChip2 = ofd.FileName;
                Image2 = new Bitmap(ofd.FileName);
                pbGoodChip2.Image = Image2;
            }
        }

        private void pbGoodChip3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PathToGoodChip3 = ofd.FileName;
                Image3 = new Bitmap(ofd.FileName);
                pbGoodChip3.Image = Image3;
            }
        }

        private void trbLeftPosition_Scroll(object sender, EventArgs e)
        {
            pbGoodChip1.Image = DrawFrames(Image1, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
            pbGoodChip2.Image = DrawFrames(Image2, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
            pbGoodChip3.Image = DrawFrames(Image3, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);

            GC.Collect();
        }

        private void trbRightPosition_Scroll(object sender, EventArgs e)
        {
            pbGoodChip1.Image = DrawFrames(Image1, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
            pbGoodChip2.Image = DrawFrames(Image2, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
            pbGoodChip3.Image = DrawFrames(Image3, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);

            GC.Collect();
        }

        private void trbUpPosition_Scroll(object sender, EventArgs e)
        {
            pbGoodChip1.Image = DrawFrames(Image1, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
            pbGoodChip2.Image = DrawFrames(Image2, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
            pbGoodChip3.Image = DrawFrames(Image3, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);

            GC.Collect();
        }

        private void trbDownPosition_Scroll(object sender, EventArgs e)
        {
            pbGoodChip1.Image = DrawFrames(Image1, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
            pbGoodChip2.Image = DrawFrames(Image2, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
            pbGoodChip3.Image = DrawFrames(Image3, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);

            GC.Collect();
        }

        private void FormAddNewProject_Load(object sender, EventArgs e)
        {

        }

    }
}
