namespace RSA
{
    partial class Form1
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
            this.lbCrypto = new System.Windows.Forms.ListBox();
            this.lbSign = new System.Windows.Forms.ListBox();
            this.btnGenerateKeys = new System.Windows.Forms.Button();
            this.tbPrivKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPubKey = new System.Windows.Forms.TextBox();
            this.btnCrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.butVerify = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImportKeys = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbCrypto
            // 
            this.lbCrypto.FormattingEnabled = true;
            this.lbCrypto.Items.AddRange(new object[] {
            "PKCS#1 v.1.5",
            "PKCS#1 v.2.0 (OAEP)"});
            this.lbCrypto.Location = new System.Drawing.Point(12, 12);
            this.lbCrypto.Name = "lbCrypto";
            this.lbCrypto.Size = new System.Drawing.Size(120, 30);
            this.lbCrypto.TabIndex = 0;
            // 
            // lbSign
            // 
            this.lbSign.FormattingEnabled = true;
            this.lbSign.Items.AddRange(new object[] {
            "PKCS#1 v.1.5",
            "PKCS#1 v.2.1 (PSS)",
            "ISO/IEC 9796-2"});
            this.lbSign.Location = new System.Drawing.Point(12, 48);
            this.lbSign.Name = "lbSign";
            this.lbSign.Size = new System.Drawing.Size(120, 43);
            this.lbSign.TabIndex = 1;
            // 
            // btnGenerateKeys
            // 
            this.btnGenerateKeys.Location = new System.Drawing.Point(12, 123);
            this.btnGenerateKeys.Name = "btnGenerateKeys";
            this.btnGenerateKeys.Size = new System.Drawing.Size(92, 23);
            this.btnGenerateKeys.TabIndex = 2;
            this.btnGenerateKeys.Text = "Generuj klucze";
            this.btnGenerateKeys.UseVisualStyleBackColor = true;
            this.btnGenerateKeys.Click += new System.EventHandler(this.btnGenerateKeys_Click);
            // 
            // tbPrivKey
            // 
            this.tbPrivKey.Location = new System.Drawing.Point(9, 293);
            this.tbPrivKey.Multiline = true;
            this.tbPrivKey.Name = "tbPrivKey";
            this.tbPrivKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbPrivKey.Size = new System.Drawing.Size(266, 117);
            this.tbPrivKey.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Klucz Prywatny";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Klucz Publiczny";
            // 
            // tbPubKey
            // 
            this.tbPubKey.Location = new System.Drawing.Point(358, 292);
            this.tbPubKey.Multiline = true;
            this.tbPubKey.Name = "tbPubKey";
            this.tbPubKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbPubKey.Size = new System.Drawing.Size(304, 118);
            this.tbPubKey.TabIndex = 6;
            // 
            // btnCrypt
            // 
            this.btnCrypt.Location = new System.Drawing.Point(12, 152);
            this.btnCrypt.Name = "btnCrypt";
            this.btnCrypt.Size = new System.Drawing.Size(92, 23);
            this.btnCrypt.TabIndex = 7;
            this.btnCrypt.Text = "Szyfruj";
            this.btnCrypt.UseVisualStyleBackColor = true;
            this.btnCrypt.Click += new System.EventHandler(this.btnCrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(12, 181);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(92, 23);
            this.btnDecrypt.TabIndex = 8;
            this.btnDecrypt.Text = "Deszyfruj";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(12, 210);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(92, 23);
            this.btnSign.TabIndex = 9;
            this.btnSign.Text = "Podpisz";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(138, 26);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInput.Size = new System.Drawing.Size(286, 248);
            this.tbInput.TabIndex = 10;
            // 
            // butVerify
            // 
            this.butVerify.Location = new System.Drawing.Point(12, 239);
            this.butVerify.Name = "butVerify";
            this.butVerify.Size = new System.Drawing.Size(92, 23);
            this.butVerify.TabIndex = 11;
            this.butVerify.Text = "Weryfikuj";
            this.butVerify.UseVisualStyleBackColor = true;
            this.butVerify.Click += new System.EventHandler(this.butVerify_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(439, 26);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(229, 248);
            this.tbOutput.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Podpis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Wiadomość";
            // 
            // btnImportKeys
            // 
            this.btnImportKeys.Location = new System.Drawing.Point(12, 97);
            this.btnImportKeys.Name = "btnImportKeys";
            this.btnImportKeys.Size = new System.Drawing.Size(92, 23);
            this.btnImportKeys.TabIndex = 15;
            this.btnImportKeys.Text = "Wczytaj klucze";
            this.btnImportKeys.UseVisualStyleBackColor = true;
            this.btnImportKeys.Click += new System.EventHandler(this.btnImportKeys_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 421);
            this.Controls.Add(this.btnImportKeys);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.butVerify);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnCrypt);
            this.Controls.Add(this.tbPubKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPrivKey);
            this.Controls.Add(this.btnGenerateKeys);
            this.Controls.Add(this.lbSign);
            this.Controls.Add(this.lbCrypto);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbCrypto;
        private System.Windows.Forms.ListBox lbSign;
        private System.Windows.Forms.Button btnGenerateKeys;
        private System.Windows.Forms.TextBox tbPrivKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPubKey;
        private System.Windows.Forms.Button btnCrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button butVerify;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImportKeys;
    }
}

