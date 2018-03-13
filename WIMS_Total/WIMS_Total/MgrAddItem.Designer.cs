namespace ManagerModifyItem
{
    partial class formMgrModifyItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMgrModifyItem));
            this.panelScLoginTitle = new System.Windows.Forms.Panel();
            this.buttonMLogout = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.dataGridViewOrdList = new System.Windows.Forms.DataGridView();
            this.panelSearchResultNum = new System.Windows.Forms.Panel();
            this.labelOrdSearchResult = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMSUP_SKU = new System.Windows.Forms.Label();
            this.textBoxMSUP_SKU = new System.Windows.Forms.TextBox();
            this.labelMBE_SKU = new System.Windows.Forms.Label();
            this.textBoxMBE_SKU = new System.Windows.Forms.TextBox();
            this.labelMInvID = new System.Windows.Forms.Label();
            this.textBoxMInvID = new System.Windows.Forms.TextBox();
            this.labelMQOH = new System.Windows.Forms.Label();
            this.textBoxModQTY = new System.Windows.Forms.TextBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonModItem = new System.Windows.Forms.Button();
            this.panelMDetail = new System.Windows.Forms.Panel();
            this.buttonModConfirm = new System.Windows.Forms.Button();
            this.panelScLoginTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrdList)).BeginInit();
            this.panelSearchResultNum.SuspendLayout();
            this.panelMDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelScLoginTitle
            // 
            this.panelScLoginTitle.AutoSize = true;
            this.panelScLoginTitle.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelScLoginTitle.Controls.Add(this.buttonMLogout);
            this.panelScLoginTitle.Controls.Add(this.labelInfo);
            this.panelScLoginTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelScLoginTitle.Location = new System.Drawing.Point(0, 0);
            this.panelScLoginTitle.Name = "panelScLoginTitle";
            this.panelScLoginTitle.Size = new System.Drawing.Size(321, 30);
            this.panelScLoginTitle.TabIndex = 130;
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
            // dataGridViewOrdList
            // 
            this.dataGridViewOrdList.AllowUserToAddRows = false;
            this.dataGridViewOrdList.AllowUserToDeleteRows = false;
            this.dataGridViewOrdList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrdList.Location = new System.Drawing.Point(0, 67);
            this.dataGridViewOrdList.Name = "dataGridViewOrdList";
            this.dataGridViewOrdList.ReadOnly = true;
            this.dataGridViewOrdList.Size = new System.Drawing.Size(321, 150);
            this.dataGridViewOrdList.TabIndex = 131;
            this.dataGridViewOrdList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrdList_CellClick);
            // 
            // panelSearchResultNum
            // 
            this.panelSearchResultNum.BackColor = System.Drawing.Color.AliceBlue;
            this.panelSearchResultNum.Controls.Add(this.labelOrdSearchResult);
            this.panelSearchResultNum.Controls.Add(this.label3);
            this.panelSearchResultNum.ForeColor = System.Drawing.Color.MediumBlue;
            this.panelSearchResultNum.Location = new System.Drawing.Point(153, 36);
            this.panelSearchResultNum.Name = "panelSearchResultNum";
            this.panelSearchResultNum.Size = new System.Drawing.Size(168, 28);
            this.panelSearchResultNum.TabIndex = 132;
            // 
            // labelOrdSearchResult
            // 
            this.labelOrdSearchResult.AutoSize = true;
            this.labelOrdSearchResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrdSearchResult.ForeColor = System.Drawing.Color.Blue;
            this.labelOrdSearchResult.Location = new System.Drawing.Point(29, 4);
            this.labelOrdSearchResult.Name = "labelOrdSearchResult";
            this.labelOrdSearchResult.Size = new System.Drawing.Size(19, 20);
            this.labelOrdSearchResult.TabIndex = 22;
            this.labelOrdSearchResult.Text = "#";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(83, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Items found";
            // 
            // labelMSUP_SKU
            // 
            this.labelMSUP_SKU.AutoSize = true;
            this.labelMSUP_SKU.Location = new System.Drawing.Point(16, 61);
            this.labelMSUP_SKU.Name = "labelMSUP_SKU";
            this.labelMSUP_SKU.Size = new System.Drawing.Size(70, 13);
            this.labelMSUP_SKU.TabIndex = 139;
            this.labelMSUP_SKU.Text = "Supplier SKU";
            // 
            // textBoxMSUP_SKU
            // 
            this.textBoxMSUP_SKU.Location = new System.Drawing.Point(94, 57);
            this.textBoxMSUP_SKU.Name = "textBoxMSUP_SKU";
            this.textBoxMSUP_SKU.Size = new System.Drawing.Size(100, 20);
            this.textBoxMSUP_SKU.TabIndex = 140;
            // 
            // labelMBE_SKU
            // 
            this.labelMBE_SKU.AutoSize = true;
            this.labelMBE_SKU.Location = new System.Drawing.Point(16, 36);
            this.labelMBE_SKU.Name = "labelMBE_SKU";
            this.labelMBE_SKU.Size = new System.Drawing.Size(46, 13);
            this.labelMBE_SKU.TabIndex = 137;
            this.labelMBE_SKU.Text = "BE SKU";
            // 
            // textBoxMBE_SKU
            // 
            this.textBoxMBE_SKU.Location = new System.Drawing.Point(94, 32);
            this.textBoxMBE_SKU.Name = "textBoxMBE_SKU";
            this.textBoxMBE_SKU.Size = new System.Drawing.Size(100, 20);
            this.textBoxMBE_SKU.TabIndex = 138;
            // 
            // labelMInvID
            // 
            this.labelMInvID.AutoSize = true;
            this.labelMInvID.Location = new System.Drawing.Point(16, 11);
            this.labelMInvID.Name = "labelMInvID";
            this.labelMInvID.Size = new System.Drawing.Size(65, 13);
            this.labelMInvID.TabIndex = 135;
            this.labelMInvID.Text = "Inventory ID";
            // 
            // textBoxMInvID
            // 
            this.textBoxMInvID.Location = new System.Drawing.Point(94, 7);
            this.textBoxMInvID.Name = "textBoxMInvID";
            this.textBoxMInvID.Size = new System.Drawing.Size(100, 20);
            this.textBoxMInvID.TabIndex = 136;
            // 
            // labelMQOH
            // 
            this.labelMQOH.AutoSize = true;
            this.labelMQOH.Location = new System.Drawing.Point(16, 85);
            this.labelMQOH.Name = "labelMQOH";
            this.labelMQOH.Size = new System.Drawing.Size(56, 13);
            this.labelMQOH.TabIndex = 133;
            this.labelMQOH.Text = "Case QTY";
            // 
            // textBoxModQTY
            // 
            this.textBoxModQTY.Location = new System.Drawing.Point(94, 81);
            this.textBoxModQTY.Name = "textBoxModQTY";
            this.textBoxModQTY.Size = new System.Drawing.Size(100, 20);
            this.textBoxModQTY.TabIndex = 134;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.Location = new System.Drawing.Point(12, 223);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(86, 48);
            this.buttonRemove.TabIndex = 141;
            this.buttonRemove.Text = "Remove Item";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonModItem
            // 
            this.buttonModItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModItem.Location = new System.Drawing.Point(104, 223);
            this.buttonModItem.Name = "buttonModItem";
            this.buttonModItem.Size = new System.Drawing.Size(86, 48);
            this.buttonModItem.TabIndex = 142;
            this.buttonModItem.Text = "Modify Item";
            this.buttonModItem.UseVisualStyleBackColor = true;
            this.buttonModItem.Click += new System.EventHandler(this.buttonModItem_Click);
            // 
            // panelMDetail
            // 
            this.panelMDetail.Controls.Add(this.buttonModConfirm);
            this.panelMDetail.Controls.Add(this.labelMInvID);
            this.panelMDetail.Controls.Add(this.textBoxModQTY);
            this.panelMDetail.Controls.Add(this.labelMQOH);
            this.panelMDetail.Controls.Add(this.labelMSUP_SKU);
            this.panelMDetail.Controls.Add(this.textBoxMInvID);
            this.panelMDetail.Controls.Add(this.textBoxMSUP_SKU);
            this.panelMDetail.Controls.Add(this.textBoxMBE_SKU);
            this.panelMDetail.Controls.Add(this.labelMBE_SKU);
            this.panelMDetail.Location = new System.Drawing.Point(9, 283);
            this.panelMDetail.Name = "panelMDetail";
            this.panelMDetail.Size = new System.Drawing.Size(300, 112);
            this.panelMDetail.TabIndex = 143;
            // 
            // buttonModConfirm
            // 
            this.buttonModConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModConfirm.Location = new System.Drawing.Point(203, 29);
            this.buttonModConfirm.Name = "buttonModConfirm";
            this.buttonModConfirm.Size = new System.Drawing.Size(86, 48);
            this.buttonModConfirm.TabIndex = 144;
            this.buttonModConfirm.Text = "Modify Confirm";
            this.buttonModConfirm.UseVisualStyleBackColor = true;
            this.buttonModConfirm.Click += new System.EventHandler(this.buttonModConfirm_Click);
            // 
            // formMgrModifyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 503);
            this.Controls.Add(this.panelMDetail);
            this.Controls.Add(this.buttonModItem);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.panelSearchResultNum);
            this.Controls.Add(this.dataGridViewOrdList);
            this.Controls.Add(this.panelScLoginTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formMgrModifyItem";
            this.Text = "Modify Item to Order";
            this.Load += new System.EventHandler(this.formMgrModifyItem_Load);
            this.panelScLoginTitle.ResumeLayout(false);
            this.panelScLoginTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrdList)).EndInit();
            this.panelSearchResultNum.ResumeLayout(false);
            this.panelSearchResultNum.PerformLayout();
            this.panelMDetail.ResumeLayout(false);
            this.panelMDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelScLoginTitle;
        private System.Windows.Forms.Button buttonMLogout;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.DataGridView dataGridViewOrdList;
        private System.Windows.Forms.Panel panelSearchResultNum;
        private System.Windows.Forms.Label labelOrdSearchResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelMSUP_SKU;
        private System.Windows.Forms.TextBox textBoxMSUP_SKU;
        private System.Windows.Forms.Label labelMBE_SKU;
        private System.Windows.Forms.TextBox textBoxMBE_SKU;
        private System.Windows.Forms.Label labelMInvID;
        private System.Windows.Forms.TextBox textBoxMInvID;
        private System.Windows.Forms.Label labelMQOH;
        private System.Windows.Forms.TextBox textBoxModQTY;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonModItem;
        private System.Windows.Forms.Panel panelMDetail;
        private System.Windows.Forms.Button buttonModConfirm;
    }
}