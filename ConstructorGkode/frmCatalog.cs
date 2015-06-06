using System;
using System.Windows.Forms;

namespace CNC_App.primitiv
{
    public partial class frmCatalog : Form
    {
        private MainForm mf;

        public frmCatalog(MainForm _mf)
        {
            mf = _mf;
            InitializeComponent();
        }

        private void btAppy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btGetPosition_Click(object sender, EventArgs e)
        {
            deltaX.Value = deviceInfo.AxesX_PositionMM;
            deltaY.Value = deviceInfo.AxesY_PositionMM;
            deltaZ.Value = deviceInfo.AxesZ_PositionMM;
        }

        private void frmCatalog_Load(object sender, EventArgs e)
        {

        }
    }
}
