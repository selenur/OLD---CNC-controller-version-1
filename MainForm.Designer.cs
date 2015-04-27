namespace CNC_Controller
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
            this.controllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNumberInstruction = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelPosition = new System.Windows.Forms.Panel();
            this.groupBoxPositions = new System.Windows.Forms.GroupBox();
            this.numPosZ = new System.Windows.Forms.NumericUpDown();
            this.numPosY = new System.Windows.Forms.NumericUpDown();
            this.numPosX = new System.Windows.Forms.NumericUpDown();
            this.labelposZ = new System.Windows.Forms.Label();
            this.labelposY = new System.Windows.Forms.Label();
            this.labelposX = new System.Windows.Forms.Label();
            this.panelIndicator = new System.Windows.Forms.Panel();
            this.groupBoxLimits = new System.Windows.Forms.GroupBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelControl1 = new System.Windows.Forms.Panel();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.groupBoxManualMove = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownManualSpeed = new System.Windows.Forms.NumericUpDown();
            this.buttonShowKeyInfo = new System.Windows.Forms.Button();
            this.checkBoxManualMove = new System.Windows.Forms.CheckBox();
            this.groupBoxManualSpeedGkode = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3D = new System.Windows.Forms.TabPage();
            this.btDefaulPreview = new System.Windows.Forms.Button();
            this.lb3DPosView = new System.Windows.Forms.Label();
            this.menu3Dview = new System.Windows.Forms.MenuStrip();
            this.menuLabelX = new System.Windows.Forms.ToolStripLabel();
            this.posAngleX = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLabelY = new System.Windows.Forms.ToolStripLabel();
            this.posAngleY = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLabelZ = new System.Windows.Forms.ToolStripLabel();
            this.posAngleZ = new System.Windows.Forms.ToolStripLabel();
            this.OpenGL_preview = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.tabPageSupp = new System.Windows.Forms.TabPage();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.radioButton_RC = new System.Windows.Forms.RadioButton();
            this.radioButton_Hz = new System.Windows.Forms.RadioButton();
            this.radioButton_off = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxB0 = new System.Windows.Forms.CheckBox();
            this.checkBoxB1 = new System.Windows.Forms.CheckBox();
            this.checkBoxB2 = new System.Windows.Forms.CheckBox();
            this.checkBoxB3 = new System.Windows.Forms.CheckBox();
            this.checkBoxB4 = new System.Windows.Forms.CheckBox();
            this.checkBoxB5 = new System.Windows.Forms.CheckBox();
            this.checkBoxB6 = new System.Windows.Forms.CheckBox();
            this.checkBoxB7 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.groupBoxWorking = new System.Windows.Forms.GroupBox();
            this.textBoxNumberLine = new System.Windows.Forms.TextBox();
            this.labelWorkingRow = new System.Windows.Forms.Label();
            this.timerKeyHook = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.RenderTimer = new System.Windows.Forms.Timer(this.components);
            this.TaskTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listGkodeCommand = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.posAngleXm = new System.Windows.Forms.ToolStripButton();
            this.posAngleXp = new System.Windows.Forms.ToolStripButton();
            this.posAngleYp = new System.Windows.Forms.ToolStripButton();
            this.posAngleYm = new System.Windows.Forms.ToolStripButton();
            this.posAngleZp = new System.Windows.Forms.ToolStripButton();
            this.posAngleZm = new System.Windows.Forms.ToolStripButton();
            this.buttonPauseTask = new System.Windows.Forms.Button();
            this.btStopTask = new System.Windows.Forms.Button();
            this.buttonStartTask = new System.Windows.Forms.Button();
            this.buttonZtoZero = new System.Windows.Forms.Button();
            this.buttonYtoZero = new System.Windows.Forms.Button();
            this.buttonXtoZero = new System.Windows.Forms.Button();
            this.labelZmax = new System.Windows.Forms.Label();
            this.labelZmin = new System.Windows.Forms.Label();
            this.labelYmax = new System.Windows.Forms.Label();
            this.labelXmin = new System.Windows.Forms.Label();
            this.labelYmin = new System.Windows.Forms.Label();
            this.labelXmax = new System.Windows.Forms.Label();
            this.bt_ConnDiskonect = new System.Windows.Forms.ToolStripButton();
            this.btOpenFile = new System.Windows.Forms.ToolStripButton();
            this.bt_exit2 = new System.Windows.Forms.ToolStripButton();
            this.buttonSpindel = new System.Windows.Forms.ToolStripButton();
            this.buttonESTOP = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownadditionally = new System.Windows.Forms.ToolStripDropDownButton();
            this.settingControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scansurfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatorCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonEditData = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLikePoint = new System.Windows.Forms.ToolStripButton();
            this.menuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.btConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_disconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.MainToolStrip.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelPosition.SuspendLayout();
            this.groupBoxPositions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).BeginInit();
            this.panelIndicator.SuspendLayout();
            this.groupBoxLimits.SuspendLayout();
            this.panelControl1.SuspendLayout();
            this.groupBoxManualMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownManualSpeed)).BeginInit();
            this.groupBoxManualSpeedGkode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3D.SuspendLayout();
            this.menu3Dview.SuspendLayout();
            this.tabPageSupp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.groupBoxWorking.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.controllerToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(910, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenFile,
            this.bt_exit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "&Файл";
            // 
            // controllerToolStripMenuItem
            // 
            this.controllerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btConnect,
            this.bt_disconnect,
            this.settingToolStripMenuItem});
            this.controllerToolStripMenuItem.Name = "controllerToolStripMenuItem";
            this.controllerToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.controllerToolStripMenuItem.Text = "&Контроллер";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.helpToolStripMenuItem.Text = "Помощь";
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
            this.toolStripDropDownadditionally,
            this.toolStripButtonEditData,
            this.toolStripButtonLikePoint});
            this.MainToolStrip.Location = new System.Drawing.Point(0, 24);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Size = new System.Drawing.Size(910, 39);
            this.MainToolStrip.TabIndex = 1;
            this.MainToolStrip.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar,
            this.toolStripStatus,
            this.toolStripStatusLabelNumberInstruction});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 581);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(910, 22);
            this.MainStatusStrip.TabIndex = 2;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(22, 17);
            this.toolStripStatusLabel1.Text = "---";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(300, 16);
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(49, 17);
            this.toolStripStatus.Text = ".....         ";
            this.toolStripStatus.Click += new System.EventHandler(this.toolStripStatus_Click);
            // 
            // toolStripStatusLabelNumberInstruction
            // 
            this.toolStripStatusLabelNumberInstruction.Name = "toolStripStatusLabelNumberInstruction";
            this.toolStripStatusLabelNumberInstruction.Size = new System.Drawing.Size(22, 17);
            this.toolStripStatusLabelNumberInstruction.Text = "---";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.Controls.Add(this.panelPosition);
            this.flowLayoutPanel1.Controls.Add(this.panelIndicator);
            this.flowLayoutPanel1.Controls.Add(this.panelControl1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 66);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(204, 512);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // panelPosition
            // 
            this.panelPosition.Controls.Add(this.groupBoxPositions);
            this.panelPosition.Enabled = false;
            this.panelPosition.Location = new System.Drawing.Point(3, 3);
            this.panelPosition.Name = "panelPosition";
            this.panelPosition.Size = new System.Drawing.Size(198, 119);
            this.panelPosition.TabIndex = 4;
            // 
            // groupBoxPositions
            // 
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
            this.groupBoxPositions.Size = new System.Drawing.Size(192, 113);
            this.groupBoxPositions.TabIndex = 4;
            this.groupBoxPositions.TabStop = false;
            this.groupBoxPositions.Text = "Координаты";
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
            // panelIndicator
            // 
            this.panelIndicator.Controls.Add(this.groupBoxLimits);
            this.panelIndicator.Location = new System.Drawing.Point(3, 128);
            this.panelIndicator.Name = "panelIndicator";
            this.panelIndicator.Size = new System.Drawing.Size(198, 94);
            this.panelIndicator.TabIndex = 4;
            // 
            // groupBoxLimits
            // 
            this.groupBoxLimits.Controls.Add(this.labelZmax);
            this.groupBoxLimits.Controls.Add(this.labelZmin);
            this.groupBoxLimits.Controls.Add(this.labelYmax);
            this.groupBoxLimits.Controls.Add(this.labelXmin);
            this.groupBoxLimits.Controls.Add(this.labelYmin);
            this.groupBoxLimits.Controls.Add(this.labelXmax);
            this.groupBoxLimits.Location = new System.Drawing.Point(4, 2);
            this.groupBoxLimits.Name = "groupBoxLimits";
            this.groupBoxLimits.Size = new System.Drawing.Size(192, 88);
            this.groupBoxLimits.TabIndex = 6;
            this.groupBoxLimits.TabStop = false;
            this.groupBoxLimits.Text = "Индикация лимитов";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "draw_ellipse.png");
            this.imageList1.Images.SetKeyName(1, "sport_tennis.png");
            this.imageList1.Images.SetKeyName(2, "stop.png");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelSpeed);
            this.panelControl1.Controls.Add(this.groupBoxManualMove);
            this.panelControl1.Enabled = false;
            this.panelControl1.Location = new System.Drawing.Point(3, 228);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(198, 274);
            this.panelControl1.TabIndex = 0;
            // 
            // labelSpeed
            // 
            this.labelSpeed.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSpeed.ForeColor = System.Drawing.Color.Maroon;
            this.labelSpeed.Location = new System.Drawing.Point(6, 123);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(183, 28);
            this.labelSpeed.TabIndex = 4;
            this.labelSpeed.Text = "---";
            this.labelSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxManualMove
            // 
            this.groupBoxManualMove.Controls.Add(this.label4);
            this.groupBoxManualMove.Controls.Add(this.numericUpDownManualSpeed);
            this.groupBoxManualMove.Controls.Add(this.buttonShowKeyInfo);
            this.groupBoxManualMove.Controls.Add(this.checkBoxManualMove);
            this.groupBoxManualMove.Location = new System.Drawing.Point(2, 6);
            this.groupBoxManualMove.Name = "groupBoxManualMove";
            this.groupBoxManualMove.Size = new System.Drawing.Size(192, 109);
            this.groupBoxManualMove.TabIndex = 0;
            this.groupBoxManualMove.TabStop = false;
            this.groupBoxManualMove.Text = "Ручное управление";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Скорость:";
            // 
            // numericUpDownManualSpeed
            // 
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
            // 
            // groupBoxManualSpeedGkode
            // 
            this.groupBoxManualSpeedGkode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxManualSpeedGkode.Controls.Add(this.checkBox1);
            this.groupBoxManualSpeedGkode.Controls.Add(this.numericUpDown1);
            this.groupBoxManualSpeedGkode.Controls.Add(this.label5);
            this.groupBoxManualSpeedGkode.Controls.Add(this.numericUpDown2);
            this.groupBoxManualSpeedGkode.Controls.Add(this.label6);
            this.groupBoxManualSpeedGkode.Location = new System.Drawing.Point(3, 279);
            this.groupBoxManualSpeedGkode.Name = "groupBoxManualSpeedGkode";
            this.groupBoxManualSpeedGkode.Size = new System.Drawing.Size(203, 113);
            this.groupBoxManualSpeedGkode.TabIndex = 9;
            this.groupBoxManualSpeedGkode.TabStop = false;
            this.groupBoxManualSpeedGkode.Text = "Выполнение G-кода";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(3, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(181, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Ручное управление скоростью";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown1.Location = new System.Drawing.Point(107, 41);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            7500,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(65, 29);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(24, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 30);
            this.label5.TabIndex = 7;
            this.label5.Text = "Скорость подачи:";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown2.Location = new System.Drawing.Point(107, 76);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            7500,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(65, 29);
            this.numericUpDown2.TabIndex = 6;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown2.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(24, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 29);
            this.label6.TabIndex = 8;
            this.label6.Text = "Скорость перемещения:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3D);
            this.tabControl1.Controls.Add(this.tabPageSupp);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(476, 512);
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
            this.tabPage3D.Size = new System.Drawing.Size(468, 486);
            this.tabPage3D.TabIndex = 2;
            this.tabPage3D.Text = "3D";
            this.tabPage3D.UseVisualStyleBackColor = true;
            // 
            // btDefaulPreview
            // 
            this.btDefaulPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDefaulPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDefaulPreview.Location = new System.Drawing.Point(321, 0);
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
            this.lb3DPosView.Size = new System.Drawing.Size(319, 22);
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
            this.menu3Dview.Size = new System.Drawing.Size(463, 37);
            this.menu3Dview.TabIndex = 24;
            this.menu3Dview.Text = "menuStrip1";
            // 
            // menuLabelX
            // 
            this.menuLabelX.Name = "menuLabelX";
            this.menuLabelX.Size = new System.Drawing.Size(89, 30);
            this.menuLabelX.Text = "Вращение: X";
            // 
            // posAngleX
            // 
            this.posAngleX.Name = "posAngleX";
            this.posAngleX.Size = new System.Drawing.Size(23, 30);
            this.posAngleX.Text = "0°";
            this.posAngleX.Click += new System.EventHandler(this.posAngleX_Click);
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
            // posAngleY
            // 
            this.posAngleY.Name = "posAngleY";
            this.posAngleY.Size = new System.Drawing.Size(23, 30);
            this.posAngleY.Text = "0°";
            this.posAngleY.Click += new System.EventHandler(this.posAngleY_Click);
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
            // posAngleZ
            // 
            this.posAngleZ.Name = "posAngleZ";
            this.posAngleZ.Size = new System.Drawing.Size(23, 30);
            this.posAngleZ.Text = "0°";
            this.posAngleZ.Click += new System.EventHandler(this.posAngleZ_Click);
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
            this.OpenGL_preview.Size = new System.Drawing.Size(463, 415);
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
            this.tabPageSupp.Controls.Add(this.trackBar1);
            this.tabPageSupp.Controls.Add(this.groupBox9);
            this.tabPageSupp.Controls.Add(this.groupBox7);
            this.tabPageSupp.Controls.Add(this.groupBox6);
            this.tabPageSupp.Controls.Add(this.groupBox5);
            this.tabPageSupp.Controls.Add(this.groupBox3);
            this.tabPageSupp.Controls.Add(this.button1);
            this.tabPageSupp.Controls.Add(this.listBoxLog);
            this.tabPageSupp.Location = new System.Drawing.Point(4, 22);
            this.tabPageSupp.Name = "tabPageSupp";
            this.tabPageSupp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSupp.Size = new System.Drawing.Size(468, 486);
            this.tabPageSupp.TabIndex = 1;
            this.tabPageSupp.Text = "Дополнительно";
            this.tabPageSupp.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(6, 435);
            this.trackBar1.Maximum = 65535;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(445, 45);
            this.trackBar1.SmallChange = 50;
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.radioButton_RC);
            this.groupBox9.Controls.Add(this.radioButton_Hz);
            this.groupBox9.Controls.Add(this.radioButton_off);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Controls.Add(this.button2);
            this.groupBox9.Controls.Add(this.numericUpDown8);
            this.groupBox9.Controls.Add(this.numericUpDown7);
            this.groupBox9.Controls.Add(this.checkBox18);
            this.groupBox9.Location = new System.Drawing.Point(6, 318);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(456, 115);
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
            this.label12.Location = new System.Drawing.Point(289, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Скорость ШИМ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(128, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "№ канала для ШИМ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(131, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(209, 46);
            this.button2.TabIndex = 4;
            this.button2.Text = "Послать команду";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.Location = new System.Drawing.Point(256, 32);
            this.numericUpDown8.Maximum = new decimal(new int[] {
            330000,
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
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.Location = new System.Drawing.Point(137, 32);
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
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkBox10);
            this.groupBox7.Controls.Add(this.checkBox11);
            this.groupBox7.Controls.Add(this.checkBox12);
            this.groupBox7.Controls.Add(this.checkBox13);
            this.groupBox7.Controls.Add(this.checkBox14);
            this.groupBox7.Controls.Add(this.checkBox15);
            this.groupBox7.Controls.Add(this.checkBox16);
            this.groupBox7.Controls.Add(this.checkBox17);
            this.groupBox7.Location = new System.Drawing.Point(220, 263);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(181, 52);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Байт 19 (E-sop)";
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Enabled = false;
            this.checkBox10.Location = new System.Drawing.Point(153, 26);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(15, 14);
            this.checkBox10.TabIndex = 12;
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Enabled = false;
            this.checkBox11.Location = new System.Drawing.Point(132, 26);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(15, 14);
            this.checkBox11.TabIndex = 11;
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Enabled = false;
            this.checkBox12.Location = new System.Drawing.Point(111, 26);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(15, 14);
            this.checkBox12.TabIndex = 10;
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Enabled = false;
            this.checkBox13.Location = new System.Drawing.Point(90, 26);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(15, 14);
            this.checkBox13.TabIndex = 9;
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Enabled = false;
            this.checkBox14.Location = new System.Drawing.Point(69, 26);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(15, 14);
            this.checkBox14.TabIndex = 8;
            this.checkBox14.UseVisualStyleBackColor = true;
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Enabled = false;
            this.checkBox15.Location = new System.Drawing.Point(48, 26);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(15, 14);
            this.checkBox15.TabIndex = 7;
            this.checkBox15.UseVisualStyleBackColor = true;
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Enabled = false;
            this.checkBox16.Location = new System.Drawing.Point(27, 26);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(15, 14);
            this.checkBox16.TabIndex = 6;
            this.checkBox16.UseVisualStyleBackColor = true;
            // 
            // checkBox17
            // 
            this.checkBox17.AutoSize = true;
            this.checkBox17.Enabled = false;
            this.checkBox17.Location = new System.Drawing.Point(6, 26);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(15, 14);
            this.checkBox17.TabIndex = 5;
            this.checkBox17.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkBox2);
            this.groupBox6.Controls.Add(this.checkBox3);
            this.groupBox6.Controls.Add(this.checkBox4);
            this.groupBox6.Controls.Add(this.checkBox5);
            this.groupBox6.Controls.Add(this.checkBox6);
            this.groupBox6.Controls.Add(this.checkBox7);
            this.groupBox6.Controls.Add(this.checkBox8);
            this.groupBox6.Controls.Add(this.checkBox9);
            this.groupBox6.Location = new System.Drawing.Point(220, 205);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(181, 52);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Байт 15 (лимиты осей)";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(153, 26);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(132, 26);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(111, 26);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 10;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Enabled = false;
            this.checkBox5.Location = new System.Drawing.Point(90, 26);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 9;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Enabled = false;
            this.checkBox6.Location = new System.Drawing.Point(69, 26);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 8;
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Enabled = false;
            this.checkBox7.Location = new System.Drawing.Point(48, 26);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(15, 14);
            this.checkBox7.TabIndex = 7;
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Enabled = false;
            this.checkBox8.Location = new System.Drawing.Point(27, 26);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(15, 14);
            this.checkBox8.TabIndex = 6;
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Enabled = false;
            this.checkBox9.Location = new System.Drawing.Point(6, 26);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(15, 14);
            this.checkBox9.TabIndex = 5;
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBoxB0);
            this.groupBox5.Controls.Add(this.checkBoxB1);
            this.groupBox5.Controls.Add(this.checkBoxB2);
            this.groupBox5.Controls.Add(this.checkBoxB3);
            this.groupBox5.Controls.Add(this.checkBoxB4);
            this.groupBox5.Controls.Add(this.checkBoxB5);
            this.groupBox5.Controls.Add(this.checkBoxB6);
            this.groupBox5.Controls.Add(this.checkBoxB7);
            this.groupBox5.Location = new System.Drawing.Point(220, 147);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(181, 52);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Байт 14 (включ. шпиндель сож)";
            // 
            // checkBoxB0
            // 
            this.checkBoxB0.AutoSize = true;
            this.checkBoxB0.Enabled = false;
            this.checkBoxB0.Location = new System.Drawing.Point(153, 26);
            this.checkBoxB0.Name = "checkBoxB0";
            this.checkBoxB0.Size = new System.Drawing.Size(15, 14);
            this.checkBoxB0.TabIndex = 12;
            this.checkBoxB0.UseVisualStyleBackColor = true;
            // 
            // checkBoxB1
            // 
            this.checkBoxB1.AutoSize = true;
            this.checkBoxB1.Enabled = false;
            this.checkBoxB1.Location = new System.Drawing.Point(132, 26);
            this.checkBoxB1.Name = "checkBoxB1";
            this.checkBoxB1.Size = new System.Drawing.Size(15, 14);
            this.checkBoxB1.TabIndex = 11;
            this.checkBoxB1.UseVisualStyleBackColor = true;
            // 
            // checkBoxB2
            // 
            this.checkBoxB2.AutoSize = true;
            this.checkBoxB2.Enabled = false;
            this.checkBoxB2.Location = new System.Drawing.Point(111, 26);
            this.checkBoxB2.Name = "checkBoxB2";
            this.checkBoxB2.Size = new System.Drawing.Size(15, 14);
            this.checkBoxB2.TabIndex = 10;
            this.checkBoxB2.UseVisualStyleBackColor = true;
            // 
            // checkBoxB3
            // 
            this.checkBoxB3.AutoSize = true;
            this.checkBoxB3.Enabled = false;
            this.checkBoxB3.Location = new System.Drawing.Point(90, 26);
            this.checkBoxB3.Name = "checkBoxB3";
            this.checkBoxB3.Size = new System.Drawing.Size(15, 14);
            this.checkBoxB3.TabIndex = 9;
            this.checkBoxB3.UseVisualStyleBackColor = true;
            // 
            // checkBoxB4
            // 
            this.checkBoxB4.AutoSize = true;
            this.checkBoxB4.Enabled = false;
            this.checkBoxB4.Location = new System.Drawing.Point(69, 26);
            this.checkBoxB4.Name = "checkBoxB4";
            this.checkBoxB4.Size = new System.Drawing.Size(15, 14);
            this.checkBoxB4.TabIndex = 8;
            this.checkBoxB4.UseVisualStyleBackColor = true;
            // 
            // checkBoxB5
            // 
            this.checkBoxB5.AutoSize = true;
            this.checkBoxB5.Enabled = false;
            this.checkBoxB5.Location = new System.Drawing.Point(48, 26);
            this.checkBoxB5.Name = "checkBoxB5";
            this.checkBoxB5.Size = new System.Drawing.Size(15, 14);
            this.checkBoxB5.TabIndex = 7;
            this.checkBoxB5.UseVisualStyleBackColor = true;
            // 
            // checkBoxB6
            // 
            this.checkBoxB6.AutoSize = true;
            this.checkBoxB6.Enabled = false;
            this.checkBoxB6.Location = new System.Drawing.Point(27, 26);
            this.checkBoxB6.Name = "checkBoxB6";
            this.checkBoxB6.Size = new System.Drawing.Size(15, 14);
            this.checkBoxB6.TabIndex = 6;
            this.checkBoxB6.UseVisualStyleBackColor = true;
            // 
            // checkBoxB7
            // 
            this.checkBoxB7.AutoSize = true;
            this.checkBoxB7.Enabled = false;
            this.checkBoxB7.Location = new System.Drawing.Point(6, 26);
            this.checkBoxB7.Name = "checkBoxB7";
            this.checkBoxB7.Size = new System.Drawing.Size(15, 14);
            this.checkBoxB7.TabIndex = 5;
            this.checkBoxB7.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.numericUpDown4);
            this.groupBox3.Controls.Add(this.numericUpDown5);
            this.groupBox3.Controls.Add(this.numericUpDown6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numericUpDown3);
            this.groupBox3.Location = new System.Drawing.Point(6, 142);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 148);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "движение в точку";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 76);
            this.button3.TabIndex = 13;
            this.button3.Text = "RUN";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(73, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Z";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(72, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(72, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "X";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.DecimalPlaces = 3;
            this.numericUpDown4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown4.Location = new System.Drawing.Point(99, 71);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(83, 29);
            this.numericUpDown4.TabIndex = 9;
            this.numericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.DecimalPlaces = 3;
            this.numericUpDown5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown5.Location = new System.Drawing.Point(99, 41);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown5.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(83, 29);
            this.numericUpDown5.TabIndex = 8;
            this.numericUpDown5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.DecimalPlaces = 3;
            this.numericUpDown6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown6.Location = new System.Drawing.Point(99, 15);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown6.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(83, 29);
            this.numericUpDown6.TabIndex = 7;
            this.numericUpDown6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(10, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 24);
            this.label7.TabIndex = 5;
            this.label7.Text = "Скорость:";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown3.Location = new System.Drawing.Point(117, 106);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            7500,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(65, 29);
            this.numericUpDown3.TabIndex = 6;
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown3.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
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
            this.listBoxLog.Size = new System.Drawing.Size(459, 108);
            this.listBoxLog.TabIndex = 0;
            // 
            // groupBoxWorking
            // 
            this.groupBoxWorking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWorking.Controls.Add(this.textBoxNumberLine);
            this.groupBoxWorking.Controls.Add(this.buttonPauseTask);
            this.groupBoxWorking.Controls.Add(this.labelWorkingRow);
            this.groupBoxWorking.Controls.Add(this.btStopTask);
            this.groupBoxWorking.Controls.Add(this.buttonStartTask);
            this.groupBoxWorking.Location = new System.Drawing.Point(3, 395);
            this.groupBoxWorking.Name = "groupBoxWorking";
            this.groupBoxWorking.Size = new System.Drawing.Size(203, 111);
            this.groupBoxWorking.TabIndex = 1;
            this.groupBoxWorking.TabStop = false;
            this.groupBoxWorking.Text = "Выполнение программы";
            // 
            // textBoxNumberLine
            // 
            this.textBoxNumberLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNumberLine.Location = new System.Drawing.Point(51, 17);
            this.textBoxNumberLine.Name = "textBoxNumberLine";
            this.textBoxNumberLine.ReadOnly = true;
            this.textBoxNumberLine.Size = new System.Drawing.Size(146, 31);
            this.textBoxNumberLine.TabIndex = 11;
            this.textBoxNumberLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelWorkingRow
            // 
            this.labelWorkingRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWorkingRow.Location = new System.Drawing.Point(3, 20);
            this.labelWorkingRow.Name = "labelWorkingRow";
            this.labelWorkingRow.Size = new System.Drawing.Size(42, 31);
            this.labelWorkingRow.TabIndex = 9;
            this.labelWorkingRow.Text = "С №:";
            this.labelWorkingRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerKeyHook
            // 
            this.timerKeyHook.Enabled = true;
            this.timerKeyHook.Interval = 10;
            this.timerKeyHook.Tick += new System.EventHandler(this.timerKeyHooks_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // RenderTimer
            // 
            this.RenderTimer.Enabled = true;
            this.RenderTimer.Interval = 30;
            this.RenderTimer.Tick += new System.EventHandler(this.RenderTimer_Tick);
            // 
            // TaskTimer
            // 
            this.TaskTimer.Enabled = true;
            this.TaskTimer.Interval = 1;
            this.TaskTimer.Tick += new System.EventHandler(this.TaskTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listGkodeCommand);
            this.groupBox1.Controls.Add(this.groupBoxManualSpeedGkode);
            this.groupBox1.Controls.Add(this.groupBoxWorking);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 512);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "G-код";
            // 
            // listGkodeCommand
            // 
            this.listGkodeCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listGkodeCommand.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listGkodeCommand.ForeColor = System.Drawing.Color.MidnightBlue;
            this.listGkodeCommand.FormattingEnabled = true;
            this.listGkodeCommand.ItemHeight = 19;
            this.listGkodeCommand.Location = new System.Drawing.Point(6, 20);
            this.listGkodeCommand.Name = "listGkodeCommand";
            this.listGkodeCommand.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listGkodeCommand.Size = new System.Drawing.Size(194, 251);
            this.listGkodeCommand.TabIndex = 10;
            this.listGkodeCommand.Click += new System.EventHandler(this.listBox1_Click);
            this.listGkodeCommand.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listGkodeCommand.DataSourceChanged += new System.EventHandler(this.listBox1_DataSourceChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(210, 66);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(692, 512);
            this.splitContainer1.SplitterDistance = 476;
            this.splitContainer1.TabIndex = 6;
            // 
            // posAngleXm
            // 
            this.posAngleXm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.posAngleXm.ForeColor = System.Drawing.Color.Yellow;
            this.posAngleXm.Image = global::CNC_Controller.Properties.Resources.undo;
            this.posAngleXm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.posAngleXm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.posAngleXm.Name = "posAngleXm";
            this.posAngleXm.Size = new System.Drawing.Size(36, 30);
            this.posAngleXm.Click += new System.EventHandler(this.posAngleXm_Click);
            // 
            // posAngleXp
            // 
            this.posAngleXp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.posAngleXp.ForeColor = System.Drawing.Color.Yellow;
            this.posAngleXp.Image = global::CNC_Controller.Properties.Resources.redo;
            this.posAngleXp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.posAngleXp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.posAngleXp.Name = "posAngleXp";
            this.posAngleXp.Size = new System.Drawing.Size(36, 30);
            this.posAngleXp.Click += new System.EventHandler(this.posAngleXp_Click);
            // 
            // posAngleYp
            // 
            this.posAngleYp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.posAngleYp.ForeColor = System.Drawing.Color.Yellow;
            this.posAngleYp.Image = global::CNC_Controller.Properties.Resources.undo;
            this.posAngleYp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.posAngleYp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.posAngleYp.Name = "posAngleYp";
            this.posAngleYp.Size = new System.Drawing.Size(36, 30);
            this.posAngleYp.Click += new System.EventHandler(this.posAngleYp_Click);
            // 
            // posAngleYm
            // 
            this.posAngleYm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.posAngleYm.ForeColor = System.Drawing.Color.Yellow;
            this.posAngleYm.Image = global::CNC_Controller.Properties.Resources.redo;
            this.posAngleYm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.posAngleYm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.posAngleYm.Name = "posAngleYm";
            this.posAngleYm.Size = new System.Drawing.Size(36, 30);
            this.posAngleYm.Click += new System.EventHandler(this.posAngleYm_Click);
            // 
            // posAngleZp
            // 
            this.posAngleZp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.posAngleZp.Image = global::CNC_Controller.Properties.Resources.undo;
            this.posAngleZp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.posAngleZp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.posAngleZp.Name = "posAngleZp";
            this.posAngleZp.Size = new System.Drawing.Size(36, 30);
            this.posAngleZp.Click += new System.EventHandler(this.posAngleZp_Click);
            // 
            // posAngleZm
            // 
            this.posAngleZm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.posAngleZm.Image = global::CNC_Controller.Properties.Resources.redo;
            this.posAngleZm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.posAngleZm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.posAngleZm.Name = "posAngleZm";
            this.posAngleZm.Size = new System.Drawing.Size(36, 30);
            this.posAngleZm.Click += new System.EventHandler(this.posAngleZm_Click);
            // 
            // buttonPauseTask
            // 
            this.buttonPauseTask.Image = global::CNC_Controller.Properties.Resources.control_pause_blue;
            this.buttonPauseTask.Location = new System.Drawing.Point(78, 58);
            this.buttonPauseTask.Name = "buttonPauseTask";
            this.buttonPauseTask.Size = new System.Drawing.Size(50, 46);
            this.buttonPauseTask.TabIndex = 10;
            this.buttonPauseTask.UseVisualStyleBackColor = true;
            this.buttonPauseTask.Click += new System.EventHandler(this.buttonPauseTask_Click);
            // 
            // btStopTask
            // 
            this.btStopTask.Image = global::CNC_Controller.Properties.Resources.control_stop_blue;
            this.btStopTask.Location = new System.Drawing.Point(134, 58);
            this.btStopTask.Name = "btStopTask";
            this.btStopTask.Size = new System.Drawing.Size(50, 46);
            this.btStopTask.TabIndex = 1;
            this.btStopTask.UseVisualStyleBackColor = true;
            this.btStopTask.Click += new System.EventHandler(this.btStopTask_Click);
            // 
            // buttonStartTask
            // 
            this.buttonStartTask.Image = global::CNC_Controller.Properties.Resources.control_play_blue;
            this.buttonStartTask.Location = new System.Drawing.Point(22, 58);
            this.buttonStartTask.Name = "buttonStartTask";
            this.buttonStartTask.Size = new System.Drawing.Size(50, 46);
            this.buttonStartTask.TabIndex = 0;
            this.buttonStartTask.UseVisualStyleBackColor = true;
            this.buttonStartTask.Click += new System.EventHandler(this.buttonStartTask_Click);
            // 
            // buttonZtoZero
            // 
            this.buttonZtoZero.Enabled = false;
            this.buttonZtoZero.Image = global::CNC_Controller.Properties.Resources.digit_separator;
            this.buttonZtoZero.Location = new System.Drawing.Point(1, 81);
            this.buttonZtoZero.Name = "buttonZtoZero";
            this.buttonZtoZero.Size = new System.Drawing.Size(26, 28);
            this.buttonZtoZero.TabIndex = 12;
            this.buttonZtoZero.UseVisualStyleBackColor = true;
            this.buttonZtoZero.Click += new System.EventHandler(this.buttonZtoZero_Click);
            // 
            // buttonYtoZero
            // 
            this.buttonYtoZero.Enabled = false;
            this.buttonYtoZero.Image = global::CNC_Controller.Properties.Resources.digit_separator;
            this.buttonYtoZero.Location = new System.Drawing.Point(1, 47);
            this.buttonYtoZero.Name = "buttonYtoZero";
            this.buttonYtoZero.Size = new System.Drawing.Size(26, 28);
            this.buttonYtoZero.TabIndex = 11;
            this.buttonYtoZero.UseVisualStyleBackColor = true;
            this.buttonYtoZero.Click += new System.EventHandler(this.buttonYtoZero_Click);
            // 
            // buttonXtoZero
            // 
            this.buttonXtoZero.Enabled = false;
            this.buttonXtoZero.Image = global::CNC_Controller.Properties.Resources.digit_separator;
            this.buttonXtoZero.Location = new System.Drawing.Point(1, 14);
            this.buttonXtoZero.Name = "buttonXtoZero";
            this.buttonXtoZero.Size = new System.Drawing.Size(26, 28);
            this.buttonXtoZero.TabIndex = 10;
            this.buttonXtoZero.UseVisualStyleBackColor = true;
            this.buttonXtoZero.Click += new System.EventHandler(this.buttonXtoZero_Click);
            // 
            // labelZmax
            // 
            this.labelZmax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelZmax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelZmax.ImageIndex = 0;
            this.labelZmax.ImageList = this.imageList1;
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
            this.labelZmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelZmin.ImageIndex = 0;
            this.labelZmin.ImageList = this.imageList1;
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
            this.labelYmax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelYmax.ImageIndex = 0;
            this.labelYmax.ImageList = this.imageList1;
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
            this.labelXmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelXmin.ImageIndex = 0;
            this.labelXmin.ImageList = this.imageList1;
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
            this.labelYmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelYmin.ImageIndex = 0;
            this.labelYmin.ImageList = this.imageList1;
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
            this.labelXmax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelXmax.ImageIndex = 0;
            this.labelXmax.ImageList = this.imageList1;
            this.labelXmax.Location = new System.Drawing.Point(92, 16);
            this.labelXmax.Name = "labelXmax";
            this.labelXmax.Size = new System.Drawing.Size(92, 23);
            this.labelXmax.TabIndex = 6;
            this.labelXmax.Text = "       Xмакс";
            this.labelXmax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_ConnDiskonect
            // 
            this.bt_ConnDiskonect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bt_ConnDiskonect.Image = global::CNC_Controller.Properties.Resources.disconnect;
            this.bt_ConnDiskonect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bt_ConnDiskonect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt_ConnDiskonect.Name = "bt_ConnDiskonect";
            this.bt_ConnDiskonect.Size = new System.Drawing.Size(36, 36);
            this.bt_ConnDiskonect.Text = "Подключиться к контроллеру";
            this.bt_ConnDiskonect.Click += new System.EventHandler(this.bt_ConnDiskonect_Click);
            // 
            // btOpenFile
            // 
            this.btOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btOpenFile.Image = global::CNC_Controller.Properties.Resources.open_folder;
            this.btOpenFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(36, 36);
            this.btOpenFile.Text = "Открыть файл";
            this.btOpenFile.Click += new System.EventHandler(this.btOpenFile_Click);
            // 
            // bt_exit2
            // 
            this.bt_exit2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bt_exit2.Image = global::CNC_Controller.Properties.Resources.door_in;
            this.bt_exit2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bt_exit2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt_exit2.Name = "bt_exit2";
            this.bt_exit2.Size = new System.Drawing.Size(36, 36);
            this.bt_exit2.Text = "toolStripButton2";
            this.bt_exit2.Click += new System.EventHandler(this.bt_exit2_Click);
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
            this.buttonSpindel.Click += new System.EventHandler(this.buttonSpindel_Click_1);
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
            // toolStripDropDownadditionally
            // 
            this.toolStripDropDownadditionally.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingControllerToolStripMenuItem,
            this.additionallyToolStripMenuItem,
            this.scansurfaceToolStripMenuItem,
            this.generatorCodeToolStripMenuItem});
            this.toolStripDropDownadditionally.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownadditionally.Image")));
            this.toolStripDropDownadditionally.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownadditionally.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownadditionally.Name = "toolStripDropDownadditionally";
            this.toolStripDropDownadditionally.Size = new System.Drawing.Size(140, 36);
            this.toolStripDropDownadditionally.Text = "Дополнительно";
            // 
            // settingControllerToolStripMenuItem
            // 
            this.settingControllerToolStripMenuItem.Image = global::CNC_Controller.Properties.Resources.pci;
            this.settingControllerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingControllerToolStripMenuItem.Name = "settingControllerToolStripMenuItem";
            this.settingControllerToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.settingControllerToolStripMenuItem.Text = "Настройка контроллера";
            this.settingControllerToolStripMenuItem.Click += new System.EventHandler(this.settingControllerToolStripMenuItem_Click);
            // 
            // additionallyToolStripMenuItem
            // 
            this.additionallyToolStripMenuItem.Image = global::CNC_Controller.Properties.Resources.google_webmaster_tools;
            this.additionallyToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.additionallyToolStripMenuItem.Name = "additionallyToolStripMenuItem";
            this.additionallyToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.additionallyToolStripMenuItem.Text = "Настройка 3D отображения";
            this.additionallyToolStripMenuItem.Click += new System.EventHandler(this.additionallyToolStripMenuItem_Click);
            // 
            // scansurfaceToolStripMenuItem
            // 
            this.scansurfaceToolStripMenuItem.Image = global::CNC_Controller.Properties.Resources.layer_grid;
            this.scansurfaceToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scansurfaceToolStripMenuItem.Name = "scansurfaceToolStripMenuItem";
            this.scansurfaceToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.scansurfaceToolStripMenuItem.Text = "Сканирование поверхности";
            this.scansurfaceToolStripMenuItem.Click += new System.EventHandler(this.scansurfaceToolStripMenuItem_Click);
            // 
            // generatorCodeToolStripMenuItem
            // 
            this.generatorCodeToolStripMenuItem.Image = global::CNC_Controller.Properties.Resources.draw_vertex;
            this.generatorCodeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.generatorCodeToolStripMenuItem.Name = "generatorCodeToolStripMenuItem";
            this.generatorCodeToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.generatorCodeToolStripMenuItem.Text = "Модуль генерации кода";
            this.generatorCodeToolStripMenuItem.Click += new System.EventHandler(this.generatorCodeToolStripMenuItem_Click);
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
            // toolStripButtonLikePoint
            // 
            this.toolStripButtonLikePoint.Enabled = false;
            this.toolStripButtonLikePoint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLikePoint.Image")));
            this.toolStripButtonLikePoint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonLikePoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLikePoint.Name = "toolStripButtonLikePoint";
            this.toolStripButtonLikePoint.Size = new System.Drawing.Size(113, 36);
            this.toolStripButtonLikePoint.Text = "Набор точек";
            this.toolStripButtonLikePoint.Visible = false;
            this.toolStripButtonLikePoint.Click += new System.EventHandler(this.toolStripButtonLikePoint_Click);
            // 
            // menuOpenFile
            // 
            this.menuOpenFile.Image = global::CNC_Controller.Properties.Resources.open_folder;
            this.menuOpenFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuOpenFile.Name = "menuOpenFile";
            this.menuOpenFile.Size = new System.Drawing.Size(203, 38);
            this.menuOpenFile.Text = "Открыть файл";
            this.menuOpenFile.Click += new System.EventHandler(this.menuOpenFile_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Image = global::CNC_Controller.Properties.Resources.door_in;
            this.bt_exit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(203, 38);
            this.bt_exit.Text = "Завершение работы";
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // btConnect
            // 
            this.btConnect.Image = global::CNC_Controller.Properties.Resources.connect;
            this.btConnect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(225, 38);
            this.btConnect.Text = "Подключиться";
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // bt_disconnect
            // 
            this.bt_disconnect.Image = global::CNC_Controller.Properties.Resources.disconnect;
            this.bt_disconnect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bt_disconnect.Name = "bt_disconnect";
            this.bt_disconnect.Size = new System.Drawing.Size(225, 38);
            this.bt_disconnect.Text = "Отключиться";
            this.bt_disconnect.Click += new System.EventHandler(this.bt_disconnect_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Image = global::CNC_Controller.Properties.Resources.pci;
            this.settingToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(225, 38);
            this.settingToolStripMenuItem.Text = "Настройки контроллера";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::CNC_Controller.Properties.Resources.contact_email;
            this.aboutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(165, 38);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 603);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.MainToolStrip);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Управленец ЧПУ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelPosition.ResumeLayout(false);
            this.groupBoxPositions.ResumeLayout(false);
            this.groupBoxPositions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).EndInit();
            this.panelIndicator.ResumeLayout(false);
            this.groupBoxLimits.ResumeLayout(false);
            this.panelControl1.ResumeLayout(false);
            this.groupBoxManualMove.ResumeLayout(false);
            this.groupBoxManualMove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownManualSpeed)).EndInit();
            this.groupBoxManualSpeedGkode.ResumeLayout(false);
            this.groupBoxManualSpeedGkode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3D.ResumeLayout(false);
            this.menu3Dview.ResumeLayout(false);
            this.menu3Dview.PerformLayout();
            this.tabPageSupp.ResumeLayout(false);
            this.tabPageSupp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.groupBoxWorking.ResumeLayout(false);
            this.groupBoxWorking.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStrip MainToolStrip;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.Windows.Forms.ToolStripButton bt_ConnDiskonect;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btConnect;
        private System.Windows.Forms.ToolStripMenuItem bt_disconnect;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuOpenFile;
        private System.Windows.Forms.ToolStripMenuItem bt_exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bt_exit2;
        private System.Windows.Forms.ToolStripButton btOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelPosition;
        private System.Windows.Forms.GroupBox groupBoxPositions;
        private System.Windows.Forms.NumericUpDown numPosZ;
        private System.Windows.Forms.NumericUpDown numPosY;
        private System.Windows.Forms.NumericUpDown numPosX;
        private System.Windows.Forms.Label labelposZ;
        private System.Windows.Forms.Label labelposY;
        private System.Windows.Forms.Label labelposX;
        private System.Windows.Forms.Panel panelIndicator;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBoxLimits;
        private System.Windows.Forms.Label labelZmax;
        private System.Windows.Forms.Label labelZmin;
        private System.Windows.Forms.Label labelYmax;
        private System.Windows.Forms.Label labelXmin;
        private System.Windows.Forms.Label labelYmin;
        private System.Windows.Forms.Label labelXmax;
        private System.Windows.Forms.Panel panelControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBoxManualMove;
        private System.Windows.Forms.Button buttonShowKeyInfo;
        private System.Windows.Forms.CheckBox checkBoxManualMove;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownManualSpeed;
        private System.Windows.Forms.Timer timerKeyHook;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.GroupBox groupBoxWorking;
        private System.Windows.Forms.Button btStopTask;
        private System.Windows.Forms.Button buttonStartTask;
        private System.Windows.Forms.Label labelWorkingRow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button buttonXtoZero;
        private System.Windows.Forms.Button buttonZtoZero;
        private System.Windows.Forms.Button buttonYtoZero;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageSupp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton buttonSpindel;
        private System.Windows.Forms.ToolStripButton buttonESTOP;
        private System.Windows.Forms.Button buttonPauseTask;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.TextBox textBoxNumberLine;
        private System.Windows.Forms.Timer TaskTimer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNumberInstruction;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBoxB0;
        private System.Windows.Forms.CheckBox checkBoxB1;
        private System.Windows.Forms.CheckBox checkBoxB2;
        private System.Windows.Forms.CheckBox checkBoxB3;
        private System.Windows.Forms.CheckBox checkBoxB4;
        private System.Windows.Forms.CheckBox checkBoxB5;
        private System.Windows.Forms.CheckBox checkBoxB6;
        private System.Windows.Forms.CheckBox checkBoxB7;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox17;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.GroupBox groupBoxManualSpeedGkode;
        private System.Windows.Forms.CheckBox checkBox1;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownadditionally;
        private System.Windows.Forms.ToolStripMenuItem additionallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scansurfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditData;
        private System.Windows.Forms.ToolStripButton toolStripButtonLikePoint;
        private System.Windows.Forms.ListBox listGkodeCommand;
        private System.Windows.Forms.ToolStripMenuItem generatorCodeToolStripMenuItem;
    }
}

