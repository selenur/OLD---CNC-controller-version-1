using System;
using System.Windows.Forms;
using CNC_App.Controllers;

namespace CNC_App
{
    public partial class setting : Form
    {
        public Setting _setting;

        public setting()
        {
            InitializeComponent();
        }       

        private void setting_Load(object sender, EventArgs e)
        {

            numPulseX.Value = (decimal)_setting.pulseX;
            numPulseY.Value = (decimal)_setting.pulseY;
            numPulseZ.Value = (decimal)_setting.pulseZ;

            switch (_setting.kind)
            {
                    case KindControllers.Emulator:
                    rbType_Emulator.Checked = true;
                    break;

                    case KindControllers.MK1:
                    rbType_MK1.Checked = true;
                    break;

                    case KindControllers.MK2:
                    rbType_MK2.Checked = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _setting.pulseX = (int)numPulseX.Value;
            _setting.pulseY = (int)numPulseY.Value;
            _setting.pulseZ = (int)numPulseZ.Value;

            if (rbType_Emulator.Checked) _setting.kind = KindControllers.Emulator;

            if (rbType_MK1.Checked) _setting.kind = KindControllers.MK1;

            if (rbType_MK2.Checked) _setting.kind = KindControllers.MK2;
        }
    }
}
