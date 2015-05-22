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
            numPosX.Value = deviceInfo.AxesX_PositionMM;
            numPosY.Value = deviceInfo.AxesY_PositionMM;
            numPosZ.Value = deviceInfo.AxesZ_PositionMM;
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
            numericUpDown7.Value =(decimal)( (double)numPosX.Value + (double)numericRadius.Value * Math.Cos((double)numericStart.Value * (Math.PI / 180)));
            numericUpDown6.Value = (decimal)( (double)numPosY.Value + (double)numericRadius.Value * Math.Sin((double)numericStart.Value * (Math.PI / 180)));

            numericUpDown8.Value =(decimal)(  (double)numPosX.Value + (double)numericRadius.Value * Math.Cos((double)numericStop.Value * (Math.PI / 180)));
            numericUpDown10.Value =(decimal)(  (double)numPosY.Value + (double)numericRadius.Value * Math.Sin((double)numericStop.Value * (Math.PI / 180)));

            numericUpDown5.Value = numPosZ.Value;
            numericUpDown9.Value = numPosZ.Value;

        }   
    }
}
