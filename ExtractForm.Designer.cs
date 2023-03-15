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
            this.cmsPicBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiPicBoxSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSwitchColors = new System.Windows.Forms.Button();
            this.lblColor2 = new System.Windows.Forms.Label();
            this.lblColor1 = new System.Windows.Forms.Label();
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.grpParts = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtYparts = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.txtXparts = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.btnShowOriginal = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkProcessStep2 = new System.Windows.Forms.CheckBox();
            this.chkProcessStep1 = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.txtMedianVal = new System.Windows.Forms.TextBox();
            this.chkFilterGrayScale = new System.Windows.Forms.CheckBox();
            this.chkFilterThreshold = new System.Windows.Forms.CheckBox();
            this.chkFilterMedian = new System.Windows.Forms.CheckBox();
            this.chkFilterDilatation = new System.Windows.Forms.CheckBox();
            this.chkErosion = new System.Windows.Forms.CheckBox();
            this.grpOCRFilter = new System.Windows.Forms.GroupBox();
            this.btnSPCACR = new System.Windows.Forms.Button();
            this.btnOpenAIECF = new System.Windows.Forms.Button();
            this.chkFilterContrast = new System.Windows.Forms.CheckBox();
            this.chkTrimParts = new System.Windows.Forms.CheckBox();
            this.dvtxtGrayScaleBlue = new WeaveImagePatternExtractor.DoubleValueTextBox();
            this.dvtxtGrayScaleGreen = new WeaveImagePatternExtractor.DoubleValueTextBox();
            this.dvtxtGrayScaleRed = new WeaveImagePatternExtractor.DoubleValueTextBox();
            this.tvtxtTrimPartsSize = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.ivtxtFilterRemoveIsolatedPixelsP2 = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.dvtxtFilterAdaptiveSmoothing = new WeaveImagePatternExtractor.DoubleValueTextBox();
            this.ivtxtFilterRemoveIsolatedPixelsP1 = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.ivtxtFilterMedian = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.ivtxtPreDilatationCount = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.chkFilterPreDilatation = new System.Windows.Forms.CheckBox();
            this.ivtxtDilatationCount = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.ivtxtErosionCount = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.chkFilterAdaptiveSmoothing = new System.Windows.Forms.CheckBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.chkFilterRemoveIsolatedPixels = new System.Windows.Forms.CheckBox();
            this.rtxt = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtExtractThreshold = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.tbExtractThreshold = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.cmsPicBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpParts.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.grpOCRFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbExtractThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.ContextMenuStrip = this.cmsPicBox;
            this.picBox.Location = new System.Drawing.Point(3, 3);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(434, 506);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 20;
            this.picBox.TabStop = false;
            this.picBox.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox_Paint);
            // 
            // cmsPicBox
            // 
            this.cmsPicBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPicBoxSaveAs});
            this.cmsPicBox.Name = "cmsPicBox";
            this.cmsPicBox.Size = new System.Drawing.Size(119, 26);
            // 
            // tsmiPicBoxSaveAs
            // 
            this.tsmiPicBoxSaveAs.Name = "tsmiPicBoxSaveAs";
            this.tsmiPicBoxSaveAs.Size = new System.Drawing.Size(118, 22);
            this.tsmiPicBoxSaveAs.Text = "Save as..";
            this.tsmiPicBoxSaveAs.Click += new System.EventHandler(this.tsmiPicBoxSaveAs_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSwitchColors);
            this.groupBox2.Controls.Add(this.lblColor2);
            this.groupBox2.Controls.Add(this.lblColor1);
            this.groupBox2.Location = new System.Drawing.Point(226, 7);
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
            // btnExtract
            // 
            this.btnExtract.Enabled = false;
            this.btnExtract.Location = new System.Drawing.Point(600, 8);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(88, 43);
            this.btnExtract.TabIndex = 30;
            this.btnExtract.Text = "extract";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(7, 8);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 44);
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
            this.grpParts.Location = new System.Drawing.Point(88, 8);
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
            // btnShowOriginal
            // 
            this.btnShowOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowOriginal.Enabled = false;
            this.btnShowOriginal.Location = new System.Drawing.Point(6, 477);
            this.btnShowOriginal.Name = "btnShowOriginal";
            this.btnShowOriginal.Size = new System.Drawing.Size(84, 23);
            this.btnShowOriginal.TabIndex = 45;
            this.btnShowOriginal.Text = "Show Original";
            this.btnShowOriginal.UseVisualStyleBackColor = true;
            this.btnShowOriginal.Click += new System.EventHandler(this.btnShowOriginal_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkProcessStep2);
            this.groupBox1.Controls.Add(this.chkProcessStep1);
            this.groupBox1.Location = new System.Drawing.Point(424, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 45);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process steps";
            // 
            // chkProcessStep2
            // 
            this.chkProcessStep2.AutoSize = true;
            this.chkProcessStep2.Checked = true;
            this.chkProcessStep2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProcessStep2.Location = new System.Drawing.Point(5, 28);
            this.chkProcessStep2.Name = "chkProcessStep2";
            this.chkProcessStep2.Size = new System.Drawing.Size(162, 17);
            this.chkProcessStep2.TabIndex = 1;
            this.chkProcessStep2.Text = "2. Pattern From out threshold";
            this.chkProcessStep2.UseVisualStyleBackColor = true;
            // 
            // chkProcessStep1
            // 
            this.chkProcessStep1.AutoSize = true;
            this.chkProcessStep1.Checked = true;
            this.chkProcessStep1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkProcessStep1.Enabled = false;
            this.chkProcessStep1.Location = new System.Drawing.Point(5, 14);
            this.chkProcessStep1.Name = "chkProcessStep1";
            this.chkProcessStep1.Size = new System.Drawing.Size(83, 17);
            this.chkProcessStep1.TabIndex = 0;
            this.chkProcessStep1.Text = "1. OCRFilter";
            this.chkProcessStep1.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(145, 12);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 446);
            this.trackBar1.TabIndex = 51;
            this.trackBar1.TickFrequency = 8;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 63;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // txtMedianVal
            // 
            this.txtMedianVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMedianVal.Location = new System.Drawing.Point(145, 456);
            this.txtMedianVal.Name = "txtMedianVal";
            this.txtMedianVal.Size = new System.Drawing.Size(39, 20);
            this.txtMedianVal.TabIndex = 51;
            // 
            // chkFilterGrayScale
            // 
            this.chkFilterGrayScale.AutoSize = true;
            this.chkFilterGrayScale.Checked = true;
            this.chkFilterGrayScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterGrayScale.Enabled = false;
            this.chkFilterGrayScale.Location = new System.Drawing.Point(5, 64);
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
            this.chkFilterThreshold.Location = new System.Drawing.Point(5, 125);
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
            this.chkFilterMedian.Location = new System.Drawing.Point(5, 191);
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
            this.chkFilterDilatation.Location = new System.Drawing.Point(5, 260);
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
            this.chkErosion.Checked = true;
            this.chkErosion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkErosion.Location = new System.Drawing.Point(5, 237);
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
            this.grpOCRFilter.Controls.Add(this.btnSPCACR);
            this.grpOCRFilter.Controls.Add(this.btnOpenAIECF);
            this.grpOCRFilter.Controls.Add(this.chkFilterContrast);
            this.grpOCRFilter.Controls.Add(this.chkTrimParts);
            this.grpOCRFilter.Controls.Add(this.dvtxtGrayScaleBlue);
            this.grpOCRFilter.Controls.Add(this.dvtxtGrayScaleGreen);
            this.grpOCRFilter.Controls.Add(this.dvtxtGrayScaleRed);
            this.grpOCRFilter.Controls.Add(this.tvtxtTrimPartsSize);
            this.grpOCRFilter.Controls.Add(this.ivtxtFilterRemoveIsolatedPixelsP2);
            this.grpOCRFilter.Controls.Add(this.btnShowOriginal);
            this.grpOCRFilter.Controls.Add(this.dvtxtFilterAdaptiveSmoothing);
            this.grpOCRFilter.Controls.Add(this.ivtxtFilterRemoveIsolatedPixelsP1);
            this.grpOCRFilter.Controls.Add(this.ivtxtFilterMedian);
            this.grpOCRFilter.Controls.Add(this.ivtxtPreDilatationCount);
            this.grpOCRFilter.Controls.Add(this.chkFilterPreDilatation);
            this.grpOCRFilter.Controls.Add(this.ivtxtDilatationCount);
            this.grpOCRFilter.Controls.Add(this.ivtxtErosionCount);
            this.grpOCRFilter.Controls.Add(this.chkFilterAdaptiveSmoothing);
            this.grpOCRFilter.Controls.Add(this.btnApplyFilter);
            this.grpOCRFilter.Controls.Add(this.txtMedianVal);
            this.grpOCRFilter.Controls.Add(this.chkFilterGrayScale);
            this.grpOCRFilter.Controls.Add(this.chkErosion);
            this.grpOCRFilter.Controls.Add(this.chkFilterThreshold);
            this.grpOCRFilter.Controls.Add(this.trackBar1);
            this.grpOCRFilter.Controls.Add(this.chkFilterDilatation);
            this.grpOCRFilter.Controls.Add(this.chkFilterRemoveIsolatedPixels);
            this.grpOCRFilter.Controls.Add(this.chkFilterMedian);
            this.grpOCRFilter.Enabled = false;
            this.grpOCRFilter.Location = new System.Drawing.Point(443, 4);
            this.grpOCRFilter.Name = "grpOCRFilter";
            this.grpOCRFilter.Size = new System.Drawing.Size(196, 506);
            this.grpOCRFilter.TabIndex = 58;
            this.grpOCRFilter.TabStop = false;
            this.grpOCRFilter.Text = "OCR filter";
            // 
            // btnSPCACR
            // 
            this.btnSPCACR.Location = new System.Drawing.Point(15, 335);
            this.btnSPCACR.Name = "btnSPCACR";
            this.btnSPCACR.Size = new System.Drawing.Size(75, 84);
            this.btnSPCACR.TabIndex = 69;
            this.btnSPCACR.Text = "show/hide perspective correction and crop rectangle";
            this.btnSPCACR.UseVisualStyleBackColor = true;
            this.btnSPCACR.Click += new System.EventHandler(this.btnSPCACR_Click);
            // 
            // btnOpenAIECF
            // 
            this.btnOpenAIECF.Enabled = false;
            this.btnOpenAIECF.Location = new System.Drawing.Point(66, 15);
            this.btnOpenAIECF.Name = "btnOpenAIECF";
            this.btnOpenAIECF.Size = new System.Drawing.Size(80, 23);
            this.btnOpenAIECF.TabIndex = 60;
            this.btnOpenAIECF.Text = "adv edit form";
            this.btnOpenAIECF.UseVisualStyleBackColor = true;
            this.btnOpenAIECF.Click += new System.EventHandler(this.btnOpenAIECF_Click);
            // 
            // chkFilterContrast
            // 
            this.chkFilterContrast.AutoSize = true;
            this.chkFilterContrast.Location = new System.Drawing.Point(5, 19);
            this.chkFilterContrast.Name = "chkFilterContrast";
            this.chkFilterContrast.Size = new System.Drawing.Size(65, 17);
            this.chkFilterContrast.TabIndex = 68;
            this.chkFilterContrast.Text = "Contrast";
            this.chkFilterContrast.UseVisualStyleBackColor = true;
            // 
            // chkTrimParts
            // 
            this.chkTrimParts.AutoSize = true;
            this.chkTrimParts.Checked = true;
            this.chkTrimParts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrimParts.Location = new System.Drawing.Point(5, 41);
            this.chkTrimParts.Name = "chkTrimParts";
            this.chkTrimParts.Size = new System.Drawing.Size(73, 17);
            this.chkTrimParts.TabIndex = 67;
            this.chkTrimParts.Text = "Trim Parts";
            this.chkTrimParts.UseVisualStyleBackColor = true;
            // 
            // dvtxtGrayScaleBlue
            // 
            this.dvtxtGrayScaleBlue.DefaultValue = 0D;
            this.dvtxtGrayScaleBlue.Location = new System.Drawing.Point(87, 88);
            this.dvtxtGrayScaleBlue.Name = "dvtxtGrayScaleBlue";
            this.dvtxtGrayScaleBlue.Size = new System.Drawing.Size(41, 20);
            this.dvtxtGrayScaleBlue.TabIndex = 66;
            this.dvtxtGrayScaleBlue.Text = "0,0721";
            this.dvtxtGrayScaleBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dvtxtGrayScaleBlue.Value = 0.0721D;
            // 
            // dvtxtGrayScaleGreen
            // 
            this.dvtxtGrayScaleGreen.DefaultValue = 0D;
            this.dvtxtGrayScaleGreen.Location = new System.Drawing.Point(46, 88);
            this.dvtxtGrayScaleGreen.Name = "dvtxtGrayScaleGreen";
            this.dvtxtGrayScaleGreen.Size = new System.Drawing.Size(41, 20);
            this.dvtxtGrayScaleGreen.TabIndex = 66;
            this.dvtxtGrayScaleGreen.Text = "0,7154";
            this.dvtxtGrayScaleGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dvtxtGrayScaleGreen.Value = 0.7154D;
            // 
            // dvtxtGrayScaleRed
            // 
            this.dvtxtGrayScaleRed.DefaultValue = 0D;
            this.dvtxtGrayScaleRed.Location = new System.Drawing.Point(5, 88);
            this.dvtxtGrayScaleRed.Name = "dvtxtGrayScaleRed";
            this.dvtxtGrayScaleRed.Size = new System.Drawing.Size(41, 20);
            this.dvtxtGrayScaleRed.TabIndex = 66;
            this.dvtxtGrayScaleRed.Text = "0,2125";
            this.dvtxtGrayScaleRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dvtxtGrayScaleRed.Value = 0.2125D;
            // 
            // tvtxtTrimPartsSize
            // 
            this.tvtxtTrimPartsSize.DefaultValue = 1;
            this.tvtxtTrimPartsSize.Location = new System.Drawing.Point(78, 40);
            this.tvtxtTrimPartsSize.Name = "tvtxtTrimPartsSize";
            this.tvtxtTrimPartsSize.Size = new System.Drawing.Size(24, 20);
            this.tvtxtTrimPartsSize.TabIndex = 65;
            this.tvtxtTrimPartsSize.Text = "5";
            this.tvtxtTrimPartsSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tvtxtTrimPartsSize.Value = 5;
            // 
            // ivtxtFilterRemoveIsolatedPixelsP2
            // 
            this.ivtxtFilterRemoveIsolatedPixelsP2.DefaultValue = 1;
            this.ivtxtFilterRemoveIsolatedPixelsP2.Location = new System.Drawing.Point(111, 143);
            this.ivtxtFilterRemoveIsolatedPixelsP2.Name = "ivtxtFilterRemoveIsolatedPixelsP2";
            this.ivtxtFilterRemoveIsolatedPixelsP2.Size = new System.Drawing.Size(24, 20);
            this.ivtxtFilterRemoveIsolatedPixelsP2.TabIndex = 65;
            this.ivtxtFilterRemoveIsolatedPixelsP2.Text = "1";
            this.ivtxtFilterRemoveIsolatedPixelsP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ivtxtFilterRemoveIsolatedPixelsP2.Value = 1;
            // 
            // dvtxtFilterAdaptiveSmoothing
            // 
            this.dvtxtFilterAdaptiveSmoothing.DefaultValue = 0D;
            this.dvtxtFilterAdaptiveSmoothing.Location = new System.Drawing.Point(87, 166);
            this.dvtxtFilterAdaptiveSmoothing.Name = "dvtxtFilterAdaptiveSmoothing";
            this.dvtxtFilterAdaptiveSmoothing.Size = new System.Drawing.Size(24, 20);
            this.dvtxtFilterAdaptiveSmoothing.TabIndex = 64;
            this.dvtxtFilterAdaptiveSmoothing.Text = "0";
            this.dvtxtFilterAdaptiveSmoothing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dvtxtFilterAdaptiveSmoothing.Value = 0D;
            // 
            // ivtxtFilterRemoveIsolatedPixelsP1
            // 
            this.ivtxtFilterRemoveIsolatedPixelsP1.DefaultValue = 1;
            this.ivtxtFilterRemoveIsolatedPixelsP1.Location = new System.Drawing.Point(87, 143);
            this.ivtxtFilterRemoveIsolatedPixelsP1.Name = "ivtxtFilterRemoveIsolatedPixelsP1";
            this.ivtxtFilterRemoveIsolatedPixelsP1.Size = new System.Drawing.Size(24, 20);
            this.ivtxtFilterRemoveIsolatedPixelsP1.TabIndex = 63;
            this.ivtxtFilterRemoveIsolatedPixelsP1.Text = "5";
            this.ivtxtFilterRemoveIsolatedPixelsP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ivtxtFilterRemoveIsolatedPixelsP1.Value = 5;
            // 
            // ivtxtFilterMedian
            // 
            this.ivtxtFilterMedian.DefaultValue = 0;
            this.ivtxtFilterMedian.Location = new System.Drawing.Point(87, 189);
            this.ivtxtFilterMedian.Name = "ivtxtFilterMedian";
            this.ivtxtFilterMedian.Size = new System.Drawing.Size(24, 20);
            this.ivtxtFilterMedian.TabIndex = 63;
            this.ivtxtFilterMedian.Text = "1";
            this.ivtxtFilterMedian.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ivtxtFilterMedian.Value = 1;
            // 
            // ivtxtPreDilatationCount
            // 
            this.ivtxtPreDilatationCount.DefaultValue = 1;
            this.ivtxtPreDilatationCount.Location = new System.Drawing.Point(87, 212);
            this.ivtxtPreDilatationCount.Name = "ivtxtPreDilatationCount";
            this.ivtxtPreDilatationCount.Size = new System.Drawing.Size(24, 20);
            this.ivtxtPreDilatationCount.TabIndex = 63;
            this.ivtxtPreDilatationCount.Text = "1";
            this.ivtxtPreDilatationCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ivtxtPreDilatationCount.Value = 1;
            // 
            // chkFilterPreDilatation
            // 
            this.chkFilterPreDilatation.AutoSize = true;
            this.chkFilterPreDilatation.Location = new System.Drawing.Point(5, 214);
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
            this.ivtxtDilatationCount.Location = new System.Drawing.Point(87, 258);
            this.ivtxtDilatationCount.Name = "ivtxtDilatationCount";
            this.ivtxtDilatationCount.Size = new System.Drawing.Size(24, 20);
            this.ivtxtDilatationCount.TabIndex = 61;
            this.ivtxtDilatationCount.Text = "1";
            this.ivtxtDilatationCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ivtxtDilatationCount.Value = 1;
            // 
            // ivtxtErosionCount
            // 
            this.ivtxtErosionCount.DefaultValue = 1;
            this.ivtxtErosionCount.Location = new System.Drawing.Point(87, 235);
            this.ivtxtErosionCount.Name = "ivtxtErosionCount";
            this.ivtxtErosionCount.Size = new System.Drawing.Size(24, 20);
            this.ivtxtErosionCount.TabIndex = 60;
            this.ivtxtErosionCount.Text = "10";
            this.ivtxtErosionCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ivtxtErosionCount.Value = 10;
            // 
            // chkFilterAdaptiveSmoothing
            // 
            this.chkFilterAdaptiveSmoothing.AutoSize = true;
            this.chkFilterAdaptiveSmoothing.Location = new System.Drawing.Point(5, 169);
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
            this.btnApplyFilter.Location = new System.Drawing.Point(111, 477);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(79, 23);
            this.btnApplyFilter.TabIndex = 58;
            this.btnApplyFilter.Text = "Show Filtered";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // chkFilterRemoveIsolatedPixels
            // 
            this.chkFilterRemoveIsolatedPixels.AutoSize = true;
            this.chkFilterRemoveIsolatedPixels.Location = new System.Drawing.Point(5, 146);
            this.chkFilterRemoveIsolatedPixels.Name = "chkFilterRemoveIsolatedPixels";
            this.chkFilterRemoveIsolatedPixels.Size = new System.Drawing.Size(85, 17);
            this.chkFilterRemoveIsolatedPixels.TabIndex = 55;
            this.chkFilterRemoveIsolatedPixels.Text = "Rm. Isolated";
            this.chkFilterRemoveIsolatedPixels.UseVisualStyleBackColor = true;
            // 
            // rtxt
            // 
            this.rtxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt.Location = new System.Drawing.Point(0, 0);
            this.rtxt.Name = "rtxt";
            this.rtxt.Size = new System.Drawing.Size(693, 83);
            this.rtxt.TabIndex = 59;
            this.rtxt.Text = "";
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // txtExtractThreshold
            // 
            this.txtExtractThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtractThreshold.Location = new System.Drawing.Point(645, 489);
            this.txtExtractThreshold.Name = "txtExtractThreshold";
            this.txtExtractThreshold.Size = new System.Drawing.Size(39, 20);
            this.txtExtractThreshold.TabIndex = 51;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(4, 58);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.tbExtractThreshold);
            this.splitContainer1.Panel1.Controls.Add(this.picBox);
            this.splitContainer1.Panel1.Controls.Add(this.txtExtractThreshold);
            this.splitContainer1.Panel1.Controls.Add(this.grpOCRFilter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtxt);
            this.splitContainer1.Size = new System.Drawing.Size(693, 599);
            this.splitContainer1.SplitterDistance = 512;
            this.splitContainer1.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(640, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "out threshold";
            // 
            // tbExtractThreshold
            // 
            this.tbExtractThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExtractThreshold.Location = new System.Drawing.Point(645, 23);
            this.tbExtractThreshold.Maximum = 255;
            this.tbExtractThreshold.Name = "tbExtractThreshold";
            this.tbExtractThreshold.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbExtractThreshold.Size = new System.Drawing.Size(45, 460);
            this.tbExtractThreshold.TabIndex = 59;
            this.tbExtractThreshold.TickFrequency = 8;
            this.tbExtractThreshold.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbExtractThreshold.Value = 63;
            // 
            // ExtractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 658);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpParts);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "ExtractForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Extract Pattern";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExtractForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.cmsPicBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.grpParts.ResumeLayout(false);
            this.grpParts.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.grpOCRFilter.ResumeLayout(false);
            this.grpOCRFilter.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbExtractThreshold)).EndInit();
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
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.GroupBox grpParts;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnShowOriginal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkProcessStep2;
        private System.Windows.Forms.CheckBox chkProcessStep1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox txtMedianVal;
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
        private System.Windows.Forms.ContextMenuStrip cmsPicBox;
        private System.Windows.Forms.ToolStripMenuItem tsmiPicBoxSaveAs;
        private IntegerValueTextBox ivtxtFilterRemoveIsolatedPixelsP1;
        private System.Windows.Forms.CheckBox chkFilterRemoveIsolatedPixels;
        private IntegerValueTextBox ivtxtFilterRemoveIsolatedPixelsP2;
        private DoubleValueTextBox dvtxtGrayScaleRed;
        private DoubleValueTextBox dvtxtGrayScaleBlue;
        private DoubleValueTextBox dvtxtGrayScaleGreen;
        private System.Windows.Forms.TextBox txtExtractThreshold;
        private System.Windows.Forms.CheckBox chkTrimParts;
        private IntegerValueTextBox tvtxtTrimPartsSize;
        private System.Windows.Forms.CheckBox chkFilterContrast;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TrackBar tbExtractThreshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSPCACR;
    }
}