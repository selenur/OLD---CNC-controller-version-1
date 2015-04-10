using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CNC_Controller
{
    public partial class EditGkode : Form
    {
        //Доступ к основной форме
        private MainForm mf;

        public EditGkode(MainForm _mf)
        {
            InitializeComponent();
            mf = _mf;
        }

        private void EditGkode_Load(object sender, EventArgs e)
        {
            checkBoxChangePos.Checked = mf.deltaUsage;
            numPosX.Value = (decimal)mf.deltaX;
            numPosY.Value = (decimal)mf.deltaY;
            numPosZ.Value = (decimal)mf.deltaZ;

            checkBox6.Checked = mf.deltaFeed;

        }

        private void checkBoxChangePos_CheckedChanged(object sender, EventArgs e)
        {
            mf.deltaUsage = checkBoxChangePos.Checked;
        }

        private void numPosX_ValueChanged(object sender, EventArgs e)
        {
            mf.deltaX = (double)numPosX.Value;
        }

        private void numPosY_ValueChanged(object sender, EventArgs e)
        {
            mf.deltaY = (double)numPosY.Value;
        }

        private void numPosZ_ValueChanged(object sender, EventArgs e)
        {
            mf.deltaZ = (double)numPosZ.Value;
        }




        //private void checkBox6_CheckedChanged(object sender, EventArgs e)
        //{
        //    mf.deltaFeed = checkBox6.Checked;
        //}
    }
}
