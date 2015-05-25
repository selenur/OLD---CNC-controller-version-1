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
            this.centerZ = new System.Windows.Forms.NumericUpDown();
            this.labelposY = new System.Windows.Forms.Label();
            this.centerY = new System.Windows.Forms.NumericUpDown();
            this.labelposZ = new System.Windows.Forms.Label();
            this.centerX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.rotateStartAngle = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.rotateStopAngle = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.rotateStepAngle = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.rotateRadius = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.arcStopX = new System.Windows.Forms.NumericUpDown();
            this.arcStopZ = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.arcStopY = new System.Windows.Forms.NumericUpDown();
            this.arcStartX = new System.Windows.Forms.NumericUpDown();
            this.arcStartZ = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.arcStartY = new System.Windows.Forms.NumericUpDown();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.deltaStepRadius = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.RotateRotates = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.centerZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateStartAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateStopAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateStepAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateRadius)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arcStopX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcStopZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcStopY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcStartX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcStartZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcStartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deltaStepRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotateRotates)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Image = global::CNC_Controller.Properties.Resources.cancel2;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(153, 522);
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
            this.button1.Location = new System.Drawing.Point(5, 522);
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
            // centerZ
            // 
            this.centerZ.DecimalPlaces = 3;
            this.centerZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.centerZ.Location = new System.Drawing.Point(36, 101);
            this.centerZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.centerZ.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.centerZ.Name = "centerZ";
            this.centerZ.Size = new System.Drawing.Size(73, 22);
            this.centerZ.TabIndex = 39;
            this.centerZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.centerZ.ValueChanged += new System.EventHandler(this.numPosZ_ValueChanged);
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
            // centerY
            // 
            this.centerY.DecimalPlaces = 3;
            this.centerY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.centerY.Location = new System.Drawing.Point(36, 78);
            this.centerY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.centerY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.centerY.Name = "centerY";
            this.centerY.Size = new System.Drawing.Size(73, 22);
            this.centerY.TabIndex = 38;
            this.centerY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.centerY.ValueChanged += new System.EventHandler(this.numPosY_ValueChanged);
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
            // centerX
            // 
            this.centerX.DecimalPlaces = 3;
            this.centerX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.centerX.Location = new System.Drawing.Point(36, 55);
            this.centerX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.centerX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.centerX.Name = "centerX";
            this.centerX.Size = new System.Drawing.Size(73, 22);
            this.centerX.TabIndex = 37;
            this.centerX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.centerX.ValueChanged += new System.EventHandler(this.numPosX_ValueChanged);
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
            // rotateStartAngle
            // 
            this.rotateStartAngle.DecimalPlaces = 3;
            this.rotateStartAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotateStartAngle.Location = new System.Drawing.Point(186, 165);
            this.rotateStartAngle.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rotateStartAngle.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.rotateStartAngle.Name = "rotateStartAngle";
            this.rotateStartAngle.Size = new System.Drawing.Size(73, 22);
            this.rotateStartAngle.TabIndex = 45;
            this.rotateStartAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rotateStartAngle.ValueChanged += new System.EventHandler(this.numericStart_ValueChanged);
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
            // rotateStopAngle
            // 
            this.rotateStopAngle.DecimalPlaces = 3;
            this.rotateStopAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotateStopAngle.Location = new System.Drawing.Point(186, 189);
            this.rotateStopAngle.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rotateStopAngle.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.rotateStopAngle.Name = "rotateStopAngle";
            this.rotateStopAngle.Size = new System.Drawing.Size(73, 22);
            this.rotateStopAngle.TabIndex = 47;
            this.rotateStopAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rotateStopAngle.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.rotateStopAngle.ValueChanged += new System.EventHandler(this.numericStop_ValueChanged);
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
            // rotateStepAngle
            // 
            this.rotateStepAngle.DecimalPlaces = 3;
            this.rotateStepAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotateStepAngle.Location = new System.Drawing.Point(186, 213);
            this.rotateStepAngle.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rotateStepAngle.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.rotateStepAngle.Name = "rotateStepAngle";
            this.rotateStepAngle.Size = new System.Drawing.Size(73, 22);
            this.rotateStepAngle.TabIndex = 49;
            this.rotateStepAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rotateStepAngle.ValueChanged += new System.EventHandler(this.numericStep_ValueChanged);
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
            // rotateRadius
            // 
            this.rotateRadius.DecimalPlaces = 3;
            this.rotateRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotateRadius.Location = new System.Drawing.Point(186, 141);
            this.rotateRadius.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rotateRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.rotateRadius.Name = "rotateRadius";
            this.rotateRadius.Size = new System.Drawing.Size(73, 22);
            this.rotateRadius.TabIndex = 51;
            this.rotateRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rotateRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rotateRadius.ValueChanged += new System.EventHandler(this.numericRadius_ValueChanged);
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
            this.groupBox1.Controls.Add(this.arcStopX);
            this.groupBox1.Controls.Add(this.arcStopZ);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.arcStopY);
            this.groupBox1.Controls.Add(this.arcStartX);
            this.groupBox1.Controls.Add(this.arcStartZ);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.arcStartY);
            this.groupBox1.Location = new System.Drawing.Point(5, 237);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 107);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Координаты начала, и окончания дуги:";
            // 
            // arcStopX
            // 
            this.arcStopX.DecimalPlaces = 3;
            this.arcStopX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arcStopX.Location = new System.Drawing.Point(117, 25);
            this.arcStopX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.arcStopX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.arcStopX.Name = "arcStopX";
            this.arcStopX.ReadOnly = true;
            this.arcStopX.Size = new System.Drawing.Size(73, 22);
            this.arcStopX.TabIndex = 59;
            this.arcStopX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // arcStopZ
            // 
            this.arcStopZ.DecimalPlaces = 3;
            this.arcStopZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arcStopZ.Location = new System.Drawing.Point(117, 71);
            this.arcStopZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.arcStopZ.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.arcStopZ.Name = "arcStopZ";
            this.arcStopZ.ReadOnly = true;
            this.arcStopZ.Size = new System.Drawing.Size(73, 22);
            this.arcStopZ.TabIndex = 61;
            this.arcStopZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // arcStopY
            // 
            this.arcStopY.DecimalPlaces = 3;
            this.arcStopY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arcStopY.Location = new System.Drawing.Point(117, 48);
            this.arcStopY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.arcStopY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.arcStopY.Name = "arcStopY";
            this.arcStopY.ReadOnly = true;
            this.arcStopY.Size = new System.Drawing.Size(73, 22);
            this.arcStopY.TabIndex = 60;
            this.arcStopY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // arcStartX
            // 
            this.arcStartX.DecimalPlaces = 3;
            this.arcStartX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arcStartX.Location = new System.Drawing.Point(38, 25);
            this.arcStartX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.arcStartX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.arcStartX.Name = "arcStartX";
            this.arcStartX.ReadOnly = true;
            this.arcStartX.Size = new System.Drawing.Size(73, 22);
            this.arcStartX.TabIndex = 56;
            this.arcStartX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // arcStartZ
            // 
            this.arcStartZ.DecimalPlaces = 3;
            this.arcStartZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arcStartZ.Location = new System.Drawing.Point(38, 71);
            this.arcStartZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.arcStartZ.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.arcStartZ.Name = "arcStartZ";
            this.arcStartZ.ReadOnly = true;
            this.arcStartZ.Size = new System.Drawing.Size(73, 22);
            this.arcStartZ.TabIndex = 58;
            this.arcStartZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // arcStartY
            // 
            this.arcStartY.DecimalPlaces = 3;
            this.arcStartY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arcStartY.Location = new System.Drawing.Point(38, 48);
            this.arcStartY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.arcStartY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.arcStartY.Name = "arcStartY";
            this.arcStartY.ReadOnly = true;
            this.arcStartY.Size = new System.Drawing.Size(73, 22);
            this.arcStartY.TabIndex = 57;
            this.arcStartY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(91, 6);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(164, 22);
            this.textBoxName.TabIndex = 54;
            this.textBoxName.Text = "Вращение";
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
            // deltaStepRadius
            // 
            this.deltaStepRadius.DecimalPlaces = 3;
            this.deltaStepRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deltaStepRadius.Location = new System.Drawing.Point(90, 33);
            this.deltaStepRadius.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.deltaStepRadius.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.deltaStepRadius.Name = "deltaStepRadius";
            this.deltaStepRadius.Size = new System.Drawing.Size(73, 22);
            this.deltaStepRadius.TabIndex = 56;
            this.deltaStepRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(7, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(241, 33);
            this.label10.TabIndex = 55;
            this.label10.Text = "∆ изменения радиуса с каждым шагом (мм):";
            // 
            // RotateRotates
            // 
            this.RotateRotates.DecimalPlaces = 3;
            this.RotateRotates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RotateRotates.Location = new System.Drawing.Point(175, 85);
            this.RotateRotates.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.RotateRotates.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.RotateRotates.Name = "RotateRotates";
            this.RotateRotates.Size = new System.Drawing.Size(73, 22);
            this.RotateRotates.TabIndex = 58;
            this.RotateRotates.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(5, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(243, 36);
            this.label11.TabIndex = 57;
            this.label11.Text = "На сколько градусов вращать данные, с каждым шагом:";
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label12.Location = new System.Drawing.Point(7, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(241, 47);
            this.label12.TabIndex = 59;
            this.label12.Text = "При положительном угле данные поворачиваются против часовой стрелки, при отрицате" +
    "льном угле по часовой стрелке";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deltaStepRadius);
            this.groupBox2.Controls.Add(this.RotateRotates);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(5, 350);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 164);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "дополнительно";
            // 
            // frmRotate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 582);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rotateRadius);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rotateStepAngle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rotateStopAngle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rotateStartAngle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btGetPosition);
            this.Controls.Add(this.labelposX);
            this.Controls.Add(this.centerZ);
            this.Controls.Add(this.labelposY);
            this.Controls.Add(this.centerY);
            this.Controls.Add(this.labelposZ);
            this.Controls.Add(this.centerX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRotate";
            this.Text = "Вращение";
            this.Load += new System.EventHandler(this.frmRotate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.centerZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateStartAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateStopAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateStepAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateRadius)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arcStopX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcStopZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcStopY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcStartX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcStartZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcStartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deltaStepRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotateRotates)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btGetPosition;
        private System.Windows.Forms.Label labelposX;
        public System.Windows.Forms.NumericUpDown centerZ;
        private System.Windows.Forms.Label labelposY;
        public System.Windows.Forms.NumericUpDown centerY;
        private System.Windows.Forms.Label labelposZ;
        public System.Windows.Forms.NumericUpDown centerX;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown rotateStartAngle;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown rotateStopAngle;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown rotateStepAngle;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown rotateRadius;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.NumericUpDown arcStopX;
        public System.Windows.Forms.NumericUpDown arcStopZ;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown arcStopY;
        public System.Windows.Forms.NumericUpDown arcStartX;
        public System.Windows.Forms.NumericUpDown arcStartZ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown arcStartY;
        public System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.NumericUpDown deltaStepRadius;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.NumericUpDown RotateRotates;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}