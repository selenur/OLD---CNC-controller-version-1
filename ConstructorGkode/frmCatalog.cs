using System;
using System.Windows.Forms;

namespace CNC_Controller.primitiv
{
    public partial class frmCatalog : Form
    {
        private MainForm mf;

        public frmCatalog(MainForm _mf)
        {
            mf = _mf;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btGetPosition_Click(object sender, EventArgs e)
        {
            numPosX.Value = deviceInfo.AxesX_PositionMM;
            numPosY.Value = deviceInfo.AxesY_PositionMM;
            numPosZ.Value = deviceInfo.AxesZ_PositionMM;
        }

        private void frmCatalog_Load(object sender, EventArgs e)
        {

        }
    }
}
