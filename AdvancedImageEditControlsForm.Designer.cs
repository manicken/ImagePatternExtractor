namespace WeaveImagePatternExtractor
{
    partial class AdvancedImageEditControlsForm
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
            this.grpContrastAdj = new System.Windows.Forms.GroupBox();
            this.btnContrastPreview = new System.Windows.Forms.Button();
            this.btnContrastReset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRedContrast = new System.Windows.Forms.TrackBar();
            this.tbGreenContrast = new System.Windows.Forms.TrackBar();
            this.txtBlueContrastValue = new System.Windows.Forms.TextBox();
            this.tbBlueContrast = new System.Windows.Forms.TrackBar();
            this.btnContrastApply = new System.Windows.Forms.Button();
            this.txtGreenContrastValue = new System.Windows.Forms.TextBox();
            this.txtRedContrastValue = new System.Windows.Forms.TextBox();
            this.grpContrastAdj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRedContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreenContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlueContrast)).BeginInit();
            this.SuspendLayout();
            // 
            // grpContrastAdj
            // 
            this.grpContrastAdj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpContrastAdj.Controls.Add(this.btnContrastPreview);
            this.grpContrastAdj.Controls.Add(this.btnContrastReset);
            this.grpContrastAdj.Controls.Add(this.label3);
            this.grpContrastAdj.Controls.Add(this.label2);
            this.grpContrastAdj.Controls.Add(this.label1);
            this.grpContrastAdj.Controls.Add(this.tbRedContrast);
            this.grpContrastAdj.Controls.Add(this.tbGreenContrast);
            this.grpContrastAdj.Controls.Add(this.txtBlueContrastValue);
            this.grpContrastAdj.Controls.Add(this.tbBlueContrast);
            this.grpContrastAdj.Controls.Add(this.btnContrastApply);
            this.grpContrastAdj.Controls.Add(this.txtGreenContrastValue);
            this.grpContrastAdj.Controls.Add(this.txtRedContrastValue);
            this.grpContrastAdj.Location = new System.Drawing.Point(2, 2);
            this.grpContrastAdj.Name = "grpContrastAdj";
            this.grpContrastAdj.Size = new System.Drawing.Size(159, 506);
            this.grpContrastAdj.TabIndex = 47;
            this.grpContrastAdj.TabStop = false;
            this.grpContrastAdj.Text = "Contrast Adjustment:";
            // 
            // btnContrastPreview
            // 
            this.btnContrastPreview.Location = new System.Drawing.Point(99, 473);
            this.btnContrastPreview.Name = "btnContrastPreview";
            this.btnContrastPreview.Size = new System.Drawing.Size(56, 24);
            this.btnContrastPreview.TabIndex = 51;
            this.btnContrastPreview.Text = "preview";
            this.btnContrastPreview.UseVisualStyleBackColor = true;
            this.btnContrastPreview.Click += new System.EventHandler(this.btnContrastPreview_Click);
            // 
            // btnContrastReset
            // 
            this.btnContrastReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContrastReset.Location = new System.Drawing.Point(54, 473);
            this.btnContrastReset.Name = "btnContrastReset";
            this.btnContrastReset.Size = new System.Drawing.Size(38, 24);
            this.btnContrastReset.TabIndex = 50;
            this.btnContrastReset.Text = "reset";
            this.btnContrastReset.UseVisualStyleBackColor = true;
            this.btnContrastReset.Click += new System.EventHandler(this.btnResetContrast_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(122, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 49;
            this.label3.Text = "B";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 48;
            this.label2.Text = "G";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 16);
            this.label1.TabIndex = 47;
            this.label1.Text = "R";
            // 
            // tbRedContrast
            // 
            this.tbRedContrast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRedContrast.Location = new System.Drawing.Point(16, 37);
            this.tbRedContrast.Maximum = 100;
            this.tbRedContrast.Minimum = -100;
            this.tbRedContrast.Name = "tbRedContrast";
            this.tbRedContrast.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbRedContrast.Size = new System.Drawing.Size(45, 408);
            this.tbRedContrast.TabIndex = 36;
            this.tbRedContrast.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbRedContrast.Scroll += new System.EventHandler(this.tbRedContrast_Scroll);
            // 
            // tbGreenContrast
            // 
            this.tbGreenContrast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGreenContrast.Location = new System.Drawing.Point(63, 37);
            this.tbGreenContrast.Maximum = 100;
            this.tbGreenContrast.Minimum = -100;
            this.tbGreenContrast.Name = "tbGreenContrast";
            this.tbGreenContrast.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbGreenContrast.Size = new System.Drawing.Size(45, 408);
            this.tbGreenContrast.TabIndex = 39;
            this.tbGreenContrast.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbGreenContrast.Scroll += new System.EventHandler(this.tbGreenContrast_Scroll);
            // 
            // txtBlueContrastValue
            // 
            this.txtBlueContrastValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlueContrastValue.Location = new System.Drawing.Point(109, 447);
            this.txtBlueContrastValue.Name = "txtBlueContrastValue";
            this.txtBlueContrastValue.Size = new System.Drawing.Size(39, 20);
            this.txtBlueContrastValue.TabIndex = 44;
            // 
            // tbBlueContrast
            // 
            this.tbBlueContrast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBlueContrast.Location = new System.Drawing.Point(108, 37);
            this.tbBlueContrast.Maximum = 100;
            this.tbBlueContrast.Minimum = -100;
            this.tbBlueContrast.Name = "tbBlueContrast";
            this.tbBlueContrast.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbBlueContrast.Size = new System.Drawing.Size(45, 408);
            this.tbBlueContrast.TabIndex = 40;
            this.tbBlueContrast.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbBlueContrast.Scroll += new System.EventHandler(this.tbBlueContrast_Scroll);
            // 
            // btnContrastApply
            // 
            this.btnContrastApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContrastApply.Location = new System.Drawing.Point(6, 473);
            this.btnContrastApply.Name = "btnContrastApply";
            this.btnContrastApply.Size = new System.Drawing.Size(40, 24);
            this.btnContrastApply.TabIndex = 37;
            this.btnContrastApply.Text = "apply";
            this.btnContrastApply.UseVisualStyleBackColor = true;
            this.btnContrastApply.Click += new System.EventHandler(this.btnApplyContrast_Click);
            // 
            // txtGreenContrastValue
            // 
            this.txtGreenContrastValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGreenContrastValue.Location = new System.Drawing.Point(64, 447);
            this.txtGreenContrastValue.Name = "txtGreenContrastValue";
            this.txtGreenContrastValue.Size = new System.Drawing.Size(39, 20);
            this.txtGreenContrastValue.TabIndex = 42;
            // 
            // txtRedContrastValue
            // 
            this.txtRedContrastValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRedContrastValue.Location = new System.Drawing.Point(19, 447);
            this.txtRedContrastValue.Name = "txtRedContrastValue";
            this.txtRedContrastValue.Size = new System.Drawing.Size(39, 20);
            this.txtRedContrastValue.TabIndex = 38;
            // 
            // AdvancedImageEditControlsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(173, 509);
            this.Controls.Add(this.grpContrastAdj);
            this.Name = "AdvancedImageEditControlsForm";
            this.Text = "AdvancedImageEditControlsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdvancedImageEditControlsForm_FormClosing);
            this.grpContrastAdj.ResumeLayout(false);
            this.grpContrastAdj.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbRedContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreenContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlueContrast)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpContrastAdj;
        private System.Windows.Forms.Button btnContrastReset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbRedContrast;
        private System.Windows.Forms.TrackBar tbGreenContrast;
        private System.Windows.Forms.TextBox txtBlueContrastValue;
        private System.Windows.Forms.TrackBar tbBlueContrast;
        private System.Windows.Forms.Button btnContrastApply;
        private System.Windows.Forms.TextBox txtGreenContrastValue;
        private System.Windows.Forms.TextBox txtRedContrastValue;
        private System.Windows.Forms.Button btnContrastPreview;
    }
}