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
            this.toolStripMenuAddGroupe = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuAddPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.openDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delPrimitivToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btSubMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.btAddCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.btAddPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.btAddSpiral = new System.Windows.Forms.ToolStripMenuItem();
            this.btAddCircle = new System.Windows.Forms.ToolStripMenuItem();
            this.btAddBox = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btGenerateGCode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btNewData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btLoadFromFile = new System.Windows.Forms.ToolStripButton();
            this.btSaveToFile = new System.Windows.Forms.ToolStripButton();
            this.contextMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeDataConstructor
            // 
            this.treeDataConstructor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeDataConstructor.ContextMenuStrip = this.contextMenu;
            this.treeDataConstructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeDataConstructor.FullRowSelect = true;
            this.treeDataConstructor.HideSelection = false;
            this.treeDataConstructor.ImageIndex = 0;
            this.treeDataConstructor.ImageList = this.imageList1;
            this.treeDataConstructor.Location = new System.Drawing.Point(4, 27);
            this.treeDataConstructor.Name = "treeDataConstructor";
            this.treeDataConstructor.SelectedImageIndex = 0;
            this.treeDataConstructor.Size = new System.Drawing.Size(744, 649);
            this.treeDataConstructor.TabIndex = 0;
            this.treeDataConstructor.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeDataConstructor_BeforeCollapse);
            this.treeDataConstructor.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDataConstructor_AfterSelect);
            this.treeDataConstructor.Click += new System.EventHandler(this.treeDataConstructor_Click);
            this.treeDataConstructor.DoubleClick += new System.EventHandler(this.treeDataConstructor_DoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuAddGroupe,
            this.toolStripMenuAddPoint,
            this.toolStripSeparator5,
            this.openDialogToolStripMenuItem,
            this.delPrimitivToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(190, 98);
            // 
            // toolStripMenuAddGroupe
            // 
            this.toolStripMenuAddGroupe.Image = global::CNC_Controller.Properties.Resources.folder;
            this.toolStripMenuAddGroupe.Name = "toolStripMenuAddGroupe";
            this.toolStripMenuAddGroupe.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuAddGroupe.Text = "Добавить группу";
            this.toolStripMenuAddGroupe.Click += new System.EventHandler(this.toolStripMenuAddGroupe_Click);
            // 
            // toolStripMenuAddPoint
            // 
            this.toolStripMenuAddPoint.Image = global::CNC_Controller.Properties.Resources.bullet_blue;
            this.toolStripMenuAddPoint.Name = "toolStripMenuAddPoint";
            this.toolStripMenuAddPoint.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuAddPoint.Text = "Добавить точку";
            this.toolStripMenuAddPoint.Click += new System.EventHandler(this.toolStripMenuAddPoint_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(186, 6);
            // 
            // openDialogToolStripMenuItem
            // 
            this.openDialogToolStripMenuItem.Image = global::CNC_Controller.Properties.Resources.application;
            this.openDialogToolStripMenuItem.Name = "openDialogToolStripMenuItem";
            this.openDialogToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.openDialogToolStripMenuItem.Text = "Свойства примитива";
            this.openDialogToolStripMenuItem.Click += new System.EventHandler(this.openDialogToolStripMenuItem_Click);
            // 
            // delPrimitivToolStripMenuItem
            // 
            this.delPrimitivToolStripMenuItem.Image = global::CNC_Controller.Properties.Resources.delete;
            this.delPrimitivToolStripMenuItem.Name = "delPrimitivToolStripMenuItem";
            this.delPrimitivToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.delPrimitivToolStripMenuItem.Text = "Удалить примитив";
            this.delPrimitivToolStripMenuItem.Click += new System.EventHandler(this.delPrimitivToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "asterisk_orange.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "bullet_blue.png");
            this.imageList1.Images.SetKeyName(3, "draw_line.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btSubMenu,
            this.toolStripSeparator2,
            this.btGenerateGCode,
            this.toolStripSeparator1,
            this.btNewData,
            this.toolStripSeparator3,
            this.btLoadFromFile,
            this.btSaveToFile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(752, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btSubMenu
            // 
            this.btSubMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btAddCatalog,
            this.btAddPoint,
            this.btAddSpiral,
            this.btAddCircle,
            this.btAddBox});
            this.btSubMenu.Image = ((System.Drawing.Image)(resources.GetObject("btSubMenu.Image")));
            this.btSubMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSubMenu.Name = "btSubMenu";
            this.btSubMenu.Size = new System.Drawing.Size(137, 22);
            this.btSubMenu.Text = "Добавить элемент";
            // 
            // btAddCatalog
            // 
            this.btAddCatalog.Image = global::CNC_Controller.Properties.Resources.folder;
            this.btAddCatalog.Name = "btAddCatalog";
            this.btAddCatalog.Size = new System.Drawing.Size(163, 22);
            this.btAddCatalog.Text = "Группа";
            this.btAddCatalog.Click += new System.EventHandler(this.btAddCatalog_Click);
            // 
            // btAddPoint
            // 
            this.btAddPoint.Image = global::CNC_Controller.Properties.Resources.bullet_blue;
            this.btAddPoint.Name = "btAddPoint";
            this.btAddPoint.Size = new System.Drawing.Size(163, 22);
            this.btAddPoint.Text = "Точка";
            this.btAddPoint.Click += new System.EventHandler(this.btAddPoint_Click);
            // 
            // btAddSpiral
            // 
            this.btAddSpiral.Enabled = false;
            this.btAddSpiral.Image = global::CNC_Controller.Properties.Resources.draw_spiral;
            this.btAddSpiral.Name = "btAddSpiral";
            this.btAddSpiral.Size = new System.Drawing.Size(163, 22);
            this.btAddSpiral.Text = "спираль";
            // 
            // btAddCircle
            // 
            this.btAddCircle.Enabled = false;
            this.btAddCircle.Image = global::CNC_Controller.Properties.Resources.draw_ellipse1;
            this.btAddCircle.Name = "btAddCircle";
            this.btAddCircle.Size = new System.Drawing.Size(163, 22);
            this.btAddCircle.Text = "Окружность";
            // 
            // btAddBox
            // 
            this.btAddBox.Enabled = false;
            this.btAddBox.Image = global::CNC_Controller.Properties.Resources.grid;
            this.btAddBox.Name = "btAddBox";
            this.btAddBox.Size = new System.Drawing.Size(163, 22);
            this.btAddBox.Text = "Прямоугольник";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btGenerateGCode
            // 
            this.btGenerateGCode.Enabled = false;
            this.btGenerateGCode.Image = ((System.Drawing.Image)(resources.GetObject("btGenerateGCode.Image")));
            this.btGenerateGCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btGenerateGCode.Name = "btGenerateGCode";
            this.btGenerateGCode.Size = new System.Drawing.Size(126, 22);
            this.btGenerateGCode.Text = "Генерация G-кода";
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btLoadFromFile
            // 
            this.btLoadFromFile.Image = ((System.Drawing.Image)(resources.GetObject("btLoadFromFile.Image")));
            this.btLoadFromFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btLoadFromFile.Name = "btLoadFromFile";
            this.btLoadFromFile.Size = new System.Drawing.Size(128, 22);
            this.btLoadFromFile.Text = "Загрузка из файла";
            this.btLoadFromFile.Click += new System.EventHandler(this.btLoadFromFile_Click);
            // 
            // btSaveToFile
            // 
            this.btSaveToFile.Image = ((System.Drawing.Image)(resources.GetObject("btSaveToFile.Image")));
            this.btSaveToFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSaveToFile.Name = "btSaveToFile";
            this.btSaveToFile.Size = new System.Drawing.Size(134, 22);
            this.btSaveToFile.Text = "Сохранение в файл";
            this.btSaveToFile.Click += new System.EventHandler(this.btSaveToFile_Click);
            // 
            // GeneratorCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 679);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.treeDataConstructor);
            this.Name = "GeneratorCode";
            this.Text = "Генератор G-кода";
            this.Load += new System.EventHandler(this.GeneratorCode_Load);
            this.contextMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeDataConstructor;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btNewData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btGenerateGCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton btSubMenu;
        private System.Windows.Forms.ToolStripMenuItem btAddPoint;
        private System.Windows.Forms.ToolStripMenuItem btAddCatalog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btAddBox;
        private System.Windows.Forms.ToolStripMenuItem btAddCircle;
        private System.Windows.Forms.ToolStripMenuItem btAddSpiral;
        private System.Windows.Forms.ToolStripButton btLoadFromFile;
        private System.Windows.Forms.ToolStripButton btSaveToFile;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAddGroupe;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAddPoint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem openDialogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delPrimitivToolStripMenuItem;
    }
}