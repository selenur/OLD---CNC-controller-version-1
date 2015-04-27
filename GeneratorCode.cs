using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CNC_Controller
{
    public partial class GeneratorCode : Form
    {

        private CONTROLLER _ctrl;

        private string code = "";


        public GeneratorCode(ref CONTROLLER ctrl)
        {
            _ctrl = ctrl;
            InitializeComponent();
        }

        private void GeneratorCode_Load(object sender, EventArgs e)
        {

        }

        private void buttonGenerateCode_Click(object sender, EventArgs e)
        {
            // 1. прямолинейное движение к начальной точке
            code += "G0 X" + numPosX.Value.ToString() + " Y" + numPosY.Value.ToString() + " Z" + numPosZ.Value.ToString() + "\n";

            // 2. движение змейкой

            decimal posYNow = numPosY.Value;
            decimal posYMax = numPosY.Value + numericUpDownSizeY.Value;
            decimal posXMax = numPosX.Value + numericUpDownSizeX.Value;


            while (posYNow != posYMax)
            {
                code += "G0 X" + posXMax.ToString() + "\n";

                if ((posYNow + numericUpDownDelta.Value) > (numPosY.Value + numericUpDownSizeY.Value))
                {
                    posYNow = posYMax;
                }
                else
                {
                    posYNow += numericUpDownDelta.Value;
                }

                code += "G0 Y" + posYNow.ToString() + "\n";

                code += "G0 X" + numPosX.Value.ToString() + "\n";
            }




            //for (decimal y = numPosY.Value; y < (numPosY.Value + numericUpDownSizeY.Value); y += numericUpDownDelta.Value)
            //{

            //    

            //    //





            //}





            // 3. Поднятие вверх
            code += "G0 X" + numPosX.Value.ToString() + " Y" + numPosY.Value.ToString() + " Z" +
                    (numPosZ.Value + 10).ToString() + "\n";


        }
    }
}
