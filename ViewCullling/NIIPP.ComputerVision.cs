using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace NIIPP.ComputerVision
{
    public class Segmentation
    {
        private byte[,,] _masRgb;
        readonly int _height,
                     _width;

        public Segmentation(Bitmap innerPic)
        {
            _masRgb = Utils.BitmapToByteRgb(innerPic);
            _height = _masRgb.GetUpperBound(0) + 1;
            _width = _masRgb.GetUpperBound(1) + 1;
        }

        private bool IsBackground(byte r, byte g, byte b)
        {
            int delta = Math.Abs(63 - r) + Math.Abs(50 - g) + Math.Abs(100 - b);
            return delta < 50;

            //int delta = Math.Abs(95 - r) + Math.Abs(110 - g) + Math.Abs(232 - b);
            //return delta < 120;

            //int delta = Math.Abs(72 - r) + Math.Abs(88 - g) + Math.Abs(185 - b);
            //return delta < 90;

            // серый
            //int delta = Math.Abs(140 - r) + Math.Abs(143 - g) + Math.Abs(152 - b);
            //return delta < 150;

            // OUT__50__percent
            //int delta = Math.Abs(10 - r) + Math.Abs(20 - g) + Math.Abs(115 - b);
            //return delta < 135;

            //призма Т
            //int delta = Math.Abs(107 - r) + Math.Abs(83 - g) + Math.Abs(189 - b);
            //return delta < 115;
        }

        private void ReleaseSegmentation()
        {
            int rad = 5;
            int[] dx = { 0, 0, rad, rad };
            int[] dy = { 0, rad, 0, rad };

            for (int i = 0; i < _height - rad; i++)
                for (int j = 0; j < _width - rad; j++)
                {
                    bool curRes = true;
                    for (int k = 0; k < dx.Length; k++)
                    {
                        if (!IsBackground(_masRgb[i + dy[k], j + dx[k], 0], _masRgb[i + dy[k], j + dx[k], 1], _masRgb[i + dy[k], j + dx[k], 2]))
                        {
                            curRes = false;
                            break;
                        }
                    }
                    if (curRes)
                        FillBackground(i, j);
                }

            for (int i = 0; i < _height; i++)
                for (int j = 0; j < _width; j++)
                {
                    if (_masRgb[i, j, 0] != 0 || _masRgb[i, j, 1] != 0 || _masRgb[i, j, 2] != 0)
                    {
                        _masRgb[i, j, 0] = 174;
                        _masRgb[i, j, 1] = 179;
                        _masRgb[i, j, 2] = 23;
                    }
                }
        }

        public Bitmap GetSegmentedPicture()
        {
            ReleaseSegmentation();

            Bitmap outerPic = Utils.ByteToBitmapRgb(_masRgb);
            return outerPic;
        }

        public byte[,,] GetSegmentedMass()
        {
            ReleaseSegmentation();

            return _masRgb;
        }

        void FillBackground(int ist, int jst)
        {
            int height = _masRgb.GetUpperBound(0) + 1,
                width = _masRgb.GetUpperBound(1) + 1;

            int[] di = { 0, 0, 1, -1, -1, 1, -1, 1 };
            int[] dj = { 1, -1, 0, 0, -1, 1, 1, -1 };
            Stack<Point> st = new Stack<Point>();
            st.Push(new Point(ist, jst));
            _masRgb[ist, jst, 0] = 0;
            _masRgb[ist, jst, 1] = 0;
            _masRgb[ist, jst, 2] = 0;

            while (st.Count > 0)
            {
                Point currPoint = st.Pop();
                for (int k = 0; k < di.Length; k++)
                {
                    int i = currPoint.X + di[k],
                        j = currPoint.Y + dj[k];
                    if (i < 0 || i >= height || j < 0 || j >= width)
                        continue;

                    if (IsBackground(_masRgb[i, j, 0], _masRgb[i, j, 1], _masRgb[i, j, 2]))
                    {
                        st.Push(new Point(i, j));

                        _masRgb[i, j, 0] = 0;
                        _masRgb[i, j, 1] = 0;
                        _masRgb[i, j, 2] = 0;
                    }
                }
            }
        }
    }

    public class VisualInspect
    {
        private readonly byte[,,] _segmentedMassGoodChip;
        private readonly int _widthOfGood;
        private readonly int _heightOfGood;

        private readonly Bitmap _originGoodChip;
        private Bitmap _nextChipForTest;

        public string CurrVerdict { get; private set; }
        public int CurrMark { get; private set; }

        public VisualInspect(string pathToGoodChipFile)
        {
            // сохраняем оригинальное изображение
            _originGoodChip = new Bitmap(pathToGoodChipFile);

            // сегментируем оригинал
            Segmentation segm = new Segmentation(_originGoodChip);
            _segmentedMassGoodChip = segm.GetSegmentedMass();
            _heightOfGood = _segmentedMassGoodChip.GetUpperBound(0) + 1;
            _widthOfGood = _segmentedMassGoodChip.GetUpperBound(1) + 1;

        }

        private Point FindBestSuperposition(byte[,,] nextPicMass)
        {
            Point offset = new Point(0, 0);

            int minDiff = Int32.MaxValue;
            Point bestOffset = new Point(0, 0);

            // ищем по высоте
            offset.X = bestOffset.X;
            int bestY = bestOffset.Y;
            for (int i = -200; i <= 200; i++)
            {
                offset.Y = bestY + i;
                int currRes = CheckSuperpositionBruteforce(nextPicMass, offset);
                // если нашли минимальный результат - сохраняем
                if (currRes < minDiff)
                {
                    minDiff = currRes;
                    bestOffset.Y = offset.Y;
                }
            }

            // ищем по ширине
            offset.Y = bestOffset.Y;
            int bestX = bestOffset.X;
            for (int j = -200; j <= 200; j++)
            {
                offset.X = bestX + j;
                int currRes = CheckSuperpositionBruteforce(nextPicMass, offset);
                // если нашли минимальный результат - сохраняем
                if (currRes < minDiff)
                {
                    minDiff = currRes;
                    bestOffset.X = offset.X;
                }
            }

            return bestOffset;
        }

        private int CheckSuperpositionBruteforce(byte[,,] nextPicMass, Point offset)
        {
            // проверка на выход за границы массива
            int currHeight = nextPicMass.GetUpperBound(0) + 1,
                currWidth = nextPicMass.GetUpperBound(1) + 1;
            if (_heightOfGood + offset.Y > currHeight || offset.Y < 0 || _widthOfGood + offset.X > currWidth || offset.X < 0)
                return Int32.MaxValue;

            int res = 0;
            for (int i = 0; i < _heightOfGood / 4; i++)
                for (int j = 0; j < _widthOfGood / 4; j++)
                    if (_segmentedMassGoodChip[i, j, 0] != nextPicMass[i + offset.Y, j + offset.X, 0])
                        res++;

            return res;
        }

        public Bitmap CheckNextChip(string pathToChipFile)
        {
            // сегментируем очередной чип, который нужно проверить
            Bitmap bmp = new Bitmap(pathToChipFile);
            Segmentation segm = new Segmentation(bmp);
            byte[,,] segmentedMass = segm.GetSegmentedMass();

            // сохраняем изображение очередного чипа
            _nextChipForTest = bmp;

            // находим наилучшее совмещение
            Point offset = FindBestSuperposition(segmentedMass);

            // сравниваем хороший чип и очередной тестируемый
            Bitmap picWithSprites = CheckChipForDamage(segmentedMass, offset);

            return picWithSprites;
        }

        private bool ColorsEqual(byte[,,] mas1, byte[,,] mas2, int i, int j, Point offset)
        {
            return mas1[i, j, 0] == mas2[i + offset.Y, j + offset.X, 0];
        }

        private int AnalyzeIslandOfPixels(int si, int sj, Point offset, byte[,,] nextPicMass, ref byte[,,] nextChipWithSprites, ref bool[,] isAnalyzed)
        {
            int[] di = {-1, 1, 0, 0};
            int[] dj = {0, 0, 1, -1};

            // проходим по всем пикселям этого острова и кладем их в лист
            List<Point> queue = new List<Point>();
            queue.Add(new Point(sj, si));
            isAnalyzed[si, sj] = true;
            int currPos = 0;
            while (currPos < queue.Count)
            {
                Point currPoint = queue[currPos];
                int i = currPoint.Y,
                    j = currPoint.X;

                for (int k = 0; k < di.Length; k++)
                {
                    int curri = i + di[k],
                        currj = j + dj[k];
                    if (curri >= _heightOfGood || currj >= _widthOfGood || curri < 0 || currj < 0)
                        continue;

                    if (!isAnalyzed[curri, currj] && !ColorsEqual(_segmentedMassGoodChip, nextPicMass, curri, currj, offset))
                    {
                        queue.Add(new Point(currj, curri));
                        isAnalyzed[curri, currj] = true;
                    }
                }
                currPos++;
            }

            // оцениваем остров по параметрам
            int maxi = 0, maxj = 0, mini = Int32.MaxValue, minj = Int32.MaxValue; 
            foreach (Point nextPoint in queue)
            {
                int i = nextPoint.Y,
                    j = nextPoint.X;

                maxi = Math.Max(maxi, i);
                maxj = Math.Max(maxj, j);
                mini = Math.Min(mini, i);
                minj = Math.Min(minj, j);
            }

            bool isDamage = !(maxi - mini < 10 || maxj - minj < 10 || queue.Count < 100 || (maxi - mini)*(maxj - minj) > 5 * queue.Count);

            if (isDamage)
            {
                // закрашиваем остров - повреждение
                foreach (Point nextPoint in queue)
                {
                    int curri = nextPoint.Y,
                        currj = nextPoint.X;
                    nextChipWithSprites[curri + offset.Y, currj + offset.X, 0] = Color.Coral.R;
                    nextChipWithSprites[curri + offset.Y, currj + offset.X, 1] = Color.Coral.G;
                    nextChipWithSprites[curri + offset.Y, currj + offset.X, 2] = Color.Coral.B;
                }

                // рисуем рамку
                mini -= 4;
                minj -= 4;
                maxj += 4;
                maxi += 4;

                int limitForI = nextChipWithSprites.GetUpperBound(0) - 1 - offset.Y,
                    limitForJ = nextChipWithSprites.GetUpperBound(1) - 1 - offset.X;

                mini = Math.Max(mini, 1);
                maxi = Math.Min(maxi, limitForI);
                minj = Math.Max(minj, 1);
                maxj = Math.Min(maxj, limitForJ);

                for (int i = mini - 1; i <= mini + 1; i++)
                {
                    for (int j = minj; j <= maxj; j++)
                    {
                        nextChipWithSprites[i + offset.Y, j + offset.X, 0] = Color.GreenYellow.R;
                        nextChipWithSprites[i + offset.Y, j + offset.X, 1] = Color.GreenYellow.G;
                        nextChipWithSprites[i + offset.Y, j + offset.X, 2] = Color.GreenYellow.B;
                    }
                }
                for (int i = maxi - 1; i <= maxi + 1; i++)
                {
                    for (int j = minj; j <= maxj; j++)
                    {
                        nextChipWithSprites[i + offset.Y, j + offset.X, 0] = Color.GreenYellow.R;
                        nextChipWithSprites[i + offset.Y, j + offset.X, 1] = Color.GreenYellow.G;
                        nextChipWithSprites[i + offset.Y, j + offset.X, 2] = Color.GreenYellow.B;
                    }
                }
                for (int j = minj - 1; j <= minj + 1; j++)
                {
                    for (int i = mini; i <= maxi; i++)
                    {
                        nextChipWithSprites[i + offset.Y, j + offset.X, 0] = Color.GreenYellow.R;
                        nextChipWithSprites[i + offset.Y, j + offset.X, 1] = Color.GreenYellow.G;
                        nextChipWithSprites[i + offset.Y, j + offset.X, 2] = Color.GreenYellow.B;
                    }
                }
                for (int j = maxj - 1; j <= maxj + 1; j++)
                {
                    for (int i = mini; i <= maxi; i++)
                    {
                        nextChipWithSprites[i + offset.Y, j + offset.X, 0] = Color.GreenYellow.R;
                        nextChipWithSprites[i + offset.Y, j + offset.X, 1] = Color.GreenYellow.G;
                        nextChipWithSprites[i + offset.Y, j + offset.X, 2] = Color.GreenYellow.B;
                    }
                }
            }

            return isDamage ? queue.Count : 0;
        }

        private Bitmap CheckChipForDamage(byte[,,] nextPicMass, Point offset)
        {
            bool[,] isAnalyzed = new bool[_heightOfGood, _widthOfGood];

            byte[,,] nextChipWithSprites = Utils.BitmapToByteRgb(_nextChipForTest);
            int diff = 0;
            for (int i = 0; i < _heightOfGood; i++)
                for (int j = 0; j < _widthOfGood; j++)
                {
                    if (!isAnalyzed[i, j] && (!ColorsEqual(_segmentedMassGoodChip, nextPicMass, i, j, offset)))
                    {
                        diff += AnalyzeIslandOfPixels(i, j, offset, nextPicMass, ref nextChipWithSprites, ref isAnalyzed);
                        //nextChipWithSprites[i + offset.Y, j + offset.X, 0] = Color.Coral.R;
                        //nextChipWithSprites[i + offset.Y, j + offset.X, 1] = Color.Coral.G;
                        //nextChipWithSprites[i + offset.Y, j + offset.X, 2] = Color.Coral.B;
                    }
                }

            CurrMark = diff;
            return Utils.ByteToBitmapRgb(nextChipWithSprites);
        }
    }

    static class Utils
    {
        /// <summary>
        /// Преобразовывает изображение в формате bmp в массив
        /// </summary>
        /// <param name="bmp">Изображение в формате bmp</param>
        /// <returns>Трехмерный массив (высота, ширина, цвет[0 - R, 1 - G, 2 - B])</returns>
        public static unsafe byte[, ,] BitmapToByteRgb(Bitmap bmp)
        {
            int width = bmp.Width,
                height = bmp.Height;
            byte[, ,] res = new byte[height, width, 3];
            BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            try
            {
                for (int h = 0; h < height; h++)
                {
                    byte* currPos = ((byte*)bd.Scan0) + h * bd.Stride;
                    for (int w = 0; w < width; w++)
                    {
                        res[h, w, 2] = *(currPos++);
                        res[h, w, 1] = *(currPos++);
                        res[h, w, 0] = *(currPos++);
                    }
                }
            }
            finally
            {
                bmp.UnlockBits(bd);
            }
            return res;
        }

        /// <summary>
        /// Преобразовывает трехмерный массив в изображение в формате bmp
        /// </summary>
        /// <param name="mas">Трехмерный массив (высота, ширина, цвет[0 - R, 1 - G, 2 - B])</param>
        /// <returns>Изображение в формате bmp</returns>
        public static unsafe Bitmap ByteToBitmapRgb(byte[, ,] mas)
        {
            int height = mas.GetUpperBound(0) + 1,
                width = mas.GetUpperBound(1) + 1;
            Bitmap bmpRes = new Bitmap(width, height);
            BitmapData bd = bmpRes.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);
            try
            {
                for (int h = 0; h < height; h++)
                {
                    byte* currPos = ((byte*)bd.Scan0) + h * bd.Stride;
                    for (int w = 0; w < width; w++)
                    {
                        *(currPos++) = mas[h, w, 2];
                        *(currPos++) = mas[h, w, 1];
                        *(currPos++) = mas[h, w, 0];
                    }
                }
            }
            finally
            {
                bmpRes.UnlockBits(bd);
            }
            return bmpRes;
        }
    }
}
