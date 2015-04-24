using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CNC_Controller
{
    // ReSharper disable once InconsistentNaming
    public partial class ScanSurface : Form
    {
        // ReSharper disable once NotAccessedField.Local
        private CONTROLLER _ctrl;

        private dobPoint selectedPoint = null;
        private int selectedX = -1;
        private int selectedY = -1;
        
        public ScanSurface(ref CONTROLLER ctrl)
        {
            _ctrl = ctrl;
            InitializeComponent();
        }

        private void feeler_Load(object sender, EventArgs e)
        {
            //TODO: загрузить данные из существующей матрицы


            numPosX.Value = deviceInfo.AxesX_PositionMM;
            numPosY.Value = deviceInfo.AxesY_PositionMM;
            numPosZ.Value = deviceInfo.AxesZ_PositionMM;

            RefrechDataGrid();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            RefrechDataGrid();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            RefrechDataGrid();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            RefrechDataGrid();
        }

        private void numPosX_ValueChanged(object sender, EventArgs e)
        {
            RefrechDataGrid();
        }

        private void numPosY_ValueChanged(object sender, EventArgs e)
        {
            RefrechDataGrid();
        }

        private void RefrechDataGrid()
        {
            //наполним массив
            //dataCode.Matrix.Clear();

            dataCode.matrix2 = new dobPoint[(int)numCountX.Value, (int)numCountY.Value];

            for (int y = 0; y < numCountY.Value; y++)
            {
                //matrixYline matrixline = new matrixYline();
                
                //matrixline.Y = numPosY.Value + (y* numStep.Value);

                for (int x = 0; x < numCountX.Value; x++)
                {
                    dataCode.matrix2[x, y] = new dobPoint((double)numPosX.Value + (x * (double)numStepX.Value), (double)numPosY.Value + (y * (double)numStepY.Value), (double)numPosZ.Value);

                    //matrixline.X.Add(new matrixPoint(numPosX.Value + (x * numStep.Value), numPosZ.Value, true));
                }
                //dataCode.Matrix.Add(matrixline);
            }

            //и перезаполним таблицу
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            // в начале создадим незаполненную таблицу
            dataGridView.Columns.Add("nameY", "---");
            dataGridView.Rows.Add();
            
            for (int x = 0; x < numCountX.Value; x++)
            {
                dataGridView.Columns.Add("X" + x.ToString(), "");
                dataGridView.Rows[0].Cells[x+1].Value = "X " + (numPosX.Value + (x*numStepX.Value));
            }

            for (int y = 0; y < numCountY.Value; y++)
            {
                int index = dataGridView.Rows.Add();
                dataGridView.Rows[index].Cells[0].Value = "Y " + (numPosY.Value + (y * numStepY.Value));
            }

            for (int y = 0; y < numCountY.Value; y++)
            {
                for (int x = 0; x < numCountX.Value; x++)
                {
                    dataGridView.Rows[y + 1].Cells[x + 1].Value = dataCode.matrix2[x, y].Z;

                    //dataGridView.Rows[y + 1].Cells[x + 1].Value = dataCode.Matrix[y].X[x].Z;
                }
            }

        }

        private void numPosZ_ValueChanged(object sender, EventArgs e)
        {
            RefrechDataGrid();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView.ReadOnly = checkBox1.Checked;
        }        

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex;
            int y = e.RowIndex;

            if (x == 0 || y == 0) return;

            string ss = dataGridView.Rows[y].Cells[x].Value.ToString();
            decimal val = decimal.Parse(ss.Replace(".", ","));

            try
            {
                dataCode.matrix2[x - 1, y - 1].Z = (double)val;

                //dataCode.Matrix[y - 1].X[x - 1].Z = val;
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy) return; //небудем вклиниваться если что....

            if (Scan) return;

            _ctrl.SendBinaryData(BinaryData.pack_C0(0x01)); //вкл
            _ctrl.SendBinaryData(BinaryData.pack_D2((int)numSpeed.Value, (decimal)numReturn.Value));      // + настройка отхода, и скорости
            _ctrl.SendBinaryData(BinaryData.pack_C0(0x00)); //выкл
        }






        private bool Scan = false;
        private int indexScanX = 0;
        private int indexScanY = 0;
        private int indexMaxScanX = 0;
        private int indexMaxScanY = 0;
        
        private void button1_Click(object sender, EventArgs e)
        {
            //TODO: Добавить возможность выборочного сканирования

            if (Scan)
            {
                Scan = false;
            }
            else
            {

                if (backgroundWorker1.IsBusy) return; //пока ещё работает поток

                indexScanX = 0;
                indexScanY = 0;
                //indexMaxScanX = dataCode.Matrix[0].X.Count - 1;
                //indexMaxScanY = dataCode.Matrix.Count - 1;
                indexMaxScanX = (int)numCountX.Value - 1;
                indexMaxScanY = (int)numCountY.Value - 1;

                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void timerTASK_Tick_1(object sender, EventArgs e)
        {
            if (Scan)
            {
                button1.Text = @"Остановить";
            }
            else
            {
                button1.Text = @"Сканировать";
            }

            try
            {
               // dataGridView.Rows[indexScanY + 1].Cells[indexScanX + 1].Value = dataCode.Matrix[indexScanY].X[indexScanX].Z;
                dataGridView.Rows[indexScanY + 1].Cells[indexScanX + 1].Value = dataCode.matrix2[indexScanX, indexScanY].Z;
            }
            catch (Exception)
            {
                
               // throw;
            }
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Scan = true;

            while (Scan)
            {
                theads();
            }
        }

        // Поток выполняющий сканирование
        // TODO: при сканировании иногда заполняет сразу 2 ячейки в таблице?!?
        private void theads()
        {
            if (_ctrl.ShpindelMoveSpeed != 0) return;
            
            //координаты куда передвинуться
            //decimal px = dataCode.Matrix[indexScanY].X[indexScanX].X;
            decimal px = (decimal)dataCode.matrix2[indexScanX, indexScanY].X;
            //decimal pz = dataCode.Matrix[indexScanY].X[indexScanX].Z;
            decimal pz = numPosZ.Value;
            //decimal py = dataCode.Matrix[indexScanY].Y;
            decimal py = (decimal)dataCode.matrix2[indexScanX, indexScanY].Y;

            //спозиционируемся
            _ctrl.SendBinaryData(BinaryData.pack_CA(deviceInfo.CalcPosPulse("X", px), deviceInfo.CalcPosPulse("Y", py), deviceInfo.CalcPosPulse("Z", pz), (int)numSpeed.Value, 0));
            Thread.Sleep(100);

            //опустим щуп
            _ctrl.SendBinaryData(BinaryData.pack_C0(0x01)); //вкл
            _ctrl.SendBinaryData(BinaryData.pack_D2((int)numSpeed.Value, 0));      // + настройка отхода, и скорости
            _ctrl.SendBinaryData(BinaryData.pack_C0(0x00)); //выкл
            Thread.Sleep(100);

            while (!deviceInfo.AxesZ_LimitMax)
            {
                //dataCode.Matrix[indexScanY].X[indexScanX].Z = deviceInfo.AxesZ_PositionMM - numReturn.Value;
                Thread.Sleep(100);
            }

            
            Thread.Sleep(300);
            //dataCode.Matrix[indexScanY].X[indexScanX].Z = deviceInfo.AxesZ_PositionMM;
            dataCode.matrix2[indexScanX, indexScanY].Z = (double)deviceInfo.AxesZ_PositionMM;

            _ctrl.SendBinaryData(BinaryData.pack_C0(0x01)); //вкл
            _ctrl.SendBinaryData(BinaryData.pack_D2((int)numSpeed.Value, (decimal)numReturn.Value));      // + настройка отхода, и скорости
            _ctrl.SendBinaryData(BinaryData.pack_C0(0x00)); //выкл
            Thread.Sleep(100);
            //спозиционируемся
            _ctrl.SendBinaryData(BinaryData.pack_CA(deviceInfo.CalcPosPulse("X", px), deviceInfo.CalcPosPulse("Y", py), deviceInfo.CalcPosPulse("Z", pz), (int)numSpeed.Value, 0));
            Thread.Sleep(100);

            if (indexScanX == indexMaxScanX && indexScanY == indexMaxScanY)
            {
                Scan = false;
                _ctrl.SendBinaryData(BinaryData.pack_FF());
            }

            if (indexScanX < indexMaxScanX)
            {
                indexScanX++;
            }
            else
            {
                indexScanX = 0;

                if (indexScanY < indexMaxScanY)
                {
                    indexScanY++;
                }
                else
                {
                    indexScanY = 0;
                }
            }
        }

        private void numStepY_ValueChanged(object sender, EventArgs e)
        {
            RefrechDataGrid();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (selectedPoint == null)
            {
                label10.Text = @"X: 000.000  Y: 000.000";
                return;
            }

            label10.Text = @"X: " + selectedPoint.X + @"  Y: " + selectedPoint.Y;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex-1;
            int y = e.RowIndex-1;

            if (x < 0 || y < 0)
            {
                selectedPoint = null;

                selectedX = -1;
                selectedY = -1;
            }
            else
            {
                selectedPoint = new dobPoint(dataCode.matrix2[x, y].X, dataCode.matrix2[x, y].Y, dataCode.matrix2[x, y].Z);
                selectedX = x;
                selectedY = y;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (!_ctrl.TestAllowActions()) return;

            if (selectedPoint == null) return;

            int speed = 200;

            _ctrl.SendBinaryData(BinaryData.pack_9E(0x05));
            _ctrl.SendBinaryData(BinaryData.pack_BF(speed, speed, speed));
            _ctrl.SendBinaryData(BinaryData.pack_C0());
            _ctrl.SendBinaryData(BinaryData.pack_CA(deviceInfo.CalcPosPulse("X", (decimal)selectedPoint.X), deviceInfo.CalcPosPulse("Y", (decimal)selectedPoint.Y), deviceInfo.CalcPosPulse("Z", (decimal)selectedPoint.Z), speed, 0));
            _ctrl.SendBinaryData(BinaryData.pack_FF());
            _ctrl.SendBinaryData(BinaryData.pack_9D());
            _ctrl.SendBinaryData(BinaryData.pack_9E(0x02));
            _ctrl.SendBinaryData(BinaryData.pack_FF());
            _ctrl.SendBinaryData(BinaryData.pack_FF());
            _ctrl.SendBinaryData(BinaryData.pack_FF());
            _ctrl.SendBinaryData(BinaryData.pack_FF());
            _ctrl.SendBinaryData(BinaryData.pack_FF());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 
            
            //узнаем координаты из таблицы, куда все поместить

            if (selectedX == -1 || selectedY == -1) return;

            dataCode.matrix2[selectedX, selectedY].Z = (double)deviceInfo.AxesZ_PositionMM;
            dataGridView.Rows[selectedY + 1].Cells[selectedX + 1].Value = dataCode.matrix2[selectedX, selectedY].Z;

        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            button6.BackColor = Color.DarkGreen;
            _ctrl.StartManualMove("0", "0", "+", 100);       
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            button6.BackColor = Color.FromName("Control");
            _ctrl.StopManualMove();        
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            button5.BackColor = Color.DarkGreen;
            _ctrl.StartManualMove("0", "0", "-", 100);
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            button5.BackColor = Color.FromName("Control");
            _ctrl.StopManualMove();
        }




    }
}

