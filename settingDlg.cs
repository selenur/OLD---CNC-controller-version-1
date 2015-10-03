using System;
using System.Windows.Forms;

namespace CNC_App
{
    public partial class setting : Form
    {

        public setting()
        {
            InitializeComponent();
        }       

        private void setting_Load(object sender, EventArgs e)
        {
            numPulseX.Value = (decimal)Setting.PulseX;
            numPulseY.Value = (decimal)Setting.PulseY;
            numPulseZ.Value = (decimal)Setting.PulseZ;
            checkBoxAutoConnect.Checked = Setting.StartupConnect;

            switch (Setting.DeviceModel)
            {
                case DeviceModel.Emulator:
                    rbType_Emulator.Checked = true;
                    break;

                case DeviceModel.MK1:
                    rbType_MK1.Checked = true;
                    break;

                case DeviceModel.MK2:
                    rbType_MK2.Checked = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Setting.PulseX = (int)numPulseX.Value;
            Setting.PulseY = (int)numPulseY.Value;
            Setting.PulseZ = (int)numPulseZ.Value;
            Setting.StartupConnect = checkBoxAutoConnect.Checked;

            if (rbType_Emulator.Checked) Setting.DeviceModel = DeviceModel.Emulator;

            if (rbType_MK1.Checked) Setting.DeviceModel = DeviceModel.MK1;

            if (rbType_MK2.Checked) Setting.DeviceModel = DeviceModel.MK2;

            Setting.SaveSetting();

        }
    }
}
