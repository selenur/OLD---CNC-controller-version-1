namespace CNC_Assist
{
    partial class GUI_panel_Limits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI_panel_Limits));
            this.groupBoxLimits = new System.Windows.Forms.GroupBox();
            this.labelZmax = new System.Windows.Forms.Label();
            this.labelZmin = new System.Windows.Forms.Label();
            this.labelYmax = new System.Windows.Forms.Label();
            this.labelXmin = new System.Windows.Forms.Label();
            this.labelYmin = new System.Windows.Forms.Label();
            this.labelXmax = new System.Windows.Forms.Label();
            this.timerCheckStatus = new System.Windows.Forms.Timer(this.components);
            this.groupBoxLimits.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLimits
            // 
            this.groupBoxLimits.Controls.Add(this.labelZmax);
            this.groupBoxLimits.Controls.Add(this.labelZmin);
            this.groupBoxLimits.Controls.Add(this.labelYmax);
            this.groupBoxLimits.Controls.Add(this.labelXmin);
            this.groupBoxLimits.Controls.Add(this.labelYmin);
            this.groupBoxLimits.Controls.Add(this.labelXmax);
            this.groupBoxLimits.Location = new System.Drawing.Point(3, 3);
            this.groupBoxLimits.Name = "groupBoxLimits";
            this.groupBoxLimits.Size = new System.Drawing.Size(192, 88);
            this.groupBoxLimits.TabIndex = 7;
            this.groupBoxLimits.TabStop = false;
            this.groupBoxLimits.Text = "Индикация лимитов";
            // 
            // labelZmax
            // 
            this.labelZmax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelZmax.Image = ((System.Drawing.Image)(resources.GetObject("labelZmax.Image")));
            this.labelZmax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelZmax.Location = new System.Drawing.Point(92, 62);
            this.labelZmax.Name = "labelZmax";
            this.labelZmax.Size = new System.Drawing.Size(85, 23);
            this.labelZmax.TabIndex = 10;
            this.labelZmax.Text = "       Zмакс";
            this.labelZmax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelZmin
            // 
            this.labelZmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelZmin.Image = ((System.Drawing.Image)(resources.GetObject("labelZmin.Image")));
            this.labelZmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelZmin.Location = new System.Drawing.Point(6, 62);
            this.labelZmin.Name = "labelZmin";
            this.labelZmin.Size = new System.Drawing.Size(80, 23);
            this.labelZmin.TabIndex = 9;
            this.labelZmin.Text = "       Zмин";
            this.labelZmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelYmax
            // 
            this.labelYmax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelYmax.Image = ((System.Drawing.Image)(resources.GetObject("labelYmax.Image")));
            this.labelYmax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelYmax.Location = new System.Drawing.Point(92, 39);
            this.labelYmax.Name = "labelYmax";
            this.labelYmax.Size = new System.Drawing.Size(91, 23);
            this.labelYmax.TabIndex = 8;
            this.labelYmax.Text = "       Yмакс";
            this.labelYmax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelXmin
            // 
            this.labelXmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelXmin.Image = global::CNC_Assist.Properties.Resources.draw_ellipse;
            this.labelXmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelXmin.Location = new System.Drawing.Point(6, 16);
            this.labelXmin.Name = "labelXmin";
            this.labelXmin.Size = new System.Drawing.Size(80, 23);
            this.labelXmin.TabIndex = 5;
            this.labelXmin.Text = "       Xмин";
            this.labelXmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelYmin
            // 
            this.labelYmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelYmin.Image = ((System.Drawing.Image)(resources.GetObject("labelYmin.Image")));
            this.labelYmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelYmin.Location = new System.Drawing.Point(6, 39);
            this.labelYmin.Name = "labelYmin";
            this.labelYmin.Size = new System.Drawing.Size(80, 23);
            this.labelYmin.TabIndex = 7;
            this.labelYmin.Text = "       Yмин";
            this.labelYmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelXmax
            // 
            this.labelXmax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelXmax.Image = ((System.Drawing.Image)(resources.GetObject("labelXmax.Image")));
            this.labelXmax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelXmax.Location = new System.Drawing.Point(92, 16);
            this.labelXmax.Name = "labelXmax";
            this.labelXmax.Size = new System.Drawing.Size(92, 23);
            this.labelXmax.TabIndex = 6;
            this.labelXmax.Text = "       Xмакс";
            this.labelXmax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerCheckStatus
            // 
            this.timerCheckStatus.Enabled = true;
            this.timerCheckStatus.Tick += new System.EventHandler(this.timerCheckStatus_Tick);
            // 
            // GUI_panel_Limits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxLimits);
            this.Name = "GUI_panel_Limits";
            this.Size = new System.Drawing.Size(200, 99);
            this.groupBoxLimits.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLimits;
        private System.Windows.Forms.Label labelZmax;
        private System.Windows.Forms.Label labelZmin;
        private System.Windows.Forms.Label labelYmax;
        private System.Windows.Forms.Label labelXmin;
        private System.Windows.Forms.Label labelYmin;
        private System.Windows.Forms.Label labelXmax;
        private System.Windows.Forms.Timer timerCheckStatus;
    }
}
