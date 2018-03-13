namespace BENewMainMenu
{
    partial class formNewMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formNewMainMenu));
            this.labelWelcomeMessage = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.buttonMaintainDB = new System.Windows.Forms.Button();
            this.buttonViewReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWelcomeMessage
            // 
            this.labelWelcomeMessage.AutoSize = true;
            this.labelWelcomeMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcomeMessage.Location = new System.Drawing.Point(63, 118);
            this.labelWelcomeMessage.Name = "labelWelcomeMessage";
            this.labelWelcomeMessage.Size = new System.Drawing.Size(562, 25);
            this.labelWelcomeMessage.TabIndex = 12;
            this.labelWelcomeMessage.Text = "Welcome to Bullseye Inventory Management System";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(659, 79);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(147, 100);
            this.pictureBoxLogo.TabIndex = 11;
            this.pictureBoxLogo.TabStop = false;
            // 
            // buttonMaintainDB
            // 
            this.buttonMaintainDB.BackColor = System.Drawing.Color.DeepPink;
            this.buttonMaintainDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMaintainDB.Location = new System.Drawing.Point(484, 224);
            this.buttonMaintainDB.Name = "buttonMaintainDB";
            this.buttonMaintainDB.Size = new System.Drawing.Size(216, 107);
            this.buttonMaintainDB.TabIndex = 10;
            this.buttonMaintainDB.Text = "Maintain Database";
            this.buttonMaintainDB.UseVisualStyleBackColor = false;
            this.buttonMaintainDB.Click += new System.EventHandler(this.buttonMaintainDB_Click);
            // 
            // buttonViewReport
            // 
            this.buttonViewReport.BackColor = System.Drawing.Color.LawnGreen;
            this.buttonViewReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewReport.Location = new System.Drawing.Point(170, 224);
            this.buttonViewReport.Name = "buttonViewReport";
            this.buttonViewReport.Size = new System.Drawing.Size(216, 107);
            this.buttonViewReport.TabIndex = 9;
            this.buttonViewReport.Text = "View Reports ";
            this.buttonViewReport.UseVisualStyleBackColor = false;
            // 
            // formNewMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 410);
            this.Controls.Add(this.labelWelcomeMessage);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.buttonMaintainDB);
            this.Controls.Add(this.buttonViewReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formNewMainMenu";
            this.Text = "Bullseye IMS Main Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcomeMessage;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button buttonMaintainDB;
        private System.Windows.Forms.Button buttonViewReport;
    }
}

