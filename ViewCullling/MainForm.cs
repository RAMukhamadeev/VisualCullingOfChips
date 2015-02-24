using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;
using NIIPP.ComputerVision;



namespace ViewCullling
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        bool IsBackground(byte r, byte g, byte b)
        {
            int delta = Math.Abs(95 - r) + Math.Abs(107 - g) + Math.Abs(237 - b);
            return delta < 120;
        }

        byte[, ,] mas;
        int width, height;

        void ProcessPicture()
        {
            int rad = 5;
            int[] dx = { 0, 0, rad, rad };
            int[] dy = { 0, rad, 0, rad };
            int width = mas.GetUpperBound(2) + 1,
                height = mas.GetUpperBound(1) + 1;

            for (int i = 0; i < height - rad; i++)
                for (int j = 0; j < width - rad; j++)
                {
                    bool curRes = true;
                    for (int k = 0; k < dx.Length; k++)
                    {
                        if (!IsBackground(mas[0, i + dy[k], j + dx[k]], mas[1, i + dy[k], j + dx[k]], mas[2, i + dy[k], j + dx[k]]))
                        {
                            curRes = false;
                            break;
                        }
                    }
                    if (curRes)
                        FillBackground(i, j);
                }

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                { 
                    if (mas[0, i, j] != 0 || mas[1, i, j] != 0 || mas[2, i, j] != 0)
                    {
                        mas[0, i, j] = 174;
                        mas[1, i, j] = 179;
                        mas[2, i, j] = 23;
                    }
                }
        }

        void FillBackground(int ist, int jst)
        {
            int[] di = { 0, 0, 1, -1, -1, 1, -1, 1 };
            int[] dj = { 1, -1, 0, 0, -1, 1, 1, -1 };
            Stack<Point> st = new Stack<Point>();
            st.Push(new Point(ist, jst));
            mas[0, ist, jst] = 0;
            mas[1, ist, jst] = 0;
            mas[2, ist, jst] = 0;

            Point curPoint;
            while (st.Count > 0)
            {
                curPoint = st.Pop();
                for (int k = 0; k < di.Length; k++)
                {
                    int i = curPoint.X + di[k],
                        j = curPoint.Y + dj[k];
                    if (i < 0 || i >= height || j < 0 || j >= width)
                        continue;

                    if (IsBackground(mas[0, i, j], mas[1, i, j], mas[2, i, j]))
                    {
                        st.Push(new Point(i, j));
                        mas[0, i, j] = 0;
                        mas[1, i, j] = 0;
                        mas[2, i, j] = 0;
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap("OUT__12_5__percent.bmp");
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            
            mas = BitmapToByteRgb(bmp);
            width = mas.GetUpperBound(2) + 1;
            height = mas.GetUpperBound(1) + 1;

            ProcessPicture();

            Bitmap newBmp = ByteToBitmapRgb(mas);
            pbImage.Image = newBmp;

            newBmp.Save("procc.bmp");
        }
    }
}
