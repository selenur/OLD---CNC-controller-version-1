namespace CNC_Controller
{
    partial class EditGkode
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.labelposX = new System.Windows.Forms.Label();
            this.checkBoxChangePos = new System.Windows.Forms.CheckBox();
            this.labelposY = new System.Windows.Forms.Label();
            this.numPosZ = new System.Windows.Forms.NumericUpDown();
            this.labelposZ = new System.Windows.Forms.Label();
            this.numPosY = new System.Windows.Forms.NumericUpDown();
            this.numPosX = new System.Windows.Forms.NumericUpDown();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox6);
            this.groupBox2.Controls.Add(this.labelposX);
            this.groupBox2.Controls.Add(this.checkBoxChangePos);
            this.groupBox2.Controls.Add(this.labelposY);
            this.groupBox2.Controls.Add(this.numPosZ);
            this.groupBox2.Controls.Add(this.labelposZ);
            this.groupBox2.Controls.Add(this.numPosY);
            this.groupBox2.Controls.Add(this.numPosX);
            this.groupBox2.Location = new System.Drawing.Point(33, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 213);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выполнение G-кода";
            // 
            // checkBox6
            // 
            this.checkBox6.Location = new System.Drawing.Point(25, 149);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(234, 49);
            this.checkBox6.TabIndex = 14;
            this.checkBox6.Text = "Корректировать высоту Z с учетом сканирования поверхности";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // labelposX
            // 
            this.labelposX.AutoSize = true;
            this.labelposX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposX.Location = new System.Drawing.Point(21, 51);
            this.labelposX.Name = "labelposX";
            this.labelposX.Size = new System.Drawing.Size(21, 20);
            this.labelposX.TabIndex = 6;
            this.labelposX.Text = "X";
            // 
            // checkBoxChangePos
            // 
            this.checkBoxChangePos.AutoSize = true;
            this.checkBoxChangePos.Location = new System.Drawing.Point(6, 19);
            this.checkBoxChangePos.Name = "checkBoxChangePos";
            this.checkBoxChangePos.Size = new System.Drawing.Size(178, 17);
            this.checkBoxChangePos.TabIndex = 12;
            this.checkBoxChangePos.Text = "Выполнять смещение данных";
            this.checkBoxChangePos.UseVisualStyleBackColor = true;
            this.checkBoxChangePos.CheckedChanged += new System.EventHandler(this.checkBoxChangePos_CheckedChanged);
            // 
            // labelposY
            // 
            this.labelposY.AutoSize = true;
            this.labelposY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposY.Location = new System.Drawing.Point(21, 85);
            this.labelposY.Name = "labelposY";
            this.labelposY.Size = new System.Drawing.Size(21, 20);
            this.labelposY.TabIndex = 7;
            this.labelposY.Text = "Y";
            // 
            // numPosZ
            // 
            this.numPosZ.DecimalPlaces = 3;
            this.numPosZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosZ.Location = new System.Drawing.Point(48, 114);
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
            this.numPosZ.TabIndex = 11;
            this.numPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPosZ.ValueChanged += new System.EventHandler(this.numPosZ_ValueChanged);
            // 
            // labelposZ
            // 
            this.labelposZ.AutoSize = true;
            this.labelposZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposZ.Location = new System.Drawing.Point(22, 119);
            this.labelposZ.Name = "labelposZ";
            this.labelposZ.Size = new System.Drawing.Size(20, 20);
            this.labelposZ.TabIndex = 8;
            this.labelposZ.Text = "Z";
            // 
            // numPosY
            // 
            this.numPosY.DecimalPlaces = 3;
            this.numPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosY.Location = new System.Drawing.Point(48, 80);
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
            this.numPosY.TabIndex = 10;
            this.numPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPosY.ValueChanged += new System.EventHandler(this.numPosY_ValueChanged);
            // 
            // numPosX
            // 
            this.numPosX.DecimalPlaces = 3;
            this.numPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosX.Location = new System.Drawing.Point(48, 46);
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
            this.numPosX.TabIndex = 9;
            this.numPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPosX.ValueChanged += new System.EventHandler(this.numPosX_ValueChanged);
            // 
            // EditGkode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 399);
            this.Controls.Add(this.groupBox2);
            this.Name = "EditGkode";
            this.Text = "EditGkode";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EditGkode_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Label labelposX;
        private System.Windows.Forms.CheckBox checkBoxChangePos;
        private System.Windows.Forms.Label labelposY;
        private System.Windows.Forms.NumericUpDown numPosZ;
        private System.Windows.Forms.Label labelposZ;
        private System.Windows.Forms.NumericUpDown numPosY;
        private System.Windows.Forms.NumericUpDown numPosX;
    }
}