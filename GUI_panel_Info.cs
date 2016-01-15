using System;
using System.Windows.Forms;

namespace CNC_Assist
{
    public partial class GUI_panel_Info : UserControl
    {
        public GUI_panel_Info()
        {
            InitializeComponent();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            this.Enabled = Controller.Connected;
            labelSpeed.Text = Controller.INFO.shpindel_MoveSpeed.ToString() + @" мм./мин.";
        }
    }
}
