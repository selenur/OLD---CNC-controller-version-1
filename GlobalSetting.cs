using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace CNC_Assist
{

    /// <summary>
    /// Все настройки программы
    /// </summary>
    public static class GlobalSetting
    {
        /// <summary>
        /// Файл настроек программы
        /// </summary>
        private static readonly string Filesetting1 = string.Format("{0}\\setup1.ini", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        /// <summary>
        /// Файл настроек контроллера
        /// </summary>
        private static readonly string Filesetting2 = string.Format("{0}\\setup2.ini", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        /// <summary>
        /// Файл настроек 3D вуализации
        /// </summary>
        private static readonly string Filesetting3 = string.Format("{0}\\setup3.ini", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        /// <summary>
        /// Файл настроек отображения панелей
        /// </summary>
        private static readonly string Filesetting4 = string.Format("{0}\\setup4.ini", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        // создание классов, с настройками по умолчанию



        /// <summary>
        /// Базовые настройки
        /// </summary>
        public static SettingAPP AppSetting = new SettingAPP();
        /// <summary>
        /// Настройки текущего контроллера
        /// </summary>
        public static SettingController ControllerSetting = new SettingController();
        /// <summary>
        /// Настройки 3D вуализации
        /// </summary>
        public static SettingRender RenderSetting = new SettingRender();
        /// <summary>
        /// Настройки отображения панелей
        /// </summary>
        public static SettingPanels PanelSetting = new SettingPanels();

        /// <summary>
        /// Сохранение настроек в файл
        /// </summary>
        public static void SaveToFile()
        {
            BinaryFormatter binFormat1 = new BinaryFormatter();
            using (Stream fStream1 = new FileStream(Filesetting1, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat1.Serialize(fStream1, AppSetting);
            }


            BinaryFormatter binFormat2 = new BinaryFormatter();
            using (Stream fStream2 = new FileStream(Filesetting2, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat2.Serialize(fStream2, ControllerSetting);
            }


            BinaryFormatter binFormat3 = new BinaryFormatter();
            using (Stream fStream3 = new FileStream(Filesetting3, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat3.Serialize(fStream3, RenderSetting);
            }


            BinaryFormatter binFormat4 = new BinaryFormatter();
            using (Stream fStream4 = new FileStream(Filesetting4, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat4.Serialize(fStream4, PanelSetting);
            }
        }

        /// <summary>
        /// Загрузка настроек из файла
        /// </summary>
        public static void LoadSetting()
        {
            try
            {
                BinaryFormatter binFormat1 = new BinaryFormatter();

                using (Stream fStream1 = File.OpenRead(Filesetting1))
                {
                    AppSetting = (SettingAPP)binFormat1.Deserialize(fStream1);
                }

                using (Stream fStream2 = File.OpenRead(Filesetting2))
                {
                    ControllerSetting = (SettingController)binFormat1.Deserialize(fStream2);
                }

                using (Stream fStream3 = File.OpenRead(Filesetting3))
                {
                    RenderSetting = (SettingRender)binFormat1.Deserialize(fStream3);
                }

                using (Stream fStream4 = File.OpenRead(Filesetting4))
                {
                    PanelSetting = (SettingPanels)binFormat1.Deserialize(fStream4);
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }

    }

    /// <summary>
    /// Базовые настройки
    /// </summary>
    [Serializable]
    public class SettingAPP
    {
        /// <summary>
        /// Модель контроллера
        /// </summary>
        private ControllerModel _controller = ControllerModel.PlanetCNC_MK1;
        /// <summary>
        /// Модель контроллера
        /// </summary>
        [DisplayName(@"Модель контроллера")]
        [Description("В данном пункте выбирается аппаратный контроллер, с которым будет работать программа")]
        [Category("1. Настройки программы")]
        [TypeConverter(typeof(EnumTypeConverter))]
        public ControllerModel Controller
        {
            get { return _controller; }
            set { _controller = value; }

        }

        /// <summary>
        /// Используемый язык
        /// </summary>
        private Languages _language = Languages.Russian;
        /// <summary>
        /// Используемый язык
        /// </summary>
        [DisplayName(@"Язык программы")]
        [Category("1. Настройки программы")]
        //[ReadOnly(true)]
        [TypeConverter(typeof(EnumTypeConverter))]
        public Languages Language
        {
            get { return _language; }
            set { _language = value; }

        }

        /// <summary>
        /// Автоподключение к контроллеру
        /// </summary>
        private bool _autoconnect;
        /// <summary>
        /// Автоподключение к контроллеру
        /// </summary>
        [DisplayName(@"Авто-подключение")]
        [Description("Постоянное удержание связи с контроллером, в случае обрыва связи, будет выполнятся автоматическое подключение")]
        [Category("1. Настройки программы")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool Autoconnect
        {
            get { return _autoconnect; }
            set { _autoconnect = value; }           

        }
    }

    /// <summary>
    /// Настройки текущего контроллера
    /// </summary>
    [Serializable]
    public class SettingController
    {

        /// <summary>
        /// Минимальный объем буфера контроллера, при котором посылаем данные
        /// </summary>
        private int _minBuffSize = 3;
        /// <summary>
        /// Минимальный объем буфера контроллера, при котором посылаем данные
        /// </summary>
        [DisplayName(@"Количество посылаемых данных")]
        [Description("Настройка позволяет указать сколько посылать комманд в контроллер, от текущего кадра наперед.")]
        [PropertyOrder(5)]
        [Category("2. Настройки контроллера")]
        public int MinBuffSize
        {
            get { return _minBuffSize; }
            set { _minBuffSize = value; }

        }

        /// <summary>
        /// Настройки оси
        /// </summary>
        private AxleSetting _axleX = new AxleSetting();
        /// <summary>
        /// Настройки оси
        /// </summary>
        [DisplayName(@"Ось X")]
        [Description("Настройки оси X")]
        [PropertyOrder(10)]
        [Category("2.1 Параметры осей")]
        public AxleSetting AxleX
        {
            get { return _axleX; }
            set { _axleX = value; }
        }


        /// <summary>
        /// Настройки оси
        /// </summary>
        private AxleSetting _axleY = new AxleSetting();
        /// <summary>
        /// Настройки оси
        /// </summary>
        [DisplayName(@"Ось Y")]
        [Description("Настройки оси Y")]
        [PropertyOrder(20)]
        [Category("2.1 Параметры осей")]
        public AxleSetting AxleY
        {
            get { return _axleY; }
            set { _axleY = value; }
        }


        /// <summary>
        /// Настройки оси
        /// </summary>
        private AxleSetting _axleZ = new AxleSetting();
        /// <summary>
        /// Настройки оси
        /// </summary>
        [DisplayName(@"Ось Z")]
        [Description("Настройки оси Z")]
        [PropertyOrder(30)]
        [Category("2.1 Параметры осей")]
        public AxleSetting AxleZ
        {
            get { return _axleZ; }
            set { _axleZ = value; }
        }


        /// <summary>
        /// Настройки оси
        /// </summary>
        private AxleSetting _axleA = new AxleSetting(false);
        /// <summary>
        /// Настройки оси
        /// </summary>
        [DisplayName(@"Ось A")]
        [Description("Настройки оси A")]
        [PropertyOrder(40)]
        [Category("2.1 Параметры осей")]
        public AxleSetting AxleA
        {
            get { return _axleA; }
            set { _axleA = value; }
        }





        //X+
        /// <summary>
        /// Использование концевика
        /// </summary>
        private bool _useLimitSwichXp = true;
        /// <summary>
        /// Использование концевика
        /// </summary>
        [DisplayName(@"X+")]
        [Description("X+")]
        [PropertyOrder(1)]
        [Category("2.2 Использование концевиков")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool UseLimitSwichXp
        {
            get { return _useLimitSwichXp; }
            set { _useLimitSwichXp = value; }
        }

        //X-
        /// <summary>
        /// Использование концевика
        /// </summary>
        private bool _useLimitSwichXm = true;
        /// <summary>
        /// Использование концевика
        /// </summary>
        [DisplayName(@"X-")]
        [Description("X-")]
        [PropertyOrder(1)]
        [Category("2.2 Использование концевиков")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool UseLimitSwichXm
        {
            get { return _useLimitSwichXm; }
            set { _useLimitSwichXm = value; }
        }


        //Y+
        /// <summary>
        /// Использование концевика
        /// </summary>
        private bool _useLimitSwichYp = true;
        /// <summary>
        /// Использование концевика
        /// </summary>
        [DisplayName(@"Y+")]
        [Description("Y+")]
        [PropertyOrder(1)]
        [Category("2.2 Использование концевиков")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool UseLimitSwichYp
        {
            get { return _useLimitSwichYp; }
            set { _useLimitSwichYp = value; }
        }

        //Y-
        /// <summary>
        /// Использование концевика
        /// </summary>
        private bool _useLimitSwichYm = true;
        /// <summary>
        /// Использование концевика
        /// </summary>
        [DisplayName(@"Y-")]
        [Description("Y-")]
        [PropertyOrder(1)]
        [Category("2.2 Использование концевиков")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool UseLimitSwichYm
        {
            get { return _useLimitSwichYm; }
            set { _useLimitSwichYm = value; }
        }


        //X+
        /// <summary>
        /// Использование концевика
        /// </summary>
        private bool _useLimitSwichZp = true;
        /// <summary>
        /// Использование концевика
        /// </summary>
        [DisplayName(@"Z+")]
        [Description("Z+")]
        [PropertyOrder(1)]
        [Category("2.2 Использование концевиков")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool UseLimitSwichZp
        {
            get { return _useLimitSwichZp; }
            set { _useLimitSwichZp = value; }
        }

        //X-
        /// <summary>
        /// Использование концевика
        /// </summary>
        private bool _useLimitSwichZm = true;
        /// <summary>
        /// Использование концевика
        /// </summary>
        [DisplayName(@"Z-")]
        [Description("Z-")]
        [PropertyOrder(1)]
        [Category("2.2 Использование концевиков")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool UseLimitSwichZm
        {
            get { return _useLimitSwichZm; }
            set { _useLimitSwichZm = value; }
        }




        /// <summary>
        /// Доступная рабочая область
        /// </summary>
        private float _workSizeXp;
        /// <summary>
        /// Доступная рабочая область
        /// </summary>
        [DisplayName(@"Граница X+")]
        [Description("Граница рабочей области")]
        [PropertyOrder(5)]
        [Category("2.3 Рабочая область")]
        public float WorkSizeXp
        {
            get { return _workSizeXp; }
            set { _workSizeXp = value; }

        }

        /// <summary>
        /// Доступная рабочая область
        /// </summary>
        private float _workSizeXm;
        /// <summary>
        /// Доступная рабочая область
        /// </summary>
        [DisplayName(@"Граница X-")]
        [Description("Граница рабочей области")]
        [PropertyOrder(5)]
        [Category("2.3 Рабочая область")]
        public float WorkSizeXm
        {
            get { return _workSizeXm; }
            set { _workSizeXm = value; }

        }

        /// <summary>
        /// Доступная рабочая область
        /// </summary>
        private float _workSizeYp;
        /// <summary>
        /// Доступная рабочая область
        /// </summary>
        [DisplayName(@"Граница Y+")]
        [Description("Граница рабочей области")]
        [PropertyOrder(5)]
        [Category("2.3 Рабочая область")]
        public float WorkSizeYp
        {
            get { return _workSizeYp; }
            set { _workSizeYp = value; }

        }

        /// <summary>
        /// Доступная рабочая область
        /// </summary>
        private float _workSizeYm;
        /// <summary>
        /// Доступная рабочая область
        /// </summary>
        [DisplayName(@"Граница Y-")]
        [Description("Граница рабочей области")]
        [PropertyOrder(5)]
        [Category("2.3 Рабочая область")]
        public float WorkSizeYm
        {
            get { return _workSizeYm; }
            set { _workSizeYm = value; }

        }



    }

    /// <summary>
    /// Настройки 3D вуализации
    /// </summary>
    [Serializable]
    public class SettingRender
    {

        /// <summary>
        /// Показывать оси координат
        /// </summary>
        private bool _showAxes = true;
        /// <summary>
        /// Показывать оси координат
        /// </summary>
        [DisplayName(@"Отображать оси")]
        [Description("Показывать оси X,Y,Z")]
        [PropertyOrder(1)]
        [Category("3.1 Настройки 3D")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowAxes
        {
            get { return _showAxes; }
            set { _showAxes = value; }
        }

        /// <summary>
        /// Показывать инструмент
        /// </summary>
        private bool _showCursor = true;
        /// <summary>
        /// Показывать инструмент
        /// </summary>
        [DisplayName(@"Отображать курсор/инструмент")]
        [Description("Показывать курсор/инструмент")]
        [PropertyOrder(2)]
        [Category("3.1 Настройки 3D")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowCursor
        {
            get { return _showCursor; }
            set { _showCursor = value; }
        }

        /// <summary>
        /// Показывать сетку
        /// </summary>
        private bool _showGrid = true;
        /// <summary>
        /// Показывать сетку
        /// </summary>
        [DisplayName(@"Отображать сетку")]
        [Description("Показывать сетку")]
        [PropertyOrder(3)]
        [Category("3.2 Настройки 3D - Сетка")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowGrid
        {
            get { return _showGrid; }
            set { _showGrid = value; }
        }

        /// <summary>
        /// Размер ячейки в сетке
        /// </summary>
        private int _gridSize = 10;
        /// <summary>
        /// Размер ячейки в сетке
        /// </summary>
        [DisplayName(@"Размер ячейки")]
        [Description(" ")]
        [PropertyOrder(4)]
        [Category("3.2 Настройки 3D - Сетка")]
        public int GridSize
        {
            get { return _gridSize; }
            set { _gridSize = value; }

        }

        /// <summary>
        /// Размер всей сетки
        /// </summary>
        private int _gridSizeX = 100;
        /// <summary>
        /// Размер всей сетки
        /// </summary>
        [DisplayName(@"Размер сетки по X")]
        [Description(" ")]
        [PropertyOrder(4)]
        [Category("3.2 Настройки 3D - Сетка")]
        public int GridSizeX
        {
            get { return _gridSizeX; }
            set { _gridSizeX = value; }

        }

        /// <summary>
        /// Размер всей сетки
        /// </summary>
        private int _gridSizeY = 100;
        /// <summary>
        /// Размер всей сетки
        /// </summary>
        [DisplayName(@"Размер сетки по Y")]
        [Description(" ")]
        [PropertyOrder(4)]
        [Category("3.2 Настройки 3D - Сетка")]
        public int GridSizeY
        {
            get { return _gridSizeY; }
            set { _gridSizeY = value; }

        }


        /// <summary>
        /// Начало сетки
        /// </summary>
        private int _gridStartX;
        /// <summary>
        /// Начало сетки
        /// </summary>
        [DisplayName(@"Начальное расположение сетки по X")]
        [Description(" ")]
        [PropertyOrder(4)]
        [Category("3.2 Настройки 3D - Сетка")]
        public int GridStartX
        {
            get { return _gridStartX; }
            set { _gridStartX = value; }

        }

        /// <summary>
        /// Начало сетки
        /// </summary>
        private int _gridStartY = 100;
        /// <summary>
        /// Начало сетки
        /// </summary>
        [DisplayName(@"Начальное расположение сетки по Y")]
        [Description(" ")]
        [PropertyOrder(4)]
        [Category("3.2 Настройки 3D - Сетка")]
        public int GridStartY
        {
            get { return _gridStartY; }
            set { _gridStartY = value; }

        }





        /// <summary>
        /// Показывать рабочую область
        /// </summary>
        private bool _showWorkArea = true;
        /// <summary>
        /// Показывать рабочую область
        /// </summary>
        [DisplayName(@"Отображать рабочую область")]
        [Description("Показывать область в пределах которой станок сможет работать")]
        [PropertyOrder(5)]
        [Category("3.1 Настройки 3D")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowWorkArea
        {
            get { return _showWorkArea; }
            set { _showWorkArea = value; }
        }



        /// <summary>
        /// Показывать матрицу сканирования
        /// </summary>
        private bool _showScanedGrid = true;
        /// <summary>
        /// Показывать матрицу сканирования
        /// </summary>
        [DisplayName(@"Отображать сетку сканирования")]
        [Description("Показывать сетку сканирования")]
        [PropertyOrder(5)]
        [Category("3.1 Настройки 3D")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowScanedGrid
        {
            get { return _showScanedGrid; }
            set { _showScanedGrid = value; }
        }

        /// <summary>
        /// Параметры отображения g-кода
        /// </summary>
        private Show3DGkode _gkodeshow = Show3DGkode.All;
        /// <summary>
        /// Параметры отображения g-кода
        /// </summary>
        [DisplayName(@"Вариант отображения G-кода")]
        [Category("3.1 Настройки 3D")]
        //[ReadOnly(true)]
        [TypeConverter(typeof(EnumTypeConverter))]
        public Show3DGkode Gkodeshow
        {
            get { return _gkodeshow; }
            set { _gkodeshow = value; }
        }

        
    }

    /// <summary>
    /// Настройки отображения панелей
    /// </summary>
    [Serializable]
    public class SettingPanels
    {

        private bool _showGuiPanelInfo;
        [DisplayName(@"Скорость движения")]
        [Description("Модуль отображает скорость движения")]
        [Category("4. Настройки отображения модулей")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowGuiPanelInfo
        {
            get { return _showGuiPanelInfo; }
            set { _showGuiPanelInfo = value; }

        }

        private bool _showGuiPanelLimits;
        [DisplayName(@"Концевики")]
        [Description("Модуль вотобразает статус концевиков")]
        [Category("4. Настройки отображения модулей")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowGuiPanelLimits
        {
            get { return _showGuiPanelLimits; }
            set { _showGuiPanelLimits = value; }

        }

        private bool _showGuiPanelManualControl;
        [DisplayName(@"Ручное управление")]
        [Description("Модуль позволяет с помощью мыши, или клавиш управлять станком")]
        [Category("4. Настройки отображения модулей")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowGuiPanelManualControl
        {
            get { return _showGuiPanelManualControl; }
            set { _showGuiPanelManualControl = value; }

        }

        private bool _showGuiPanelMoveTo;
        [DisplayName(@"Запуск движения в точку")]
        [Description("Модуль позволяет запустить движение в указанную точку")]
        [Category("4. Настройки отображения модулей")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowGuiPanelMoveTo
        {
            get { return _showGuiPanelMoveTo; }
            set { _showGuiPanelMoveTo = value; }

        }

        private bool _showGuiPanelPos;
        [DisplayName(@"Координаты")]
        [Description("Модуль выводит координаты станка")]
        [Category("4. Настройки отображения модулей")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowGuiPanelPos
        {
            get { return _showGuiPanelPos; }
            set { _showGuiPanelPos = value; }

        }

        private bool _showGuiPanelTaskControl;
        [DisplayName(@"Выполнение G-кода")]
        [Description("Модуль позволяет запускать выполнение G-кода")]
        [Category("4. Настройки отображения модулей")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowGuiPanelTaskControl
        {
            get { return _showGuiPanelTaskControl; }
            set { _showGuiPanelTaskControl = value; }
        }

        private bool _showGuiPanelBitValue;
        [DisplayName(@"Регистры контроллера")]
        [Description("Модуль позволяет отображать значения некоторых регистров контроллера")]
        [Category("4. Настройки отображения модулей")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowGuiPanelBitValue
        {
            get { return _showGuiPanelBitValue; }
            set { _showGuiPanelBitValue = value; }
        }








    }

    /// <summary>
    /// Параметры одной оси
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class AxleSetting
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AxleSetting()
        {
            _usedAxes = true;
            _countPulse = 200;
            _nameUe = "мм.";
            _maxSpeed = 200;
            _acceleration = 20;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public AxleSetting(bool usedAxes = true, int countPulse = 200, string nameUe = "мм.", int maxSpeed = 200, int acceleration = 20)
        {
            _usedAxes = usedAxes;
            _countPulse = countPulse;
            _nameUe = nameUe;
            _maxSpeed = maxSpeed;
            _acceleration = acceleration;
        }


        private bool _usedAxes;
        [DisplayName(@"Использовать")]
        [Description("Использовать ли данную ось")]
        [PropertyOrder(10)]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool UsedAxes
        {
            get { return _usedAxes; }
            set { _usedAxes = value; }

        }

        private int _countPulse;
        [DisplayName(@"Количество импульсов на 1 у.е.")]
        [Description("Настройка позволяет указать сколько импульсов соответствует, одной у.е.")]
        [PropertyOrder(20)]
        public int CountPulse
        {
            get { return _countPulse; }
            set { _countPulse = value; }

        }

        private string _nameUe;
        [DisplayName(@"Наименование у.е.")]
        [Description("Наименование условной единицы")]
        [PropertyOrder(30)]
        public string NameUE
        {
            get { return _nameUe; }
            set { _nameUe = value; }
        }


        private int _maxSpeed;
        [DisplayName(@"Максимальная скорость")]
        [Description("Настройка позволяет указать максимальную скорость движения")]
        [PropertyOrder(40)]
        public int MaxSpeed
        {
            get { return _maxSpeed; }
            set { _maxSpeed = value; }

        }

        private int _acceleration;
        [DisplayName(@"Ускорение")]
        [Description("Настройка позволяет указать ускорение")]
        [PropertyOrder(50)]
        public int Acceleration
        {
            get { return _acceleration; }
            set { _acceleration = value; }

        }




        /// <summary>
        /// Представление в виде строки
        /// </summary>
        public override string ToString()
        {
            if (_usedAxes) return _countPulse + " имп. на 1 " + _nameUe;

            return "Не используется";
        }

    } 

    /// <summary>
    /// Перечень поддерживающих контроллеров
    /// </summary>
    [Serializable]
    public enum ControllerModel
    {
        /// <summary>
        /// Контроллер МК1
        /// </summary>
        [Description("Planet-CNC MK1")]
        PlanetCNC_MK1 = 0,
        /// <summary>
        /// Контроллер МК2
        /// </summary>
        [Description("Planet-CNC MK2")]
        PlanetCNC_MK2 = 1//,
        /// <summary>
        /// Контроллер ардуино
        /// </summary>
        //[Description("Arduino UNO + GRBL v0.9")]
        //Arduino_Gerber09 = 2
    }

    /// <summary>
    /// Доступные языки программы
    /// </summary>
    [Serializable]
    public enum Languages
    {
        /// <summary>
        /// Русский
        /// </summary>
        [Description("Русский")]
        Russian = 0,
        /// <summary>
        /// Английский
        /// </summary>
        [Description("Английский")]
        English = 1
    };


    /// <summary>
    /// Параметры отображения g-кода
    /// </summary>
    [Serializable]
    public enum Show3DGkode
    {
        /// <summary>
        /// Отображать весь G-код
        /// </summary>
        [Description("Весь")]
        All = 0,
        /// <summary>
        /// Отображать только выполненный G-код
        /// </summary>
        [Description("Только выполненный")]
        Compleated = 1,
        /// <summary>
        /// Отображать G-код, который осталось выполнить
        /// </summary>
        [Description("Только не выполненный")]
        NotCompleated = 2
    };


    class BooleanTypeConverter : BooleanConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context,
          CultureInfo culture,
          object value,
          Type destType)
        {
            return (bool)value ?
              "Да" : "Нет";
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
          CultureInfo culture,
          object value)
        {
            return (string)value == "Да";
        }
    }

    /// <summary>
    /// TypeConverter для Enum, преобразовывающий Enum к строке с
    /// учетом атрибута Description
    /// </summary>
    class EnumTypeConverter : EnumConverter
    {
        private Type _enumType;
        /// <summary>Инициализирует экземпляр</summary>
        /// <param name="type">тип Enum</param>
        public EnumTypeConverter(Type type)
            : base(type)
        {
            _enumType = type;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context,
          Type destType)
        {
            return destType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
          CultureInfo culture,
          object value, Type destType)
        {
            FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, value));
            DescriptionAttribute dna =
              (DescriptionAttribute)Attribute.GetCustomAttribute(
                fi, typeof(DescriptionAttribute));

            if (dna != null)
                return dna.Description;
            else
                return value.ToString();
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context,
          Type srcType)
        {
            return srcType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
          CultureInfo culture,
          object value)
        {
            foreach (FieldInfo fi in _enumType.GetFields())
            {
                DescriptionAttribute dna =
                  (DescriptionAttribute)Attribute.GetCustomAttribute(
                    fi, typeof(DescriptionAttribute));

                if ((dna != null) && ((string)value == dna.Description))
                    return Enum.Parse(_enumType, fi.Name);
            }

            return Enum.Parse(_enumType, (string)value);
        }

    }

    public class PropertySorter : ExpandableObjectConverter
    {
        #region Методы

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Возвращает упорядоченный список свойств
        /// </summary>
        public override PropertyDescriptorCollection GetProperties(
          ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection pdc =
              TypeDescriptor.GetProperties(value, attributes);

            ArrayList orderedProperties = new ArrayList();

            foreach (PropertyDescriptor pd in pdc)
            {
                Attribute attribute = pd.Attributes[typeof(PropertyOrderAttribute)];

                if (attribute != null)
                {
                    // атрибут есть - используем номер п/п из него
                    PropertyOrderAttribute poa = (PropertyOrderAttribute)attribute;
                    orderedProperties.Add(new PropertyOrderPair(pd.Name, poa.Order));
                }
                else
                {
                    // атрибута нет – считаем, что 0
                    orderedProperties.Add(new PropertyOrderPair(pd.Name, 0));
                }
            }

            // сортируем по Order-у
            orderedProperties.Sort();

            // формируем список имен свойств
            ArrayList propertyNames = new ArrayList();

            foreach (PropertyOrderPair pop in orderedProperties)
                propertyNames.Add(pop.Name);

            // возвращаем
            return pdc.Sort((string[])propertyNames.ToArray(typeof(string)));
        }

        #endregion
    }

    #region PropertyOrder Attribute

    /// <summary>
    /// Атрибут для задания сортировки
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyOrderAttribute : Attribute
    {
        private int _order;
        public PropertyOrderAttribute(int order)
        {
            _order = order;
        }

        public int Order
        {
            get { return _order; }
        }
    }

    #endregion

    #region PropertyOrderPair

    /// <summary>
    /// Пара имя/номер п/п с сортировкой по номеру
    /// </summary>
    public class PropertyOrderPair : IComparable
    {
        private int _order;
        private string _name;

        public string Name
        {
            get { return _name; }
        }

        public PropertyOrderPair(string name, int order)
        {
            _order = order;
            _name = name;
        }

        /// <summary>
        /// Собственно метод сравнения
        /// </summary>
        public int CompareTo(object obj)
        {
            int otherOrder = ((PropertyOrderPair)obj)._order;

            if (otherOrder == _order)
            {
                // если Order одинаковый - сортируем по именам
                string otherName = ((PropertyOrderPair)obj)._name;
                return string.Compare(_name, otherName);
            }
            else if (otherOrder > _order)
                return -1;

            return 1;
        }
    }

    #endregion



}
