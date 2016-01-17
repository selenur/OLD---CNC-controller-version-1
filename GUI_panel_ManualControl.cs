using System;
using System.Windows.Forms;

namespace CNC_Assist
{
    public partial class GUI_panel_ManualControl : UserControl
    {
        public GUI_panel_ManualControl()
        {
            InitializeComponent();
            if (GlobalSetting.AppSetting.Language == Languages.Russian)
            {
                groupBoxManualMove.Text = @"Ручное управление";
                checkBoxManualMove.Text = @"Управление с NumPad";
                lbSpeed.Text = @"Скорость:";
                buttonShowKeyInfo.Text = @"Управление мышкой";
                groupBox1.Text = @"Выполнить G-код";
                buttonSend.Text = @"Выполнить";
            }
            else
            {
                groupBoxManualMove.Text = @"Manual control";
                checkBoxManualMove.Text = @"Control with NumPad";
                lbSpeed.Text = @"Speed:";
                buttonShowKeyInfo.Text = @"Control with mouse";
                groupBox1.Text = @"Run G-kod";
                buttonSend.Text = @"RUN";
            }

        }

        private void buttonShowKeyInfo_Click(object sender, EventArgs e)
        {
            ManualControl kf = new ManualControl();
            kf.Show();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (Controller.Connected)
            {
                if (Controller.Locked)
                {
                    this.Enabled = false;
                }
                else
                {
                    this.Enabled = true;
                }
            }
            else
            {
                this.Enabled = false;
            }
        }

        private void checkBoxManualMove_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownManualSpeed.Enabled = checkBoxManualMove.Checked;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (Controller.Locked) return;

            if (tbSendGKode.Text.Trim() == "") return;


            Controller.Locked = true;

            Controller.ExecuteCommand(tbSendGKode.Text);

            Controller.Locked = false;

            tbSendGKode.Text = "";
        }

        private void tbSendGKode_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSendGKode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Controller.Locked) return;

                if (tbSendGKode.Text.Trim() == "") return;

                Controller.Locked = true;

                Controller.ExecuteCommand(tbSendGKode.Text);

                Controller.Locked = false; 
                
                tbSendGKode.Text = "";
            }
        }
    }
}
