using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace CNC_Controller
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Главный класс для работы со станком
        /// </summary>
        private CONTROLLER _cnc;

        #region Инициализация/заршение работы формы

        public MainForm()
        {
            InitializeComponent();

            // 1 Подключение событий от контроллера
            _cnc = new CONTROLLER();
            _cnc.LoadSetting();
            _cnc.WasConnected += CncConnect;
            _cnc.WasDisconnected += CncDisconnect;
            _cnc.NewDataFromController += CncNewData;
            _cnc.Message += CncMessage;

            // 2
            OpenGL_preview.InitializeContexts();

            // подключение обработчика, колесика мышки
            MouseWheel += this_MouseWheel;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Init3D();

            Task.posCodeNow = -1; //пока нет никаких заданий
            Task.StatusTask = EStatusTask.Waiting; //пока нет заданий для выполнения

            toolStripStatus.Text = @"";
            RefreshElementsForms();


            //TODO: DEBUG
            GeneratorCode frm = new GeneratorCode(this);
            frm.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cnc.Connected)
            {
                MessageBox.Show(@"Для завершения работы с программой, необходимо отключиться от ЧПУ контроллера!");
                e.Cancel = true;
            }
            else
            {
                //Отменим подписки
                _cnc.WasConnected -= CncConnect;
                _cnc.WasDisconnected -= CncDisconnect;
                _cnc.NewDataFromController -= CncNewData;
                _cnc.Message -= CncMessage;
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
            Invoke((MethodInvoker)RefreshElementsForms);

            //сдвинем границы
            if (ShowGrate)
            {
                if ((double)deviceInfo.AxesX_PositionMM < grateXmin) grateXmin = (double)deviceInfo.AxesX_PositionMM;
                if ((double)deviceInfo.AxesX_PositionMM > grateXmax) grateXmax = (double)deviceInfo.AxesX_PositionMM;

                if ((double)deviceInfo.AxesY_PositionMM < grateYmin) grateYmin = (double)deviceInfo.AxesY_PositionMM;
                if ((double)deviceInfo.AxesY_PositionMM > grateYmax) grateYmax = (double)deviceInfo.AxesY_PositionMM;
            }
        }

        //событие о прекращении связи
        private void CncDisconnect(object sender, DeviceEventArgsMessage e)
        {
            Invoke((MethodInvoker)RefreshElementsForms);
        }

        //событие успешного подключения
        private void CncConnect(object sender)
        {
            Invoke((MethodInvoker)RefreshElementsForms);
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


            if (!checkBoxManualMove.Checked) return;  //проверка флажка "управление с NUM-pad"

            if (!_cnc.TestAllowActions()) return; //Проверка что контроллер доступен

            if (Task.StatusTask != EStatusTask.Waiting) return; //Проверка что нет выполняемых задач в данный момент

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

                _cnc.StartManualMove(_x, _y, _z, (int)numericUpDownManualSpeed.Value);
            }
            else
            {
                //нет ни одной нажатой
                if (!_manualMoveButtonPressed) return;
                _cnc.StopManualMove();
                _manualMoveButtonPressed = false;
            }
        }

        #endregion

        #region События от элементов на форме

        private void RefreshElementsForms()
        {
            if (_cnc.Connected)
            {
                bt_ConnDiskonect.Image = btConnect.Image;
                bt_ConnDiskonect.Text = @"Отключиться от контроллера";
                toolStripStatus.ForeColor = Color.Green;

            }
            else
            {
                bt_ConnDiskonect.Image = bt_disconnect.Image;
                bt_ConnDiskonect.Text = @"Подключиться к контроллеру";
                toolStripStatus.ForeColor = Color.Red;
            }

            panelPosition.Enabled = _cnc.Connected;
            panelControl1.Enabled = _cnc.Connected;
            buttonESTOP.Enabled   = _cnc.Connected;
            buttonSpindel.Enabled = _cnc.Connected;


            labelSpeed.Text = _cnc.ShpindelMoveSpeed.ToString() + @" мм./мин.";
            toolStripStatusLabelNumberInstruction.Text = @"№ инструкции: " + _cnc.NumberComleatedInstructions;
            

            if (!_cnc.Connected) return;

            if (Task.StatusTask == EStatusTask.TaskStart) toolStripStatusLabel1.Text = @"Запуск задания";
            if (Task.StatusTask == EStatusTask.TaskPaused) toolStripStatusLabel1.Text = @"Пауза выполнения";
            if (Task.StatusTask == EStatusTask.TaskStop) toolStripStatusLabel1.Text = @"Остановка задания";
            if (Task.StatusTask == EStatusTask.TaskWorking) toolStripStatusLabel1.Text = @"Выполнение задания";
            if (Task.StatusTask == EStatusTask.Waiting) toolStripStatusLabel1.Text = @"ожидание";



            numPosX.Value = deviceInfo.AxesX_PositionMM;
            numPosY.Value = deviceInfo.AxesY_PositionMM;
            numPosZ.Value = deviceInfo.AxesZ_PositionMM;

            if (_cnc.EstopOn)
            {
                buttonESTOP.BackColor = Color.Red;
                buttonESTOP.ForeColor = Color.White;
            }
            else
            {
                buttonESTOP.BackColor = Color.FromName("Control");
                buttonESTOP.ForeColor = Color.Black;
            }


            if (_cnc.SpindelOn)
            {
                buttonSpindel.BackColor = Color.Green;
                buttonSpindel.ForeColor = Color.White;
            }
            else
            {
                buttonSpindel.BackColor = Color.FromName("Control");
                buttonSpindel.ForeColor = Color.Black;
            }



            labelXmax.ImageIndex = deviceInfo.AxesX_LimitMax ? 2 : 0;
            labelXmin.ImageIndex = deviceInfo.AxesX_LimitMin ? 2 : 0;
            labelYmax.ImageIndex = deviceInfo.AxesY_LimitMax ? 2 : 0;
            labelYmin.ImageIndex = deviceInfo.AxesY_LimitMin ? 2 : 0;
            labelZmax.ImageIndex = deviceInfo.AxesZ_LimitMax ? 2 : 0;
            labelZmin.ImageIndex = deviceInfo.AxesZ_LimitMin ? 2 : 0;


            //***************

            //DEBUG:
            SuperByte bb14 = new SuperByte(deviceInfo.rawData[14]);

            checkBoxB0.Checked = bb14.Bit0;
            checkBoxB1.Checked = bb14.Bit1;
            checkBoxB2.Checked = bb14.Bit2;
            checkBoxB3.Checked = bb14.Bit3;
            checkBoxB4.Checked = bb14.Bit4;
            checkBoxB5.Checked = bb14.Bit5;
            checkBoxB6.Checked = bb14.Bit6;
            checkBoxB7.Checked = bb14.Bit7;


            SuperByte bb15 = new SuperByte(deviceInfo.rawData[15]);

            checkBox9.Checked = bb15.Bit7;
            checkBox8.Checked = bb15.Bit6;
            checkBox7.Checked = bb15.Bit5;
            checkBox6.Checked = bb15.Bit4;
            checkBox5.Checked = bb15.Bit3;
            checkBox4.Checked = bb15.Bit2;
            checkBox3.Checked = bb15.Bit1;
            checkBox2.Checked = bb15.Bit0;


            SuperByte bb19 = new SuperByte(deviceInfo.rawData[19]);

            checkBox10.Checked = bb19.Bit0;
            checkBox11.Checked = bb19.Bit1;
            checkBox12.Checked = bb19.Bit2;
            checkBox13.Checked = bb19.Bit3;
            checkBox14.Checked = bb19.Bit4;
            checkBox15.Checked = bb19.Bit5;
            checkBox16.Checked = bb19.Bit6;
            checkBox17.Checked = bb19.Bit7;

            // end debug


            // Кнопки запуска остановки заданий
            groupBoxWorking.Enabled = _cnc.Connected;

            if (_cnc.Connected)
            {
                if (TaskTimer.Enabled)
                {
                    buttonStartTask.Enabled = false;

                    if (Task.StatusTask == EStatusTask.TaskPaused)
                    {
                        btStopTask.Enabled = false;
                        buttonPauseTask.Enabled = true;
                    }
                    else
                    {
                        btStopTask.Enabled = true;
                        buttonPauseTask.Enabled = true;     
                    }
                }
                else //таймер выполнения задания выключен
                {
                    buttonStartTask.Enabled = true;
                    btStopTask.Enabled = false;
                    buttonPauseTask.Enabled = false;
                }

                if (Task.StatusTask == EStatusTask.Waiting)
                {
                    buttonXtoZero.Enabled = true;
                    buttonYtoZero.Enabled = true;
                    buttonZtoZero.Enabled = true;
                }
                else
                {
                    buttonXtoZero.Enabled = false;
                    buttonYtoZero.Enabled = false;
                    buttonZtoZero.Enabled = false;
                }



                if (Task.StatusTask == EStatusTask.TaskWorking)
                {
                    toolStripProgressBar.Value = _cnc.NumberComleatedInstructions;
                    //listGkodeForUser.Rows[_cnc.NumberComleatedInstructions].Selected = true;
                    //TODO: переделать алгоритм, иначе это изменение сбивает выделенный диапазон
                    //listGkodeCommand.SelectedIndex = _cnc.NumberComleatedInstructions;
                }
            }
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
 
        private void btConnect_Click(object sender, EventArgs e)
        {
            _cnc.Connect();
        }

        private void bt_disconnect_Click(object sender, EventArgs e)
        {
            _cnc.Disconnect();
        }

        private void bt_ConnDiskonect_Click(object sender, EventArgs e)
        {
            if (_cnc.Connected)
            {
                _cnc.Disconnect();
            }
            else
            {
                _cnc.Connect();
            }
        }

        private void buttonShowKeyInfo_Click(object sender, EventArgs e)
        {
            ManualControl kf = new ManualControl(ref _cnc);
            kf.Show();
        }




        /// <summary>
        /// Преобразование строки, в список строк, с разделением параметров
        /// </summary>
        /// <param name="value">Строка с командами</param>
        /// <returns>Список команд в строке по раздельности</returns>
        private List<string> parserGkodeLine(string value)
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
                        collectCommand = false;
                    }

                    collectCommand = true;
                    lcmd.Add("");
                }

                if (collectCommand && symb != ' ') lcmd[inx] += symb.ToString();
            }

            return lcmd;
        }

        /// <summary>
        /// Быстрый парсинг строки с G-кодом (только для визуальной части, проверка кие коды выполняем, а какие нет) 
        /// </summary>
        /// <param name="value">строка с G-кодом</param>
        public GKOD_resultParse parseStringCode(string value)
        {
            GKOD_resultParse result = null;

            // 1) распарсим строку
            List<string> lcmd = parserGkodeLine(value);

            string sGoodsCmd = "";
            string sBadCmd = "";

            // 2) проанализируем список команд, и разберем команды на те которые знаем и не знаем
            for (int i = 0; i < lcmd.Count; i++)
            {
                string sCommd = lcmd[i].Substring(0, 1).Trim().ToUpper();
                string sValue = lcmd[i].Substring(1).Trim().ToUpper();

                bool good = false;

                if (sCommd == "G") 
                {
                    //скорости движения
                    if (sValue == "0" || sValue == "00") good = true;
                    if (sValue == "1" || sValue == "01") good = true;
                    // пауза в работе
                    if (sValue == "4" || sValue == "04")
                    {
                        if ((i + 1) < lcmd.Count)
                        {
                            //проверим что есть ещё параметр "P"
                            if (lcmd[i + 1].Substring(0, 1).ToUpper() == "P")
                            {
                                sGoodsCmd += lcmd[i].Trim().ToUpper() + " " + lcmd[i + 1].Trim().ToUpper();
                                continue;
                            }
                        }
                    }
                }

                if (sCommd == "M") 
                {
                    //остановка до нажатия кнопки продолжить
                    if (sValue == "0" || sValue == "00") good = true;
                    //вкл/выкл шпинделя
                    if (sValue == "3" || sValue == "03") good = true;
                    if (sValue == "5" || sValue == "05") good = true;
                    //смена инструмента
                    if (sValue == "6" || sValue == "06")
                    {
                        if ((i + 2) < lcmd.Count)
                        {
                            //проверим что есть ещё параметр "T" и "D"
                            if (lcmd[i + 1].Substring(0, 1).ToUpper() == "T" && lcmd[i + 2].Substring(0, 1).ToUpper() == "D")
                            {
                                sGoodsCmd += lcmd[i].Trim().ToUpper() + " " + lcmd[i + 1].Trim().ToUpper() + " " + lcmd[i + 2].Trim().ToUpper();
                                continue;
                            }                            
                        }
                    }
                }

                if (sCommd == "X" || sCommd == "Y" || sCommd == "Z")
                {
                    //координаты 3-х осей 
                    good = true;
                }

                if (good)
                {
                    sGoodsCmd += lcmd[i] + " ";
                }
                else
                {
                    sBadCmd += lcmd[i] + " ";
                }
            } //for (int i = 0; i < lcmd.Count; i++)


            if (lcmd.Count == 0) sBadCmd = value;

            result = new GKOD_resultParse(value, sGoodsCmd, sBadCmd);

            return result;
        }

        /// <summary>
        /// Набор готовых инструкций для станка 
        /// </summary>
        public static List<GKOD_Command> GKODS = new List<GKOD_Command>();

        /// <summary>
        /// Перезаполнение данных
        /// </summary>
        /// <param name="listCode"></param>
        public void FillData(List<string> listCode)
        {
            GKODS.Clear();
            listGkodeCommand.Items.Clear();

            GKOD_Command tmpCommand = new GKOD_Command();
            int maxIndexLen = listCode.Count.ToString().Length; //вычисление количества символов используемых для нумерации записей

            foreach (string valueStr in listCode)
            {
                List<string> lcmd = parserGkodeLine(valueStr);

                for (int i = 0; i < lcmd.Count; i++)
                {
                    string property = lcmd[i].Substring(0, 1).Trim().ToUpper();
                    string value = lcmd[i].Substring(1).Trim().ToUpper();

                    if (property == "" || value == "") continue; //ошибочная команда

                    if (property == "G")
                    {
                        if (value == "0" || value == "00") tmpCommand.workspeed = false;

                        if (value == "1" || value == "01") tmpCommand.workspeed = true;

                        if (value == "4" || value == "04")
                        {
                            //нужен следующий параметр
                            string property1 = lcmd[i+1].Substring(0, 1).Trim().ToUpper();
                            string value1 = lcmd[i+1].Substring(1).Trim().ToUpper();

                            if (property1 == "P")
                            {
                                tmpCommand.needPause = true;
                                tmpCommand.timeSeconds = int.Parse(value1);
                                i++;
                            }
                        }
                    }

                    if (property == "X")
                    {
                        //из-за кодировок, пока так сделаю...
                        string value1 = value.Trim().Replace('.', ',');

                        try
                        {
                            //если вдруг не число было....
                            tmpCommand.X = decimal.Parse(value1);
                        }
                        catch (Exception)
                        {
                            //throw;
                        }
                    }

                    if (property == "Y")
                    {
                        //из-за кодировок, пока так сделаю...
                        string value1 = value.Trim().Replace('.', ',');

                        try
                        {
                            //если вдруг не число было....
                            tmpCommand.Y = decimal.Parse(value1);
                        }
                        catch (Exception)
                        {
                            //throw;
                        }
                    }

                    if (property == "Z")
                    {
                        //из-за кодировок, пока так сделаю...
                        string value1 = value.Trim().Replace('.', ',');

                        try
                        {
                            //если вдруг не число было....
                            tmpCommand.Z = decimal.Parse(value1);
                        }
                        catch (Exception)
                        {
                            //throw;
                        }
                    }

                    if (property == "M")
                    {
                        if (value == "0" || value == "0") tmpCommand.needPause = true;

                        if (value == "3" || value == "03") tmpCommand.spindelON = true;

                        if (value == "5" || value == "05") tmpCommand.spindelON = false;

                        if (value == "6" || value == "06")
                        {
                            //нужен следующий параметр
                            string property1 = lcmd[i + 1].Substring(0, 1).Trim().ToUpper();
                            string value1 = lcmd[i + 1].Substring(1).Trim().ToUpper();

                            string property2 = lcmd[i + 2].Substring(0, 1).Trim().ToUpper();
                            string value2 = lcmd[i + 2].Substring(1).Trim().ToUpper().Replace('.', ',');

                            if (property1 == "T" && property2 == "D")
                            {
                                tmpCommand.changeInstrument = true;
                                tmpCommand.numberInstrument = int.Parse(value1);
                                tmpCommand.timeSeconds = int.Parse(value1);
                                tmpCommand.diametr = decimal.Parse(value2);
                                i+=2;
                            }
                        }
                    }
                }

                GKODS.Add(new GKOD_Command(tmpCommand));

                tmpCommand.numberInstruct++;
                tmpCommand.needPause = false;
                tmpCommand.changeInstrument = false;
                tmpCommand.timeSeconds = 0;

                listGkodeCommand.Items.Add("[" + tmpCommand.numberInstruct.ToString().PadLeft(maxIndexLen, '0') + "]" + " " + valueStr);
            }
        }


        /// <summary>
        /// Парсинг G-кода
        /// </summary>
        /// <param name="lines">Массив строк с G-кодом</param>
        public void LoadDataFromText(string[] lines)
        {
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Minimum = 0;
            toolStripProgressBar.Maximum = lines.Length;

            int index = 0;

            List<string> goodstr = new List<string>(); //массив только для распознаных!!! G-кодов

            foreach (string str in lines)
            {
                toolStripProgressBar.Value = index++;

                GKOD_resultParse graw = parseStringCode(str.ToUpper());

                if (graw.GoodStr.Trim().Length == 0)
                {
                    AddLog(@"В строке: " + index + " не распознаны команды: " + graw.BadStr);
                    continue;
                }

                goodstr.Add(graw.GoodStr);
            }

           //запуск анализа нормальных команд
            FillData(goodstr);
        }

        /// <summary>
        /// Вызов диалога пользователя для выбора файла, и посылка данных в процедуру: LoadDataFromText(string[] lines)
        /// </summary>
        private void OpenFile()
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            Text = @"Управленец ЧПУ: " + openFileDialog.FileName; //заголовок окна

            listBoxLog.Items.Add(@"Загрузка данных из файла: " + openFileDialog.FileName);

            string[] sData = File.ReadAllLines(openFileDialog.FileName);

            LoadDataFromText(sData);
        }

        private void menuOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void buttonXtoZero_Click(object sender, EventArgs e)
        {
            _cnc.DeviceNewPosition(0, deviceInfo.AxesY_PositionPulse, deviceInfo.AxesZ_PositionPulse);
        }

        private void buttonYtoZero_Click(object sender, EventArgs e)
        {
            _cnc.DeviceNewPosition(deviceInfo.AxesX_PositionPulse, 0, deviceInfo.AxesZ_PositionPulse);
        }

        private void buttonZtoZero_Click(object sender, EventArgs e)
        {
            _cnc.DeviceNewPosition(deviceInfo.AxesX_PositionPulse, deviceInfo.AxesY_PositionPulse, 0);
        }

        private void ShowSetting()
        {
            setting setfrm = new setting(ref _cnc);
            DialogResult dlgResult = setfrm.ShowDialog();
            
            if (dlgResult == DialogResult.OK) _cnc.SaveSetting();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSetting();
        }

        private void settingControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSetting();
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

        private void buttonSpindel_Click_1(object sender, EventArgs e)
        {
            if (_cnc.SpindelOn)
            {
                _cnc.Spindel_OFF();
            }
            else
            {
                _cnc.Spindel_ON();
            }
        }

        private void toolStripButtonEnergyStop_Click(object sender, EventArgs e)
        {
            _cnc.EnergyStop();
        }

        private void Feed()
        {
            PreviewSetting.ShowMatrix = true;
            ScanSurface frm = new ScanSurface(ref _cnc);
            frm.Show();
        }

        private void additionallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //вызов 3Д формы
            //покажем графические настройки
            Sett3D frm = new Sett3D(this);
            frm.Show();
        }

        private void scansurfaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //вызов формы сканирования
            Feed();
        }

        private void toolStripButtonEditData_Click(object sender, EventArgs e)
        {
            EditGkode frm = new EditGkode(this);
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

        public bool ShowGrate = false;
        public double grateXmin = 0;
        public double grateXmax = 0;
        public double grateYmin = 0;
        public double grateYmax = 0;


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

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            // обработка "тика" таймера - вызов функции отрисовки 
            Draw();
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
                    
                    int p1 = OpenGL_preview.Width;
                    int p2 = OpenGL_preview.Height;

                    double n = 1;

                    if (p2<p1) n = (p1/p2);

                    double scaleX = PreviewSetting.PosZoom / (1000.0*n);
                    double scaleY = PreviewSetting.PosZoom / 1000.0;
                    double scaleZ = PreviewSetting.PosZoom / 1000.0;

                    Gl.glScaled(scaleX, scaleY, scaleZ);


                }

            }
            catch (Exception)
            {
                
                //throw;
            }

            //// помещаем состояние матрицы в стек матриц 
            Gl.glPushMatrix();


            Gl.glEnable(Gl.GL_LINE_SMOOTH);

            #endregion

            #region Отображение координатной оси

            if (PreviewSetting.ShowAxes)
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

            if (PreviewSetting.ShowGrid)
            {
                Gl.glLineWidth(0.1f);
                Gl.glColor3f(0, 0, 0.5F);
                Gl.glBegin(Gl.GL_LINES);

                for (int gX = PreviewSetting.GridXstart; gX < PreviewSetting.GridXend+1; gX += PreviewSetting.GrigStep)
                {
                    Gl.glVertex3d(gX, PreviewSetting.GridYstart, 0);
                    Gl.glVertex3d(gX, PreviewSetting.GridYend, 0);
                }

                for (int gY = PreviewSetting.GridYstart; gY < PreviewSetting.GridYend+1; gY += PreviewSetting.GrigStep)
                {
                    Gl.glVertex3d(PreviewSetting.GridXstart, gY, 0);
                    Gl.glVertex3d(PreviewSetting.GridXend, gY, 0);
                }
                
                Gl.glEnd();
            }

            #endregion

            #region Матрица поверхности

            if (PreviewSetting.ShowMatrix)
            {
                //отбразим точки матрицы
                Gl.glColor3f(1.000f, 0.498f, 0.314f);
                Gl.glPointSize(10.0F);
                Gl.glBegin(Gl.GL_POINTS);


                int maxX = dataCode.matrix2.GetLength(0);
                int maxY = dataCode.matrix2.GetLength(1);

                for (int x = 0; x < maxX; x++)
                {
                    for (int y = 0; y < maxY; y++)
                    {
                        if (dataCode.matrix2[x, y] == null) continue;
                        
                        //рисуем точку
                        Gl.glVertex3d(dataCode.matrix2[x, y].X, dataCode.matrix2[x, y].Y, dataCode.matrix2[x, y].Z);
                    }
                }

                Gl.glEnd();

                //Добавим связи между точками
                Gl.glColor3f(0.678f, 1.000f, 0.184f);
                Gl.glLineWidth(0.4f);
                Gl.glBegin(Gl.GL_LINES); 

                for (int x = 0; x < maxX; x++)
                {
                    for (int y = 0; y < maxY; y++)
                    {
                        if (dataCode.matrix2[x, y] == null) continue;

                        if (x > 0)
                        {
                            //line 1
                            Gl.glVertex3d(dataCode.matrix2[x, y].X, dataCode.matrix2[x, y].Y, dataCode.matrix2[x, y].Z);
                            Gl.glVertex3d(dataCode.matrix2[x-1, y].X, dataCode.matrix2[x-1, y].Y, dataCode.matrix2[x-1, y].Z);
                        }

                        if (x < maxX-1)
                        {
                            //line2
                            Gl.glVertex3d(dataCode.matrix2[x, y].X, dataCode.matrix2[x, y].Y, dataCode.matrix2[x, y].Z);
                            Gl.glVertex3d(dataCode.matrix2[x + 1, y].X, dataCode.matrix2[x + 1, y].Y, dataCode.matrix2[x + 1, y].Z);
                        }

                        if (y > 0)
                        {
                            //line 3
                            Gl.glVertex3d(dataCode.matrix2[x, y].X, dataCode.matrix2[x, y].Y, dataCode.matrix2[x, y].Z);
                            Gl.glVertex3d(dataCode.matrix2[x , y- 1].X, dataCode.matrix2[x , y- 1].Y, dataCode.matrix2[x , y- 1].Z);
                        }

                        if (y < maxY-1)
                        {
                            //line4
                            Gl.glVertex3d(dataCode.matrix2[x, y].X, dataCode.matrix2[x, y].Y, dataCode.matrix2[x, y].Z);
                            Gl.glVertex3d(dataCode.matrix2[x , y+ 1].X, dataCode.matrix2[x , y+ 1].Y, dataCode.matrix2[x , y+ 1].Z);
                        }
                    }
                }
                Gl.glEnd();
            }

            #endregion

            #region Отображение инструмента

            if (PreviewSetting.ShowInstrument)
            {

                //нарисуем курсор
                double startX = (double)deviceInfo.AxesX_PositionMM;
                double startY = (double)deviceInfo.AxesY_PositionMM;
                double startZ = (double)deviceInfo.AxesZ_PositionMM;

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

            Gl.glLineWidth(0.3f);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            foreach (GKOD_Command vv in GKODS)
            {
                //Gl.glLineWidth(0.1f);
                if (vv.workspeed) Gl.glColor3f(0, 255, 0); else Gl.glColor3f(255, 0, 0);
                
                //координаты следующей точки
                double pointX = (double)vv.X;
                double pointY = (double)vv.Y;
                double pointZ = (double)vv.Z;

                //добавление смещения G-кода
                if (Correction)
                {
                    // применение пропорций
                    pointX *= koeffSizeX;
                    pointY *= koeffSizeY;

                    //применение смещения
                    pointX += deltaX;
                    pointY += deltaY;
                    pointZ += deltaZ;

                    //применение матрицы поверхности детали
                    if (deltaFeed)
                    {
                        pointZ += GetDeltaZ(pointX, pointY);
                    }
                }

                Gl.glVertex3d(pointX, pointY, pointZ);
                Gl.glLineWidth(0.4f);
            }

            Gl.glEnd();


            //******Вывод выделенной траектории***********************
            Gl.glLineWidth(3.0f);
            Gl.glColor3f(1, 1, 1);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            foreach (GKOD_Command vv in GKODS)
            {

                //координаты следующей точки
                double pointX = (double)vv.X;
                double pointY = (double)vv.Y;
                double pointZ = (double)vv.Z;

                //добавление смещения G-кода
                if (Correction)
                {
                    // применение пропорций
                    pointX *= koeffSizeX;
                    pointY *= koeffSizeY;

                    //применение смещения
                    pointX += deltaX;
                    pointY += deltaY;
                    pointZ += deltaZ;

                    //применение матрицы поверхности детали
                    if (deltaFeed)
                    {
                        pointZ += GetDeltaZ(pointX, pointY);
                    }
                }

                //добавим тут фильт

                if (Task.StatusTask == EStatusTask.Waiting)
                {
                    int numSelectStart = Task.posCodeStart-1;
                    int numSelectStop = Task.posCodeEnd-1;

                    if (vv.numberInstruct >= numSelectStart && vv.numberInstruct <= numSelectStop)
                    {
                        Gl.glVertex3d(pointX, pointY, pointZ);
                    }
                }
                else
                {
                    // Тут выделяется только одна линия из траектории
                    int numSelect = _cnc.NumberComleatedInstructions + 1;
                    if (vv.numberInstruct == (numSelect - 1))
                    {
                        Gl.glVertex3d(pointX, pointY, pointZ);
                    }

                    if (vv.numberInstruct == (numSelect))
                    {
                        Gl.glVertex3d(pointX, pointY, pointZ);
                    }
                }
            }
            Gl.glEnd();




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

            if (ShowGrate)
            {
                //отобразим лишь 4 линии
                
            //public double grateXmin = 0;
            //public double grateXmax = 0;
            //public double grateYmin = 0;
            //public double grateYmax = 0;

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

            #region Завершение отрисовки

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


        

        private double GetDeltaZ(double _x, double _y)
        {
                        //точка которую нужно отобразить
           dobPoint pResult = new dobPoint(_x, _y, 0);


            int indexXmin = 0;
            int indexYmin = 0;
            for (int x = 0; x < dataCode.matrix2.GetLength(0) - 1; x++)
            {
                for (int y = 0; y < dataCode.matrix2.GetLength(1) - 1; y++)
                {
                    if (_x > dataCode.matrix2[x, 0].X && _x < dataCode.matrix2[x + 1, 0].X && dataCode.matrix2[0, y].Y < _y && dataCode.matrix2[0, y + 1].Y > _y)
                    {
                        indexXmin = x;
                        indexYmin = y;
                    }
                }
            }


            dobPoint p1 = new dobPoint(dataCode.matrix2[indexXmin, indexYmin].X, dataCode.matrix2[indexXmin, indexYmin].Y, dataCode.matrix2[indexXmin, indexYmin].Z);
            dobPoint p3 = new dobPoint(dataCode.matrix2[indexXmin, indexYmin + 1].X, dataCode.matrix2[indexXmin, indexYmin + 1].Y, dataCode.matrix2[indexXmin, indexYmin + 1].Z);
            dobPoint p2 = new dobPoint(dataCode.matrix2[indexXmin + 1, indexYmin].X, dataCode.matrix2[indexXmin + 1, indexYmin].Y, dataCode.matrix2[indexXmin + 1, indexYmin].Z);
            dobPoint p4 = new dobPoint(dataCode.matrix2[indexXmin + 1, indexYmin + 1].X, dataCode.matrix2[indexXmin + 1, indexYmin + 1].Y, dataCode.matrix2[indexXmin + 1, indexYmin + 1].Z);

            dobPoint p12 = Geometry.CalcPX(p1, p2, pResult);
            dobPoint p34 = Geometry.CalcPX(p3, p4, pResult);
            dobPoint p1234 = Geometry.CalcPY(p12, p34, pResult);
/* 

            //pointZ = p1234.Z;



             //TODO: В связи с переделкой ряда ключевых механизмов применение матрицы отключим



            //1) получим координаты 4-х ближайших точек из матрицы

            //текущая точка
                    




            //2) запустим математику


            //Point p1 = new Point(numericUpDown11.Value, numericUpDown10.Value, numericUpDown9.Value);
            //Point p2 = new Point(numericUpDown12.Value, numericUpDown14.Value, numericUpDown13.Value);
            //Point p3 = new Point(numericUpDown15.Value, numericUpDown17.Value, numericUpDown16.Value);
            //Point p4 = new Point(numericUpDown21.Value, numericUpDown23.Value, numericUpDown22.Value);

            //Point p5 = new Point(numericUpDown18.Value, numericUpDown20.Value, numericUpDown19.Value);



            //numericUpDown24.Value = p1234.X;
            //numericUpDown26.Value = p1234.Y;
            //numericUpDown25.Value = p1234.Z;

            ////Point p01 = Geometry.GetZ(p1, p2, p3, p4, new Point(3, 3, 1));
            */

            return p1234.Z;
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

        #region Выполнение G-кода из таблицы

        //Для использования, корректировки положения
        /// <summary>
        /// Необходимость применения корректировки данных
        /// </summary>
        public bool Correction = false;
        public double deltaX = 0;
        public double deltaY = 0;
        public double deltaZ = 0;
        public double koeffSizeX = 1;
        public double koeffSizeY = 1;
        public bool deltaFeed = false;

        private void buttonStartTask_Click(object sender, EventArgs e)
        {
            if (TaskTimer.Enabled) return; //нельзя дальше, если таймер включен

            if (!_cnc.Connected)
            {
                MessageBox.Show(@"Нет связи с контроллером!");
                return;
            }

            if (GKODS.Count == 0)
            {
                // нет данных для выполнения
                MessageBox.Show(@"Нет данных для выполнения!");
                return;
            }

            //если в списке команд не выбрана строчка, то спозиционируемся на первой
            if (listGkodeCommand.SelectedIndex == -1) listGkodeCommand.SelectedIndex = 0;

            if (listGkodeCommand.SelectedItems.Count == 1)   //выбрана всего одна строка, а значит для выполнения будет указан диапазон, от этой строки и до конца
            {
                DialogResult dlgres = MessageBox.Show(@"Запустить выполнение G-кода со строки №: " + (listGkodeCommand.SelectedIndex + 1).ToString() 
                    + "\n и до последней?", @"Запуск выполнения программы", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dlgres == DialogResult.Cancel) return;

                //установим границы выполнения
                Task.posCodeStart = listGkodeCommand.SelectedIndex;
                Task.posCodeEnd = listGkodeCommand.Items.Count;
                Task.posCodeNow = Task.posCodeStart;
            }
            else   //выбран диапазон строк
            {
                DialogResult dlgr = MessageBox.Show(@"Запустить выполнение G-кода со строки №: " + (listGkodeCommand.SelectedIndex + 1).ToString() 
                    + @" по строку №: " + (listGkodeCommand.SelectedIndex + listGkodeCommand.SelectedItems.Count).ToString() 
                    + "?", @"Запуск выполнения программы", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dlgr == DialogResult.Cancel) return;

                //установим границы выполнения
                Task.posCodeStart = listGkodeCommand.SelectedIndex;
                Task.posCodeEnd = listGkodeCommand.SelectedIndex + listGkodeCommand.SelectedItems.Count;
                Task.posCodeNow = Task.posCodeStart;
            }

            checkBoxManualMove.Checked = false; // отключим реакцию на нажатие NUM-pad

            Task.StatusTask = EStatusTask.TaskStart;
            TaskTimer.Enabled = true;
             
            RefreshElementsForms();
        }

        private void buttonPauseTask_Click(object sender, EventArgs e)
        {
            if (Task.StatusTask == EStatusTask.TaskStart) return; //пока задание не запустилось, нет смысла ставить паузу

            if (Task.StatusTask == EStatusTask.TaskWorking || Task.StatusTask == EStatusTask.TaskPaused)
            {
                Task.StatusTask = (Task.StatusTask == EStatusTask.TaskPaused) ? EStatusTask.TaskWorking : EStatusTask.TaskPaused;
            }
            RefreshElementsForms();
        }

        private void btStopTask_Click(object sender, EventArgs e)
        {
            if (Task.StatusTask == EStatusTask.Waiting) return;
            Task.StatusTask = EStatusTask.TaskStop;
            RefreshElementsForms();
        }

        private void TaskTimer_Tick(object sender, EventArgs e)
        {
            if (!_cnc.Connected)
            {
                TaskTimer.Enabled = false;
                return;
            }

            // скорость с главной формы
            int UserSpeedG1 = (int)numericUpDown1.Value;
            int UserSpeedG0 = (int)numericUpDown2.Value;

            GKOD_Command gcodeNow = null;

            if (Task.posCodeNow == GKODS.Count)
            {
                //уже дошли до конца
                if (Task.StatusTask == EStatusTask.TaskWorking)
                {
                    Task.StatusTask = EStatusTask.TaskStop;
                }
            }
            else
            {
                gcodeNow = GKODS[Task.posCodeNow];
            }

            #region TaskStart

            if (Task.StatusTask == EStatusTask.TaskStart)
            {
                AddLog("Запуск задания в " + DateTime.Now.ToLocalTime().ToString(CultureInfo.InvariantCulture));

                int MaxSpeedX = 100;
                int MaxSpeedY = 100;
                int MaxSpeedZ = 100;

                _cnc.SendBinaryData(BinaryData.pack_9E(0x05));
                _cnc.SendBinaryData(BinaryData.pack_BF(MaxSpeedX, MaxSpeedY, MaxSpeedZ));
                _cnc.SendBinaryData(BinaryData.pack_C0());

                //так-же спозиционируемся, над первой точкой по оси X и Y
                //TODO: нужно ещё и поднять повыше шпиндель, а пока на 10 мм (продумать реализацию)
                _cnc.SendBinaryData(BinaryData.pack_CA(deviceInfo.AxesX_PositionPulse, deviceInfo.AxesY_PositionPulse, deviceInfo.AxesZ_PositionPulse + deviceInfo.CalcPosPulse("Z",10), UserSpeedG0, 0));

                //TODO: И продумать реализацию к подходу к точке
                _cnc.SendBinaryData(BinaryData.pack_CA(deviceInfo.CalcPosPulse("X", gcodeNow.X), deviceInfo.CalcPosPulse("Y", gcodeNow.Y), deviceInfo.AxesZ_PositionPulse + deviceInfo.CalcPosPulse("Z", 10), UserSpeedG0, 0));

                Task.StatusTask = EStatusTask.TaskWorking;
                RefreshElementsForms();

                return; //после запуска дальше код пропустим...
            }

            #endregion
            
            #region TaskStop

            if (Task.StatusTask == EStatusTask.TaskStop)
            {
                //TODO: добавить поднятие фрезы, возможное позиционирование в home

                _cnc.SendBinaryData(BinaryData.pack_FF());
                _cnc.SendBinaryData(BinaryData.pack_9D());
                _cnc.SendBinaryData(BinaryData.pack_9E(0x02));
                _cnc.SendBinaryData(BinaryData.pack_FF());
                _cnc.SendBinaryData(BinaryData.pack_FF());
                _cnc.SendBinaryData(BinaryData.pack_FF());
                _cnc.SendBinaryData(BinaryData.pack_FF());
                _cnc.SendBinaryData(BinaryData.pack_FF());

                AddLog("Завершение задания в " + DateTime.Now.ToLocalTime().ToString(CultureInfo.InvariantCulture));
                Task.StatusTask = EStatusTask.Waiting;
                TaskTimer.Enabled = false;
                RefreshElementsForms();
            }

            #endregion
            
            #region TaskWorking

            if (Task.StatusTask != EStatusTask.TaskWorking) return;

            //Все необходимые команды завершены, пора всё завершить
            if (Task.posCodeNow > Task.posCodeEnd) 
            {
                Task.StatusTask = EStatusTask.TaskStop;
                return;
            }

            //TODO: добавить в параметр значение
            if (_cnc.AvailableBufferSize < 5) return; // откажемся от посылки контроллеру, пока буфер не освободиться


            //TODO: добавить в параметр и это значение
            if (Task.posCodeNow > (_cnc.NumberComleatedInstructions + 3)) return; // Так-же не будем много посылать команд, т.е. далеко убегать

            //команда остановки G4 или M0
            if (gcodeNow.needPause)  
            {
                if (gcodeNow.timeSeconds == 0) // M0 - команда ожидания от пользователя
                {
                    Task.StatusTask = EStatusTask.TaskPaused;
                    RefreshElementsForms();
                    //пауза до клика пользователя
                    MessageBox.Show(@"Получена команда M0 для остановки! для дальнейшего выполнения нужно нажать на кнопку 'пауза'", "Пауза",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    toolStripStatus.Text = "Пауза " + gcodeNow.timeSeconds + " мсек. по команде G4";
                    
                    System.Threading.Thread.Sleep(gcodeNow.timeSeconds); // пауза в мсек.

                    toolStripStatus.Text = "";
                }
            }

            //команда смены инструмента
            if (gcodeNow.changeInstrument)
            {
                Task.StatusTask = EStatusTask.TaskPaused;
                RefreshElementsForms();

                //пауза до клика пользователя
                MessageBox.Show(@"Активирована ПАУЗА! Установите инструмент №:" + gcodeNow.numberInstrument + " имеющий диаметр: " + gcodeNow.diametr + " мм. и нажмите для продолжения кнопку 'пауза'", "Пауза",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }



            double pointX = (double)gcodeNow.X;
            double pointY = (double)gcodeNow.Y;
            double pointZ = (double)gcodeNow.Z;

            //добавление смещения G-кода
            if (Correction)
            {
                // применение пропорций
                pointX *= koeffSizeX;
                pointY *= koeffSizeY;

                //применение смещения
                pointX += deltaX;
                pointY += deltaY;
                pointZ += deltaZ;

                //применение матрицы поверхности детали
                if (deltaFeed)
                {
                    pointZ += GetDeltaZ(pointX, pointY);
                }
            }

            int posX = deviceInfo.CalcPosPulse("X", (decimal)pointX);
            int posY = deviceInfo.CalcPosPulse("Y", (decimal)pointY);
            int posZ = deviceInfo.CalcPosPulse("Z", (decimal)pointZ);

            //TODO: доделать управление скоростью ручая/по программе
            int speed = (gcodeNow.workspeed) ? UserSpeedG1 : UserSpeedG0;

            _cnc.SendBinaryData(BinaryData.pack_CA(posX, posY, posZ, speed, Task.posCodeNow));

            Task.posCodeNow++;
            textBoxNumberLine.Text = Task.posCodeNow.ToString();

            #endregion
        } //void TaskTimer_Tick

        #endregion

        #region OTHER

        // вывод лога
        void AddLog(string _text = "")
        {
            if (_text == null) return;
            listBoxLog.Items.Add(_text);
        }


        //разобраться о необходимости
        private void toolStripStatus_Click(object sender, EventArgs e)
        {
            // Вызовем очистку сообщения
            toolStripStatus.Text = @"";
        }


        // движение в заданную точку
        private void button3_Click(object sender, EventArgs e)
        {
            

            if (!_cnc.TestAllowActions()) return;
            
            _cnc.SendBinaryData(BinaryData.pack_9E(0x05));
            _cnc.SendBinaryData(BinaryData.pack_BF((int)numericUpDown3.Value, (int)numericUpDown3.Value, (int)numericUpDown3.Value));
            _cnc.SendBinaryData(BinaryData.pack_C0());
            _cnc.SendBinaryData(BinaryData.pack_CA(deviceInfo.CalcPosPulse("X",numericUpDown6.Value), deviceInfo.CalcPosPulse("Y",numericUpDown5.Value), deviceInfo.CalcPosPulse("Z",numericUpDown4.Value), (int)numericUpDown3.Value,0));
            _cnc.SendBinaryData(BinaryData.pack_FF());
            _cnc.SendBinaryData(BinaryData.pack_9D());
            _cnc.SendBinaryData(BinaryData.pack_9E(0x02));
            _cnc.SendBinaryData(BinaryData.pack_FF());
            _cnc.SendBinaryData(BinaryData.pack_FF());
            _cnc.SendBinaryData(BinaryData.pack_FF());
            _cnc.SendBinaryData(BinaryData.pack_FF());
            _cnc.SendBinaryData(BinaryData.pack_FF());
        }

        
        
        //ОТЛАДКА генератора ШИМ
        private void SendSignal()
        {
            if (radioButton_off.Checked)
            {
                _cnc.SendBinaryData(BinaryData.pack_B5(checkBox18.Checked, (int)numericUpDown7.Value, BinaryData.TypeSignal.None, (int)numericUpDown8.Value));
            }

            if (radioButton_Hz.Checked)
            {
                _cnc.SendBinaryData(BinaryData.pack_B5(checkBox18.Checked, (int)numericUpDown7.Value, BinaryData.TypeSignal.Hz, (int)numericUpDown8.Value));
            }

            if (radioButton_RC.Checked)
            {
                _cnc.SendBinaryData(BinaryData.pack_B5(checkBox18.Checked, (int)numericUpDown7.Value, BinaryData.TypeSignal.RC, (int)numericUpDown8.Value));
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


 
        #endregion

        private void toolStripButtonLikePoint_Click(object sender, EventArgs e)
        {
            //TODO: откроем окно со списком точек
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            
            if (Task.StatusTask == EStatusTask.Waiting)
            {
                Task.posCodeStart = listGkodeCommand.SelectedIndex;
                textBoxNumberLine.Text = (listGkodeCommand.SelectedIndex +1).ToString();
            }

        }

        private void listBox1_DataSourceChanged(object sender, EventArgs e)
        {


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Task.StatusTask == EStatusTask.Waiting)
            {
                Task.posCodeStart = listGkodeCommand.SelectedIndex;
                Task.posCodeEnd = listGkodeCommand.SelectedIndex + listGkodeCommand.SelectedItems.Count;
                textBoxNumberLine.Text = (listGkodeCommand.SelectedIndex + 1).ToString();
            }
        }

        private void generatorCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GeneratorCode frm = new GeneratorCode(this);
            frm.Show();
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
    public enum EStatusTask { Waiting = 0, TaskStart, TaskWorking, TaskPaused, TaskStop };

    /// <summary>
    /// Класс для работы с заданием для контроллера
    /// </summary>
    public static class Task
    {
        /// <summary>
        /// Сво-во для определения режима работы
        /// </summary>
        public static EStatusTask StatusTask = EStatusTask.Waiting;

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
        }

        public GKOD_Command(int _numberInstruct, bool _spindelON, decimal _X, decimal _Y, decimal _Z, int _speed, bool _workspeed, bool _changeInstrument = false, int _numberInstrument = 0, bool _needPause = false, int _timeSeconds = 0, decimal _diametr = 0)
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
