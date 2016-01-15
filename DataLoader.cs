/*
 * Данный класс предназначачен для парсинга данных, в G-kod
 * И их хранения
 */


using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CNC_Assist
{
    /// <summary>
    /// Класс осуществляет асинхронную загрузку данных, парсинг для 3D-вуализации
    /// </summary>
    static class DataLoader
    {
        /// <summary>
        /// Экстренная необходимость остановки работы потока в данном классе
        /// </summary>
        private static volatile bool _shouldStop = false;

        /// <summary>
        /// Набор данных
        /// </summary>
        public static volatile List<DataRow> DataRows = new List<DataRow>(); 

        /// <summary>
        /// статус работы потока в данном классе
        /// </summary>
        public static volatile eDataSetStatus status = eDataSetStatus.none;

        public static volatile string descryption = "";

        /// <summary>
        /// При выполнении какой либо операции показывать процент выполнения
        /// </summary>
        public static volatile int percentCompleated = 0;


        /// <summary>
        /// Параметр указывающий о дате начала загрузки G-кода
        /// Если он меняется (а происходит это до начала загрузки из файла), то остальные
        /// Модули программы перестают получать данные из DataRows до тех пор пока "status" не станет равным "eDataSetStatus.none"
        /// TODO: check!
        /// </summary>
        public static DateTime dateGetNewDataCode = DateTime.Now;


        /// <summary>
        /// Перечисление описывающее статус выполнения заданий в данном классе
        /// </summary>
        public enum eDataSetStatus
        {
            none = 0,
            loadingFromFile = 1,
            parsingData = 2
        };

        // Применяются для отображения в 3D выделенных строк из общего списка
        public static int SelectedRowStart = -1;
        public static int SelectedRowStop = -1;

        public static bool AbsolutlePosParsing = true; //применяем абсолютные координаты при парсинге

        public static ResultCommand ReadFromFile(string fileName)
        {
            DataRows.Clear(); 

            //Data_string.Clear();

            if (status == eDataSetStatus.loadingFromFile)
            {
                return new ResultCommand(false,@"Нельзя запустить загрузку нового файла, пока не завершилась текущая!");
            }

            Thread workerThread = new Thread(DoWork);
            workerThread.Start(fileName);

            return new ResultCommand(true, @"Запущена загрузка файла " + fileName);
        }

        public static ResultCommand ReadFromBuffer()
        {
            DataRows.Clear();

            //Data_string.Clear();

            if (status == eDataSetStatus.loadingFromFile)
            {
                return new ResultCommand(false, @"Нельзя запустить загрузку из буффера, пока не завершилась текущая!");
            }

            Thread workerThread = new Thread(DoWork1);
            workerThread.Start(Clipboard.GetText());

            return new ResultCommand(true, @"Запущена загрузка из буффера.");
        }

        /// <summary>
        /// вызов остановки
        /// </summary>
        public static void RequestStop()
        {
            _shouldStop = true;
        }

        /// <summary>
        /// поток загрузки данных из файла
        /// </summary>
        private static void DoWork(object data)
        {
            status = eDataSetStatus.loadingFromFile;
            descryption = @"Загрузка данных из файла";
            percentCompleated = 0;
            int countLines = 0;
            int currentLine = 0;

            // в начале узнаем сколько строк
            using (StreamReader r = new StreamReader((string)data))
            {
                while ((r.ReadLine()) != null)
                {
                    countLines++;
                }
            }
            // а теперь из файла прочитаем
            using (StreamReader srReader = File.OpenText((string)data))
            {
                string line;
                while ((line = srReader.ReadLine()) != null && !_shouldStop)
                {

                    // в переменной line имеем строку которую парсим
                    DataRows.Add(new DataRow(currentLine, line));
                    //Data_string.Add(new stringData(indx++,line));

                    percentCompleated = (int)(((decimal)100 / countLines) * currentLine);
                    currentLine++;
                }
            }

            status = eDataSetStatus.parsingData;
            descryption = @"Парсинг данных";
            percentCompleated = 0;
            currentLine = 0;

            DataRow tmpDataRowRecord = new DataRow(0, "");

            while ((currentLine < countLines) && !_shouldStop)
            {
                percentCompleated = (int)(((decimal)100 / countLines) * currentLine);

                DataRow curDataRow = DataRows[currentLine];
                FillStructure(tmpDataRowRecord, ref curDataRow);

                //скопируем, ля возможности дальше знать предыдущие параметры
                tmpDataRowRecord = curDataRow;

                currentLine++;
            }

            status = eDataSetStatus.none;
            dateGetNewDataCode = DateTime.Now;
        }

        /// <summary>
        /// поток загрузки данных из буффера
        /// </summary>
        private static void DoWork1(object data)
        {
            status = eDataSetStatus.loadingFromFile;
            descryption = @"Загрузка данных из файла";
            percentCompleated = 0;
            int countLines = 0;
            int currentLine = 0;

            string tmp = (string) data;
            tmp = tmp.Replace('\r', ' ');

            string[] Gkode = tmp.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries); //"\r\n"

            countLines = Gkode.Length;

            foreach (string line in Gkode)
            {
                DataRows.Add(new DataRow(currentLine, line));

                percentCompleated = (int)(((decimal)100 / countLines) * currentLine);
                currentLine++;
            }



            status = eDataSetStatus.parsingData;
            descryption = @"Парсинг данных";
            percentCompleated = 0;
            currentLine = 0;

            DataRow tmpDataRowRecord = new DataRow(0, "");

            while ((currentLine < countLines) && !_shouldStop)
            {
                percentCompleated = (int)(((decimal)100 / countLines) * currentLine);

                DataRow curDataRow = DataRows[currentLine];
                FillStructure(tmpDataRowRecord, ref curDataRow);

                //скопируем, ля возможности дальше знать предыдущие параметры
                tmpDataRowRecord = curDataRow;

                currentLine++;
            }

            status = eDataSetStatus.none;
            dateGetNewDataCode = DateTime.Now;
        }





        public static void FillStructure(DataRow lastDataRow, ref DataRow nextDataRow)
        {
            // Установим большинство параметров, из предыдущей строки,
            // и при дальнейшем парсинге, изменим только те поля которые встретятся в анализируемой строке
            nextDataRow.duplicate(lastDataRow);


            //получим символ разделения дробной и целой части.
            string symbSeparatorDec = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

            char csourse = '.';
            char cdestination = ',';

            if (symbSeparatorDec == ".")
            {
                csourse = ',';
                cdestination = '.';
            }

            nextDataRow.DataString = nextDataRow.DataString.ToUpper();

            // 1) распарсим строку на отдельные строки с параметрами
            List<string> lcmd = ParseStringToSubString(nextDataRow.DataString);

            if (lcmd.Count == 0) return;

            //необходимо для получения следующей команды, т.к. команда G04 P500 будет раздельно
            int index = 0;
            foreach (string code in lcmd)
            {
                if (code == "M3")
                {
                    nextDataRow.Machine.SpindelON = true;
                }

                if (code == "M5")
                {
                    nextDataRow.Machine.SpindelON = false;
                }

                if (code == "M7")
                {
                    nextDataRow.Machine.Chanel2ON = true;
                }

                if (code == "M8")
                {
                    nextDataRow.Machine.Chanel3ON = true;
                }

                if (code == "M9")
                {
                    nextDataRow.Machine.Chanel2ON = false;
                    nextDataRow.Machine.Chanel3ON = false;
                }


                if (code == "G0") //холостое движение
                {
                    nextDataRow.Machine.NumGkode = 0;
                }

                if (code == "G1") //рабочее движение
                {
                    nextDataRow.Machine.NumGkode = 1;
                    nextDataRow.Machine.WithoutPause = false;
                }

                if (code == "G1.1") //рабочее движение без дальнейшей остановки в конце отрезка
                {
                    nextDataRow.Machine.NumGkode = 1;
                    nextDataRow.Machine.WithoutPause = true;
                }

                if (code == "G2") //TODO: не реализовано
                {
                    nextDataRow.Machine.NumGkode = 2;
                }

                if (code == "G3") //TODO: не реализовано
                {
                    nextDataRow.Machine.NumGkode = 3;
                }


                if (code == "G4") //пауза
                {
                    try
                    {
                        //следующий параметр должен быть длительностью типа P500
                        string strNext = lcmd[index + 1].ToUpper();
                        if (strNext.Substring(0,1) == "P")
                        {
                            int times;
                            int.TryParse(strNext.Substring(1), out times);
                            nextDataRow.Extra.NeedPause = true;
                            nextDataRow.Extra.timeoutMsec = times;
                        }
                    }
                    catch (Exception)
                    {

                        nextDataRow.Extra.NeedPause = false;
                    }
                }

                #region G92 - несколько кодов отвечающие за смещение координат

                if (code == "G92")
                {
                    //TODO: пока применим простое смещение с переносом в точку ноль
                    Controller.CorrectionPos.useCorrection = true;
                    Controller.CorrectionPos.deltaX = Controller.INFO.AxesX_PositionMM;
                    Controller.CorrectionPos.deltaY = Controller.INFO.AxesY_PositionMM;
                    Controller.CorrectionPos.deltaZ = Controller.INFO.AxesZ_PositionMM;
                    Controller.CorrectionPos.deltaA = Controller.INFO.AxesA_PositionMM;
                }

                if (code == "G92.1")
                {
                    Controller.CorrectionPos.useCorrection = false;
                    Controller.CorrectionPos.deltaX = 0;
                    Controller.CorrectionPos.deltaY = 0;
                    Controller.CorrectionPos.deltaZ = 0;
                    Controller.CorrectionPos.deltaA = 0;
                }


                if (code == "G92.2")
                {
                    Controller.CorrectionPos.useCorrection = false;
                }


                if (code == "G92.3")
                {
                    Controller.CorrectionPos.useCorrection = true;
                }

                #endregion


                if (code.Substring(0, 1) == "F") //скорость движения, извлечем
                {
                    string svalue = code.Substring(1).Replace(csourse, cdestination);
                    int spd;
                    int.TryParse(svalue, out spd);

                    nextDataRow.Machine.SpeedMaсhine = spd;
                }

                if (code.Substring(0, 1) == "N") //номер кадра
                {
                    string svalue = code.Substring(1).Replace(csourse, cdestination); ;
                    int numKadr = 0;
                    int.TryParse(svalue, out numKadr);

                    nextDataRow.numberKadr = numKadr;
                }

                if (code.Substring(0, 1) == "S") //скорость движения, извлечем
                {
                    string svalue = code.Substring(1).Replace(csourse, cdestination); ;
                    int spd = 0;
                    int.TryParse(svalue, out spd);
                    nextDataRow.Machine.SpeedSpindel = spd;
                }


                if (code.Substring(0, 1) == "X") //координата
                {
                    string svalue = code.Substring(1).Replace(csourse, cdestination); ;
                    decimal pos = 0;
                    decimal.TryParse(svalue, out pos);

                    if (AbsolutlePosParsing) nextDataRow.POS.X = pos;
                    else nextDataRow.POS.X += pos;
                }


                if (code.Substring(0, 1) == "Y") //координата
                {
                    string svalue = code.Substring(1).Replace(csourse, cdestination); ;
                    decimal pos = 0;
                    decimal.TryParse(svalue, out pos);

                    if (AbsolutlePosParsing) nextDataRow.POS.Y = pos;
                    else nextDataRow.POS.Y += pos;
                }


                if (code.Substring(0, 1) == "Z") //координата
                {
                    string svalue = code.Substring(1).Replace(csourse, cdestination); ;
                    decimal pos = 0;
                    decimal.TryParse(svalue, out pos);

                    if (AbsolutlePosParsing) nextDataRow.POS.Z = pos;
                    else nextDataRow.POS.Z += pos;
                }


                if (code.Substring(0, 1) == "A") //координата
                {
                    string svalue = code.Substring(1);
                    decimal pos = 0;
                    decimal.TryParse(svalue, out pos);

                    if (AbsolutlePosParsing) nextDataRow.POS.A = pos;
                    else nextDataRow.POS.A += pos;
                }

                if (code == "G90")
                {
                    AbsolutlePosParsing = true; //применяем абсолютные координаты
                }

                if (code == "G91")
                {
                    AbsolutlePosParsing = false;//применяем относительные координаты
                }

                index++;
            }//foreach (string CODE in lcmd)
           







        }









        /// <summary>
        /// Разбивка строки на отдельные параметры
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static List<string> ParseStringToSubString(string value)
        {

            List<string> lcmd = new List<string>();

            if (value.Trim() == "") return lcmd;

            // если строка начинается со скобки, то эту строку не анализируем, т.к. это комментарий!!!
            if (value.Substring(0, 1) == "(")
            {
                lcmd.Add(value);
                return lcmd;
            }

            if (value.Substring(0, 1) == "%") //тоже пропускаем эту сторку
            {
                lcmd.Add(value);
                return lcmd;
            }

            int inx = 0;

            bool collectCommand = false;

            foreach (char symb in value)
            {
                if (symb > 0x40 && symb < 0x5B)  //символы от A до Z
                {
                    if (collectCommand)
                    {
                        inx++;
                    }

                    collectCommand = true;
                    lcmd.Add("");
                }

                if (collectCommand && symb != ' ') lcmd[inx] += symb.ToString();
            }

            return lcmd;
        }




    }




    #region Классы для хранения всей структуры загруженных данных

    /// <summary>
    /// Хранение координат
    /// </summary>
    class Position
    {
        /// <summary>
        /// координата в мм
        /// </summary>
        public decimal X;
        /// <summary>
        /// координата в мм
        /// </summary>
        public decimal Y;
        /// <summary>
        /// координата в мм
        /// </summary>
        public decimal Z;         
        /// <summary>
        /// координата в мм
        /// </summary>
        public decimal A;

        /// <summary>
        /// Конструктор расположения
        /// </summary>
        /// <param name="_X">координата X</param>
        /// <param name="_Y">координата Y</param>
        /// <param name="_Z">координата Z</param>
        /// <param name="_A">координата A</param>
        public Position(decimal _X,decimal _Y,decimal _Z,decimal _A)
        {
            X = _X;
            Y = _Y;
            Z = _Z;
            A = _A;
        }

        /// <summary>
        /// Конструктор расположения
        /// </summary>
        public Position()
        {
            X = (decimal)0.00001;
            Y = (decimal)0.00001;
            Z = (decimal)0.00001;
            A = (decimal)0.00001;
        }
    }

    /// <summary>
    /// Хранение параметров станка
    /// </summary>
    class PropMaсhine
    {
        /// <summary>
        /// Номер команды скорости G0 G1 G2 G3, в переменной храним число 0,1,2, или 3
        /// </summary>
        public int NumGkode;
        /// <summary>
        /// Скорость движения шпинделя
        /// </summary>
        public int SpeedMaсhine;
        /// <summary>
        /// Включен ли шпиндель
        /// </summary>
        public bool SpindelON;
        /// <summary>
        /// Скорость вращения шпинделя/PWM
        /// </summary>
        public int SpeedSpindel;

        /// <summary>
        /// Включен ли канал 2
        /// </summary>
        public bool Chanel2ON;

        /// <summary>
        /// Включен ли канал 3
        /// </summary>
        public bool Chanel3ON;

        /// <summary>
        /// Для planet-cnc отключать паузу командой G1.1
        /// WithoutPause = true при G1.1
        /// WithoutPause = false при G1
        /// </summary>
        public bool WithoutPause;

        /// <summary>
        /// Установка параметров станка
        /// </summary>
        /// <param name="_NumGkode">Число указывающее на применяемый код 0 -> G0, 1 -> G1, 2 -> G2, 3 -> G3</param>
        /// <param name="_SpeedMaсhine">Скорость движения шпинделя</param>
        /// <param name="_SpindelON">Влючен ли шпиндель</param>
        /// <param name="_SpeedSpindel">Скорость вращения шпинделя, или значение PWM</param>
        public PropMaсhine(int _NumGkode, int _SpeedMaсhine, bool _SpindelON, int _SpeedSpindel, bool _Chanel2ON, bool _Chanel3ON, bool _WithoutPause)
        {
            NumGkode = _NumGkode;
            SpeedMaсhine = _SpeedMaсhine;
            SpindelON = _SpindelON;
            SpeedSpindel = _SpeedSpindel;
            Chanel2ON = _Chanel2ON;
            Chanel3ON = _Chanel3ON;
            WithoutPause = _WithoutPause;
        }

        /// <summary>
        /// Установка параметров станка
        /// </summary>
        public PropMaсhine()
        {
            NumGkode = 0;
            SpeedMaсhine = 100;
            SpindelON = false;
            SpeedSpindel = 0;
            WithoutPause = false;
        }

    }


    /// <summary>
    /// Параметры применяемого инструмента
    /// </summary>
    class ToolOptions
    {
        /// <summary>
        /// Необходимость смены инструмента
        /// </summary>
        public bool NeedChange;
        /// <summary>
        /// Номер инструмента
        /// </summary>
        public int NumberTools;
        /// <summary>
        /// Диаметр инструмента
        /// </summary>
        public decimal DiametrTools;
        /// <summary>
        /// Конструктор информации о инструменте
        /// </summary>
        /// <param name="_NeedChange">необходимость смены</param>
        /// <param name="_NumberTools">номер инструмента</param>
        /// <param name="_DiametrTools">диаметр инструмента</param>
        public ToolOptions(bool _NeedChange, int _NumberTools, decimal _DiametrTools)
        {
            NeedChange = _NeedChange;
            NumberTools = _NumberTools;
            DiametrTools = _DiametrTools;
        }
        /// <summary>
        /// Конструктор информации о инструменте
        /// </summary>
        public ToolOptions()
        {
            NeedChange = false;
            NumberTools = 0;
            DiametrTools = 0;
        }
    }

    /// <summary>
    /// Дополнительные параметры
    /// </summary>
    class ExtraOtions
    {
        /// <summary>
        /// Необходимость остановки
        /// </summary>
        public bool NeedPause;
        /// <summary>
        /// Длительность остановки, если равна нулю то отановка до действия пользователя
        /// </summary>
        public int timeoutMsec;
        /// <summary>
        /// Посылать ли эту команду в станок
        /// </summary>
        public bool useThisCommand;
        /// <summary>
        /// Конструктор доп параметров
        /// </summary>
        /// <param name="_NeedPause">Необходимость остановки</param>
        /// <param name="_timeoutMsec">Длительность остановки, если равна нулю то отановка до действия пользователя</param>
        /// <param name="_useThisCommand">Посылать ли эту команду в станок</param>
        public ExtraOtions(bool _NeedPause, int _timeoutMsec, bool _useThisCommand)
        {
            NeedPause = _NeedPause;
            timeoutMsec = _timeoutMsec;
            useThisCommand = _useThisCommand;
        }
        /// <summary>
        /// Конструктор доп параметров
        /// </summary>
        public ExtraOtions()
        {
            NeedPause = false;
            timeoutMsec = -1;
            useThisCommand = false;
        }
    }


    /// <summary>
    /// данный класс содержит всю необходимую информацию для выполнения на станке, полученную из 1-й строки файла
    /// </summary>
    class DataRow
    {
        /// <summary>
        /// Номер строки из файла
        /// </summary>
        public int numberRow;
        /// <summary>
        /// Номер кадра
        /// </summary>
        public int numberKadr;
        /// <summary>
        /// Вся строка из файла
        /// </summary>
        public string DataString;
        /// <summary>
        /// Координаты расположения
        /// </summary>
        public Position POS;

        /// <summary>
        /// Параметры работы станка
        /// </summary>
        public PropMaсhine Machine;
        /// <summary>
        /// Параметры применяемого инструмента
        /// </summary>
        public ToolOptions Tools;
        /// <summary>
        /// Дополнительные параметры
        /// </summary>
        public ExtraOtions Extra;

        /// <summary>
        /// Конструктор строки данных
        /// </summary>
        /// <param name="_numberRow">Номер строки из файла</param>
        /// <param name="_DataString">Вся строка из файла</param>
        /// <param name="_POS">Координаты расположения</param>
        /// <param name="_Machine">Параметры работы станка</param>
        /// <param name="_Tools">Параметры применяемого инструмента</param>
        /// <param name="_Extra">Дополнительные параметры</param>
        public DataRow(int _numberRow, int _numberKadr, string _DataString, Position _POS, PropMaсhine _Machine, ToolOptions _Tools, ExtraOtions _Extra)
        {
            numberRow = _numberRow;
            numberKadr = _numberKadr;
            DataString = _DataString;
            POS = _POS;
            Machine = _Machine;
            Tools = _Tools;
            Extra = _Extra;
        }

        /// <summary>
        /// Конструктор строки данных
        /// </summary>
        /// <param name="_numberRow">Номер строки из файла</param>
        /// <param name="_DataString">Вся строка из файла</param>
        public DataRow(int _numberRow, string _DataString)
        {
            numberRow = _numberRow;
            numberKadr = 0;
            DataString = _DataString;
            POS = new Position();
            Machine = new PropMaсhine();
            Tools = new ToolOptions();
            Extra = new ExtraOtions();
        }

        /// <summary>
        /// Копирование почти всех параметров из указанного источника
        /// </summary>
        /// <param name="_sourceRow"></param>
        public void duplicate(DataRow tmp)
        {
            POS = new Position(tmp.POS.X, tmp.POS.Y, tmp.POS.Z, tmp.POS.A);
            Machine = new PropMaсhine(tmp.Machine.NumGkode, tmp.Machine.SpeedMaсhine,tmp.Machine.SpindelON,tmp.Machine.SpeedSpindel,tmp.Machine.Chanel2ON,tmp.Machine.Chanel3ON,tmp.Machine.WithoutPause);
            Tools = new ToolOptions(tmp.Tools.NeedChange, tmp.Tools.NumberTools, tmp.Tools.DiametrTools);
            Extra = new ExtraOtions(false, 0, tmp.Extra.useThisCommand); //не нужно копировать паузу....
        }

    }


    #endregion
}




    //class stringData
    //{
    //    public int index;
    //    public string line;
    //    public int indexGcode;

    //    public stringData(int _index = 0, string _line = "")
    //    {
    //        index = _index;
    //        line = _line;
    //        indexGcode = 0;


    //    }
    //}

