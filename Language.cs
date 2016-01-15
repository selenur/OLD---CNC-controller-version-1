using System.Collections.Generic;

namespace CNC_Assist
{
    static class Language
    {

        public static List<langString> ValueLangStrings = new List<langString>();

        public static void Init()
        {
            ValueLangStrings.Clear();

            ValueLangStrings.Add(new langString(@"_appName_", @"ЧПУ хоббист", @"CNC hobbist"));

            ValueLangStrings.Add(new langString(@"_menuFile_"       , @"Файл"           , @"File"));
            ValueLangStrings.Add(new langString(@"_menuSetting_", @"Настройки", @"Setting"));
            ValueLangStrings.Add(new langString(@"_menuHelp_"       , @"Справка"        , @"Help"));
            ValueLangStrings.Add(new langString(@"_aboutApp_"       , @"О программе"    , @"About")); 




            ValueLangStrings.Add(new langString(@"_dialog_setting_", @"Настройки программы", @"Setting application"));
            ValueLangStrings.Add(new langString(@"_select_controller_", @"Выбор контроллера", @"Select controller"));


            /*  
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             */





        }





        public static string GetTranslate(languages _lang,string _value)
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
                        case languages.russian:
                        return ss.rus;
                        break;

                        case languages.english:
                        return ss.eng;
                        break;


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


//private void TranslateMenu(MenuStrip _mm)
//{


//    for (int i = 0; i < _mm.Items.Count; i++)
//    {
//        _mm.Items[i].Text = Language.GetTranslate(Setting.language, _mm.Items[i].Text);

//        //TranslateMenu((MenuStrip) _mm.Items[i].Owner);

//       // for (int n = 0; n < _mm.Items[i].Owner.Items.Count;n++ )
//        //{


//      //  }


//      //_mm.Items[3].Owner.Items[1]

//    //foreach (ToolStripMenuItem tsiCollection in _mm.Items)
//    //{
//    //   // Tranlate(ctrl);

//    //    //ctrl.Text = Language.GetTranslate(Setting.language, ctrl.Text);



//    //}              



//    }





//}


////будет рекурсивной
//private void Tranlate(Control _obj)
//{


//    _obj.Text = Language.GetTranslate(Setting.language, _obj.Text);

//    if (_obj.Controls.Count > 0)
//    {

//        foreach (Control ctrl in _obj.Controls)
//        {
//            Tranlate(ctrl);

//            //ctrl.Text = Language.GetTranslate(Setting.language, ctrl.Text);



//        }

//    }



//}