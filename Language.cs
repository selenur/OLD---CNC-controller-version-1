using System.Collections.Generic;
using System.Windows.Forms;

namespace CNC_Assist
{
    static class Language
    {

        private static List<langString> ValueLangStrings = new List<langString>();

        public static void Init()
        {
            ValueLangStrings.Clear();

            ValueLangStrings.Add(new langString(@"_formCaption_", @"Хобби ЧПУ", @"Hobby CNC"));

            ValueLangStrings.Add(new langString(@"_menuFile_"                   , @"Файл"                       , @"File"));
                ValueLangStrings.Add(new langString(@"_menuopenfile_"           , @"Открыть файл..."            , @"Open file..."));
                ValueLangStrings.Add(new langString(@"_menuloadkodefrombuffer_" , @"Получить из буффера"        , @"Get from buffer"));
                ValueLangStrings.Add(new langString(@"_menucloseprogramm_"      , @"Закрыть"                    , @"Close")); 
            ValueLangStrings.Add(new langString(@"_menumodules_"                , @"Модули"                     , @"Modules")); 
                ValueLangStrings.Add(new langString(@"_menuwebcamera_"          , @"Работа с WEB камерой"       , @"Work with WEB camera")); 
                ValueLangStrings.Add(new langString(@"_menuscannSurface_"       , @"Сканирование поверхности"   , @"Scan surface")); 
            ValueLangStrings.Add(new langString(@"_menuhelp_"                   , @"Справка"                    , @"Help")); 
                ValueLangStrings.Add(new langString(@"_menuabout_"              , @"О программе"                , @"About")); 
            ValueLangStrings.Add(new langString(@"_menulanguage_"               , @"Выбор языка"                , @"Select language")); 
                ValueLangStrings.Add(new langString(@"_menurus_"                , @"Русский"                    , @"Russian"));
                ValueLangStrings.Add(new langString(@"_menueng_"                , @"Английский"                 , @"English"));



                ValueLangStrings.Add(new langString(@"_panelSpindel_"       , @"Шпиндель"               , @"Shpindel"));
                ValueLangStrings.Add(new langString(@"_panelEnergystop_"    , @"ОСТАНОВКА"              , @"STOP"));
                ValueLangStrings.Add(new langString(@"_panelSetting_"       , @"Настройки"              , @"Setting"));
                ValueLangStrings.Add(new langString(@"_panelEditGkode_"     , @"Корректировка G-Кода"   , @"Edit G-kode"));
                ValueLangStrings.Add(new langString(@"_panelAdditionally_"  , @"Дополнительно"          , @"Additionally"));
                ValueLangStrings.Add(new langString(@"_panelSetting3D_"     , @"настройки 3D"           , @"Setting 3D"));

                ValueLangStrings.Add(new langString(@"_panelConnect_"   , @"Подключение к контроллеру"  , @"Connect to controller"));
                ValueLangStrings.Add(new langString(@"_panelOpenFile_"  , @"Открыть файл"               , @"Setting 3D"));
                ValueLangStrings.Add(new langString(@"_panelExit_"      , @"Выход"                      , @"EXIT"));

        }



        // рекурсивная функция для применения мультиязычности
        public static void TranlateMenuStrip(ToolStripMenuItem _menuItem)
        {
            string tagElement = _menuItem.Tag.ToString();

            if (tagElement.Substring(0, 1) == "_")
            {
                // попытаемся перевести
                _menuItem.Text = GetTranslate(GlobalSetting.AppSetting.Language, tagElement);
            }


            foreach (ToolStripMenuItem drmenu in _menuItem.DropDownItems)
            {
                TranlateMenuStrip(drmenu);
            }
        }

        public static string GetTranslate(Languages _lang,string _value)
        {
            if (_value == "") return "";

            //_dialog_setting_ rus	Настройки программы	
            //_dialog_setting_ eng	Setting application

            langString ss = null;

            //ss = ValueLangStrings.Find(x => x._NAME_.Contains(_value));

            foreach (langString langRow in ValueLangStrings)
            {
                if (langRow._NAME_ == _value)
                {
                    ss = langRow;
                    break;
                }
                
            }

            if (ss != null)
            {
                switch (_lang)
                {
                        case Languages.Russian:
                        return ss.rus;


                        case Languages.English:
                        return ss.eng;



                }


                return ss.eng;
            }

            //TODO: сделать механизм по нормальному



            return _value;
        }

    }

    class langString
    {
        public string _NAME_;
        public string rus;
        public string eng;

        public langString(string _name, string _rus, string _eng)
        {
            _NAME_ = _name;
            rus = _rus;
            eng = _eng;
        }
    }
}


//Language.Init();
//Tranlate(this);

//TranslateMenu(this.MainMenu);




