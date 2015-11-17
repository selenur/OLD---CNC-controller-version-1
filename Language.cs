using System.Collections.Generic;

namespace CNC_App
{
    static class Language
    {

        public static List<langString> ValueLangStrings = new List<langString>();

        public static void Init()
        {
            ValueLangStrings.Clear();

            ValueLangStrings.Add(new langString(@"_dialog_setting_", @"Настройки программы", @"Setting application"));
            ValueLangStrings.Add(new langString(@"_select_controller_", @"Выбор контроллера", @"Select controller"));
            
            




        }

        public static string GetTranslate(eLanguage _lang,string _value)
        {

            //_dialog_setting_ rus	Настройки программы	
            //_dialog_setting_ eng	Setting application

            langString ss = ValueLangStrings.Find(x => x._NAME_ == _value);
			


            //TODO: сделать механизм по нормальному



            return null;
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
