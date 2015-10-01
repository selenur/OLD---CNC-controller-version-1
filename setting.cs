using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CNC_App
{
    /// <summary>
    ///  Класс для храненения настроек программы
    /// </summary>
    public static class Setting
    {
        /// <summary>
        /// Модель контроллера
        /// </summary>
        public static DeviceModel DeviceModel = DeviceModel.Emulator;

        /// <summary>
        /// Количество импульсов в 1 мм для X
        /// </summary>
        public static int PulseX = 400;
        /// <summary>
        /// Количество импульсов в 1 мм для Y
        /// </summary>
        public static int PulseY = 400;
        /// <summary>
        /// Количество импульсов в 1 мм для Z 
        /// </summary>
        public static int PulseZ = 400;

        public static bool StartupConnect = true;


        /// <summary>
        /// Файл настроек программы
        /// </summary>
        private static readonly string Filesetting = string.Format("{0}\\setting.ini", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));


        /// <summary>
        /// Загрузка из файла настроек
        /// </summary>
        /// <returns></returns>
        public static void LoadSetting()
        {
            string sPulseX = LoadProperty("pulseX");
            string sPulseY = LoadProperty("pulseY");
            string sPulseZ = LoadProperty("pulseZ");
            string sStartupConnect = LoadProperty("StartupConnect");

            if (sPulseX.Trim() != "") Setting.PulseX = int.Parse(sPulseX);
            if (sPulseY.Trim() != "") Setting.PulseY = int.Parse(sPulseY);
            if (sPulseZ.Trim() != "") Setting.PulseZ = int.Parse(sPulseZ);
            if (sStartupConnect.Trim() != "") StartupConnect      = bool.Parse(sStartupConnect);
        }


        /// <summary>
        /// Сохранение в файл настроек
        /// </summary>
        /// <returns></returns>
        public static void SaveSetting()
        {
            SaveProperty("pulseX", Setting.PulseX.ToString());
            SaveProperty("pulseY", Setting.PulseY.ToString());
            SaveProperty("pulseZ", Setting.PulseZ.ToString());
            SaveProperty("StartupConnect", StartupConnect.ToString());
        }



        /// <summary>
        /// Функция извлечения параметра из файла настроек
        /// </summary>
        /// <param name="property">Имя параметра (строка)</param>
        /// <returns>Значение параметра (Строка), если будет отсутствовать файл настроек, или указанный параметр, то вернется ""</returns>
        private static string LoadProperty(string property)
        {
            if (!File.Exists(Filesetting)) return "";
            var sr = new StreamReader(Filesetting);
            var arr = sr.ReadToEnd().Split('\n');
            sr.Close();

            foreach (var ss in arr)
            {
                //проверим наш ли это параметр
                var posSymbol = ss.IndexOf('=');

                if (posSymbol <= 0) continue; //странный параметр, такой не нужен нам

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
        /// Функция для сохранения параметров в файле настроек
        /// Сохраненные данные в файле будут выглядеть следующим образом:
        /// параметр = значение
        /// !!! Поэтому знак равно нельзя использовать ни в параметре ни в значении
        /// </summary>
        /// <param name="property">Имя параметра (строка)</param>
        /// <param name="value">Значение параметра (Строка)</param>
        private static void SaveProperty(string property, string value)
        {
            List<string> listProperty = new List<string>();

            // Запись параметра в файл

            // В начале получим все параметры
            if (File.Exists(Filesetting))
            {

                StreamReader sr = new StreamReader(Filesetting);
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

                StreamWriter sw = new StreamWriter(Filesetting);
                sw.WriteLine(sOut);
                sw.Close();
            }
            catch (Exception)
            {
                //addLog(e.ToString(), true);
            }
        }



    }

    /// <summary>
    /// Виды контроллеров, которые поддерживает программа
    /// </summary>
    public enum DeviceModel
    {
        Emulator = 0,
        MK1 = 1,
        MK2 = 2
    };


}







