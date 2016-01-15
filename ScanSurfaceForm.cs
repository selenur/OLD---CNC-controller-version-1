using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CNC_Assist
{
    public partial class ScanSurfaceForm : Form
    {

        #region Compleated

        /// <summary>
        /// Поток сканирования устанавливает флаг, когда появились новые данные
        /// Для таймера который по этому флагу обновляет данные на форме
        /// </summary>
        private bool _refreshDataFromMatrix;

        /// <summary>
        /// Статус необходимости сканирования поверхности, при установке в false, поток самозавершиться, при первом удобном случае
        /// Изменяется кнопкой "Сканировать"
        /// </summary>
        private bool _ScanningNow;

        /// <summary>
        /// Статус работы потока сканирования, поток сам меняет данный статус
        /// </summary>
        private bool _ThreadDoWorks;


        public ScanSurfaceForm()
        {
            InitializeComponent();

            _ScanningNow = false;
            _ThreadDoWorks = false;
            _refreshDataFromMatrix = false;
        }

        private void feeler_Load(object sender, EventArgs e)
        {
            if (ScanSurface.NotInit)
            {
                //MessageBox.Show("Матрица не содана! поэтому пока нет данных для отображения");
                labelNotInit.Visible = true;
            }
            else
            {
                labelNotInit.Visible = false;
                //Обновим данные на форме
                numStartPosX.Value = (decimal)ScanSurface.PrimaryPosition.PosX;
                numStartPosY.Value = (decimal)ScanSurface.PrimaryPosition.PosY;
                numZforStart.Value = (decimal)ScanSurface.PrimaryPosition.PosZ;

                numCountPointX.Value = (decimal)ScanSurface.CountPointX;
                numCountPointY.Value = (decimal)ScanSurface.CountPointY;

                numStepX.Value = (decimal)ScanSurface.StepX;
                numStepY.Value = (decimal)ScanSurface.StepY;
                numSpeedMove.Value = (decimal)ScanSurface.SpeedMove;
                numSpeedScan.Value = (decimal)ScanSurface.SpeedScan;

                RefrechDataGrid();
            }
        }





        private void btSetStartPosition_Click(object sender, EventArgs e)
        {
            ////1) нужно опуститься до поверхности и зафиксировать точку касания

            //Controller.SendBinaryData(BinaryData.pack_C0(0x01)); //вкл
            //Controller.SendBinaryData(BinaryData.pack_D2((int)numSpeedScan.Value, 0));      // + настройка отхода, и скорости
            //Controller.SendBinaryData(BinaryData.pack_C0(0x00)); //выкл

            //Thread.Sleep(500); //задержка небольшая, что-бы станок успел разогнаться
            //while (Controller.INFO.shpindel_MoveSpeed != 0)
            //{
            //    Thread.Sleep(100);
            //}

            //фиксируем точку
            numStartPosX.Value = Controller.INFO.AxesX_PositionMM;
            numStartPosY.Value = Controller.INFO.AxesY_PositionMM;
            numZforStart.Value = Controller.INFO.AxesZ_PositionMM;

            //// 2) поднимаемся обратно
            //Controller.SendBinaryData(BinaryData.pack_C0(0x01)); //вкл
            //Controller.SendBinaryData(BinaryData.pack_D2((int)numSpeedScan.Value, numReturn.Value));      // + настройка отхода, и скорости
            //Controller.SendBinaryData(BinaryData.pack_C0(0x00)); //выкл
        }



        private void buttonTest_Click(object sender, EventArgs e)
        {
            if (_ScanningNow) return; //небудем вклиниваться если что....

            Controller.SendBinaryData(BinaryData.pack_C0(0x01)); //вкл
            Controller.SendBinaryData(BinaryData.pack_D2((int)numSpeedScan.Value, numReturn.Value));      // + настройка отхода, и скорости
            Controller.SendBinaryData(BinaryData.pack_C0(0x00)); //выкл
        }

        /// <summary>
        /// Перезаполнение визуальной таблицы
        /// </summary>
        /// <param name="RefreshOnlyData">Если не указать параметр, или указать false, то в начале будут пересозданы
        /// Колонки и столбцы, а потом заполнено данными.
        /// Если параметр будет истина - то будет перезаполнена таблица с данными</param>
        private void RefrechDataGrid(bool RefreshOnlyData = false)
        {
            if (!RefreshOnlyData)
            {
                //и перезаполним таблицу
                dataGridView.Columns.Clear();
                dataGridView.Rows.Clear();

                // в начале создадим незаполненную таблицу
                dataGridView.Columns.Add("nameY", "---");
                dataGridView.Rows.Add();
            
                // нарисуем колонки и строки
                for (int x = 0; x < numCountPointX.Value; x++)
                {
                    dataGridView.Columns.Add("X" + x.ToString(), "");
                    dataGridView.Rows[0].Cells[x + 1].Value = "X " + (numStartPosX.Value + (x * numStepX.Value));
                }

                for (int y = 0; y < numCountPointY.Value; y++)
                {
                    int index = dataGridView.Rows.Add();
                    dataGridView.Rows[index].Cells[0].Value = "Y " + (numStartPosY.Value + (y * numStepY.Value));
                }                
            }

            // заполним данными
            for (int y = 0; y < numCountPointY.Value; y++)
            {
                for (int x = 0; x < numCountPointX.Value; x++)
                {
                    dataGridView.Rows[y + 1].Cells[x + 1].Value = ScanSurface.Matrix[x, y].PosZ;
                }
            }

        }

        private void checkBoxEditGrid_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView.ReadOnly = checkBoxEditGrid.Checked;
        }




        #endregion



        #region Not Compleated









        


        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            //RefreshElements();

           if (_refreshDataFromMatrix)
            {
               _refreshDataFromMatrix = false;
               RefrechDataGrid(true);
           }

           //if (_scan)
           //{
           //    button1.Text = @"Остановить";
           //}
           //else
           //{
           //    button1.Text = @"Сканировать";
           //}

            //try
            //{
            //   // dataGridView.Rows[indexScanY + 1].Cells[indexScanX + 1].Value = dataCode.Matrix[indexScanY].X[indexScanX].Z;
            //    dataGridView.Rows[_indexScanY + 1].Cells[_indexScanX + 1].Value = dataCode.matrix2[_indexScanX, _indexScanY].Z;
            //}
            //catch (Exception)
            //{
                
            //   // throw;
            //}
            
        }



        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int x = e.ColumnIndex-1;
            //int y = e.RowIndex-1;

            //if (x < 0 || y < 0)
            //{
            //    selectedPoint = null;

            //    _selectedX = -1;
            //    _selectedY = -1;
            //}
            //else
            //{
            //    selectedPoint = new dobPoint(dataCode.matrix2[x, y].X, dataCode.matrix2[x, y].Y, dataCode.matrix2[x, y].Z,0);
            //    _selectedX = x;
            //    _selectedY = y;
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {


            //if (!Controller.TestAllowActions()) return;

            //if (selectedPoint == null) return;

            //int speed = 200;

            //Controller.SendBinaryData(BinaryData.pack_9E(0x05));
            //Controller.SendBinaryData(BinaryData.pack_BF(speed, speed, speed,0));
            //Controller.SendBinaryData(BinaryData.pack_C0());
            ////Controller.SendBinaryData(BinaryData.pack_CA(Controller.INFO.CalcPosPulse("X", (decimal)selectedPoint.X), Controller.INFO.CalcPosPulse("Y", (decimal)selectedPoint.Y), Controller.INFO.CalcPosPulse("Z", (decimal)selectedPoint.Z), 0, speed, 0, 0, 0));
            //Controller.SendBinaryData(BinaryData.pack_FF());
            //Controller.SendBinaryData(BinaryData.pack_9D());
            //Controller.SendBinaryData(BinaryData.pack_9E(0x02));
            //Controller.SendBinaryData(BinaryData.pack_FF());
            //Controller.SendBinaryData(BinaryData.pack_FF());
            //Controller.SendBinaryData(BinaryData.pack_FF());
            //Controller.SendBinaryData(BinaryData.pack_FF());
            //Controller.SendBinaryData(BinaryData.pack_FF());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 
            
            ////узнаем координаты из таблицы, куда все поместить

            //if (_selectedX == -1 || _selectedY == -1) return;

            //dataCode.matrix2[_selectedX, _selectedY].Z = (double)Controller.INFO.AxesZ_PositionMM;
            //dataGridView.Rows[_selectedY + 1].Cells[_selectedX + 1].Value = dataCode.matrix2[_selectedX, _selectedY].Z;

        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            button6.BackColor = Color.DarkGreen;
            Controller.StartManualMove("0", "0", "+", 100);       
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            button6.BackColor = Color.FromName("Control");
            Controller.StopManualMove();        
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            button5.BackColor = Color.DarkGreen;
            Controller.StartManualMove("0", "0", "-", 100);
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            button5.BackColor = Color.FromName("Control");
            Controller.StopManualMove();
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           // if (_formIsLoading) return;

            int x = e.ColumnIndex;
            int y = e.RowIndex;

            if (x == 0 || y == 0) return;

            string ss = dataGridView.Rows[y].Cells[x].Value.ToString();
            decimal val = decimal.Parse(ss.Replace(".", ","));

            try
            {
               ScanSurface.Matrix[x-1, y-1].PosZ = (float) val;
            }
            catch (Exception)
            {
            //    //throw;
            }
        }


        #endregion








        private void RefreshElements()
        {
            if (_ThreadDoWorks)
            {
                buttonScan.Text = @"Остановка";



            }
            else
            {
                buttonScan.Text = @"Запуск";
            }

            //TODO: debug
            //if (Controller.Connected)
            //{

            //    groupBox1.Enabled = !_ScanningNow;
            //    groupBox2.Enabled = !_ScanningNow;
            //    groupBox3.Enabled = !_ScanningNow;
            //}
            //else
            //{
            //    groupBox1.Enabled = false;
            //    groupBox2.Enabled = false;
            //    groupBox3.Enabled = false;
            //}
        }
        
        private void buttonScan_Click(object sender, EventArgs e)
        {
            if (_ThreadDoWorks) //если поток запущен то установим флаг о необходимости остановки потока
            {
                _ScanningNow = false;
            }
            else
            {
                if (Controller.Connected)
                {
                    Thread ScanThread = new Thread(DoWork);
                    ScanThread.Start("");
                }
            }
        }


        private void WaitStop()
        {
            Thread.Sleep(500);
            while (Controller.INFO.shpindel_MoveSpeed != 0)
            {
                Thread.Sleep(100);
            }
        }

        // поток выполняющий сканирование
        private void DoWork(object data)
        {
            _ThreadDoWorks = true;
            _ScanningNow = true;

            //текущие координаты сканирования
            int _indexScanX = 0; 
            int _indexScanY = 0;

            while (_ScanningNow && _ThreadDoWorks)  //цикл работает пока не прийдет команда внеплановой остановки, или не бутет выполнено всё сканирование
            {
                // 1) получаем координаты
                SurfacePoint mp = ScanSurface.Matrix[_indexScanX, _indexScanY];

                //Дальше не двигаемся, т.к. контроллер занят какой-то другой задачей
                if (Controller.Locked) continue;

                // подходим к точке сканирования
                Controller.Locked = true;
                Controller.ExecuteCommand(@"G0 F" + numSpeedMove.Value + 
                    " X" + mp.PosX.ToString("###0,###") + 
                    " Y" + mp.PosY.ToString("###0,###") +
                    " Z" + numZforStart.Value.ToString("###0,###"));
                Controller.Locked = false;

                // ждем завершения движения
                //WaitStop();

                Thread.Sleep(500); //задержка небольшая, что-бы станок успел разогнаться
                while (Controller.INFO.shpindel_MoveSpeed != 0)
                {
                    Thread.Sleep(100);
                }

                //запускаем сканирование, с остановкой при касании
                Controller.SendBinaryData(BinaryData.pack_C0(0x01)); //вкл
                Controller.SendBinaryData(BinaryData.pack_D2((int)numSpeedScan.Value, 0));      // + настройка отхода, и скорости
                Controller.SendBinaryData(BinaryData.pack_C0(0x00)); //выкл

                //WaitStop(); //ждем остановки

                Thread.Sleep(1000); //задержка небольшая, что-бы станок успел разогнаться
                while (Controller.INFO.shpindel_MoveSpeed != 0)
                {
                    Thread.Sleep(100);
                }

                //фиксируем точку
                mp.PosZ = (float)Controller.INFO.AxesZ_PositionMM;

                // установим флаг что можно обновлять таблицу на форме
                _refreshDataFromMatrix = true;

                // 2) поднимаемся обратно
                Controller.SendBinaryData(BinaryData.pack_C0(0x01)); //вкл
                Controller.SendBinaryData(BinaryData.pack_D2((int)numSpeedScan.Value, numReturn.Value));      // + настройка отхода, и скорости
                Controller.SendBinaryData(BinaryData.pack_C0(0x00)); //выкл

                WaitStop(); //ждем остановки

                // 2) перемещаемся к новой точке
                if (_indexScanX == ScanSurface.CountPointX - 1)
                {
                    // 3) проверяем что не дошли до конца массива
                    if (_indexScanY == ScanSurface.CountPointY - 1)
                    {
                        _ThreadDoWorks = false;
                    }
                    else
                    {
                        _indexScanX = 0;
                        _indexScanY++;                        
                    }
                }
                else _indexScanX++;



            }
            // Поток завершен
            _ThreadDoWorks = false;
            _ScanningNow = false;
        }

        private void buttonInitMatrix_Click(object sender, EventArgs e)
        {
            // создадим матрицу
            ScanSurface.Init(new SurfacePoint((float)numStartPosX.Value, (float)numStartPosY.Value, (float)numZforStart.Value), (int)numCountPointX.Value, (int)numCountPointY.Value, (float)numStepX.Value, (float)numStepY.Value);

            labelNotInit.Visible = false;

            //и отобразим её
            RefrechDataGrid();

        }

        private void buttonSTOP_Click(object sender, EventArgs e)
        {
            Controller.EnergyStop(); //Аварийная остановка
        }

        private void buttonToTouch_Click(object sender, EventArgs e)
        {
            if (_ScanningNow) return; //небудем вклиниваться если что....

            Controller.SendBinaryData(BinaryData.pack_C0(0x01)); //вкл
            Controller.SendBinaryData(BinaryData.pack_D2((int)numSpeedScan.Value, 0));      // + настройка отхода, и скорости
            Controller.SendBinaryData(BinaryData.pack_C0(0x00)); //выкл
        }

    }
}






