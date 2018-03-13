namespace InventoryP3
{
    partial class formScannerLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formScannerLogin));
            this.panelScLogin = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelReq2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRequst = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.textBoxMUserID = new System.Windows.Forms.TextBox();
            this.textBoxMUserPWD = new System.Windows.Forms.TextBox();
            this.labelUserPassWord = new System.Windows.Forms.Label();
            this.buttonUserLogIn = new System.Windows.Forms.Button();
            this.panelLoginPart = new System.Windows.Forms.Panel();
            this.panelScLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLoginPart.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelScLogin
            // 
            this.panelScLogin.Controls.Add(this.panelLoginPart);
            this.panelScLogin.Controls.Add(this.pictureBox1);
            this.panelScLogin.Location = new System.Drawing.Point(0, 0);
            this.panelScLogin.Name = "panelScLogin";
            this.panelScLogin.Size = new System.Drawing.Size(319, 479);
            this.panelScLogin.TabIndex = 127;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(192, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 79);
            this.pictureBox1.TabIndex = 134;
            this.pictureBox1.TabStop = false;
            // 
            // labelReq2
            // 
            this.labelReq2.AutoSize = true;
            this.labelReq2.Location = new System.Drawing.Point(66, 285);
            this.labelReq2.Name = "labelReq2";
            this.labelReq2.Size = new System.Drawing.Size(152, 13);
            this.labelReq2.TabIndex = 133;
            this.labelReq2.Text = "Please contact IT Department.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(25, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 24);
            this.label1.TabIndex = 132;
            this.label1.Text = "Welcome to BE WIMS!";
            // 
            // labelRequst
            // 
            this.labelRequst.AutoSize = true;
            this.labelRequst.Location = new System.Drawing.Point(66, 263);
            this.labelRequst.Name = "labelRequst";
            this.labelRequst.Size = new System.Drawing.Size(128, 13);
            this.labelRequst.TabIndex = 129;
            this.labelRequst.Text = "* Forgot ID or Password? ";
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserID.Location = new System.Drawing.Point(26, 79);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(50, 13);
            this.labelUserID.TabIndex = 124;
            this.labelUserID.Text = "User ID";
            // 
            // textBoxMUserID
            // 
            this.textBoxMUserID.Location = new System.Drawing.Point(145, 75);
            this.textBoxMUserID.Name = "textBoxMUserID";
            this.textBoxMUserID.Size = new System.Drawing.Size(100, 20);
            this.textBoxMUserID.TabIndex = 122;
            // 
            // textBoxMUserPWD
            // 
            this.textBoxMUserPWD.Location = new System.Drawing.Point(143, 120);
            this.textBoxMUserPWD.Name = "textBoxMUserPWD";
            this.textBoxMUserPWD.PasswordChar = '●';
            this.textBoxMUserPWD.Size = new System.Drawing.Size(100, 20);
            this.textBoxMUserPWD.TabIndex = 125;
            // 
            // labelUserPassWord
            // 
            this.labelUserPassWord.AutoSize = true;
            this.labelUserPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserPassWord.Location = new System.Drawing.Point(24, 124);
            this.labelUserPassWord.Name = "labelUserPassWord";
            this.labelUserPassWord.Size = new System.Drawing.Size(68, 13);
            this.labelUserPassWord.TabIndex = 121;
            this.labelUserPassWord.Text = "Pass Word";
            // 
            // buttonUserLogIn
            // 
            this.buttonUserLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUserLogIn.Location = new System.Drawing.Point(143, 179);
            this.buttonUserLogIn.Name = "buttonUserLogIn";
            this.buttonUserLogIn.Size = new System.Drawing.Size(75, 34);
            this.buttonUserLogIn.TabIndex = 123;
            this.buttonUserLogIn.Text = "Log In";
            this.buttonUserLogIn.UseVisualStyleBackColor = true;
            this.buttonUserLogIn.Click += new System.EventHandler(this.buttonUserLogIn_Click);
            // 
            // panelLoginPart
            // 
            this.panelLoginPart.Controls.Add(this.labelReq2);
            this.panelLoginPart.Controls.Add(this.label1);
            this.panelLoginPart.Controls.Add(this.labelRequst);
            this.panelLoginPart.Controls.Add(this.labelUserID);
            this.panelLoginPart.Controls.Add(this.textBoxMUserID);
            this.panelLoginPart.Controls.Add(this.textBoxMUserPWD);
            this.panelLoginPart.Controls.Add(this.labelUserPassWord);
            this.panelLoginPart.Controls.Add(this.buttonUserLogIn);
            this.panelLoginPart.Location = new System.Drawing.Point(21, 114);
            this.panelLoginPart.Name = "panelLoginPart";
            this.panelLoginPart.Size = new System.Drawing.Size(286, 342);
            this.panelLoginPart.TabIndex = 135;
            // 
            // formScannerLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 479);
            this.Controls.Add(this.panelScLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formScannerLogin";
            this.Text = "BE WIMS Mobile";
            this.Load += new System.EventHandler(this.formScannerLogin_Load);
            this.panelScLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLoginPart.ResumeLayout(false);
            this.panelLoginPart.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelScLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRequst;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.TextBox textBoxMUserID;
        private System.Windows.Forms.TextBox textBoxMUserPWD;
        private System.Windows.Forms.Label labelUserPassWord;
        private System.Windows.Forms.Button buttonUserLogIn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelReq2;
        private System.Windows.Forms.Panel panelLoginPart;
    }
}