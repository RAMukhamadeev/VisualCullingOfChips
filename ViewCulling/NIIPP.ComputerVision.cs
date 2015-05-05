using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace NIIPP.ComputerVision
{
    /// <summary>
    /// Класс для сегментации изображений
    /// </summary>
    public class Segmentation
    {
        /// <summary>
        /// Минимальный радиус фоновой области, из которой начинается заливка изображения фоновыми пикселями
        /// </summary>
        private int RadiusOfStartFilling { get; set; }
        /// <summary>
        /// Трехмерный массив - двумерный массив пикселей + 3 измерение RGB компоненты
        /// </summary>
        private readonly byte[,,] _masRgb;
        /// <summary>
        /// Высота изображения
        /// </summary>
        private readonly int _height;
        /// <summary>
        /// Ширина изображения
        /// </summary>
        private readonly int _width;

        // RGB-компоненты цвета фона
        private readonly int 
            _backColR,
            _backColG,
            _backColB;
        /// <summary>
        /// Допустимое отклонение фонового пикселя
        /// </summary>
        private readonly int _delta;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="innerPic">Изображение, которое необходимо сегментировать в формате Bitmap</param>
        /// <param name="backgroundColor">Цвет фона изображения</param>
        /// <param name="delta">Допустимое отклонение фонового пикселя</param>
        public Segmentation(Bitmap innerPic, Color backgroundColor, int delta)
        {
            _masRgb = Utils.BitmapToByteRgb(innerPic);
            _height = _masRgb.GetUpperBound(0) + 1;
            _width = _masRgb.GetUpperBound(1) + 1;
            _backColR = backgroundColor.R;
            _backColG = backgroundColor.G;
            _backColB = backgroundColor.B;
            _delta = delta;

            RadiusOfStartFilling = 15;
        }

        /// <summary>
        /// Проверяет является ли переданный пиксель фоновым
        /// </summary>
        /// <param name="r">R-компонента пикселя</param>
        /// <param name="g">G-компонента пикселя</param>
        /// <param name="b">B-компонента пикселя</param>
        /// <returns>True - это пиксель фона, False - это не пиксель фона</returns>
        private bool IsBackground(byte r, byte g, byte b)
        {
            return Math.Abs(_backColR - r) + Math.Abs(_backColG - g) + Math.Abs(_backColB - b) <= _delta;
        }

        /// <summary>
        /// Выполняет сегментацию изображения
        /// </summary>
        private void ReleaseSegmentation()
        {
            int[] dx = { 0, 0, RadiusOfStartFilling, RadiusOfStartFilling, RadiusOfStartFilling / 2, 0, RadiusOfStartFilling / 2, RadiusOfStartFilling, RadiusOfStartFilling / 2 };
            int[] dy = { 0, RadiusOfStartFilling, 0, RadiusOfStartFilling, RadiusOfStartFilling / 2, RadiusOfStartFilling / 2, 0, RadiusOfStartFilling / 2, RadiusOfStartFilling };

            for (int i = 0; i < _height - RadiusOfStartFilling; i++)
                for (int j = 0; j < _width - RadiusOfStartFilling; j++)
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

        /// <summary>
        /// Возвращает сегментированное изображение в формате Bitmap
        /// </summary>
        /// <returns>Сегментированное изображение в формате Bitmap</returns>
        public Bitmap GetSegmentedPicture()
        {
            ReleaseSegmentation();

            Bitmap outerPic = Utils.ByteToBitmapRgb(_masRgb);
            return outerPic;
        }

        /// <summary>
        /// Возвращает сегментированное изображение в виде трехмерного массива
        /// </summary>
        /// <returns>Трехмерный массив, описывающий изображение, третье измерение (0 - R, 1 - G, 2 - B) RGB компоненты цвета</returns>
        public byte[,,] GetSegmentedMass()
        {
            ReleaseSegmentation();

            return _masRgb;
        }

        /// <summary>
        /// Заполняет область фоновым цветом, начиная с переданной точки (поиск в ширину)
        /// </summary>
        /// <param name="ist">i-координата массива точки</param>
        /// <param name="jst">j-координата массива точки</param>
        void FillBackground(int ist, int jst)
        {
            int height = _masRgb.GetUpperBound(0) + 1,
                width = _masRgb.GetUpperBound(1) + 1;

            int[] di = { 0, 0, 1, -1, -1, 1, -1, 1 };
            int[] dj = { 1, -1, 0, 0, -1, 1, 1, -1 };

            List<Point> st = new List<Point> {new Point(ist, jst)};
            _masRgb[ist, jst, 0] = 0;
            _masRgb[ist, jst, 1] = 0;
            _masRgb[ist, jst, 2] = 0;

            int currPos = 0;
            while (st.Count > currPos)
            {
                Point currPoint = st[currPos++];
                for (int k = 0; k < di.Length; k++)
                {
                    int i = currPoint.X + di[k],
                        j = currPoint.Y + dj[k];
                    if (i < 0 || i >= height || j < 0 || j >= width)
                        continue;
                    if (_masRgb[i, j, 0] == 0 && _masRgb[i, j, 1] == 0 && _masRgb[i, j, 2] == 0)
                        continue;

                    if (IsBackground(_masRgb[i, j, 0], _masRgb[i, j, 1], _masRgb[i, j, 2]))
                    {
                        st.Add(new Point(i, j));

                        _masRgb[i, j, 0] = 0;
                        _masRgb[i, j, 1] = 0;
                        _masRgb[i, j, 2] = 0;
                    }
                }
            }

            st.Clear();
        }
    }

    /// <summary>
    /// Класс для нахождения оптимального совмещения тестируемого чипа с образцом годного чипа
    /// </summary>
    public class SuperImposition
    {
        private readonly byte[,,] _originMas;
        private byte[,,] _currMas;

        private readonly int[,] _calcedOriginMas;
        private int[,] _calcedCurrMas;

        private int _top;
        private int _bottom;
        private const int Bandwidth = 20;

        /// <summary>
        /// Конструктор принимает массив пикселей изображения годного чипа
        /// </summary>
        /// <param name="originMas">Массив пикселей изображения годного чипа</param>
        public SuperImposition(byte[, ,] originMas)
        {
            _originMas = originMas;

            _calcedOriginMas = CalcRectanglePixelCount(originMas);
            PrepareOriginMas();
        }

        /// <summary>
        /// Создает новый массив в (i, j) ячейке которого находится сумма пикселей не-подложки в прямоугольнике (0, 0; i, j) 
        /// </summary>
        /// <param name="inputMas"></param>
        /// <returns></returns>
        private int[,] CalcRectanglePixelCount(byte[, ,] inputMas)
        {
            int height = inputMas.GetUpperBound(0) + 1;
            int width = inputMas.GetUpperBound(1) + 1;
            int[,] res = new int[height, width];

            res[0, 0] = inputMas[0, 0, 1] != 0 ? 1 : 0;
            for (int i = 1; i < height; i++)
                res[i, 0] += res[i - 1, 0] + (inputMas[i, 0, 0] != 0 ? 1 : 0);
            for (int j = 1; j < width; j++)
                res[0, j] += res[0, j - 1] + (inputMas[0, j, 0] != 0 ? 1 : 0);
            for (int i = 1; i < height; i++)
                for (int j = 1; j < width; j++)
                    res[i, j] += (inputMas[i, j, 0] != 0 ? 1 : 0) + res[i - 1, j] + res[i, j - 1] - res[i - 1, j - 1];

            return res;
        }

        private void PrepareOriginMas()
        {
            const int halfOfWidth = 10;
            int heightOfGood = _originMas.GetUpperBound(0) + 1;
            int widthOfGood = _originMas.GetUpperBound(1) + 1;
            int x = widthOfGood - 1;

            int y = (heightOfGood - 1) - halfOfWidth;
            // идем снизу вверх
            while (y > heightOfGood / 2)
            {
                int upCount = _calcedOriginMas[y, x] - _calcedOriginMas[y - halfOfWidth, x];
                int downCount = _calcedOriginMas[y + halfOfWidth, x] - _calcedOriginMas[y, x];
                double koeff = (double) (upCount) / (downCount + upCount);
                if (koeff > 0.7 && upCount*10 > widthOfGood*halfOfWidth)
                {
                    _bottom = y + 3;
                    break;
                }
                y--;
            }

            y = halfOfWidth;
            // идем сверху вниз
            while (y < heightOfGood / 2)
            {
                int upCount = _calcedOriginMas[y, x] - _calcedOriginMas[y - halfOfWidth, x];
                int downCount = _calcedOriginMas[y + halfOfWidth, x] - _calcedOriginMas[y, x];
                double koeff = (double) (downCount) / (downCount + upCount);
                if (koeff > 0.7 && downCount*10 > widthOfGood*halfOfWidth)
                {
                    _top = y - 3;
                    break;
                }
                y++;
            }
        }

        private int CheckStripePositions(Point point)
        {
            int wOrigin = _originMas.GetUpperBound(1) + 1;

            int res = 0;
            for (int i = _top; i < _top + Bandwidth; i++)
            {
                for (int j = 0; j < wOrigin; j++)
                {
                    if (_originMas[i, j, 0] != _currMas[i + point.Y, j + point.X, 0])
                        res++;
                }
            }

            for (int i = _bottom - Bandwidth; i < _bottom; i++)
            {
                for (int j = 0; j < wOrigin; j++)
                {
                    if (_originMas[i, j, 0] != _currMas[i + point.Y, j + point.X, 0])
                        res++;
                }
            }

            return res;
        }

        private Point FindBestStripePoint(List<Point> points)
        {
            Point bestPoint = new Point(0, 0);
            int minDiffer = Int32.MaxValue;
            foreach (var point in points)
            {
                int currDiffer = CheckStripePositions(point);
                if (currDiffer < minDiffer)
                {
                    minDiffer = currDiffer;
                    bestPoint = point;
                }
            }

            return bestPoint;
        }

        private List<Point> FindProbablePositions()
        {
            List<Point> probablePositions = new List<Point>();

            int h = _currMas.GetUpperBound(0) + 1;
            int w = _currMas.GetUpperBound(1) + 1;
            int hOrigin = _originMas.GetUpperBound(0) + 1;
            int wOrigin = _originMas.GetUpperBound(1) + 1;
            int countOfPixelsUp = _calcedOriginMas[_top + Bandwidth, wOrigin - 1] - _calcedOriginMas[_top, wOrigin - 1];
            int countOfPixelsDown = _calcedOriginMas[_bottom, wOrigin - 1] - _calcedOriginMas[ _bottom - Bandwidth, wOrigin - 1];
            int limitI = h - hOrigin + 1;
            int startJ = wOrigin;

            for (int i = 0; i < limitI; i++)
            {
                for (int j = startJ; j < w; j++)
                {
                    int currCountOfPixelsUp = _calcedCurrMas[_top + i + Bandwidth, j] - (_calcedCurrMas[_top + i, j] + _calcedCurrMas[_top + i + Bandwidth, j - wOrigin]) 
                        + _calcedCurrMas[_top + i, j - wOrigin];
                    int currCountOfPixelsDown = _calcedCurrMas[_bottom + i, j] - (_calcedCurrMas[_bottom + i - Bandwidth, j] + _calcedCurrMas[_bottom + i, j - wOrigin])
                        + _calcedCurrMas[_bottom + i - Bandwidth, j - wOrigin];

                    double upDelta = (double)(Math.Abs(countOfPixelsUp - currCountOfPixelsUp)) / (countOfPixelsUp + currCountOfPixelsUp);
                    double downDelta = (double)(Math.Abs(countOfPixelsDown - currCountOfPixelsDown)) / (countOfPixelsDown + currCountOfPixelsDown);

                    if (upDelta < 0.1 && downDelta < 0.1)
                        probablePositions.Add(new Point(j - wOrigin, i));
                }
            }

            return probablePositions;
        }

        /// <summary>
        /// Находит более точную позицию совмещения с помощью небольших отклонений и анализа совмещения
        /// </summary>
        /// <param name="start">Начальная позиция для поиска</param>
        /// <returns></returns>
        private Point FindPreciseImposition(Point start)
        {
            Point offset = new Point(start.X, start.Y);

            // текущий коэффициент разности изображений
            int min = CheckSuperpositionBruteforce(_currMas, offset);

            // размеры массивов
            int h = _currMas.GetUpperBound(0) + 1;
            int w = _currMas.GetUpperBound(1) + 1;
            int hOrigin = _originMas.GetUpperBound(0) + 1;
            int wOrigin = _originMas.GetUpperBound(1) + 1;

            // идем вверх
            while (offset.Y > 0)
            {
                Point newOffset = new Point(offset.X, offset.Y - 1);
                int curr = CheckSuperpositionBruteforce(_currMas, newOffset);

                if (curr < min)
                {
                    min = curr;
                    offset = newOffset;
                }
                else
                {
                    break;
                }
            }

            // идем вниз
            while (offset.Y < h - hOrigin)
            {
                Point newOffset = new Point(offset.X, offset.Y + 1);
                int curr = CheckSuperpositionBruteforce(_currMas, newOffset);

                if (curr < min)
                {
                    min = curr;
                    offset = newOffset;
                }
                else
                {
                    break;
                }
            }

            // идем влево
            while (offset.X > 0)
            {
                Point newOffset = new Point(offset.X - 1, offset.Y);
                int curr = CheckSuperpositionBruteforce(_currMas, newOffset);

                if (curr < min)
                {
                    min = curr;
                    offset = newOffset;
                }
                else
                {
                    break;
                }
            }

            // идем вправо
            while (offset.X < w - wOrigin)
            {
                Point newOffset = new Point(offset.X + 1, offset.Y);
                int curr = CheckSuperpositionBruteforce(_currMas, newOffset);

                if (curr < min)
                {
                    min = curr;
                    offset = newOffset;
                }
                else
                {
                    break;
                }
            } 

            return offset;
        }

        /// <summary>
        /// Находит лучшее совмещения данного изображения
        /// </summary>
        /// <param name="currMas">Массив пикселей изображения тестируемого чипа</param>
        /// <returns></returns>
        public Point FindBestImposition(byte[, ,] currMas)
        {
            _currMas = currMas;
            _calcedCurrMas = CalcRectanglePixelCount(currMas);

            List<Point> probablePositions = FindProbablePositions();

            Point res = FindBestStripePoint(probablePositions);

           // res = FindPreciseImposition(res);

            return res;
        }

        /// <summary>
        /// Находит лучшее совмещения данного изображения
        /// </summary>
        /// <param name="nextPicMass">Массив пикселей изображения тестируемого чипа</param>
        /// <returns></returns>
        public Point FindBestImposition2(byte[, ,] nextPicMass)
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

        /// <summary>
        /// Проверка заданного смещения (неоптимально в лоб)
        /// </summary>
        /// <param name="nextPicMass">Массив пикселей изображения тестируемого чипа</param>
        /// <param name="offset">Координаты смещения</param>
        /// <returns>Количество несовпадающих пикселей</returns>
        private int CheckSuperpositionBruteforce(byte[, ,] nextPicMass, Point offset)
        {
            int heightOfGood = _originMas.GetUpperBound(0) + 1;
            int widthOfGood = _originMas.GetUpperBound(1) + 1;

            // проверка на выход за границы массива
            int currHeight = nextPicMass.GetUpperBound(0) + 1,
                currWidth = nextPicMass.GetUpperBound(1) + 1;
            if (heightOfGood + offset.Y > currHeight || offset.Y < 0 || widthOfGood + offset.X > currWidth || offset.X < 0)
                return Int32.MaxValue;

            int res = 0;
            for (int i = 0; i < heightOfGood / 3; i++)
                for (int j = 0; j < widthOfGood / 3; j++)
                    if (_originMas[i, j, 0] != nextPicMass[i + offset.Y, j + offset.X, 0])
                        res++;

            return res;
        }
    }

    /// <summary>
    /// Класс для автоматизированного визуального контроля
    /// </summary>
    public class VisualInspect
    {
        /// <summary>
        /// Сегментированный массив образца годного чипа
        /// </summary>
        private readonly byte[,,] _segmentedMassGoodChip;
        /// <summary>
        /// Ширина изображения годного чипа
        /// </summary>
        private readonly int _widthOfGood;
        /// <summary>
        /// Высота изображения годного чипв
        /// </summary>
        private readonly int _heightOfGood;
        /// <summary>
        /// Текущий тестируемый чип
        /// </summary>
        private Bitmap _currChipForTest;
        /// <summary>
        /// Текущий вердикт по тестируемому чипу
        /// </summary>
        public string CurrVerdict { get; private set; }
        /// <summary>
        /// Текущая оценка чипа (сумма отличающихся пикселей)
        /// </summary>
        public int CurrMark { get; private set; }
        /// <summary>
        /// Объект для нахождения лучшего совмещения
        /// </summary>
        private readonly SuperImposition _superImposition;

        /// <summary>
        /// Конструктор принимает путь к изображению образца годного чипа
        /// </summary>
        /// <param name="pathToGoodChipFile">Путь к изображению образца годного чипа</param>
        public VisualInspect(string pathToGoodChipFile)
        {
            // сохраняем оригинальное изображение
            Bitmap originGoodChip = new Bitmap(pathToGoodChipFile);

            // сегментируем оригинал
            Segmentation segm = new Segmentation(originGoodChip, Color.Blue, 100); // TO DO: исправить
            _segmentedMassGoodChip = segm.GetSegmentedMass();

            // фиксируем размеры массива
            _heightOfGood = _segmentedMassGoodChip.GetUpperBound(0) + 1;
            _widthOfGood = _segmentedMassGoodChip.GetUpperBound(1) + 1;

            // создаем объект для нахождения лучшего совмещения
            _superImposition = new SuperImposition(_segmentedMassGoodChip);
        }

        /// <summary>
        /// Проверка очередного изображения чипа
        /// </summary>
        /// <param name="pathToChipFile">Путь к файлу с изображением чипа</param>
        /// <returns>Возвращает изображение в формате Bitmap с пометкой подозрительных областей</returns>
        public Bitmap CheckNextChip(string pathToChipFile)
        {
            // сегментируем очередной чип, который нужно проверить
            Bitmap bmp = new Bitmap(pathToChipFile);
            Segmentation segm = new Segmentation(bmp, Color.Blue, 100); // TO DO: исправить
            byte[,,] segmentedMass = segm.GetSegmentedMass();

            // сохраняем изображение очередного чипа
            _currChipForTest = bmp;

            // находим наилучшее совмещение
            Point offset = _superImposition.FindBestImposition2(segmentedMass);

            // сравниваем хороший чип и очередной тестируемый
            Bitmap picWithSprites = CheckChipForDamage(segmentedMass, offset);

            return picWithSprites;
        }

        /// <summary>
        /// Проверка равенства цветов с учетом относительного сдвига
        /// </summary>
        /// <param name="mas1">Массив первого изображения</param>
        /// <param name="mas2">Массив второго изображения</param>
        /// <param name="i">i-координата</param>
        /// <param name="j">j-координата</param>
        /// <param name="offset">Относительный сдвиг</param>
        /// <returns>true-равны, false-не равны</returns>
        private bool ColorsEqual(byte[,,] mas1, byte[,,] mas2, int i, int j, Point offset)
        {
            return mas1[i, j, 0] == mas2[i + offset.Y, j + offset.X, 0];
        }

        /// <summary>
        /// Проверка острова связанных отличающихся пикселей
        /// </summary>
        /// <param name="si"></param>
        /// <param name="sj"></param>
        /// <param name="offset"></param>
        /// <param name="nextPicMass"></param>
        /// <param name="nextChipWithSprites"></param>
        /// <param name="isAnalyzed"></param>
        /// <returns></returns>
        private int AnalyzeIslandOfPixels(int si, int sj, Point offset, byte[,,] nextPicMass, ref byte[,,] nextChipWithSprites, ref bool[,] isAnalyzed)
        {
            int[] di = {-1, 1, 0, 0};
            int[] dj = {0, 0, 1, -1};

            // проходим по всем пикселям этого острова и кладем их в лист
            List<Point> queue = new List<Point> {new Point(sj, si)};
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

        /// <summary>
        /// Анализ изображения тестируемого чипа на предмет брака
        /// </summary>
        /// <param name="nextPicMass">Изображение тестируемого чипа в виде массива пикселей</param>
        /// <param name="offset">Координаты относительного сдвига</param>
        /// <returns>Изображение с пометкой подозрительных областей</returns>
        private Bitmap CheckChipForDamage(byte[,,] nextPicMass, Point offset)
        {
            bool[,] isAnalyzed = new bool[_heightOfGood, _widthOfGood];

            byte[,,] nextChipWithSprites = Utils.BitmapToByteRgb(_currChipForTest);
            int diff = 0;
            for (int i = 0; i < _heightOfGood; i++)
                for (int j = 0; j < _widthOfGood; j++)
                {
                    if (!isAnalyzed[i, j] && (!ColorsEqual(_segmentedMassGoodChip, nextPicMass, i, j, offset)))
                    {
                        diff += AnalyzeIslandOfPixels(i, j, offset, nextPicMass, ref nextChipWithSprites, ref isAnalyzed);
                    }
                }

            CurrMark = diff;
            return Utils.ByteToBitmapRgb(nextChipWithSprites);
        }
    }

    /// <summary>
    /// Вспомогательные методы
    /// </summary>
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