//// Поток выполняющий сканирование
//// TODO: при сканировании иногда заполняет сразу 2 ячейки в таблице?!?
//private void Theads()
//{
//    //if (Controller.INFO.shpindel_MoveSpeed != 0) return;

//    ////координаты куда передвинуться
//    ////decimal px = dataCode.Matrix[indexScanY].X[indexScanX].X;
//    //decimal px = (decimal)MatrixArray.matrix2[_indexScanX, _indexScanY].X;
//    ////decimal pz = dataCode.Matrix[indexScanY].X[indexScanX].Z;
//    //decimal pz = numStartPosZ.Value;
//    ////decimal py = dataCode.Matrix[indexScanY].Y;
//    //decimal py = (decimal)MatrixArray.matrix2[_indexScanX, _indexScanY].Y;

//    ////спозиционируемся
//    ////Controller.SendBinaryData(BinaryData.pack_CA(Controller.INFO.CalcPosPulse("X", px), Controller.INFO.CalcPosPulse("Y", py), Controller.INFO.CalcPosPulse("Z", pz), 0, (int)numSpeed.Value, 0, 0, 0));
//    //Thread.Sleep(100);

//    ////опустим щуп
//    //Controller.SendBinaryData(BinaryData.pack_C0(0x01)); //вкл
//    //Controller.SendBinaryData(BinaryData.pack_D2((int)numSpeed.Value, 0));      // + настройка отхода, и скорости
//    //Controller.SendBinaryData(BinaryData.pack_C0(0x00)); //выкл
//    //Thread.Sleep(100);

