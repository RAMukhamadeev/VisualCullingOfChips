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



namespace ViewCullling
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public unsafe byte[, ,] BitmapToByteRGB(Bitmap bmp)
        {
            int width = bmp.Width,
                height = bmp.Height;
            byte[, ,] res = new byte[3, height, width];
            BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);
            try
            {
                byte* curpos;
                for (int h = 0; h < height; h++)
                {
                    curpos = ((byte*)bd.Scan0) + h * bd.Stride;
                    for (int w = 0; w < width; w++)
                    {
                        res[2, h, w] = *(curpos++);
                        res[1, h, w] = *(curpos++);
                        res[0, h, w] = *(curpos++);
                    }
                }
            }
            finally
            {
                bmp.UnlockBits(bd);
            }
            return res;
        }

        public unsafe Bitmap ByteToBitmapRGB(byte[, ,] mas)
        {
            //  byte[, ,] mas = new byte[3, height, width];
            int width = mas.GetUpperBound(2) + 1,
                height = mas.GetUpperBound(1) + 1;
            Bitmap bmpRes = new Bitmap(width, height);
            BitmapData bd = bmpRes.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);
            try
            {
                byte* curpos;
                for (int h = 0; h < height; h++)
                {
                    curpos = ((byte*)bd.Scan0) + h * bd.Stride;
                    for (int w = 0; w < width; w++)
                    {
                        *(curpos++) = mas[2, h, w];
                        *(curpos++) = mas[1, h, w];
                        *(curpos++) = mas[0, h, w];
                    }
                }
            }
            finally
            {
                bmpRes.UnlockBits(bd);
            }
            return bmpRes;
        }

        //int[] di = {0, 0, 2, -2, -2, 2, -2, 2};
        //int[] dj = {2, -2, 0, 0, -2, 2, 2, -2};
        //int[] di = { 0, 0, 1, -1, -1, 1, -1, 1 };
        //int[] dj = { 1, -1, 0, 0, -1, 1, 1, -1 };
        // нахождение границ
        //for (int i = 2; i < height - 2; i++)
        //    for (int j = 2; j < width - 2; j++)
        //    {
        //        int countOfEdge = 0;

        //        for (int k = 0; k < 8; k++)
        //        {
        //            int delta = Math.Abs(mas[0, i, j] - mas[0, i + di[k], j + dj[k]]) +
        //                        Math.Abs(mas[1, i, j] - mas[1, i + di[k], j + dj[k]]) +
        //                        Math.Abs(mas[2, i, j] - mas[2, i + di[k], j + dj[k]]);
        //            if (delta > 45)
        //                countOfEdge++;
        //        }
        //        if (countOfEdge >= 2)
        //        {
        //            res[0, i, j] = 255;
        //            res[1, i, j] = 0;
        //            res[2, i, j] = 0;
        //        }
        //    }

        //byte[, ,] ProcessPicture(byte[, ,] mas)
        //{
        //    int width = mas.GetUpperBound(2) + 1,
        //        height = mas.GetUpperBound(1) + 1;
        //    byte[, ,] res = new byte[3, height, width];
            
        //    for (int i = 0; i < height; i++)
        //        for (int j = 0; j < width; j++)
        //        {
        //            int delta = Math.Abs(mas[0, i, j] - 95) +
        //                Math.Abs(mas[1, i, j] - 107) +
        //                Math.Abs(mas[2, i, j] - 237);

        //            if (delta > 110)
        //            {
        //                res[0, i, j] = 155;
        //                res[1, i, j] = 45;
        //                res[2, i, j] = 165;
        //            }
        //            else
        //            {
        //                res[0, i, j] = 255;
        //                res[1, i, j] = 255;
        //                res[2, i, j] = 255;
        //            }
        //        }

        //    return res;
        //}


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

            // убираем артефакты
            RemoveArtifacts();
            RemoveArtifacts();
            RemoveArtifacts();
        }

        void CorrectPix(int i, int j)
        {
            int[] di = { 0, 0, 1, -1 };
            int[] dj = { 1, -1, 0, 0 };
            bool res = false;

            int countOfDiff = 0;
            byte r = 0, g = 0, b = 0;
            for (int k = 0; k < di.Length; k++)
            {
                int curi = i + di[k],
                    curj = j + dj[k];
                if (curi < 0 || curi >= height || curj < 0 || curj >= width)
                    continue;
                if (IsDifferent(i, j, curi, curj))
                {
                    countOfDiff++;
                    r = mas[0, curi, curj];
                    g = mas[1, curi, curj];
                    b = mas[2, curi, curj];
                }
            }
            if (countOfDiff >= 3)
            {
                mas[0, i, j] = r;
                mas[1, i, j] = g;
                mas[2, i, j] = b;
                res = true;
            }
        }

        void RemoveArtifacts()
        {

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    CorrectPix(i, j);
                }
        }

        bool IsDifferent(int i1, int j1, int i2, int j2)
        {
            if (mas[0, i1, j1] == mas[0, i2, j2] && mas[1, i1, j1] == mas[1, i2, j2] && mas[2, i1, j1] == mas[2, i2, j2])
                return true;
            else
                return false;
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
            Bitmap bmp = new Bitmap("14_02.bmp");
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            
            mas = BitmapToByteRGB(bmp);
            width = mas.GetUpperBound(2) + 1;
            height = mas.GetUpperBound(1) + 1;

            ProcessPicture();

            Bitmap newBmp = ByteToBitmapRGB(mas);
            pbImage.Image = newBmp;

            newBmp.Save("procc.bmp");
        }
    }
}