///// <summary>
///// Преобразование строки, в список строк, с разделением параметров
///// </summary>
///// <param name="value">Строка с командами</param>
///// <returns>Список команд в строке по раздельности</returns>
//private static List<string> parserGkodeLine(string value)
//{

//    List<string> lcmd = new List<string>();

//    if (value.Trim() == "") return lcmd;

//    // если строка начинается со скобки, то эту строку не анализируем, т.к. это комментарий!!!
//    if (value.Substring(0, 1) == "(")
//    {
//        lcmd.Add(value);
//        return lcmd;
//    }

//    if (value.Substring(0, 1) == "%") //тоже пропускаем эту сторку
//    {
//        lcmd.Add(value);
//        return lcmd;
//    }

//    int inx = 0;

//    bool collectCommand = false;

//    foreach (char symb in value)
//    {
//        if (symb > 0x40 && symb < 0x5B)  //символы от A до Z
//        {
//            if (collectCommand)
//            {
//                inx++;
//            }

//            collectCommand = true;
//            lcmd.Add("");
//        }

//        if (collectCommand && symb != ' ') lcmd[inx] += symb.ToString();
//    }

//    return lcmd;
//}

///// <summary>
///// Быстрый парсинг строки с G-кодом (только для визуальной части, проверка кие коды выполняем, а какие нет) 
///// </summary>
///// <param name="value">строка с G-кодом</param>
//public static GKOD_resultParse ParseStringCode(string value)
//{
//    GKOD_resultParse result;

