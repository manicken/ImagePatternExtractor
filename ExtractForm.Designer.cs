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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtractForm));
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
            this.btnReopen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkProcessStep2 = new System.Windows.Forms.CheckBox();
            this.chkProcessStep1 = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.txtMedianVal = new System.Windows.Forms.TextBox();
            this.btnPreviewFilter = new System.Windows.Forms.Button();
            this.chkFilterGrayScale = new System.Windows.Forms.CheckBox();
            this.chkFilterThreshold = new System.Windows.Forms.CheckBox();
            this.chkFilterMedian = new System.Windows.Forms.CheckBox();
            this.chkFilterDilatation = new System.Windows.Forms.CheckBox();
            this.chkErosion = new System.Windows.Forms.CheckBox();
            this.grpOCRFilter = new System.Windows.Forms.GroupBox();
            this.dvtxtFilterAdaptiveSmoothing = new WeaveImagePatternExtractor.DoubleValueTextBox();
            this.ivtxtFilterMedian = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.ivtxtPreDilatationCount = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.chkFilterPreDilatation = new System.Windows.Forms.CheckBox();
            this.ivtxtDilatationCount = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.ivtxtErosionCount = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.chkFilterAdaptiveSmoothing = new System.Windows.Forms.CheckBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.rtxt = new System.Windows.Forms.RichTextBox();
            this.btnOpenAIECF = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpThresholds.SuspendLayout();
            this.grpParts.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.grpOCRFilter.SuspendLayout();
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
            this.picBox.Size = new System.Drawing.Size(452, 535);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 20;
            this.picBox.TabStop = false;
            this.picBox.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox_Paint);
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
            this.txtYparts.Text = "26";
            this.txtYparts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtYparts.Value = 26;
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
            this.txtXparts.Text = "27";
            this.txtXparts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtXparts.Value = 27;
            this.txtXparts.TextChanged += new System.EventHandler(this.txtXorYparts_TextChanged);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkProcessStep2);
            this.groupBox1.Controls.Add(this.chkProcessStep1);
            this.groupBox1.Location = new System.Drawing.Point(290, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 67);
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
            this.trackBar1.Location = new System.Drawing.Point(110, 12);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 475);
            this.trackBar1.TabIndex = 51;
            this.trackBar1.TickFrequency = 8;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 63;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // txtMedianVal
            // 
            this.txtMedianVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMedianVal.Location = new System.Drawing.Point(110, 484);
            this.txtMedianVal.Name = "txtMedianVal";
            this.txtMedianVal.Size = new System.Drawing.Size(39, 20);
            this.txtMedianVal.TabIndex = 51;
            // 
            // btnPreviewFilter
            // 
            this.btnPreviewFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviewFilter.Location = new System.Drawing.Point(42, 506);
            this.btnPreviewFilter.Name = "btnPreviewFilter";
            this.btnPreviewFilter.Size = new System.Drawing.Size(53, 23);
            this.btnPreviewFilter.TabIndex = 52;
            this.btnPreviewFilter.Text = "preview";
            this.btnPreviewFilter.UseVisualStyleBackColor = true;
            this.btnPreviewFilter.Click += new System.EventHandler(this.btnPreviewFilter_Click);
            // 
            // chkFilterGrayScale
            // 
            this.chkFilterGrayScale.AutoSize = true;
            this.chkFilterGrayScale.Checked = true;
            this.chkFilterGrayScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterGrayScale.Enabled = false;
            this.chkFilterGrayScale.Location = new System.Drawing.Point(5, 57);
            this.chkFilterGrayScale.Name = "chkFilterGrayScale";
            this.chkFilterGrayScale.Size = new System.Drawing.Size(71, 17);
            this.chkFilterGrayScale.TabIndex = 53;
            this.chkFilterGrayScale.Text = "grayscale";
            this.toolTip1.SetToolTip(this.chkFilterGrayScale, "Converts the image to 8bit grayscale \"binary\" format that can be used by other fi" +
        "lters, this is enabled by default and cannot be disabled");
            this.chkFilterGrayScale.UseVisualStyleBackColor = true;
            // 
            // chkFilterThreshold
            // 
            this.chkFilterThreshold.AutoSize = true;
            this.chkFilterThreshold.Checked = true;
            this.chkFilterThreshold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterThreshold.Location = new System.Drawing.Point(5, 80);
            this.chkFilterThreshold.Name = "chkFilterThreshold";
            this.chkFilterThreshold.Size = new System.Drawing.Size(73, 17);
            this.chkFilterThreshold.TabIndex = 54;
            this.chkFilterThreshold.Text = "Threshold";
            this.toolTip1.SetToolTip(this.chkFilterThreshold, resources.GetString("chkFilterThreshold.ToolTip"));
            this.chkFilterThreshold.UseVisualStyleBackColor = true;
            // 
            // chkFilterMedian
            // 
            this.chkFilterMedian.AutoSize = true;
            this.chkFilterMedian.Location = new System.Drawing.Point(5, 125);
            this.chkFilterMedian.Name = "chkFilterMedian";
            this.chkFilterMedian.Size = new System.Drawing.Size(61, 17);
            this.chkFilterMedian.TabIndex = 55;
            this.chkFilterMedian.Text = "Median";
            this.toolTip1.SetToolTip(this.chkFilterMedian, "used to smooth the image and thus removing small specks");
            this.chkFilterMedian.UseVisualStyleBackColor = true;
            // 
            // chkFilterDilatation
            // 
            this.chkFilterDilatation.AutoSize = true;
            this.chkFilterDilatation.Location = new System.Drawing.Point(5, 194);
            this.chkFilterDilatation.Name = "chkFilterDilatation";
            this.chkFilterDilatation.Size = new System.Drawing.Size(70, 17);
            this.chkFilterDilatation.TabIndex = 56;
            this.chkFilterDilatation.Text = "Dilatation";
            this.toolTip1.SetToolTip(this.chkFilterDilatation, "dilatation makes white areas bigger");
            this.chkFilterDilatation.UseVisualStyleBackColor = true;
            // 
            // chkErosion
            // 
            this.chkErosion.AutoSize = true;
            this.chkErosion.Location = new System.Drawing.Point(5, 171);
            this.chkErosion.Name = "chkErosion";
            this.chkErosion.Size = new System.Drawing.Size(61, 17);
            this.chkErosion.TabIndex = 57;
            this.chkErosion.Text = "Erosion";
            this.toolTip1.SetToolTip(this.chkErosion, "erosion makes black areas bigger");
            this.chkErosion.UseVisualStyleBackColor = true;
            // 
            // grpOCRFilter
            // 
            this.grpOCRFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOCRFilter.Controls.Add(this.dvtxtFilterAdaptiveSmoothing);
            this.grpOCRFilter.Controls.Add(this.ivtxtFilterMedian);
            this.grpOCRFilter.Controls.Add(this.ivtxtPreDilatationCount);
            this.grpOCRFilter.Controls.Add(this.chkFilterPreDilatation);
            this.grpOCRFilter.Controls.Add(this.ivtxtDilatationCount);
            this.grpOCRFilter.Controls.Add(this.ivtxtErosionCount);
            this.grpOCRFilter.Controls.Add(this.chkFilterAdaptiveSmoothing);
            this.grpOCRFilter.Controls.Add(this.btnApplyFilter);
            this.grpOCRFilter.Controls.Add(this.chkFilterGrayScale);
            this.grpOCRFilter.Controls.Add(this.btnPreviewFilter);
            this.grpOCRFilter.Controls.Add(this.chkErosion);
            this.grpOCRFilter.Controls.Add(this.txtMedianVal);
            this.grpOCRFilter.Controls.Add(this.chkFilterThreshold);
            this.grpOCRFilter.Controls.Add(this.trackBar1);
            this.grpOCRFilter.Controls.Add(this.chkFilterDilatation);
            this.grpOCRFilter.Controls.Add(this.chkFilterMedian);
            this.grpOCRFilter.Enabled = false;
            this.grpOCRFilter.Location = new System.Drawing.Point(459, 122);
            this.grpOCRFilter.Name = "grpOCRFilter";
            this.grpOCRFilter.Size = new System.Drawing.Size(161, 535);
            this.grpOCRFilter.TabIndex = 58;
            this.grpOCRFilter.TabStop = false;
            this.grpOCRFilter.Text = "OCR filter";
            // 
            // dvtxtFilterAdaptiveSmoothing
            // 
            this.dvtxtFilterAdaptiveSmoothing.DefaultValue = 0D;
            this.dvtxtFilterAdaptiveSmoothing.Location = new System.Drawing.Point(74, 100);
            this.dvtxtFilterAdaptiveSmoothing.Name = "dvtxtFilterAdaptiveSmoothing";
            this.dvtxtFilterAdaptiveSmoothing.Size = new System.Drawing.Size(31, 20);
            this.dvtxtFilterAdaptiveSmoothing.TabIndex = 64;
            this.dvtxtFilterAdaptiveSmoothing.Text = "0";
            this.dvtxtFilterAdaptiveSmoothing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dvtxtFilterAdaptiveSmoothing.Value = 0D;
            // 
            // ivtxtFilterMedian
            // 
            this.ivtxtFilterMedian.DefaultValue = 0;
            this.ivtxtFilterMedian.Location = new System.Drawing.Point(74, 123);
            this.ivtxtFilterMedian.Name = "ivtxtFilterMedian";
            this.ivtxtFilterMedian.Size = new System.Drawing.Size(31, 20);
            this.ivtxtFilterMedian.TabIndex = 63;
            this.ivtxtFilterMedian.Text = "1";
            this.ivtxtFilterMedian.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ivtxtFilterMedian.Value = 1;
            // 
            // ivtxtPreDilatationCount
            // 
            this.ivtxtPreDilatationCount.DefaultValue = 1;
            this.ivtxtPreDilatationCount.Location = new System.Drawing.Point(74, 146);
            this.ivtxtPreDilatationCount.Name = "ivtxtPreDilatationCount";
            this.ivtxtPreDilatationCount.Size = new System.Drawing.Size(31, 20);
            this.ivtxtPreDilatationCount.TabIndex = 63;
            this.ivtxtPreDilatationCount.Text = "1";
            this.ivtxtPreDilatationCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ivtxtPreDilatationCount.Value = 1;
            // 
            // chkFilterPreDilatation
            // 
            this.chkFilterPreDilatation.AutoSize = true;
            this.chkFilterPreDilatation.Location = new System.Drawing.Point(5, 148);
            this.chkFilterPreDilatation.Name = "chkFilterPreDilatation";
            this.chkFilterPreDilatation.Size = new System.Drawing.Size(70, 17);
            this.chkFilterPreDilatation.TabIndex = 62;
            this.chkFilterPreDilatation.Text = "Dilatation";
            this.toolTip1.SetToolTip(this.chkFilterPreDilatation, "dilatation makes white areas bigger");
            this.chkFilterPreDilatation.UseVisualStyleBackColor = true;
            // 
            // ivtxtDilatationCount
            // 
            this.ivtxtDilatationCount.DefaultValue = 1;
            this.ivtxtDilatationCount.Location = new System.Drawing.Point(74, 192);
            this.ivtxtDilatationCount.Name = "ivtxtDilatationCount";
            this.ivtxtDilatationCount.Size = new System.Drawing.Size(31, 20);
            this.ivtxtDilatationCount.TabIndex = 61;
            this.ivtxtDilatationCount.Text = "1";
            this.ivtxtDilatationCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ivtxtDilatationCount.Value = 1;
            // 
            // ivtxtErosionCount
            // 
            this.ivtxtErosionCount.DefaultValue = 1;
            this.ivtxtErosionCount.Location = new System.Drawing.Point(74, 169);
            this.ivtxtErosionCount.Name = "ivtxtErosionCount";
            this.ivtxtErosionCount.Size = new System.Drawing.Size(31, 20);
            this.ivtxtErosionCount.TabIndex = 60;
            this.ivtxtErosionCount.Text = "1";
            this.ivtxtErosionCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ivtxtErosionCount.Value = 1;
            // 
            // chkFilterAdaptiveSmoothing
            // 
            this.chkFilterAdaptiveSmoothing.AutoSize = true;
            this.chkFilterAdaptiveSmoothing.Location = new System.Drawing.Point(5, 103);
            this.chkFilterAdaptiveSmoothing.Name = "chkFilterAdaptiveSmoothing";
            this.chkFilterAdaptiveSmoothing.Size = new System.Drawing.Size(63, 17);
            this.chkFilterAdaptiveSmoothing.TabIndex = 59;
            this.chkFilterAdaptiveSmoothing.Text = "AdpSmt";
            this.toolTip1.SetToolTip(this.chkFilterAdaptiveSmoothing, " removes all connected components from the input image that are smaller than a sp" +
        "ecified size.");
            this.chkFilterAdaptiveSmoothing.UseVisualStyleBackColor = true;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyFilter.Location = new System.Drawing.Point(102, 506);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(53, 23);
            this.btnApplyFilter.TabIndex = 58;
            this.btnApplyFilter.Text = "apply";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // rtxt
            // 
            this.rtxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxt.Location = new System.Drawing.Point(448, 17);
            this.rtxt.Name = "rtxt";
            this.rtxt.Size = new System.Drawing.Size(172, 96);
            this.rtxt.TabIndex = 59;
            this.rtxt.Text = "";
            // 
            // btnOpenAIECF
            // 
            this.btnOpenAIECF.Enabled = false;
            this.btnOpenAIECF.Location = new System.Drawing.Point(346, 7);
            this.btnOpenAIECF.Name = "btnOpenAIECF";
            this.btnOpenAIECF.Size = new System.Drawing.Size(92, 23);
            this.btnOpenAIECF.TabIndex = 60;
            this.btnOpenAIECF.Text = "adv edit form";
            this.btnOpenAIECF.UseVisualStyleBackColor = true;
            this.btnOpenAIECF.Click += new System.EventHandler(this.btnOpenAIECF_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // ExtractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 658);
            this.Controls.Add(this.btnOpenAIECF);
            this.Controls.Add(this.rtxt);
            this.Controls.Add(this.grpOCRFilter);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.grpOCRFilter.ResumeLayout(false);
            this.grpOCRFilter.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnReopen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkProcessStep2;
        private System.Windows.Forms.CheckBox chkProcessStep1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox txtMedianVal;
        private System.Windows.Forms.Button btnPreviewFilter;
        private System.Windows.Forms.CheckBox chkFilterGrayScale;
        private System.Windows.Forms.CheckBox chkFilterThreshold;
        private System.Windows.Forms.CheckBox chkFilterMedian;
        private System.Windows.Forms.CheckBox chkFilterDilatation;
        private System.Windows.Forms.CheckBox chkErosion;
        private System.Windows.Forms.GroupBox grpOCRFilter;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.RichTextBox rtxt;
        private System.Windows.Forms.Button btnOpenAIECF;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkFilterAdaptiveSmoothing;
        private IntegerValueTextBox ivtxtDilatationCount;
        private IntegerValueTextBox ivtxtErosionCount;
        private IntegerValueTextBox ivtxtPreDilatationCount;
        private System.Windows.Forms.CheckBox chkFilterPreDilatation;
        private IntegerValueTextBox ivtxtFilterMedian;
        private DoubleValueTextBox dvtxtFilterAdaptiveSmoothing;
    }
}