using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CNC_Controller
{
    public partial class setting : Form
    {
        CONTROLLER _cnc;

        public setting(ref CONTROLLER cnc)
        {
            InitializeComponent();
            _cnc = cnc;
        }       

        private void setting_Load(object sender, EventArgs e)
        {
            numPulseX.Value = (decimal)deviceInfo.AxesX_PulsePerMm;
            numPulseY.Value = (decimal)deviceInfo.AxesY_PulsePerMm;
            numPulseZ.Value = (decimal)deviceInfo.AxesZ_PulsePerMm;
            checkBoxDemoController.Checked = deviceInfo.DEMO_DEVICE;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            deviceInfo.AxesX_PulsePerMm = (int)numPulseX.Value;
            deviceInfo.AxesY_PulsePerMm = (int)numPulseY.Value;
            deviceInfo.AxesZ_PulsePerMm = (int)numPulseZ.Value;
            deviceInfo.DEMO_DEVICE      = checkBoxDemoController.Checked;
        }
    }
}
