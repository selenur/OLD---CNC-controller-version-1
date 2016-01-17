namespace CNC_Assist
{
    /// <summary>
    /// Класс содержащий информацию о сканируемой поверхности
    /// </summary>
    public static class ScanSurface
    {
        #region Инициализация переменных

        //Для определения того, инициализирован-ли
        /// <summary>
        /// Переменная для определения того что матрица ещё не инициализированна
        /// </summary>
        public static bool NotInit = true;

        /// <summary>
        /// Базовая точка относительно которой ,будем собирать отклонения
        /// </summary>
        private static SurfacePoint _primaryPosition;

        /// <summary>
        /// Количество точек сканирования в матрице по оси X
        /// </summary>
        private static int _countPointX;

        /// <summary>
        /// Количество точек сканирования в матрице по оси Y
        /// </summary>
        private static int _countPointY;

        /// <summary>
        /// Шаг между точками сканирования по оси X
        /// </summary>
        private static float _stepX;

        /// <summary>
        /// Шаг между точками сканирования по оси Y
        /// </summary>
        private static float _stepY;

        /// <summary>
        /// Скорость движения до точки сканирования
        /// </summary>
        public static int SpeedMove;

        /// <summary>
        /// Скорость сканирования
        /// </summary>
        public static int SpeedScan;

        /// <summary>
        /// Матрица содержащая данные сканирования
        /// </summary>
        public static SurfacePoint[,] Matrix;

        #endregion

        #region Свойства

        /// <summary>
        /// Базовая точка относительно которой ,будем собирать отклонения
        /// </summary>
        public static SurfacePoint PrimaryPosition
        {
            get { return _primaryPosition; }
            //set { _primaryPosition = value; }
        }

        /// <summary>
        /// Количество точек сканирования в матрице по оси X
        /// </summary>
        public static int CountPointX
        {
            get
            {
                return _countPointX;
            }
            //set
            //{
            //    _countPointX = value;
            //    // нужно пересчитать матрицу
            //}
        }

        /// <summary>
        /// Количество точек сканирования в матрице по оси Y
        /// </summary>
        public static int CountPointY
        {
            get
            {
                return _countPointY;
            }
            //set
            //{
            //    _countPointY = value;
            //    // нужно пересчитать матрицу
            //}
        }

        /// <summary>
        /// Шаг между точками сканирования по оси X
        /// </summary>
        public static float StepX
        {
            get
            {
                return _stepX;
            }
            //set
            //{
            //    _stepX = value;
            //    // нужно пересчитать матрицу
            //}
        }

        /// <summary>
        /// Шаг между точками сканирования по оси Y
        /// </summary>
        public static float StepY
        {
            get
            {
                return _stepY;
            }
            //set
            //{
            //    _stepY = value;
            //    // нужно пересчитать матрицу
            //}
        }

        #endregion

        /// <summary>
        /// Инициализация матрицы
        /// </summary>
        /// <param name="surfacePoint">Ключевая(начальная) точка массива</param>
        /// <param name="countpointX">Количество точек/рядов сканирования по оси X</param>
        /// <param name="countpointY">Количество точек/строк сканирования по оси Y</param>
        /// <param name="stepx">Интервал между точками</param>
        /// <param name="stepy">Интервал между точками</param>
        public static void Init(SurfacePoint surfacePoint, int countpointX, int countpointY, float stepx, float stepy)
        {
            
            _primaryPosition = surfacePoint == null ? new SurfacePoint() : new SurfacePoint(surfacePoint);

            _countPointX = countpointX;
            _countPointY = countpointY;
            _stepX = stepx;
            _stepY = stepy;

            SpeedMove = 200;
            SpeedScan = 50;

            Matrix = new SurfacePoint[_countPointX, _countPointY];

            // заполним пустыми данными
            for (int y = 0; y < _countPointY; y++)
            {
                for (int x = 0; x < _countPointX; x++)
                {
                    SurfacePoint tmPoint = new SurfacePoint();

                    if (surfacePoint != null)
                    {
                        tmPoint.PosX = (x * stepx) + surfacePoint.PosX;
                        tmPoint.PosY = (y * stepy) + surfacePoint.PosY;
                        tmPoint.PosZ = surfacePoint.PosZ;
                    }
                    tmPoint.PosZ = 0;

                    Matrix[x, y] = new SurfacePoint(tmPoint);
                }
            }

            NotInit = false;
        }

        /// <summary>
        /// Вычисление высоты Z по переданным 2-м координатам
        /// </summary>
        public static float GetPosZ(float _x, float _y)
        {
            //точка которую нужно отобразить
            SurfacePoint pResult = new SurfacePoint(_x, _y, 0);



            //поиск ближайшей точки из матрицы
            int indexXmin = 0;
            int indexYmin = 0;
            for (int x = 0; x < Matrix.GetLength(0) - 1; x++)
            {
                for (int y = 0; y < Matrix.GetLength(1) - 1; y++)
                {
                    if (_x > Matrix[x, 0].PosX && _x < Matrix[x + 1, 0].PosX && Matrix[0, y].PosY < _y && Matrix[0, y + 1].PosY > _y)
                    {
                        indexXmin = x;
                        indexYmin = y;
                    }
                }
            }


            SurfacePoint p1 = new SurfacePoint(Matrix[indexXmin, indexYmin].PosX, Matrix[indexXmin, indexYmin].PosY, Matrix[indexXmin, indexYmin].PosZ);
            SurfacePoint p3 = new SurfacePoint(Matrix[indexXmin, indexYmin + 1].PosX, Matrix[indexXmin, indexYmin + 1].PosY, Matrix[indexXmin, indexYmin + 1].PosZ);
            SurfacePoint p2 = new SurfacePoint(Matrix[indexXmin + 1, indexYmin].PosX, Matrix[indexXmin + 1, indexYmin].PosY, Matrix[indexXmin + 1, indexYmin].PosZ);
            SurfacePoint p4 = new SurfacePoint(Matrix[indexXmin + 1, indexYmin + 1].PosX, Matrix[indexXmin + 1, indexYmin + 1].PosY, Matrix[indexXmin + 1, indexYmin + 1].PosZ);

            SurfacePoint p12 = CalcPX(p1, p2, pResult);
            SurfacePoint p34 = CalcPX(p3, p4, pResult);
            SurfacePoint p1234 = CalcPY(p12, p34, pResult);


            return p1234.PosZ;
            //return 0;
        }

        /*
         *    Корректировка высоты по оси Z, у точки №5, зная высоту по Z у точек 1,2,3,4 
         * 
         *  /\ ось Y
         *  |
         *  |    (точка №1) -------------*--------------- (точка №2)
         *  |                            |
         *  |                            |
         *  |                            |
         *  |                       (точка №5)
         *  |                            |
         *  |                            |
         *  |    (точка №3) -------------*--------------- (точка №4)
         *  |
         *  |
         *  *----------------------------------------------------------------> ось X 
         *  Корректировка выполняется следующим образом:
         *  1) зная координату X у точки 5, и координаты точек 1 и 2, вычисляем высоту Z в точке которая находится на линии точек 1,2 и перпендикулярно 5-й точке (получает точку №12)
         *  2) Тоже самое вычисляется для точки на линии точек 3,4 (получает точку №34)
         *  3) Зная координаты точек №12, №34 и значение по оси Y у точки 5, вычисляем высоту по оси Z 
         */

        /// <summary>
        /// Функция корректирует высоту по оси Z
        /// </summary>
        /// <param name="p1">первая точка первой линии X</param>
        /// <param name="p2">вторая точка первой линии X</param>
        /// <param name="p3">первая точка второй линии X</param>
        /// <param name="p4">вторая точка второй линии X</param>
        /// <param name="p5">точка у которой нужно скорректировать высоту</param>
        /// <returns></returns>
        private static SurfacePoint GetZ(SurfacePoint p1, SurfacePoint p2, SurfacePoint p3, SurfacePoint p4, SurfacePoint p5)
        {
            SurfacePoint p12 = CalcPX(p1, p2, p5);
            SurfacePoint p34 = CalcPX(p3, p4, p5);

            SurfacePoint p1234 = CalcPY(p12, p34, p5);

            return p1234;
        }

        //нахождение высоты Z точки p0, лежащей на прямой которая паралельна оси X
        private static SurfacePoint CalcPX(SurfacePoint p1, SurfacePoint p2, SurfacePoint p0)
        {
            SurfacePoint ReturnPoint = new SurfacePoint(p0.PosX, p0.PosY, p0.PosZ);

            ReturnPoint.PosZ = p1.PosZ + (((p1.PosZ - p2.PosZ) / (p1.PosX - p2.PosX)) * (p0.PosX - p1.PosX));

            //TODO: учесть на будущее что точка 1 и 2 могут лежать не на одной паралльной линии оси Х
            ReturnPoint.PosY = p1.PosY;

            return ReturnPoint;
        }

        //нахождение высоты Z точки p0, лежащей на прямой между точками p3 p4  (прямая паралельна оси Y)
        private static SurfacePoint CalcPY(SurfacePoint p1, SurfacePoint p2, SurfacePoint p0)
        {
            SurfacePoint ReturnPoint = new SurfacePoint(p0.PosX, p0.PosY, p0.PosZ);

            ReturnPoint.PosZ = p1.PosZ + (((p1.PosZ - p2.PosZ) / (p1.PosY - p2.PosY)) * (p0.PosY - p1.PosY));

            return ReturnPoint;
        }

    }


    /// <summary>
    /// Класс содержит информацию о точке сканирования поверхности
    /// </summary>
    public class SurfacePoint
    {
        public float PosX = 0; 
        public float PosY = 0;
        public float PosZ = 0;
        //public float deltaZ = 0;

        public SurfacePoint()
        {
            PosX = 0;
            PosY = 0;
            PosZ = 0;
            //deltaZ = 0;
        }

        public SurfacePoint(float _PosX, float _PosY, float _PosZ)
        {
            PosX = _PosX;
            PosY = _PosY;
            PosZ = _PosZ;
            //deltaZ = _deltaZ;
        }

        /// <summary>
        /// Клонирование данных из существующей точки
        /// </summary>
        /// <param name="_point"></param>
        public SurfacePoint(SurfacePoint _point)
        {
            PosX = _point.PosX;
            PosY = _point.PosY;
            PosZ = _point.PosZ;
            //deltaZ = _point.deltaZ;
        }
    }
}
