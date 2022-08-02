namespace PDFConverter
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnDirSelect = new System.Windows.Forms.Button();
            this.txtSelectedDir = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnConvertFiles = new System.Windows.Forms.Button();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.ckBxSubDirs = new System.Windows.Forms.CheckBox();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.ckBxDeleteOrig = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDirSelect
            // 
            this.btnDirSelect.Location = new System.Drawing.Point(12, 73);
            this.btnDirSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDirSelect.Name = "btnDirSelect";
            this.btnDirSelect.Size = new System.Drawing.Size(152, 36);
            this.btnDirSelect.TabIndex = 0;
            this.btnDirSelect.Text = "Select Directory";
            this.btnDirSelect.UseVisualStyleBackColor = true;
            this.btnDirSelect.Click += new System.EventHandler(this.btnDirSelect_Click);
            // 
            // txtSelectedDir
            // 
            this.txtSelectedDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedDir.Location = new System.Drawing.Point(175, 77);
            this.txtSelectedDir.Name = "txtSelectedDir";
            this.txtSelectedDir.Size = new System.Drawing.Size(532, 26);
            this.txtSelectedDir.TabIndex = 1;
            this.txtSelectedDir.TextChanged += new System.EventHandler(this.txtSelectedDir_TextChanged);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(16, 158);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(695, 432);
            this.txtOutput.TabIndex = 3;
            // 
            // btnConvertFiles
            // 
            this.btnConvertFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertFiles.Location = new System.Drawing.Point(551, 598);
            this.btnConvertFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConvertFiles.Name = "btnConvertFiles";
            this.btnConvertFiles.Size = new System.Drawing.Size(152, 35);
            this.btnConvertFiles.TabIndex = 4;
            this.btnConvertFiles.Text = "Convert to PDF";
            this.btnConvertFiles.UseVisualStyleBackColor = true;
            this.btnConvertFiles.Click += new System.EventHandler(this.btnConvertFiles_Click);
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Location = new System.Drawing.Point(12, 113);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(98, 20);
            this.lblFileCount.TabIndex = 5;
            this.lblFileCount.Text = "File Count: 0";
            // 
            // ckBxSubDirs
            // 
            this.ckBxSubDirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckBxSubDirs.AutoSize = true;
            this.ckBxSubDirs.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckBxSubDirs.Location = new System.Drawing.Point(521, 112);
            this.ckBxSubDirs.Name = "ckBxSubDirs";
            this.ckBxSubDirs.Size = new System.Drawing.Size(186, 24);
            this.ckBxSubDirs.TabIndex = 6;
            this.ckBxSubDirs.Text = "Include Subdirectories";
            this.ckBxSubDirs.UseVisualStyleBackColor = true;
            this.ckBxSubDirs.CheckedChanged += new System.EventHandler(this.ckBxSubDirs_CheckedChanged);
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(12, 39);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(412, 20);
            this.lblInstructions.TabIndex = 7;
            this.lblInstructions.Text = "Select a directory or drag and drop files to convert to PDF";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(16, 601);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(152, 35);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ckBxDeleteOrig
            // 
            this.ckBxDeleteOrig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckBxDeleteOrig.AutoSize = true;
            this.ckBxDeleteOrig.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckBxDeleteOrig.Location = new System.Drawing.Point(383, 112);
            this.ckBxDeleteOrig.Name = "ckBxDeleteOrig";
            this.ckBxDeleteOrig.Size = new System.Drawing.Size(132, 24);
            this.ckBxDeleteOrig.TabIndex = 9;
            this.ckBxDeleteOrig.Text = "Delete Original";
            this.ckBxDeleteOrig.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(723, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 650);
            this.Controls.Add(this.ckBxDeleteOrig);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.ckBxSubDirs);
            this.Controls.Add(this.lblFileCount);
            this.Controls.Add(this.btnConvertFiles);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtSelectedDir);
            this.Controls.Add(this.btnDirSelect);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.Text = "XPS to PDF File Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDirSelect;
        private System.Windows.Forms.TextBox txtSelectedDir;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnConvertFiles;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.CheckBox ckBxSubDirs;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox ckBxDeleteOrig;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}