//    // 1) распарсим строку
//    List<string> lcmd = parserGkodeLine(value);

//    string sGoodsCmd = "";
//    string sBadCmd = "";

//    // 2) проанализируем список команд, и разберем команды на те которые знаем и не знаем
//    for (int i = 0; i < lcmd.Count; i++)
//    {
//        string sCommd = lcmd[i].Substring(0, 1).Trim().ToUpper();
//        string sValue = lcmd[i].Substring(1).Trim().ToUpper();

//        bool good = false;

//        if (sCommd == "G")
//        {
//            //скорости движения
//            if (sValue == "0" || sValue == "00") good = true;
//            if (sValue == "1" || sValue == "01") good = true;
//            // пауза в работе
//            if (sValue == "4" || sValue == "04")
//            {
//                if ((i + 1) < lcmd.Count)
//                {
//                    //проверим что есть ещё параметр "P"
//                    if (lcmd[i + 1].Substring(0, 1).ToUpper() == "P")
//                    {
//                        sGoodsCmd += lcmd[i].Trim().ToUpper() + " " + lcmd[i + 1].Trim().ToUpper();
//                        continue;
//                    }
//                }
//            }
//        }

//        if (sCommd == "M")
//        {
//            //остановка до нажатия кнопки продолжить
//            if (sValue == "0" || sValue == "00") good = true;
//            //вкл/выкл шпинделя
//            if (sValue == "3" || sValue == "03") good = true;
//            if (sValue == "5" || sValue == "05") good = true;
//            //смена инструмента
//            if (sValue == "6" || sValue == "06")
//            {
//                if ((i + 2) < lcmd.Count)
//                {
//                    //проверим что есть ещё параметр "T" и "D"
//                    if (lcmd[i + 1].Substring(0, 1).ToUpper() == "T" && lcmd[i + 2].Substring(0, 1).ToUpper() == "D")
//                    {
//                        sGoodsCmd += lcmd[i].Trim().ToUpper() + " " + lcmd[i + 1].Trim().ToUpper() + " " + lcmd[i + 2].Trim().ToUpper();
//                        continue;
//                    }
//                }
//            }
//        }

