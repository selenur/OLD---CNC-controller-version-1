using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CNC_Controller.ConstructorGkode
{
    public partial class frmRotate : Form
    {
        private MainForm mf;

        public frmRotate(MainForm _mf)
        {
            mf = _mf;
            InitializeComponent();
        }

        private void frmRotate_Load(object sender, EventArgs e)
        {

        }

        private void btGetPosition_Click(object sender, EventArgs e)
        {
            centerX.Value = deviceInfo.AxesX_PositionMM;
            centerY.Value = deviceInfo.AxesY_PositionMM;
            centerZ.Value = deviceInfo.AxesZ_PositionMM;
            CalculatePos();
        }

        private void numPosX_ValueChanged(object sender, EventArgs e)
        {
            CalculatePos();
        }

        private void numPosY_ValueChanged(object sender, EventArgs e)
        {
            CalculatePos();
        }

        private void numPosZ_ValueChanged(object sender, EventArgs e)
        {
            CalculatePos();
        }

        private void numericRadius_ValueChanged(object sender, EventArgs e)
        {
            CalculatePos();
        }

        private void numericStart_ValueChanged(object sender, EventArgs e)
        {
            CalculatePos();
        }

        private void numericStop_ValueChanged(object sender, EventArgs e)
        {
            CalculatePos();
        }

        private void numericStep_ValueChanged(object sender, EventArgs e)
        {
            CalculatePos();
        }



        // Вычисление начальной и конечной точки
        private void CalculatePos()
        {
            arcStartX.Value =(decimal)( (double)centerX.Value + (double)rotateRadius.Value * Math.Cos((double)rotateStartAngle.Value * (Math.PI / 180)));
            arcStartY.Value = (decimal)( (double)centerY.Value + (double)rotateRadius.Value * Math.Sin((double)rotateStartAngle.Value * (Math.PI / 180)));

            arcStopX.Value =(decimal)(  (double)centerX.Value + (double)rotateRadius.Value * Math.Cos((double)rotateStopAngle.Value * (Math.PI / 180)));
            arcStopY.Value =(decimal)(  (double)centerY.Value + (double)rotateRadius.Value * Math.Sin((double)rotateStopAngle.Value * (Math.PI / 180)));

            arcStartZ.Value = centerZ.Value;
            arcStopZ.Value = centerZ.Value;

        }

 
    }
}
