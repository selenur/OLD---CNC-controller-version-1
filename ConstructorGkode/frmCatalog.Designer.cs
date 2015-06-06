namespace CNC_App.primitiv
{
    partial class frmCatalog
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
            this.deltaZ = new System.Windows.Forms.NumericUpDown();
            this.labelposY = new System.Windows.Forms.Label();
            this.deltaY = new System.Windows.Forms.NumericUpDown();
            this.labelposZ = new System.Windows.Forms.Label();
            this.deltaX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btAppy = new System.Windows.Forms.Button();
            this.btGetPosition = new System.Windows.Forms.Button();
            this.deltaRotate = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.deltaZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deltaY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deltaX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deltaRotate)).BeginInit();
            this.SuspendLayout();
            // 
            // labelposX
            // 
            this.labelposX.AutoSize = true;
            this.labelposX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposX.Location = new System.Drawing.Point(8, 73);
            this.labelposX.Name = "labelposX";
            this.labelposX.Size = new System.Drawing.Size(31, 16);
            this.labelposX.TabIndex = 13;
            this.labelposX.Text = "∆ X:";
            // 
            // deltaZ
            // 
            this.deltaZ.DecimalPlaces = 3;
            this.deltaZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deltaZ.Location = new System.Drawing.Point(44, 115);
            this.deltaZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.deltaZ.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.deltaZ.Name = "deltaZ";
            this.deltaZ.Size = new System.Drawing.Size(73, 22);
            this.deltaZ.TabIndex = 18;
            this.deltaZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelposY
            // 
            this.labelposY.AutoSize = true;
            this.labelposY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposY.Location = new System.Drawing.Point(8, 96);
            this.labelposY.Name = "labelposY";
            this.labelposY.Size = new System.Drawing.Size(32, 16);
            this.labelposY.TabIndex = 14;
            this.labelposY.Text = "∆ Y:";
            // 
            // deltaY
            // 
            this.deltaY.DecimalPlaces = 3;
            this.deltaY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deltaY.Location = new System.Drawing.Point(44, 92);
            this.deltaY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.deltaY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.deltaY.Name = "deltaY";
            this.deltaY.Size = new System.Drawing.Size(73, 22);
            this.deltaY.TabIndex = 17;
            this.deltaY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelposZ
            // 
            this.labelposZ.AutoSize = true;
            this.labelposZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposZ.Location = new System.Drawing.Point(8, 118);
            this.labelposZ.Name = "labelposZ";
            this.labelposZ.Size = new System.Drawing.Size(31, 16);
            this.labelposZ.TabIndex = 15;
            this.labelposZ.Text = "∆ Z:";
            // 
            // deltaX
            // 
            this.deltaX.DecimalPlaces = 3;
            this.deltaX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deltaX.Location = new System.Drawing.Point(44, 69);
            this.deltaX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.deltaX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.deltaX.Name = "deltaX";
            this.deltaX.Size = new System.Drawing.Size(73, 22);
            this.deltaX.TabIndex = 16;
            this.deltaX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 38);
            this.label1.TabIndex = 20;
            this.label1.Text = "Корректировка данных у примитивов внутри данной группы";
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
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(93, 6);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(164, 22);
            this.textBoxName.TabIndex = 22;
            this.textBoxName.Text = "Группа";
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::CNC_App.Properties.Resources.cancel2;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(157, 250);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(105, 57);
            this.btCancel.TabIndex = 24;
            this.btCancel.Text = "Отмена";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btAppy
            // 
            this.btAppy.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAppy.Image = global::CNC_App.Properties.Resources.accept_button2;
            this.btAppy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAppy.Location = new System.Drawing.Point(8, 250);
            this.btAppy.Name = "btAppy";
            this.btAppy.Size = new System.Drawing.Size(104, 57);
            this.btAppy.TabIndex = 23;
            this.btAppy.Text = "Применить";
            this.btAppy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAppy.UseVisualStyleBackColor = true;
            this.btAppy.Click += new System.EventHandler(this.btAppy_Click);
            // 
            // btGetPosition
            // 
            this.btGetPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btGetPosition.Image = global::CNC_App.Properties.Resources.geolocation_sight;
            this.btGetPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGetPosition.Location = new System.Drawing.Point(118, 69);
            this.btGetPosition.Name = "btGetPosition";
            this.btGetPosition.Size = new System.Drawing.Size(144, 68);
            this.btGetPosition.TabIndex = 19;
            this.btGetPosition.Text = "Использовать текущее положение";
            this.btGetPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGetPosition.UseVisualStyleBackColor = true;
            this.btGetPosition.Click += new System.EventHandler(this.btGetPosition_Click);
            // 
            // deltaRotate
            // 
            this.deltaRotate.DecimalPlaces = 3;
            this.deltaRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deltaRotate.Location = new System.Drawing.Point(189, 155);
            this.deltaRotate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.deltaRotate.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.deltaRotate.Name = "deltaRotate";
            this.deltaRotate.Size = new System.Drawing.Size(73, 22);
            this.deltaRotate.TabIndex = 25;
            this.deltaRotate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 45);
            this.label3.TabIndex = 26;
            this.label3.Text = "Угол поворота, всех элементов относительно точки 0,0,0 в плоскости XY";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label4.Location = new System.Drawing.Point(15, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 47);
            this.label4.TabIndex = 27;
            this.label4.Text = "При положительном угле данные поворачиваются против часовой стрелки, при отрицате" +
    "льном угле по часовой стрелке";
            // 
            // frmCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 314);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deltaRotate);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAppy);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btGetPosition);
            this.Controls.Add(this.labelposX);
            this.Controls.Add(this.deltaZ);
            this.Controls.Add(this.labelposY);
            this.Controls.Add(this.deltaY);
            this.Controls.Add(this.labelposZ);
            this.Controls.Add(this.deltaX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCatalog";
            this.Text = "Группа элементов";
            this.Load += new System.EventHandler(this.frmCatalog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deltaZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deltaY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deltaX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deltaRotate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btGetPosition;
        private System.Windows.Forms.Label labelposX;
        private System.Windows.Forms.Label labelposY;
        private System.Windows.Forms.Label labelposZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btAppy;
        private System.Windows.Forms.Button btCancel;
        public System.Windows.Forms.NumericUpDown deltaZ;
        public System.Windows.Forms.NumericUpDown deltaY;
        public System.Windows.Forms.NumericUpDown deltaX;
        public System.Windows.Forms.TextBox textBoxName;
        public System.Windows.Forms.NumericUpDown deltaRotate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}