//        if (sCommd == "X" || sCommd == "Y" || sCommd == "Z")
//        {
//            //координаты 3-х осей 
//            good = true;
//        }

//        if (good)
//        {
//            sGoodsCmd += lcmd[i] + " ";
//        }
//        else
//        {
//            sBadCmd += lcmd[i] + " ";
//        }
//    } //for (int i = 0; i < lcmd.Count; i++)


//    if (lcmd.Count == 0) sBadCmd = value;

//    result = new GKOD_resultParse(value, sGoodsCmd, sBadCmd);

//    return result;
//}

///// <summary>
///// Набор готовых инструкций для станка 
///// </summary>
//public static List<GKOD_Command> GKODS = new List<GKOD_Command>();



//GKOD_resultParse graw = ParseStringCode(Data_string[(int)currentLine].line.ToUpper());
//Data_string[(int) currentLine].indexGcode = indexGcode;

//int strindex = Data_string[(int) currentLine].index;
//currentLine++;

//if (graw.GoodStr.Trim() == "") continue;

//////    //  if (panelListGkode != null) panelListGkode.listGkodeCommand.Items.Clear();

//GKOD_Command tmpCommand = new GKOD_Command();
//tmpCommand.indexStr = strindex;
////tmpCommand.angleVectors = 0; //значение по умолчанию
////int maxIndexLen = listCode.Count.ToString().Length; //вычисление количества символов используемых для нумерации записей

