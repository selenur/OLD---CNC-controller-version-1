namespace CNC_Assist
{
    partial class GUI_panel_3DView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxShowScanedGrid = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonShowAllCode = new System.Windows.Forms.RadioButton();
            this.radioButtonShowNOTCompleatedCode = new System.Windows.Forms.RadioButton();
            this.radioButtonShowCompleatedCode = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownSizeGrig = new System.Windows.Forms.NumericUpDown();
            this.checkBoxShowGrid = new System.Windows.Forms.CheckBox();
            this.checkBoxShowCursor = new System.Windows.Forms.CheckBox();
            this.checkBoxShowAxes = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeGrig)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxShowScanedGrid);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownSizeGrig);
            this.groupBox1.Controls.Add(this.checkBoxShowGrid);
            this.groupBox1.Controls.Add(this.checkBoxShowCursor);
            this.groupBox1.Controls.Add(this.checkBoxShowAxes);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 253);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки 3D";
            // 
            // checkBoxShowScanedGrid
            // 
            this.checkBoxShowScanedGrid.Location = new System.Drawing.Point(9, 216);
            this.checkBoxShowScanedGrid.Name = "checkBoxShowScanedGrid";
            this.checkBoxShowScanedGrid.Size = new System.Drawing.Size(179, 32);
            this.checkBoxShowScanedGrid.TabIndex = 9;
            this.checkBoxShowScanedGrid.Text = "Отображать сетку сканирования";
            this.checkBoxShowScanedGrid.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonShowAllCode);
            this.groupBox2.Controls.Add(this.radioButtonShowNOTCompleatedCode);
            this.groupBox2.Controls.Add(this.radioButtonShowCompleatedCode);
            this.groupBox2.Location = new System.Drawing.Point(6, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 90);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отображать G-код";
            // 
            // radioButtonShowAllCode
            // 
            this.radioButtonShowAllCode.AutoSize = true;
            this.radioButtonShowAllCode.Checked = true;
            this.radioButtonShowAllCode.Location = new System.Drawing.Point(6, 19);
            this.radioButtonShowAllCode.Name = "radioButtonShowAllCode";
            this.radioButtonShowAllCode.Size = new System.Drawing.Size(50, 17);
            this.radioButtonShowAllCode.TabIndex = 5;
            this.radioButtonShowAllCode.TabStop = true;
            this.radioButtonShowAllCode.Text = "Весь";
            this.radioButtonShowAllCode.UseVisualStyleBackColor = true;
            // 
            // radioButtonShowNOTCompleatedCode
            // 
            this.radioButtonShowNOTCompleatedCode.AutoSize = true;
            this.radioButtonShowNOTCompleatedCode.Location = new System.Drawing.Point(6, 65);
            this.radioButtonShowNOTCompleatedCode.Name = "radioButtonShowNOTCompleatedCode";
            this.radioButtonShowNOTCompleatedCode.Size = new System.Drawing.Size(132, 17);
            this.radioButtonShowNOTCompleatedCode.TabIndex = 7;
            this.radioButtonShowNOTCompleatedCode.Text = "Осталось выполнить";
            this.radioButtonShowNOTCompleatedCode.UseVisualStyleBackColor = true;
            // 
            // radioButtonShowCompleatedCode
            // 
            this.radioButtonShowCompleatedCode.AutoSize = true;
            this.radioButtonShowCompleatedCode.Location = new System.Drawing.Point(6, 42);
            this.radioButtonShowCompleatedCode.Name = "radioButtonShowCompleatedCode";
            this.radioButtonShowCompleatedCode.Size = new System.Drawing.Size(76, 17);
            this.radioButtonShowCompleatedCode.TabIndex = 6;
            this.radioButtonShowCompleatedCode.Text = "Выполнен";
            this.radioButtonShowCompleatedCode.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Размер сетки (мм.)";
            // 
            // numericUpDownSizeGrig
            // 
            this.numericUpDownSizeGrig.Location = new System.Drawing.Point(118, 94);
            this.numericUpDownSizeGrig.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownSizeGrig.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSizeGrig.Name = "numericUpDownSizeGrig";
            this.numericUpDownSizeGrig.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownSizeGrig.TabIndex = 3;
            this.numericUpDownSizeGrig.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // checkBoxShowGrid
            // 
            this.checkBoxShowGrid.AutoSize = true;
            this.checkBoxShowGrid.Location = new System.Drawing.Point(9, 69);
            this.checkBoxShowGrid.Name = "checkBoxShowGrid";
            this.checkBoxShowGrid.Size = new System.Drawing.Size(119, 17);
            this.checkBoxShowGrid.TabIndex = 2;
            this.checkBoxShowGrid.Text = "Отображать сетку";
            this.checkBoxShowGrid.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowCursor
            // 
            this.checkBoxShowCursor.AutoSize = true;
            this.checkBoxShowCursor.Location = new System.Drawing.Point(9, 46);
            this.checkBoxShowCursor.Name = "checkBoxShowCursor";
            this.checkBoxShowCursor.Size = new System.Drawing.Size(126, 17);
            this.checkBoxShowCursor.TabIndex = 1;
            this.checkBoxShowCursor.Text = "Отображать курсор";
            this.checkBoxShowCursor.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowAxes
            // 
            this.checkBoxShowAxes.AutoSize = true;
            this.checkBoxShowAxes.Location = new System.Drawing.Point(9, 23);
            this.checkBoxShowAxes.Name = "checkBoxShowAxes";
            this.checkBoxShowAxes.Size = new System.Drawing.Size(109, 17);
            this.checkBoxShowAxes.TabIndex = 0;
            this.checkBoxShowAxes.Text = "Отображать оси";
            this.checkBoxShowAxes.UseVisualStyleBackColor = true;
            // 
            // GUI_panel_3DView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "GUI_panel_3DView";
            this.Size = new System.Drawing.Size(200, 263);
            this.Load += new System.EventHandler(this.GUI_panel_3DView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeGrig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonShowAllCode;
        private System.Windows.Forms.RadioButton radioButtonShowNOTCompleatedCode;
        private System.Windows.Forms.RadioButton radioButtonShowCompleatedCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeGrig;
        private System.Windows.Forms.CheckBox checkBoxShowGrid;
        private System.Windows.Forms.CheckBox checkBoxShowCursor;
        private System.Windows.Forms.CheckBox checkBoxShowAxes;
        private System.Windows.Forms.CheckBox checkBoxShowScanedGrid;
    }
}
