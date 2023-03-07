namespace WeaveImagePatternExtractor
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblEditColor2 = new System.Windows.Forms.Label();
            this.lblEditColor1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSavePatternAs = new System.Windows.Forms.Button();
            this.picEditor = new System.Windows.Forms.PictureBox();
            this.btnSavePattern = new System.Windows.Forms.Button();
            this.btnUpdateEditor = new System.Windows.Forms.Button();
            this.btnOpenPattern = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnUpdatePreview = new System.Windows.Forms.Button();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiOpenExtractForm = new System.Windows.Forms.ToolStripMenuItem();
            this.txtEditorImageHeight = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.txtEditorImageWidth = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.txtY = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.txtX = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.txtEditorPixelSpacing = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.txtEditorPixelSize = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.txtPreviewPixelSpacing = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.txtPreviewPixelSize = new WeaveImagePatternExtractor.IntegerValueTextBox();
            this.tsmiOpenPatternFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSavePatternFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSavePatternFileAs = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(3, 27);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel1.Controls.Add(this.txtEditorImageHeight);
            this.splitContainer2.Panel1.Controls.Add(this.txtEditorImageWidth);
            this.splitContainer2.Panel1.Controls.Add(this.label13);
            this.splitContainer2.Panel1.Controls.Add(this.label12);
            this.splitContainer2.Panel1.Controls.Add(this.txtY);
            this.splitContainer2.Panel1.Controls.Add(this.btnSavePatternAs);
            this.splitContainer2.Panel1.Controls.Add(this.txtX);
            this.splitContainer2.Panel1.Controls.Add(this.picEditor);
            this.splitContainer2.Panel1.Controls.Add(this.btnSavePattern);
            this.splitContainer2.Panel1.Controls.Add(this.btnUpdateEditor);
            this.splitContainer2.Panel1.Controls.Add(this.btnOpenPattern);
            this.splitContainer2.Panel1.Controls.Add(this.label8);
            this.splitContainer2.Panel1.Controls.Add(this.label9);
            this.splitContainer2.Panel1.Controls.Add(this.txtEditorPixelSpacing);
            this.splitContainer2.Panel1.Controls.Add(this.txtEditorPixelSize);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnUpdatePreview);
            this.splitContainer2.Panel2.Controls.Add(this.txtPreviewPixelSpacing);
            this.splitContainer2.Panel2.Controls.Add(this.picPreview);
            this.splitContainer2.Panel2.Controls.Add(this.label10);
            this.splitContainer2.Panel2.Controls.Add(this.label11);
            this.splitContainer2.Panel2.Controls.Add(this.txtPreviewPixelSize);
            this.splitContainer2.Size = new System.Drawing.Size(867, 603);
            this.splitContainer2.SplitterDistance = 387;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.lblEditColor2);
            this.groupBox3.Controls.Add(this.lblEditColor1);
            this.groupBox3.Location = new System.Drawing.Point(246, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 55);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "edit colors";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(44, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 32);
            this.button1.TabIndex = 24;
            this.button1.Text = "<-\r\n->";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblEditColor2
            // 
            this.lblEditColor2.BackColor = System.Drawing.Color.White;
            this.lblEditColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEditColor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditColor2.ForeColor = System.Drawing.Color.White;
            this.lblEditColor2.Location = new System.Drawing.Point(86, 17);
            this.lblEditColor2.Name = "lblEditColor2";
            this.lblEditColor2.Size = new System.Drawing.Size(32, 32);
            this.lblEditColor2.TabIndex = 23;
            this.lblEditColor2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEditColor1
            // 
            this.lblEditColor1.BackColor = System.Drawing.Color.Black;
            this.lblEditColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEditColor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditColor1.Location = new System.Drawing.Point(6, 17);
            this.lblEditColor1.Name = "lblEditColor1";
            this.lblEditColor1.Size = new System.Drawing.Size(32, 32);
            this.lblEditColor1.TabIndex = 22;
            this.lblEditColor1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(160, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Height:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(161, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Width:";
            // 
            // btnSavePatternAs
            // 
            this.btnSavePatternAs.Location = new System.Drawing.Point(165, 3);
            this.btnSavePatternAs.Name = "btnSavePatternAs";
            this.btnSavePatternAs.Size = new System.Drawing.Size(75, 23);
            this.btnSavePatternAs.TabIndex = 34;
            this.btnSavePatternAs.Text = "save file as..";
            this.btnSavePatternAs.UseVisualStyleBackColor = true;
            this.btnSavePatternAs.Click += new System.EventHandler(this.btnSavePatternAs_Click);
            // 
            // picEditor
            // 
            this.picEditor.BackColor = System.Drawing.Color.Gray;
            this.picEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEditor.Location = new System.Drawing.Point(3, 89);
            this.picEditor.Name = "picEditor";
            this.picEditor.Size = new System.Drawing.Size(264, 343);
            this.picEditor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picEditor.TabIndex = 1;
            this.picEditor.TabStop = false;
            this.picEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picEditor_MouseDown);
            this.picEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picEditor_MouseMove);
            this.picEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picEditor_MouseUp);
            // 
            // btnSavePattern
            // 
            this.btnSavePattern.Location = new System.Drawing.Point(84, 3);
            this.btnSavePattern.Name = "btnSavePattern";
            this.btnSavePattern.Size = new System.Drawing.Size(75, 23);
            this.btnSavePattern.TabIndex = 33;
            this.btnSavePattern.Text = "save file";
            this.btnSavePattern.UseVisualStyleBackColor = true;
            this.btnSavePattern.Click += new System.EventHandler(this.btnSavePattern_Click);
            // 
            // btnUpdateEditor
            // 
            this.btnUpdateEditor.Location = new System.Drawing.Point(306, 5);
            this.btnUpdateEditor.Name = "btnUpdateEditor";
            this.btnUpdateEditor.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateEditor.TabIndex = 28;
            this.btnUpdateEditor.Text = "update";
            this.btnUpdateEditor.UseVisualStyleBackColor = true;
            this.btnUpdateEditor.Click += new System.EventHandler(this.btnUpdateEditor_Click);
            // 
            // btnOpenPattern
            // 
            this.btnOpenPattern.Location = new System.Drawing.Point(3, 3);
            this.btnOpenPattern.Name = "btnOpenPattern";
            this.btnOpenPattern.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPattern.TabIndex = 32;
            this.btnOpenPattern.Text = "open file";
            this.btnOpenPattern.UseVisualStyleBackColor = true;
            this.btnOpenPattern.Click += new System.EventHandler(this.btnOpenPattern_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Editor Pixel Size:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Editor Pixel Spacing:";
            // 
            // btnUpdatePreview
            // 
            this.btnUpdatePreview.Location = new System.Drawing.Point(174, 32);
            this.btnUpdatePreview.Name = "btnUpdatePreview";
            this.btnUpdatePreview.Size = new System.Drawing.Size(75, 23);
            this.btnUpdatePreview.TabIndex = 29;
            this.btnUpdatePreview.Text = "update";
            this.btnUpdatePreview.UseVisualStyleBackColor = true;
            this.btnUpdatePreview.Click += new System.EventHandler(this.btnUpdatePreview_Click);
            // 
            // picPreview
            // 
            this.picPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPreview.Location = new System.Drawing.Point(0, 89);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(453, 514);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Preview Pixel Spacing:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Preview Pixel Size:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 636);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(400, 20);
            this.textBox1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenExtractForm,
            this.tsmiOpenPatternFile,
            this.tsmiSavePatternFile,
            this.tsmiSavePatternFileAs});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(870, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiOpenExtractForm
            // 
            this.tsmiOpenExtractForm.BackColor = System.Drawing.Color.Silver;
            this.tsmiOpenExtractForm.Name = "tsmiOpenExtractForm";
            this.tsmiOpenExtractForm.Size = new System.Drawing.Size(139, 20);
            this.tsmiOpenExtractForm.Text = "Open Pattern &Extractor";
            this.tsmiOpenExtractForm.Click += new System.EventHandler(this.tsmiOpenExtractForm_Click);
            // 
            // txtEditorImageHeight
            // 
            this.txtEditorImageHeight.DefaultValue = 1;
            this.txtEditorImageHeight.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditorImageHeight.Location = new System.Drawing.Point(199, 54);
            this.txtEditorImageHeight.Name = "txtEditorImageHeight";
            this.txtEditorImageHeight.Size = new System.Drawing.Size(41, 22);
            this.txtEditorImageHeight.TabIndex = 38;
            this.txtEditorImageHeight.Text = "20";
            this.txtEditorImageHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEditorImageHeight.Value = 20;
            // 
            // txtEditorImageWidth
            // 
            this.txtEditorImageWidth.DefaultValue = 1;
            this.txtEditorImageWidth.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditorImageWidth.Location = new System.Drawing.Point(199, 32);
            this.txtEditorImageWidth.Name = "txtEditorImageWidth";
            this.txtEditorImageWidth.Size = new System.Drawing.Size(41, 22);
            this.txtEditorImageWidth.TabIndex = 37;
            this.txtEditorImageWidth.Text = "20";
            this.txtEditorImageWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEditorImageWidth.Value = 20;
            // 
            // txtY
            // 
            this.txtY.DefaultValue = 0;
            this.txtY.Location = new System.Drawing.Point(277, 5);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(22, 20);
            this.txtY.TabIndex = 31;
            this.txtY.Text = "0";
            this.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtY.Value = 0;
            // 
            // txtX
            // 
            this.txtX.DefaultValue = 0;
            this.txtX.Location = new System.Drawing.Point(246, 5);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(25, 20);
            this.txtX.TabIndex = 30;
            this.txtX.Text = "0";
            this.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtX.Value = 0;
            // 
            // txtEditorPixelSpacing
            // 
            this.txtEditorPixelSpacing.DefaultValue = 0;
            this.txtEditorPixelSpacing.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditorPixelSpacing.Location = new System.Drawing.Point(113, 54);
            this.txtEditorPixelSpacing.Name = "txtEditorPixelSpacing";
            this.txtEditorPixelSpacing.Size = new System.Drawing.Size(41, 22);
            this.txtEditorPixelSpacing.TabIndex = 23;
            this.txtEditorPixelSpacing.Text = "1";
            this.txtEditorPixelSpacing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEditorPixelSpacing.Value = 1;
            // 
            // txtEditorPixelSize
            // 
            this.txtEditorPixelSize.DefaultValue = 1;
            this.txtEditorPixelSize.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditorPixelSize.Location = new System.Drawing.Point(113, 32);
            this.txtEditorPixelSize.Name = "txtEditorPixelSize";
            this.txtEditorPixelSize.Size = new System.Drawing.Size(41, 22);
            this.txtEditorPixelSize.TabIndex = 21;
            this.txtEditorPixelSize.Text = "10";
            this.txtEditorPixelSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEditorPixelSize.Value = 10;
            // 
            // txtPreviewPixelSpacing
            // 
            this.txtPreviewPixelSpacing.DefaultValue = 0;
            this.txtPreviewPixelSpacing.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreviewPixelSpacing.Location = new System.Drawing.Point(127, 33);
            this.txtPreviewPixelSpacing.Name = "txtPreviewPixelSpacing";
            this.txtPreviewPixelSpacing.Size = new System.Drawing.Size(41, 22);
            this.txtPreviewPixelSpacing.TabIndex = 27;
            this.txtPreviewPixelSpacing.Text = "0";
            this.txtPreviewPixelSpacing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPreviewPixelSpacing.Value = 0;
            // 
            // txtPreviewPixelSize
            // 
            this.txtPreviewPixelSize.DefaultValue = 1;
            this.txtPreviewPixelSize.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreviewPixelSize.Location = new System.Drawing.Point(126, 5);
            this.txtPreviewPixelSize.Name = "txtPreviewPixelSize";
            this.txtPreviewPixelSize.Size = new System.Drawing.Size(41, 22);
            this.txtPreviewPixelSize.TabIndex = 25;
            this.txtPreviewPixelSize.Text = "2";
            this.txtPreviewPixelSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPreviewPixelSize.Value = 2;
            // 
            // tsmiOpenPatternFile
            // 
            this.tsmiOpenPatternFile.Name = "tsmiOpenPatternFile";
            this.tsmiOpenPatternFile.Size = new System.Drawing.Size(110, 20);
            this.tsmiOpenPatternFile.Text = "&Open Pattern File";
            this.tsmiOpenPatternFile.Click += new System.EventHandler(this.tsmiOpenPatternFile_Click);
            // 
            // tsmiSavePatternFile
            // 
            this.tsmiSavePatternFile.Name = "tsmiSavePatternFile";
            this.tsmiSavePatternFile.Size = new System.Drawing.Size(105, 20);
            this.tsmiSavePatternFile.Text = "&Save Pattern File";
            // 
            // tsmiSavePatternFileAs
            // 
            this.tsmiSavePatternFileAs.Name = "tsmiSavePatternFileAs";
            this.tsmiSavePatternFileAs.Size = new System.Drawing.Size(127, 20);
            this.tsmiSavePatternFileAs.Text = "Save Pattern File &As..";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 666);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Pattern Extractor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Move += new System.EventHandler(this.MainForm_Move);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox picEditor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label8;
        private IntegerValueTextBox txtEditorPixelSize;
        private IntegerValueTextBox txtEditorPixelSpacing;
        private System.Windows.Forms.Label label9;
        private IntegerValueTextBox txtPreviewPixelSpacing;
        private System.Windows.Forms.Label label10;
        private IntegerValueTextBox txtPreviewPixelSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnUpdateEditor;
        private System.Windows.Forms.Button btnUpdatePreview;
        private IntegerValueTextBox txtX;
        private IntegerValueTextBox txtY;
        private System.Windows.Forms.Button btnOpenPattern;
        private System.Windows.Forms.Button btnSavePattern;
        private System.Windows.Forms.Button btnSavePatternAs;
        private IntegerValueTextBox txtEditorImageHeight;
        private IntegerValueTextBox txtEditorImageWidth;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblEditColor2;
        private System.Windows.Forms.Label lblEditColor1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenExtractForm;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenPatternFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiSavePatternFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiSavePatternFileAs;
    }
}

