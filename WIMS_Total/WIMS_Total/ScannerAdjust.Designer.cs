namespace ScannerAdjust
{
    partial class formScannerAdjust
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formScannerAdjust));
            this.buttonMAdjustConfirm = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelScanTitle = new System.Windows.Forms.Label();
            this.panelMroughInfo = new System.Windows.Forms.Panel();
            this.labelMSUP_SKU = new System.Windows.Forms.Label();
            this.textBoxMSUP_SKU = new System.Windows.Forms.TextBox();
            this.labelMBE_SKU = new System.Windows.Forms.Label();
            this.textBoxMBE_SKU = new System.Windows.Forms.TextBox();
            this.labelMTouchIntro = new System.Windows.Forms.Label();
            this.textBoxMProdName = new System.Windows.Forms.TextBox();
            this.labelMProdName = new System.Windows.Forms.Label();
            this.labelMInvLevelBrief = new System.Windows.Forms.Label();
            this.comboBoxMShelfLoc = new System.Windows.Forms.ComboBox();
            this.labelMInvID = new System.Windows.Forms.Label();
            this.textBoxMProdID = new System.Windows.Forms.TextBox();
            this.textBoxMInvID = new System.Windows.Forms.TextBox();
            this.labelMQOH = new System.Windows.Forms.Label();
            this.labelMProdID = new System.Windows.Forms.Label();
            this.textBoxMQOH = new System.Windows.Forms.TextBox();
            this.labelMShelfLoc = new System.Windows.Forms.Label();
            this.textBoxMKeyword = new System.Windows.Forms.TextBox();
            this.panelScLoginTitle = new System.Windows.Forms.Panel();
            this.buttonMLogout = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.panelMbottom = new System.Windows.Forms.Panel();
            this.groupBoxAdjType = new System.Windows.Forms.GroupBox();
            this.radioButtonDefective = new System.Windows.Forms.RadioButton();
            this.radioButtonDamaged = new System.Windows.Forms.RadioButton();
            this.radioButtonLost = new System.Windows.Forms.RadioButton();
            this.labelAdj = new System.Windows.Forms.Label();
            this.textBoxAdjAmt = new System.Windows.Forms.TextBox();
            this.panelMroughInfo.SuspendLayout();
            this.panelScLoginTitle.SuspendLayout();
            this.panelMbottom.SuspendLayout();
            this.groupBoxAdjType.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonMAdjustConfirm
            // 
            this.buttonMAdjustConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMAdjustConfirm.Location = new System.Drawing.Point(15, 14);
            this.buttonMAdjustConfirm.Name = "buttonMAdjustConfirm";
            this.buttonMAdjustConfirm.Size = new System.Drawing.Size(86, 48);
            this.buttonMAdjustConfirm.TabIndex = 134;
            this.buttonMAdjustConfirm.Text = "Confirm Adjustment";
            this.buttonMAdjustConfirm.UseVisualStyleBackColor = true;
            this.buttonMAdjustConfirm.Click += new System.EventHandler(this.buttonMAdjustConfirm_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(228, 38);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 140;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelScanTitle
            // 
            this.labelScanTitle.AutoSize = true;
            this.labelScanTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScanTitle.Location = new System.Drawing.Point(9, 43);
            this.labelScanTitle.Name = "labelScanTitle";
            this.labelScanTitle.Size = new System.Drawing.Size(109, 13);
            this.labelScanTitle.TabIndex = 139;
            this.labelScanTitle.Text = "Searched Product";
            // 
            // panelMroughInfo
            // 
            this.panelMroughInfo.BackColor = System.Drawing.Color.Azure;
            this.panelMroughInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMroughInfo.Controls.Add(this.labelMSUP_SKU);
            this.panelMroughInfo.Controls.Add(this.textBoxMSUP_SKU);
            this.panelMroughInfo.Controls.Add(this.labelMBE_SKU);
            this.panelMroughInfo.Controls.Add(this.textBoxMBE_SKU);
            this.panelMroughInfo.Controls.Add(this.labelMTouchIntro);
            this.panelMroughInfo.Controls.Add(this.textBoxMProdName);
            this.panelMroughInfo.Controls.Add(this.labelMProdName);
            this.panelMroughInfo.Controls.Add(this.labelMInvLevelBrief);
            this.panelMroughInfo.Controls.Add(this.comboBoxMShelfLoc);
            this.panelMroughInfo.Controls.Add(this.labelMInvID);
            this.panelMroughInfo.Controls.Add(this.textBoxMProdID);
            this.panelMroughInfo.Controls.Add(this.textBoxMInvID);
            this.panelMroughInfo.Controls.Add(this.labelMQOH);
            this.panelMroughInfo.Controls.Add(this.labelMProdID);
            this.panelMroughInfo.Controls.Add(this.textBoxMQOH);
            this.panelMroughInfo.Controls.Add(this.labelMShelfLoc);
            this.panelMroughInfo.Location = new System.Drawing.Point(6, 66);
            this.panelMroughInfo.Name = "panelMroughInfo";
            this.panelMroughInfo.Size = new System.Drawing.Size(304, 290);
            this.panelMroughInfo.TabIndex = 136;
            this.panelMroughInfo.Click += new System.EventHandler(this.panelMroughInfo_Click);
            // 
            // labelMSUP_SKU
            // 
            this.labelMSUP_SKU.AutoSize = true;
            this.labelMSUP_SKU.Location = new System.Drawing.Point(24, 119);
            this.labelMSUP_SKU.Name = "labelMSUP_SKU";
            this.labelMSUP_SKU.Size = new System.Drawing.Size(70, 13);
            this.labelMSUP_SKU.TabIndex = 131;
            this.labelMSUP_SKU.Text = "Supplier SKU";
            // 
            // textBoxMSUP_SKU
            // 
            this.textBoxMSUP_SKU.Location = new System.Drawing.Point(143, 115);
            this.textBoxMSUP_SKU.Name = "textBoxMSUP_SKU";
            this.textBoxMSUP_SKU.Size = new System.Drawing.Size(100, 20);
            this.textBoxMSUP_SKU.TabIndex = 132;
            // 
            // labelMBE_SKU
            // 
            this.labelMBE_SKU.AutoSize = true;
            this.labelMBE_SKU.Location = new System.Drawing.Point(24, 93);
            this.labelMBE_SKU.Name = "labelMBE_SKU";
            this.labelMBE_SKU.Size = new System.Drawing.Size(46, 13);
            this.labelMBE_SKU.TabIndex = 129;
            this.labelMBE_SKU.Text = "BE SKU";
            // 
            // textBoxMBE_SKU
            // 
            this.textBoxMBE_SKU.Location = new System.Drawing.Point(143, 89);
            this.textBoxMBE_SKU.Name = "textBoxMBE_SKU";
            this.textBoxMBE_SKU.Size = new System.Drawing.Size(100, 20);
            this.textBoxMBE_SKU.TabIndex = 130;
            // 
            // labelMTouchIntro
            // 
            this.labelMTouchIntro.AutoSize = true;
            this.labelMTouchIntro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMTouchIntro.Location = new System.Drawing.Point(31, 258);
            this.labelMTouchIntro.Name = "labelMTouchIntro";
            this.labelMTouchIntro.Size = new System.Drawing.Size(243, 13);
            this.labelMTouchIntro.TabIndex = 128;
            this.labelMTouchIntro.Text = "Touch for more detail Product Information";
            // 
            // textBoxMProdName
            // 
            this.textBoxMProdName.Location = new System.Drawing.Point(143, 142);
            this.textBoxMProdName.Multiline = true;
            this.textBoxMProdName.Name = "textBoxMProdName";
            this.textBoxMProdName.Size = new System.Drawing.Size(100, 43);
            this.textBoxMProdName.TabIndex = 127;
            // 
            // labelMProdName
            // 
            this.labelMProdName.AutoSize = true;
            this.labelMProdName.Location = new System.Drawing.Point(24, 146);
            this.labelMProdName.Name = "labelMProdName";
            this.labelMProdName.Size = new System.Drawing.Size(75, 13);
            this.labelMProdName.TabIndex = 126;
            this.labelMProdName.Text = "Product Name";
            // 
            // labelMInvLevelBrief
            // 
            this.labelMInvLevelBrief.AutoSize = true;
            this.labelMInvLevelBrief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMInvLevelBrief.Location = new System.Drawing.Point(22, 14);
            this.labelMInvLevelBrief.Name = "labelMInvLevelBrief";
            this.labelMInvLevelBrief.Size = new System.Drawing.Size(164, 13);
            this.labelMInvLevelBrief.TabIndex = 104;
            this.labelMInvLevelBrief.Text = "Detail Inventory Information";
            // 
            // comboBoxMShelfLoc
            // 
            this.comboBoxMShelfLoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxMShelfLoc.Location = new System.Drawing.Point(143, 192);
            this.comboBoxMShelfLoc.Name = "comboBoxMShelfLoc";
            this.comboBoxMShelfLoc.Size = new System.Drawing.Size(100, 21);
            this.comboBoxMShelfLoc.TabIndex = 125;
            // 
            // labelMInvID
            // 
            this.labelMInvID.AutoSize = true;
            this.labelMInvID.Location = new System.Drawing.Point(24, 41);
            this.labelMInvID.Name = "labelMInvID";
            this.labelMInvID.Size = new System.Drawing.Size(65, 13);
            this.labelMInvID.TabIndex = 119;
            this.labelMInvID.Text = "Inventory ID";
            // 
            // textBoxMProdID
            // 
            this.textBoxMProdID.Location = new System.Drawing.Point(143, 63);
            this.textBoxMProdID.Name = "textBoxMProdID";
            this.textBoxMProdID.Size = new System.Drawing.Size(100, 20);
            this.textBoxMProdID.TabIndex = 107;
            // 
            // textBoxMInvID
            // 
            this.textBoxMInvID.Location = new System.Drawing.Point(143, 37);
            this.textBoxMInvID.Name = "textBoxMInvID";
            this.textBoxMInvID.Size = new System.Drawing.Size(100, 20);
            this.textBoxMInvID.TabIndex = 120;
            // 
            // labelMQOH
            // 
            this.labelMQOH.AutoSize = true;
            this.labelMQOH.Location = new System.Drawing.Point(24, 224);
            this.labelMQOH.Name = "labelMQOH";
            this.labelMQOH.Size = new System.Drawing.Size(31, 13);
            this.labelMQOH.TabIndex = 110;
            this.labelMQOH.Text = "QOH";
            // 
            // labelMProdID
            // 
            this.labelMProdID.AutoSize = true;
            this.labelMProdID.Location = new System.Drawing.Point(24, 67);
            this.labelMProdID.Name = "labelMProdID";
            this.labelMProdID.Size = new System.Drawing.Size(58, 13);
            this.labelMProdID.TabIndex = 106;
            this.labelMProdID.Text = "Product ID";
            // 
            // textBoxMQOH
            // 
            this.textBoxMQOH.Location = new System.Drawing.Point(143, 220);
            this.textBoxMQOH.Name = "textBoxMQOH";
            this.textBoxMQOH.Size = new System.Drawing.Size(100, 20);
            this.textBoxMQOH.TabIndex = 113;
            // 
            // labelMShelfLoc
            // 
            this.labelMShelfLoc.AutoSize = true;
            this.labelMShelfLoc.Location = new System.Drawing.Point(24, 193);
            this.labelMShelfLoc.Name = "labelMShelfLoc";
            this.labelMShelfLoc.Size = new System.Drawing.Size(75, 13);
            this.labelMShelfLoc.TabIndex = 117;
            this.labelMShelfLoc.Text = "Shelf Location";
            // 
            // textBoxMKeyword
            // 
            this.textBoxMKeyword.Location = new System.Drawing.Point(122, 39);
            this.textBoxMKeyword.Name = "textBoxMKeyword";
            this.textBoxMKeyword.Size = new System.Drawing.Size(100, 20);
            this.textBoxMKeyword.TabIndex = 138;
            this.textBoxMKeyword.Text = "BESKU or SUPSKU";
            // 
            // panelScLoginTitle
            // 
            this.panelScLoginTitle.AutoSize = true;
            this.panelScLoginTitle.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelScLoginTitle.Controls.Add(this.buttonMLogout);
            this.panelScLoginTitle.Controls.Add(this.labelInfo);
            this.panelScLoginTitle.Location = new System.Drawing.Point(0, 0);
            this.panelScLoginTitle.Name = "panelScLoginTitle";
            this.panelScLoginTitle.Size = new System.Drawing.Size(319, 30);
            this.panelScLoginTitle.TabIndex = 137;
            // 
            // buttonMLogout
            // 
            this.buttonMLogout.ForeColor = System.Drawing.Color.Sienna;
            this.buttonMLogout.Location = new System.Drawing.Point(241, 4);
            this.buttonMLogout.Name = "buttonMLogout";
            this.buttonMLogout.Size = new System.Drawing.Size(75, 23);
            this.buttonMLogout.TabIndex = 1;
            this.buttonMLogout.Text = "Logout";
            this.buttonMLogout.UseVisualStyleBackColor = true;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.ForeColor = System.Drawing.Color.MistyRose;
            this.labelInfo.Location = new System.Drawing.Point(12, 10);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(73, 13);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "labelLoginInfo";
            // 
            // panelMbottom
            // 
            this.panelMbottom.Controls.Add(this.buttonMAdjustConfirm);
            this.panelMbottom.Location = new System.Drawing.Point(181, 404);
            this.panelMbottom.Name = "panelMbottom";
            this.panelMbottom.Size = new System.Drawing.Size(110, 78);
            this.panelMbottom.TabIndex = 141;
            // 
            // groupBoxAdjType
            // 
            this.groupBoxAdjType.BackColor = System.Drawing.Color.PapayaWhip;
            this.groupBoxAdjType.Controls.Add(this.radioButtonDefective);
            this.groupBoxAdjType.Controls.Add(this.radioButtonDamaged);
            this.groupBoxAdjType.Controls.Add(this.radioButtonLost);
            this.groupBoxAdjType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAdjType.Location = new System.Drawing.Point(15, 374);
            this.groupBoxAdjType.Name = "groupBoxAdjType";
            this.groupBoxAdjType.Size = new System.Drawing.Size(136, 100);
            this.groupBoxAdjType.TabIndex = 142;
            this.groupBoxAdjType.TabStop = false;
            this.groupBoxAdjType.Text = "Adjustment Type";
            // 
            // radioButtonDefective
            // 
            this.radioButtonDefective.AutoSize = true;
            this.radioButtonDefective.Location = new System.Drawing.Point(18, 68);
            this.radioButtonDefective.Name = "radioButtonDefective";
            this.radioButtonDefective.Size = new System.Drawing.Size(80, 17);
            this.radioButtonDefective.TabIndex = 2;
            this.radioButtonDefective.TabStop = true;
            this.radioButtonDefective.Text = "Defective";
            this.radioButtonDefective.UseVisualStyleBackColor = true;
            // 
            // radioButtonDamaged
            // 
            this.radioButtonDamaged.AutoSize = true;
            this.radioButtonDamaged.Location = new System.Drawing.Point(20, 44);
            this.radioButtonDamaged.Name = "radioButtonDamaged";
            this.radioButtonDamaged.Size = new System.Drawing.Size(78, 17);
            this.radioButtonDamaged.TabIndex = 1;
            this.radioButtonDamaged.TabStop = true;
            this.radioButtonDamaged.Text = "Damaged";
            this.radioButtonDamaged.UseVisualStyleBackColor = true;
            // 
            // radioButtonLost
            // 
            this.radioButtonLost.AutoSize = true;
            this.radioButtonLost.Location = new System.Drawing.Point(20, 20);
            this.radioButtonLost.Name = "radioButtonLost";
            this.radioButtonLost.Size = new System.Drawing.Size(49, 17);
            this.radioButtonLost.TabIndex = 0;
            this.radioButtonLost.TabStop = true;
            this.radioButtonLost.Text = "Lost";
            this.radioButtonLost.UseVisualStyleBackColor = true;
            // 
            // labelAdj
            // 
            this.labelAdj.AutoSize = true;
            this.labelAdj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdj.Location = new System.Drawing.Point(180, 359);
            this.labelAdj.Name = "labelAdj";
            this.labelAdj.Size = new System.Drawing.Size(102, 13);
            this.labelAdj.TabIndex = 133;
            this.labelAdj.Text = "Amount to adjust";
            // 
            // textBoxAdjAmt
            // 
            this.textBoxAdjAmt.Location = new System.Drawing.Point(183, 377);
            this.textBoxAdjAmt.Name = "textBoxAdjAmt";
            this.textBoxAdjAmt.Size = new System.Drawing.Size(75, 20);
            this.textBoxAdjAmt.TabIndex = 134;
            this.textBoxAdjAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAdjAmt_KeyPress);
            // 
            // formScannerAdjust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 486);
            this.Controls.Add(this.labelAdj);
            this.Controls.Add(this.groupBoxAdjType);
            this.Controls.Add(this.textBoxAdjAmt);
            this.Controls.Add(this.panelMbottom);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelScanTitle);
            this.Controls.Add(this.panelMroughInfo);
            this.Controls.Add(this.textBoxMKeyword);
            this.Controls.Add(this.panelScLoginTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formScannerAdjust";
            this.Text = "ScannerAdjust";
            this.Load += new System.EventHandler(this.ScannerAdjust_Load);
            this.panelMroughInfo.ResumeLayout(false);
            this.panelMroughInfo.PerformLayout();
            this.panelScLoginTitle.ResumeLayout(false);
            this.panelScLoginTitle.PerformLayout();
            this.panelMbottom.ResumeLayout(false);
            this.groupBoxAdjType.ResumeLayout(false);
            this.groupBoxAdjType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMAdjustConfirm;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelScanTitle;
        private System.Windows.Forms.Panel panelMroughInfo;
        private System.Windows.Forms.Label labelMSUP_SKU;
        private System.Windows.Forms.TextBox textBoxMSUP_SKU;
        private System.Windows.Forms.Label labelMBE_SKU;
        private System.Windows.Forms.TextBox textBoxMBE_SKU;
        private System.Windows.Forms.Label labelMTouchIntro;
        private System.Windows.Forms.TextBox textBoxMProdName;
        private System.Windows.Forms.Label labelMProdName;
        private System.Windows.Forms.Label labelMInvLevelBrief;
        private System.Windows.Forms.ComboBox comboBoxMShelfLoc;
        private System.Windows.Forms.Label labelMInvID;
        private System.Windows.Forms.TextBox textBoxMProdID;
        private System.Windows.Forms.TextBox textBoxMInvID;
        private System.Windows.Forms.Label labelMQOH;
        private System.Windows.Forms.Label labelMProdID;
        private System.Windows.Forms.TextBox textBoxMQOH;
        private System.Windows.Forms.Label labelMShelfLoc;
        private System.Windows.Forms.TextBox textBoxMKeyword;
        private System.Windows.Forms.Panel panelScLoginTitle;
        private System.Windows.Forms.Button buttonMLogout;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Panel panelMbottom;
        private System.Windows.Forms.GroupBox groupBoxAdjType;
        private System.Windows.Forms.RadioButton radioButtonDefective;
        private System.Windows.Forms.RadioButton radioButtonDamaged;
        private System.Windows.Forms.RadioButton radioButtonLost;
        private System.Windows.Forms.Label labelAdj;
        private System.Windows.Forms.TextBox textBoxAdjAmt;
    }
}