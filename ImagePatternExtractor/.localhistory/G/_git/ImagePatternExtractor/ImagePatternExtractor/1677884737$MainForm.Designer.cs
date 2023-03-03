namespace WindowsFormsApp3
{
    partial class MainForm
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
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.picEditor = new System.Windows.Forms.PictureBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtXoffset = new System.Windows.Forms.TextBox();
            this.txtYoffset = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtXparts = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYparts = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExtract = new System.Windows.Forms.Button();
            this.txtRthreshold = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBthreshold = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGthreshold = new System.Windows.Forms.TextBox();
            this.btnSwitchColors = new System.Windows.Forms.Button();
            this.lblColor2 = new System.Windows.Forms.Label();
            this.lblColor1 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEditorPixelSize = new System.Windows.Forms.TextBox();
            this.txtEditorPixelSpacing = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPreviewPixelSpacing = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPreviewPixelSize = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnUpdateEditor = new System.Windows.Forms.Button();
            this.btnUpdatePreview = new System.Windows.Forms.Button();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.btnOpenPattern = new System.Windows.Forms.Button();
            this.btnSavePattern = new System.Windows.Forms.Button();
            this.btnSavePatternAs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(5, 2);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "open file";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 92);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.picBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1210, 572);
            this.splitContainer1.SplitterDistance = 402;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 2;
            // 
            // picBox
            // 
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox.Location = new System.Drawing.Point(0, 0);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(402, 572);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            this.picBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseDown);
            this.picBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseMove);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.picEditor);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.picPreview);
            this.splitContainer2.Size = new System.Drawing.Size(800, 572);
            this.splitContainer2.SplitterDistance = 403;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 2;
            // 
            // picEditor
            // 
            this.picEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEditor.Location = new System.Drawing.Point(0, 0);
            this.picEditor.Name = "picEditor";
            this.picEditor.Size = new System.Drawing.Size(264, 343);
            this.picEditor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picEditor.TabIndex = 1;
            this.picEditor.TabStop = false;
            this.picEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picEditor_MouseDown);
            this.picEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picEditor_MouseMove);
            this.picEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picEditor_MouseUp);
            // 
            // picPreview
            // 
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPreview.Location = new System.Drawing.Point(0, 0);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(389, 572);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "xOffset:";
            // 
            // txtXoffset
            // 
            this.txtXoffset.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXoffset.Location = new System.Drawing.Point(129, 5);
            this.txtXoffset.Name = "txtXoffset";
            this.txtXoffset.Size = new System.Drawing.Size(40, 22);
            this.txtXoffset.TabIndex = 4;
            this.txtXoffset.Text = "3";
            // 
            // txtYoffset
            // 
            this.txtYoffset.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYoffset.Location = new System.Drawing.Point(211, 5);
            this.txtYoffset.Name = "txtYoffset";
            this.txtYoffset.Size = new System.Drawing.Size(40, 22);
            this.txtYoffset.TabIndex = 6;
            this.txtYoffset.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "yOffset:";
            // 
            // txtXparts
            // 
            this.txtXparts.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXparts.Location = new System.Drawing.Point(292, 6);
            this.txtXparts.Name = "txtXparts";
            this.txtXparts.Size = new System.Drawing.Size(32, 22);
            this.txtXparts.TabIndex = 8;
            this.txtXparts.Text = "24";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "x parts:";
            // 
            // txtYparts
            // 
            this.txtYparts.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYparts.Location = new System.Drawing.Point(365, 5);
            this.txtYparts.Name = "txtYparts";
            this.txtYparts.Size = new System.Drawing.Size(32, 22);
            this.txtYparts.TabIndex = 10;
            this.txtYparts.Text = "34";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(326, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "y parts:";
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(330, 48);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(75, 32);
            this.btnExtract.TabIndex = 11;
            this.btnExtract.Text = "extract";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // txtRthreshold
            // 
            this.txtRthreshold.Location = new System.Drawing.Point(24, 17);
            this.txtRthreshold.Name = "txtRthreshold";
            this.txtRthreshold.Size = new System.Drawing.Size(32, 20);
            this.txtRthreshold.TabIndex = 13;
            this.txtRthreshold.Text = "128";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtBthreshold);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtGthreshold);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtRthreshold);
            this.groupBox1.Location = new System.Drawing.Point(5, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 55);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "thresholds";
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
            this.txtBthreshold.Location = new System.Drawing.Point(136, 17);
            this.txtBthreshold.Name = "txtBthreshold";
            this.txtBthreshold.Size = new System.Drawing.Size(32, 20);
            this.txtBthreshold.TabIndex = 17;
            this.txtBthreshold.Text = "128";
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
            this.txtGthreshold.Location = new System.Drawing.Point(80, 17);
            this.txtGthreshold.Name = "txtGthreshold";
            this.txtGthreshold.Size = new System.Drawing.Size(32, 20);
            this.txtGthreshold.TabIndex = 15;
            this.txtGthreshold.Text = "128";
            // 
            // btnSwitchColors
            // 
            this.btnSwitchColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitchColors.Location = new System.Drawing.Point(44, 17);
            this.btnSwitchColors.Name = "btnSwitchColors";
            this.btnSwitchColors.Size = new System.Drawing.Size(36, 32);
            this.btnSwitchColors.TabIndex = 24;
            this.btnSwitchColors.Text = "<-\r\n->";
            this.btnSwitchColors.UseVisualStyleBackColor = true;
            this.btnSwitchColors.Click += new System.EventHandler(this.btnSwitchColors_Click);
            // 
            // lblColor2
            // 
            this.lblColor2.BackColor = System.Drawing.Color.Black;
            this.lblColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor2.ForeColor = System.Drawing.Color.White;
            this.lblColor2.Location = new System.Drawing.Point(86, 17);
            this.lblColor2.Name = "lblColor2";
            this.lblColor2.Size = new System.Drawing.Size(32, 32);
            this.lblColor2.TabIndex = 23;
            this.lblColor2.Text = "<";
            this.lblColor2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblColor2.Click += new System.EventHandler(this.lblColor2_Click);
            // 
            // lblColor1
            // 
            this.lblColor1.BackColor = System.Drawing.Color.White;
            this.lblColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor1.Location = new System.Drawing.Point(6, 17);
            this.lblColor1.Name = "lblColor1";
            this.lblColor1.Size = new System.Drawing.Size(32, 32);
            this.lblColor1.TabIndex = 22;
            this.lblColor1.Text = ">";
            this.lblColor1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblColor1.Click += new System.EventHandler(this.lblColor1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSwitchColors);
            this.groupBox2.Controls.Add(this.lblColor2);
            this.groupBox2.Controls.Add(this.lblColor1);
            this.groupBox2.Location = new System.Drawing.Point(189, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 55);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "output colors";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(441, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Editor Pixel Size:";
            // 
            // txtEditorPixelSize
            // 
            this.txtEditorPixelSize.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditorPixelSize.Location = new System.Drawing.Point(549, 37);
            this.txtEditorPixelSize.Name = "txtEditorPixelSize";
            this.txtEditorPixelSize.Size = new System.Drawing.Size(41, 22);
            this.txtEditorPixelSize.TabIndex = 21;
            this.txtEditorPixelSize.Text = "10";
            // 
            // txtEditorPixelSpacing
            // 
            this.txtEditorPixelSpacing.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditorPixelSpacing.Location = new System.Drawing.Point(549, 65);
            this.txtEditorPixelSpacing.Name = "txtEditorPixelSpacing";
            this.txtEditorPixelSpacing.Size = new System.Drawing.Size(41, 22);
            this.txtEditorPixelSpacing.TabIndex = 23;
            this.txtEditorPixelSpacing.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(441, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Editor Pixel Spacing:";
            // 
            // txtPreviewPixelSpacing
            // 
            this.txtPreviewPixelSpacing.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreviewPixelSpacing.Location = new System.Drawing.Point(951, 44);
            this.txtPreviewPixelSpacing.Name = "txtPreviewPixelSpacing";
            this.txtPreviewPixelSpacing.Size = new System.Drawing.Size(41, 22);
            this.txtPreviewPixelSpacing.TabIndex = 27;
            this.txtPreviewPixelSpacing.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(837, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Preview Pixel Spacing:";
            // 
            // txtPreviewPixelSize
            // 
            this.txtPreviewPixelSize.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreviewPixelSize.Location = new System.Drawing.Point(950, 16);
            this.txtPreviewPixelSize.Name = "txtPreviewPixelSize";
            this.txtPreviewPixelSize.Size = new System.Drawing.Size(41, 22);
            this.txtPreviewPixelSize.TabIndex = 25;
            this.txtPreviewPixelSize.Text = "2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(837, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Preview Pixel Size:";
            // 
            // btnUpdateEditor
            // 
            this.btnUpdateEditor.Location = new System.Drawing.Point(596, 64);
            this.btnUpdateEditor.Name = "btnUpdateEditor";
            this.btnUpdateEditor.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateEditor.TabIndex = 28;
            this.btnUpdateEditor.Text = "update";
            this.btnUpdateEditor.UseVisualStyleBackColor = true;
            this.btnUpdateEditor.Click += new System.EventHandler(this.btnUpdateEditor_Click);
            // 
            // btnUpdatePreview
            // 
            this.btnUpdatePreview.Location = new System.Drawing.Point(998, 43);
            this.btnUpdatePreview.Name = "btnUpdatePreview";
            this.btnUpdatePreview.Size = new System.Drawing.Size(75, 23);
            this.btnUpdatePreview.TabIndex = 29;
            this.btnUpdatePreview.Text = "update";
            this.btnUpdatePreview.UseVisualStyleBackColor = true;
            this.btnUpdatePreview.Click += new System.EventHandler(this.btnUpdatePreview_Click);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(693, 37);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(100, 20);
            this.txtX.TabIndex = 30;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(693, 62);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(100, 20);
            this.txtY.TabIndex = 31;
            // 
            // btnOpenPattern
            // 
            this.btnOpenPattern.Location = new System.Drawing.Point(413, 4);
            this.btnOpenPattern.Name = "btnOpenPattern";
            this.btnOpenPattern.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPattern.TabIndex = 32;
            this.btnOpenPattern.Text = "open file";
            this.btnOpenPattern.UseVisualStyleBackColor = true;
            this.btnOpenPattern.Click += new System.EventHandler(this.btnOpenPattern_Click);
            // 
            // btnSavePattern
            // 
            this.btnSavePattern.Location = new System.Drawing.Point(494, 4);
            this.btnSavePattern.Name = "btnSavePattern";
            this.btnSavePattern.Size = new System.Drawing.Size(75, 23);
            this.btnSavePattern.TabIndex = 33;
            this.btnSavePattern.Text = "save file";
            this.btnSavePattern.UseVisualStyleBackColor = true;
            // 
            // btnSavePatternAs
            // 
            this.btnSavePatternAs.Location = new System.Drawing.Point(575, 4);
            this.btnSavePatternAs.Name = "btnSavePatternAs";
            this.btnSavePatternAs.Size = new System.Drawing.Size(75, 23);
            this.btnSavePatternAs.TabIndex = 34;
            this.btnSavePatternAs.Text = "save file as..";
            this.btnSavePatternAs.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 666);
            this.Controls.Add(this.btnSavePatternAs);
            this.Controls.Add(this.btnSavePattern);
            this.Controls.Add(this.btnOpenPattern);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.btnUpdatePreview);
            this.Controls.Add(this.btnUpdateEditor);
            this.Controls.Add(this.txtPreviewPixelSpacing);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPreviewPixelSize);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtEditorPixelSpacing);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtEditorPixelSize);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.txtYparts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtXparts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYoffset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtXoffset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtXoffset;
        private System.Windows.Forms.TextBox txtYoffset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtXparts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYparts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.TextBox txtRthreshold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBthreshold;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGthreshold;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox picEditor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lblColor1;
        private System.Windows.Forms.Label lblColor2;
        private System.Windows.Forms.Button btnSwitchColors;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEditorPixelSize;
        private System.Windows.Forms.TextBox txtEditorPixelSpacing;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPreviewPixelSpacing;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPreviewPixelSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnUpdateEditor;
        private System.Windows.Forms.Button btnUpdatePreview;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Button btnOpenPattern;
        private System.Windows.Forms.Button btnSavePattern;
        private System.Windows.Forms.Button btnSavePatternAs;
    }
}

