using System;
//using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Tao.OpenGl;                 // для работы с библиотекой OpenGL
using Tao.FreeGlut;               // для работы с библиотекой FreeGLUT

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

            _indexLineForTask = 0;
            _task = EStatusTask.Waiting;

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
            toolStripStatus.Text = @"";
            Init3D();

            PreviewSetting.ShowInstrument = true;
            //preview_setting.ShowGrid = true;

            PreviewSetting.PosAngleX = -90;
            PreviewSetting.PosAngleY = 0;
            PreviewSetting.PosAngleZ = 0;
            PreviewSetting.PosX = -96;
            PreviewSetting.PosY = -64;
            PreviewSetting.PosZ = -300;
            PreviewSetting.PosZoom = 7;

            RefreshElementsForms();
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
        bool _manualMoveButtonPressed;

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


            if (!checkBoxManualMove.Checked) return;

            if (!_cnc.TestAllowActions()) return;


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



            if (!_cnc.Connected) 
            {
                buttonStartTask.Enabled = false;
                btStopTask.Enabled = false;
                buttonPauseTask.Enabled = false;
                return;
            }


            if (_task == EStatusTask.Waiting)
            {
                buttonStartTask.Enabled = true;
                btStopTask.Enabled = false;
                buttonPauseTask.Enabled = false;
                buttonXtoZero.Enabled = true;
                buttonYtoZero.Enabled = true;
                buttonZtoZero.Enabled = true;
            }


            if (_task == EStatusTask.TaskPaused)
            {
                buttonStartTask.Enabled = false;
                btStopTask.Enabled = true;
                buttonPauseTask.Enabled = true;
                buttonXtoZero.Enabled = false;
                buttonYtoZero.Enabled = false;
                buttonZtoZero.Enabled = false;
            }


            if (_task == EStatusTask.TaskWorking)
            {
                buttonStartTask.Enabled = false;
                btStopTask.Enabled = true;
                buttonPauseTask.Enabled = true;
                buttonXtoZero.Enabled = false;
                buttonYtoZero.Enabled = false;
                buttonZtoZero.Enabled = false;

                toolStripProgressBar.Value = _cnc.NumberComleatedInstructions;
                dataGrid.Rows[_cnc.NumberComleatedInstructions].Selected = true;
            }


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

            //if (!_cnc.AvailableNewData) return; //нет смысла обновлять элементы на форме

            //RefreshElementsForms();

            //TODO: добавим проверку которая получает описание ошибки у класса cnc

            //toolStripStatus.Text = _cnc.StringError; //ошибку выведем на форме

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
            kf.ShowDialog();
        }

        private void OpenFile()
        {

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            Text = @"Управленец ЧПУ: " + openFileDialog.FileName;
            listBoxLog.Items.Add(@"Загрузка данных из файла: " + openFileDialog.FileName);

            //Очистим данные
            dataCode.Clear();

            string[] sData = System.IO.File.ReadAllLines(openFileDialog.FileName);

            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Minimum = 0;
            toolStripProgressBar.Maximum = sData.Length;

            foreach (string ss in sData)
            {
                dataCode.AddData(ss);

                toolStripProgressBar.Value++;
            }

            dataGrid.Rows.Clear();

            int pp = dataCode.GKODraw.Count.ToString().Length;

            foreach (GKOD_raw valueGkodRaw in dataCode.GKODraw)
            {
                int p = dataGrid.Rows.Add();
                dataGrid.Rows[p].Cells[0].Value = "[" + p.ToString().PadLeft(pp, '0') + "]" + " " + valueGkodRaw.GoodStr;
                dataGrid.Rows[p].Cells[1].Value = valueGkodRaw.BadStr;
            }

            dataCode.CalculateData();
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

            Double endX = 0, endY = 0, endZ = 0;

            //TODO: переделать
            foreach (GKOD_ready vv in dataCode.GKODready)
            {
                if (vv.workspeed) Gl.glColor3f(0, 255, 0); else Gl.glColor3f(255, 0, 0);

                //выделим жирным текущую линию
                if (vv.numberInstruct == (_indexLineForTask - 1)) Gl.glLineWidth(3.0f); else Gl.glLineWidth(0.1f);


                //смещение положения g-кода
                double pointXpp = 0;
                double pointYpp = 0;
                double pointZpp = 0;

                //координаты следующей точки
                double pointX = (double)vv.X;
                double pointY = (double)vv.Y;
                double pointZ = (double)vv.Z;


                //добавление смещения G-кода
                if (deltaUsage)
                {
                    pointXpp = deltaX;
                    pointYpp = deltaY;
                    pointZpp = deltaZ;
                }

                //добавление корректировки по z
                if (deltaFeed)
                {


                    /* 
                     //TODO: В связи с переделкой ряда ключевых механизмов применение матрицы отключим



                    //1) получим координаты 4-х ближайших точек из матрицы

                    //текущая точка
                    dobPoint pResult = new dobPoint(pointX, pointY, pointZ);

                    int indexXmin = 0;

                    int indexYmin = 0;

                    for (int x = 0; x < dataCode.matrix2.GetLength(0)-1; x++)
                    {
                        //нужно текущую точку проверить между 2-х точек

                        if (pResult.X > dataCode.matrix2[x, 0].X && pResult.X < dataCode.matrix2[x + 1, 0].X)
                        {
                            indexXmin = x;
                        }
                    }


                    for (int y = 0; y < dataCode.matrix2.GetLength(1)-1; y++)
                    {
                        if (dataCode.matrix2[0, y].Y < pResult.Y && dataCode.matrix2[0, y+1].Y > pResult.Y)
                        {
                            indexYmin = y;
                        }
                    }


                    //2) запустим математику

                    dobPoint p1 = new dobPoint(dataCode.matrix2[indexXmin, indexYmin].X, dataCode.matrix2[indexXmin, indexYmin].Y, dataCode.matrix2[indexXmin, indexYmin].Z);
                    dobPoint p2 = new dobPoint(dataCode.matrix2[indexXmin, indexYmin+1].X, dataCode.matrix2[indexXmin, indexYmin+1].Y, dataCode.matrix2[indexXmin, indexYmin+1].Z);
                    dobPoint p3 = new dobPoint(dataCode.matrix2[indexXmin+1, indexYmin].X, dataCode.matrix2[indexXmin+1, indexYmin].Y, dataCode.matrix2[indexXmin+1, indexYmin].Z);
                    dobPoint p4 = new dobPoint(dataCode.matrix2[indexXmin + 1, indexYmin + 1].X, dataCode.matrix2[indexXmin + 1, indexYmin + 1].Y, dataCode.matrix2[indexXmin + 1, indexYmin + 1].Z);

                    //Point p1 = new Point(numericUpDown11.Value, numericUpDown10.Value, numericUpDown9.Value);
                    //Point p2 = new Point(numericUpDown12.Value, numericUpDown14.Value, numericUpDown13.Value);
                    //Point p3 = new Point(numericUpDown15.Value, numericUpDown17.Value, numericUpDown16.Value);
                    //Point p4 = new Point(numericUpDown21.Value, numericUpDown23.Value, numericUpDown22.Value);

                    //Point p5 = new Point(numericUpDown18.Value, numericUpDown20.Value, numericUpDown19.Value);


                    dobPoint p12 = Geometry.CalcPX(p1, p2, pResult);
                    dobPoint p34 = Geometry.CalcPX(p3, p4, pResult);

                    dobPoint p1234 = Geometry.CalcPY(p12, p34, pResult);

                    pointZ = p1234.Z;

                    //numericUpDown24.Value = p1234.X;
                    //numericUpDown26.Value = p1234.Y;
                    //numericUpDown25.Value = p1234.Z;

                    ////Point p01 = Geometry.GetZ(p1, p2, p3, p4, new Point(3, 3, 1));
                    */
                }

                

                Gl.glBegin(Gl.GL_LINES); //РИСОВАНИЕ ОБЫЧНОЙ ЛИНИИ

                Gl.glVertex3d(endX + pointXpp, endY + pointYpp, endZ + pointZpp);
                Gl.glVertex3d(pointX + deltaX, pointY + deltaY, pointZ + deltaZ);

                Gl.glEnd();

                endX = pointX;
                endY = pointY;
                endZ = pointZ;
            }

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
        public bool deltaUsage = false;
        public double deltaX = 0;
        public double deltaY = 0;
        public double deltaZ = 0;

        public bool deltaFeed = false;


        /// <summary>
        /// Номер строки с заданием для выполнения
        /// </summary>
        private int _indexLineForTask;

        /// <summary>
        /// Виды статусов выполнения задания
        /// </summary>
        private enum EStatusTask { Waiting = 0, TaskStart, TaskWorking, TaskPaused,  TaskStop};

        /// <summary>
        /// Свойство для работы со статусом задания
        /// </summary>
        private EStatusTask _task;

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_task == EStatusTask.Waiting)
            {
                _indexLineForTask = (dataGrid.Rows.Count > 0) ?  e.RowIndex+1:0;

                textBoxNumberLine.Text = _indexLineForTask.ToString();
            }
        }

        private void buttonStartTask_Click(object sender, EventArgs e)
        {
            if (_task != EStatusTask.Waiting) return;
            
            DialogResult dlgres = MessageBox.Show(@"Вы хотите начать выполнение программы с строки " + _indexLineForTask.ToString() + @"?", @"Запуск выполнения программы", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            checkBoxManualMove.Checked = false;

            if (dlgres == DialogResult.Cancel) return;

            //TODO: переделать
            ////toolStripProgressBar.Minimum = 0;
            ////toolStripProgressBar.Maximum = G3D.points.Count;

            _task = EStatusTask.TaskStart;
        }

        private void buttonPauseTask_Click(object sender, EventArgs e)
        {
            if (_task == EStatusTask.TaskWorking || _task == EStatusTask.TaskPaused)
            {
                _task = (_task == EStatusTask.TaskPaused) ? EStatusTask.TaskWorking : EStatusTask.TaskPaused;
            }
        }

        private void btStopTask_Click(object sender, EventArgs e)
        {
            if (_task != EStatusTask.TaskWorking) return;

            _task = EStatusTask.TaskStop;
        }

        private void TaskTimer_Tick(object sender, EventArgs e)
        {

            if (_task == EStatusTask.TaskStart) toolStripStatusLabel1.Text = @"Запуск задания";
            if (_task == EStatusTask.TaskPaused) toolStripStatusLabel1.Text = @"Пауза выполнения";
            if (_task == EStatusTask.TaskStop) toolStripStatusLabel1.Text = @"Остановка задания";
            if (_task == EStatusTask.TaskWorking) toolStripStatusLabel1.Text = @"Выполнение задания";
            if (_task == EStatusTask.Waiting) toolStripStatusLabel1.Text = @"ожидание";
            
            
            
            //TODO: вот тут основная поссылка данных

            int speedG1 = (int)numericUpDown1.Value;
            int speedG0 = (int)numericUpDown2.Value;               
 
            if (_task == EStatusTask.TaskStart)
            {
                AddLog("Запуск задания в " + DateTime.Now.ToLocalTime().ToString(CultureInfo.InvariantCulture));

                int MaxSpeedX = 100;
                int MaxSpeedY = 100;
                int MaxSpeedZ = 100;

                _cnc.SendBinaryData(BinaryData.pack_9E(0x05));
                _cnc.SendBinaryData(BinaryData.pack_BF(MaxSpeedX, MaxSpeedY, MaxSpeedZ));
                _cnc.SendBinaryData(BinaryData.pack_C0());

                _task = EStatusTask.TaskWorking;

                return;
            }


            //TODO: переделать
            if (_task == EStatusTask.TaskWorking)
            {

                if (_indexLineForTask >= dataCode.GKODready.Count)
                {
                    _task = EStatusTask.TaskStop;
                    return;
                }


                if (_cnc.AvailableBufferSize < 5) return;

                if (_indexLineForTask > (_cnc.NumberComleatedInstructions+3)) return;

                GKOD_ready gr = dataCode.GKODready[_indexLineForTask];

                int posX = deviceInfo.CalcPosPulse("X", gr.X);
                int posY = deviceInfo.CalcPosPulse("Y", gr.Y);
                int posZ = deviceInfo.CalcPosPulse("Z", gr.Z);
                int speed = (gr.workspeed) ? speedG1 : speedG0;

                _cnc.SendBinaryData(BinaryData.pack_CA(posX, posY, posZ, speed, _indexLineForTask));

                //TODO: распарсим и выполним
                _indexLineForTask++;
                textBoxNumberLine.Text = _indexLineForTask.ToString();

            }

            if (_task == EStatusTask.TaskStop)
            {
                _cnc.SendBinaryData(BinaryData.pack_FF());
                _cnc.SendBinaryData(BinaryData.pack_9D());
                _cnc.SendBinaryData(BinaryData.pack_9E(0x02));
                _cnc.SendBinaryData(BinaryData.pack_FF());
                _cnc.SendBinaryData(BinaryData.pack_FF());
                _cnc.SendBinaryData(BinaryData.pack_FF());
                _cnc.SendBinaryData(BinaryData.pack_FF());
                _cnc.SendBinaryData(BinaryData.pack_FF());

                AddLog("Завершение задания в " + DateTime.Now.ToLocalTime().ToString(CultureInfo.InvariantCulture));
                _task = EStatusTask.Waiting;
            }
        }

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

}