//////    listBoxLog.Items.Add("Преобразование текста в спец-формат...");

//////    foreach (string valueStr in listCode)
//////    {
//List<string> lcmd = parserGkodeLine(graw.GoodStr);

//        for (int i = 0; i < lcmd.Count; i++)
//        {
//            string property = lcmd[i].Substring(0, 1).Trim().ToUpper();
//            string value = lcmd[i].Substring(1).Trim().ToUpper();

//            if (property == "" || value == "") continue; //ошибочная команда

//            if (property == "G")
//            {
//                if (value == "0" || value == "00") tmpCommand.workspeed = false;

//                if (value == "1" || value == "01") tmpCommand.workspeed = true;

//                if (value == "4" || value == "04")
//                {
//                    //нужен следующий параметр
//                    string property1 = lcmd[i + 1].Substring(0, 1).Trim().ToUpper();
//                    string value1 = lcmd[i + 1].Substring(1).Trim().ToUpper();

//                    if (property1 == "P")
//                    {
//                        tmpCommand.needPause = true;
//                        tmpCommand.timeSeconds = int.Parse(value1);
//                        i++;
//                    }
//                }
//            }


//            string symbSeparatorDec = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.ToString();
//            //string symbSeparatorGroup = CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator.ToString(); 

//            char Csourse = '.';
//            char Cdestination = ',';

