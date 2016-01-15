namespace CNC_Assist
{
    partial class ScanSurfaceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.numStartPosY = new System.Windows.Forms.NumericUpDown();
            this.numStartPosX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btSetStartPosition = new System.Windows.Forms.Button();
            this.numZforStart = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonInitMatrix = new System.Windows.Forms.Button();
            this.numStepY = new System.Windows.Forms.NumericUpDown();
            this.numStepX = new System.Windows.Forms.NumericUpDown();
            this.numCountPointX = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numCountPointY = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numSpeedScan = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numReturn = new System.Windows.Forms.NumericUpDown();
            this.numSpeedMove = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.buttonScan = new System.Windows.Forms.Button();
            this.checkBoxEditGrid = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonToTouch = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonSTOP = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.labelNotInit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numStartPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartPosX)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZforStart)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStepY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStepX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountPointX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountPointY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeedScan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeedMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // numStartPosY
            // 
            this.numStartPosY.DecimalPlaces = 3;
            this.numStartPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numStartPosY.Location = new System.Drawing.Point(33, 55);
            this.numStartPosY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStartPosY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numStartPosY.Name = "numStartPosY";
            this.numStartPosY.Size = new System.Drawing.Size(105, 29);
            this.numStartPosY.TabIndex = 8;
            this.numStartPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numStartPosX
            // 
            this.numStartPosX.DecimalPlaces = 3;
            this.numStartPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numStartPosX.Location = new System.Drawing.Point(33, 20);
            this.numStartPosX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStartPosX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numStartPosX.Name = "numStartPosX";
            this.numStartPosX.Size = new System.Drawing.Size(105, 29);
            this.numStartPosX.TabIndex = 7;
            this.numStartPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "X";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btSetStartPosition);
            this.groupBox1.Controls.Add(this.numZforStart);
            this.groupBox1.Controls.Add(this.numStartPosX);
            this.groupBox1.Controls.Add(this.numStartPosY);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 208);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1) Базовая точка";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Высота Z подхода к точке";
            // 
            // btSetStartPosition
            // 
            this.btSetStartPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSetStartPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSetStartPosition.Location = new System.Drawing.Point(6, 90);
            this.btSetStartPosition.Name = "btSetStartPosition";
            this.btSetStartPosition.Size = new System.Drawing.Size(138, 38);
            this.btSetStartPosition.TabIndex = 32;
            this.btSetStartPosition.Text = "Установить текущие координаты";
            this.btSetStartPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSetStartPosition.UseVisualStyleBackColor = true;
            this.btSetStartPosition.Click += new System.EventHandler(this.btSetStartPosition_Click);
            // 
            // numZforStart
            // 
            this.numZforStart.DecimalPlaces = 3;
            this.numZforStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numZforStart.Location = new System.Drawing.Point(33, 162);
            this.numZforStart.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numZforStart.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numZforStart.Name = "numZforStart";
            this.numZforStart.Size = new System.Drawing.Size(105, 29);
            this.numZforStart.TabIndex = 12;
            this.numZforStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonInitMatrix);
            this.groupBox2.Controls.Add(this.numStepY);
            this.groupBox2.Controls.Add(this.numStepX);
            this.groupBox2.Controls.Add(this.numCountPointX);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.numCountPointY);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(166, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 119);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2) Параметры сетки сканирования";
            // 
            // buttonInitMatrix
            // 
            this.buttonInitMatrix.Location = new System.Drawing.Point(9, 74);
            this.buttonInitMatrix.Name = "buttonInitMatrix";
            this.buttonInitMatrix.Size = new System.Drawing.Size(303, 39);
            this.buttonInitMatrix.TabIndex = 17;
            this.buttonInitMatrix.Text = "Инициализация матрицы";
            this.buttonInitMatrix.UseVisualStyleBackColor = true;
            this.buttonInitMatrix.Click += new System.EventHandler(this.buttonInitMatrix_Click);
            // 
            // numStepY
            // 
            this.numStepY.DecimalPlaces = 1;
            this.numStepY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numStepY.Location = new System.Drawing.Point(233, 45);
            this.numStepY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStepY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numStepY.Name = "numStepY";
            this.numStepY.Size = new System.Drawing.Size(79, 20);
            this.numStepY.TabIndex = 16;
            this.numStepY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStepY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numStepX
            // 
            this.numStepX.DecimalPlaces = 1;
            this.numStepX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numStepX.Location = new System.Drawing.Point(233, 20);
            this.numStepX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStepX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numStepX.Name = "numStepX";
            this.numStepX.Size = new System.Drawing.Size(79, 20);
            this.numStepX.TabIndex = 14;
            this.numStepX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStepX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numCountPointX
            // 
            this.numCountPointX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numCountPointX.Location = new System.Drawing.Point(100, 20);
            this.numCountPointX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCountPointX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCountPointX.Name = "numCountPointX";
            this.numCountPointX.Size = new System.Drawing.Size(79, 20);
            this.numCountPointX.TabIndex = 11;
            this.numCountPointX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCountPointX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(185, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "ШАГ Y:";
            // 
            // numCountPointY
            // 
            this.numCountPointY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numCountPointY.Location = new System.Drawing.Point(100, 45);
            this.numCountPointY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCountPointY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCountPointY.Name = "numCountPointY";
            this.numCountPointY.Size = new System.Drawing.Size(79, 20);
            this.numCountPointY.TabIndex = 12;
            this.numCountPointY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCountPointY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(185, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "ШАГ X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Кол. точек по X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Кол. точек по Y:";
            // 
            // numSpeedScan
            // 
            this.numSpeedScan.Location = new System.Drawing.Point(233, 36);
            this.numSpeedScan.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSpeedScan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpeedScan.Name = "numSpeedScan";
            this.numSpeedScan.Size = new System.Drawing.Size(63, 20);
            this.numSpeedScan.TabIndex = 20;
            this.numSpeedScan.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "После касания подняться по Z на мм.";
            // 
            // numReturn
            // 
            this.numReturn.Location = new System.Drawing.Point(233, 58);
            this.numReturn.Name = "numReturn";
            this.numReturn.Size = new System.Drawing.Size(64, 20);
            this.numReturn.TabIndex = 16;
            this.numReturn.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numSpeedMove
            // 
            this.numSpeedMove.Location = new System.Drawing.Point(233, 14);
            this.numSpeedMove.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSpeedMove.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpeedMove.Name = "numSpeedMove";
            this.numSpeedMove.Size = new System.Drawing.Size(63, 20);
            this.numSpeedMove.TabIndex = 19;
            this.numSpeedMove.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(207, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Скорость снижения при сканировании:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(217, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Скорость подхода к точке сканирования:";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.Location = new System.Drawing.Point(5, 226);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.ShowCellToolTips = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.ShowRowErrors = false;
            this.dataGridView.Size = new System.Drawing.Size(808, 292);
            this.dataGridView.TabIndex = 11;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 50;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(6, 16);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(116, 64);
            this.buttonScan.TabIndex = 0;
            this.buttonScan.Text = "Сканировать";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // checkBoxEditGrid
            // 
            this.checkBoxEditGrid.Checked = true;
            this.checkBoxEditGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEditGrid.Location = new System.Drawing.Point(215, 47);
            this.checkBoxEditGrid.Name = "checkBoxEditGrid";
            this.checkBoxEditGrid.Size = new System.Drawing.Size(97, 59);
            this.checkBoxEditGrid.TabIndex = 12;
            this.checkBoxEditGrid.Text = "только просмотр таблицы";
            this.checkBoxEditGrid.UseVisualStyleBackColor = true;
            this.checkBoxEditGrid.CheckedChanged += new System.EventHandler(this.checkBoxEditGrid_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(144, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 26);
            this.button2.TabIndex = 14;
            this.button2.Text = "тест";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.checkBoxEditGrid);
            this.groupBox4.Controls.Add(this.buttonToTouch);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(495, 107);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(318, 113);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Работа с точкой из таблицы";
            // 
            // buttonToTouch
            // 
            this.buttonToTouch.Location = new System.Drawing.Point(6, 80);
            this.buttonToTouch.Name = "buttonToTouch";
            this.buttonToTouch.Size = new System.Drawing.Size(132, 27);
            this.buttonToTouch.TabIndex = 33;
            this.buttonToTouch.Text = "Опускание на косание";
            this.buttonToTouch.UseVisualStyleBackColor = true;
            this.buttonToTouch.Click += new System.EventHandler(this.buttonToTouch_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(255, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(34, 24);
            this.button5.TabIndex = 16;
            this.button5.Text = "Z-";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button5_MouseDown);
            this.button5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button5_MouseUp);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(132, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(77, 60);
            this.button4.TabIndex = 2;
            this.button4.Text = "Установить Z";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(215, 17);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(34, 30);
            this.button6.TabIndex = 15;
            this.button6.Text = "Z+";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button6_MouseDown);
            this.button6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button6_MouseUp);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 38);
            this.button3.TabIndex = 1;
            this.button3.Text = "двигаться в точку";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "X: 000.000  Y: 000.000";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonSTOP);
            this.groupBox5.Controls.Add(this.buttonScan);
            this.groupBox5.Location = new System.Drawing.Point(495, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(312, 89);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "3) Сканирование";
            // 
            // buttonSTOP
            // 
            this.buttonSTOP.BackColor = System.Drawing.Color.Red;
            this.buttonSTOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSTOP.ForeColor = System.Drawing.Color.White;
            this.buttonSTOP.Location = new System.Drawing.Point(128, 16);
            this.buttonSTOP.Name = "buttonSTOP";
            this.buttonSTOP.Size = new System.Drawing.Size(178, 64);
            this.buttonSTOP.TabIndex = 1;
            this.buttonSTOP.Text = "СТОП";
            this.buttonSTOP.UseVisualStyleBackColor = false;
            this.buttonSTOP.Click += new System.EventHandler(this.buttonSTOP_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.numSpeedScan);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.numSpeedMove);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.numReturn);
            this.groupBox6.Location = new System.Drawing.Point(166, 137);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(323, 83);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Дополнительные параметры";
            // 
            // labelNotInit
            // 
            this.labelNotInit.AutoSize = true;
            this.labelNotInit.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelNotInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNotInit.ForeColor = System.Drawing.Color.Yellow;
            this.labelNotInit.Location = new System.Drawing.Point(121, 350);
            this.labelNotInit.Name = "labelNotInit";
            this.labelNotInit.Size = new System.Drawing.Size(597, 42);
            this.labelNotInit.TabIndex = 22;
            this.labelNotInit.Text = "Матрица не инициализированна!";
            // 
            // ScanSurfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 530);
            this.Controls.Add(this.labelNotInit);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ScanSurfaceForm";
            this.Text = "Сканирование поверхности";
            this.Load += new System.EventHandler(this.feeler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numStartPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartPosX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZforStart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStepY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStepX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountPointX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountPointY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeedScan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeedMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numStartPosY;
        private System.Windows.Forms.NumericUpDown numStartPosX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numStepX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numCountPointX;
        private System.Windows.Forms.NumericUpDown numCountPointY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.CheckBox checkBoxEditGrid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numReturn;
        private System.Windows.Forms.NumericUpDown numStepY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btSetStartPosition;
        private System.Windows.Forms.NumericUpDown numSpeedScan;
        private System.Windows.Forms.NumericUpDown numSpeedMove;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonInitMatrix;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown numZforStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelNotInit;
        private System.Windows.Forms.Button buttonSTOP;
        private System.Windows.Forms.Button buttonToTouch;
    }
}