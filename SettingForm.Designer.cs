namespace CNC_Assist.SettingApp
{
    partial class SettingForm
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
            this.btAppyChange = new System.Windows.Forms.Button();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btAppyChange
            // 
            this.btAppyChange.Enabled = false;
            this.btAppyChange.Image = global::CNC_Assist.Properties.Resources.accept_button;
            this.btAppyChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAppyChange.Location = new System.Drawing.Point(385, 527);
            this.btAppyChange.Name = "btAppyChange";
            this.btAppyChange.Size = new System.Drawing.Size(108, 28);
            this.btAppyChange.TabIndex = 0;
            this.btAppyChange.Text = "Применить";
            this.btAppyChange.UseVisualStyleBackColor = true;
            this.btAppyChange.Click += new System.EventHandler(this.btAppyChange_Click);
            // 
            // propertyGrid
            // 
            this.propertyGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.propertyGrid.Location = new System.Drawing.Point(213, 2);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(394, 515);
            this.propertyGrid.TabIndex = 3;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(7, 6);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(197, 510);
            this.treeView1.TabIndex = 4;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // btClose
            // 
            this.btClose.Image = global::CNC_Assist.Properties.Resources.cross;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClose.Location = new System.Drawing.Point(499, 527);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(108, 28);
            this.btClose.TabIndex = 5;
            this.btClose.Text = "Закрыть";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 557);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.btAppyChange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingForm";
            this.Text = "Настройки программы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingAPP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btAppyChange;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btClose;
    }
}