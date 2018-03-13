namespace ListAdjustment
{
    partial class formListAdjustment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.buttonAdjSearch = new System.Windows.Forms.Button();
            this.panelScLoginTitle = new System.Windows.Forms.Panel();
            this.buttonMLogout = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.textBoxInvSearchKeyword = new System.Windows.Forms.TextBox();
            this.comboBoxInvSearch = new System.Windows.Forms.ComboBox();
            this.labelProdSearchBy = new System.Windows.Forms.Label();
            this.panelInvProdView = new System.Windows.Forms.Panel();
            this.labelAdjustTitle = new System.Windows.Forms.Label();
            this.labelProdIntro = new System.Windows.Forms.Label();
            this.dataGridViewAdjResults = new System.Windows.Forms.DataGridView();
            this.panelSearchResultNum = new System.Windows.Forms.Panel();
            this.labelAdjSearchResult = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelSearch.SuspendLayout();
            this.panelScLoginTitle.SuspendLayout();
            this.panelInvProdView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdjResults)).BeginInit();
            this.panelSearchResultNum.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelSearch.Controls.Add(this.buttonAdjSearch);
            this.panelSearch.Controls.Add(this.panelScLoginTitle);
            this.panelSearch.Controls.Add(this.textBoxInvSearchKeyword);
            this.panelSearch.Controls.Add(this.comboBoxInvSearch);
            this.panelSearch.Controls.Add(this.labelProdSearchBy);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(992, 56);
            this.panelSearch.TabIndex = 132;
            // 
            // buttonAdjSearch
            // 
            this.buttonAdjSearch.Location = new System.Drawing.Point(408, 10);
            this.buttonAdjSearch.Name = "buttonAdjSearch";
            this.buttonAdjSearch.Size = new System.Drawing.Size(75, 37);
            this.buttonAdjSearch.TabIndex = 3;
            this.buttonAdjSearch.Text = "Search";
            this.buttonAdjSearch.UseVisualStyleBackColor = true;
            this.buttonAdjSearch.Click += new System.EventHandler(this.buttonAdjSearch_Click);
            // 
            // panelScLoginTitle
            // 
            this.panelScLoginTitle.AutoSize = true;
            this.panelScLoginTitle.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelScLoginTitle.Controls.Add(this.buttonMLogout);
            this.panelScLoginTitle.Controls.Add(this.labelInfo);
            this.panelScLoginTitle.Location = new System.Drawing.Point(651, 0);
            this.panelScLoginTitle.Name = "panelScLoginTitle";
            this.panelScLoginTitle.Size = new System.Drawing.Size(325, 30);
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
            // textBoxInvSearchKeyword
            // 
            this.textBoxInvSearchKeyword.Location = new System.Drawing.Point(248, 18);
            this.textBoxInvSearchKeyword.Name = "textBoxInvSearchKeyword";
            this.textBoxInvSearchKeyword.Size = new System.Drawing.Size(134, 20);
            this.textBoxInvSearchKeyword.TabIndex = 2;
            // 
            // comboBoxInvSearch
            // 
            this.comboBoxInvSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInvSearch.FormattingEnabled = true;
            this.comboBoxInvSearch.Items.AddRange(new object[] {
            "Product ID",
            "Product Name",
            "BE SKU",
            "Supplier SKU"});
            this.comboBoxInvSearch.Location = new System.Drawing.Point(109, 18);
            this.comboBoxInvSearch.Name = "comboBoxInvSearch";
            this.comboBoxInvSearch.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInvSearch.TabIndex = 1;
            // 
            // labelProdSearchBy
            // 
            this.labelProdSearchBy.AutoSize = true;
            this.labelProdSearchBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProdSearchBy.Location = new System.Drawing.Point(25, 20);
            this.labelProdSearchBy.Name = "labelProdSearchBy";
            this.labelProdSearchBy.Size = new System.Drawing.Size(78, 16);
            this.labelProdSearchBy.TabIndex = 0;
            this.labelProdSearchBy.Text = "Search by";
            // 
            // panelInvProdView
            // 
            this.panelInvProdView.Controls.Add(this.labelAdjustTitle);
            this.panelInvProdView.Controls.Add(this.labelProdIntro);
            this.panelInvProdView.Controls.Add(this.dataGridViewAdjResults);
            this.panelInvProdView.Controls.Add(this.panelSearchResultNum);
            this.panelInvProdView.Location = new System.Drawing.Point(-3, 123);
            this.panelInvProdView.Name = "panelInvProdView";
            this.panelInvProdView.Size = new System.Drawing.Size(984, 268);
            this.panelInvProdView.TabIndex = 133;
            // 
            // labelAdjustTitle
            // 
            this.labelAdjustTitle.AutoSize = true;
            this.labelAdjustTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdjustTitle.Location = new System.Drawing.Point(10, 12);
            this.labelAdjustTitle.Name = "labelAdjustTitle";
            this.labelAdjustTitle.Size = new System.Drawing.Size(159, 17);
            this.labelAdjustTitle.TabIndex = 118;
            this.labelAdjustTitle.Text = "■ Adjustment List(s)";
            // 
            // labelProdIntro
            // 
            this.labelProdIntro.AutoSize = true;
            this.labelProdIntro.Location = new System.Drawing.Point(160, 12);
            this.labelProdIntro.Name = "labelProdIntro";
            this.labelProdIntro.Size = new System.Drawing.Size(471, 13);
            this.labelProdIntro.TabIndex = 110;
            this.labelProdIntro.Text = "**Tip: Click a line below if you want to see detail Product Information or Add a " +
    "product to Inventory.";
            // 
            // dataGridViewAdjResults
            // 
            this.dataGridViewAdjResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAdjResults.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAdjResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAdjResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAdjResults.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAdjResults.Location = new System.Drawing.Point(13, 35);
            this.dataGridViewAdjResults.Name = "dataGridViewAdjResults";
            this.dataGridViewAdjResults.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAdjResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewAdjResults.Size = new System.Drawing.Size(963, 230);
            this.dataGridViewAdjResults.TabIndex = 117;
            // 
            // panelSearchResultNum
            // 
            this.panelSearchResultNum.BackColor = System.Drawing.Color.AliceBlue;
            this.panelSearchResultNum.Controls.Add(this.labelAdjSearchResult);
            this.panelSearchResultNum.Controls.Add(this.label3);
            this.panelSearchResultNum.ForeColor = System.Drawing.Color.MediumBlue;
            this.panelSearchResultNum.Location = new System.Drawing.Point(807, 4);
            this.panelSearchResultNum.Name = "panelSearchResultNum";
            this.panelSearchResultNum.Size = new System.Drawing.Size(168, 28);
            this.panelSearchResultNum.TabIndex = 111;
            // 
            // labelAdjSearchResult
            // 
            this.labelAdjSearchResult.AutoSize = true;
            this.labelAdjSearchResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdjSearchResult.ForeColor = System.Drawing.Color.Blue;
            this.labelAdjSearchResult.Location = new System.Drawing.Point(29, 4);
            this.labelAdjSearchResult.Name = "labelAdjSearchResult";
            this.labelAdjSearchResult.Size = new System.Drawing.Size(0, 20);
            this.labelAdjSearchResult.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(83, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Results found";
            // 
            // formListAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 403);
            this.Controls.Add(this.panelInvProdView);
            this.Controls.Add(this.panelSearch);
            this.Name = "formListAdjustment";
            this.Text = "ListAdjustment";
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelScLoginTitle.ResumeLayout(false);
            this.panelScLoginTitle.PerformLayout();
            this.panelInvProdView.ResumeLayout(false);
            this.panelInvProdView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdjResults)).EndInit();
            this.panelSearchResultNum.ResumeLayout(false);
            this.panelSearchResultNum.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button buttonAdjSearch;
        private System.Windows.Forms.Panel panelScLoginTitle;
        private System.Windows.Forms.Button buttonMLogout;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TextBox textBoxInvSearchKeyword;
        private System.Windows.Forms.ComboBox comboBoxInvSearch;
        private System.Windows.Forms.Label labelProdSearchBy;
        private System.Windows.Forms.Panel panelInvProdView;
        private System.Windows.Forms.Label labelAdjustTitle;
        private System.Windows.Forms.Label labelProdIntro;
        private System.Windows.Forms.DataGridView dataGridViewAdjResults;
        private System.Windows.Forms.Panel panelSearchResultNum;
        private System.Windows.Forms.Label labelAdjSearchResult;
        private System.Windows.Forms.Label label3;
    }
}