using System.Collections.Generic;
using System.ComponentModel;
using LibUsbDotNet;
using LibUsbDotNet.Main;

namespace CNC_App
{
    /// <summary>
    /// Класс работы с контроллером
    /// </summary>
    public static class Controller
    {
        #region Инициализация событий контроллера

        public delegate void DeviceEventConnect(object sender);                              // уведомление об установки связи
        public delegate void DeviceEventDisconnect(object sender, DeviceEventArgsMessage e); // уведомление об обрыве/прекращении связи
        public delegate void DeviceEventNewData(object sender);                              // уведомление что получены новые данные контроллером
        public delegate void DeviceEventNewMessage(object sender, DeviceEventArgsMessage e); // для посылки управляющей программе сообщений о действиях

        /// <summary>
        /// Событие при успешном подключении к контроллеру
        /// </summary>
        public static event DeviceEventConnect WasConnected;
        /// <summary>
        /// Событие при отключении от контроллера, или разрыве связи с контроллером
        /// </summary>
        public static event DeviceEventDisconnect WasDisconnected;
        /// <summary>
        /// Получены новые данные от контроллера
        /// </summary>
        public static event DeviceEventNewData NewDataFromController;
        /// <summary>
        /// Посылка строки описания (для ведения логов)
        /// </summary>
        public static event DeviceEventNewMessage Message;

        #endregion
        
        #region внутренние параметры

        /// <summary>
        /// Наличие связи с контроллером
        /// </summary>
        private static bool _connected;

        /// <summary>
        /// Поток для получения, посылки данных в контроллер
        /// </summary>
        private static BackgroundWorker _theads;

        private static UsbDevice _myUsbDevice;
        private static ErrorCode _ec;
        private static UsbEndpointReader _usbReader;
        private static UsbEndpointWriter _usbWriter;

        #endregion

        #region Свойства для доступа извне к переменным

        /// <summary>
        /// Возвращает информацию о наличии связи
        /// </summary>
        public static bool Connected
        {
            get
            {
                return _connected;
            }
        }

        /// <summary>
        /// Скорость движения шпинделя
        /// </summary>
        public static int ShpindelMoveSpeed
        {
            get
            {
                return deviceInfo.shpindel_MoveSpeed;
            }
        }

        /// <summary>
        /// Номер выполняемой инструкции
        /// </summary>
        public static int NumberComleatedInstructions
        {
            get
            {
                return deviceInfo.NuberCompleatedInstruction;
            }
        }

        /// <summary>
        /// Свойство включен ли шпиндель
        /// </summary>
        public static bool SpindelOn
        {
            get { return deviceInfo.shpindel_Enable; }
        }

        /// <summary>
        /// Свойство активированна ли аварийная остановка
        /// </summary>
        public static bool EstopOn
        {
            get { return deviceInfo.Estop; }
        }

        /// <summary>
        /// Проверка наличия связи, и незанятости контроллера
        /// </summary>
        /// <returns>булево, возможно ли посылать контроллеру задачи</returns>
        public static bool TestAllowActions()
        {
            if (!Connected)
            {
                //StringError = @"Отсутствует связь с контроллером!";
                return false;
            }

            return true;
        }


        /// <summary>
        /// Размер свободного буфера
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public static int AvailableBufferSize
        {
            get
            {
                return deviceInfo.FreebuffSize;
            }
        }

        #endregion

        #region Поток выполнения задания

