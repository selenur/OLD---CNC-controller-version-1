using System;
using System.Windows.Forms;

namespace CNC_App.primitiv
{
    public partial class frmPoint : Form
    {
        public frmPoint()
        {
            InitializeComponent();
        }

        private void btGetPosition_Click(object sender, EventArgs e)
        {
            numPosX.Value = deviceInfo.AxesX_PositionMM;
            numPosY.Value = deviceInfo.AxesY_PositionMM;
            numPosZ.Value = deviceInfo.AxesZ_PositionMM;
        }
    }
}