//    //while (!Controller.INFO.AxesZ_LimitMax)
//    //{
//    //    //dataCode.Matrix[indexScanY].X[indexScanX].Z = deviceInfo.AxesZ_PositionMM - numReturn.Value;
//    //    Thread.Sleep(100);
//    //}


//    //Thread.Sleep(300);
//    ////dataCode.Matrix[indexScanY].X[indexScanX].Z = deviceInfo.AxesZ_PositionMM;
//    //MatrixArray.matrix2[_indexScanX, _indexScanY].Z = (double)Controller.INFO.AxesZ_PositionMM;

//    //Controller.SendBinaryData(BinaryData.pack_C0(0x01)); //вкл
//    //Controller.SendBinaryData(BinaryData.pack_D2((int)numSpeed.Value, numReturn.Value));      // + настройка отхода, и скорости
//    //Controller.SendBinaryData(BinaryData.pack_C0(0x00)); //выкл
//    //Thread.Sleep(100);
//    ////спозиционируемся
//    ////Controller.SendBinaryData(BinaryData.pack_CA(Controller.INFO.CalcPosPulse("X", px), Controller.INFO.CalcPosPulse("Y", py), Controller.INFO.CalcPosPulse("Z", pz), 0, (int)numSpeed.Value, 0, 0, 0));
//    //Thread.Sleep(100);

