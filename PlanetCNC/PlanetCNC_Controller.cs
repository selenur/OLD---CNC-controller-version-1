namespace CNC_Assist.PlanetCNC
{
    static class PlanetCNC_Controller
    {
        //при каждом выполнении сюда записываем последнюю команду
        public static DataRow LastStatus = new DataRow(0,"");


        //// последнее отправленное в контроллер значение
        //public static bool lastChanel1ON = false;
        //public static bool lastChanel2ON = false;
        //public static bool lastChanel3ON = false;

        ////последняя установленная команда скорости
        //public static bool lastG0 = false;
        //public static bool lastG1 = false;
        //public static bool lastG2 = false;
        //public static bool lastG3 = false;

        ////последняя установленная скорость
        //public static int lastG0speed = 100;
        //public static int lastG1speed = 100;
        //public static int lastG2speed = 100;
        //public static int lastG3speed = 100;

        ////значение для выхода №2, для генерации частоты сигнала
        public static int ValueHz = 0;

        //public static int numKadr = 0; //номер кадра


        ////применяем абсолютные координаты G90 = ИСТИНА
        ////применяем относительные координаты G91 = ложь
        //public static bool AbsolutlyPos = true; 


        //// Для выполнения G-кода, нужно знать последнее посланное значение в контроллер
        //public static int lastPosXpulse = 0;
        //public static int lastPosYpulse = 0;
        //public static int lastPosZpulse = 0;
        //public static int lastPosApulse = 0;

        ////public static decimal lastPosIpulse = 0;
        ////public static decimal lastPosJpulse = 0;
        ////public static decimal lastPosKpulse = 0;

        /// <summary>
        /// Включение шпинделя
        /// </summary>
        public static void Spindel_ON()
        {
            Controller.SendBinaryData(BinaryData.pack_B5(true, 2, BinaryData.TypeSignal.Hz, PlanetCNC_Controller.ValueHz));

            //зафиксируем
            PlanetCNC_Controller.LastStatus.Machine.SpindelON = true;

        }

        /// <summary>
        /// Выключение шпинделя
        /// </summary>
        public static void Spindel_OFF()
        {
            Controller.SendBinaryData(BinaryData.pack_B5(false, 2, BinaryData.TypeSignal.Hz, PlanetCNC_Controller.ValueHz));
            //зафиксируем
            PlanetCNC_Controller.LastStatus.Machine.SpindelON = false;
        }



        ///// <summary>
        ///// chanel 2
        ///// </summary>
        //public static bool Chanel2
        //{

        //    get { return lastChanel2ON; }
        //    set { Controller.SendBinaryData(BinaryData.pack_B6(value,lastChanel3ON)); }
        //}

        ///// <summary>
        ///// chanel 3
        ///// </summary>
        //public static bool Chanel3
        //{

        //    get { return lastChanel3ON; }
        //    set { Controller.SendBinaryData(BinaryData.pack_B6(lastChanel2ON,value)); }
        //}

    }
}
