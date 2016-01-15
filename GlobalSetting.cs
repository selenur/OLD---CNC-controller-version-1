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
    /// Класс для хранения абсолютно всех настроек программы
    /// </summary>
    public static class GlobalSetting
    {
        /// <summary>
        /// Файл настроек программы
        /// </summary>
        private static readonly string Filesetting1 = string.Format("{0}\\setup1.ini", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        private static readonly string Filesetting2 = string.Format("{0}\\setup2.ini", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        private static readonly string Filesetting3 = string.Format("{0}\\setup3.ini", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        private static readonly string Filesetting4 = string.Format("{0}\\setup4.ini", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        // создание классов, с настройками по умолчанию
        public static SettingAPP AppSetting = new SettingAPP();
        public static SettingController ControllerSetting = new SettingController();
        public static SettingRender RenderSetting = new SettingRender();
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

    [Serializable]
    public class SettingAPP
    {
        private ControllerModel _Controller = ControllerModel.PlanetCNC_MK1;
        [DisplayName("Модель контроллера")]
        [Description("В данном пункте выбирается аппаратный контроллер, с которым будет работать программа")]
        [Category("1. Настройки программы")]
        [TypeConverter(typeof(EnumTypeConverter))]
        public ControllerModel Controller
        {
            get { return _Controller; }
            set { _Controller = value; }

        }

        private languages _language = languages.russian;
        [DisplayName("Язык программы")]
        [Category("1. Настройки программы")]
        //[ReadOnly(true)]
        [TypeConverter(typeof(EnumTypeConverter))]
        public languages Language
        {
            get { return _language; }
            set { _language = value; }

        }

        private bool _autoconnect = false;
        [DisplayName("Авто-подключение")]
        [Description("Постоянное удержание связи с контроллером, в случае обрыва связи, будет выполнятся автоматическое подключение")]
        [Category("1. Настройки программы")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool Autoconnect
        {
            get { return _autoconnect; }
            set { _autoconnect = value; }           

        }
    }

    [Serializable]
    public class SettingController
    {

        private int _MinBuffSize = 3;
        [DisplayName("Количество посылаемых данных")]
        [Description("Настройка позволяет указать сколько посылать комманд в контроллер, от текущего кадра наперед.")]
        [PropertyOrder(5)]
        [Category("2. Настройки контроллера")]
        public int MinBuffSize
        {
            get { return _MinBuffSize; }
            set { _MinBuffSize = value; }

        }

        private AxleSetting _AxleX = new AxleSetting();
        [DisplayName("Ось X")]
        [Description("Настройки оси X")]
        [PropertyOrder(10)]
        [Category("2.1 Параметры осей")]
        public AxleSetting AxleX
        {
            get { return _AxleX; }
            set { _AxleX = value; }
        }


        private AxleSetting _AxleY = new AxleSetting();
        [DisplayName("Ось Y")]
        [Description("Настройки оси Y")]
        [PropertyOrder(20)]
        [Category("2.1 Параметры осей")]
        public AxleSetting AxleY
        {
            get { return _AxleY; }
            set { _AxleY = value; }
        }


        private AxleSetting _AxleZ = new AxleSetting();
        [DisplayName("Ось Z")]
        [Description("Настройки оси Z")]
        [PropertyOrder(30)]
        [Category("2.1 Параметры осей")]
        public AxleSetting AxleZ
        {
            get { return _AxleZ; }
            set { _AxleZ = value; }
        }


        private AxleSetting _AxleA = new AxleSetting(false);
        [DisplayName("Ось A")]
        [Description("Настройки оси A")]
        [PropertyOrder(40)]
        [Category("2.1 Параметры осей")]
        public AxleSetting AxleA
        {
            get { return _AxleA; }
            set { _AxleA = value; }
        }





        //X+
        private bool _UseLimitSwichXp = true;
        [DisplayName("X+")]
        [Description("X+")]
        [PropertyOrder(1)]
        [Category("2.2 Использование концевиков")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool UseLimitSwichXp
        {
            get { return _UseLimitSwichXp; }
            set { _UseLimitSwichXp = value; }
        }

        //X-
        private bool _UseLimitSwichXm = true;
        [DisplayName("X-")]
        [Description("X-")]
        [PropertyOrder(1)]
        [Category("2.2 Использование концевиков")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool UseLimitSwichXm
        {
            get { return _UseLimitSwichXm; }
            set { _UseLimitSwichXm = value; }
        }


        //Y+
        private bool _UseLimitSwichYp = true;
        [DisplayName("Y+")]
        [Description("Y+")]
        [PropertyOrder(1)]
        [Category("2.2 Использование концевиков")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool UseLimitSwichYp
        {
            get { return _UseLimitSwichYp; }
            set { _UseLimitSwichYp = value; }
        }

        //Y-
        private bool _UseLimitSwichYm = true;
        [DisplayName("Y-")]
        [Description("Y-")]
        [PropertyOrder(1)]
        [Category("2.2 Использование концевиков")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool UseLimitSwichYm
        {
            get { return _UseLimitSwichYm; }
            set { _UseLimitSwichYm = value; }
        }


        //X+
        private bool _UseLimitSwichZp = true;
        [DisplayName("Z+")]
        [Description("Z+")]
        [PropertyOrder(1)]
        [Category("2.2 Использование концевиков")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool UseLimitSwichZp
        {
            get { return _UseLimitSwichZp; }
            set { _UseLimitSwichZp = value; }
        }

        //X-
        private bool _UseLimitSwichZm = true;
        [DisplayName("Z-")]
        [Description("Z-")]
        [PropertyOrder(1)]
        [Category("2.2 Использование концевиков")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool UseLimitSwichZm
        {
            get { return _UseLimitSwichZm; }
            set { _UseLimitSwichZm = value; }
        }




        private float _WorkSizeXp = 0;
        [DisplayName("Граница X+")]
        [Description("Граница рабочей области")]
        [PropertyOrder(5)]
        [Category("2.3 Рабочая область")]
        public float WorkSizeXp
        {
            get { return _WorkSizeXp; }
            set { _WorkSizeXp = value; }

        }

        private float _WorkSizeXm = 0;
        [DisplayName("Граница X-")]
        [Description("Граница рабочей области")]
        [PropertyOrder(5)]
        [Category("2.3 Рабочая область")]
        public float WorkSizeXm
        {
            get { return _WorkSizeXm; }
            set { _WorkSizeXm = value; }

        }

        private float _WorkSizeYp = 0;
        [DisplayName("Граница Y+")]
        [Description("Граница рабочей области")]
        [PropertyOrder(5)]
        [Category("2.3 Рабочая область")]
        public float WorkSizeYp
        {
            get { return _WorkSizeYp; }
            set { _WorkSizeYp = value; }

        }

        private float _WorkSizeYm = 0;
        [DisplayName("Граница Y-")]
        [Description("Граница рабочей области")]
        [PropertyOrder(5)]
        [Category("2.3 Рабочая область")]
        public float WorkSizeYm
        {
            get { return _WorkSizeYm; }
            set { _WorkSizeYm = value; }

        }



    }

    [Serializable]
    public class SettingRender
    {

        private bool _ShowAxes = true;
        [DisplayName("Отображать оси")]
        [Description("Показывать оси X,Y,Z")]
        [PropertyOrder(1)]
        [Category("3.1 Настройки 3D")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowAxes
        {
            get { return _ShowAxes; }
            set { _ShowAxes = value; }
        }

        private bool _ShowCursor = true;
        [DisplayName("Отображать курсор/инструмент")]
        [Description("Показывать курсор/инструмент")]
        [PropertyOrder(2)]
        [Category("3.1 Настройки 3D")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowCursor
        {
            get { return _ShowCursor; }
            set { _ShowCursor = value; }
        }

        private bool _ShowGrid = true;
        [DisplayName("Отображать сетку")]
        [Description("Показывать сетку")]
        [PropertyOrder(3)]
        [Category("3.2 Настройки 3D - Сетка")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowGrid
        {
            get { return _ShowGrid; }
            set { _ShowGrid = value; }
        }

        private int _GridSize = 10;
        [DisplayName("Размер ячейки")]
        [Description(" ")]
        [PropertyOrder(4)]
        [Category("3.2 Настройки 3D - Сетка")]
        public int GridSize
        {
            get { return _GridSize; }
            set { _GridSize = value; }

        }

        private int _GridSizeX = 100;
        [DisplayName("Размер сетки по X")]
        [Description(" ")]
        [PropertyOrder(4)]
        [Category("3.2 Настройки 3D - Сетка")]
        public int GridSizeX
        {
            get { return _GridSizeX; }
            set { _GridSizeX = value; }

        }

        private int _GridSizeY = 100;
        [DisplayName("Размер сетки по Y")]
        [Description(" ")]
        [PropertyOrder(4)]
        [Category("3.2 Настройки 3D - Сетка")]
        public int GridSizeY
        {
            get { return _GridSizeY; }
            set { _GridSizeY = value; }

        }





        private bool _ShowWorkArea = true;
        [DisplayName("Отображать рабочую область")]
        [Description("Показывать область в пределах которой станок сможет работать")]
        [PropertyOrder(5)]
        [Category("3.1 Настройки 3D")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowWorkArea
        {
            get { return _ShowWorkArea; }
            set { _ShowWorkArea = value; }
        }



        private bool _ShowScanedGrid = true;
        [DisplayName("Отображать сетку сканирования")]
        [Description("Показывать сетку сканирования")]
        [PropertyOrder(5)]
        [Category("3.1 Настройки 3D")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool ShowScanedGrid
        {
            get { return _ShowScanedGrid; }
            set { _ShowScanedGrid = value; }
        }

        private show3DGkode _gkodeshow = show3DGkode.all;
        [DisplayName("Вариант отображения G-кода")]
        [Category("3.1 Настройки 3D")]
        //[ReadOnly(true)]
        [TypeConverter(typeof(EnumTypeConverter))]
        public show3DGkode gkodeshow
        {
            get { return _gkodeshow; }
            set { _gkodeshow = value; }
        }

        
    }

    [Serializable]
    public class SettingPanels
    {

        private bool _showGUI_panel_Info = false;
        [DisplayName("Скорость движения")]
        [Description("Модуль отображает скорость движения")]
        [Category("4. Настройки отображения модулей")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool showGUI_panel_Info
        {
            get { return _showGUI_panel_Info; }
            set { _showGUI_panel_Info = value; }

        }

        private bool _showGUI_panel_Limits = false;
        [DisplayName("Концевики")]
        [Description("Модуль вотобразает статус концевиков")]
        [Category("4. Настройки отображения модулей")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool showGUI_panel_Limits
        {
            get { return _showGUI_panel_Limits; }
            set { _showGUI_panel_Limits = value; }

        }

        private bool _showGUI_panel_ManualControl = false;
        [DisplayName("Ручное управление")]
        [Description("Модуль позволяет с помощью мыши, или клавиш управлять станком")]
        [Category("4. Настройки отображения модулей")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool showGUI_panel_ManualControl
        {
            get { return _showGUI_panel_ManualControl; }
            set { _showGUI_panel_ManualControl = value; }

        }

        private bool _showGUI_panel_MoveTo = false;
        [DisplayName("Запуск движения в точку")]
        [Description("Модуль позволяет запустить движение в указанную точку")]
        [Category("4. Настройки отображения модулей")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool showGUI_panel_MoveTo
        {
            get { return _showGUI_panel_MoveTo; }
            set { _showGUI_panel_MoveTo = value; }

        }

        private bool _showGUI_panel_POS = false;
        [DisplayName("Координаты")]
        [Description("Модуль выводит координаты станка")]
        [Category("4. Настройки отображения модулей")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool showGUI_panel_POS
        {
            get { return _showGUI_panel_POS; }
            set { _showGUI_panel_POS = value; }

        }

        private bool _showGUI_panel_TaskControl = false;
        [DisplayName("Выполнение G-кода")]
        [Description("Модуль позволяет запускать выполнение G-кода")]
        [Category("4. Настройки отображения модулей")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool showGUI_panel_TaskControl
        {
            get { return _showGUI_panel_TaskControl; }
            set { _showGUI_panel_TaskControl = value; }
        }

        private bool _showGUI_panel_BitValue = false;
        [DisplayName("Регистры контроллера")]
        [Description("Модуль позволяет отображать значения некоторых регистров контроллера")]
        [Category("4. Настройки отображения модулей")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool showGUI_panel_BitValue
        {
            get { return _showGUI_panel_BitValue; }
            set { _showGUI_panel_BitValue = value; }
        }

        private bool _showGUI_panel_3DView = false;
        [DisplayName("Найстройки 3D отображения")]
        [Description("Модуль позволяет настраивать информацию того что отображать")]
        [Category("4. Настройки отображения модулей")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool showGUI_panel_3DView
        {
            get { return _showGUI_panel_3DView; }
            set { _showGUI_panel_3DView = value; }
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
        public AxleSetting(bool usedAxes = true, int CountPulse = 200, string NameUE = "мм.", int MaxSpeed = 200, int acceleration = 20)
        {
            _usedAxes = usedAxes;
            _CountPulse = CountPulse;
            _NameUE = NameUE;
            _MaxSpeed = MaxSpeed;
            _acceleration = acceleration;
        }


        private bool _usedAxes = true;
        [DisplayName("Использовать")]
        [Description("Использовать ли данную ось")]
        [PropertyOrder(10)]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool UsedAxes
        {
            get { return _usedAxes; }
            set { _usedAxes = value; }

        }

        private int _CountPulse = 200;
        [DisplayName("Количество импульсов на 1 у.е.")]
        [Description("Настройка позволяет указать сколько импульсов соответствует, одной у.е.")]
        [PropertyOrder(20)]
        public int countPulse
        {
            get { return _CountPulse; }
            set { _CountPulse = value; }

        }

        private string _NameUE = "мм.";
        [DisplayName("Наименование у.е.")]
        [Description("Наименование условной единицы")]
        [PropertyOrder(30)]
        public string NameUE
        {
            get { return _NameUE; }
            set { _NameUE = value; }
        }


        private int _MaxSpeed = 200;
        [DisplayName("Максимальная скорость")]
        [Description("Настройка позволяет указать максимальную скорость движения")]
        [PropertyOrder(40)]
        public int MaxSpeed
        {
            get { return _MaxSpeed; }
            set { _MaxSpeed = value; }

        }

        private int _acceleration = 20;
        [DisplayName("Ускорение")]
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
            if (_usedAxes == true) return _CountPulse + " имп. на 1 " + _NameUE;

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
        PlanetCNC_MK2 = 1,
        /// <summary>
        /// Контроллер ардуино
        /// </summary>
        [Description("Arduino UNO + GRBL v0.9")]
        Arduino_Gerber09 = 2
        ///// <summary>
        ///// Эмулятор контроллера
        ///// </summary>
        //[Description("Эмулятор контроллера")]
        //Emulator = 3
    }

    /// <summary>
    /// язык программы
    /// </summary>
    [Serializable]
    public enum languages
    {
        [Description("Русский")]
        russian = 0,
        [Description("Английский")]
        english = 1
    };


    /// <summary>
    /// параметры отображения g-кода
    /// </summary>
    [Serializable]
    public enum show3DGkode
    {
        [Description("Весь")]
        all = 0,
        [Description("Только выполненный")]
        compleated = 1,
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
