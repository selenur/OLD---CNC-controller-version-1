namespace CNC_Controller
{
    partial class GeneratorCode
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
            this.buttonGenerateCode = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageBox = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numPosZ = new System.Windows.Forms.NumericUpDown();
            this.numPosY = new System.Windows.Forms.NumericUpDown();
            this.numPosX = new System.Windows.Forms.NumericUpDown();
            this.labelposZ = new System.Windows.Forms.Label();
            this.labelposY = new System.Windows.Forms.Label();
            this.labelposX = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownSizeX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownSizeY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownDelta = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPageBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelta)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGenerateCode
            // 
            this.buttonGenerateCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerateCode.Location = new System.Drawing.Point(225, 235);
            this.buttonGenerateCode.Name = "buttonGenerateCode";
            this.buttonGenerateCode.Size = new System.Drawing.Size(125, 28);
            this.buttonGenerateCode.TabIndex = 0;
            this.buttonGenerateCode.Text = "Генерация";
            this.buttonGenerateCode.UseVisualStyleBackColor = true;
            this.buttonGenerateCode.Click += new System.EventHandler(this.buttonGenerateCode_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageBox);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(346, 230);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageBox
            // 
            this.tabPageBox.Controls.Add(this.label3);
            this.tabPageBox.Controls.Add(this.numericUpDownDelta);
            this.tabPageBox.Controls.Add(this.groupBox2);
            this.tabPageBox.Controls.Add(this.groupBox1);
            this.tabPageBox.Location = new System.Drawing.Point(4, 22);
            this.tabPageBox.Name = "tabPageBox";
            this.tabPageBox.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBox.Size = new System.Drawing.Size(338, 204);
            this.tabPageBox.TabIndex = 0;
            this.tabPageBox.Text = "Прямоугольник";
            this.tabPageBox.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(269, 199);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // numPosZ
            // 
            this.numPosZ.DecimalPlaces = 3;
            this.numPosZ.Location = new System.Drawing.Point(33, 66);
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
            this.numPosZ.Size = new System.Drawing.Size(73, 20);
            this.numPosZ.TabIndex = 11;
            this.numPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numPosY
            // 
            this.numPosY.DecimalPlaces = 3;
            this.numPosY.Location = new System.Drawing.Point(33, 43);
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
            this.numPosY.Size = new System.Drawing.Size(73, 20);
            this.numPosY.TabIndex = 10;
            this.numPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numPosX
            // 
            this.numPosX.DecimalPlaces = 3;
            this.numPosX.Location = new System.Drawing.Point(33, 21);
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
            this.numPosX.Size = new System.Drawing.Size(73, 20);
            this.numPosX.TabIndex = 9;
            this.numPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelposZ
            // 
            this.labelposZ.AutoSize = true;
            this.labelposZ.Location = new System.Drawing.Point(7, 71);
            this.labelposZ.Name = "labelposZ";
            this.labelposZ.Size = new System.Drawing.Size(14, 13);
            this.labelposZ.TabIndex = 8;
            this.labelposZ.Text = "Z";
            // 
            // labelposY
            // 
            this.labelposY.AutoSize = true;
            this.labelposY.Location = new System.Drawing.Point(6, 48);
            this.labelposY.Name = "labelposY";
            this.labelposY.Size = new System.Drawing.Size(14, 13);
            this.labelposY.TabIndex = 7;
            this.labelposY.Text = "Y";
            // 
            // labelposX
            // 
            this.labelposX.AutoSize = true;
            this.labelposX.Location = new System.Drawing.Point(6, 26);
            this.labelposX.Name = "labelposX";
            this.labelposX.Size = new System.Drawing.Size(14, 13);
            this.labelposX.TabIndex = 6;
            this.labelposX.Text = "X";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.labelposX);
            this.groupBox1.Controls.Add(this.numPosZ);
            this.groupBox1.Controls.Add(this.labelposY);
            this.groupBox1.Controls.Add(this.numPosY);
            this.groupBox1.Controls.Add(this.labelposZ);
            this.groupBox1.Controls.Add(this.numPosX);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 137);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Точка старта (мм.)";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 36);
            this.button2.TabIndex = 12;
            this.button2.Text = "Получ. тек. положение";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numericUpDownSizeY);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numericUpDownSizeX);
            this.groupBox2.Location = new System.Drawing.Point(135, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 78);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Размер прямоугольника (мм.)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "по X";
            // 
            // numericUpDownSizeX
            // 
            this.numericUpDownSizeX.DecimalPlaces = 3;
            this.numericUpDownSizeX.Location = new System.Drawing.Point(62, 21);
            this.numericUpDownSizeX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSizeX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownSizeX.Name = "numericUpDownSizeX";
            this.numericUpDownSizeX.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownSizeX.TabIndex = 11;
            this.numericUpDownSizeX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "по Y";
            // 
            // numericUpDownSizeY
            // 
            this.numericUpDownSizeY.DecimalPlaces = 3;
            this.numericUpDownSizeY.Location = new System.Drawing.Point(62, 46);
            this.numericUpDownSizeY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSizeY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownSizeY.Name = "numericUpDownSizeY";
            this.numericUpDownSizeY.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownSizeY.TabIndex = 13;
            this.numericUpDownSizeY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "дельта шага";
            // 
            // numericUpDownDelta
            // 
            this.numericUpDownDelta.DecimalPlaces = 3;
            this.numericUpDownDelta.Location = new System.Drawing.Point(165, 116);
            this.numericUpDownDelta.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownDelta.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownDelta.Name = "numericUpDownDelta";
            this.numericUpDownDelta.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownDelta.TabIndex = 15;
            this.numericUpDownDelta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GeneratorCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 266);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonGenerateCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GeneratorCode";
            this.Text = "Генератор G-кода";
            this.Load += new System.EventHandler(this.GeneratorCode_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageBox.ResumeLayout(false);
            this.tabPageBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerateCode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown numPosZ;
        private System.Windows.Forms.NumericUpDown numPosY;
        private System.Windows.Forms.NumericUpDown numPosX;
        private System.Windows.Forms.Label labelposZ;
        private System.Windows.Forms.Label labelposY;
        private System.Windows.Forms.Label labelposX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownDelta;
    }
}