namespace LOGIN
{
    partial class FormLOGIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLOGIN));
            this.labelUserID = new System.Windows.Forms.Label();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.textBoxUserPWD = new System.Windows.Forms.TextBox();
            this.labelUserPassWord = new System.Windows.Forms.Label();
            this.buttonUserLogIn = new System.Windows.Forms.Button();
            this.panelLogInPart_D = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRequst = new System.Windows.Forms.Label();
            this.pictureBoxBELogo = new System.Windows.Forms.PictureBox();
            this.buttonScannerDemo = new System.Windows.Forms.Button();
            this.panelLogInPart_D.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBELogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserID.Location = new System.Drawing.Point(88, 93);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(50, 13);
            this.labelUserID.TabIndex = 124;
            this.labelUserID.Text = "User ID";
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(207, 89);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(100, 20);
            this.textBoxUserID.TabIndex = 122;
            // 
            // textBoxUserPWD
            // 
            this.textBoxUserPWD.Location = new System.Drawing.Point(207, 120);
            this.textBoxUserPWD.Name = "textBoxUserPWD";
            this.textBoxUserPWD.PasswordChar = '●';
            this.textBoxUserPWD.Size = new System.Drawing.Size(100, 20);
            this.textBoxUserPWD.TabIndex = 125;
            // 
            // labelUserPassWord
            // 
            this.labelUserPassWord.AutoSize = true;
            this.labelUserPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserPassWord.Location = new System.Drawing.Point(88, 124);
            this.labelUserPassWord.Name = "labelUserPassWord";
            this.labelUserPassWord.Size = new System.Drawing.Size(68, 13);
            this.labelUserPassWord.TabIndex = 121;
            this.labelUserPassWord.Text = "Pass Word";
            // 
            // buttonUserLogIn
            // 
            this.buttonUserLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUserLogIn.Location = new System.Drawing.Point(352, 96);
            this.buttonUserLogIn.Name = "buttonUserLogIn";
            this.buttonUserLogIn.Size = new System.Drawing.Size(75, 34);
            this.buttonUserLogIn.TabIndex = 123;
            this.buttonUserLogIn.Text = "Log In";
            this.buttonUserLogIn.UseVisualStyleBackColor = true;
            this.buttonUserLogIn.Click += new System.EventHandler(this.buttonUserLogIn_Click);
            // 
            // panelLogInPart_D
            // 
            this.panelLogInPart_D.Controls.Add(this.label1);
            this.panelLogInPart_D.Controls.Add(this.labelRequst);
            this.panelLogInPart_D.Controls.Add(this.labelUserID);
            this.panelLogInPart_D.Controls.Add(this.textBoxUserID);
            this.panelLogInPart_D.Controls.Add(this.textBoxUserPWD);
            this.panelLogInPart_D.Controls.Add(this.labelUserPassWord);
            this.panelLogInPart_D.Controls.Add(this.buttonUserLogIn);
            this.panelLogInPart_D.Location = new System.Drawing.Point(191, 125);
            this.panelLogInPart_D.Name = "panelLogInPart_D";
            this.panelLogInPart_D.Size = new System.Drawing.Size(528, 195);
            this.panelLogInPart_D.TabIndex = 126;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(64, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 24);
            this.label1.TabIndex = 132;
            this.label1.Text = "Welcome to BE WIMS!";
            // 
            // labelRequst
            // 
            this.labelRequst.AutoSize = true;
            this.labelRequst.Location = new System.Drawing.Point(88, 153);
            this.labelRequst.Name = "labelRequst";
            this.labelRequst.Size = new System.Drawing.Size(361, 13);
            this.labelRequst.TabIndex = 129;
            this.labelRequst.Text = "* Forgot ID or Password?  Please contact IT Department . T. 506-333-1234";
            // 
            // pictureBoxBELogo
            // 
            this.pictureBoxBELogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBELogo.Image")));
            this.pictureBoxBELogo.Location = new System.Drawing.Point(669, 32);
            this.pictureBoxBELogo.Name = "pictureBoxBELogo";
            this.pictureBoxBELogo.Size = new System.Drawing.Size(105, 87);
            this.pictureBoxBELogo.TabIndex = 127;
            this.pictureBoxBELogo.TabStop = false;
            // 
            // buttonScannerDemo
            // 
            this.buttonScannerDemo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonScannerDemo.BackgroundImage")));
            this.buttonScannerDemo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonScannerDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonScannerDemo.ForeColor = System.Drawing.Color.Red;
            this.buttonScannerDemo.Location = new System.Drawing.Point(41, 312);
            this.buttonScannerDemo.Name = "buttonScannerDemo";
            this.buttonScannerDemo.Size = new System.Drawing.Size(130, 136);
            this.buttonScannerDemo.TabIndex = 133;
            this.buttonScannerDemo.Text = "Scanner Demo";
            this.buttonScannerDemo.UseVisualStyleBackColor = true;
            this.buttonScannerDemo.Click += new System.EventHandler(this.buttonScannerDemo_Click);
            // 
            // FormLOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 460);
            this.Controls.Add(this.buttonScannerDemo);
            this.Controls.Add(this.pictureBoxBELogo);
            this.Controls.Add(this.panelLogInPart_D);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLOGIN";
            this.Text = "BE WIMS User Log In";
            this.Load += new System.EventHandler(this.FormLOGIN_Load);
            this.panelLogInPart_D.ResumeLayout(false);
            this.panelLogInPart_D.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBELogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.TextBox textBoxUserPWD;
        private System.Windows.Forms.Label labelUserPassWord;
        private System.Windows.Forms.Button buttonUserLogIn;
        private System.Windows.Forms.Panel panelLogInPart_D;
        private System.Windows.Forms.PictureBox pictureBoxBELogo;
        private System.Windows.Forms.Label labelRequst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonScannerDemo;
    }
}