        /// <summary>
        /// Парсит полученные данные с контроллера
        /// </summary>
        /// <param name="readBuffer"></param>
        private static void ParseInfo(IList<byte> readBuffer)
        {

            int ttm = (int) (((readBuffer[22]*65536) + (readBuffer[21]*256) + (readBuffer[20]))/2.1);

            if (ttm > 5000) return;

            //TODO: иногда в МК2 бывает глюк, поэтому защитимся от него, костылем
            //if (readBuffer[10] == 0x58 && readBuffer[11] == 0x02 && readBuffer[22] == 0x20 && readBuffer[23] == 0x02) return;

            deviceInfo.FreebuffSize = readBuffer[1];


            deviceInfo.shpindel_MoveSpeed = 0; 

            if (Setting.DeviceModel == DeviceModel.MK1)
            {
                deviceInfo.shpindel_MoveSpeed = (int)(((readBuffer[22] * 65536) + (readBuffer[21] * 256) + (readBuffer[20])) / 2.1);
            }

            if (Setting.DeviceModel == DeviceModel.MK2)
            {
                deviceInfo.shpindel_MoveSpeed = (int)(((readBuffer[22] * 65536) + (readBuffer[21] * 256) + (readBuffer[20])) / 1.341);
            }


             



            deviceInfo.AxesX_PositionPulse = (readBuffer[27] * 16777216) + (readBuffer[26] * 65536) + (readBuffer[25] * 256) + (readBuffer[24]);
            deviceInfo.AxesY_PositionPulse = (readBuffer[31] * 16777216) + (readBuffer[30] * 65536) + (readBuffer[29] * 256) + (readBuffer[28]);
            deviceInfo.AxesZ_PositionPulse = (readBuffer[35] * 16777216) + (readBuffer[34] * 65536) + (readBuffer[33] * 256) + (readBuffer[32]);

            deviceInfo.AxesX_LimitMax = (readBuffer[15] & (1 << 0)) != 0;
            deviceInfo.AxesX_LimitMin = (readBuffer[15] & (1 << 1)) != 0;
            deviceInfo.AxesY_LimitMax = (readBuffer[15] & (1 << 2)) != 0;
            deviceInfo.AxesY_LimitMin = (readBuffer[15] & (1 << 3)) != 0;
            deviceInfo.AxesZ_LimitMax = (readBuffer[15] & (1 << 4)) != 0;
            deviceInfo.AxesZ_LimitMin = (readBuffer[15] & (1 << 5)) != 0;

            deviceInfo.NuberCompleatedInstruction = readBuffer[9] * 16777216 + (readBuffer[8] * 65536) + (readBuffer[7] * 256) + (readBuffer[6]);

            SuperByte bb = new SuperByte(readBuffer[19]);

            deviceInfo.shpindel_Enable = bb.Bit0;

            SuperByte bb2 = new SuperByte(readBuffer[14]);
            deviceInfo.Estop = bb2.Bit7;
        }

        private static void AddMessage(string ss)
        {
            if (Message != null) Message(null, new DeviceEventArgsMessage(ss));
        }

