using System;
using System.Drawing;
using System.Windows.Forms;

namespace CNC_Assist
{
    public partial class GUI_panel_Limits : UserControl
    {
        public GUI_panel_Limits()
        {
            InitializeComponent();
        }

        private void timerCheckStatus_Tick(object sender, EventArgs e)
        {
            this.Enabled = Controller.Connected;
            Bitmap bGrey = Properties.Resources.draw_ellipse;
            Bitmap bRed = Properties.Resources.ball_red;

            labelXmax.Image = Controller.INFO.AxesX_LimitMax ? bRed : bGrey;
            labelXmin.Image = Controller.INFO.AxesX_LimitMin ? bRed : bGrey;
            labelYmax.Image = Controller.INFO.AxesY_LimitMax ? bRed : bGrey;
            labelYmin.Image = Controller.INFO.AxesY_LimitMin ? bRed : bGrey;
            labelZmax.Image = Controller.INFO.AxesZ_LimitMax ? bRed : bGrey;
            labelZmin.Image = Controller.INFO.AxesZ_LimitMin ? bRed : bGrey;
            //TODO: add AxesA
        }
    }
}
