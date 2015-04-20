namespace CNC_Controller
{
    partial class ScanSurface
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
            this.numPosY = new System.Windows.Forms.NumericUpDown();
            this.numPosX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numPosZ = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numStepX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numCountX = new System.Windows.Forms.NumericUpDown();
            this.numCountY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.timerTASK = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numReturn = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numSpeed = new System.Windows.Forms.NumericUpDown();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.numStepY = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStepX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStepY)).BeginInit();
            this.SuspendLayout();
            // 
            // numPosY
            // 
            this.numPosY.DecimalPlaces = 3;
            this.numPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosY.Location = new System.Drawing.Point(38, 53);
            this.numPosY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPosY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numPosY.Name = "numPosY";
            this.numPosY.Size = new System.Drawing.Size(120, 29);
            this.numPosY.TabIndex = 8;
            this.numPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPosY.ValueChanged += new System.EventHandler(this.numPosY_ValueChanged);
            // 
            // numPosX
            // 
            this.numPosX.DecimalPlaces = 3;
            this.numPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosX.Location = new System.Drawing.Point(38, 19);
            this.numPosX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPosX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numPosX.Name = "numPosX";
            this.numPosX.Size = new System.Drawing.Size(120, 29);
            this.numPosX.TabIndex = 7;
            this.numPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPosX.ValueChanged += new System.EventHandler(this.numPosX_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "X";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numPosZ);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numPosX);
            this.groupBox1.Controls.Add(this.numPosY);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 145);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1) Начальная точка";
            // 
            // numPosZ
            // 
            this.numPosZ.DecimalPlaces = 3;
            this.numPosZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosZ.Location = new System.Drawing.Point(38, 101);
            this.numPosZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPosZ.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numPosZ.Name = "numPosZ";
            this.numPosZ.Size = new System.Drawing.Size(120, 29);
            this.numPosZ.TabIndex = 10;
            this.numPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPosZ.ValueChanged += new System.EventHandler(this.numPosZ_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(11, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Z";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numStepY);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.numStepX);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numCountX);
            this.groupBox2.Controls.Add(this.numCountY);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 160);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2) Размер и количество шагов";
            // 
            // numStepX
            // 
            this.numStepX.DecimalPlaces = 1;
            this.numStepX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numStepX.Location = new System.Drawing.Point(79, 25);
            this.numStepX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStepX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numStepX.Name = "numStepX";
            this.numStepX.Size = new System.Drawing.Size(79, 29);
            this.numStepX.TabIndex = 14;
            this.numStepX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStepX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numStepX.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(11, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "ШАГ X:";
            // 
            // numCountX
            // 
            this.numCountX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numCountX.Location = new System.Drawing.Point(38, 94);
            this.numCountX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCountX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numCountX.Name = "numCountX";
            this.numCountX.Size = new System.Drawing.Size(120, 29);
            this.numCountX.TabIndex = 11;
            this.numCountX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCountX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCountX.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numCountY
            // 
            this.numCountY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numCountY.Location = new System.Drawing.Point(38, 128);
            this.numCountY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCountY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numCountY.Name = "numCountY";
            this.numCountY.Size = new System.Drawing.Size(120, 29);
            this.numCountY.TabIndex = 12;
            this.numCountY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCountY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCountY.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(11, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Y";
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
            this.dataGridView.Location = new System.Drawing.Point(211, 22);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.ShowCellToolTips = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.ShowRowErrors = false;
            this.dataGridView.Size = new System.Drawing.Size(384, 476);
            this.dataGridView.TabIndex = 11;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            // 
            // timerTASK
            // 
            this.timerTASK.Enabled = true;
            this.timerTASK.Interval = 10;
            this.timerTASK.Tick += new System.EventHandler(this.timerTASK_Tick_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Сканировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(25, 482);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(159, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "только просмотр таблицы";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numReturn);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.numSpeed);
            this.groupBox3.Location = new System.Drawing.Point(12, 329);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 108);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 22);
            this.button2.TabIndex = 14;
            this.button2.Text = "тест";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Возврат мм.";
            // 
            // numReturn
            // 
            this.numReturn.Location = new System.Drawing.Point(90, 43);
            this.numReturn.Name = "numReturn";
            this.numReturn.Size = new System.Drawing.Size(69, 20);
            this.numReturn.TabIndex = 16;
            this.numReturn.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Скорость";
            // 
            // numSpeed
            // 
            this.numSpeed.Location = new System.Drawing.Point(90, 18);
            this.numSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(68, 20);
            this.numSpeed.TabIndex = 14;
            this.numSpeed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // numStepY
            // 
            this.numStepY.DecimalPlaces = 1;
            this.numStepY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numStepY.Location = new System.Drawing.Point(80, 57);
            this.numStepY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStepY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numStepY.Name = "numStepY";
            this.numStepY.Size = new System.Drawing.Size(79, 29);
            this.numStepY.TabIndex = 16;
            this.numStepY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStepY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numStepY.ValueChanged += new System.EventHandler(this.numStepY_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(12, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "ШАГ Y:";
            // 
            // ScanSurface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 510);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "ScanSurface";
            this.Text = "Сканирование поверхности";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.feeler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStepX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStepY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numPosY;
        private System.Windows.Forms.NumericUpDown numPosX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numStepX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numCountX;
        private System.Windows.Forms.NumericUpDown numCountY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Timer timerTASK;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numReturn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numSpeed;
        private System.Windows.Forms.NumericUpDown numPosZ;
        private System.Windows.Forms.Label label8;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.NumericUpDown numStepY;
        private System.Windows.Forms.Label label9;
    }
}