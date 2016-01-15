namespace CNC_Assist
{
    partial class GUI_panel_ManualControl
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
            this.components = new System.ComponentModel.Container();
            this.groupBoxManualMove = new System.Windows.Forms.GroupBox();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.numericUpDownManualSpeed = new System.Windows.Forms.NumericUpDown();
            this.buttonShowKeyInfo = new System.Windows.Forms.Button();
            this.checkBoxManualMove = new System.Windows.Forms.CheckBox();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.tbSendGKode = new System.Windows.Forms.TextBox();
            this.groupBoxManualMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownManualSpeed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxManualMove
            // 
            this.groupBoxManualMove.Controls.Add(this.lbSpeed);
            this.groupBoxManualMove.Controls.Add(this.numericUpDownManualSpeed);
            this.groupBoxManualMove.Controls.Add(this.buttonShowKeyInfo);
            this.groupBoxManualMove.Controls.Add(this.checkBoxManualMove);
            this.groupBoxManualMove.Location = new System.Drawing.Point(5, 3);
            this.groupBoxManualMove.Name = "groupBoxManualMove";
            this.groupBoxManualMove.Size = new System.Drawing.Size(192, 109);
            this.groupBoxManualMove.TabIndex = 1;
            this.groupBoxManualMove.TabStop = false;
            this.groupBoxManualMove.Text = "Ручное управление";
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSpeed.Location = new System.Drawing.Point(9, 39);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(101, 24);
            this.lbSpeed.TabIndex = 0;
            this.lbSpeed.Text = "Скорость:";
            // 
            // numericUpDownManualSpeed
            // 
            this.numericUpDownManualSpeed.Enabled = false;
            this.numericUpDownManualSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownManualSpeed.Location = new System.Drawing.Point(116, 37);
            this.numericUpDownManualSpeed.Maximum = new decimal(new int[] {
            7500,
            0,
            0,
            0});
            this.numericUpDownManualSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownManualSpeed.Name = "numericUpDownManualSpeed";
            this.numericUpDownManualSpeed.Size = new System.Drawing.Size(65, 29);
            this.numericUpDownManualSpeed.TabIndex = 4;
            this.numericUpDownManualSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownManualSpeed.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // buttonShowKeyInfo
            // 
            this.buttonShowKeyInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonShowKeyInfo.Location = new System.Drawing.Point(6, 71);
            this.buttonShowKeyInfo.Name = "buttonShowKeyInfo";
            this.buttonShowKeyInfo.Size = new System.Drawing.Size(181, 32);
            this.buttonShowKeyInfo.TabIndex = 1;
            this.buttonShowKeyInfo.Text = "Управление мышкой";
            this.buttonShowKeyInfo.UseVisualStyleBackColor = true;
            this.buttonShowKeyInfo.Click += new System.EventHandler(this.buttonShowKeyInfo_Click);
            // 
            // checkBoxManualMove
            // 
            this.checkBoxManualMove.AutoSize = true;
            this.checkBoxManualMove.Location = new System.Drawing.Point(9, 19);
            this.checkBoxManualMove.Name = "checkBoxManualMove";
            this.checkBoxManualMove.Size = new System.Drawing.Size(141, 17);
            this.checkBoxManualMove.TabIndex = 0;
            this.checkBoxManualMove.Text = "Управление с NumPad";
            this.checkBoxManualMove.UseVisualStyleBackColor = true;
            this.checkBoxManualMove.CheckedChanged += new System.EventHandler(this.checkBoxManualMove_CheckedChanged);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSend);
            this.groupBox1.Controls.Add(this.tbSendGKode);
            this.groupBox1.Location = new System.Drawing.Point(9, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 70);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выполнить G-код";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(10, 40);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(172, 29);
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "Выполнить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // tbSendGKode
            // 
            this.tbSendGKode.Location = new System.Drawing.Point(8, 16);
            this.tbSendGKode.Name = "tbSendGKode";
            this.tbSendGKode.Size = new System.Drawing.Size(175, 20);
            this.tbSendGKode.TabIndex = 0;
            this.tbSendGKode.TextChanged += new System.EventHandler(this.tbSendGKode_TextChanged);
            this.tbSendGKode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSendGKode_KeyDown);
            // 
            // GUI_panel_ManualControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxManualMove);
            this.Name = "GUI_panel_ManualControl";
            this.Size = new System.Drawing.Size(200, 185);
            this.groupBoxManualMove.ResumeLayout(false);
            this.groupBoxManualMove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownManualSpeed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxManualMove;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Button buttonShowKeyInfo;
        public System.Windows.Forms.CheckBox checkBoxManualMove;
        public System.Windows.Forms.NumericUpDown numericUpDownManualSpeed;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbSendGKode;
        private System.Windows.Forms.Button buttonSend;
    }
}
