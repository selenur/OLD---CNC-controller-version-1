using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CNC_Controller
{
    public partial class GeneratorCode : Form
    {

        private MainForm mf;

        private string code = "";


        public GeneratorCode(MainForm _mf)
        {
            mf = _mf;
            InitializeComponent();
        }

        //Генерация, и посылка новых данных
        private void RefreshData()
        {
            string code = "";

            // 1. прямолинейное движение к начальной точке
            code += "G0 X" + numPosX.Value.ToString() + " Y" + numPosY.Value.ToString() + "\n";
            code += "G1 Z" + numPosZ.Value.ToString() + "\n";

            // 2. движение змейкой


            bool toLeft = true; // направление движения змейки


            int countTask = (int)numericUpDown1.Value + 1;

            decimal posZ = numPosZ.Value;

            while (countTask > 0)
            {


                decimal posYNow = numPosY.Value;
                decimal posYMax = numPosY.Value + numericUpDownSizeY.Value;
                decimal posXMax = numPosX.Value + numericUpDownSizeX.Value;


                while (posYNow != posYMax)
                {
                    if (toLeft)
                    {
                        toLeft = false;
                        code += "G1 X" + posXMax.ToString() + "\n";
                    }
                    else
                    {
                        toLeft = true;
                        code += "G1 X" + numPosX.Value.ToString() + "\n";
                    }

                    if ((posYNow + numericUpDownDelta.Value) > (numPosY.Value + numericUpDownSizeY.Value))
                    {
                        posYNow = posYMax;
                    }
                    else
                    {
                        posYNow += numericUpDownDelta.Value;
                    }

                    code += "G1 Y" + posYNow.ToString() + "\n";
                }


                if (toLeft)
                {
                    code += "G1 X" + posXMax.ToString() + "\n";
                }
                else
                {
                    code += "G1 X" + numPosX.Value.ToString() + "\n";
                }

                posZ -= numericUpDown2.Value;

                code += "G0 Z" + posZ + "\n";



                countTask--;
            }




            //for (decimal y = numPosY.Value; y < (numPosY.Value + numericUpDownSizeY.Value); y += numericUpDownDelta.Value)
            //{

            //    

            //    //





            //}




            if (radioButton2.Checked)
            {
                // 3. Поднятие вверх
                code += "G0 Z" + numericUpDown3.Value.ToString() + "\n";
            }

            //пошлем сгенерированный код
            mf.LoadDataFromText(Regex.Split(code, "\n"));
        }




        private void GeneratorCode_Load(object sender, EventArgs e)
        {

        }

        private void buttonGenerateCode_Click(object sender, EventArgs e)
        {
            RefreshData();

        }
    }
}
