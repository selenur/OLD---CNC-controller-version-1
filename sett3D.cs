using System;
using System.Windows.Forms;

namespace CNC_Controller
{
    public partial class Sett3D : Form
    {
        MainForm mf;

        public Sett3D(MainForm _mf)
        {
            if (_mf == null) throw new ArgumentNullException("_mf");
            InitializeComponent();
            mf = _mf;
        }

        private void sett3D_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = mf.PreviewSetting.ShowInstrument;
            checkBox2.Checked = mf.PreviewSetting.ShowGrid;
            checkBox3.Checked = mf.PreviewSetting.ShowMatrix;
            checkBox4.Checked = mf.PreviewSetting.ShowAxes;
            
            numericUpDown1.Value = mf.PreviewSetting.GrigStep;

            numericUpDown2.Value=mf.PreviewSetting.GridXstart;
            numericUpDown3.Value=mf.PreviewSetting.GridXend;
            numericUpDown4.Value=mf.PreviewSetting.GridYstart;
            numericUpDown5.Value=mf.PreviewSetting.GridYend;

            checkBoxShowGrate.Checked = mf.ShowGrate;
            numPosXmin.Value = (decimal)mf.grateXmin;
            numPosXmax.Value = (decimal)mf.grateXmax;
            numPosYmin.Value = (decimal)mf.grateYmin;
            numPosYmax.Value = (decimal)mf.grateYmax;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            mf.PreviewSetting.ShowInstrument = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            mf.PreviewSetting.ShowGrid = checkBox2.Checked;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            mf.PreviewSetting.GrigStep = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            mf.PreviewSetting.GridXstart = (int)numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            mf.PreviewSetting.GridXend = (int)numericUpDown3.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            mf.PreviewSetting.GridYstart = (int)numericUpDown4.Value;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            mf.PreviewSetting.GridYend = (int)numericUpDown5.Value;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            mf.PreviewSetting.ShowMatrix = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            mf.PreviewSetting.ShowAxes = checkBox4.Checked;
        }

        private void checkBoxShowGrate_CheckedChanged(object sender, EventArgs e)
        {
            mf.ShowGrate = checkBoxShowGrate.Checked;
        }

        private void numPosXmin_ValueChanged(object sender, EventArgs e)
        {
            mf.grateXmin = (double)numPosXmin.Value;
        }

        private void numPosXmax_ValueChanged(object sender, EventArgs e)
        {
            mf.grateXmax = (double)numPosXmax.Value;
        }

        private void numPosYmin_ValueChanged(object sender, EventArgs e)
        {
            mf.grateYmin = (double)numPosYmin.Value;
        }

        private void numPosYmax_ValueChanged(object sender, EventArgs e)
        {
            mf.grateYmax = (double)numPosYmax.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mf.grateXmin = (double)deviceInfo.AxesX_PositionMM;
            mf.grateXmax = (double)deviceInfo.AxesX_PositionMM;
            mf.grateYmin = (double)deviceInfo.AxesY_PositionMM;
            mf.grateYmax = (double)deviceInfo.AxesY_PositionMM;
        }
    }
}
