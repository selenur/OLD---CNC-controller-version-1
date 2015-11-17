/*
 * ru - Данная панель является частью графического интерфейса для отображения координат станка
 * 
 * en - This panel is part of a graphical user interface for displaying the machine coordinate
 * 
 */


using System;
using System.Windows.Forms;

namespace CNC_App
{
    public partial class GUI_panel_POS : UserControl
    {
        public GUI_panel_POS()
        {
            InitializeComponent();

            if (Setting.language == eLanguage.rus)
            {
                groupBoxPositions.Text = @"Координаты";
            }
            else
            {
                groupBoxPositions.Text = @"Position";
            }
        }

        private void GUI_panel_POS_Load(object sender, EventArgs e)
        {

        }

        private void buttonXtoZero_Click(object sender, EventArgs e)
        {
            Controller.DeviceNewPosition(0, deviceInfo.AxesY_PositionPulse, deviceInfo.AxesZ_PositionPulse);
        }

        private void buttonYtoZero_Click(object sender, EventArgs e)
        {
            Controller.DeviceNewPosition(deviceInfo.AxesX_PositionPulse, 0, deviceInfo.AxesZ_PositionPulse);
        }

        private void buttonZtoZero_Click(object sender, EventArgs e)
        {
            Controller.DeviceNewPosition(deviceInfo.AxesX_PositionPulse, deviceInfo.AxesY_PositionPulse, 0);
        }

        private void buttonAtoZero_Click(object sender, EventArgs e)
        {

        }


        //необходимость обновить данные на контроле
        public void RefreshControl()
        {
            this.Enabled = Controller.Connected;

            numPosX.Value = deviceInfo.AxesX_PositionMM;
            numPosY.Value = deviceInfo.AxesY_PositionMM;
            numPosZ.Value = deviceInfo.AxesZ_PositionMM;
            numPosA.Value = deviceInfo.AxesA_PositionMM;

            if (Task.StatusTask == statusVariant.Waiting)
            {
                buttonXtoZero.Enabled = true;
                buttonYtoZero.Enabled = true;
                buttonZtoZero.Enabled = true;
                buttonAtoZero.Enabled = true;
            }
            else
            {
                buttonXtoZero.Enabled = false;
                buttonYtoZero.Enabled = false;
                buttonZtoZero.Enabled = false;
                buttonAtoZero.Enabled = false;
            }
        }
    }
}
