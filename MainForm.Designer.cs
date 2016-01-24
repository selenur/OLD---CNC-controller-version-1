namespace CNC_Assist
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.fromBufferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.modulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webcameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanSurfaceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.bt_ConnDiskonect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bt_exit2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonSpindel = new System.Windows.Forms.ToolStripButton();
            this.buttonESTOP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditData = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownadditionally = new System.Windows.Forms.ToolStripDropDownButton();
            this.additionallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3D = new System.Windows.Forms.TabPage();
            this.btDefaulPreview = new System.Windows.Forms.Button();
            this.lb3DPosView = new System.Windows.Forms.Label();
            this.menu3Dview = new System.Windows.Forms.MenuStrip();
            this.menuLabelX = new System.Windows.Forms.ToolStripLabel();
            this.posAngleXm = new System.Windows.Forms.ToolStripButton();
            this.posAngleX = new System.Windows.Forms.ToolStripLabel();
            this.posAngleXp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLabelY = new System.Windows.Forms.ToolStripLabel();
            this.posAngleYp = new System.Windows.Forms.ToolStripButton();
            this.posAngleY = new System.Windows.Forms.ToolStripLabel();
            this.posAngleYm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLabelZ = new System.Windows.Forms.ToolStripLabel();
            this.posAngleZp = new System.Windows.Forms.ToolStripButton();
            this.posAngleZ = new System.Windows.Forms.ToolStripLabel();
            this.posAngleZm = new System.Windows.Forms.ToolStripButton();
            this.OpenGL_preview = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.tabPageSupp = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxNewSpped = new System.Windows.Forms.CheckBox();
            this.btToBuffer = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.radioButton_RC = new System.Windows.Forms.RadioButton();
            this.radioButton_Hz = new System.Windows.Forms.RadioButton();
            this.radioButton_off = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.timerKeyHook = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.RenderTimer = new System.Windows.Forms.Timer(this.components);
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.MainMenu.SuspendLayout();
            this.MainToolStrip.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3D.SuspendLayout();
            this.menu3Dview.SuspendLayout();
            this.tabPageSupp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            this.panelCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modulesToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.menuLanguageToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(864, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenFile,
            this.fromBufferToolStripMenuItem,
            this.bt_exit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // menuOpenFile
            // 
            this.menuOpenFile.Image = global::CNC_Assist.Properties.Resources.open_folder;
            this.menuOpenFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuOpenFile.Name = "menuOpenFile";
            this.menuOpenFile.Size = new System.Drawing.Size(212, 38);
            this.menuOpenFile.Text = "Открыть файл";
            this.menuOpenFile.Click += new System.EventHandler(this.menuOpenFile_Click);
            // 
            // fromBufferToolStripMenuItem
            // 
            this.fromBufferToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fromBufferToolStripMenuItem.Image")));
            this.fromBufferToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fromBufferToolStripMenuItem.Name = "fromBufferToolStripMenuItem";
            this.fromBufferToolStripMenuItem.Size = new System.Drawing.Size(212, 38);
            this.fromBufferToolStripMenuItem.Text = "Загрузить из буффера";
            this.fromBufferToolStripMenuItem.Click += new System.EventHandler(this.fromBufferToolStripMenuItem_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Image = global::CNC_Assist.Properties.Resources.door_in;
            this.bt_exit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(212, 38);
            this.bt_exit.Text = "Завершение работы";
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // modulesToolStripMenuItem
            // 
            this.modulesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.webcameraToolStripMenuItem,
            this.scanSurfaceToolStripMenuItem1});
            this.modulesToolStripMenuItem.Name = "modulesToolStripMenuItem";
            this.modulesToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.modulesToolStripMenuItem.Text = "Модули";
            // 
            // webcameraToolStripMenuItem
            // 
            this.webcameraToolStripMenuItem.Image = global::CNC_Assist.Properties.Resources.webcam;
            this.webcameraToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.webcameraToolStripMenuItem.Name = "webcameraToolStripMenuItem";
            this.webcameraToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.webcameraToolStripMenuItem.Text = "Веб-камера";
            this.webcameraToolStripMenuItem.Click += new System.EventHandler(this.webcameraToolStripMenuItem_Click);
            // 
            // scanSurfaceToolStripMenuItem1
            // 
            this.scanSurfaceToolStripMenuItem1.Image = global::CNC_Assist.Properties.Resources.layer_grid;
            this.scanSurfaceToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scanSurfaceToolStripMenuItem1.Name = "scanSurfaceToolStripMenuItem1";
            this.scanSurfaceToolStripMenuItem1.Size = new System.Drawing.Size(243, 38);
            this.scanSurfaceToolStripMenuItem1.Text = "Сканирование поверхности";
            this.scanSurfaceToolStripMenuItem1.Click += new System.EventHandler(this.scanSurfaceToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpToolStripMenuItem.Text = "Справка";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::CNC_Assist.Properties.Resources.contact_email;
            this.aboutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(165, 38);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // menuLanguageToolStripMenuItem
            // 
            this.menuLanguageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRuToolStripMenuItem,
            this.menuEnToolStripMenuItem});
            this.menuLanguageToolStripMenuItem.Image = global::CNC_Assist.Properties.Resources.flag_russia;
            this.menuLanguageToolStripMenuItem.Name = "menuLanguageToolStripMenuItem";
            this.menuLanguageToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.menuLanguageToolStripMenuItem.Text = "Язык";
            // 
            // menuRuToolStripMenuItem
            // 
            this.menuRuToolStripMenuItem.Image = global::CNC_Assist.Properties.Resources.flag_russia;
            this.menuRuToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuRuToolStripMenuItem.Name = "menuRuToolStripMenuItem";
            this.menuRuToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
            this.menuRuToolStripMenuItem.Text = "русский";
            this.menuRuToolStripMenuItem.Click += new System.EventHandler(this.menuRuToolStripMenuItem_Click);
            // 
            // menuEnToolStripMenuItem
            // 
            this.menuEnToolStripMenuItem.Image = global::CNC_Assist.Properties.Resources.flag_great_britain;
            this.menuEnToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuEnToolStripMenuItem.Name = "menuEnToolStripMenuItem";
            this.menuEnToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
            this.menuEnToolStripMenuItem.Text = "Английский";
            this.menuEnToolStripMenuItem.Click += new System.EventHandler(this.menuEnToolStripMenuItem_Click);
            // 
            // MainToolStrip
            // 
            this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bt_ConnDiskonect,
            this.toolStripSeparator1,
            this.btOpenFile,
            this.toolStripSeparator2,
            this.bt_exit2,
            this.toolStripSeparator3,
            this.buttonSpindel,
            this.buttonESTOP,
            this.toolStripSeparator4,
            this.toolStripButton1,
            this.toolStripButtonEditData,
            this.toolStripDropDownadditionally});
            this.MainToolStrip.Location = new System.Drawing.Point(0, 24);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Size = new System.Drawing.Size(864, 39);
            this.MainToolStrip.TabIndex = 1;
            this.MainToolStrip.Text = "toolStrip1";
            // 
            // bt_ConnDiskonect
            // 
            this.bt_ConnDiskonect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bt_ConnDiskonect.Image = global::CNC_Assist.Properties.Resources.disconnect;
            this.bt_ConnDiskonect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bt_ConnDiskonect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt_ConnDiskonect.Name = "bt_ConnDiskonect";
            this.bt_ConnDiskonect.Size = new System.Drawing.Size(36, 36);
            this.bt_ConnDiskonect.Text = "Подключиться к контроллеру";
            this.bt_ConnDiskonect.Click += new System.EventHandler(this.bt_ConnDiskonect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btOpenFile
            // 
            this.btOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btOpenFile.Image = global::CNC_Assist.Properties.Resources.open_folder;
            this.btOpenFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(36, 36);
            this.btOpenFile.Text = "Открыть файл";
            this.btOpenFile.Click += new System.EventHandler(this.btOpenFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // bt_exit2
            // 
            this.bt_exit2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bt_exit2.Image = global::CNC_Assist.Properties.Resources.door_in;
            this.bt_exit2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bt_exit2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt_exit2.Name = "bt_exit2";
            this.bt_exit2.Size = new System.Drawing.Size(36, 36);
            this.bt_exit2.Text = "toolStripButton2";
            this.bt_exit2.Click += new System.EventHandler(this.bt_exit2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // buttonSpindel
            // 
            this.buttonSpindel.Enabled = false;
            this.buttonSpindel.Image = ((System.Drawing.Image)(resources.GetObject("buttonSpindel.Image")));
            this.buttonSpindel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonSpindel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSpindel.Name = "buttonSpindel";
            this.buttonSpindel.Size = new System.Drawing.Size(110, 36);
            this.buttonSpindel.Text = "ШПИНДЕЛЬ";
            this.buttonSpindel.Click += new System.EventHandler(this.buttonSpindel_Click);
            // 
            // buttonESTOP
            // 
            this.buttonESTOP.Enabled = false;
            this.buttonESTOP.Image = ((System.Drawing.Image)(resources.GetObject("buttonESTOP.Image")));
            this.buttonESTOP.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonESTOP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonESTOP.Name = "buttonESTOP";
            this.buttonESTOP.Size = new System.Drawing.Size(115, 36);
            this.buttonESTOP.Text = "ОСТАНОВКА";
            this.buttonESTOP.Click += new System.EventHandler(this.toolStripButtonEnergyStop_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::CNC_Assist.Properties.Resources.document_prepare;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(103, 36);
            this.toolStripButton1.Text = "Настройки";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButtonEditData
            // 
            this.toolStripButtonEditData.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditData.Image")));
            this.toolStripButtonEditData.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonEditData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditData.Name = "toolStripButtonEditData";
            this.toolStripButtonEditData.Size = new System.Drawing.Size(179, 36);
            this.toolStripButtonEditData.Text = "манипуляции с G-кодом";
            this.toolStripButtonEditData.Click += new System.EventHandler(this.toolStripButtonEditData_Click);
            // 
            // toolStripDropDownadditionally
            // 
            this.toolStripDropDownadditionally.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.additionallyToolStripMenuItem});
            this.toolStripDropDownadditionally.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownadditionally.Image")));
            this.toolStripDropDownadditionally.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownadditionally.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownadditionally.Name = "toolStripDropDownadditionally";
            this.toolStripDropDownadditionally.Size = new System.Drawing.Size(140, 36);
            this.toolStripDropDownadditionally.Text = "Дополнительно";
            // 
            // additionallyToolStripMenuItem
            // 
            this.additionallyToolStripMenuItem.Image = global::CNC_Assist.Properties.Resources.video_mode;
            this.additionallyToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.additionallyToolStripMenuItem.Name = "additionallyToolStripMenuItem";
            this.additionallyToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.additionallyToolStripMenuItem.Text = "Настройка 3D отображения";
            this.additionallyToolStripMenuItem.Click += new System.EventHandler(this.additionallyToolStripMenuItem_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 582);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(864, 22);
            this.MainStatusStrip.TabIndex = 2;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabel1.Text = "FPS:000";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3D);
            this.tabControl1.Controls.Add(this.tabPageSupp);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 510);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3D
            // 
            this.tabPage3D.Controls.Add(this.btDefaulPreview);
            this.tabPage3D.Controls.Add(this.lb3DPosView);
            this.tabPage3D.Controls.Add(this.menu3Dview);
            this.tabPage3D.Controls.Add(this.OpenGL_preview);
            this.tabPage3D.Location = new System.Drawing.Point(4, 22);
            this.tabPage3D.Name = "tabPage3D";
            this.tabPage3D.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3D.Size = new System.Drawing.Size(430, 484);
            this.tabPage3D.TabIndex = 2;
            this.tabPage3D.Text = "3D";
            this.tabPage3D.UseVisualStyleBackColor = true;
            // 
            // btDefaulPreview
            // 
            this.btDefaulPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDefaulPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDefaulPreview.Location = new System.Drawing.Point(283, 0);
            this.btDefaulPreview.Name = "btDefaulPreview";
            this.btDefaulPreview.Size = new System.Drawing.Size(146, 23);
            this.btDefaulPreview.TabIndex = 23;
            this.btDefaulPreview.Text = "Исходный вид 3D просмотра";
            this.btDefaulPreview.UseVisualStyleBackColor = true;
            this.btDefaulPreview.Click += new System.EventHandler(this.btDefaulPreview_Click);
            // 
            // lb3DPosView
            // 
            this.lb3DPosView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb3DPosView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb3DPosView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb3DPosView.Location = new System.Drawing.Point(2, 1);
            this.lb3DPosView.Name = "lb3DPosView";
            this.lb3DPosView.Size = new System.Drawing.Size(281, 22);
            this.lb3DPosView.TabIndex = 22;
            this.lb3DPosView.Text = "---------------------------------------------------";
            this.lb3DPosView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menu3Dview
            // 
            this.menu3Dview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menu3Dview.AutoSize = false;
            this.menu3Dview.Dock = System.Windows.Forms.DockStyle.None;
            this.menu3Dview.Font = new System.Drawing.Font("Tahoma", 10F);
            this.menu3Dview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLabelX,
            this.posAngleXm,
            this.posAngleX,
            this.posAngleXp,
            this.toolStripSeparator10,
            this.menuLabelY,
            this.posAngleYp,
            this.posAngleY,
            this.posAngleYm,
            this.toolStripSeparator11,
            this.menuLabelZ,
            this.posAngleZp,
            this.posAngleZ,
            this.posAngleZm});
            this.menu3Dview.Location = new System.Drawing.Point(2, 23);
            this.menu3Dview.Name = "menu3Dview";
            this.menu3Dview.Size = new System.Drawing.Size(425, 37);
            this.menu3Dview.TabIndex = 24;
            this.menu3Dview.Text = "menuStrip1";
            // 
            // menuLabelX
            // 
            this.menuLabelX.Name = "menuLabelX";
            this.menuLabelX.Size = new System.Drawing.Size(89, 30);
            this.menuLabelX.Text = "Вращение: X";
            // 
            // posAngleXm
            // 
            this.posAngleXm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.posAngleXm.ForeColor = System.Drawing.Color.Yellow;
            this.posAngleXm.Image = global::CNC_Assist.Properties.Resources.undo;
            this.posAngleXm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.posAngleXm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.posAngleXm.Name = "posAngleXm";
            this.posAngleXm.Size = new System.Drawing.Size(36, 30);
            this.posAngleXm.Click += new System.EventHandler(this.posAngleXm_Click);
            // 
            // posAngleX
            // 
            this.posAngleX.Name = "posAngleX";
            this.posAngleX.Size = new System.Drawing.Size(23, 30);
            this.posAngleX.Text = "0°";
            this.posAngleX.Click += new System.EventHandler(this.posAngleX_Click);
            // 
            // posAngleXp
            // 
            this.posAngleXp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.posAngleXp.ForeColor = System.Drawing.Color.Yellow;
            this.posAngleXp.Image = global::CNC_Assist.Properties.Resources.redo;
            this.posAngleXp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.posAngleXp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.posAngleXp.Name = "posAngleXp";
            this.posAngleXp.Size = new System.Drawing.Size(36, 30);
            this.posAngleXp.Click += new System.EventHandler(this.posAngleXp_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 33);
            // 
            // menuLabelY
            // 
            this.menuLabelY.Name = "menuLabelY";
            this.menuLabelY.Size = new System.Drawing.Size(16, 30);
            this.menuLabelY.Text = "Y";
            // 
            // posAngleYp
            // 
            this.posAngleYp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.posAngleYp.ForeColor = System.Drawing.Color.Yellow;
            this.posAngleYp.Image = global::CNC_Assist.Properties.Resources.undo;
            this.posAngleYp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.posAngleYp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.posAngleYp.Name = "posAngleYp";
            this.posAngleYp.Size = new System.Drawing.Size(36, 30);
            this.posAngleYp.Click += new System.EventHandler(this.posAngleYp_Click);
            // 
            // posAngleY
            // 
            this.posAngleY.Name = "posAngleY";
            this.posAngleY.Size = new System.Drawing.Size(23, 30);
            this.posAngleY.Text = "0°";
            this.posAngleY.Click += new System.EventHandler(this.posAngleY_Click);
            // 
            // posAngleYm
            // 
            this.posAngleYm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.posAngleYm.ForeColor = System.Drawing.Color.Yellow;
            this.posAngleYm.Image = global::CNC_Assist.Properties.Resources.redo;
            this.posAngleYm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.posAngleYm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.posAngleYm.Name = "posAngleYm";
            this.posAngleYm.Size = new System.Drawing.Size(36, 30);
            this.posAngleYm.Click += new System.EventHandler(this.posAngleYm_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 33);
            // 
            // menuLabelZ
            // 
            this.menuLabelZ.Name = "menuLabelZ";
            this.menuLabelZ.Size = new System.Drawing.Size(16, 30);
            this.menuLabelZ.Text = "Z";
            // 
            // posAngleZp
            // 
            this.posAngleZp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.posAngleZp.Image = global::CNC_Assist.Properties.Resources.undo;
            this.posAngleZp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.posAngleZp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.posAngleZp.Name = "posAngleZp";
            this.posAngleZp.Size = new System.Drawing.Size(36, 30);
            this.posAngleZp.Click += new System.EventHandler(this.posAngleZp_Click);
            // 
            // posAngleZ
            // 
            this.posAngleZ.Name = "posAngleZ";
            this.posAngleZ.Size = new System.Drawing.Size(23, 30);
            this.posAngleZ.Text = "0°";
            this.posAngleZ.Click += new System.EventHandler(this.posAngleZ_Click);
            // 
            // posAngleZm
            // 
            this.posAngleZm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.posAngleZm.Image = global::CNC_Assist.Properties.Resources.redo;
            this.posAngleZm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.posAngleZm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.posAngleZm.Name = "posAngleZm";
            this.posAngleZm.Size = new System.Drawing.Size(36, 30);
            this.posAngleZm.Click += new System.EventHandler(this.posAngleZm_Click);
            // 
            // OpenGL_preview
            // 
            this.OpenGL_preview.AccumBits = ((byte)(0));
            this.OpenGL_preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenGL_preview.AutoCheckErrors = false;
            this.OpenGL_preview.AutoFinish = false;
            this.OpenGL_preview.AutoMakeCurrent = true;
            this.OpenGL_preview.AutoSwapBuffers = true;
            this.OpenGL_preview.BackColor = System.Drawing.Color.Gainsboro;
            this.OpenGL_preview.ColorBits = ((byte)(32));
            this.OpenGL_preview.DepthBits = ((byte)(16));
            this.OpenGL_preview.ForeColor = System.Drawing.Color.SlateBlue;
            this.OpenGL_preview.Location = new System.Drawing.Point(2, 65);
            this.OpenGL_preview.Name = "OpenGL_preview";
            this.OpenGL_preview.Size = new System.Drawing.Size(425, 413);
            this.OpenGL_preview.StencilBits = ((byte)(0));
            this.OpenGL_preview.TabIndex = 21;
            this.OpenGL_preview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OpenGL_preview_KeyDown);
            this.OpenGL_preview.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OpenGL_preview_KeyPress);
            this.OpenGL_preview.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OpenGL_preview_KeyUp);
            this.OpenGL_preview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpenGL_preview_MouseDown);
            this.OpenGL_preview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OpenGL_preview_MouseMove);
            this.OpenGL_preview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OpenGL_preview_MouseUp);
            this.OpenGL_preview.Resize += new System.EventHandler(this.OpenGL_preview_Resize);
            // 
            // tabPageSupp
            // 
            this.tabPageSupp.Controls.Add(this.label2);
            this.tabPageSupp.Controls.Add(this.numericUpDown1);
            this.tabPageSupp.Controls.Add(this.label1);
            this.tabPageSupp.Controls.Add(this.numericUpDown9);
            this.tabPageSupp.Controls.Add(this.checkBoxNewSpped);
            this.tabPageSupp.Controls.Add(this.btToBuffer);
            this.tabPageSupp.Controls.Add(this.groupBox9);
            this.tabPageSupp.Controls.Add(this.button1);
            this.tabPageSupp.Controls.Add(this.listBoxLog);
            this.tabPageSupp.Location = new System.Drawing.Point(4, 22);
            this.tabPageSupp.Name = "tabPageSupp";
            this.tabPageSupp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSupp.Size = new System.Drawing.Size(430, 484);
            this.tabPageSupp.TabIndex = 1;
            this.tabPageSupp.Text = "Дополнительно";
            this.tabPageSupp.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 405);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "max pwm";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(273, 428);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            330000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(119, 20);
            this.numericUpDown1.TabIndex = 13;
            this.numericUpDown1.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(232, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Пауза между отрезками";
            // 
            // numericUpDown9
            // 
            this.numericUpDown9.Enabled = false;
            this.numericUpDown9.ForeColor = System.Drawing.Color.DarkBlue;
            this.numericUpDown9.Location = new System.Drawing.Point(254, 342);
            this.numericUpDown9.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown9.Name = "numericUpDown9";
            this.numericUpDown9.Size = new System.Drawing.Size(78, 20);
            this.numericUpDown9.TabIndex = 11;
            this.numericUpDown9.Value = new decimal(new int[] {
            57,
            0,
            0,
            0});
            // 
            // checkBoxNewSpped
            // 
            this.checkBoxNewSpped.Checked = true;
            this.checkBoxNewSpped.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNewSpped.Enabled = false;
            this.checkBoxNewSpped.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxNewSpped.ForeColor = System.Drawing.Color.MidnightBlue;
            this.checkBoxNewSpped.Location = new System.Drawing.Point(233, 269);
            this.checkBoxNewSpped.Name = "checkBoxNewSpped";
            this.checkBoxNewSpped.Size = new System.Drawing.Size(131, 46);
            this.checkBoxNewSpped.TabIndex = 10;
            this.checkBoxNewSpped.Text = "Использовать новый режим обработки";
            this.checkBoxNewSpped.UseVisualStyleBackColor = true;
            // 
            // btToBuffer
            // 
            this.btToBuffer.Location = new System.Drawing.Point(95, 3);
            this.btToBuffer.Name = "btToBuffer";
            this.btToBuffer.Size = new System.Drawing.Size(209, 22);
            this.btToBuffer.TabIndex = 9;
            this.btToBuffer.Text = "Лог сохранить в буфер обмена";
            this.btToBuffer.UseVisualStyleBackColor = true;
            this.btToBuffer.Click += new System.EventHandler(this.btToBuffer_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.radioButton_RC);
            this.groupBox9.Controls.Add(this.radioButton_Hz);
            this.groupBox9.Controls.Add(this.radioButton_off);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.trackBar1);
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Controls.Add(this.button2);
            this.groupBox9.Controls.Add(this.numericUpDown8);
            this.groupBox9.Controls.Add(this.numericUpDown7);
            this.groupBox9.Controls.Add(this.checkBox18);
            this.groupBox9.Location = new System.Drawing.Point(6, 220);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(220, 260);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Генерация сигнала";
            // 
            // radioButton_RC
            // 
            this.radioButton_RC.AutoSize = true;
            this.radioButton_RC.Location = new System.Drawing.Point(14, 80);
            this.radioButton_RC.Name = "radioButton_RC";
            this.radioButton_RC.Size = new System.Drawing.Size(40, 17);
            this.radioButton_RC.TabIndex = 9;
            this.radioButton_RC.Text = "RC";
            this.radioButton_RC.UseVisualStyleBackColor = true;
            // 
            // radioButton_Hz
            // 
            this.radioButton_Hz.AutoSize = true;
            this.radioButton_Hz.Location = new System.Drawing.Point(14, 63);
            this.radioButton_Hz.Name = "radioButton_Hz";
            this.radioButton_Hz.Size = new System.Drawing.Size(38, 17);
            this.radioButton_Hz.TabIndex = 8;
            this.radioButton_Hz.Text = "Hz";
            this.radioButton_Hz.UseVisualStyleBackColor = true;
            // 
            // radioButton_off
            // 
            this.radioButton_off.AutoSize = true;
            this.radioButton_off.Checked = true;
            this.radioButton_off.Location = new System.Drawing.Point(13, 45);
            this.radioButton_off.Name = "radioButton_off";
            this.radioButton_off.Size = new System.Drawing.Size(37, 17);
            this.radioButton_off.TabIndex = 7;
            this.radioButton_off.TabStop = true;
            this.radioButton_off.Text = "off";
            this.radioButton_off.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Скорость ШИМ";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(11, 194);
            this.trackBar1.Maximum = 500;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(154, 45);
            this.trackBar1.SmallChange = 50;
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(58, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "№ канала для ШИМ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 46);
            this.button2.TabIndex = 4;
            this.button2.Text = "Послать команду";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.Location = new System.Drawing.Point(11, 168);
            this.numericUpDown8.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Size = new System.Drawing.Size(105, 20);
            this.numericUpDown8.TabIndex = 3;
            this.numericUpDown8.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown8.ValueChanged += new System.EventHandler(this.numericUpDown8_ValueChanged);
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.Location = new System.Drawing.Point(74, 80);
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(45, 20);
            this.numericUpDown7.TabIndex = 2;
            // 
            // checkBox18
            // 
            this.checkBox18.AutoSize = true;
            this.checkBox18.Location = new System.Drawing.Point(7, 22);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(100, 17);
            this.checkBox18.TabIndex = 0;
            this.checkBox18.Text = "вкл. шпиндель";
            this.checkBox18.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btLogClear_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(3, 28);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(459, 186);
            this.listBoxLog.TabIndex = 0;
            // 
            // timerKeyHook
            // 
            this.timerKeyHook.Enabled = true;
            this.timerKeyHook.Interval = 10;
            this.timerKeyHook.Tick += new System.EventHandler(this.timerKeyHooks_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "Выбор файла с данными";
            // 
            // RenderTimer
            // 
            this.RenderTimer.Enabled = true;
            this.RenderTimer.Interval = 30;
            this.RenderTimer.Tick += new System.EventHandler(this.RenderTimer_Tick);
            // 
            // panelCenter
            // 
            this.panelCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCenter.Controls.Add(this.tabControl1);
            this.panelCenter.Location = new System.Drawing.Point(210, 66);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(440, 512);
            this.panelCenter.TabIndex = 8;
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Location = new System.Drawing.Point(656, 66);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(204, 511);
            this.panelRight.TabIndex = 9;
            // 
            // panelLeft
            // 
            this.panelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Location = new System.Drawing.Point(0, 67);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(204, 511);
            this.panelLeft.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 604);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.MainToolStrip);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Хобби ЧПУ 2.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3D.ResumeLayout(false);
            this.menu3Dview.ResumeLayout(false);
            this.menu3Dview.PerformLayout();
            this.tabPageSupp.ResumeLayout(false);
            this.tabPageSupp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            this.panelCenter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStrip MainToolStrip;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripButton bt_ConnDiskonect;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuOpenFile;
        private System.Windows.Forms.ToolStripMenuItem bt_exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bt_exit2;
        private System.Windows.Forms.ToolStripButton btOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Timer timerKeyHook;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageSupp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton buttonSpindel;
        private System.Windows.Forms.ToolStripButton buttonESTOP;
        private System.Windows.Forms.TabPage tabPage3D;
        private System.Windows.Forms.Button btDefaulPreview;
        private System.Windows.Forms.Label lb3DPosView;
        private System.Windows.Forms.MenuStrip menu3Dview;
        private System.Windows.Forms.ToolStripLabel menuLabelX;
        private System.Windows.Forms.ToolStripButton posAngleXm;
        private System.Windows.Forms.ToolStripLabel posAngleX;
        private System.Windows.Forms.ToolStripButton posAngleXp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripLabel menuLabelY;
        private System.Windows.Forms.ToolStripButton posAngleYp;
        private System.Windows.Forms.ToolStripLabel posAngleY;
        private System.Windows.Forms.ToolStripButton posAngleYm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripLabel menuLabelZ;
        private System.Windows.Forms.ToolStripButton posAngleZp;
        private System.Windows.Forms.ToolStripLabel posAngleZ;
        private System.Windows.Forms.ToolStripButton posAngleZm;
        private Tao.Platform.Windows.SimpleOpenGlControl OpenGL_preview;
        private System.Windows.Forms.Timer RenderTimer;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox checkBox18;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDown8;
        private System.Windows.Forms.NumericUpDown numericUpDown7;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.RadioButton radioButton_RC;
        private System.Windows.Forms.RadioButton radioButton_Hz;
        private System.Windows.Forms.RadioButton radioButton_off;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownadditionally;
        private System.Windows.Forms.ToolStripMenuItem additionallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditData;
        private System.Windows.Forms.Button btToBuffer;
        private System.Windows.Forms.CheckBox checkBoxNewSpped;
        private System.Windows.Forms.NumericUpDown numericUpDown9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.FlowLayoutPanel panelRight;
        private System.Windows.Forms.FlowLayoutPanel panelLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ToolStripMenuItem modulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webcameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromBufferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanSurfaceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuRuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuEnToolStripMenuItem;
    }
}