//            if (symbSeparatorDec == ".")
//            {
//                Csourse = ',';
//                Cdestination = '.';
//            }

//            if (property == "X")
//            {
//                //из-за кодировок, пока так сделаю...
//                string value1 = value.Trim().Replace(Csourse, Cdestination);

//                try
//                {
//                    //если вдруг не число было....
//                    newX = decimal.Parse(value1);
//                    //tmpCommand.X = decimal.Parse(value1);
//                    //listBoxLog.Items.Add("Преобразование значения X: " + value1 + @" -> " + tmpCommand.X.ToString());
//                }
//                catch (Exception eEx)
//                {
//                    //throw;
//                    //listBoxLog.Items.Add("Ошибка парсинга числа " + value1 + " -> " + eEx.ToString());
//                }
//            }

//            if (property == "Y")
//            {
//                //из-за кодировок, пока так сделаю...
//                string value1 = value.Trim().Replace(Csourse, Cdestination);

//                try
//                {
//                    //если вдруг не число было....
//                    newY = decimal.Parse(value1);
//                    //tmpCommand.Y = decimal.Parse(value1);
//                    //listBoxLog.Items.Add("Преобразование значения Y: " + value1 + @" -> " + tmpCommand.Y.ToString());
//                }
//                catch (Exception eEx)
//                {
//                    //throw;
//                   // listBoxLog.Items.Add("Ошибка парсинга числа " + value1 + " -> " + eEx.ToString());
//                }
//            }

//            if (property == "Z")
//            {
//                //из-за кодировок, пока так сделаю...
//                string value1 = value.Trim().Replace(Csourse, Cdestination);

//                try
//                {
//                    //если вдруг не число было....
//                    newZ = decimal.Parse(value1);
//                    //tmpCommand.Z = decimal.Parse(value1);
//                    //  listBoxLog.Items.Add("Преобразование значения Z: " + value1 + @" -> " + tmpCommand.Z.ToString());
//                }
//                catch (Exception eEx)
//                {
//                    //throw;
//                   // listBoxLog.Items.Add("Ошибка парсинга числа " + value1 + " -> " + eEx.ToString());
//                }
//            }

