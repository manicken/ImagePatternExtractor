namespace WeaveImagePatternExtractor
{
    partial class ExtractForm
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
            this.picBox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSwitchColors = new System.Windows.Forms.Button();
            this.lblColor2 = new System.Windows.Forms.Label();
            this.lblColor1 = new System.Windows.Forms.Label();
            this.grpThresholds = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBthreshold = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGthreshold = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRthreshold = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.grpParts = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtYparts = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.txtXparts = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.tbRedContrast = new System.Windows.Forms.TrackBar();
            this.btnApplyContrast = new System.Windows.Forms.Button();
            this.txtRedContrastValue = new System.Windows.Forms.TextBox();
            this.tbGreenContrast = new System.Windows.Forms.TrackBar();
            this.tbBlueContrast = new System.Windows.Forms.TrackBar();
            this.txtGreenContrastValue = new System.Windows.Forms.TextBox();
            this.txtBlueContrastValue = new System.Windows.Forms.TextBox();
            this.btnReopen = new System.Windows.Forms.Button();
            this.grpContrastAdj = new System.Windows.Forms.GroupBox();
            this.btnResetContrast = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkProcessStep2 = new System.Windows.Forms.CheckBox();
            this.chkProcessStep1 = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.txtMedianVal = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpThresholds.SuspendLayout();
            this.grpParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRedContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreenContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlueContrast)).BeginInit();
            this.grpContrastAdj.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(1, 122);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(282, 538);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 20;
            this.picBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSwitchColors);
            this.groupBox2.Controls.Add(this.lblColor2);
            this.groupBox2.Controls.Add(this.lblColor1);
            this.groupBox2.Location = new System.Drawing.Point(147, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 44);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "output colors:";
            // 
            // btnSwitchColors
            // 
            this.btnSwitchColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitchColors.Location = new System.Drawing.Point(44, 11);
            this.btnSwitchColors.Name = "btnSwitchColors";
            this.btnSwitchColors.Size = new System.Drawing.Size(36, 32);
            this.btnSwitchColors.TabIndex = 24;
            this.btnSwitchColors.Text = "<-\r\n->";
            this.btnSwitchColors.UseVisualStyleBackColor = true;
            this.btnSwitchColors.Click += new System.EventHandler(this.btnSwitchColors_Click);
            // 
            // lblColor2
            // 
            this.lblColor2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblColor2.BackColor = System.Drawing.Color.Black;
            this.lblColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor2.ForeColor = System.Drawing.Color.White;
            this.lblColor2.Location = new System.Drawing.Point(86, 17);
            this.lblColor2.Name = "lblColor2";
            this.lblColor2.Size = new System.Drawing.Size(32, 21);
            this.lblColor2.TabIndex = 23;
            this.lblColor2.Text = "<";
            this.lblColor2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblColor2.Click += new System.EventHandler(this.lblColor2_Click);
            // 
            // lblColor1
            // 
            this.lblColor1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblColor1.BackColor = System.Drawing.Color.White;
            this.lblColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor1.Location = new System.Drawing.Point(6, 17);
            this.lblColor1.Name = "lblColor1";
            this.lblColor1.Size = new System.Drawing.Size(32, 21);
            this.lblColor1.TabIndex = 22;
            this.lblColor1.Text = ">";
            this.lblColor1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblColor1.Click += new System.EventHandler(this.lblColor1_Click);
            // 
            // grpThresholds
            // 
            this.grpThresholds.Controls.Add(this.label7);
            this.grpThresholds.Controls.Add(this.txtBthreshold);
            this.grpThresholds.Controls.Add(this.label6);
            this.grpThresholds.Controls.Add(this.txtGthreshold);
            this.grpThresholds.Controls.Add(this.label5);
            this.grpThresholds.Controls.Add(this.txtRthreshold);
            this.grpThresholds.Enabled = false;
            this.grpThresholds.Location = new System.Drawing.Point(11, 79);
            this.grpThresholds.Name = "grpThresholds";
            this.grpThresholds.Size = new System.Drawing.Size(178, 42);
            this.grpThresholds.TabIndex = 31;
            this.grpThresholds.TabStop = false;
            this.grpThresholds.Text = "calculated thresholds:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "B:";
            // 
            // txtBthreshold
            // 
            this.txtBthreshold.DefaultValue = 0;
            this.txtBthreshold.Location = new System.Drawing.Point(136, 17);
            this.txtBthreshold.Name = "txtBthreshold";
            this.txtBthreshold.Size = new System.Drawing.Size(32, 20);
            this.txtBthreshold.TabIndex = 17;
            this.txtBthreshold.Text = "128";
            this.txtBthreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBthreshold.Value = 128;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "G:";
            // 
            // txtGthreshold
            // 
            this.txtGthreshold.DefaultValue = 0;
            this.txtGthreshold.Location = new System.Drawing.Point(80, 17);
            this.txtGthreshold.Name = "txtGthreshold";
            this.txtGthreshold.Size = new System.Drawing.Size(32, 20);
            this.txtGthreshold.TabIndex = 15;
            this.txtGthreshold.Text = "128";
            this.txtGthreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGthreshold.Value = 128;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "R:";
            // 
            // txtRthreshold
            // 
            this.txtRthreshold.DefaultValue = 0;
            this.txtRthreshold.Location = new System.Drawing.Point(24, 17);
            this.txtRthreshold.Name = "txtRthreshold";
            this.txtRthreshold.Size = new System.Drawing.Size(32, 20);
            this.txtRthreshold.TabIndex = 13;
            this.txtRthreshold.Text = "128";
            this.txtRthreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRthreshold.Value = 128;
            // 
            // btnExtract
            // 
            this.btnExtract.Enabled = false;
            this.btnExtract.Location = new System.Drawing.Point(195, 79);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(88, 43);
            this.btnExtract.TabIndex = 30;
            this.btnExtract.Text = "extract";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(12, 7);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 21;
            this.btnOpenFile.Text = "open file";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // grpParts
            // 
            this.grpParts.Controls.Add(this.label8);
            this.grpParts.Controls.Add(this.label9);
            this.grpParts.Controls.Add(this.txtYparts);
            this.grpParts.Controls.Add(this.txtXparts);
            this.grpParts.Enabled = false;
            this.grpParts.Location = new System.Drawing.Point(12, 32);
            this.grpParts.Name = "grpParts";
            this.grpParts.Size = new System.Drawing.Size(132, 44);
            this.grpParts.TabIndex = 34;
            this.grpParts.TabStop = false;
            this.grpParts.Text = "parts:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Y:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "X:";
            // 
            // txtYparts
            // 
            this.txtYparts.DefaultValue = 1;
            this.txtYparts.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYparts.Location = new System.Drawing.Point(77, 16);
            this.txtYparts.Name = "txtYparts";
            this.txtYparts.Size = new System.Drawing.Size(32, 22);
            this.txtYparts.TabIndex = 29;
            this.txtYparts.Text = "34";
            this.txtYparts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtYparts.Value = 34;
            this.txtYparts.TextChanged += new System.EventHandler(this.txtXorYparts_TextChanged);
            // 
            // txtXparts
            // 
            this.txtXparts.DefaultValue = 1;
            this.txtXparts.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXparts.Location = new System.Drawing.Point(25, 16);
            this.txtXparts.Name = "txtXparts";
            this.txtXparts.Size = new System.Drawing.Size(32, 22);
            this.txtXparts.TabIndex = 27;
            this.txtXparts.Text = "24";
            this.txtXparts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtXparts.Value = 24;
            this.txtXparts.TextChanged += new System.EventHandler(this.txtXorYparts_TextChanged);
            // 
            // tbRedContrast
            // 
            this.tbRedContrast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRedContrast.Location = new System.Drawing.Point(6, 37);
            this.tbRedContrast.Maximum = 100;
            this.tbRedContrast.Minimum = -100;
            this.tbRedContrast.Name = "tbRedContrast";
            this.tbRedContrast.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbRedContrast.Size = new System.Drawing.Size(45, 440);
            this.tbRedContrast.TabIndex = 36;
            this.tbRedContrast.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbRedContrast.Scroll += new System.EventHandler(this.tbContrast_Scroll);
            // 
            // btnApplyContrast
            // 
            this.btnApplyContrast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApplyContrast.Location = new System.Drawing.Point(98, 503);
            this.btnApplyContrast.Name = "btnApplyContrast";
            this.btnApplyContrast.Size = new System.Drawing.Size(45, 29);
            this.btnApplyContrast.TabIndex = 37;
            this.btnApplyContrast.Text = "apply";
            this.btnApplyContrast.UseVisualStyleBackColor = true;
            this.btnApplyContrast.Click += new System.EventHandler(this.btnApplyContrast_Click);
            // 
            // txtRedContrastValue
            // 
            this.txtRedContrastValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRedContrastValue.Location = new System.Drawing.Point(9, 479);
            this.txtRedContrastValue.Name = "txtRedContrastValue";
            this.txtRedContrastValue.Size = new System.Drawing.Size(39, 20);
            this.txtRedContrastValue.TabIndex = 38;
            // 
            // tbGreenContrast
            // 
            this.tbGreenContrast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGreenContrast.Location = new System.Drawing.Point(53, 37);
            this.tbGreenContrast.Maximum = 100;
            this.tbGreenContrast.Minimum = -100;
            this.tbGreenContrast.Name = "tbGreenContrast";
            this.tbGreenContrast.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbGreenContrast.Size = new System.Drawing.Size(45, 440);
            this.tbGreenContrast.TabIndex = 39;
            this.tbGreenContrast.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbGreenContrast.Scroll += new System.EventHandler(this.tbContrast_Scroll);
            // 
            // tbBlueContrast
            // 
            this.tbBlueContrast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBlueContrast.Location = new System.Drawing.Point(98, 37);
            this.tbBlueContrast.Maximum = 100;
            this.tbBlueContrast.Minimum = -100;
            this.tbBlueContrast.Name = "tbBlueContrast";
            this.tbBlueContrast.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbBlueContrast.Size = new System.Drawing.Size(45, 440);
            this.tbBlueContrast.TabIndex = 40;
            this.tbBlueContrast.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbBlueContrast.Scroll += new System.EventHandler(this.tbContrast_Scroll);
            // 
            // txtGreenContrastValue
            // 
            this.txtGreenContrastValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGreenContrastValue.Location = new System.Drawing.Point(54, 479);
            this.txtGreenContrastValue.Name = "txtGreenContrastValue";
            this.txtGreenContrastValue.Size = new System.Drawing.Size(39, 20);
            this.txtGreenContrastValue.TabIndex = 42;
            // 
            // txtBlueContrastValue
            // 
            this.txtBlueContrastValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlueContrastValue.Location = new System.Drawing.Point(99, 479);
            this.txtBlueContrastValue.Name = "txtBlueContrastValue";
            this.txtBlueContrastValue.Size = new System.Drawing.Size(39, 20);
            this.txtBlueContrastValue.TabIndex = 44;
            // 
            // btnReopen
            // 
            this.btnReopen.Enabled = false;
            this.btnReopen.Location = new System.Drawing.Point(104, 7);
            this.btnReopen.Name = "btnReopen";
            this.btnReopen.Size = new System.Drawing.Size(75, 23);
            this.btnReopen.TabIndex = 45;
            this.btnReopen.Text = "Restore";
            this.btnReopen.UseVisualStyleBackColor = true;
            this.btnReopen.Click += new System.EventHandler(this.btnReopen_Click);
            // 
            // grpContrastAdj
            // 
            this.grpContrastAdj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpContrastAdj.Controls.Add(this.btnResetContrast);
            this.grpContrastAdj.Controls.Add(this.label3);
            this.grpContrastAdj.Controls.Add(this.label2);
            this.grpContrastAdj.Controls.Add(this.label1);
            this.grpContrastAdj.Controls.Add(this.tbRedContrast);
            this.grpContrastAdj.Controls.Add(this.tbGreenContrast);
            this.grpContrastAdj.Controls.Add(this.txtBlueContrastValue);
            this.grpContrastAdj.Controls.Add(this.tbBlueContrast);
            this.grpContrastAdj.Controls.Add(this.btnApplyContrast);
            this.grpContrastAdj.Controls.Add(this.txtGreenContrastValue);
            this.grpContrastAdj.Controls.Add(this.txtRedContrastValue);
            this.grpContrastAdj.Enabled = false;
            this.grpContrastAdj.Location = new System.Drawing.Point(347, 122);
            this.grpContrastAdj.Name = "grpContrastAdj";
            this.grpContrastAdj.Size = new System.Drawing.Size(149, 538);
            this.grpContrastAdj.TabIndex = 46;
            this.grpContrastAdj.TabStop = false;
            this.grpContrastAdj.Text = "Contrast Adjustment:";
            // 
            // btnResetContrast
            // 
            this.btnResetContrast.Location = new System.Drawing.Point(8, 506);
            this.btnResetContrast.Name = "btnResetContrast";
            this.btnResetContrast.Size = new System.Drawing.Size(40, 23);
            this.btnResetContrast.TabIndex = 50;
            this.btnResetContrast.Text = "reset";
            this.btnResetContrast.UseVisualStyleBackColor = true;
            this.btnResetContrast.Click += new System.EventHandler(this.btnResetContrast_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(109, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 49;
            this.label3.Text = "B";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 48;
            this.label2.Text = "G";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 16);
            this.label1.TabIndex = 47;
            this.label1.Text = "R";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkProcessStep2);
            this.groupBox1.Controls.Add(this.chkProcessStep1);
            this.groupBox1.Location = new System.Drawing.Point(290, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 100);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process steps";
            // 
            // chkProcessStep2
            // 
            this.chkProcessStep2.AutoSize = true;
            this.chkProcessStep2.Checked = true;
            this.chkProcessStep2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProcessStep2.Location = new System.Drawing.Point(7, 42);
            this.chkProcessStep2.Name = "chkProcessStep2";
            this.chkProcessStep2.Size = new System.Drawing.Size(128, 17);
            this.chkProcessStep2.TabIndex = 1;
            this.chkProcessStep2.Text = "2. Pattern From Mean";
            this.chkProcessStep2.UseVisualStyleBackColor = true;
            // 
            // chkProcessStep1
            // 
            this.chkProcessStep1.AutoSize = true;
            this.chkProcessStep1.Checked = true;
            this.chkProcessStep1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkProcessStep1.Enabled = false;
            this.chkProcessStep1.Location = new System.Drawing.Point(5, 20);
            this.chkProcessStep1.Name = "chkProcessStep1";
            this.chkProcessStep1.Size = new System.Drawing.Size(134, 17);
            this.chkProcessStep1.TabIndex = 0;
            this.chkProcessStep1.Text = "1. Calc Mean From Src";
            this.chkProcessStep1.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(295, 159);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 440);
            this.trackBar1.TabIndex = 51;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // txtMedianVal
            // 
            this.txtMedianVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMedianVal.Location = new System.Drawing.Point(297, 601);
            this.txtMedianVal.Name = "txtMedianVal";
            this.txtMedianVal.Size = new System.Drawing.Size(39, 20);
            this.txtMedianVal.TabIndex = 51;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(297, 628);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 23);
            this.button1.TabIndex = 52;
            this.button1.Text = "preview";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExtractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 661);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtMedianVal);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpContrastAdj);
            this.Controls.Add(this.btnReopen);
            this.Controls.Add(this.grpParts);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpThresholds);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "ExtractForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Extract Pattern";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExtractForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.grpThresholds.ResumeLayout(false);
            this.grpThresholds.PerformLayout();
            this.grpParts.ResumeLayout(false);
            this.grpParts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRedContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreenContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlueContrast)).EndInit();
            this.grpContrastAdj.ResumeLayout(false);
            this.grpContrastAdj.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private IntegerValueTextBox txtYparts;
        private IntegerValueTextBox txtXparts;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSwitchColors;
        private System.Windows.Forms.Label lblColor2;
        private System.Windows.Forms.Label lblColor1;
        private System.Windows.Forms.GroupBox grpThresholds;
        private System.Windows.Forms.Label label7;
        private IntegerValueTextBox txtBthreshold;
        private System.Windows.Forms.Label label6;
        private IntegerValueTextBox txtGthreshold;
        private System.Windows.Forms.Label label5;
        private IntegerValueTextBox txtRthreshold;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.GroupBox grpParts;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar tbRedContrast;
        private System.Windows.Forms.Button btnApplyContrast;
        private System.Windows.Forms.TextBox txtRedContrastValue;
        private System.Windows.Forms.TrackBar tbGreenContrast;
        private System.Windows.Forms.TrackBar tbBlueContrast;
        private System.Windows.Forms.TextBox txtGreenContrastValue;
        private System.Windows.Forms.TextBox txtBlueContrastValue;
        private System.Windows.Forms.Button btnReopen;
        private System.Windows.Forms.GroupBox grpContrastAdj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnResetContrast;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkProcessStep2;
        private System.Windows.Forms.CheckBox chkProcessStep1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox txtMedianVal;
        private System.Windows.Forms.Button button1;
    }
}