namespace Hash_KillRowan_Project4
{
    partial class frmHash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHash));
            this.btnHash = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblAlgorithmChoice = new System.Windows.Forms.Label();
            this.cboAlgorithm = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblResults = new System.Windows.Forms.Label();
            this.lblHashPath = new System.Windows.Forms.Label();
            this.lblHashFolder = new System.Windows.Forms.Label();
            this.txtHashResult = new System.Windows.Forms.TextBox();
            this.txtHashPathResult = new System.Windows.Forms.TextBox();
            this.lblResetBtnInfo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHash
            // 
            this.btnHash.Location = new System.Drawing.Point(340, 178);
            this.btnHash.Name = "btnHash";
            this.btnHash.Size = new System.Drawing.Size(115, 23);
            this.btnHash.TabIndex = 2;
            this.btnHash.Text = "Hash File Location";
            this.btnHash.UseVisualStyleBackColor = true;
            this.btnHash.Click += new System.EventHandler(this.btnHash_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(12, 149);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(57, 13);
            this.lblFileName.TabIndex = 8;
            this.lblFileName.Text = "File Name:";
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(75, 147);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(727, 20);
            this.txtFileName.TabIndex = 0;
            this.txtFileName.Text = "example.txt";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(340, 227);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblAlgorithmChoice
            // 
            this.lblAlgorithmChoice.AutoSize = true;
            this.lblAlgorithmChoice.Location = new System.Drawing.Point(12, 183);
            this.lblAlgorithmChoice.Name = "lblAlgorithmChoice";
            this.lblAlgorithmChoice.Size = new System.Drawing.Size(95, 13);
            this.lblAlgorithmChoice.TabIndex = 9;
            this.lblAlgorithmChoice.Text = "Hashing Algorithm:";
            // 
            // cboAlgorithm
            // 
            this.cboAlgorithm.DropDownHeight = 130;
            this.cboAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlgorithm.FormattingEnabled = true;
            this.cboAlgorithm.IntegralHeight = false;
            this.cboAlgorithm.Items.AddRange(new object[] {
            "AES",
            "DES",
            "TripleDES",
            "MD5",
            "RC2",
            "Rijndael",
            "RIPEMD160",
            "SHA1",
            "SHA256",
            "SHA384",
            "SHA512",
            "HMAC-MD5",
            "HMAC-RIPEMD160",
            "HMAC-SHA1",
            "HMAC-SHA256",
            "HMAC-SHA384",
            "HMAC-SHA512"});
            this.cboAlgorithm.Location = new System.Drawing.Point(113, 180);
            this.cboAlgorithm.Name = "cboAlgorithm";
            this.cboAlgorithm.Size = new System.Drawing.Size(190, 21);
            this.cboAlgorithm.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(727, 567);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Location = new System.Drawing.Point(12, 34);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(790, 108);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = resources.GetString("lblInfo.Text");
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(12, 354);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(128, 13);
            this.lblResults.TabIndex = 11;
            this.lblResults.Text = "Results of hash algorithm:";
            // 
            // lblHashPath
            // 
            this.lblHashPath.AutoSize = true;
            this.lblHashPath.Location = new System.Drawing.Point(55, 481);
            this.lblHashPath.Name = "lblHashPath";
            this.lblHashPath.Size = new System.Drawing.Size(72, 13);
            this.lblHashPath.TabIndex = 13;
            this.lblHashPath.Text = "Hashed Path:";
            // 
            // lblHashFolder
            // 
            this.lblHashFolder.AutoSize = true;
            this.lblHashFolder.Location = new System.Drawing.Point(55, 394);
            this.lblHashFolder.Name = "lblHashFolder";
            this.lblHashFolder.Size = new System.Drawing.Size(79, 13);
            this.lblHashFolder.TabIndex = 12;
            this.lblHashFolder.Text = "Hashed Folder:";
            // 
            // txtHashResult
            // 
            this.txtHashResult.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHashResult.Location = new System.Drawing.Point(140, 391);
            this.txtHashResult.Multiline = true;
            this.txtHashResult.Name = "txtHashResult";
            this.txtHashResult.ReadOnly = true;
            this.txtHashResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHashResult.Size = new System.Drawing.Size(662, 81);
            this.txtHashResult.TabIndex = 4;
            // 
            // txtHashPathResult
            // 
            this.txtHashPathResult.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHashPathResult.Location = new System.Drawing.Point(133, 478);
            this.txtHashPathResult.Multiline = true;
            this.txtHashPathResult.Name = "txtHashPathResult";
            this.txtHashPathResult.ReadOnly = true;
            this.txtHashPathResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHashPathResult.Size = new System.Drawing.Size(669, 83);
            this.txtHashPathResult.TabIndex = 5;
            // 
            // lblResetBtnInfo
            // 
            this.lblResetBtnInfo.AutoSize = true;
            this.lblResetBtnInfo.Location = new System.Drawing.Point(337, 253);
            this.lblResetBtnInfo.Name = "lblResetBtnInfo";
            this.lblResetBtnInfo.Size = new System.Drawing.Size(119, 26);
            this.lblResetBtnInfo.TabIndex = 10;
            this.lblResetBtnInfo.Text = "The reset button clears\r\n  all data in this window.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(242, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(346, 25);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Hide Files with Hash Algorithms";
            // 
            // frmHash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 602);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblResetBtnInfo);
            this.Controls.Add(this.txtHashPathResult);
            this.Controls.Add(this.txtHashResult);
            this.Controls.Add(this.lblHashFolder);
            this.Controls.Add(this.lblHashPath);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cboAlgorithm);
            this.Controls.Add(this.lblAlgorithmChoice);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnHash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmHash";
            this.Text = "Hash_KillRowan_Project4";
            this.Load += new System.EventHandler(this.frmHash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHash;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblAlgorithmChoice;
        private System.Windows.Forms.ComboBox cboAlgorithm;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Label lblHashPath;
        private System.Windows.Forms.Label lblHashFolder;
        private System.Windows.Forms.TextBox txtHashResult;
        private System.Windows.Forms.TextBox txtHashPathResult;
        private System.Windows.Forms.Label lblResetBtnInfo;
        private System.Windows.Forms.Label lblTitle;
    }
}

