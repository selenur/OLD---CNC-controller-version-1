using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CNC_Assist.PlanetCNC;
using CNC_Assist.SettingApp;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace CNC_Assist
{
    public partial class MainForm : Form
    {
        #region Инициализация/заршение работы формы

        // --------
        // User panels
        // Пользовательские панели
        // --------
        private GuiPanelPos _panelPos;
        private GUI_panel_ManualControl _panelManualControl;
        private GUI_panel_Info _panelInfo;
        private GUI_panel_Limits _panelLimits;
        private GuiPanelTaskControl _panelTaskControl;
        private GUI_panel_BitValue _panelBitValue;
        private GUI_panel_MoveTo _panelMoveTo;
        private webCamera _webCameraForms;

        public MainForm()
        {
            InitializeComponent();

            // Получаем настройки из файла
            GlobalSetting.LoadSetting();

            // 3d инициализация OpenGL
            OpenGL_preview.InitializeContexts();

            // подключение обработчика, колесика мышки
            MouseWheel += this_MouseWheel;

            // Подключение событий от контроллера
            Controller.WasConnected         += CncConnect;
            Controller.WasDisconnected      += CncDisconnect;
            Controller.NewDataFromController+= CncNewData;
            Controller.Message              += CncMessage;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Дополнительная инициализация 3D
            Init3D();

            Language.Init();

            // Подключение к контроллеру
            if (GlobalSetting.AppSetting.Autoconnect) Controller.Connect();

            RefreshElementsForms(true);

            //ScanSurface.Init();


            

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Controller.Connected)
            {
                MessageBox.Show(@"Для завершения работы с программой, необходимо отключиться от ЧПУ контроллера!");
                e.Cancel = true; // запретим закрытие формы
                DataLoader.RequestStop(); //если вдруг в этот момент выполняется загрузка данных, то прервем её
                Controller.Disconnect(); //завершим связь с контроллером
            }
            else
            {
                //Отменим подписки
                Controller.WasConnected         -= CncConnect;
                Controller.WasDisconnected      -= CncDisconnect;
                Controller.NewDataFromController-= CncNewData;
                Controller.Message              -= CncMessage;
                MouseWheel -= this_MouseWheel;
            }
        }

        #endregion


        #region События от контроллера

        //событие для ведения логов
        private void CncMessage(object sender, DeviceEventArgsMessage e)
        {
            Invoke((MethodInvoker)delegate
            {
                listBoxLog.Items.Add(DateTime.Now + " - " + e.Message);
            });
        }

        // СОБЫТИЯ ОТ КОНТРОЛЛЕРА что получили новые данные
        private void CncNewData(object sender)
        {
            //текущие границы
            double GrateXmin = GlobalSetting.ControllerSetting.WorkSizeXm;
            double GrateXmax = GlobalSetting.ControllerSetting.WorkSizeXp;
            double GrateYmin = GlobalSetting.ControllerSetting.WorkSizeYm;
            double GrateYmax = GlobalSetting.ControllerSetting.WorkSizeYp;
            
            //текущие координаты
            double x = (double)Controller.INFO.AxesX_PositionMM;
            double y = (double)Controller.INFO.AxesY_PositionMM;


            // При каждом получении новых данных от контроллера, проверим необходимость расширения рабочей области
            if (x < GrateXmin) GlobalSetting.ControllerSetting.WorkSizeXm = (float)x;
            if (x > GrateXmax) GlobalSetting.ControllerSetting.WorkSizeXp = (float)x;

            if (y < GrateYmin) GlobalSetting.ControllerSetting.WorkSizeYm = (float)y;
            if (y > GrateYmax) GlobalSetting.ControllerSetting.WorkSizeYp = (float)y;

        }

        //событие о прекращении связи
        private void CncDisconnect(object sender, DeviceEventArgsMessage e)
        {
            Invoke((MethodInvoker)RefreshElementsForms1);
        }

        //событие успешного подключения
        private void CncConnect(object sender)
        {
            Invoke((MethodInvoker)RefreshElementsForms1);
        }

        #endregion

        #region Отслеживание нажатий на NumLock-e и функц. клавиш

        //KeyHook gkh = new KeyHook();
        [DllImport("USER32.dll")] static extern short GetKeyState(VirtualKeyStates nVirtKey);

        enum VirtualKeyStates
        {
            //VkLbutton = 0x01,
            //VkRbutton = 0x02,
            //VkCancel = 0x03,
            //VkMbutton = 0x04,
            //
            //VK_XBUTTON1 = 0x05,
            //VK_XBUTTON2 = 0x06,
            ////
            //VK_BACK = 0x08,
            //VK_TAB = 0x09,
            ////
            //VK_CLEAR = 0x0C,
            //VK_RETURN = 0x0D,
            ////
            //VK_SHIFT = 0x10,
            //VK_CONTROL = 0x11,
            //VK_MENU = 0x12,
            //VK_PAUSE = 0x13,
            //VK_CAPITAL = 0x14,
            ////
            //VK_KANA = 0x15,
            //VK_HANGEUL = 0x15,  /* old name - should be here for compatibility */
            //VK_HANGUL = 0x15,
            //VK_JUNJA = 0x17,
            //VK_FINAL = 0x18,
            //VK_HANJA = 0x19,
            //VK_KANJI = 0x19,
            //
            VkEscape = 0x1B,
            //
            //VK_CONVERT = 0x1C,
            //VK_NONCONVERT = 0x1D,
            //VK_ACCEPT = 0x1E,
            //VK_MODECHANGE = 0x1F,
            //
            //VK_SPACE = 0x20,
            //VK_PRIOR = 0x21,
            //VK_NEXT = 0x22,
            //VK_END = 0x23,
            //VK_HOME = 0x24,
            //VK_LEFT = 0x25,
            //VK_UP = 0x26,
            //VK_RIGHT = 0x27,
            //VK_DOWN = 0x28,
            //VK_SELECT = 0x29,
            //VK_PRINT = 0x2A,
            //VK_EXECUTE = 0x2B,
            //VK_SNAPSHOT = 0x2C,
            //VK_INSERT = 0x2D,
            //VK_DELETE = 0x2E,
            //VK_HELP = 0x2F,
            ////
            //VK_LWIN = 0x5B,
            //VK_RWIN = 0x5C,
            //VK_APPS = 0x5D,
            ////
            //VK_SLEEP = 0x5F,
            //
            VkNumpad0 = 0x60,
            VkNumpad1 = 0x61,
            VkNumpad2 = 0x62,
            VkNumpad3 = 0x63,
            VkNumpad4 = 0x64,
            VkNumpad5 = 0x65,
            VkNumpad6 = 0x66,
            VkNumpad7 = 0x67,
            VkNumpad8 = 0x68,
            VkNumpad9 = 0x69,
            //VK_MULTIPLY = 0x6A,
            //VK_ADD = 0x6B,
            //VK_SEPARATOR = 0x6C,
            //VK_SUBTRACT = 0x6D,
            //VK_DECIMAL = 0x6E,
            //VK_DIVIDE = 0x6F,
            VkF1 = 0x70,
            VkF2 = 0x71,
            VkF3 = 0x72,
            VkF4 = 0x73,
            VkF5 = 0x74,
            VkF6 = 0x75,
            //VK_F7 = 0x76,
            //VK_F8 = 0x77,
            //VK_F9 = 0x78,
            //VK_F10 = 0x79,
            //VK_F11 = 0x7A,
            //VK_F12 = 0x7B,
            //VK_F13 = 0x7C,
            //VK_F14 = 0x7D,
            //VK_F15 = 0x7E,
            //VK_F16 = 0x7F,
            //VK_F17 = 0x80,
            //VK_F18 = 0x81,
            //VK_F19 = 0x82,
            //VK_F20 = 0x83,
            //VK_F21 = 0x84,
            //VK_F22 = 0x85,
            //VK_F23 = 0x86,
            //VK_F24 = 0x87,
            //
            //VkNumlock = 0x90
            //VK_SCROLL = 0x91,
            ////
            //VK_OEM_NEC_EQUAL = 0x92,   // '=' key on numpad
            ////
            //VK_OEM_FJ_JISHO = 0x92,   // 'Dictionary' key
            //VK_OEM_FJ_MASSHOU = 0x93,   // 'Unregister word' key
            //VK_OEM_FJ_TOUROKU = 0x94,   // 'Register word' key
            //VK_OEM_FJ_LOYA = 0x95,   // 'Left OYAYUBI' key
            //VK_OEM_FJ_ROYA = 0x96,   // 'Right OYAYUBI' key
            ////
            //VK_LSHIFT = 0xA0,
            //VK_RSHIFT = 0xA1,
            //VK_LCONTROL = 0xA2,
            //VK_RCONTROL = 0xA3,
            //VK_LMENU = 0xA4,
            //VK_RMENU = 0xA5,
            ////
            //VK_BROWSER_BACK = 0xA6,
            //VK_BROWSER_FORWARD = 0xA7,
            //VK_BROWSER_REFRESH = 0xA8,
            //VK_BROWSER_STOP = 0xA9,
            //VK_BROWSER_SEARCH = 0xAA,
            //VK_BROWSER_FAVORITES = 0xAB,
            //VK_BROWSER_HOME = 0xAC,
            ////
            //VK_VOLUME_MUTE = 0xAD,
            //VK_VOLUME_DOWN = 0xAE,
            //VK_VOLUME_UP = 0xAF,
            //VK_MEDIA_NEXT_TRACK = 0xB0,
            //VK_MEDIA_PREV_TRACK = 0xB1,
            //VK_MEDIA_STOP = 0xB2,
            //VK_MEDIA_PLAY_PAUSE = 0xB3,
            //VK_LAUNCH_MAIL = 0xB4,
            //VK_LAUNCH_MEDIA_SELECT = 0xB5,
            //VK_LAUNCH_APP1 = 0xB6,
            //VK_LAUNCH_APP2 = 0xB7,
            ////
            //VK_OEM_1 = 0xBA,   // ';:' for US
            //VK_OEM_PLUS = 0xBB,   // '+' any country
            //VK_OEM_COMMA = 0xBC,   // ',' any country
            //VK_OEM_MINUS = 0xBD,   // '-' any country
            //VK_OEM_PERIOD = 0xBE,   // '.' any country
            //VK_OEM_2 = 0xBF,   // '/?' for US
            //VK_OEM_3 = 0xC0,   // '`~' for US
            ////
            //VK_OEM_4 = 0xDB,  //  '[{' for US
            //VK_OEM_5 = 0xDC,  //  '\|' for US
            //VK_OEM_6 = 0xDD,  //  ']}' for US
            //VK_OEM_7 = 0xDE,  //  ''"' for US
            //VK_OEM_8 = 0xDF,
            ////
            //VK_OEM_AX = 0xE1,  //  'AX' key on Japanese AX kbd
            //VK_OEM_102 = 0xE2,  //  "<>" or "\|" on RT 102-key kbd.
            //VK_ICO_HELP = 0xE3,  //  Help key on ICO
            //VK_ICO_00 = 0xE4,  //  00 key on ICO
            ////
            //VK_PROCESSKEY = 0xE5,
            ////
            //VK_ICO_CLEAR = 0xE6,
            ////
            //VK_PACKET = 0xE7,
            ////
            //VK_OEM_RESET = 0xE9,
            //VK_OEM_JUMP = 0xEA,
            //VK_OEM_PA1 = 0xEB,
            //VK_OEM_PA2 = 0xEC,
            //VK_OEM_PA3 = 0xED,
            //VK_OEM_WSCTRL = 0xEE,
            //VK_OEM_CUSEL = 0xEF,
            //VK_OEM_ATTN = 0xF0,
            //VK_OEM_FINISH = 0xF1,
            //VK_OEM_COPY = 0xF2,
            //VK_OEM_AUTO = 0xF3,
            //VK_OEM_ENLW = 0xF4,
            //VK_OEM_BACKTAB = 0xF5,
            ////
            //VK_ATTN = 0xF6,
            //VK_CRSEL = 0xF7,
            //VK_EXSEL = 0xF8,
            //VK_EREOF = 0xF9,
            //VK_PLAY = 0xFA,
            //VK_ZOOM = 0xFB,
            //VK_NONAME = 0xFC,
            //VK_PA1 = 0xFD,
            //VkOemClear = 0xFE
        }

        private const int KeyPressed = 0x8000;

        private bool IsPressed(VirtualKeyStates key)
        {
            return Convert.ToBoolean(GetKeyState(key) & KeyPressed);
        }

        /// <summary>
        /// Для определения выполняется ли ручное движение
        /// </summary>
        private bool _manualMoveButtonPressed;

        // ReSharper disable once FunctionComplexityOverflow
        private void timerKeyHooks_Tick(object sender, EventArgs e)
        {

            bool keyf1 = IsPressed(VirtualKeyStates.VkF1);
            bool keyf2 = IsPressed(VirtualKeyStates.VkF2);
            bool keyf3 = IsPressed(VirtualKeyStates.VkF3);
            bool keyf4 = IsPressed(VirtualKeyStates.VkF4);
            bool keyf5 = IsPressed(VirtualKeyStates.VkF5);
            bool keyf6 = IsPressed(VirtualKeyStates.VkF6);
            bool keyesc = IsPressed(VirtualKeyStates.VkEscape);
            //bool keyNUM = IsPressed(VirtualKeyStates.VK_NUMLOCK);

            //if (keyNUM) //F1
            //{
            //   // checkBoxManualMove.Checked = !checkBoxManualMove.Checked;
            //}

            if (keyesc) //ESC
            {
                PreviewSetting.PosAngleX = 0;
                PreviewSetting.PosAngleY = 0;
                PreviewSetting.PosAngleZ = 0;
            }


            if (keyf1) //F1
            {
                --PreviewSetting.PosAngleX;
            }

            if (keyf2) //F2
            {
                ++PreviewSetting.PosAngleX;
            }


            if (keyf3)
            {
                --PreviewSetting.PosAngleY;
            }

            if (keyf4)
            {
                ++PreviewSetting.PosAngleY;
            }


            if (keyf5)
            {
                --PreviewSetting.PosAngleZ;
            }

            if (keyf6)
            {
                ++PreviewSetting.PosAngleZ;
            }

            if (_panelManualControl == null) return; //если панель не отображается, то дальше нет смысла



            if (!_panelManualControl.checkBoxManualMove.Checked) return;  //проверка флажка "управление с NUM-pad"

            if (!Controller.TestAllowActions()) return; //Проверка что контроллер доступен

            if (Task.StatusTask != statusVariant.Waiting) return; //Проверка что нет выполняемых задач в данный момент

            bool num0 = IsPressed(VirtualKeyStates.VkNumpad0);
            bool num1 = IsPressed(VirtualKeyStates.VkNumpad1);
            bool num2 = IsPressed(VirtualKeyStates.VkNumpad2);
            bool num3 = IsPressed(VirtualKeyStates.VkNumpad3);
            bool num4 = IsPressed(VirtualKeyStates.VkNumpad4);
            bool num5 = IsPressed(VirtualKeyStates.VkNumpad5);
            bool num6 = IsPressed(VirtualKeyStates.VkNumpad6);
            bool num7 = IsPressed(VirtualKeyStates.VkNumpad7);
            bool num8 = IsPressed(VirtualKeyStates.VkNumpad8);
            bool num9 = IsPressed(VirtualKeyStates.VkNumpad9);

            // ReSharper disable once InconsistentNaming
            string _x = "0";
            // ReSharper disable once InconsistentNaming
            string _y = "0";
            // ReSharper disable once InconsistentNaming
            string _z = "0";

            if (num0 || num1 || num2 || num3 || num4 || num5 || num6 || num7 || num8 || num9)
            {
                //нажата хотя-бы 1 кнопка
                if (_manualMoveButtonPressed) return;

                _manualMoveButtonPressed = true;

                // -x
                if (num1 || num4 || num7) _x = "-";
                // +x
                if (num3 || num6 || num9) _x = "+";

                // -y
                if (num1 || num2 || num3) _y = "-";
                // +y
                if (num7 || num8 || num9) _y = "+";

                // -z
                if (num0) _z = "-";
                // +z
                if (num5) _z = "+";

                Controller.StartManualMove(_x, _y, _z, (int)_panelManualControl.numericUpDownManualSpeed.Value);
            }
            else
            {
                //нет ни одной нажатой
                if (!_manualMoveButtonPressed) return;
                Controller.StopManualMove();
                _manualMoveButtonPressed = false;
            }
        }

        #endregion

        #region События от элементов на форме

        /// <summary>
        /// для invoke вызовов
        /// </summary>
        private void RefreshElementsForms1()
        {
            RefreshElementsForms();
        }


        //void GetAllTypedControls(Control ctrl)
        //{

        //    string ss = "";

        //    if (ctrl.Tag != null)
        //    {
        //        ss = ctrl.Tag.ToString();
        //    }
        //    //// Работаем только с элементами искомого типа   
        //    //if (ctrl.GetType() == type)
        //    //{
        //    //    controls.Add(ctrl);
        //    //////Language.Tranlate(ctrl);
        //    //}
        //    // Проходим через элементы рекурсивно,   
        //    // чтобы не пропустить элементы,   
        //    //которые находятся в контейнерах   
        //    foreach (Control ctrlChild in ctrl.Controls)
        //    {
        //        string ss2 = "";

        //        if (ctrlChild.Tag != null)
        //        {
        //            ss2 = ctrlChild.Tag.ToString();
        //        }
        //        //string ss2 = ctrlChild.Tag.ToString();
        //        //string ss2 = (Control) ctrlChild.Tag;
        //        GetAllTypedControls(ctrlChild);
        //    }
        //}  



        private void RefreshElementsForms(bool _reloadPanel = false)
        {
            if (Controller.Connected)
            {
                bt_ConnDiskonect.Image = Properties.Resources.connect;
                bt_ConnDiskonect.Text = @"Отключиться от контроллера";
            }
            else
            {
                bt_ConnDiskonect.Image = Properties.Resources.disconnect;
                bt_ConnDiskonect.Text = @"Подключиться к контроллеру";
            }

            buttonESTOP.Enabled = Controller.Connected;
            buttonSpindel.Enabled = Controller.Connected;

            if (Controller.INFO.Estop)
            {
                buttonESTOP.BackColor = Color.Red;
                buttonESTOP.ForeColor = Color.White;
            }
            else
            {
                buttonESTOP.BackColor = Color.FromName("Control");
                buttonESTOP.ForeColor = Color.Black;
            }


            if (Controller.INFO.shpindel_Enable)
            {
                buttonSpindel.BackColor = Color.Green;
                buttonSpindel.ForeColor = Color.White;
            }
            else
            {
                buttonSpindel.BackColor = Color.FromName("Control");
                buttonSpindel.ForeColor = Color.Black;
            }

            if (!_reloadPanel) return; //что-бы не перерисовывать панели


            // --- ПЕРЕВОД меню и диалогов ---
            //1)заголовок программы
            this.Text = Language.GetTranslate(GlobalSetting.AppSetting.Language, this.Tag.ToString());
            //2)меню действий
            foreach (ToolStripMenuItem item in MainMenu.Items)
            {
                Language.TranlateMenuStrip(item);
            }



            //3)панель действий
            foreach (var item in MainToolStrip.Items)
            {
                if (item is ToolStripButton)
                {

                    string ss = ((ToolStripButton)item).Tag.ToString();		


                    ((ToolStripButton)item).Text = Language.GetTranslate(GlobalSetting.AppSetting.Language, ss);
                    

                    
                    

                }

                 //пропускаем ToolStripSeparator

                if (item is ToolStripDropDownButton)
                {
                    //тут нужно пробежаться внутри так-же
                    string ss = ((ToolStripDropDownButton)item).Tag.ToString();
                    ((ToolStripDropDownButton)item).Text = Language.GetTranslate(GlobalSetting.AppSetting.Language, ss);

                    foreach (var ddb in ((ToolStripDropDownButton)item).DropDownItems)
                    {
                        string ss2 = ((ToolStripMenuItem)ddb).Tag.ToString();
                        ((ToolStripMenuItem)ddb).Text = Language.GetTranslate(GlobalSetting.AppSetting.Language, ss2);

                    }

                    //  ((ToolStripDropDownButton)item).DropDownItems[0]
                    

                }
               // Language.TranlateMenuStrip(item);
            }



            //fileToolStripMenuItem.Tag

            //foreach (var ctrl in this.Controls)
            //{
            //    //string ss = (Control)ctrl.Tag;
            //    if (ctrl is ToolStrip) //
            //    {
            //        Language.Tranlate(ctrl);
            //    }
            //}

            //GetAllTypedControls(this);
            

            //if (GlobalSetting.AppSetting.Language == Languages.Russian)
            //{
            //    this.Text = @"Хобби ЧПУ 2.0.0";
            //    menuLanguageToolStripMenuItem.Text = @"Язык";


            //}
            //else
            //{
            //    this.Text = @"Hobby CNC 2.0.0";
            //    menuLanguageToolStripMenuItem.Text = @"Language";
            //}




            bool visibleLeft;
            bool visibleRight;
            bool visibleTask;

            panelLeft.Controls.Clear();
            panelRight.Controls.Clear();

            if (!GlobalSetting.PanelSetting.ShowGuiPanelPos && 
                !GlobalSetting.PanelSetting.ShowGuiPanelLimits &&
                !GlobalSetting.PanelSetting.ShowGuiPanelInfo &&
                !GlobalSetting.PanelSetting.ShowGuiPanelManualControl)
            {
                visibleLeft = false;
            }
            else
            {
                visibleLeft = true;
            }

            if (!GlobalSetting.PanelSetting.ShowGuiPanelTaskControl &&
                !GlobalSetting.PanelSetting.ShowGuiPanelMoveTo &&
                !GlobalSetting.PanelSetting.ShowGuiPanelBitValue)
            {
                visibleRight = false;
                visibleTask = false;
            }
            else
            {
                visibleRight = true;
                visibleTask = GlobalSetting.PanelSetting.ShowGuiPanelTaskControl;
            }

            if (GlobalSetting.PanelSetting.ShowGuiPanelPos)
            {
                _panelPos = new GuiPanelPos();
                panelLeft.Controls.Add(_panelPos);
            }
            else
            {
                _panelPos = null;
            }

            if (GlobalSetting.PanelSetting.ShowGuiPanelLimits)
            {
                _panelLimits = new GUI_panel_Limits();
                panelLeft.Controls.Add(_panelLimits);
            }
            else
            {
                _panelLimits = null;
            }

            if (GlobalSetting.PanelSetting.ShowGuiPanelInfo)
            {
                _panelInfo = new GUI_panel_Info();
                panelLeft.Controls.Add(_panelInfo);
            }
            else
            {
                _panelInfo = null;
            }

            if (GlobalSetting.PanelSetting.ShowGuiPanelManualControl)
            {
                _panelManualControl = new GUI_panel_ManualControl();
                panelLeft.Controls.Add(_panelManualControl);
            }
            else
            {
                _panelManualControl = null;
            }




            if (GlobalSetting.PanelSetting.ShowGuiPanelTaskControl)
            {
                _panelTaskControl = new GuiPanelTaskControl();
                panelRight.Controls.Add(_panelTaskControl);
            }
            else
            {
                _panelTaskControl = null;
            }

            if (GlobalSetting.PanelSetting.ShowGuiPanelMoveTo)
            {
                _panelMoveTo = new GUI_panel_MoveTo();
                panelRight.Controls.Add(_panelMoveTo);
            }
            else
            {
                _panelMoveTo = null;
            }

            if (GlobalSetting.PanelSetting.ShowGuiPanelBitValue)
            {
                _panelBitValue = new GUI_panel_BitValue();
                panelRight.Controls.Add(_panelBitValue);
            }
            else
            {
                _panelBitValue = null;
            }

            int mwidht = Width - 20;

            if (visibleLeft)
            {
                panelLeft.Visible = true;
                panelCenter.Left = 210;
                mwidht -= 210;
            }
            else
            {
                panelLeft.Visible = false;
                panelCenter.Left = 0;
            }

            if (visibleRight)
            {
                panelRight.Visible = true;

                if (visibleTask)
                {
                    mwidht -= 414;
                    panelRight.Width = 408;
                }
                else
                {
                    mwidht -= 210;
                    panelRight.Width = 204;
                }
            }
            else
            {
                panelRight.Visible = false;
            }

            panelCenter.Width = mwidht;

            panelRight.Left = panelCenter.Left + panelCenter.Width+6;


        }

        //событие от колёсика мышки
        void this_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) ++PreviewSetting.PosZoom;
            else --PreviewSetting.PosZoom;
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_exit2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_ConnDiskonect_Click(object sender, EventArgs e)
        {
            if (Controller.Connected)
            {
                Controller.Disconnect();
            }
            else
            {
                Controller.Connect();
            }
        }

        /// <summary>
        /// Вызов диалога пользователя для выбора файла, и посылка данных в процедуру: LoadDataFromText(string[] lines)
        /// </summary>
        private void OpenFile()
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            Text = @"Управленец ЧПУ: " + openFileDialog.FileName; //заголовок окна

            listBoxLog.Items.Add(@"Загрузка данных из файла: " + openFileDialog.FileName);

            DataLoader.ReadFromFile(openFileDialog.FileName); //запуск загрузки данных

            //и покажем диалог загрузки
            LoadingData frmLoad = new LoadingData();
            frmLoad.ShowDialog();
        }

        private void menuOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btLogClear_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox frm = new AboutBox();
            frm.ShowDialog();
        }

        private void buttonSpindel_Click(object sender, EventArgs e)
        {
            if (Controller.INFO.shpindel_Enable)
            {
                PlanetCNC_Controller.Spindel_OFF();
            }
            else
            {
                PlanetCNC_Controller.Spindel_ON();
            }
        }

        private void toolStripButtonEnergyStop_Click(object sender, EventArgs e)
        {
            Controller.EnergyStop();
        }

        private void Feed()
        {
            PreviewSetting.ShowMatrix = true;
            ScanSurfaceForm frm = new ScanSurfaceForm();
            frm.Show();
        }

        private Sett3D frmSett3D = null;

        private void additionallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //вызов 3Д формы
            //покажем графические настройки

            if (frmSett3D == null)
            {
                frmSett3D = new Sett3D();
                frmSett3D.FormClosed += new FormClosedEventHandler(frmSett3D_FormClosed);
                frmSett3D.Show();
            }
            else
            {
                frmSett3D.Show();
            }
        }

        private void frmSett3D_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSett3D = null;
        }

        private void scansurfaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //вызов формы сканирования
            Feed();
        }

        private void toolStripButtonEditData_Click(object sender, EventArgs e)
        {
            EditGkode frm = new EditGkode();
            frm.Show();
        }


        #endregion

        #region 3D OpenGL

        //параметры 3Д просмотра
        public Preview3DSetting PreviewSetting = new Preview3DSetting();

        //для работы с мышью и клавой
        bool _move3D;
        MouseButtons _mouseButton;
        bool _keyShift;
        int _oldPosX;
        int _oldPosY;

        //public bool ShowGrate;
        //public double GrateXmin;
        //public double GrateXmax;
        //public double GrateYmin;
        //public double GrateYmax;


        /// <summary>
        /// инициализация 3D просмотра
        /// </summary>
        private void Init3D()//*OK*
        {
            // инициализация OpenGL
            // инициализация бибилиотеки glut 
            Glut.glutInit();
            // инициализация режима экрана 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE); //Цвет RGB и двойной буфер использовать

            // установка цвета очистки экрана (RGBA) 
            Gl.glClearColor(255, 255, 255, 1);

            // установка размера отображения 
            Gl.glViewport(0, 0, OpenGL_preview.Width, OpenGL_preview.Height);

            // активация проекционной матрицы 
            Gl.glMatrixMode(Gl.GL_PROJECTION);

            // очистка матрицы 
            Gl.glLoadIdentity();

            Glu.gluPerspective(45, OpenGL_preview.Width / (float)OpenGL_preview.Height, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            // начало визуализации (активируем таймер) 
            RenderTimer.Start();


            PreviewSetting.ShowInstrument = true;
            //preview_setting.ShowGrid = true;

            PreviewSetting.PosAngleX = -90;
            PreviewSetting.PosAngleY = 0;
            PreviewSetting.PosAngleZ = 0;
            PreviewSetting.PosX = -96;
            PreviewSetting.PosY = -64;
            PreviewSetting.PosZ = -300;
            PreviewSetting.PosZoom = 7;

        }

        private void OpenGL_preview_MouseUp(object sender, MouseEventArgs e)
        {
            _move3D = false;
        }

        private void OpenGL_preview_MouseDown(object sender, MouseEventArgs e)
        {
            _move3D = true;
            _mouseButton = e.Button;

            _oldPosX = e.X;
            _oldPosY = e.Y;
        }

        private void OpenGL_preview_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+' || e.KeyChar == '=')
            {
                if (_keyShift) ++PreviewSetting.PosZ;
                else ++PreviewSetting.PosZoom;
            }

            if (e.KeyChar == '-' || e.KeyChar == '_')
            {
                if (_keyShift) --PreviewSetting.PosZ;
                else
                {
                    if (PreviewSetting.PosZoom > 1) --PreviewSetting.PosZoom;
                }
            }
        }

        private void OpenGL_preview_MouseMove(object sender, MouseEventArgs e)
        {
            int deltaX = _oldPosX - e.X;
            int deltaY = _oldPosY - e.Y;

            _oldPosX = e.X;
            _oldPosY = e.Y;

            if (!_move3D) return;

            if (_mouseButton == MouseButtons.Left)
            {
                PreviewSetting.PosX -= deltaX;
                PreviewSetting.PosY += deltaY;
            }

            if (_mouseButton == MouseButtons.Right)
            {
                if (deltaY > 0)
                {

                    --PreviewSetting.PosAngleX;
                }
                else
                {
                    ++PreviewSetting.PosAngleX;
                }

                if (deltaX > 0)
                {
                    --PreviewSetting.PosAngleY;
                }
                else
                {
                    ++PreviewSetting.PosAngleY;
                }
            }
        }

        private void OpenGL_preview_KeyDown(object sender, KeyEventArgs e)
        {
            _keyShift = e.Shift;
        }

        private void OpenGL_preview_KeyUp(object sender, KeyEventArgs e)
        {
            _keyShift = e.Shift;
        }

        private void OpenGL_preview_Resize(object sender, EventArgs e)
        {
            // изменим параметры 
            Gl.glViewport(0, 0, OpenGL_preview.Width, OpenGL_preview.Height);
        }


        private DateTime _dtStart, _dtStop;

        DateTime dtold = DateTime.Now;

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            // обработка "тика" таймера - вызов функции отрисовки 
            _dtStart = DateTime.Now;
            Draw();
            _dtStop = DateTime.Now;


            double milisec = (_dtStop - _dtStart).TotalMilliseconds;

            double refr = 1000/milisec;

            if ((DateTime.Now - dtold).Seconds > 1)
            {
                dtold = DateTime.Now;
                toolStripStatusLabel1.Text = @"FPS: " + refr.ToString("F");

                RefreshElementsForms();

            }
            
            //вычислим разницу времени

            //TODO: доступность кнопки отключиться только если поток задания выключен!!!!!!
        }


        private void Draw()//*OK* // процедура отрисовки 
        {
            #region подготовка вуализации


            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT); // очистка буфера цвета и буфера глубины 
            Gl.glClearColor(0.5f, 0.5f, 0.5f, 1);                                 // устанавливает черный цвет фона

            Gl.glLoadIdentity();                                         // очищение текущей матрицы

            Gl.glPushMatrix();                                           // помещаем состояние матрицы в стек матриц 

            //// перемещаем камеру для более хорошего обзора объекта 
            Gl.glTranslated(PreviewSetting.PosX / 1000.0, PreviewSetting.PosY / 1000.0, PreviewSetting.PosZ / 1000.0);

            ////угловое вращение
            Gl.glRotated(PreviewSetting.PosAngleX, 1, 0, 0);
            Gl.glRotated(PreviewSetting.PosAngleY, 0, 1, 0);
            Gl.glRotated(PreviewSetting.PosAngleZ, 0, 0, 1);

            //TODO: в данном месте учесть пропорции области вывода, что-бы исключить растягивания,при маштабировании



            //Gl.glScaled(preview_setting.posZoom / (p1*1000), preview_setting.posZoom / p2, preview_setting.posZoom / 1000.0);

            // ReSharper disable once PossibleLossOfFraction

            try
            {
                if (WindowState != FormWindowState.Minimized)
                {

                    float aspect = OpenGL_preview.Width / (float)OpenGL_preview.Height;


                    //int p1 = OpenGL_preview.Width;
                    //int p2 = OpenGL_preview.Height;

                    //double n = 1;

                    //if (p2<p1) n = (p1/p2);

                    double scaleX = PreviewSetting.PosZoom / (1000.0 * aspect);
                    double scaleY = PreviewSetting.PosZoom / 1000.0;
                    double scaleZ = PreviewSetting.PosZoom / (1000.0 * aspect);
                    //TODO: тут с пропорциями разобраться, сейчас только XY плоскость нормально отображается
                    Gl.glScaled(scaleX, scaleY, scaleZ);


                }

            }
            catch (Exception)
            {
                
                //throw;
            }

            //// помещаем состояние матрицы в стек матриц 
            Gl.glPushMatrix();

            Gl.glEnable(Gl.GL_BLEND);


            //включение сглаживания линий
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);


            #endregion

            #region Отображение координатной оси

            if (GlobalSetting.RenderSetting.ShowAxes)
            {
                Gl.glLineWidth(2);

                //ось х
                Gl.glColor3f(0.0f, 1f, 0.0f);
                Gl.glBegin(Gl.GL_LINES); //РИСОВАНИЕ ОБЫЧНОЙ ЛИНИИ
                Gl.glVertex3d(0, 0, 0);
                Gl.glVertex3d(10, 0, 0);
                Gl.glVertex3d(10, 0, 0);
                Gl.glVertex3d(9, 1, 0);
                Gl.glVertex3d(10, 0, 0);
                Gl.glVertex3d(9, -1, 0);
                Gl.glEnd();

                //ось y
                Gl.glColor3f(1.0F, 0, 0.0F);
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex3d(0, 0, 0);
                Gl.glVertex3d(0, 10, 0);
                Gl.glVertex3d(0, 10, 0);
                Gl.glVertex3d(1, 9, 0);
                Gl.glVertex3d(0, 10, 0);
                Gl.glVertex3d(-1, 9, 0);
                Gl.glEnd();

                //ось z
                Gl.glColor3f(0.0F, 0, 1.0F);
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex3d(0, 0, 0);
                Gl.glVertex3d(0, 0, 10);
                Gl.glVertex3d(0, 0, 10);
                Gl.glVertex3d(1, 1, 9);
                Gl.glVertex3d(0, 0, 10);
                Gl.glVertex3d(-1, -1, 9);
                Gl.glEnd();

                //Буквы с названием осей
                Gl.glColor3f(0.0f, 1f, 0.0f);
                Gl.glRasterPos3d(12, 0, 0); //координаты расположения текста
                Glut.glutBitmapString(Glut.GLUT_BITMAP_9_BY_15, "X");

                Gl.glColor3f(1.0F, 0, 0.0F);
                Gl.glRasterPos3d(0, 12, 0); //координаты расположения текста
                Glut.glutBitmapString(Glut.GLUT_BITMAP_9_BY_15, "Y");

                Gl.glColor3f(0.0F, 0, 1.0F);
                Gl.glRasterPos3d(0, 0, 12); //координаты расположения текста
                Glut.glutBitmapString(Glut.GLUT_BITMAP_9_BY_15, "Z");
            }

            #endregion

            #region Отображение координатной сетки

            if (GlobalSetting.RenderSetting.ShowGrid)
            {
                Gl.glLineWidth(0.1f);
                Gl.glColor3f(0, 0, 0.5F);
                Gl.glBegin(Gl.GL_LINES);
                
                int gridStep = GlobalSetting.RenderSetting.GridSize;
                int gridStartX = GlobalSetting.RenderSetting.GridStartX;
                int gridStartY = GlobalSetting.RenderSetting.GridStartY;
                int gridStopX = GlobalSetting.RenderSetting.GridStartX + GlobalSetting.RenderSetting.GridSizeX;
                int gridStopY = GlobalSetting.RenderSetting.GridStartY + GlobalSetting.RenderSetting.GridSizeY;

                for (int gX = gridStartX; gX < gridStopX + 1; gX += gridStep)
                {
                    Gl.glVertex3d(gX, gridStartY, 0);
                    Gl.glVertex3d(gX, gridStopY, 0);
                }

                for (int gY = gridStartY; gY < gridStopY + 1; gY += gridStep)
                {
                    Gl.glVertex3d(gridStartX, gY, 0);
                    Gl.glVertex3d(gridStopX, gY, 0);
                }
                
                Gl.glEnd();
            }

            #endregion

            #region Матрица поверхности

            if (GlobalSetting.RenderSetting.ShowScanedGrid)
            {
                //отбразим точки матрицы
                Gl.glColor3f(1.000f, 0.498f, 0.314f);
                Gl.glPointSize(10.0F);
                Gl.glBegin(Gl.GL_POINTS);


                //int maxX = MatrixArray.matrix2.GetLength(0);
                //int maxY = MatrixArray.matrix2.GetLength(1);

                for (int x = 0; x < ScanSurface.CountPointX; x++)
                {
                    for (int y = 0; y < ScanSurface.CountPointY; y++)
                    {
                //        if (MatrixArray.matrix2[x, y] == null) continue;
                        
                //        //рисуем точку
                        Gl.glVertex3d(ScanSurface.Matrix[x, y].PosX, ScanSurface.Matrix[x, y].PosY, ScanSurface.Matrix[x, y].PosZ);
                    }
                }

                Gl.glEnd();

                //Добавим связи между точками
                Gl.glColor3f(0.678f, 1.000f, 0.184f);
                Gl.glLineWidth(0.4f);
                Gl.glBegin(Gl.GL_LINES);

                for (int x = 0; x < ScanSurface.CountPointX; x++)
                {
                    for (int y = 0; y < ScanSurface.CountPointY; y++)
                    {
                        //if (MatrixArray.matrix2[x, y] == null) continue;

                        if (x > 0)
                        {
                            //line 1
                            Gl.glVertex3d(ScanSurface.Matrix[x, y].PosX, ScanSurface.Matrix[x, y].PosY, ScanSurface.Matrix[x, y].PosZ);
                            Gl.glVertex3d(ScanSurface.Matrix[x - 1, y].PosX, ScanSurface.Matrix[x - 1, y].PosY, ScanSurface.Matrix[x - 1, y].PosZ);
                        }

                        if (x < ScanSurface.CountPointX - 1)
                        {
                            //line2
                            Gl.glVertex3d(ScanSurface.Matrix[x, y].PosX, ScanSurface.Matrix[x, y].PosY, ScanSurface.Matrix[x, y].PosZ);
                            Gl.glVertex3d(ScanSurface.Matrix[x + 1, y].PosX, ScanSurface.Matrix[x + 1, y].PosY, ScanSurface.Matrix[x + 1, y].PosZ);
                        }

                        if (y > 0)
                        {
                            //line 3
                            Gl.glVertex3d(ScanSurface.Matrix[x, y].PosX, ScanSurface.Matrix[x, y].PosY, ScanSurface.Matrix[x, y].PosZ);
                            Gl.glVertex3d(ScanSurface.Matrix[x, y - 1].PosX, ScanSurface.Matrix[x, y - 1].PosY, ScanSurface.Matrix[x, y - 1].PosZ);
                        }

                        if (y < ScanSurface.CountPointY - 1)
                        {
                            //line4
                            Gl.glVertex3d(ScanSurface.Matrix[x, y].PosX, ScanSurface.Matrix[x, y].PosY, ScanSurface.Matrix[x, y].PosZ);
                            Gl.glVertex3d(ScanSurface.Matrix[x, y + 1].PosX, ScanSurface.Matrix[x, y + 1].PosY, ScanSurface.Matrix[x, y + 1].PosZ);
                        }
                    }
                }
                Gl.glEnd();
            }

            #endregion

            #region Отображение инструмента

            if (GlobalSetting.RenderSetting.ShowCursor)
            {

                //нарисуем курсор
                double startX = (double)Controller.INFO.AxesX_PositionMM;
                double startY = (double)Controller.INFO.AxesY_PositionMM;
                double startZ = (double)Controller.INFO.AxesZ_PositionMM;

                Gl.glColor3f(1.000f, 1.000f, 0.000f);
                Gl.glLineWidth(3);
                Gl.glBegin(Gl.GL_LINES);

                Gl.glVertex3d(startX, startY, startZ);
                Gl.glVertex3d(startX, startY, startZ + 4);
                Gl.glVertex3d(startX - 1, startY - 1, startZ + 2);
                Gl.glVertex3d(startX - 1, startY + 1, startZ + 2);
                Gl.glVertex3d(startX + 1, startY - 1, startZ + 2);
                Gl.glVertex3d(startX + 1, startY + 1, startZ + 2);
                Gl.glVertex3d(startX + 1, startY + 1, startZ + 2);
                Gl.glVertex3d(startX - 1, startY + 1, startZ + 2);
                Gl.glVertex3d(startX + 1, startY - 1, startZ + 2);
                Gl.glVertex3d(startX - 1, startY - 1, startZ + 2);
                Gl.glVertex3d(startX - 1, startY - 1, startZ + 2);
                Gl.glVertex3d(startX, startY, startZ);
                Gl.glVertex3d(startX + 1, startY + 1, startZ + 2);
                Gl.glVertex3d(startX, startY, startZ);
                Gl.glVertex3d(startX + 1, startY - 1, startZ + 2);
                Gl.glVertex3d(startX, startY, startZ);
                Gl.glVertex3d(startX - 1, startY + 1, startZ + 2);
                Gl.glVertex3d(startX, startY, startZ);

                Gl.glEnd();
            }

            #endregion

            #region Отображение готовых инструкций для контроллера


            if (DataLoader.status == DataLoader.eDataSetStatus.none)
            {
                Gl.glLineWidth(0.3f);
                Gl.glBegin(Gl.GL_LINE_STRIP);
                //TODO: источником данных теперь будет являться другое место
                foreach (DataRow vv in DataLoader.DataRows)
                {
                    //Gl.glLineWidth(0.1f);
                    if (vv.Machine.NumGkode == 1) Gl.glColor3f(0, 255, 0); else Gl.glColor3f(255, 0, 0);

                    //координаты следующей точки
                    float pointX = (float)vv.POS.X;
                    float pointY = (float)vv.POS.Y;
                    float pointZ = (float)vv.POS.Z;

                    //добавление смещения G-кода
                    if (Controller.CorrectionPos.useCorrection)
                    {
                        //// применение пропорций
                        //pointX *= Setting.koeffSizeX;
                        //pointY *= Setting.koeffSizeY;

                        //применение смещения
                        pointX += (float)Controller.CorrectionPos.deltaX;
                        pointY += (float)Controller.CorrectionPos.deltaY;

                        //применение матрицы поверхности детали
                        if (Controller.CorrectionPos.UseMatrix)
                        {
                            pointZ += ScanSurface.GetPosZ(pointX, pointY);
                        }

                        pointZ += (float)Controller.CorrectionPos.deltaZ;

                    }

                    Gl.glVertex3d((double)pointX, (double)pointY, (double)pointZ);
                    Gl.glLineWidth(0.4f);
                }

                Gl.glEnd();                





                //******Вывод выделенной траектории***********************
                Gl.glLineWidth(3.0f);
                Gl.glColor3f(1, 1, 1);
                Gl.glBegin(Gl.GL_LINE_STRIP);
                //TODO: источником данных теперь изменил...
                foreach (DataRow vv in DataLoader.DataRows)
                {

                    //координаты следующей точки
                    double pointX = (double)vv.POS.X;
                    double pointY = (double)vv.POS.Y;
                    double pointZ = (double)vv.POS.Z;

                    //добавление смещения G-кода
                    if (Controller.CorrectionPos.useCorrection)
                    {
                        //// применение пропорций
                        //pointX *= Setting.koeffSizeX;
                        //pointY *= Setting.koeffSizeY;

                        //применение смещения
                        pointX += (double)Controller.CorrectionPos.deltaX;
                        pointY += (double)Controller.CorrectionPos.deltaY;
                        pointZ += (double)Controller.CorrectionPos.deltaZ;

                        ////применение матрицы поверхности детали
                        //if (Setting.deltaFeed)
                        //{
                        //    pointZ += GetDeltaZ(pointX, pointY);
                        //}
                    }





                    


                ////    //добавим тут фильт

                ////    if (Task.StatusTask == statusVariant.Waiting)
                ////    {
                    int numSelectStart = DataLoader.SelectedRowStart-1;
                    int numSelectStop = DataLoader.SelectedRowStop-1;

                    if (vv.numberRow >= numSelectStart && vv.numberRow <= numSelectStop)
                    {
                        Gl.glVertex3d(pointX, pointY, pointZ);
                    }

                    ////    }
                    ////    else
                    ////    {
                    // Тут выделяется только одна линия из траектории
                    //int numSelect = DataCode.SelectedRow;
                    //if (vv.indexStr == (numSelect - 1))
                    //{
                    //    Gl.glVertex3d(pointX, pointY, pointZ);
                    //}

                    //if (vv.indexStr == (numSelect))
                    //{
                    //    Gl.glVertex3d(pointX, pointY, pointZ);
                    //}
                    ////    }
                }
                Gl.glEnd();

            }


            //////////////отобразим выделенную одну или несколько линий
            ////////////GKOD_ready poi1 = null;
            ////////////GKOD_ready poi2 = null;


            ////////////int numSelect = 0;

            ////////////if (Task.StatusTask == EStatusTask.Waiting)
            ////////////{
            ////////////    numSelect = Task.indexLineTask+1;
            ////////////}
            ////////////else
            ////////////{
            ////////////    numSelect = _cnc.NumberComleatedInstructions+1;
            ////////////}

            ////////////foreach (GKOD_ready vv in GKODready)
            ////////////{

            ////////////    //координаты следующей точки
            ////////////    double pointX = (double)vv.X;
            ////////////    double pointY = (double)vv.Y;
            ////////////    double pointZ = (double)vv.Z;

            ////////////    //добавление смещения G-кода
            ////////////    if (Correction)
            ////////////    {
            ////////////        // применение пропорций
            ////////////        pointX *= koeffSizeX;
            ////////////        pointY *= koeffSizeY;

            ////////////        //применение смещения
            ////////////        pointX += deltaX;
            ////////////        pointY += deltaY;
            ////////////        pointZ += deltaZ;

            ////////////        //применение матрицы поверхности детали
            ////////////        if (deltaFeed)
            ////////////        {
            ////////////            pointZ += GetDeltaZ(pointX, pointY);
            ////////////        }
            ////////////    }

            ////////////    //выделим жирным текущую линию
            ////////////    if (vv.numberInstruct == (numSelect - 1))
            ////////////    {
            ////////////        poi1 = new GKOD_ready(vv.numberInstruct, vv.spindelON, (decimal)pointX, (decimal)pointY, (decimal)pointZ, vv.speed, vv.workspeed);
            ////////////    }

            ////////////    if (vv.numberInstruct == (numSelect))
            ////////////    {
            ////////////        poi2 = new GKOD_ready(vv.numberInstruct, vv.spindelON, (decimal)pointX, (decimal)pointY, (decimal)pointZ, vv.speed, vv.workspeed);
            ////////////    }
            ////////////}


            ////////////if (poi1 != null && poi2 != null)
            ////////////{
            ////////////    Gl.glLineWidth(3.0f);
            ////////////    Gl.glColor3f(1, 1, 1);
            ////////////    Gl.glBegin(Gl.GL_LINE_STRIP);

            ////////////    Gl.glVertex3d((double)poi1.X, (double)poi1.Y, (double)poi1.Z);
            ////////////    Gl.glVertex3d((double)poi2.X, (double)poi2.Y, (double)poi2.Z);

            ////////////    Gl.glEnd();           
            ////////////}





            #endregion

            #region Отображение границ рабочего поля

            if (GlobalSetting.RenderSetting.ShowWorkArea)
            {
                //отобразим лишь 4 линии
                
            double grateXmin = GlobalSetting.ControllerSetting.WorkSizeXm;
            double grateXmax = GlobalSetting.ControllerSetting.WorkSizeXp;
            double grateYmin = GlobalSetting.ControllerSetting.WorkSizeYm;
            double grateYmax = GlobalSetting.ControllerSetting.WorkSizeYp;

                Gl.glLineWidth(4.0f);

                Gl.glColor3f(0.541f, 0.169f, 0.886f);

                Gl.glBegin(Gl.GL_LINE_STRIP); //РИСОВАНИЕ ОБЫЧНОЙ ЛИНИИ

                Gl.glVertex3d(grateXmin, grateYmin, 0);
                Gl.glVertex3d(grateXmax, grateYmin, 0);
                Gl.glVertex3d(grateXmax, grateYmax, 0);
                Gl.glVertex3d(grateXmin, grateYmax, 0);
                Gl.glVertex3d(grateXmin, grateYmin, 0);

                Gl.glEnd();


            }


            #endregion


            #region DEBUG

            ////Gl.glBegin(Gl.GL_TRIANGLES);

            ////Gl.glColor3f(1.0f, 0.0f, 0.0f);                      // Красный
            ////Gl.glVertex3d(0.0f, 1.0f, 0.0f);                  // Верх треугольника (Передняя)
            ////Gl.glColor3f(0.0f, 1.0f, 0.0f);                      // Зеленный
            ////Gl.glVertex3d(-1.0f, -1.0f, 1.0f);                  // Левая точка
            ////Gl.glColor3f(0.0f, 0.0f, 1.0f);                      // Синий
            ////Gl.glVertex3d(1.0f, -1.0f, 1.0f);                  // Правая точка

            ////Gl.glEnd();

            #endregion



            #region Завершение отрисовки

            Gl.glDisable(Gl.GL_BLEND);
            //выключение сглаживания линий
            Gl.glDisable(Gl.GL_LINE_SMOOTH);
            // завершаем отрисовку примитивов 
            Gl.glEnd();
            // возвращаем состояние матрицы 
            Gl.glPopMatrix();
            // отрисовываем геометрию 
            Gl.glFlush();
            // обновляем состояние элемента 
            OpenGL_preview.Invalidate();

            #endregion

            ////TODO: перенести от сюда, т.е. очень часто выполняется без надобности
            lb3DPosView.Text = @"Позиция в 3D: x=" + PreviewSetting.PosX 
                + @" y=" + PreviewSetting.PosY 
                + @" z=" + PreviewSetting.PosZ 
                + @" увеличение: " + PreviewSetting.PosZoom;
            posAngleX.Text = PreviewSetting.PosAngleX + @"°";
            posAngleY.Text = PreviewSetting.PosAngleY + @"°";
            posAngleZ.Text = PreviewSetting.PosAngleZ + @"°";
        }


        




        private void posAngleXm_Click(object sender, EventArgs e)
        {
            --PreviewSetting.PosAngleX;
        }

        private void posAngleXp_Click(object sender, EventArgs e)
        {
            ++PreviewSetting.PosAngleX;
        }

        private void posAngleYp_Click(object sender, EventArgs e)
        {
            ++PreviewSetting.PosAngleY;
        }

        private void posAngleYm_Click(object sender, EventArgs e)
        {
            --PreviewSetting.PosAngleY;
        }

        private void posAngleZp_Click(object sender, EventArgs e)
        {
            ++PreviewSetting.PosAngleZ;
        }

        private void posAngleZm_Click(object sender, EventArgs e)
        {
            --PreviewSetting.PosAngleZ;
        }

        private void btDefaulPreview_Click(object sender, EventArgs e)
        {
            PreviewSetting.PosAngleX = -70;
            PreviewSetting.PosAngleY = 0;
            PreviewSetting.PosAngleZ = -20;
            PreviewSetting.PosX = -63;
            PreviewSetting.PosY = -30;
            PreviewSetting.PosZ = -200;
            PreviewSetting.PosZoom = 1;
        }

        private void posAngleX_Click(object sender, EventArgs e)
        {
            PreviewSetting.PosAngleX = 0;
        }

        private void posAngleY_Click(object sender, EventArgs e)
        {
            PreviewSetting.PosAngleY=0;

        }

        private void posAngleZ_Click(object sender, EventArgs e)
        {
            PreviewSetting.PosAngleZ=0;

        }

        #endregion

        #region OTHER

        // вывод лога
        void AddLog(string _text = "")
        {
            if (_text == null) return;
            listBoxLog.Items.Add(_text);
        }







        
        
        //ОТЛАДКА генератора ШИМ
        private void SendSignal()
        {
            if (radioButton_off.Checked)
            {
                Controller.SendBinaryData(BinaryData.pack_B5(checkBox18.Checked, (int)numericUpDown7.Value, BinaryData.TypeSignal.None, (int)numericUpDown8.Value));
            }

            if (radioButton_Hz.Checked)
            {
                Controller.SendBinaryData(BinaryData.pack_B5(checkBox18.Checked, (int)numericUpDown7.Value, BinaryData.TypeSignal.Hz, (int)numericUpDown8.Value));
            }

            if (radioButton_RC.Checked)
            {
                Controller.SendBinaryData(BinaryData.pack_B5(checkBox18.Checked, (int)numericUpDown7.Value, BinaryData.TypeSignal.RC, (int)numericUpDown8.Value));
            }            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SendSignal();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            numericUpDown8.Value = trackBar1.Value;

            SendSignal();

           // _cnc.SendBinaryData(BinaryData.pack_B5(checkBox18.Checked, (int)numericUpDown7.Value, checkBox19.Checked, (int)numericUpDown8.Value));
        }






        private void btToBuffer_Click(object sender, EventArgs e)
        {
            string ttx = "";

            foreach (var item in listBoxLog.Items)
            {
                ttx += item.ToString() + "\r\n";
            }

            Clipboard.SetText(ttx);

        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            SettingForm frm = new SettingForm();
            frm.ShowDialog();
            RefreshElementsForms(true);
        }

 



        #endregion

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = (int)numericUpDown8.Value;

            SendSignal();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown8.Maximum = numericUpDown1.Value;
            trackBar1.Maximum = (int)numericUpDown1.Value;
        }

        private void webcameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_webCameraForms == null)
            {
                _webCameraForms = new webCamera();
                _webCameraForms.FormClosed += new FormClosedEventHandler(webCameraForms_FormClosed);
                _webCameraForms.Show();
            }
            else
            {
                _webCameraForms.Show();
            }

        }


        private void webCameraForms_FormClosed(object sender, FormClosedEventArgs e)
        {
            _webCameraForms = null;
        }

        private void fromBufferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataLoader.ReadFromBuffer();
        }





        private ScanSurfaceForm scanSurfaceForm = null;

        private void scanSurfaceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (scanSurfaceForm == null)
            {
                scanSurfaceForm = new ScanSurfaceForm();
                scanSurfaceForm.FormClosed += new FormClosedEventHandler(scanSurfaceForm_FormClosed);
                scanSurfaceForm.Show();
            }
            else
            {
                scanSurfaceForm.Show();
            }
        }

        private void scanSurfaceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            scanSurfaceForm = null;
        }

        private void menuRuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalSetting.AppSetting.Language = Languages.Russian;
            GlobalSetting.SaveToFile();
            RefreshElementsForms(true);
        }

        private void menuEnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalSetting.AppSetting.Language = Languages.English;
            GlobalSetting.SaveToFile();
            RefreshElementsForms(true);
        }

        private void btSendSetting_Click(object sender, EventArgs e)
        {
            Controller.SendBinaryData(BinaryData.pack_D3());
            Controller.SendBinaryData(BinaryData.pack_AB());
            Controller.SendBinaryData(BinaryData.pack_9F(GlobalSetting.ControllerSetting.allowMotorUse,
                GlobalSetting.ControllerSetting.useSensorTools, GlobalSetting.ControllerSetting.AxleX.CountPulse,
                GlobalSetting.ControllerSetting.AxleY.CountPulse, GlobalSetting.ControllerSetting.AxleZ.CountPulse,
                GlobalSetting.ControllerSetting.AxleA.CountPulse));



            Controller.SendBinaryData(BinaryData.pack_BF(GlobalSetting.ControllerSetting.AxleX.MaxSpeed,
                GlobalSetting.ControllerSetting.AxleY.MaxSpeed, GlobalSetting.ControllerSetting.AxleZ.MaxSpeed,
                GlobalSetting.ControllerSetting.AxleA.MaxSpeed));

            Controller.SendBinaryData(BinaryData.pack_B5());
            Controller.SendBinaryData(BinaryData.pack_B6());
            Controller.SendBinaryData(BinaryData.pack_C2());
            Controller.SendBinaryData(BinaryData.pack_9D());
            Controller.SendBinaryData(BinaryData.pack_9E(0x01));

            /*
             *  D3 - ok
                AB - ok
                9F - ok
                A0
                A1
                BF - ok
                B5 - ok
                B6 - ok
                C2 - ok
                9D - ok
                9E - ok
                */




            //Controller.SendBinaryData(BinaryData.pack_B5(checkBox18.Checked, (int)numericUpDown7.Value, BinaryData.TypeSignal.None, (int)numericUpDown8.Value));


        }

        private void checkBoxDisableControl_CheckedChanged(object sender, EventArgs e)
        {
            GlobalSetting.DISSABLE_CHECK = checkBoxDisableControl.Checked;
        }

    }

    /// <summary>
    /// Класс для хранения параметров предпросмотра в окне OpenGL
    /// </summary>
    public class Preview3DSetting
    {
        // Параметры просмотра в 3D объекта
        //public int SizeHeight = 0;
        //public int SizeWidth = 0;

        public int PosX = 0, PosY = 0, PosZ = -300;
        public int PosAngleX = 10, PosAngleY = 0, PosAngleZ = 0;
        public int PosZoom = 3;



        public bool ShowInstrument = false;
        public bool ShowGrid = false;
        public bool ShowMatrix = false;
        public bool ShowAxes = true;

        public int GridXstart = 0;
        public int GridXend = 100;
        public int GridYstart = 0;
        public int GridYend = 100;
        public int GrigStep = 10;

    }




    /// <summary>
    /// Виды статусов выполнения задания
    /// </summary>
    public enum statusVariant { Waiting = 0, Starting, Working, Paused, Stop };

    /// <summary>
    /// Класс для работы с заданием для контроллера
    /// </summary>
    public static class Task
    {
        /// <summary>
        /// Сво-во для определения режима работы
        /// </summary>
        public static statusVariant StatusTask = statusVariant.Waiting;

        ///// <summary>
        ///// Номер строки с заданием для выполнения
        ///// </summary>
        //public static int indexLineTask = -1;

        ///// <summary>
        ///// Количество выделенных строк (если выделено более 1-й строки, то нужно выполнить задание только по этим строкам)
        ///// </summary>
        //public static int countSelectLineTask = 0;


        /// <summary>
        /// Начальная позиция для выполнения
        /// </summary>
        public static int posCodeStart = -1;
        /// <summary>
        /// Конечная позиция для выполнения
        /// </summary>
        public static int posCodeEnd = -1;
        /// <summary>
        /// Текущая позиция выполнения
        /// </summary>
        public static int posCodeNow = -1;
    }



    /// <summary>
    /// Инструкция для станка
    /// </summary>
    public class GKOD_Command
    {
        public bool changeInstrument; // если true - то необходима остановка, для смены инструмента
        public int numberInstrument;  // собственно номер инструмента

        public bool needPause;        // необходимость паузы
        public int timeSeconds;       // длительность паузы, если 0 - то ожидание от пользователя о продолжении

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
 
        public int speed;       // скорость
        public bool spindelON;  // вкл. шпинделя
        public int numberInstruct;     // номер инструкции
        public bool workspeed; // true=G1 false=G0
        public decimal diametr; // диаметр инструмента
        public int angleVectors; //угол между отрезками, образуемыми этой, предыдущей и следующей точкой
        public decimal Distance; //растояние данного отрезка в мм.
        public int indexStr; //номер строки для сопоставления, с пользовательским списком
        
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public GKOD_Command()
        {
            changeInstrument = false;
            numberInstrument = 0;
            needPause        = false;
            timeSeconds      = 0;

            X = 0;
            Y = 0;
            Z = 0;
            spindelON      = false;
            numberInstruct = 0;
            speed          = 0;
            workspeed      = false;
            diametr = 0;
            angleVectors = 0;
            Distance = 0;
            indexStr = 0;
        }

        public GKOD_Command(int _numberInstruct, bool _spindelON, decimal _X, decimal _Y, decimal _Z, int _speed, bool _workspeed, bool _changeInstrument = false, int _numberInstrument = 0, bool _needPause = false, int _timeSeconds = 0, decimal _diametr = 0,int _index = 0)
        {
            X = _X;
            Y = _Y;
            Z = _Z;
            spindelON = _spindelON;
            numberInstruct = _numberInstruct;
            speed = _speed;
            workspeed = _workspeed;

            changeInstrument = _changeInstrument;
            numberInstrument = _numberInstrument;
            needPause        = _needPause;
            timeSeconds      = _timeSeconds;
            diametr = _diametr;
            indexStr = _index;
        }

        //Конструктор на основе существующей команды
        public GKOD_Command(GKOD_Command _cmd)
        {
            X = _cmd.X;
            Y = _cmd.Y;
            Z = _cmd.Z;
            spindelON = _cmd.spindelON;
            numberInstruct = _cmd.numberInstruct;
            speed = _cmd.speed;
            workspeed = _cmd.workspeed;

            changeInstrument = _cmd.changeInstrument;
            numberInstrument = _cmd.numberInstrument;
            needPause = _cmd.needPause;
            timeSeconds = _cmd.timeSeconds;
            diametr = _cmd.diametr;
            indexStr = _cmd.indexStr;
        }


    }


    /// <summary>
    /// Результат парсинга G-кода
    /// </summary>
    public class GKOD_resultParse
    {
        public string FullStr = "";
        public string GoodStr = ""; //для распознанных
        public string BadStr  = ""; //для нераспознанных

        public GKOD_resultParse(string _FullStr, string _GoodStr, string _BadStr)
        {
            FullStr = _FullStr;
            GoodStr = _GoodStr;
            BadStr = _BadStr;
        }
    }




}
