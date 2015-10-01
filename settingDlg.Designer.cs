namespace CNC_App
{
    partial class setting
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
            this.label1 = new System.Windows.Forms.Label();
            this.numPulseX = new System.Windows.Forms.NumericUpDown();
            this.numPulseY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numPulseZ = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbType_MK2 = new System.Windows.Forms.RadioButton();
            this.rbType_MK1 = new System.Windows.Forms.RadioButton();
            this.rbType_Emulator = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoConnect = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPulseX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPulseY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPulseZ)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Х";
            // 
            // numPulseX
            // 
            this.numPulseX.Location = new System.Drawing.Point(6, 42);
            this.numPulseX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPulseX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPulseX.Name = "numPulseX";
            this.numPulseX.Size = new System.Drawing.Size(77, 20);
            this.numPulseX.TabIndex = 4;
            this.numPulseX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numPulseY
            // 
            this.numPulseY.Location = new System.Drawing.Point(89, 42);
            this.numPulseY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPulseY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPulseY.Name = "numPulseY";
            this.numPulseY.Size = new System.Drawing.Size(77, 20);
            this.numPulseY.TabIndex = 6;
            this.numPulseY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y";
            // 
            // numPulseZ
            // 
            this.numPulseZ.Location = new System.Drawing.Point(172, 42);
            this.numPulseZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPulseZ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPulseZ.Name = "numPulseZ";
            this.numPulseZ.Size = new System.Drawing.Size(77, 20);
            this.numPulseZ.TabIndex = 8;
            this.numPulseZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Z";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numPulseZ);
            this.groupBox1.Controls.Add(this.numPulseX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numPulseY);
            this.groupBox1.Location = new System.Drawing.Point(7, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 77);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Кол.импульсов на 1 мм";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Image = global::CNC_App.Properties.Resources.cancelPic;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(286, 204);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Отмена";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Image = global::CNC_App.Properties.Resources.accept_button;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(189, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Применить";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbType_MK2);
            this.groupBox2.Controls.Add(this.rbType_MK1);
            this.groupBox2.Controls.Add(this.rbType_Emulator);
            this.groupBox2.Location = new System.Drawing.Point(7, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 92);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вид контроллера";
            // 
            // rbType_MK2
            // 
            this.rbType_MK2.AutoSize = true;
            this.rbType_MK2.Location = new System.Drawing.Point(18, 68);
            this.rbType_MK2.Name = "rbType_MK2";
            this.rbType_MK2.Size = new System.Drawing.Size(89, 17);
            this.rbType_MK2.TabIndex = 2;
            this.rbType_MK2.Text = "Модель MK2";
            this.rbType_MK2.UseVisualStyleBackColor = true;
            // 
            // rbType_MK1
            // 
            this.rbType_MK1.AutoSize = true;
            this.rbType_MK1.Location = new System.Drawing.Point(18, 44);
            this.rbType_MK1.Name = "rbType_MK1";
            this.rbType_MK1.Size = new System.Drawing.Size(89, 17);
            this.rbType_MK1.TabIndex = 1;
            this.rbType_MK1.Text = "Модель MK1";
            this.rbType_MK1.UseVisualStyleBackColor = true;
            // 
            // rbType_Emulator
            // 
            this.rbType_Emulator.AutoSize = true;
            this.rbType_Emulator.Checked = true;
            this.rbType_Emulator.Location = new System.Drawing.Point(18, 21);
            this.rbType_Emulator.Name = "rbType_Emulator";
            this.rbType_Emulator.Size = new System.Drawing.Size(142, 17);
            this.rbType_Emulator.TabIndex = 0;
            this.rbType_Emulator.TabStop = true;
            this.rbType_Emulator.Text = "Эмулятор контроллера";
            this.rbType_Emulator.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxAutoConnect);
            this.groupBox3.Location = new System.Drawing.Point(201, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 83);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // checkBoxAutoConnect
            // 
            this.checkBoxAutoConnect.Location = new System.Drawing.Point(6, 19);
            this.checkBoxAutoConnect.Name = "checkBoxAutoConnect";
            this.checkBoxAutoConnect.Size = new System.Drawing.Size(148, 51);
            this.checkBoxAutoConnect.TabIndex = 0;
            this.checkBoxAutoConnect.Text = "подключение к контроллеру при запуске";
            this.checkBoxAutoConnect.UseVisualStyleBackColor = true;
            // 
            // setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 246);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "setting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Настройки программы";
            this.Load += new System.EventHandler(this.setting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPulseX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPulseY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPulseZ)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPulseX;
        private System.Windows.Forms.NumericUpDown numPulseY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPulseZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbType_MK2;
        private System.Windows.Forms.RadioButton rbType_MK1;
        private System.Windows.Forms.RadioButton rbType_Emulator;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxAutoConnect;

    }
}