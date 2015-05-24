namespace CNC_Controller.ConstructorGkode
{
    partial class frmRotate
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
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btGetPosition = new System.Windows.Forms.Button();
            this.labelposX = new System.Windows.Forms.Label();
            this.numPosZ = new System.Windows.Forms.NumericUpDown();
            this.labelposY = new System.Windows.Forms.Label();
            this.numPosY = new System.Windows.Forms.NumericUpDown();
            this.labelposZ = new System.Windows.Forms.Label();
            this.numPosX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericStart = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericStop = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericStep = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericRadius = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown10 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRadius)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Image = global::CNC_Controller.Properties.Resources.cancel2;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(150, 633);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 57);
            this.button3.TabIndex = 42;
            this.button3.Text = "Отмена";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Image = global::CNC_Controller.Properties.Resources.accept_button2;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(5, 633);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 57);
            this.button1.TabIndex = 41;
            this.button1.Text = "Применить";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btGetPosition
            // 
            this.btGetPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btGetPosition.Image = global::CNC_Controller.Properties.Resources.geolocation_sight;
            this.btGetPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGetPosition.Location = new System.Drawing.Point(115, 55);
            this.btGetPosition.Name = "btGetPosition";
            this.btGetPosition.Size = new System.Drawing.Size(144, 68);
            this.btGetPosition.TabIndex = 40;
            this.btGetPosition.Text = "Использовать текущее положение";
            this.btGetPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGetPosition.UseVisualStyleBackColor = true;
            this.btGetPosition.Click += new System.EventHandler(this.btGetPosition_Click);
            // 
            // labelposX
            // 
            this.labelposX.AutoSize = true;
            this.labelposX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposX.Location = new System.Drawing.Point(9, 59);
            this.labelposX.Name = "labelposX";
            this.labelposX.Size = new System.Drawing.Size(16, 16);
            this.labelposX.TabIndex = 34;
            this.labelposX.Text = "X";
            // 
            // numPosZ
            // 
            this.numPosZ.DecimalPlaces = 3;
            this.numPosZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosZ.Location = new System.Drawing.Point(36, 101);
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
            this.numPosZ.Size = new System.Drawing.Size(73, 22);
            this.numPosZ.TabIndex = 39;
            this.numPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPosZ.ValueChanged += new System.EventHandler(this.numPosZ_ValueChanged);
            // 
            // labelposY
            // 
            this.labelposY.AutoSize = true;
            this.labelposY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposY.Location = new System.Drawing.Point(9, 82);
            this.labelposY.Name = "labelposY";
            this.labelposY.Size = new System.Drawing.Size(17, 16);
            this.labelposY.TabIndex = 35;
            this.labelposY.Text = "Y";
            // 
            // numPosY
            // 
            this.numPosY.DecimalPlaces = 3;
            this.numPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosY.Location = new System.Drawing.Point(36, 78);
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
            this.numPosY.Size = new System.Drawing.Size(73, 22);
            this.numPosY.TabIndex = 38;
            this.numPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPosY.ValueChanged += new System.EventHandler(this.numPosY_ValueChanged);
            // 
            // labelposZ
            // 
            this.labelposZ.AutoSize = true;
            this.labelposZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelposZ.Location = new System.Drawing.Point(10, 104);
            this.labelposZ.Name = "labelposZ";
            this.labelposZ.Size = new System.Drawing.Size(16, 16);
            this.labelposZ.TabIndex = 36;
            this.labelposZ.Text = "Z";
            // 
            // numPosX
            // 
            this.numPosX.DecimalPlaces = 3;
            this.numPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPosX.Location = new System.Drawing.Point(36, 55);
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
            this.numPosX.Size = new System.Drawing.Size(73, 22);
            this.numPosX.TabIndex = 37;
            this.numPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPosX.ValueChanged += new System.EventHandler(this.numPosX_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 18);
            this.label1.TabIndex = 43;
            this.label1.Text = "Центр вращения";
            // 
            // numericStart
            // 
            this.numericStart.DecimalPlaces = 3;
            this.numericStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericStart.Location = new System.Drawing.Point(186, 165);
            this.numericStart.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericStart.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericStart.Name = "numericStart";
            this.numericStart.Size = new System.Drawing.Size(73, 22);
            this.numericStart.TabIndex = 45;
            this.numericStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericStart.ValueChanged += new System.EventHandler(this.numericStart_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(65, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 44;
            this.label2.Text = "Начальный угол:";
            // 
            // numericStop
            // 
            this.numericStop.DecimalPlaces = 3;
            this.numericStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericStop.Location = new System.Drawing.Point(186, 189);
            this.numericStop.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericStop.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericStop.Name = "numericStop";
            this.numericStop.Size = new System.Drawing.Size(73, 22);
            this.numericStop.TabIndex = 47;
            this.numericStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericStop.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericStop.ValueChanged += new System.EventHandler(this.numericStop_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(74, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 46;
            this.label3.Text = "Конечный угол:";
            // 
            // numericStep
            // 
            this.numericStep.DecimalPlaces = 3;
            this.numericStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericStep.Location = new System.Drawing.Point(186, 213);
            this.numericStep.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericStep.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericStep.Name = "numericStep";
            this.numericStep.Size = new System.Drawing.Size(73, 22);
            this.numericStep.TabIndex = 49;
            this.numericStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericStep.ValueChanged += new System.EventHandler(this.numericStep_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(25, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 16);
            this.label4.TabIndex = 48;
            this.label4.Text = "Шаг поворота (градус):";
            // 
            // numericRadius
            // 
            this.numericRadius.DecimalPlaces = 3;
            this.numericRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericRadius.Location = new System.Drawing.Point(186, 141);
            this.numericRadius.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericRadius.Name = "numericRadius";
            this.numericRadius.Size = new System.Drawing.Size(73, 22);
            this.numericRadius.TabIndex = 51;
            this.numericRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericRadius.ValueChanged += new System.EventHandler(this.numericRadius_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(124, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 50;
            this.label5.Text = "Радиус:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown8);
            this.groupBox1.Controls.Add(this.numericUpDown9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numericUpDown10);
            this.groupBox1.Controls.Add(this.numericUpDown7);
            this.groupBox1.Controls.Add(this.numericUpDown5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numericUpDown6);
            this.groupBox1.Location = new System.Drawing.Point(15, 520);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 107);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Координаты начала, и окончания дуги:";
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.DecimalPlaces = 3;
            this.numericUpDown8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown8.Location = new System.Drawing.Point(117, 25);
            this.numericUpDown8.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown8.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.ReadOnly = true;
            this.numericUpDown8.Size = new System.Drawing.Size(73, 22);
            this.numericUpDown8.TabIndex = 59;
            this.numericUpDown8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDown9
            // 
            this.numericUpDown9.DecimalPlaces = 3;
            this.numericUpDown9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown9.Location = new System.Drawing.Point(117, 71);
            this.numericUpDown9.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown9.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown9.Name = "numericUpDown9";
            this.numericUpDown9.ReadOnly = true;
            this.numericUpDown9.Size = new System.Drawing.Size(73, 22);
            this.numericUpDown9.TabIndex = 61;
            this.numericUpDown9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(11, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 16);
            this.label6.TabIndex = 53;
            this.label6.Text = "X";
            // 
            // numericUpDown10
            // 
            this.numericUpDown10.DecimalPlaces = 3;
            this.numericUpDown10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown10.Location = new System.Drawing.Point(117, 48);
            this.numericUpDown10.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown10.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown10.Name = "numericUpDown10";
            this.numericUpDown10.ReadOnly = true;
            this.numericUpDown10.Size = new System.Drawing.Size(73, 22);
            this.numericUpDown10.TabIndex = 60;
            this.numericUpDown10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.DecimalPlaces = 3;
            this.numericUpDown7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown7.Location = new System.Drawing.Point(38, 25);
            this.numericUpDown7.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown7.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.ReadOnly = true;
            this.numericUpDown7.Size = new System.Drawing.Size(73, 22);
            this.numericUpDown7.TabIndex = 56;
            this.numericUpDown7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.DecimalPlaces = 3;
            this.numericUpDown5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown5.Location = new System.Drawing.Point(38, 71);
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
            this.numericUpDown5.ReadOnly = true;
            this.numericUpDown5.Size = new System.Drawing.Size(73, 22);
            this.numericUpDown5.TabIndex = 58;
            this.numericUpDown5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 16);
            this.label8.TabIndex = 55;
            this.label8.Text = "Z";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(11, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 16);
            this.label7.TabIndex = 54;
            this.label7.Text = "Y";
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.DecimalPlaces = 3;
            this.numericUpDown6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown6.Location = new System.Drawing.Point(38, 48);
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
            this.numericUpDown6.ReadOnly = true;
            this.numericUpDown6.Size = new System.Drawing.Size(73, 22);
            this.numericUpDown6.TabIndex = 57;
            this.numericUpDown6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(91, 6);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(164, 22);
            this.textBoxName.TabIndex = 54;
            this.textBoxName.Text = "вращение";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(6, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 16);
            this.label9.TabIndex = 53;
            this.label9.Text = "Имя:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 3;
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown1.Location = new System.Drawing.Point(165, 417);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(73, 22);
            this.numericUpDown1.TabIndex = 56;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(9, 398);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(198, 16);
            this.label10.TabIndex = 55;
            this.label10.Text = "Шаг изменения радиуса (мм):";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 3;
            this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown2.Location = new System.Drawing.Point(165, 478);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(73, 22);
            this.numericUpDown2.TabIndex = 58;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(10, 459);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(205, 16);
            this.label11.TabIndex = 57;
            this.label11.Text = "Шаг поворота груупы(градус):";
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label12.Location = new System.Drawing.Point(12, 270);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(241, 47);
            this.label12.TabIndex = 59;
            this.label12.Text = "При положительном угле данные поворачиваются против часовой стрелки, при отрицате" +
    "льном угле по часовой стрелке";
            // 
            // frmRotate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 700);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numericRadius);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericStep);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericStop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btGetPosition);
            this.Controls.Add(this.labelposX);
            this.Controls.Add(this.numPosZ);
            this.Controls.Add(this.labelposY);
            this.Controls.Add(this.numPosY);
            this.Controls.Add(this.labelposZ);
            this.Controls.Add(this.numPosX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRotate";
            this.Text = "Вращение";
            this.Load += new System.EventHandler(this.frmRotate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRadius)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btGetPosition;
        private System.Windows.Forms.Label labelposX;
        public System.Windows.Forms.NumericUpDown numPosZ;
        private System.Windows.Forms.Label labelposY;
        public System.Windows.Forms.NumericUpDown numPosY;
        private System.Windows.Forms.Label labelposZ;
        public System.Windows.Forms.NumericUpDown numPosX;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown numericStart;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown numericStop;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown numericStep;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown numericRadius;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.NumericUpDown numericUpDown8;
        public System.Windows.Forms.NumericUpDown numericUpDown9;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown numericUpDown10;
        public System.Windows.Forms.NumericUpDown numericUpDown7;
        public System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown numericUpDown6;
        public System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}