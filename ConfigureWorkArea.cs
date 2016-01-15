using System;
using System.Windows.Forms;

namespace CNC_Assist
{
    public partial class ConfigureWorkArea : Form
    {
        public ConfigureWorkArea()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobalSetting.ControllerSetting.WorkSizeXm = 0;
            GlobalSetting.ControllerSetting.WorkSizeYm = 0;
            GlobalSetting.ControllerSetting.WorkSizeXp = 0;
            GlobalSetting.ControllerSetting.WorkSizeYp = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GlobalSetting.SaveToFile();
        }
    }
}
