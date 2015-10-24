using System;
using System.Windows.Forms;

namespace CNC_App
{
    public partial class testSpeed : Form
    {
        public testSpeed()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Controller.Connected)
            {
                return;
            }


            int MaxSpeedX = (int)numericUpDown_maxSpeedX.Value;
            int MaxSpeedY = (int)numericUpDown_maxSpeedX.Value;
            int MaxSpeedZ = (int)numericUpDown_maxSpeedX.Value;

            // start
            Controller.SendBinaryData(BinaryData.pack_9E(0x05));
            Controller.SendBinaryData(BinaryData.pack_BF(MaxSpeedX, MaxSpeedY, MaxSpeedZ));
            Controller.SendBinaryData(BinaryData.pack_C0());


            //move
            int speed = (int)numericUpDown_Speed.Value;
            //текущая точка
            int posX0 = deviceInfo.CalcPosPulse("X", (decimal)numPosX0.Value);
            int posY0 = deviceInfo.AxesY_PositionPulse;
            int posZ0 = deviceInfo.AxesZ_PositionPulse;
            //куда двигаться
            int posX1 = deviceInfo.CalcPosPulse("X", (decimal)numPosX1.Value);
            int posY1 = posY0;
            int posZ1 = posZ0;

            Controller.SendBinaryData(BinaryData.pack_CA(posX1, posY1, posZ1, speed, Task.posCodeNow, 0, 0));
            Controller.SendBinaryData(BinaryData.pack_CA(posX1, posY1, posZ1, speed, Task.posCodeNow, 0, 0));

            Controller.SendBinaryData(BinaryData.pack_CA(posX0, posY0, posZ0, speed, Task.posCodeNow, 0, 0));
            Controller.SendBinaryData(BinaryData.pack_CA(posX0, posY0, posZ0, speed, Task.posCodeNow, 0, 0));

            //stop
            Controller.SendBinaryData(BinaryData.pack_FF());
            Controller.SendBinaryData(BinaryData.pack_9D());
            Controller.SendBinaryData(BinaryData.pack_9E(0x02));
            Controller.SendBinaryData(BinaryData.pack_FF());
            Controller.SendBinaryData(BinaryData.pack_FF());
            Controller.SendBinaryData(BinaryData.pack_FF());
            Controller.SendBinaryData(BinaryData.pack_FF());
            Controller.SendBinaryData(BinaryData.pack_FF());
        }
    }
}