//            if (property == "M")
//            {
//                if (value == "0" || value == "0") tmpCommand.needPause = true;

//                if (value == "3" || value == "03") tmpCommand.spindelON = true;

//                if (value == "5" || value == "05") tmpCommand.spindelON = false;

//                if (value == "6" || value == "06")
//                {
//                    //нужен следующий параметр
//                    string property1 = lcmd[i + 1].Substring(0, 1).Trim().ToUpper();
//                    string value1 = lcmd[i + 1].Substring(1).Trim().ToUpper();

//                    string property2 = lcmd[i + 2].Substring(0, 1).Trim().ToUpper();
//                    string value2 = lcmd[i + 2].Substring(1).Trim().ToUpper().Replace('.', ',');

//                    if (property1 == "T" && property2 == "D")
//                    {
//                        tmpCommand.changeInstrument = true;
//                        tmpCommand.numberInstrument = int.Parse(value1);
//                        tmpCommand.timeSeconds = int.Parse(value1);
//                        tmpCommand.diametr = decimal.Parse(value2);
//                        i += 2;
//                    }
//                }
//            }
//        }

//tmpCommand.X = newX;
//tmpCommand.Y = newY;
//tmpCommand.Z = newZ;

//Data_string[(int) currentLine].indexGcode = indexGcode++;

//        GKODS.Add(new GKOD_Command(tmpCommand));



//        tmpCommand.numberInstruct++;
//        tmpCommand.needPause = false;
//        tmpCommand.changeInstrument = false;
//        tmpCommand.timeSeconds = 0;

////        //  if (panelListGkode != null) panelListGkode.listGkodeCommand.Items.Add("[" + tmpCommand.numberInstruct.ToString().PadLeft(maxIndexLen, '0') + "]" + " " + valueStr);




///// <summary>
///// Парсинг G-кода
///// </summary>
///// <param name="lines">Массив строк с G-кодом</param>
//public void LoadDataFromText(string[] lines)
//{
//    //toolStripProgressBar.Value = 0;
//    //toolStripProgressBar.Minimum = 0;
//    //toolStripProgressBar.Maximum = lines.Length-1;

//    listBoxLog.Items.Add(@"Анализ " + (lines.Length - 1) + " строк текста.");
//    //listBoxLog.Items.Add(@"Анализ " + (toolStripProgressBar.Maximum.ToString()) + " строк текста.");

//    int index = 0;

//    List<string> goodstr = new List<string>(); //массив только для распознаных!!! G-кодов

//    foreach (string str in lines)
//    {
//        //toolStripProgressBar.Value = index++;

//        GKOD_resultParse graw = ParseStringCode(str.ToUpper());


//        if (graw.BadStr.Trim().Length != 0)
//        {
//            listBoxLog.Items.Add("Не распознано: " + graw.BadStr);
//        }

//        if (graw.GoodStr.Trim().Length == 0)
//        {
//            AddLog(@"В строке: " + index + " не распознаны команды: " + graw.BadStr);
//            continue;
//        }

//        goodstr.Add(graw.GoodStr);
//    }

//    //запуск анализа нормальных команд
//    FillData(goodstr);
//}



/////// <summary>
/////// Перезаполнение данных
/////// </summary>
/////// <param name="listCode"></param>
////public void FillData(List<string> listCode)
////{
////    GKODS.Clear();

////    //  if (panelListGkode != null) panelListGkode.listGkodeCommand.Items.Clear();

////    GKOD_Command tmpCommand = new GKOD_Command();
////    tmpCommand.angleVectors = 0; //значение по умолчанию
////    int maxIndexLen = listCode.Count.ToString().Length; //вычисление количества символов используемых для нумерации записей

////    listBoxLog.Items.Add("Преобразование текста в спец-формат...");

////    foreach (string valueStr in listCode)
////    {
////        List<string> lcmd = parserGkodeLine(valueStr);

////        for (int i = 0; i < lcmd.Count; i++)
////        {
////            string property = lcmd[i].Substring(0, 1).Trim().ToUpper();
////            string value = lcmd[i].Substring(1).Trim().ToUpper();

////            if (property == "" || value == "") continue; //ошибочная команда

////            if (property == "G")
////            {
////                if (value == "0" || value == "00") tmpCommand.workspeed = false;

////                if (value == "1" || value == "01") tmpCommand.workspeed = true;

////                if (value == "4" || value == "04")
////                {
////                    //нужен следующий параметр
////                    string property1 = lcmd[i + 1].Substring(0, 1).Trim().ToUpper();
////                    string value1 = lcmd[i + 1].Substring(1).Trim().ToUpper();

////                    if (property1 == "P")
////                    {
////                        tmpCommand.needPause = true;
////                        tmpCommand.timeSeconds = int.Parse(value1);
////                        i++;
////                    }
////                }
////            }


////            string symbSeparatorDec = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.ToString();
////            //string symbSeparatorGroup = CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator.ToString(); 

////            char Csourse = '.';
////            char Cdestination = ',';

