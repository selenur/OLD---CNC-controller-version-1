using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNC_Controller
{
    public partial class KeyInfo : Form
    {
        CONTROLLER _cnc;

        public KeyInfo(ref CONTROLLER cnc)
        {
            InitializeComponent();
            _cnc = cnc;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //// -x
            //if (num1 || num4 || num7) _x = "-";
            //// +x
            //if (num3 || num6 || num9) _x = "+";

            //// -y
            //if (num1 || num2 || num3) _y = "-";
            //// +y
            //if (num7 || num8 || num9) _y = "+";

            //// -z
            //if (num0) _z = "-";
            //// +z
            //if (num5) _z = "+";

            //CNC.StartManualMove(_x, _y, _z, (int)numericUpDownManualSpeed.Value);
        }

        private void KeyInfo_Load(object sender, EventArgs e)
        {

        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            button8.BackColor = Color.DarkGreen;
            _cnc.StartManualMove("+","-","0", (int)numericUpDown1.Value);
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            button8.BackColor = Color.FromName("Control");
            _cnc.StopManualMove();
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.FromName("Control");
            _cnc.StopManualMove();
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.DarkGreen;
            _cnc.StartManualMove("0", "+", "0", (int)numericUpDown1.Value);
        }

        private void button10_MouseDown(object sender, MouseEventArgs e)
        {
            button10.BackColor = Color.DarkGreen;
            _cnc.StartManualMove("+", "+", "0", (int)numericUpDown1.Value);
        }

        private void button10_MouseUp(object sender, MouseEventArgs e)
        {
            button10.BackColor = Color.FromName("Control");
            _cnc.StopManualMove();
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            button7.BackColor = Color.DarkGreen;
            _cnc.StartManualMove("+", "0", "0", (int)numericUpDown1.Value);
        }

        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            button7.BackColor = Color.FromName("Control");
            _cnc.StopManualMove();
        }

        private void button11_MouseDown(object sender, MouseEventArgs e)
        {
            button11.BackColor = Color.DarkGreen;
            _cnc.StartManualMove("+", "-", "0", (int)numericUpDown1.Value);
        }

        private void button11_MouseUp(object sender, MouseEventArgs e)
        {
            button11.BackColor = Color.FromName("Control");
            _cnc.StopManualMove();
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.DarkGreen;
            _cnc.StartManualMove("0", "-", "0", (int)numericUpDown1.Value);
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.FromName("Control");
            _cnc.StopManualMove();
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            button9.BackColor = Color.DarkGreen;
            _cnc.StartManualMove("-", "-", "0", (int)numericUpDown1.Value);
        }

        private void button9_MouseUp(object sender, MouseEventArgs e)
        {
            button9.BackColor = Color.FromName("Control");
            _cnc.StopManualMove();
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            button6.BackColor = Color.DarkGreen;
            _cnc.StartManualMove("-", "0", "0", (int)numericUpDown1.Value);
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            button6.BackColor = Color.FromName("Control");
            _cnc.StopManualMove();
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.DarkGreen;
            _cnc.StartManualMove("0", "0", "+", (int)numericUpDown1.Value);
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.FromName("Control");
            _cnc.StopManualMove();
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            button5.BackColor = Color.DarkGreen;
            _cnc.StartManualMove("0", "0", "-", (int)numericUpDown1.Value);
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            button5.BackColor = Color.FromName("Control");
            _cnc.StopManualMove();
        }
    }
}
