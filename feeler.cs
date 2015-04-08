using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CNC_Controller
{
    // ReSharper disable once InconsistentNaming
    public partial class feeler : Form
    {
        // ReSharper disable once NotAccessedField.Local
        private CONTROLLER _ctrl;
        
        public feeler(ref CONTROLLER ctrl)
        {
            _ctrl = ctrl;
            InitializeComponent();
        }

        private void feeler_Load(object sender, EventArgs e)
        {
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
            dataCode.Matrix.Clear();

            for (int y = 0; y < numCountY.Value; y++)
            {
                matrixYline matrixline = new matrixYline();
                matrixline.Y = numPosY.Value + (y* numStep.Value);

                for (int x = 0; x < numCountX.Value; x++)
                {
                    matrixline.X.Add(new matrixPoint(numPosX.Value + (x * numStep.Value), numPosZ.Value, true));
                }
                dataCode.Matrix.Add(matrixline);
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
                dataGridView.Rows[0].Cells[x+1].Value = "X " + (numPosX.Value + (x*numStep.Value)).ToString();
            }

            for (int y = 0; y < numCountY.Value; y++)
            {
                int index = dataGridView.Rows.Add();
                dataGridView.Rows[index].Cells[0].Value = "Y " + (numPosY.Value + (y * numStep.Value)).ToString();
            }

            for (int y = 0; y < numCountY.Value; y++)
            {
                for (int x = 0; x < numCountX.Value; x++)
                {
                    dataGridView.Rows[y + 1].Cells[x + 1].Value = dataCode.Matrix[y].X[x].Z;
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
                dataCode.Matrix[y - 1].X[x - 1].Z = val;
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
                indexMaxScanX = dataCode.Matrix[0].X.Count -1;
                indexMaxScanY = dataCode.Matrix.Count - 1;

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
                dataGridView.Rows[indexScanY + 1].Cells[indexScanX + 1].Value = dataCode.Matrix[indexScanY].X[indexScanX].Z;
            }
            catch (Exception)
            {
                
               // throw;
            }
            
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
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
            decimal px = dataCode.Matrix[indexScanY].X[indexScanX].X;
            //decimal pz = dataCode.Matrix[indexScanY].X[indexScanX].Z;
            decimal pz = numPosZ.Value;
            decimal py = dataCode.Matrix[indexScanY].Y;

            //спозиционируемся
            _ctrl.SendBinaryData(BinaryData.pack_CA(deviceInfo.CalcPosPulse("X", px), deviceInfo.CalcPosPulse("Y", py), deviceInfo.CalcPosPulse("Z", pz), (int)numSpeed.Value, 0));
            System.Threading.Thread.Sleep(100);

            //опустим щуп
            _ctrl.SendBinaryData(BinaryData.pack_C0(0x01)); //вкл
            _ctrl.SendBinaryData(BinaryData.pack_D2((int)numSpeed.Value, 0));      // + настройка отхода, и скорости
            _ctrl.SendBinaryData(BinaryData.pack_C0(0x00)); //выкл
            System.Threading.Thread.Sleep(100);

            while (!deviceInfo.AxesZ_LimitMax)
            {
                //dataCode.Matrix[indexScanY].X[indexScanX].Z = deviceInfo.AxesZ_PositionMM - numReturn.Value;
                System.Threading.Thread.Sleep(100);
            }

            
            System.Threading.Thread.Sleep(300);
            dataCode.Matrix[indexScanY].X[indexScanX].Z = deviceInfo.AxesZ_PositionMM;


            _ctrl.SendBinaryData(BinaryData.pack_C0(0x01)); //вкл
            _ctrl.SendBinaryData(BinaryData.pack_D2((int)numSpeed.Value, (decimal)numReturn.Value));      // + настройка отхода, и скорости
            _ctrl.SendBinaryData(BinaryData.pack_C0(0x00)); //выкл
            System.Threading.Thread.Sleep(100);
            //спозиционируемся
            _ctrl.SendBinaryData(BinaryData.pack_CA(deviceInfo.CalcPosPulse("X", px), deviceInfo.CalcPosPulse("Y", py), deviceInfo.CalcPosPulse("Z", pz), (int)numSpeed.Value, 0));
            System.Threading.Thread.Sleep(100);

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
  
    
    }
}

