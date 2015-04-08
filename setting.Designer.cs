namespace CNC_Controller
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
            this.checkBoxDemoController = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPulseX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPulseY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPulseZ)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.numPulseX.Location = new System.Drawing.Point(39, 24);
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
            this.numPulseY.Location = new System.Drawing.Point(39, 50);
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
            this.label2.Location = new System.Drawing.Point(19, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y";
            // 
            // numPulseZ
            // 
            this.numPulseZ.Location = new System.Drawing.Point(39, 76);
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
            this.label3.Location = new System.Drawing.Point(19, 78);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 104);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Кол.импульсов на 1 мм";
            // 
            // checkBoxDemoController
            // 
            this.checkBoxDemoController.AutoSize = true;
            this.checkBoxDemoController.Location = new System.Drawing.Point(22, 136);
            this.checkBoxDemoController.Name = "checkBoxDemoController";
            this.checkBoxDemoController.Size = new System.Drawing.Size(274, 17);
            this.checkBoxDemoController.TabIndex = 10;
            this.checkBoxDemoController.Text = "Имитация устройства (виртуальный контроллер)";
            this.checkBoxDemoController.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(23, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(325, 72);
            this.label4.TabIndex = 11;
            this.label4.Text = "В режиме имитации, при наличии настоящего контроллера, использоваться будет вирту" +
    "альный контроллер!!!";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Image = global::CNC_Controller.Properties.Resources.cancelPic;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(294, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Отмена";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Image = global::CNC_Controller.Properties.Resources.accept_button;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(197, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Применить";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 308);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBoxDemoController);
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
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.CheckBox checkBoxDemoController;
        private System.Windows.Forms.Label label4;

    }
}