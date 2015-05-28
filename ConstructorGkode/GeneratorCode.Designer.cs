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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratorCode));
            this.treeDataConstructor = new System.Windows.Forms.TreeView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuCopyDATA = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delPrimitivToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.moveupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movedownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btLoadFromFile = new System.Windows.Forms.ToolStripButton();
            this.btSaveToFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btNewData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStripPrimitiv = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.contextMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStripPrimitiv.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeDataConstructor
            // 
            this.treeDataConstructor.ContextMenuStrip = this.contextMenu;
            this.treeDataConstructor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDataConstructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeDataConstructor.FullRowSelect = true;
            this.treeDataConstructor.HideSelection = false;
            this.treeDataConstructor.ImageIndex = 0;
            this.treeDataConstructor.ImageList = this.imageList1;
            this.treeDataConstructor.Location = new System.Drawing.Point(0, 0);
            this.treeDataConstructor.Name = "treeDataConstructor";
            this.treeDataConstructor.SelectedImageIndex = 0;
            this.treeDataConstructor.Size = new System.Drawing.Size(667, 629);
            this.treeDataConstructor.TabIndex = 0;
            this.treeDataConstructor.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeDataConstructor_BeforeCollapse);
            this.treeDataConstructor.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDataConstructor_AfterSelect);
            this.treeDataConstructor.DoubleClick += new System.EventHandler(this.treeDataConstructor_DoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDialogToolStripMenuItem,
            this.toolStripSeparator3,
            this.ToolStripMenuCopyDATA,
            this.pasteToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.delPrimitivToolStripMenuItem,
            this.toolStripSeparator5,
            this.moveupToolStripMenuItem,
            this.movedownToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(190, 170);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // openDialogToolStripMenuItem
            // 
            this.openDialogToolStripMenuItem.Image = global::CNC_Controller.Properties.Resources.application;
            this.openDialogToolStripMenuItem.Name = "openDialogToolStripMenuItem";
            this.openDialogToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.openDialogToolStripMenuItem.Text = "Свойства примитива";
            this.openDialogToolStripMenuItem.Click += new System.EventHandler(this.openDialogToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(186, 6);
            // 
            // ToolStripMenuCopyDATA
            // 
            this.ToolStripMenuCopyDATA.Image = global::CNC_Controller.Properties.Resources.page_copy;
            this.ToolStripMenuCopyDATA.Name = "ToolStripMenuCopyDATA";
            this.ToolStripMenuCopyDATA.Size = new System.Drawing.Size(189, 22);
            this.ToolStripMenuCopyDATA.Text = "Копировать";
            this.ToolStripMenuCopyDATA.Click += new System.EventHandler(this.ToolStripMenuCopyDATA_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::CNC_Controller.Properties.Resources.page_paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.pasteToolStripMenuItem.Text = "Вставить";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::CNC_Controller.Properties.Resources.cut_red;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.cutToolStripMenuItem.Text = "Вырезать";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // delPrimitivToolStripMenuItem
            // 
            this.delPrimitivToolStripMenuItem.Image = global::CNC_Controller.Properties.Resources.cross;
            this.delPrimitivToolStripMenuItem.Name = "delPrimitivToolStripMenuItem";
            this.delPrimitivToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.delPrimitivToolStripMenuItem.Text = "Удалить";
            this.delPrimitivToolStripMenuItem.Click += new System.EventHandler(this.delPrimitivToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(186, 6);
            // 
            // moveupToolStripMenuItem
            // 
            this.moveupToolStripMenuItem.Enabled = false;
            this.moveupToolStripMenuItem.Image = global::CNC_Controller.Properties.Resources.arrow_up;
            this.moveupToolStripMenuItem.Name = "moveupToolStripMenuItem";
            this.moveupToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.moveupToolStripMenuItem.Text = "Сдвинуть вверх";
            // 
            // movedownToolStripMenuItem
            // 
            this.movedownToolStripMenuItem.Enabled = false;
            this.movedownToolStripMenuItem.Image = global::CNC_Controller.Properties.Resources.arrow_down;
            this.movedownToolStripMenuItem.Name = "movedownToolStripMenuItem";
            this.movedownToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.movedownToolStripMenuItem.Text = "Сдвинуть вниз";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "asterisk_orange.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "bullet_blue.png");
            this.imageList1.Images.SetKeyName(3, "draw_line.png");
            this.imageList1.Images.SetKeyName(4, "arrow_repeat.png");
            this.imageList1.Images.SetKeyName(5, "arrow_out.png");
            this.imageList1.Images.SetKeyName(6, "arrow_rotate_clockwise.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btLoadFromFile,
            this.btSaveToFile,
            this.toolStripSeparator1,
            this.SaveToFile,
            this.toolStripSeparator2,
            this.btNewData});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(752, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btLoadFromFile
            // 
            this.btLoadFromFile.Image = ((System.Drawing.Image)(resources.GetObject("btLoadFromFile.Image")));
            this.btLoadFromFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btLoadFromFile.Name = "btLoadFromFile";
            this.btLoadFromFile.Size = new System.Drawing.Size(119, 22);
            this.btLoadFromFile.Text = "Чтение из файла";
            this.btLoadFromFile.Click += new System.EventHandler(this.btLoadFromFile_Click);
            // 
            // btSaveToFile
            // 
            this.btSaveToFile.Image = ((System.Drawing.Image)(resources.GetObject("btSaveToFile.Image")));
            this.btSaveToFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSaveToFile.Name = "btSaveToFile";
            this.btSaveToFile.Size = new System.Drawing.Size(126, 22);
            this.btSaveToFile.Text = "Сохранить в файл";
            this.btSaveToFile.Click += new System.EventHandler(this.btSaveToFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btNewData
            // 
            this.btNewData.Image = ((System.Drawing.Image)(resources.GetObject("btNewData.Image")));
            this.btNewData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btNewData.Name = "btNewData";
            this.btNewData.Size = new System.Drawing.Size(137, 22);
            this.btNewData.Text = "Очистить от данных";
            this.btNewData.Click += new System.EventHandler(this.btNewData_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // SaveToFile
            // 
            this.SaveToFile.Image = global::CNC_Controller.Properties.Resources.save_as;
            this.SaveToFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToFile.Name = "SaveToFile";
            this.SaveToFile.Size = new System.Drawing.Size(161, 22);
            this.SaveToFile.Text = "Сохранить G-код в файл";
            this.SaveToFile.Click += new System.EventHandler(this.SaveToFile_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.treeDataConstructor);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(667, 629);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStripPrimitiv);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 25);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(752, 654);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripPrimitiv
            // 
            this.toolStripPrimitiv.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripPrimitiv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator4,
            this.toolStripLabel2,
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripButton2});
            this.toolStripPrimitiv.Location = new System.Drawing.Point(0, 3);
            this.toolStripPrimitiv.Name = "toolStripPrimitiv";
            this.toolStripPrimitiv.Size = new System.Drawing.Size(85, 139);
            this.toolStripPrimitiv.TabIndex = 0;
            this.toolStripPrimitiv.Text = "Примитив";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(83, 15);
            this.toolStripLabel1.Text = "-Примитивы-";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::CNC_Controller.Properties.Resources.folder;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(83, 20);
            this.toolStripMenuItem1.Text = "Группа";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::CNC_Controller.Properties.Resources.bullet_blue;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(83, 20);
            this.toolStripMenuItem2.Text = "Точка";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(83, 6);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(83, 15);
            this.toolStripLabel2.Text = "-Функции-";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(83, 20);
            this.toolStripButton1.Text = "Цикл";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(83, 20);
            this.toolStripButton3.Text = "Вращение";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(83, 20);
            this.toolStripButton2.Text = "Маштаб";
            this.toolStripButton2.Visible = false;
            // 
            // GeneratorCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 679);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "GeneratorCode";
            this.Text = "Генератор G-кода";
            this.Load += new System.EventHandler(this.GeneratorCode_Load);
            this.contextMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStripPrimitiv.ResumeLayout(false);
            this.toolStripPrimitiv.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeDataConstructor;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btNewData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btLoadFromFile;
        private System.Windows.Forms.ToolStripButton btSaveToFile;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem openDialogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delPrimitivToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStripPrimitiv;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuCopyDATA;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem moveupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movedownToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton SaveToFile;
    }
}