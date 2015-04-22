using System;
using System.Windows.Forms;

namespace CNC_Controller
{
    public partial class EditGkode : Form
    {
        //Доступ к основной форме
        private MainForm mf;

        public EditGkode(MainForm _mf)
        {
            if (_mf == null) throw new ArgumentNullException(@"Ошибка инициализации формы 'Корректировка G-кода'");
            InitializeComponent();
            mf = _mf;
        }

        private void EditGkode_Load(object sender, EventArgs e)
        {
            cbCorrection.Checked = mf.Correction;
            numPosX.Value = (decimal)mf.deltaX;
            numPosY.Value = (decimal)mf.deltaY;
            numPosZ.Value = (decimal)mf.deltaZ;

            checkBox6.Checked = mf.deltaFeed;

            numericUpDown1.Value = (decimal)mf.koeffSizeX;
            numericUpDown2.Value = (decimal)mf.koeffSizeY;

            groupBox1.Enabled = cbCorrection.Checked;
            groupBox2.Enabled = cbCorrection.Checked;
            checkBox6.Enabled = cbCorrection.Checked;
        }

        private void ccbCorrection_CheckedChanged(object sender, EventArgs e)
        {
            mf.Correction = cbCorrection.Checked;
            groupBox1.Enabled = cbCorrection.Checked;
            groupBox2.Enabled = cbCorrection.Checked;
            checkBox6.Enabled = cbCorrection.Checked;
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

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            mf.deltaFeed = checkBox6.Checked;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            mf.koeffSizeX = (double)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            mf.koeffSizeY = (double)numericUpDown2.Value;
        }
    }
}
