using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using LibUsbDotNet;
using LibUsbDotNet.Main;

namespace CNC_Controller
{
    /// <summary>
    /// Класс работы с контроллером MK1
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class CONTROLLER
    {
        #region Инициализация событий контроллера

        public delegate void DeviceEventConnect(object sender); //уведомление об установки связи
        public delegate void DeviceEventDisconnect(object sender, DeviceEventArgsMessage e); //уведомление об обрыве/прекращении связи
        public delegate void DeviceEventNewData(object sender); //уведомление что получены новые данные контроллером
        public delegate void DeviceEventNewMessage(object sender, DeviceEventArgsMessage e); //для посылки управляющей программе сообщений о действиях

        /// <summary>
        /// Событие при успешном подключении к контроллеру
        /// </summary>
        public event DeviceEventConnect WasConnected;
        /// <summary>
        /// Событие при отключении от контроллера, или разрыве связи с контроллером
        /// </summary>
        public event DeviceEventDisconnect WasDisconnected;
        /// <summary>
        /// Получены новые данные от контроллера
        /// </summary>
        public event DeviceEventNewData NewDataFromController;
        /// <summary>
        /// Посылка строки описания (для ведения логов)
        /// </summary>
        public event DeviceEventNewMessage Message;

        #endregion
        
        #region внутренние параметры

        /// <summary>
        /// Наличие связи с контроллером
        /// </summary>
        private bool _connected;

        /// <summary>
        /// Поток для получения, посылки данных в контроллер
        /// </summary>
        private BackgroundWorker _theads;

        private UsbDevice _myUsbDevice;
        private ErrorCode _ec;
        private UsbEndpointReader _usbReader;
        private UsbEndpointWriter _usbWriter;

        #endregion

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public CONTROLLER()
        {
            _connected = false;
            //Создаем поток, и подключаем к нему процедуру
            _theads = new BackgroundWorker();
            _theads.DoWork += TheadsStart;
        }

        #region Работа с настройками программы

        /// <summary>
        /// Файл настроек программы
        /// </summary>
        private readonly string _filesetting = string.Format("{0}\\setting.ini", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

        /// <summary>
        /// Функция для сохранения параметров в файле настроек
        /// Сохраненные данные в файле будут выглядеть следующим образом:
        /// параметр = значение
        /// !!! Поэтому знак равно нельзя использовать ни в параметре ни в значении
        /// </summary>
        /// <param name="property">Имя параметра (строка)</param>
        /// <param name="value">Значение параметра (Строка)</param>
        private void SaveProperty(string property, string value)
        {
            List<string> listProperty = new List<string>();

            // Запись параметра в файл

            // В начале получим все параметры
            if (File.Exists(_filesetting))
            {

                StreamReader sr = new StreamReader(_filesetting);
                string[] arr = sr.ReadToEnd().Split('\n');
                sr.Close();

                foreach (string ss in arr)
                {
                    // ReSharper disable once RedundantAssignment
                    var sformat = ss.Replace('\n', ' ').Trim();
                    sformat = ss.Replace('\r', ' ').Trim();

                    if (sformat.Length < 3) continue;
                    //проверим наш ли это параметр
                    int posSymbol = sformat.IndexOf('=');

                    if (posSymbol == 0) continue; //странный параметр, такой не нужен нам

                    string sProperty = sformat.Substring(0, posSymbol);
                    string sValue = sformat.Substring(posSymbol + 1);

                    if (property.Trim() == sProperty.Trim()) continue; //нужный параметр пропустим

                    listProperty.Add(sProperty + "=" + sValue);
                }
            }

            //если в существующем файле такого параметра нет, то добавим новый
            listProperty.Add(property + "=" + value);

            try
            {
                string sOut = "";

                foreach (string ss in listProperty)
                {
                    sOut += ss + Environment.NewLine;

                    //OutputFile.WriteLine(ss);
                }

                StreamWriter sw = new StreamWriter(_filesetting);
                sw.WriteLine(sOut);
                sw.Close();
            }
            catch (Exception)
            {
                //addLog(e.ToString(), true);
            }
        }

        /// <summary>
        /// Функция извлечения параметра из файла настроек
        /// </summary>
        /// <param name="property">Имя параметра (строка)</param>
        /// <returns>Значение параметра (Строка), если будет отсутствовать файл настроек, или указанный параметр, то вернется ""</returns>
        private string LoadProperty(string property)
        {
            if (!File.Exists(_filesetting)) return "";
            var sr = new StreamReader(_filesetting);
            var arr = sr.ReadToEnd().Split('\n');
            sr.Close();

            foreach (var ss in arr)
            {
                //проверим наш ли это параметр
                var posSymbol = ss.IndexOf('=');

                if (posSymbol == 0) continue; //странный параметр, такой не нужен нам

                var sProperty = ss.Substring(0, posSymbol);
                var sValue = ss.Substring(posSymbol + 1);

                if (property.Trim() == sProperty.Trim())
                {
                    return sValue;
                }
            }
            return "";
        }

        /// <summary>
        /// Загрузка настроек программы из файла
        /// </summary>
        public void LoadSetting()
        {
            string sPulseX = LoadProperty("pulseX");
            string sPulseY = LoadProperty("pulseY");
            string sPulseZ = LoadProperty("pulseZ");

            if (sPulseX.Trim() != "") deviceInfo.AxesX_PulsePerMm = int.Parse(sPulseX);
            if (sPulseY.Trim() != "") deviceInfo.AxesY_PulsePerMm = int.Parse(sPulseY);
            if (sPulseZ.Trim() != "") deviceInfo.AxesZ_PulsePerMm = int.Parse(sPulseZ);

        }

        /// <summary>
        /// Сохранение настроек в файл
        /// </summary>
        public void SaveSetting()
        {
            SaveProperty("pulseX", deviceInfo.AxesX_PulsePerMm.ToString());
            SaveProperty("pulseY", deviceInfo.AxesY_PulsePerMm.ToString());
            SaveProperty("pulseZ", deviceInfo.AxesZ_PulsePerMm.ToString());
        }

        #endregion

        #region Свойства для доступа извне к переменным
        //TODO: пересмотреть необходимость процедур
        /// <summary>
        /// Возвращает информацию о наличии связи
        /// </summary>
        public bool Connected
        {
            get
            {
                return _connected;
            }
        }

        /// <summary>
        /// Скорость движения шпинделя
        /// </summary>
        public int ShpindelMoveSpeed
        {
            get
            {
                return deviceInfo.shpindel_MoveSpeed;
            }
        }

        /// <summary>
        /// Номер выполняемой инструкции
        /// </summary>
        public int NumberComleatedInstructions
        {
            get
            {
                return deviceInfo.NuberCompleatedInstruction;
            }
        }

        /// <summary>
        /// Свойство включен ли шпиндель
        /// </summary>
        public bool SpindelOn
        {
            get { return deviceInfo.shpindel_Enable; }
        }

        /// <summary>
        /// Свойство активированна ли аварийная остановка
        /// </summary>
        public bool EstopOn
        {
            get { return deviceInfo.Estop; }
        }

        /// <summary>
        /// Проверка наличия связи, и незанятости контроллера
        /// </summary>
        /// <returns>булево, возможно ли посылать контроллеру задачи</returns>
        public bool TestAllowActions()
        {
            if (!Connected)
            {
                //StringError = @"Отсутствует связь с контроллером!";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Для проверки новых данных от контроллера
        /// </summary>
        public bool AvailableNewData { get; set; }


        /// <summary>
        /// Размер свободного буфера
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public int AvailableBufferSize
        {
            get
            {
                return deviceInfo.FreebuffSize;
            }
            // ReSharper disable once ValueParameterNotUsed
            set
            {
            }
        }

        #endregion

        #region Поток выполнения задания

        /// <summary>
        /// Парсит полученные данные с контроллера
        /// </summary>
        /// <param name="readBuffer"></param>
        private void ParseInfo(IList<byte> readBuffer)
        {
            deviceInfo.FreebuffSize = readBuffer[1];
            deviceInfo.shpindel_MoveSpeed = (int)(((readBuffer[22] * 65536) + (readBuffer[21] * 256) + (readBuffer[20])) / 2.1); 
            deviceInfo.AxesX_PositionPulse = (readBuffer[27] * 16777216) + (readBuffer[26] * 65536) + (readBuffer[25] * 256) + (readBuffer[24]);
            deviceInfo.AxesY_PositionPulse = (readBuffer[31] * 16777216) + (readBuffer[30] * 65536) + (readBuffer[29] * 256) + (readBuffer[28]);
            deviceInfo.AxesZ_PositionPulse = (readBuffer[35] * 16777216) + (readBuffer[34] * 65536) + (readBuffer[33] * 256) + (readBuffer[32]);

            deviceInfo.AxesX_LimitMax = (readBuffer[15] & (1 << 0)) != 0;
            deviceInfo.AxesX_LimitMin = (readBuffer[15] & (1 << 1)) != 0;
            deviceInfo.AxesY_LimitMax = (readBuffer[15] & (1 << 2)) != 0;
            deviceInfo.AxesY_LimitMin = (readBuffer[15] & (1 << 3)) != 0;
            deviceInfo.AxesZ_LimitMax = (readBuffer[15] & (1 << 4)) != 0;
            deviceInfo.AxesZ_LimitMin = (readBuffer[15] & (1 << 5)) != 0;

            deviceInfo.NuberCompleatedInstruction = (int)(readBuffer[9] * 4294967296) + (readBuffer[8] * 65536) + (readBuffer[7] * 256) + (readBuffer[6]);

            SuperByte bb = new SuperByte(readBuffer[19]);

            deviceInfo.shpindel_Enable = bb.Bit0;

            SuperByte bb2 = new SuperByte(readBuffer[14]);
            deviceInfo.Estop = bb2.Bit7;
        }

        private void ADDMessage(string ss)
        {
            if (Message != null) Message(this, new DeviceEventArgsMessage(ss));
        }

        private bool CompareArray(byte[] arr1, byte[] arr2)
        {
            if (arr1 == null || arr2 == null) return false;

            //проверяем 64 байта
            bool value = true;

            for (int i = 0; i < 64; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    value = false;
                    break;
                }
            }
            return value;
        }

        //Поток для выполнения заданий
        private void TheadsStart(object sender, DoWorkEventArgs e)
        {
            ADDMessage("Запуск потока, работы с контроллером");

            if (!deviceInfo.DEMO_DEVICE)
            {
                //vid 2121 pid 2130 в десятичной системе будет как 8481 и 8496 соответственно
                UsbDeviceFinder myUsbFinder = new UsbDeviceFinder(8481, 8496);

                // Попытаемся установить связь
                _myUsbDevice = UsbDevice.OpenUsbDevice(myUsbFinder);

                if (_myUsbDevice == null)
                {

                    string StringError = "Не найден подключенный контроллер.";
                    _connected = false;

                    ADDMessage(StringError);

                    //запустим событие о разрыве связи
                    if (WasDisconnected != null) WasDisconnected(this, new DeviceEventArgsMessage(StringError));

                    return;
                }

                IUsbDevice wholeUsbDevice = _myUsbDevice as IUsbDevice;
                if (!ReferenceEquals(wholeUsbDevice, null))
                {
                    // This is a "whole" USB device. Before it can be used, 
                    // the desired configuration and interface must be selected.

                    // Select config #1
                    wholeUsbDevice.SetConfiguration(1);

                    // Claim interface #0.
                    wholeUsbDevice.ClaimInterface(0);
                }

                // open read endpoint 1.
                _usbReader = _myUsbDevice.OpenEndpointReader(ReadEndpointID.Ep01);

                // open write endpoint 1.
                _usbWriter = _myUsbDevice.OpenEndpointWriter(WriteEndpointID.Ep01);

                ADDMessage("Подключение к контроллеру, успешно");
            }
            else
            {
                ADDMessage("...Запущен ДЕМОРЕЖИМ...");
            }

            AvailableNewData = true;
            _connected = true;

            ADDMessage("Связь с контроллером установлена");

            if (WasConnected != null) WasConnected(this);

            // Для отслеживания изменений
            byte[] _oldInfoFromController = new byte[64];

            while (_connected)
            {
                // 1. Получим данные если есть
                byte[] readBuffer = new byte[64];
                int bytesRead = 0;

                if (!deviceInfo.DEMO_DEVICE)
                {
                    _ec = _usbReader.Read(readBuffer, 2000, out bytesRead); 

                     if (_ec != ErrorCode.None)
                    {
                        _connected = false;
                        if (WasDisconnected != null) WasDisconnected(this, new DeviceEventArgsMessage(@"Ошибка получения данных с контроллера, связь разорвана!"));
                        
                        return;
                    }
                }
                else
                {
                    //TODO: добавить регенерирование данных виртуальным контроллером
                }

                if (bytesRead == 0 || readBuffer[0] != 0x01) continue; //пока получаем пакеты только с кодом 0х01 

                if (CompareArray(_oldInfoFromController, readBuffer)) continue; //если данные от контроллера не изменились, то дальше нет смысла...

                deviceInfo.rawData = readBuffer;

                ParseInfo(readBuffer);
                _oldInfoFromController = readBuffer;
                AvailableNewData = true;

                if (NewDataFromController != null) NewDataFromController(this);
            }

            if (WasDisconnected != null) WasDisconnected(this, new DeviceEventArgsMessage("")); //событие завершения работы

            if (!deviceInfo.DEMO_DEVICE)
            {
                 //завершение работы
                UsbDevice.Exit();
            }

            ADDMessage("Завершение потока работы с контроллером");
        }

        /// <summary>
        /// Установка связи с контроллером
        /// </summary>
        public void Connect()
        {
            if (Connected)
            {
                ADDMessage("Соединение уже установлено!");
                return;
            }

            if (_theads.IsBusy)
            {
                ADDMessage("Повторное подключение невозможно, пока текущее не будет прервано!");
                return;
            }

            //Запустим поток
            _theads.RunWorkerAsync();
        }

        /// <summary>
        /// Отключение от контроллера
        /// </summary>
        public void Disconnect()
        {
            ADDMessage("Прекращение связи с контроллером!");
            _connected = false;
        }

        #endregion

        #region Послания данных в контроллер

        /// <summary>
        /// Посылка в контроллер бинарных данных
        /// </summary>
        /// <param name="data">Набор данных</param>
        /// <param name="checkBuffSize">Проверять ли размер доступного буффера контроллера</param>
        public void SendBinaryData(byte[] data, bool checkBuffSize = true)
        {
            if (checkBuffSize && (deviceInfo.FreebuffSize < 2))
            {
                //тут нужно зависнуть пока буфер не освободиться

                //TODO: перед выполнением проверять буфер на занятость....

            }

            // ReSharper disable once SuggestVarOrType_BuiltInTypes
            // ReSharper disable once RedundantAssignment
            int bytesWritten = 64;

            if (!deviceInfo.DEMO_DEVICE)
            {
               _ec = _usbWriter.Write(data, 2000, out bytesWritten); 
            }
            else
            {
                //TODO: добавить посылку виртуальному
            }
            
        }

        /// <summary>
        /// Включение шпинделя
        /// </summary>
        public void Spindel_ON()
        {
            SendBinaryData(BinaryData.pack_B5(true));
        }

        /// <summary>
        /// Выключение шпинделя
        /// </summary>
        public void Spindel_OFF()
        {
            SendBinaryData(BinaryData.pack_B5(false));
        }

        /// <summary>
        /// Посылка аварийной остановки
        /// </summary>
        public void EnergyStop()
        {
            SendBinaryData(BinaryData.pack_AA(), false);
        }

        /// <summary>
        /// Запуск движения без остановки
        /// </summary>
        /// <param name="x">Ось Х (доступные значения "+" "0" "-")</param>
        /// <param name="y">Ось Y (доступные значения "+" "0" "-")</param>
        /// <param name="z">Ось Z (доступные значения "+" "0" "-")</param>
        /// <param name="speed"></param>
        public void StartManualMove(string x, string y, string z, int speed)
        {
            if (!Connected)
            {
                //stringError = "Для выключения шпинделя, нужно вначале установить связь с контроллером";
                //return false;
                return;
            }

            //if (!IsFreeToTask)
            //{
            //    return;
            //}

            SuperByte axesDirection = new SuperByte(0x00);
            //поставим нужные биты
            if (x == "-") axesDirection.SetBit(0, true);
            if (x == "+") axesDirection.SetBit(1, true);
            if (y == "-") axesDirection.SetBit(2, true);
            if (y == "+") axesDirection.SetBit(3, true);
            if (z == "-") axesDirection.SetBit(4, true);
            if (z == "+") axesDirection.SetBit(5, true);

            //DataClear();
            //DataAdd(BinaryData.pack_BE(axesDirection.valueByte, speed));
            SendBinaryData(BinaryData.pack_BE(axesDirection.ValueByte, speed));
            //Task_Start();
        }

        public void StopManualMove()
        {
            if (!Connected)
            {
                //stringError = "Для выключения шпинделя, нужно вначале установить связь с контроллером";
                //return false;
            }

            byte[] buff = BinaryData.pack_BE(0x00, 0);

            //TODO: разобраться для чего, этот байт
            buff[22] = 0x01;

            //DataClear();
            //DataAdd(buff);
            SendBinaryData(buff);
            //Task_Start();
        }

        /// <summary>
        /// Установка в контроллер, нового положения по осям
        /// </summary>
        /// <param name="x">Положение в импульсах</param>
        /// <param name="y">Положение в импульсах</param>
        /// <param name="z">Положение в импульсах</param>
        public void DeviceNewPosition(int x, int y, int z)
        {
            if (!TestAllowActions()) return;

            SendBinaryData(BinaryData.pack_C8(x, y, z));
        }

        /// <summary>
        /// Установка в контроллер, нового положения по осям в ммилиметрах
        /// </summary>
        /// <param name="x">в миллиметрах</param>
        /// <param name="y">в миллиметрах</param>
        /// <param name="z">в миллиметрах</param>
        // ReSharper disable once UnusedMember.Global
        public void DeviceNewPosition(decimal x, decimal y, decimal z)
        {
            if (!TestAllowActions()) return;

            SendBinaryData(BinaryData.pack_C8(deviceInfo.CalcPosPulse("X", x), deviceInfo.CalcPosPulse("Y", y), deviceInfo.CalcPosPulse("Z", z)));
        }



        #endregion

    }

    /// <summary>
    /// Аргументы для события
    /// </summary>
    public class DeviceEventArgsMessage
    {
        protected string _str;

        public string Message
        {
            get { return _str; }
            set { _str = value;}
        }

        public DeviceEventArgsMessage(string Str)
        {
            _str = Str;
        }
    }

    /// <summary>
    /// Статусы работы с устройством
    /// </summary>
    public enum EStatusDevice { Connect = 0, Disconnect };



    static class deviceInfo
    {
        /// <summary>
        /// Сырые данные от контроллера
        /// </summary>
        public static byte[] rawData = new byte[64];

        /// <summary>
        /// Размер доступного буфера в контроллере
        /// </summary>
        public static byte FreebuffSize = 0;
        /// <summary>
        /// Номер выполненной инструкции
        /// </summary>
        public static int NuberCompleatedInstruction = 0;

        /// <summary>
        /// Текущее положение в импульсах
        /// </summary>
        public static int AxesX_PositionPulse = 0;
        /// <summary>
        /// Текущее положение в импульсах
        /// </summary>
        public static int AxesY_PositionPulse = 0;
        /// <summary>
        /// Текущее положение в импульсах
        /// </summary>
        public static int AxesZ_PositionPulse = 0;

        public static int AxesX_PulsePerMm = 400;
        public static int AxesY_PulsePerMm = 400;
        public static int AxesZ_PulsePerMm = 400;

        //срабатывание сенсора
        public static bool AxesX_LimitMax = false;
        public static bool AxesX_LimitMin = false;
        public static bool AxesY_LimitMax = false;
        public static bool AxesY_LimitMin = false;
        public static bool AxesZ_LimitMax = false;
        public static bool AxesZ_LimitMin = false;


        public static int shpindel_MoveSpeed = 0;
        public static bool shpindel_Enable = false;

        public static bool Estop = false;


        /// <summary>
        /// Использование виртуального контроллера
        /// </summary>
        public static bool DEMO_DEVICE = false;


        public static decimal AxesX_PositionMM
        {
            get
            {
                return (decimal)AxesX_PositionPulse / AxesX_PulsePerMm; ;
            }
        }

        public static decimal AxesY_PositionMM
        {
            get
            {
                return (decimal)AxesY_PositionPulse / AxesY_PulsePerMm; ;
            }
        }

        public static decimal AxesZ_PositionMM
        {
            get
            {
                return (decimal)AxesZ_PositionPulse / AxesZ_PulsePerMm; ;
            }
        }

        /// <summary>
        /// Вычисление положения в импульсах, при указании оси, и положения в миллиметрах
        /// </summary>
        /// <param name="axes">имя оси X,Y,Z</param>
        /// <param name="posMm">положение в мм</param>
        /// <returns>Количество импульсов</returns>
        public static int CalcPosPulse(string axes, decimal posMm)
        {
            if (axes == "X") return (int)(posMm * (decimal)AxesX_PulsePerMm);
            if (axes == "Y") return (int)(posMm * (decimal)AxesY_PulsePerMm);
            if (axes == "Z") return (int)(posMm * (decimal)AxesZ_PulsePerMm);
            return 0;
        }
    }


    /// <summary>
    /// Класс для получиния бинарных данных
    /// </summary>
    public static class BinaryData
    {
        /// <summary>
        /// Данная команда пока непонятна....
        /// </summary>
        /// <param name="byte05"></param>
        /// <returns></returns>
        public static byte[] pack_C0(byte byte05)
        {
            byte[] buf = new byte[64];

            buf[0] = 0xC0;
            buf[5] = byte05;

            return buf;
        }

        public enum TypeSignal
        {
            None,
            Hz,
            RC
        };

        /// <summary>
        /// Управление работой шпинделя
        /// </summary>
        /// <param name="shpindelON">Вкл/Выключен</param>
        /// <param name="numShimChanel">номер канала 1,2, или 3</param>
        /// <param name="ts">Тип сигнала</param>
        /// <param name="SpeedShim">Значение определяющее форму сигнала</param>
        /// <returns></returns>
        public static byte[] pack_B5(bool shpindelON, int numShimChanel = 0, TypeSignal ts = TypeSignal.None, int SpeedShim = 0)
        {
            byte[] buf = new byte[64];

            buf[0] = 0xB5;
            buf[4] = 0x80;


            if (shpindelON)
            {
                buf[5] = 0x02;
            }
            else
            {
                buf[5] = 0x01;
            }

            buf[6] = 0x01; //х.з.

            switch (numShimChanel)
            {
                case 2:
                {
                    buf[8] = 0x02;
                    break;
                }
                case 3:
                {
                    buf[8] = 0x03;
                    break;
                }
                default:
                {
                    buf[8] = 0x00; //доступен только 2 и 3 канал, остальные не подходят....
                    break;
                }
            }


            switch (ts)
            {
                case TypeSignal.Hz:
                {
                    buf[9] = 0x01;
                    break;
                }

                case  TypeSignal.RC:
                {
                    buf[9] = 0x02;
                    break;
                }
                default:
                {
                    buf[9] = 0x00;
                    break;
                }
            }




            int itmp = SpeedShim;
            buf[10] = (byte)(itmp);
            buf[11] = (byte)(itmp >> 8);
            buf[12] = (byte)(itmp >> 16);


            //buf[10] = 0xFF;
            //buf[11] = 0xFF;
            //buf[12] = 0x04;

            return buf;
        }

        /// <summary>
        /// Аварийная остановка
        /// </summary>
        /// <returns></returns>
        public static byte[] pack_AA()
        {
            byte[] buf = new byte[64];
            buf[0] = 0xAA;
            buf[4] = 0x80;
            return buf;
        }

        /// <summary>
        /// Установка в контроллер новых координат, без движения
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static byte[] pack_C8(int x, int y, int z)
        {
            int newPosX = x;
            int newPosY = y;
            int newPosZ = z;

            byte[] buf = new byte[64];
            buf[0] = 0xC8;
            //сколько импульсов сделать
            buf[6] = (byte)(newPosX);
            buf[7] = (byte)(newPosX >> 8);
            buf[8] = (byte)(newPosX >> 16);
            buf[9] = (byte)(newPosX >> 24);
            //сколько импульсов сделать
            buf[10] = (byte)(newPosY);
            buf[11] = (byte)(newPosY >> 8);
            buf[12] = (byte)(newPosY >> 16);
            buf[13] = (byte)(newPosY >> 24);
            //сколько импульсов сделать
            buf[14] = (byte)(newPosZ);
            buf[15] = (byte)(newPosZ >> 8);
            buf[16] = (byte)(newPosZ >> 16);
            buf[17] = (byte)(newPosZ >> 24);

            return buf;
        }










        /// <summary>
        /// Проверка длины инструмента, или прощупывание
        /// </summary>
        /// <returns></returns>
        public static byte[] pack_D2(int speed, decimal returnDistance)
        {
            byte[] buf = new byte[64];

            buf[0] = 0xD2;


            int inewSpd = 0;

            if (speed != 0)
            {
                double dnewSpd = (1800 / (double)speed) * 1000;
                inewSpd = (int)dnewSpd;
            }
            //скорость
            buf[43] = (byte)(inewSpd);
            buf[44] = (byte)(inewSpd >> 8);
            buf[45] = (byte)(inewSpd >> 16);


            //х.з.
            buf[46] = 0x10;

            // 
            int inewReturn = (int)(returnDistance * (decimal)deviceInfo.AxesZ_PulsePerMm);

            //растояние возврата
            buf[50] = (byte)(inewReturn);
            buf[51] = (byte)(inewReturn >> 8);
            buf[52] = (byte)(inewReturn >> 16);
            
            //х.з.
            buf[55] = 0x12;
            buf[56] = 0x7A;

            return buf;
        }



        /// <summary>
        /// Запуск движения без остановки (и остановка)
        /// </summary>
        /// <param name="direction">Направление по осям в байте</param>
        /// <param name="speed">Скорость движения</param>
        /// <returns></returns>
        public static byte[] pack_BE(byte direction, int speed)
        {
            byte[] buf = new byte[64];

            buf[0] = 0xBE;
            buf[4] = 0x80;
            buf[6] = direction;

            int inewSpd = 0;

            if (speed != 0)
            {
                double dnewSpd = (1800 / (double)speed) * 1000;
                inewSpd = (int)dnewSpd;
            }



            //скорость
            buf[10] = (byte)(inewSpd);
            buf[11] = (byte)(inewSpd >> 8);
            buf[12] = (byte)(inewSpd >> 16);

            return buf;
        }



        ///// <summary>
        ///// используется временно для прощупывания
        ///// </summary>
        ///// <returns></returns>
        //public static byte[] pack_CA()
        //{
        //    byte[] buf = new byte[64];


        //    buf[0] = 0xCA;

        //    buf[5] = 0xB9;
        //    buf[14] = 0xD0;
        //    buf[15] = 0x07;
        //    buf[43] = 0x10;
        //    buf[44] = 0x0E;

        //    return buf;
        //}















        public static byte[] pack_9E(byte value)
        {
            byte[] buf = new byte[64];

            buf[0] = 0x9e;
            buf[5] = value;

            return buf;
        }

        /// <summary>
        /// Установка ограничения скорости
        /// </summary>
        /// <param name="speedLimitX">Максимальная скорость по оси X</param>
        /// <param name="speedLimitY">Максимальная скорость по оси Y</param>
        /// <param name="speedLimitZ">Максимальная скорость по оси Z</param>
        /// <returns></returns>
        public static byte[] pack_BF(int speedLimitX, int speedLimitY, int speedLimitZ)
        {
            byte[] buf = new byte[64];

            buf[0] = 0xbf;
            buf[4] = 0x80; //TODO: непонятный байт


            double dnewSpdX = (3600 / (double)speedLimitX) * 1000;
            int inewSpdX = (int)dnewSpdX;

            double dnewSpdY = (3600 / (double)speedLimitY) * 1000;
            int inewSpdY = (int)dnewSpdY;

            double dnewSpdZ = (3600 / (double)speedLimitZ) * 1000;
            int inewSpdZ = (int)dnewSpdZ;

            buf[07] = (byte)(inewSpdX);
            buf[08] = (byte)(inewSpdX >> 8);
            buf[09] = (byte)(inewSpdX >> 16);
            buf[10] = (byte)(inewSpdX >> 24);


            buf[11] = (byte)(inewSpdY);
            buf[12] = (byte)(inewSpdY >> 8);
            buf[13] = (byte)(inewSpdY >> 16);
            buf[14] = (byte)(inewSpdY >> 24);

            buf[15] = (byte)(inewSpdZ);
            buf[16] = (byte)(inewSpdZ >> 8);
            buf[17] = (byte)(inewSpdZ >> 16);
            buf[18] = (byte)(inewSpdZ >> 24);

            return buf;
        }

        /// <summary>
        /// НЕИЗВЕСТНАЯ КОМАНДА
        /// </summary>
        /// <returns></returns>
        public static byte[] pack_C0()
        {
            byte[] buf = new byte[64];

            buf[0] = 0xc0;

            return buf;
        }

        /// <summary>
        /// Движение в указанную точку
        /// </summary>
        /// <param name="_posX">положение X в импульсах</param>
        /// <param name="_posY">положение Y в импульсах</param>
        /// <param name="_posZ">положение Z в импульсах</param>
        /// <param name="_speed">скорость мм/минуту</param>
        /// <param name="_NumberInstruction">Номер данной инструкции</param>
        /// <returns>набор данных для посылки</returns>
        public static byte[] pack_CA(int _posX, int _posY, int _posZ, int _speed, int _NumberInstruction)
        {
            int newPosX = _posX;
            int newPosY = _posY;
            int newPosZ = _posZ;
            int newInst = _NumberInstruction;


            byte[] buf = new byte[64];

            buf[0] = 0xca;
            //запись номера инструкции
            buf[1] = (byte)(newInst);
            buf[2] = (byte)(newInst >> 8);
            buf[3] = (byte)(newInst >> 16);
            buf[4] = (byte)(newInst >> 24);

            buf[5] = 0x39; //TODO: непонятный байт


            //сколько импульсов сделать
            buf[6] = (byte)(newPosX);
            buf[7] = (byte)(newPosX >> 8);
            buf[8] = (byte)(newPosX >> 16);
            buf[9] = (byte)(newPosX >> 24);

            //сколько импульсов сделать
            buf[10] = (byte)(newPosY);
            buf[11] = (byte)(newPosY >> 8);
            buf[12] = (byte)(newPosY >> 16);
            buf[13] = (byte)(newPosY >> 24);

            //сколько импульсов сделать
            buf[14] = (byte)(newPosZ);
            buf[15] = (byte)(newPosZ >> 8);
            buf[16] = (byte)(newPosZ >> 16);
            buf[17] = (byte)(newPosZ >> 24);


            int inewSpd = 2328; //TODO: скорость по умолчанию

            if (_speed != 0)
            {
                double dnewSpd = (1800 / (double)_speed) * 1000;
                inewSpd = (int)dnewSpd;
            }

            //скорость ось х
            buf[43] = (byte)(inewSpd);
            buf[44] = (byte)(inewSpd >> 8);
            buf[45] = (byte)(inewSpd >> 16);

            buf[54] = 0x40;  //TODO: непонятный байт

            return buf;
        }

        /// <summary>
        /// Завершение выполнения всех операций
        /// </summary>
        /// <returns></returns>
        public static byte[] pack_FF()
        {
            byte[] buf = new byte[64];

            buf[0] = 0xff;

            return buf;
        }

        /// <summary>
        /// НЕИЗВЕСТНАЯ КОМАНДА
        /// </summary>
        /// <returns></returns>
        public static byte[] pack_9D()
        {
            byte[] buf = new byte[64];

            buf[0] = 0x9d;

            return buf;
        }

        //public static byte[] GetPack07()
        //{
        //    byte[] buf = new byte[64];

        //    buf[0] = 0x9E;
        //    buf[5] = 0x02;

        //    return buf;
        //}





    }


    #region НАБОР ДАННЫХ

    /// <summary>
    /// Содержит наборы данных G-kode, и для вывода 3d
    /// </summary>
    public static class dataCode
    {
        /// <summary>
        /// Набор готовых инструкций для станка 
        /// </summary>
        public static List<GKOD_ready> GKODready = new List<GKOD_ready>();

        /// <summary>
        /// Набор сырых инструкций для станка 
        /// </summary>
        public static List<GKOD_raw> GKODraw = new List<GKOD_raw>();

        /// <summary>
        /// Набор точек матрицы, получаемой при сканировании поверхности
        /// </summary>
        //public static List<matrixYline> Matrix = new List<matrixYline>(); 


        /// <summary>
        /// Очистка данных
        /// </summary>
        public static void Clear()
        {
            GKODready.Clear();
            GKODraw.Clear();
        }

        private static List<string> parserGkodeLine(string value)
        {

            List<string> lcmd = new List<string>();
            int inx = 0;
            bool collectCommand = false;

            foreach (char symb in value)
            {
                if (symb > 0x40 && symb < 0x5B)  //символы от A до Z
                {
                    if (collectCommand)
                    {
                        inx++;
                        collectCommand = false;
                    }

                    collectCommand = true;
                    lcmd.Add("");
                }

                if (collectCommand) lcmd[inx] += symb.ToString();
            }

            return lcmd;
        }

        /// <summary>
        /// Добавление данных, в виде строки с G-кодом
        /// </summary>
        /// <param name="value">строка с G-кодом</param>
        public static void AddData(string value)
        {

            // 1) распарсим строку
            List<string> lcmd = parserGkodeLine(value);

            // 2) проанализируем список команд
            //    //а так-же разберем команды на те которые знаем и не знаем
            string sGoodsCmd = "";
            string sBadCmd = "";

            foreach (string ss in lcmd)
            {
                    string sCommd = ss.Substring(0, 1).Trim().ToUpper();
                    string sValue = ss.Substring(1).Trim().ToUpper();

                    bool good = false;

                    if (sCommd == "G") //скорости движения
                    {
                        if (sValue == "0" || sValue == "1") good = true;
                        if (sValue == "00" || sValue == "01") good = true;
                    }

                    if (sCommd == "M") //вкл/выкл шпинделя
                    {
                        if (sValue == "3" || sValue == "5") good = true;
                        if (sValue == "03" || sValue == "05") good = true;
                    }

                    if (sCommd == "X" || sCommd == "Y" || sCommd == "Z")
                    {
                        //координаты 3-х осей 
                        good = true;
                        //TODO: дальше могут быть некорректные данные
                    }

                    if (good)
                    {
                        sGoodsCmd += ss + " ";
                    }
                    else
                    {
                        sBadCmd += ss + " ";
                    }
            }

            GKODraw.Add(new GKOD_raw(value, sGoodsCmd, sBadCmd, GKODraw.Count));
        }

        //перезаполнение данных в GKOD_ready из GKOD_raw
        public static void CalculateData()
        {

            GKODready.Clear();

            decimal posx = 0, posy = 0, posz = 0;
            int CNC_speedNow = 100;
            bool spindelOn = false;
            bool workspeed = false;


            foreach (GKOD_raw valueGkodRaw in dataCode.GKODraw)
            {
                if (valueGkodRaw.GoodStr == "") continue;

                List<string> lcmd = parserGkodeLine(valueGkodRaw.GoodStr);

                foreach (string ss in lcmd)
                {
                    string value = ss.Trim().ToUpper();


                    if (value == "G0" || value == "G00")
                    {
                        CNC_speedNow = 500;//todo:
                        workspeed = false;
                    }

                    if (value == "G1" || value == "G01")
                    {
                        CNC_speedNow = 200;//todo:
                        workspeed = true;
                    }

                    if (value.Substring(0, 1) == "X")
                    {
                        string value1 = ss.Substring(1).Trim().Replace('.', ',');
                        if (value1.Trim() != "")
                        {
                            try
                            {
                                //защита при чтении неправильного файла
                                posx = decimal.Parse(value1);
                            }
                            catch (Exception)
                            {

                                //throw;
                            }
                        }
                        
                    }

                    if (value.Substring(0, 1) == "Y")
                    {
                        string value1 = ss.Substring(1).Trim().Replace('.', ',');
                        if (value1.Trim() != "")
                        {
                            try
                            {
                                //защита при чтении неправильного файла
                                posy = decimal.Parse(value1);
                            }
                            catch (Exception)
                            {
                                
                                //throw;
                            }
                            
                        }
                    }

                    if (value.Substring(0, 1) == "Z")
                    {
                        string value1 = ss.Substring(1).Trim().Replace('.', ',');
                        if (value1.Trim() != "")
                        {
                            try
                            {
                                //защита при чтении неправильного файла
                                posz = decimal.Parse(value1);
                            }
                            catch (Exception)
                            {

                                //throw;
                            }
                        }
                    }

                    if (value == "M3" || value == "M03") spindelOn = true;

                    if (value == "M5" || value == "M05") spindelOn = false;

                }

                GKODready.Add(new GKOD_ready(valueGkodRaw.numberLine, spindelOn, posx, posy, posz, CNC_speedNow, workspeed));
            }
            

        }
    
    
        //Более удобная матрица
        public static dobPoint[,] matrix2 = new dobPoint[1,1]; 


    
    
    
    }






    public class matrixYline
    {
        public decimal Y = 0;       // координата в мм
        public List<matrixPoint> X = new List<matrixPoint>(); //набор координат по оси X, и свойства используется ли эта точка
    }

    public class matrixPoint
    {
        public decimal X = 0;       // координата в мм
        public decimal Z = 0;       // координата в мм
        public bool Used = false;       // используется ли эта точка

        public matrixPoint(decimal _X, decimal _Z, bool _Used)
        {
            X = _X;
            Z = _Z;
            Used = _Used;
        }
    }

    /// <summary>
    /// Готовые данные из G-кода для станка
    /// </summary>
    public class GKOD_ready
    {
        public decimal X;       // координата в мм
        public decimal Y;       // координата в мм
        public decimal Z;       // координата в мм
        public int speed;       // скорость
        public bool spindelON;  // вкл. шпинделя
        public int numberInstruct; //номер инструкции
        public bool workspeed = false;

        public GKOD_ready(int _numberInstruct, bool _spindelON, decimal _X, decimal _Y, decimal _Z, int _speed, bool _workspeed)
        {
            X = _X;
            Y = _Y;
            Z = _Z;
            spindelON = _spindelON;
            numberInstruct = _numberInstruct;
            speed = _speed;
            workspeed = _workspeed;
        }
    }

    /// <summary>
    /// Сырые данные G-кода для станка
    /// </summary>
    public class GKOD_raw
    {
        public string FullStr = "";
        public string GoodStr = ""; //для распознанных
        public string BadStr = ""; //для нераспознанных
        public int numberLine = 0;

        public GKOD_raw(string _FullStr, string _GoodStr, string _BadStr, int _numberLine)
        {
            FullStr = _FullStr;
            GoodStr = _GoodStr;
            BadStr = _BadStr;
            numberLine = _numberLine;
        }
    }


    #endregion






    public class decPoint
    {

        public decimal X;       // координата в мм
        public decimal Y;       // координата в мм
        public decimal Z;       // координата в мм

        public decPoint(decimal _x, decimal _y, decimal _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }
    }

    public class dobPoint
    {

        public double X;       // координата в мм
        public double Y;       // координата в мм
        public double Z;       // координата в мм

        public dobPoint(double _x, double _y, double _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }
    }


    //класс для работы с геометрией
    public static class Geometry
    {
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
        public static decPoint GetZ(decPoint p1, decPoint p2, decPoint p3, decPoint p4, decPoint p5)
        {
            decPoint p12 = Geometry.CalcPX(p1, p2, p5);
            decPoint p34 = Geometry.CalcPX(p3, p4, p5);

            decPoint p1234 = Geometry.CalcPY(p12, p34, p5);

            return p1234;
        }

        //нахождение высоты Z точки p0, лежащей на прямой которая паралельна оси X
        public static decPoint CalcPX(decPoint p1, decPoint p2, decPoint p0)
        {
            decPoint ReturnPoint = new decPoint(p0.X,p0.Y,p0.Z);

            ReturnPoint.Z = p1.Z + (((p1.Z - p2.Z) / (p1.X - p2.X)) * (p0.X - p1.X));

            //TODO: учесть на будущее что точка 1 и 2 могут лежать не на одной паралльной линии оси Х
            ReturnPoint.Y = p1.Y;

            return ReturnPoint;
        }

        //TODO: деление на ноль
        //нахождение высоты Z точки p0, лежащей на прямой между точками p3 p4  (прямая паралельна оси Y)
        public static decPoint CalcPY(decPoint p1, decPoint p2, decPoint p0)
        {
            decPoint ReturnPoint = new decPoint(p0.X, p0.Y, p0.Z);

            ReturnPoint.Z = p1.Z + (((p1.Z - p2.Z) / (p1.Y - p2.Y)) * (p0.Y - p1.Y));

            return ReturnPoint;
        }

    }
}






///// <summary>
///// Класс для работы с G-кодом
///// </summary>
//public static class GKode
//{
//    public static List<LineCommands> kode = new List<LineCommands>();

//    public static int CountRow = 0;

//    /// <summary>
//    /// Получение текстового представления последней ошибки
//    /// </summary>
//    private static string _stringError = "";
//    /// <summary>
//    /// Получение текстового представления последней ошибки
//    /// </summary>
//    // ReSharper disable once InconsistentNaming
//    public static string stringError
//    {
//        get { return _stringError; }
//    }

//    /// <summary>
//    /// Очистка от всех данных
//    /// </summary>
//    public static void Clear()
//    {
//        kode.Clear();
//        CountRow = 0;
//    }


//    //{
//    //    //

//    //}
//    //byte[] readBuffer = new byte[64];
//    //byte[] writeBuffer = new byte[64];
//    //int bytesRead;
//    //int bytesWritten;

//    //while (IsConnect)
//    //{





//    //    //а тут мы и посылаем команды...
//    //    if (statusWorks == EStatusTheads.TaskStart)//_isWorking && !task_RUN
//    //    {
//    //        //TODO: это начало задания, поэтому в станок посылаем настройки

//    //        readBuffer = BinaryData.pack_9E(0x05);
//    //        ec = usb_writer.Write(readBuffer, 2000, out bytesWritten);
//    //        System.Threading.Thread.Sleep(1);

//    //        readBuffer = BinaryData.pack_BF(CNC_speedNow, CNC_speedNow, CNC_speedNow);
//    //        ec = usb_writer.Write(readBuffer, 2000, out bytesWritten);
//    //        System.Threading.Thread.Sleep(1);

//    //        readBuffer = BinaryData.pack_C0();
//    //        ec = usb_writer.Write(readBuffer, 2000, out bytesWritten);
//    //        System.Threading.Thread.Sleep(1);
//    //        //task_RUN = true;
//    //        statusWorks = EStatusTheads.TaskWorking;
//    //    }


//    //    if (statusWorks == EStatusTheads.TaskStop)//!_isWorking && task_RUN
//    //    {
//    //        //TODO: выполнение задания завершилось, необходимо послать последние параметры в контроллер
//    //        readBuffer = BinaryData.pack_FF();
//    //        ec = usb_writer.Write(readBuffer, 2000, out bytesWritten);
//    //        System.Threading.Thread.Sleep(1);


//    //        readBuffer = BinaryData.pack_9D();
//    //        ec = usb_writer.Write(readBuffer, 2000, out bytesWritten);
//    //        System.Threading.Thread.Sleep(1);

//    //        readBuffer = BinaryData.pack_9E(0x02);
//    //        ec = usb_writer.Write(readBuffer, 2000, out bytesWritten);
//    //        System.Threading.Thread.Sleep(1);

//    //        for (int i = 0; i < 7; i++)
//    //        {
//    //            readBuffer = BinaryData.pack_FF();
//    //            ec = usb_writer.Write(readBuffer, 2000, out bytesWritten);
//    //            System.Threading.Thread.Sleep(1);
//    //        }

//    //        statusWorks = EStatusTheads.Waiting;

//    //    }

//    //    if (statusWorks == EStatusTheads.TaskWorking)
//    //    {


//    //        lineCommands lcmd = gKode.kode[_numWorkingCommand];

//    //        if (lcmd.sGoodsCmd != "")//отсеим необрабатываемые команды команды
//    //        {

//    //            foreach (string ss in lcmd.cmd)
//    //            {
//    //                if (ss == "G0") CNC_speedNow = CNC_speedG0;

//    //                if (ss == "G1") CNC_speedNow = CNC_speedG1;

//    //                if (ss.Substring(0, 1) == "X")
//    //                {
//    //                    string value = ss.Substring(1).Trim().Replace('.', ',');
//    //                    decimal posx = decimal.Parse(value);
//    //                    CNC_pulseX = (int)(posx * axesX.PulsePerMm);
//    //                }

//    //                if (ss.Substring(0, 1) == "Y")
//    //                {
//    //                    string value = ss.Substring(1).Trim().Replace('.', ',');
//    //                    decimal posy = decimal.Parse(value);
//    //                    CNC_pulseY = (int)(posy * axesY.PulsePerMm);
//    //                }

//    //                if (ss.Substring(0, 1) == "Z")
//    //                {
//    //                    string value = ss.Substring(1).Trim().Replace('.', ',');
//    //                    decimal posz = decimal.Parse(value);
//    //                    CNC_pulseZ = (int)(posz * axesZ.PulsePerMm);
//    //                }

//    //                if (ss == "M3" || ss == "M03") Spindel_ON();

//    //                if (ss == "M5" || ss == "M05") Spindel_OFF();

//    //            }
//    //        }

//    //        _numWorkingCommand++;

//    //        if (_numWorkingCommand == gKode.kode.Count) statusWorks = EStatusTheads.TaskStop;

//    //        //_numWorkingCommand
//    //        //_cmd

//    //        //todo 4 pack
//    //        readBuffer = BinaryData.pack_CA(CNC_pulseX, CNC_pulseY, CNC_pulseZ, CNC_speedNow);
//    //        ec = usb_writer.Write(readBuffer, 2000, out bytesWritten);
//    //        System.Threading.Thread.Sleep(1);
//    //    }

//    //    // Если есть посылка массива данных 
//    //    if (arrSend)
//    //    {
//    //        if (arrIndex < ByteArrayToSend.Count)
//    //        {
//    //            readBuffer = ByteArrayToSend[arrIndex];
//    //            ec = usb_writer.Write(readBuffer, 2000, out bytesWritten);
//    //            System.Threading.Thread.Sleep(1);

//    //            arrIndex++;
//    //        }
//    //        else
//    //        {
//    //            arrSend = false;
//    //        }


//    //    }

//    //}




//}





///// <summary>
///// Класс для хранения 3D Траектории
///// </summary>
//public static class G3D
//{
//    public static List<G3Dpoint> points = new List<G3Dpoint>();




//}


///// <summary>
///// Класс для описания точки
///// </summary>
//public class G3Dpoint
//{
//    public decimal X;
//    public decimal Y;
//    public decimal Z;
//    public bool workspeed;
//    /// <summary>
//    /// Номер для сопоставления с источником комманд
//    /// </summary>
//    // ReSharper disable once NotAccessedField.Global
//    private int NumPosition = 0;


//    public G3Dpoint(decimal x, decimal y, decimal z, bool workspeed, int numPosition)
//    {
//        X = x;
//        Y = y;
//        Z = z;
//        this.workspeed = workspeed;
//        NumPosition = numPosition;
//    }
//}


