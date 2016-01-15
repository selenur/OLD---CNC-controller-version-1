using System;
using System.Windows.Forms;

namespace CNC_Assist
{
    public partial class GUI_panel_BitValue : UserControl
    {
        public GUI_panel_BitValue()
        {
            InitializeComponent();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (!Controller.Connected) return;

            //DEBUG:
            SuperByte bb14 = new SuperByte(Controller.INFO.rawData[14]);

            checkBoxB0.Checked = bb14.Bit0;
            checkBoxB1.Checked = bb14.Bit1;
            checkBoxB2.Checked = bb14.Bit2;
            checkBoxB3.Checked = bb14.Bit3;
            checkBoxB4.Checked = bb14.Bit4;
            checkBoxB5.Checked = bb14.Bit5;
            checkBoxB6.Checked = bb14.Bit6;
            checkBoxB7.Checked = bb14.Bit7;


            SuperByte bb15 = new SuperByte(Controller.INFO.rawData[15]);

            checkBox9.Checked = bb15.Bit7;
            checkBox8.Checked = bb15.Bit6;
            checkBox7.Checked = bb15.Bit5;
            checkBox6.Checked = bb15.Bit4;
            checkBox5.Checked = bb15.Bit3;
            checkBox4.Checked = bb15.Bit2;
            checkBox3.Checked = bb15.Bit1;
            checkBox2.Checked = bb15.Bit0;


            SuperByte bb19 = new SuperByte(Controller.INFO.rawData[19]);

            checkBox10.Checked = bb19.Bit0;
            checkBox11.Checked = bb19.Bit1;
            checkBox12.Checked = bb19.Bit2;
            checkBox13.Checked = bb19.Bit3;
            checkBox14.Checked = bb19.Bit4;
            checkBox15.Checked = bb19.Bit5;
            checkBox16.Checked = bb19.Bit6;
            checkBox17.Checked = bb19.Bit7;


            label_FreeSizeBuffer.Text = Controller.INFO.FreebuffSize.ToString();

            // end debug
        }




            ////        if (Controller.Connected)
            ////{
            ////    labelStatusConnect.Image = Resources.ball_green;
            ////    labelStatusConnect.Text = @"Физически подключен";
            ////    label_FreeSizeBuffer.ForeColor = Color.MidnightBlue;
            ////    label_FreeSizeBuffer.Text = Controller.AvailableBufferSize.ToString();
            ////}
            ////else
            ////{
            ////    //vid 2121 pid 2130 в десятичной системе будет как 8481 и 8496 соответственно
            ////    UsbDeviceFinder myUsbFinder = new UsbDeviceFinder(8481, 8496);

            ////    UsbDevice myUsbDevice = UsbDevice.OpenUsbDevice(myUsbFinder);

            ////    if (myUsbDevice == null)
            ////    {
            ////        labelStatusConnect.Image = Resources.ball_red;
            ////        labelStatusConnect.Text = @"Физически отключен";
            ////        label_FreeSizeBuffer.ForeColor = Color.DarkRed;
            ////        label_FreeSizeBuffer.Text = @"нет связи с программой";

            ////    }
            ////    else
            ////    {
            ////        labelStatusConnect.Image = Resources.ball_green;
            ////        labelStatusConnect.Text = @"Физически подключен";
            ////        label_FreeSizeBuffer.ForeColor = Color.DarkRed;
            ////        label_FreeSizeBuffer.Text = @"нет связи с программой";
            ////        myUsbDevice.Close();
            ////    }
            ////}
    }
}
