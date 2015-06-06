namespace CNC_App
{
    /// <summary>
    ///  Класс для храненения настроек контроллеров
    /// </summary>
    public class Setting
    {
        /// <summary>
        /// Тип контроллера
        /// </summary>
        public KindControllers kind;

        /// <summary>
        /// Количество импульсов для посылки в контроллер
        /// </summary>
        public int pulseX;
        /// <summary>
        /// Количество импульсов для посылки в контроллер
        /// </summary>
        public int pulseY;
        /// <summary>
        /// Количество импульсов для посылки в контроллер
        /// </summary>
        public int pulseZ;


        public Setting()
        {
            kind = KindControllers.Emulator;
            pulseX = 400;
            pulseY = 400;
            pulseZ = 400;


        }

        /// <summary>
        /// Загрузка из файла настроек
        /// </summary>
        /// <returns></returns>
        public bool LoadSetting()
        {

            return true;
        }


        /// <summary>
        /// Сохранение в файл настроек
        /// </summary>
        /// <returns></returns>
        public bool SaveSetting()
        {

            return true;
        }

    }





    /// <summary>
    /// Виды поддерживаемых контроллеров
    /// </summary>
    public enum KindControllers
    {
        Emulator,
        MK1,
        MK2
    }
}
