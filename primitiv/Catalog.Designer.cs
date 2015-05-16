namespace CNC_Controller.primitiv
{
    partial class Catalog
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
            this.labelposX = new System.Windows.Forms.Label();
            this.numPosZ = new System.Windows.Forms.NumericUpDown();
            this.labelposY = new System.Windows.Forms.Label();
            this.numPosY = new System.Windows.Forms.NumericUpDown();
            this.labelposZ = new System.Windows.Forms.Label();
            this.numPosX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).BeginInit();
            this.SuspendLayout();
            // 
            // labelposX
            // 
            this.labelposX.AutoSize = true;
            this.labelposX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposX.Location = new System.Drawing.Point(12, 92);
            this.labelposX.Name = "labelposX";
            this.labelposX.Size = new System.Drawing.Size(16, 16);
            this.labelposX.TabIndex = 13;
            this.labelposX.Text = "X";
            // 
            // numPosZ
            // 
            this.numPosZ.DecimalPlaces = 3;
            this.numPosZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosZ.Location = new System.Drawing.Point(39, 134);
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
            this.numPosZ.Size = new System.Drawing.Size(73, 22);
            this.numPosZ.TabIndex = 18;
            this.numPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelposY
            // 
            this.labelposY.AutoSize = true;
            this.labelposY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposY.Location = new System.Drawing.Point(12, 115);
            this.labelposY.Name = "labelposY";
            this.labelposY.Size = new System.Drawing.Size(17, 16);
            this.labelposY.TabIndex = 14;
            this.labelposY.Text = "Y";
            // 
            // numPosY
            // 
            this.numPosY.DecimalPlaces = 3;
            this.numPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosY.Location = new System.Drawing.Point(39, 111);
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
            this.numPosY.Size = new System.Drawing.Size(73, 22);
            this.numPosY.TabIndex = 17;
            this.numPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelposZ
            // 
            this.labelposZ.AutoSize = true;
            this.labelposZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposZ.Location = new System.Drawing.Point(13, 137);
            this.labelposZ.Name = "labelposZ";
            this.labelposZ.Size = new System.Drawing.Size(16, 16);
            this.labelposZ.TabIndex = 15;
            this.labelposZ.Text = "Z";
            // 
            // numPosX
            // 
            this.numPosX.DecimalPlaces = 3;
            this.numPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosX.Location = new System.Drawing.Point(39, 88);
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
            this.numPosX.Size = new System.Drawing.Size(73, 22);
            this.numPosX.TabIndex = 16;
            this.numPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Начальная точка, группы элементов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Имя группы:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(8, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(249, 22);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "каталог";
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Image = global::CNC_Controller.Properties.Resources.cancel2;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(118, 162);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 57);
            this.button3.TabIndex = 24;
            this.button3.Text = "Отмена";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Image = global::CNC_Controller.Properties.Resources.accept_button2;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(8, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 57);
            this.button1.TabIndex = 23;
            this.button1.Text = "Применить";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Image = global::CNC_Controller.Properties.Resources.geolocation_sight;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(118, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 68);
            this.button2.TabIndex = 19;
            this.button2.Text = "Использовать текущее положение";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Catalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 224);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelposX);
            this.Controls.Add(this.numPosZ);
            this.Controls.Add(this.labelposY);
            this.Controls.Add(this.numPosY);
            this.Controls.Add(this.labelposZ);
            this.Controls.Add(this.numPosX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Catalog";
            this.Text = "Группа элементов";
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelposX;
        private System.Windows.Forms.NumericUpDown numPosZ;
        private System.Windows.Forms.Label labelposY;
        private System.Windows.Forms.NumericUpDown numPosY;
        private System.Windows.Forms.Label labelposZ;
        private System.Windows.Forms.NumericUpDown numPosX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}