        private static bool CompareArray(byte[] arr1, byte[] arr2)
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
        private static void TheadsStart(object sender, DoWorkEventArgs e)
        {
            AddMessage("Запуск потока, работы с контроллером");

            if (Setting.DeviceModel != DeviceModel.Emulator)
            {
                //vid 2121 pid 2130 в десятичной системе будет как 8481 и 8496 соответственно
                UsbDeviceFinder myUsbFinder = new UsbDeviceFinder(8481, 8496);

                // Попытаемся установить связь
                _myUsbDevice = UsbDevice.OpenUsbDevice(myUsbFinder);

                if (_myUsbDevice == null)
                {

                    string StringError = "Не найден подключенный контроллер.";
                    _connected = false;

                    AddMessage(StringError);

                    //запустим событие о разрыве связи
                    if (WasDisconnected != null) WasDisconnected(null, new DeviceEventArgsMessage(StringError));

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

                AddMessage("Подключение к контроллеру, успешно");
            }
            else
            {
                AddMessage("...Запущен РЕЖИМ симуляции...");
            }

            _connected = true;

            AddMessage("Связь с контроллером установлена");

            if (WasConnected != null) WasConnected(null);

            // Для отслеживания изменений
            byte[] oldInfoFromController = new byte[64];

            while (_connected)
            {
                // 1. Получим данные если есть
                byte[] readBuffer = new byte[64];
                int bytesRead = 0;

                if (Setting.DeviceModel != DeviceModel.Emulator)
                {
                    _ec = _usbReader.Read(readBuffer, 2000, out bytesRead); 

                     if (_ec != ErrorCode.None)
                    {
                        _connected = false;
                        if (WasDisconnected != null) WasDisconnected(null, new DeviceEventArgsMessage(@"Ошибка получения данных с контроллера, связь разорвана!"));
                        
                        return;
                    }
                }
                else
                {
                    //TODO: добавить регенерирование данных виртуальным контроллером
                }

                if (bytesRead == 0 || readBuffer[0] != 0x01) continue; //пока получаем пакеты только с кодом 0х01 

                if (CompareArray(oldInfoFromController, readBuffer)) continue; //если данные от контроллера не изменились, то дальше нет смысла...

                deviceInfo.rawData = readBuffer;

                ParseInfo(readBuffer);
                oldInfoFromController = readBuffer;

                if (NewDataFromController != null) NewDataFromController(null);
            }

            if (WasDisconnected != null) WasDisconnected(null, new DeviceEventArgsMessage("")); //событие завершения работы

            if (Setting.DeviceModel != DeviceModel.Emulator)
            {
                 //завершение работы
                UsbDevice.Exit();
            }

            AddMessage("Завершение потока работы с контроллером");
        }

        /// <summary>
        /// Установка связи с контроллером
        /// </summary>
        public static void Connect()
        {
            if (Connected)
            {
                AddMessage("Соединение уже установлено!");
                return;
            }

            if (_theads != null)
            {
                if (_theads.IsBusy)
                {
                    AddMessage("Повторное подключение невозможно, пока текущее не будет прервано!");
                    return;
                } 
            }

            _connected = false;
            //Создаем поток, и подключаем к нему процедуру
            _theads = new BackgroundWorker();
            _theads.DoWork += TheadsStart;


            //Запустим поток
            _theads.RunWorkerAsync();
        }

        /// <summary>
        /// Отключение от контроллера
        /// </summary>
        public static void Disconnect()
        {
            AddMessage("Прекращение связи с контроллером!");
            _connected = false;
        }

        #endregion

        #region Послания данных в контроллер

        /// <summary>
        /// Посылка в контроллер бинарных данных
        /// </summary>
        /// <param name="data">Набор данных</param>
        /// <param name="checkBuffSize">Проверять ли размер доступного буффера контроллера</param>
        public static void SendBinaryData(byte[] data, bool checkBuffSize = true)
        {
            if (checkBuffSize && (deviceInfo.FreebuffSize < 2))
            {
                //тут нужно зависнуть пока буфер не освободиться

                //TODO: перед выполнением проверять буфер на занятость....

            }

            // ReSharper disable once SuggestVarOrType_BuiltInTypes
            // ReSharper disable once RedundantAssignment
            int bytesWritten = 64;

            if (Setting.DeviceModel != DeviceModel.Emulator)
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
        public static void Spindel_ON()
        {
            SendBinaryData(BinaryData.pack_B5(true));
        }

        /// <summary>
        /// Выключение шпинделя
        /// </summary>
        public static void Spindel_OFF()
        {
            SendBinaryData(BinaryData.pack_B5(false));
        }

        /// <summary>
        /// Посылка аварийной остановки
        /// </summary>
        public static void EnergyStop()
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
        public static void StartManualMove(string x, string y, string z, int speed)
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
            SendBinaryData(BinaryData.pack_BE(axesDirection.ValueByte, speed,x,y,z));
            //Task_Start();
        }

        public static void StopManualMove()
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
        public static void DeviceNewPosition(int x, int y, int z)
        {
            if (!TestAllowActions()) return;

            SendBinaryData(BinaryData.pack_C8(x, y, z,0));
        }

        /// <summary>
        /// Установка в контроллер, нового положения по осям в ммилиметрах
        /// </summary>
        /// <param name="x">в миллиметрах</param>
        /// <param name="y">в миллиметрах</param>
        /// <param name="z">в миллиметрах</param>
        // ReSharper disable once UnusedMember.Global
        public static void DeviceNewPosition(decimal x, decimal y, decimal z)
        {
            if (!TestAllowActions()) return;

            SendBinaryData(BinaryData.pack_C8(deviceInfo.CalcPosPulse("X", x), deviceInfo.CalcPosPulse("Y", y), deviceInfo.CalcPosPulse("Z", z),0));
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

    public static class deviceInfo
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
        /// <summary>
        /// Текущее положение в импульсах
        /// </summary>
        public static int AxesA_PositionPulse = 0;

        //public static int AxesX_PulsePerMm = 400;
        //public static int AxesY_PulsePerMm = 400;
        //public static int AxesZ_PulsePerMm = 400;

        //срабатывание сенсора
        public static bool AxesX_LimitMax = false;
        public static bool AxesX_LimitMin = false;
        public static bool AxesY_LimitMax = false;
        public static bool AxesY_LimitMin = false;
        public static bool AxesZ_LimitMax = false;
        public static bool AxesZ_LimitMin = false;
        public static bool AxesA_LimitMax = false;
        public static bool AxesA_LimitMin = false;


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
                return (decimal)AxesX_PositionPulse / Setting.PulseX;
            }
        }