////            if (symbSeparatorDec == ".")
////            {
////                Csourse = ',';
////                Cdestination = '.';
////            }

////            if (property == "X")
////            {
////                //из-за кодировок, пока так сделаю...
////                string value1 = value.Trim().Replace(Csourse, Cdestination);

////                try
////                {
////                    //если вдруг не число было....
////                    tmpCommand.X = decimal.Parse(value1);
////                    listBoxLog.Items.Add("Преобразование значения X: " + value1 + @" -> " + tmpCommand.X.ToString());
////                }
////                catch (Exception eEx)
////                {
////                    //throw;
////                    listBoxLog.Items.Add("Ошибка парсинга числа " + value1 + " -> " + eEx.ToString());
////                }
////            }

////            if (property == "Y")
////            {
////                //из-за кодировок, пока так сделаю...
////                string value1 = value.Trim().Replace(Csourse, Cdestination);

////                try
////                {
////                    //если вдруг не число было....
////                    tmpCommand.Y = decimal.Parse(value1);
////                    listBoxLog.Items.Add("Преобразование значения Y: " + value1 + @" -> " + tmpCommand.Y.ToString());
////                }
////                catch (Exception eEx)
////                {
////                    //throw;
////                    listBoxLog.Items.Add("Ошибка парсинга числа " + value1 + " -> " + eEx.ToString());
////                }
////            }

////            if (property == "Z")
////            {
////                //из-за кодировок, пока так сделаю...
////                string value1 = value.Trim().Replace(Csourse, Cdestination);

////                try
////                {
////                    //если вдруг не число было....
////                    tmpCommand.Z = decimal.Parse(value1);
////                    listBoxLog.Items.Add("Преобразование значения Z: " + value1 + @" -> " + tmpCommand.Z.ToString());
////                }
////                catch (Exception eEx)
////                {
////                    //throw;
////                    listBoxLog.Items.Add("Ошибка парсинга числа " + value1 + " -> " + eEx.ToString());
////                }
////            }

////            if (property == "M")
////            {
////                if (value == "0" || value == "0") tmpCommand.needPause = true;

////                if (value == "3" || value == "03") tmpCommand.spindelON = true;

////                if (value == "5" || value == "05") tmpCommand.spindelON = false;

////                if (value == "6" || value == "06")
////                {
////                    //нужен следующий параметр
////                    string property1 = lcmd[i + 1].Substring(0, 1).Trim().ToUpper();
////                    string value1 = lcmd[i + 1].Substring(1).Trim().ToUpper();

////                    string property2 = lcmd[i + 2].Substring(0, 1).Trim().ToUpper();
////                    string value2 = lcmd[i + 2].Substring(1).Trim().ToUpper().Replace('.', ',');

////                    if (property1 == "T" && property2 == "D")
////                    {
////                        tmpCommand.changeInstrument = true;
////                        tmpCommand.numberInstrument = int.Parse(value1);
////                        tmpCommand.timeSeconds = int.Parse(value1);
////                        tmpCommand.diametr = decimal.Parse(value2);
////                        i += 2;
////                    }
////                }
////            }
////        }

////        GKODS.Add(new GKOD_Command(tmpCommand));



////        tmpCommand.numberInstruct++;
////        tmpCommand.needPause = false;
////        tmpCommand.changeInstrument = false;
////        tmpCommand.timeSeconds = 0;

////        //  if (panelListGkode != null) panelListGkode.listGkodeCommand.Items.Add("[" + tmpCommand.numberInstruct.ToString().PadLeft(maxIndexLen, '0') + "]" + " " + valueStr);
////    }


////    if (!checkBoxNewSpped.Checked) return;

////    // Вычисление угла между отрезками
////    for (int numPos = 1; numPos < GKODS.Count; numPos++)
////    {
////        double xn = (double)(GKODS[numPos].X - GKODS[numPos - 1].X);
////        double yn = (double)(GKODS[numPos].Y - GKODS[numPos - 1].Y);
////        double zn = (double)(GKODS[numPos].Z - GKODS[numPos - 1].Z);

////        //длина отрезка
////        GKODS[numPos].Distance = (decimal)Math.Sqrt((xn * xn) + (yn * yn) + (zn * zn));

////        if (numPos > GKODS.Count - 2) continue; //первую и последнюю точку не трогаем

////        //получим 3 точки
////        double xa = (double)(GKODS[numPos - 1].X - GKODS[numPos].X);
////        double ya = (double)(GKODS[numPos - 1].Y - GKODS[numPos].Y);
////        double za = (double)(GKODS[numPos - 1].Z - GKODS[numPos].Z);
////        double xb = (double)(GKODS[numPos + 1].X - GKODS[numPos].X);
////        double yb = (double)(GKODS[numPos + 1].Y - GKODS[numPos].Y);
////        double zb = (double)(GKODS[numPos + 1].Z - GKODS[numPos].Z);

////        double angle = Math.Acos((xa * xb + ya * yb + za * zb) / (Math.Sqrt(xa * xa + ya * ya + za * za) * Math.Sqrt(xb * xb + yb * yb + zb * zb)));
////        double angle1 = angle * 180 / Math.PI;

////        GKODS[numPos].angleVectors = (int)angle1;
////    }
////}