//    //if (_indexScanX == _indexMaxScanX && _indexScanY == _indexMaxScanY)
//    //{
//    //    _scan = false;
//    //    Controller.SendBinaryData(BinaryData.pack_FF());
//    //}

//    //if (_indexScanX < _indexMaxScanX)
//    //{
//    //    _indexScanX++;
//    //}
//    //else
//    //{
//    //    _indexScanX = 0;

//    //    if (_indexScanY < _indexMaxScanY)
//    //    {
//    //        _indexScanY++;
//    //    }
//    //    else
//    //    {
//    //        _indexScanY = 0;
//    //    }
//    //}
//}



//private void timer1_Tick(object sender, EventArgs e)
//{
//    //if (selectedPoint == null)
//    //{
//    //    label10.Text = @"X: 000.000  Y: 000.000";
//    //    return;
//    //}

//    //label10.Text = @"X: " + selectedPoint.X + @"  Y: " + selectedPoint.Y;
//}

//наполним массив
//dataCode.Matrix.Clear();

//MatrixArray.matrix2 = new dobPoint[(int)numCountX.Value, (int)numCountY.Value];

//for (int y = 0; y < numCountY.Value; y++)
//{
//    //matrixYline matrixline = new matrixYline();

//    //matrixline.Y = numPosY.Value + (y* numStep.Value);

//    for (int x = 0; x < numCountX.Value; x++)
//    {
//        MatrixArray.matrix2[x, y] = new dobPoint((double)numStartPosX.Value + (x * (double)numStepX.Value), (double)numStartPosY.Value + (y * (double)numStepY.Value), (double)numStartPosZ.Value,0);

//        //matrixline.X.Add(new matrixPoint(numPosX.Value + (x * numStep.Value), numPosZ.Value, true));
//    }
//    //dataCode.Matrix.Add(matrixline);
//}




//private dobPoint selectedPoint;
//private int _selectedX;
//private int _selectedY;

//selectedPoint = null;
//_selectedX = -1;
//_selectedY = -1;

//_scan = false;
//_indexScanX = 0;
//_indexScanY = 0;
//_indexMaxScanX = 0;
//_indexMaxScanY = 0;


/// <summary>
/// Для возможности понимать что сейчас выполняется загрузка формы
/// </summary>
// private bool _formIsLoading;