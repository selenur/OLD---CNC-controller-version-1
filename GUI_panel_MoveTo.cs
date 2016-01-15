using System;
using System.Windows.Forms;

namespace CNC_Assist
{
    public partial class GUI_panel_MoveTo : UserControl
    {
        public GUI_panel_MoveTo()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Controller.TestAllowActions()) return;

            Controller.SendBinaryData(BinaryData.pack_9E(0x05));
            Controller.SendBinaryData(BinaryData.pack_BF((int)numericUpDown3.Value, (int)numericUpDown3.Value, (int)numericUpDown3.Value, 0));
            Controller.SendBinaryData(BinaryData.pack_C0());
            //Controller.SendBinaryData(BinaryData.pack_CA(Controller.INFO.CalcPosPulse("X", numericUpDown6.Value), Controller.INFO.CalcPosPulse("Y", numericUpDown5.Value), Controller.INFO.CalcPosPulse("Z", numericUpDown4.Value), 0, (int)numericUpDown3.Value, 0, 0, 0));
            Controller.SendBinaryData(BinaryData.pack_FF());
            Controller.SendBinaryData(BinaryData.pack_9D());
            Controller.SendBinaryData(BinaryData.pack_9E(0x02));
            Controller.SendBinaryData(BinaryData.pack_FF());
            Controller.SendBinaryData(BinaryData.pack_FF());
            Controller.SendBinaryData(BinaryData.pack_FF());
            Controller.SendBinaryData(BinaryData.pack_FF());
            Controller.SendBinaryData(BinaryData.pack_FF());
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (Controller.Connected)
            {
                Enabled = !Controller.Locked;
            }
            else
            {
                Enabled = false;
            }
        }
    }
}
