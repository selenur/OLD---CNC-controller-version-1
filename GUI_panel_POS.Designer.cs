namespace CNC_App
{
    partial class GUI_panel_POS
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxPositions = new System.Windows.Forms.GroupBox();
            this.buttonAtoZero = new System.Windows.Forms.Button();
            this.numPosA = new System.Windows.Forms.NumericUpDown();
            this.labelposA = new System.Windows.Forms.Label();
            this.buttonZtoZero = new System.Windows.Forms.Button();
            this.buttonYtoZero = new System.Windows.Forms.Button();
            this.buttonXtoZero = new System.Windows.Forms.Button();
            this.numPosZ = new System.Windows.Forms.NumericUpDown();
            this.numPosY = new System.Windows.Forms.NumericUpDown();
            this.numPosX = new System.Windows.Forms.NumericUpDown();
            this.labelposZ = new System.Windows.Forms.Label();
            this.labelposY = new System.Windows.Forms.Label();
            this.labelposX = new System.Windows.Forms.Label();
            this.groupBoxPositions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxPositions
            // 
            this.groupBoxPositions.Controls.Add(this.buttonAtoZero);
            this.groupBoxPositions.Controls.Add(this.numPosA);
            this.groupBoxPositions.Controls.Add(this.labelposA);
            this.groupBoxPositions.Controls.Add(this.buttonZtoZero);
            this.groupBoxPositions.Controls.Add(this.buttonYtoZero);
            this.groupBoxPositions.Controls.Add(this.buttonXtoZero);
            this.groupBoxPositions.Controls.Add(this.numPosZ);
            this.groupBoxPositions.Controls.Add(this.numPosY);
            this.groupBoxPositions.Controls.Add(this.numPosX);
            this.groupBoxPositions.Controls.Add(this.labelposZ);
            this.groupBoxPositions.Controls.Add(this.labelposY);
            this.groupBoxPositions.Controls.Add(this.labelposX);
            this.groupBoxPositions.Location = new System.Drawing.Point(3, 3);
            this.groupBoxPositions.Name = "groupBoxPositions";
            this.groupBoxPositions.Size = new System.Drawing.Size(192, 148);
            this.groupBoxPositions.TabIndex = 5;
            this.groupBoxPositions.TabStop = false;
            this.groupBoxPositions.Text = "Координаты";
            // 
            // buttonAtoZero
            // 
            this.buttonAtoZero.Image = global::CNC_App.Properties.Resources.digit_separator;
            this.buttonAtoZero.Location = new System.Drawing.Point(4, 114);
            this.buttonAtoZero.Name = "buttonAtoZero";
            this.buttonAtoZero.Size = new System.Drawing.Size(26, 28);
            this.buttonAtoZero.TabIndex = 15;
            this.buttonAtoZero.UseVisualStyleBackColor = true;
            this.buttonAtoZero.Click += new System.EventHandler(this.buttonAtoZero_Click);
            // 
            // numPosA
            // 
            this.numPosA.DecimalPlaces = 3;
            this.numPosA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosA.Location = new System.Drawing.Point(66, 114);
            this.numPosA.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPosA.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numPosA.Name = "numPosA";
            this.numPosA.Size = new System.Drawing.Size(120, 29);
            this.numPosA.TabIndex = 14;
            this.numPosA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelposA
            // 
            this.labelposA.AutoSize = true;
            this.labelposA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposA.Location = new System.Drawing.Point(40, 119);
            this.labelposA.Name = "labelposA";
            this.labelposA.Size = new System.Drawing.Size(21, 20);
            this.labelposA.TabIndex = 13;
            this.labelposA.Text = "A";
            // 
            // buttonZtoZero
            // 
            this.buttonZtoZero.Image = global::CNC_App.Properties.Resources.digit_separator;
            this.buttonZtoZero.Location = new System.Drawing.Point(4, 81);
            this.buttonZtoZero.Name = "buttonZtoZero";
            this.buttonZtoZero.Size = new System.Drawing.Size(26, 28);
            this.buttonZtoZero.TabIndex = 12;
            this.buttonZtoZero.UseVisualStyleBackColor = true;
            this.buttonZtoZero.Click += new System.EventHandler(this.buttonZtoZero_Click);
            // 
            // buttonYtoZero
            // 
            this.buttonYtoZero.Image = global::CNC_App.Properties.Resources.digit_separator;
            this.buttonYtoZero.Location = new System.Drawing.Point(4, 47);
            this.buttonYtoZero.Name = "buttonYtoZero";
            this.buttonYtoZero.Size = new System.Drawing.Size(26, 28);
            this.buttonYtoZero.TabIndex = 11;
            this.buttonYtoZero.UseVisualStyleBackColor = true;
            this.buttonYtoZero.Click += new System.EventHandler(this.buttonYtoZero_Click);
            // 
            // buttonXtoZero
            // 
            this.buttonXtoZero.Image = global::CNC_App.Properties.Resources.digit_separator;
            this.buttonXtoZero.Location = new System.Drawing.Point(4, 14);
            this.buttonXtoZero.Name = "buttonXtoZero";
            this.buttonXtoZero.Size = new System.Drawing.Size(26, 28);
            this.buttonXtoZero.TabIndex = 10;
            this.buttonXtoZero.UseVisualStyleBackColor = true;
            this.buttonXtoZero.Click += new System.EventHandler(this.buttonXtoZero_Click);
            // 
            // numPosZ
            // 
            this.numPosZ.DecimalPlaces = 3;
            this.numPosZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosZ.Location = new System.Drawing.Point(66, 81);
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
            this.numPosZ.TabIndex = 5;
            this.numPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numPosY
            // 
            this.numPosY.DecimalPlaces = 3;
            this.numPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosY.Location = new System.Drawing.Point(66, 47);
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
            this.numPosY.TabIndex = 4;
            this.numPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numPosX
            // 
            this.numPosX.DecimalPlaces = 3;
            this.numPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosX.Location = new System.Drawing.Point(66, 13);
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
            this.numPosX.TabIndex = 3;
            this.numPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelposZ
            // 
            this.labelposZ.AutoSize = true;
            this.labelposZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposZ.Location = new System.Drawing.Point(40, 86);
            this.labelposZ.Name = "labelposZ";
            this.labelposZ.Size = new System.Drawing.Size(20, 20);
            this.labelposZ.TabIndex = 2;
            this.labelposZ.Text = "Z";
            // 
            // labelposY
            // 
            this.labelposY.AutoSize = true;
            this.labelposY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposY.Location = new System.Drawing.Point(39, 52);
            this.labelposY.Name = "labelposY";
            this.labelposY.Size = new System.Drawing.Size(21, 20);
            this.labelposY.TabIndex = 1;
            this.labelposY.Text = "Y";
            // 
            // labelposX
            // 
            this.labelposX.AutoSize = true;
            this.labelposX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposX.Location = new System.Drawing.Point(39, 18);
            this.labelposX.Name = "labelposX";
            this.labelposX.Size = new System.Drawing.Size(21, 20);
            this.labelposX.TabIndex = 0;
            this.labelposX.Text = "X";
            // 
            // GUI_panel_POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxPositions);
            this.Name = "GUI_panel_POS";
            this.Size = new System.Drawing.Size(200, 154);
            this.Load += new System.EventHandler(this.GUI_panel_POS_Load);
            this.groupBoxPositions.ResumeLayout(false);
            this.groupBoxPositions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPositions;
        private System.Windows.Forms.Button buttonZtoZero;
        private System.Windows.Forms.Button buttonYtoZero;
        private System.Windows.Forms.Button buttonXtoZero;
        private System.Windows.Forms.NumericUpDown numPosZ;
        private System.Windows.Forms.NumericUpDown numPosY;
        private System.Windows.Forms.NumericUpDown numPosX;
        private System.Windows.Forms.Label labelposZ;
        private System.Windows.Forms.Label labelposY;
        private System.Windows.Forms.Label labelposX;
        private System.Windows.Forms.Button buttonAtoZero;
        private System.Windows.Forms.NumericUpDown numPosA;
        private System.Windows.Forms.Label labelposA;
    }
}