        public static decimal AxesY_PositionMM
        {
            get
            {
                return (decimal)AxesY_PositionPulse / Setting.PulseY;
            }
        }

        public static decimal AxesZ_PositionMM
        {
            get
            {
                return (decimal)AxesZ_PositionPulse / Setting.PulseZ;
            }
        }

        public static decimal AxesA_PositionMM
        {
            get
            {
                return (decimal)AxesA_PositionPulse / Setting.PulseA;
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
            if (axes == "X") return (int)(posMm * Setting.PulseX);
            if (axes == "Y") return (int)(posMm * Setting.PulseY);
            if (axes == "Z") return (int)(posMm * Setting.PulseZ);
            if (axes == "A") return (int)(posMm * Setting.PulseA);
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
        public static byte[] pack_C8(int x, int y, int z, int a)
        {
            int newPosX = x;
            int newPosY = y;
            int newPosZ = z;
            int newPosA = a;

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
            //сколько импульсов сделать
            buf[18] = (byte)(newPosA);
            buf[19] = (byte)(newPosA >> 8);
            buf[20] = (byte)(newPosA >> 16);
            buf[21] = (byte)(newPosA >> 24);

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
            int inewReturn = (int)(returnDistance * Setting.PulseZ);

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
        public static byte[] pack_BE(byte direction, int speed, string x = "_", string y = "_", string z = "_", string a = "_")
        {
            //TODO: переделать определения с направлениями движения

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

            if (Setting.DeviceModel == DeviceModel.MK2)
            {
                //TODO: Для МК2 немного иные посылки данных

                if (speed != 0)
                {
                    double dnewSpd = (9000 / (double)speed) * 1000;
                    inewSpd = (int)dnewSpd;
                }

                //скорость
                buf[10] = (byte)(inewSpd);
                buf[11] = (byte)(inewSpd >> 8);
                buf[12] = (byte)(inewSpd >> 16);

                if (speed == 0)
                {
                    buf[14] = 0x00;
                    buf[18] = 0x01;
                    buf[22] = 0x01;

                    //x
                    buf[26] = 0x00;
                    buf[27] = 0x00;
                    buf[28] = 0x00;
                    buf[29] = 0x00;

                    //y
                    buf[30] = 0x00;
                    buf[31] = 0x00;
                    buf[32] = 0x00;
                    buf[33] = 0x00;

                    //z
                    buf[34] = 0x00;
                    buf[35] = 0x00;
                    buf[36] = 0x00;
                    buf[37] = 0x00;

                    //a
                    buf[38] = 0x00;
                    buf[39] = 0x00;
                    buf[40] = 0x00;
                    buf[41] = 0x00;


                }
                else
                {
                    buf[14] = 0xC8; //TODO: WTF?? 
                    buf[18] = 0x14; //TODO: WTF??
                    buf[22] = 0x14; //TODO: WTF??




                    if (x == "+")
                    {
                        buf[26] = 0x40;
                        buf[27] = 0x0D;
                        buf[28] = 0x03;
                        buf[29] = 0x00;
                    }

                    if (x == "-")
                    {
                        buf[26] = 0xC0;
                        buf[27] = 0xF2;
                        buf[28] = 0xFC;
                        buf[29] = 0xFF;
                    }

                    if (y == "+")
                    {
                        buf[30] = 0x40;
                        buf[31] = 0x0D;
                        buf[32] = 0x03;
                        buf[33] = 0x00;
                    }

                    if (y == "-")
                    {
                        buf[30] = 0xC0;
                        buf[31] = 0xF2;
                        buf[32] = 0xFC;
                        buf[33] = 0xFF;
                    }

                    if (z == "+")
                    {
                        buf[34] = 0x40;
                        buf[35] = 0x0D;
                        buf[36] = 0x03;
                        buf[37] = 0x00;
                    }

                    if (z == "-")
                    {
                        buf[34] = 0xC0;
                        buf[35] = 0xF2;
                        buf[36] = 0xFC;
                        buf[37] = 0xFF;
                    }

                    if (a == "+")
                    {
                        buf[38] = 0x40;
                        buf[39] = 0x0D;
                        buf[40] = 0x03;
                        buf[41] = 0x00;
                    }

                    if (a == "-")
                    {
                        buf[38] = 0xC0;
                        buf[39] = 0xF2;
                        buf[40] = 0xFC;
                        buf[41] = 0xFF;
                    }



                }
            }

            


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
        public static byte[] pack_BF(int speedLimitX, int speedLimitY, int speedLimitZ, int speedLimitA)
        {
            byte[] buf = new byte[64];

            buf[0] = 0xbf;

            buf[4] = 0x00;

            double koef = 4500;

            if (Setting.DeviceModel == DeviceModel.MK1)
            {
                buf[4] = 0x80; //TODO: непонятный байт
                koef = 3600;
            }

            if (Setting.DeviceModel == DeviceModel.MK2)
            {
                buf[4] = 0x00; //TODO: непонятный байт
                koef = 4500;
            }


            double dnewSpdX = (koef / (double)speedLimitX) * 1000;
            int inewSpdX = (int)dnewSpdX;

            double dnewSpdY = (koef / (double)speedLimitY) * 1000;
            int inewSpdY = (int)dnewSpdY;

            double dnewSpdZ = (koef / (double)speedLimitZ) * 1000;
            int inewSpdZ = (int)dnewSpdZ;

            double dnewSpdA = (koef / (double)speedLimitA) * 1000;
            int inewSpdA = (int)dnewSpdA;

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

            buf[19] = (byte)(inewSpdA);
            buf[20] = (byte)(inewSpdA >> 8);
            buf[21] = (byte)(inewSpdA >> 16);
            buf[22] = (byte)(inewSpdA >> 24);

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
        /// <param name="AngleVectors">Угол, на который измениться направление движения</param>
        /// <param name="Distance">Длина данного отрезка в мм</param>
        /// <returns>набор данных для посылки</returns>
        public static byte[] pack_CA(int _posX, int _posY, int _posZ, int _posA, int _speed, int _NumberInstruction, int AngleVectors, decimal Distance, int _valuePause = 0x39)
        {
            int newPosX = _posX;
            int newPosY = _posY;
            int newPosZ = _posZ;
            int newPosA = _posA;
            int newInst = _NumberInstruction;

            byte[] buf = new byte[64];

            buf[0] = 0xCA;
            //запись номера инструкции
            buf[1] = (byte)(newInst);
            buf[2] = (byte)(newInst >> 8);
            buf[3] = (byte)(newInst >> 16);
            buf[4] = (byte)(newInst >> 24);

            // Зная угол между 2-мя отрезками, вычислим необходимую паузу перехода, от отрезка к отрезку
            //int deltaAngle = 180 - AngleVectors;

            //buf[5] = 0x01;

            //if (deltaAngle > 45) buf[5] = 0x39;


            //if (deltaAngle <= 25) 
            //buf[5] = 0x03;
            buf[5] = (byte)_valuePause;


            if (Distance >0 && Distance < 5) buf[5] = 0x03;

            //if (deltaAngle < 15) buf[5] = 0x10;


            //if (deltaAngle < 10) buf[5] = 0x02;


            //if (deltaAngle < 3) buf[5] = 0x01;



            //buf[5] = (byte)deltaAngle;

            //if (buf[5] == 0x00) buf[5] = 0x01;

            //if (buf[5] > 0x39) buf[5] = 0x39;

            //TODO: старый алгоритм для удаления
            //// 0х01 нет паузы, 0х39 есть пауза (при маленькой паузе, и большой скорости происходит срыв...)
            //if (AngleVectors > 170 && AngleVectors < 190)
            //{
            //    buf[5] = 0x01;
            //}
            //else
            //{
            //    buf[5] = 0x39;
            //}

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

            //сколько импульсов сделать
            buf[18] = (byte)(newPosA);
            buf[19] = (byte)(newPosA >> 8);
            buf[20] = (byte)(newPosA >> 16);
            buf[21] = (byte)(newPosA >> 24);



            double koef = 4500;

            if (Setting.DeviceModel == DeviceModel.MK1)
            {
                buf[4] = 0x80; //TODO: непонятный байт
                koef = 3600;
            }

            if (Setting.DeviceModel == DeviceModel.MK2)
            {
                buf[4] = 0x00; //TODO: непонятный байт
                koef = 4500;
            }


            //TODO: если дистанция = 0 то используем скорость....

            //TODO: Учесть длину траектории, если она короткая то нельзя ставить большую скорость, т.к. легко можно сорвать вращение 
            //int SpeedToSend = _speed;

            int SpeedToSend = 2328; 
            //старый код
            if (_speed != 0)
            {
                SpeedToSend = _speed;
            }

            //TODO: добавить ограничение скорости от дистанции!!!
            //при большой дистанции используем скорость заданную G-кодом
            //if (Distance > 50) SpeedToSend = _speed;
            //else
            //{
            //    //иначе замедлим скорость
            //    /* растояние 50мм скорость = 500мм/минуту
            //     * растояние 30мм скорость = 300мм/минуту
            //     * растояние 10мм скорость = 100мм/минуту
            //     * и т.д....
            //     */
            //    //SpeedToSend = Distance * 10;
            //    SpeedToSend = 500;
            //    // не всегда имеем дистанцию 
            //    //if (Distance == 0) SpeedToSend = 200;
            //}

            //////if (Distance < 10) SpeedToSend = 400;

            //////if (_speed == 0) SpeedToSend = 200;



            int iSpeed = (int)(koef / SpeedToSend) * 1000;
            //скорость ось х
            buf[43] = (byte)(iSpeed);
            buf[44] = (byte)(iSpeed >> 8);
            buf[45] = (byte)(iSpeed >> 16);
            
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
        ///// <summary>
        ///// Набор готовых инструкций для станка 
        ///// </summary>
        //public static List<GKOD_ready> GKODready = new List<GKOD_ready>();

        /// <summary>
        /// Набор сырых инструкций для станка 
        /// </summary>
        //public static List<GKOD_raw> GKODraw = new List<GKOD_raw>();

        /// <summary>
        /// Набор точек матрицы, получаемой при сканировании поверхности
        /// </summary>
        //public static List<matrixYline> Matrix = new List<matrixYline>(); 


        ///// <summary>
        ///// Очистка данных
        ///// </summary>
        //public static void Clear()
        //{
        //    //GKODready.Clear();
        //    //GKODraw.Clear();
        //}




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






    #endregion

    public class decPoint
    {

        public decimal X;       // координата в мм
        public decimal Y;       // координата в мм
        public decimal Z;       // координата в мм
        public decimal A;       // координата в мм

        public decPoint(decimal _x, decimal _y, decimal _z, decimal _a)
        {
            X = _x;
            Y = _y;
            Z = _z;
            A = _a;
        }
    }

    public class dobPoint
    {

        public double X;       // координата в мм
        public double Y;       // координата в мм
        public double Z;       // координата в мм
        public double A;       // координата в мм

        public dobPoint(double _x, double _y, double _z, double _a)
        {
            X = _x;
            Y = _y;
            Z = _z;
            A = _a;
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
        public static dobPoint GetZ(dobPoint p1, dobPoint p2, dobPoint p3, dobPoint p4, dobPoint p5)
        {
            dobPoint p12 = CalcPX(p1, p2, p5);
            dobPoint p34 = CalcPX(p3, p4, p5);

            dobPoint p1234 = CalcPY(p12, p34, p5);

            return p1234;
        }

        //нахождение высоты Z точки p0, лежащей на прямой которая паралельна оси X
        public static dobPoint CalcPX(dobPoint p1, dobPoint p2, dobPoint p0)
        {
            dobPoint ReturnPoint = new dobPoint(p0.X, p0.Y, p0.Z,0);

            ReturnPoint.Z = p1.Z + (((p1.Z - p2.Z) / (p1.X - p2.X)) * (p0.X - p1.X));

            //TODO: учесть на будущее что точка 1 и 2 могут лежать не на одной паралльной линии оси Х
            ReturnPoint.Y = p1.Y;

            return ReturnPoint;
        }



        //TODO: деление на ноль
        //нахождение высоты Z точки p0, лежащей на прямой между точками p3 p4  (прямая паралельна оси Y)
        public static dobPoint CalcPY(dobPoint p1, dobPoint p2, dobPoint p0)
        {
            dobPoint ReturnPoint = new dobPoint(p0.X, p0.Y, p0.Z,0);

            ReturnPoint.Z = p1.Z + (((p1.Z - p2.Z) / (p1.Y - p2.Y)) * (p0.Y - p1.Y));

            return ReturnPoint;
        }

    }
}