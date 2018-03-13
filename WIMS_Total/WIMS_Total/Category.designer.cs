namespace BECategory
{
    partial class formCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCategory));
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxCatSearchList = new System.Windows.Forms.ComboBox();
            this.buttonCatSearch = new System.Windows.Forms.Button();
            this.textCatKeyword = new System.Windows.Forms.TextBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.labelSearchBy = new System.Windows.Forms.Label();
            this.labelCatID = new System.Windows.Forms.Label();
            this.textBoxCatID = new System.Windows.Forms.TextBox();
            this.textBoxCatName = new System.Windows.Forms.TextBox();
            this.labelCatName = new System.Windows.Forms.Label();
            this.labelStockType = new System.Windows.Forms.Label();
            this.textBoxCatShortName = new System.Windows.Forms.TextBox();
            this.labelCatShortName = new System.Windows.Forms.Label();
            this.textBoxMiscInfo = new System.Windows.Forms.TextBox();
            this.labelMiscInfo = new System.Windows.Forms.Label();
            this.labelSeasonID = new System.Windows.Forms.Label();
            this.dataGridViewCategory = new System.Windows.Forms.DataGridView();
            this.radioSeasonal = new System.Windows.Forms.RadioButton();
            this.radioRegular = new System.Windows.Forms.RadioButton();
            this.labelCatHint = new System.Windows.Forms.Label();
            this.buttonCatClear = new System.Windows.Forms.Button();
            this.buttonCatUpdate = new System.Windows.Forms.Button();
            this.buttonCatInsert = new System.Windows.Forms.Button();
            this.buttonCatDelete = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.panelResult = new System.Windows.Forms.Panel();
            this.labelSearchResult = new System.Windows.Forms.Label();
            this.groupBoxStockType = new System.Windows.Forms.GroupBox();
            this.comboBoxCatSeasonID = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).BeginInit();
            this.panelResult.SuspendLayout();
            this.groupBoxStockType.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.comboBoxCatSearchList);
            this.panel1.Controls.Add(this.buttonCatSearch);
            this.panel1.Controls.Add(this.textCatKeyword);
            this.panel1.Controls.Add(this.comboBoxCategory);
            this.panel1.Controls.Add(this.labelSearchBy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 56);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxCatSearchList
            // 
            this.comboBoxCatSearchList.FormattingEnabled = true;
            this.comboBoxCatSearchList.Location = new System.Drawing.Point(248, 17);
            this.comboBoxCatSearchList.Name = "comboBoxCatSearchList";
            this.comboBoxCatSearchList.Size = new System.Drawing.Size(134, 21);
            this.comboBoxCatSearchList.TabIndex = 25;
            // 
            // buttonCatSearch
            // 
            this.buttonCatSearch.Location = new System.Drawing.Point(408, 10);
            this.buttonCatSearch.Name = "buttonCatSearch";
            this.buttonCatSearch.Size = new System.Drawing.Size(75, 37);
            this.buttonCatSearch.TabIndex = 3;
            this.buttonCatSearch.Text = "Search";
            this.buttonCatSearch.UseVisualStyleBackColor = true;
            this.buttonCatSearch.Click += new System.EventHandler(this.buttonCatSearch_Click);
            // 
            // textCatKeyword
            // 
            this.textCatKeyword.Location = new System.Drawing.Point(248, 18);
            this.textCatKeyword.Name = "textCatKeyword";
            this.textCatKeyword.Size = new System.Drawing.Size(134, 20);
            this.textCatKeyword.TabIndex = 2;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Items.AddRange(new object[] {
            "Category ID",
            "Category Name",
            "Stock Type(Seasonal)",
            "Any Values"});
            this.comboBoxCategory.Location = new System.Drawing.Point(109, 18);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCategory.TabIndex = 1;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboCategory_SelectedIndexChanged);
            // 
            // labelSearchBy
            // 
            this.labelSearchBy.AutoSize = true;
            this.labelSearchBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearchBy.Location = new System.Drawing.Point(25, 20);
            this.labelSearchBy.Name = "labelSearchBy";
            this.labelSearchBy.Size = new System.Drawing.Size(78, 16);
            this.labelSearchBy.TabIndex = 0;
            this.labelSearchBy.Text = "Search by";
            // 
            // labelCatID
            // 
            this.labelCatID.AutoSize = true;
            this.labelCatID.Location = new System.Drawing.Point(13, 75);
            this.labelCatID.Name = "labelCatID";
            this.labelCatID.Size = new System.Drawing.Size(63, 13);
            this.labelCatID.TabIndex = 1;
            this.labelCatID.Text = "Category ID";
            // 
            // textBoxCatID
            // 
            this.textBoxCatID.Location = new System.Drawing.Point(132, 71);
            this.textBoxCatID.Name = "textBoxCatID";
            this.textBoxCatID.Size = new System.Drawing.Size(100, 20);
            this.textBoxCatID.TabIndex = 2;
            this.textBoxCatID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCatID_KeyPress);
            // 
            // textBoxCatName
            // 
            this.textBoxCatName.Location = new System.Drawing.Point(132, 110);
            this.textBoxCatName.Name = "textBoxCatName";
            this.textBoxCatName.Size = new System.Drawing.Size(100, 20);
            this.textBoxCatName.TabIndex = 4;
            this.textBoxCatName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCatName_KeyPress);
            // 
            // labelCatName
            // 
            this.labelCatName.AutoSize = true;
            this.labelCatName.Location = new System.Drawing.Point(13, 114);
            this.labelCatName.Name = "labelCatName";
            this.labelCatName.Size = new System.Drawing.Size(80, 13);
            this.labelCatName.TabIndex = 3;
            this.labelCatName.Text = "Category Name";
            // 
            // labelStockType
            // 
            this.labelStockType.AutoSize = true;
            this.labelStockType.Location = new System.Drawing.Point(13, 192);
            this.labelStockType.Name = "labelStockType";
            this.labelStockType.Size = new System.Drawing.Size(107, 13);
            this.labelStockType.TabIndex = 7;
            this.labelStockType.Text = "Category Stock Type";
            // 
            // textBoxCatShortName
            // 
            this.textBoxCatShortName.Location = new System.Drawing.Point(132, 149);
            this.textBoxCatShortName.Name = "textBoxCatShortName";
            this.textBoxCatShortName.Size = new System.Drawing.Size(100, 20);
            this.textBoxCatShortName.TabIndex = 6;
            this.textBoxCatShortName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCatShortName_KeyPress);
            // 
            // labelCatShortName
            // 
            this.labelCatShortName.AutoSize = true;
            this.labelCatShortName.Location = new System.Drawing.Point(13, 153);
            this.labelCatShortName.Name = "labelCatShortName";
            this.labelCatShortName.Size = new System.Drawing.Size(108, 13);
            this.labelCatShortName.TabIndex = 5;
            this.labelCatShortName.Text = "Short Category Name";
            // 
            // textBoxMiscInfo
            // 
            this.textBoxMiscInfo.Location = new System.Drawing.Point(132, 297);
            this.textBoxMiscInfo.Multiline = true;
            this.textBoxMiscInfo.Name = "textBoxMiscInfo";
            this.textBoxMiscInfo.Size = new System.Drawing.Size(100, 38);
            this.textBoxMiscInfo.TabIndex = 12;
            this.textBoxMiscInfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMiscInfo_KeyPress);
            // 
            // labelMiscInfo
            // 
            this.labelMiscInfo.AutoSize = true;
            this.labelMiscInfo.Location = new System.Drawing.Point(13, 301);
            this.labelMiscInfo.Name = "labelMiscInfo";
            this.labelMiscInfo.Size = new System.Drawing.Size(53, 13);
            this.labelMiscInfo.TabIndex = 11;
            this.labelMiscInfo.Text = "Misc Info.";
            // 
            // labelSeasonID
            // 
            this.labelSeasonID.AutoSize = true;
            this.labelSeasonID.Location = new System.Drawing.Point(13, 267);
            this.labelSeasonID.Name = "labelSeasonID";
            this.labelSeasonID.Size = new System.Drawing.Size(91, 13);
            this.labelSeasonID.TabIndex = 9;
            this.labelSeasonID.Text = "Season ID(Name)";
            // 
            // dataGridViewCategory
            // 
            this.dataGridViewCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategory.Location = new System.Drawing.Point(263, 98);
            this.dataGridViewCategory.Name = "dataGridViewCategory";
            this.dataGridViewCategory.ReadOnly = true;
            this.dataGridViewCategory.Size = new System.Drawing.Size(548, 237);
            this.dataGridViewCategory.TabIndex = 13;
            this.dataGridViewCategory.Click += new System.EventHandler(this.dataGridViewCategory_Click);
            // 
            // radioSeasonal
            // 
            this.radioSeasonal.AutoSize = true;
            this.radioSeasonal.Location = new System.Drawing.Point(10, 19);
            this.radioSeasonal.Name = "radioSeasonal";
            this.radioSeasonal.Size = new System.Drawing.Size(69, 17);
            this.radioSeasonal.TabIndex = 14;
            this.radioSeasonal.TabStop = true;
            this.radioSeasonal.Text = "Seasonal";
            this.radioSeasonal.UseVisualStyleBackColor = true;
            // 
            // radioRegular
            // 
            this.radioRegular.AutoSize = true;
            this.radioRegular.Location = new System.Drawing.Point(11, 42);
            this.radioRegular.Name = "radioRegular";
            this.radioRegular.Size = new System.Drawing.Size(62, 17);
            this.radioRegular.TabIndex = 15;
            this.radioRegular.TabStop = true;
            this.radioRegular.Text = "Regular";
            this.radioRegular.UseVisualStyleBackColor = true;
            // 
            // labelCatHint
            // 
            this.labelCatHint.AutoSize = true;
            this.labelCatHint.Location = new System.Drawing.Point(263, 74);
            this.labelCatHint.Name = "labelCatHint";
            this.labelCatHint.Size = new System.Drawing.Size(335, 13);
            this.labelCatHint.TabIndex = 16;
            this.labelCatHint.Text = "**Tip: Click a line below if you want to see detail information in the left.";
            // 
            // buttonCatClear
            // 
            this.buttonCatClear.Location = new System.Drawing.Point(135, 350);
            this.buttonCatClear.Name = "buttonCatClear";
            this.buttonCatClear.Size = new System.Drawing.Size(75, 34);
            this.buttonCatClear.TabIndex = 17;
            this.buttonCatClear.Text = "Clear";
            this.buttonCatClear.UseVisualStyleBackColor = true;
            this.buttonCatClear.Click += new System.EventHandler(this.buttonCatClear_Click);
            // 
            // buttonCatUpdate
            // 
            this.buttonCatUpdate.Location = new System.Drawing.Point(252, 350);
            this.buttonCatUpdate.Name = "buttonCatUpdate";
            this.buttonCatUpdate.Size = new System.Drawing.Size(75, 34);
            this.buttonCatUpdate.TabIndex = 18;
            this.buttonCatUpdate.Text = "Update";
            this.buttonCatUpdate.UseVisualStyleBackColor = true;
            this.buttonCatUpdate.Click += new System.EventHandler(this.buttonCatUpdate_Click);
            // 
            // buttonCatInsert
            // 
            this.buttonCatInsert.Location = new System.Drawing.Point(351, 350);
            this.buttonCatInsert.Name = "buttonCatInsert";
            this.buttonCatInsert.Size = new System.Drawing.Size(75, 34);
            this.buttonCatInsert.TabIndex = 19;
            this.buttonCatInsert.Text = "Insert New";
            this.buttonCatInsert.UseVisualStyleBackColor = true;
            this.buttonCatInsert.Click += new System.EventHandler(this.buttonCatInsert_Click);
            // 
            // buttonCatDelete
            // 
            this.buttonCatDelete.BackColor = System.Drawing.Color.Red;
            this.buttonCatDelete.Location = new System.Drawing.Point(476, 350);
            this.buttonCatDelete.Name = "buttonCatDelete";
            this.buttonCatDelete.Size = new System.Drawing.Size(75, 34);
            this.buttonCatDelete.TabIndex = 20;
            this.buttonCatDelete.Text = "Delete";
            this.buttonCatDelete.UseVisualStyleBackColor = false;
            this.buttonCatDelete.Click += new System.EventHandler(this.buttonCatDelete_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelResult.Location = new System.Drawing.Point(83, 7);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(72, 13);
            this.labelResult.TabIndex = 21;
            this.labelResult.Text = "Results found";
            // 
            // panelResult
            // 
            this.panelResult.BackColor = System.Drawing.Color.AliceBlue;
            this.panelResult.Controls.Add(this.labelSearchResult);
            this.panelResult.Controls.Add(this.labelResult);
            this.panelResult.ForeColor = System.Drawing.Color.MediumBlue;
            this.panelResult.Location = new System.Drawing.Point(640, 63);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(168, 28);
            this.panelResult.TabIndex = 22;
            // 
            // labelSearchResult
            // 
            this.labelSearchResult.AutoSize = true;
            this.labelSearchResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearchResult.ForeColor = System.Drawing.Color.Blue;
            this.labelSearchResult.Location = new System.Drawing.Point(39, 4);
            this.labelSearchResult.Name = "labelSearchResult";
            this.labelSearchResult.Size = new System.Drawing.Size(0, 20);
            this.labelSearchResult.TabIndex = 22;
            // 
            // groupBoxStockType
            // 
            this.groupBoxStockType.Controls.Add(this.radioSeasonal);
            this.groupBoxStockType.Controls.Add(this.radioRegular);
            this.groupBoxStockType.Location = new System.Drawing.Point(132, 175);
            this.groupBoxStockType.Name = "groupBoxStockType";
            this.groupBoxStockType.Size = new System.Drawing.Size(118, 74);
            this.groupBoxStockType.TabIndex = 23;
            this.groupBoxStockType.TabStop = false;
            // 
            // comboBoxCatSeasonID
            // 
            this.comboBoxCatSeasonID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCatSeasonID.FormattingEnabled = true;
            this.comboBoxCatSeasonID.Location = new System.Drawing.Point(132, 263);
            this.comboBoxCatSeasonID.Name = "comboBoxCatSeasonID";
            this.comboBoxCatSeasonID.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCatSeasonID.TabIndex = 24;
            // 
            // formCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 392);
            this.Controls.Add(this.comboBoxCatSeasonID);
            this.Controls.Add(this.groupBoxStockType);
            this.Controls.Add(this.buttonCatDelete);
            this.Controls.Add(this.buttonCatInsert);
            this.Controls.Add(this.buttonCatUpdate);
            this.Controls.Add(this.buttonCatClear);
            this.Controls.Add(this.labelCatHint);
            this.Controls.Add(this.dataGridViewCategory);
            this.Controls.Add(this.textBoxMiscInfo);
            this.Controls.Add(this.labelMiscInfo);
            this.Controls.Add(this.labelSeasonID);
            this.Controls.Add(this.labelStockType);
            this.Controls.Add(this.textBoxCatShortName);
            this.Controls.Add(this.labelCatShortName);
            this.Controls.Add(this.textBoxCatName);
            this.Controls.Add(this.labelCatName);
            this.Controls.Add(this.textBoxCatID);
            this.Controls.Add(this.labelCatID);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelResult);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formCategory";
            this.Text = "Category Management";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formCategory_FormClosed);
            this.Load += new System.EventHandler(this.formCategory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).EndInit();
            this.panelResult.ResumeLayout(false);
            this.panelResult.PerformLayout();
            this.groupBoxStockType.ResumeLayout(false);
            this.groupBoxStockType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label labelSearchBy;
        private System.Windows.Forms.Button buttonCatSearch;
        private System.Windows.Forms.TextBox textCatKeyword;
        private System.Windows.Forms.Label labelCatID;
        private System.Windows.Forms.TextBox textBoxCatID;
        private System.Windows.Forms.TextBox textBoxCatName;
        private System.Windows.Forms.Label labelCatName;
        private System.Windows.Forms.Label labelStockType;
        private System.Windows.Forms.TextBox textBoxCatShortName;
        private System.Windows.Forms.Label labelCatShortName;
        private System.Windows.Forms.TextBox textBoxMiscInfo;
        private System.Windows.Forms.Label labelMiscInfo;
        private System.Windows.Forms.Label labelSeasonID;
        private System.Windows.Forms.DataGridView dataGridViewCategory;
        private System.Windows.Forms.RadioButton radioSeasonal;
        private System.Windows.Forms.RadioButton radioRegular;
        private System.Windows.Forms.Label labelCatHint;
        private System.Windows.Forms.Button buttonCatClear;
        private System.Windows.Forms.Button buttonCatUpdate;
        private System.Windows.Forms.Button buttonCatInsert;
        private System.Windows.Forms.Button buttonCatDelete;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.Label labelSearchResult;
        private System.Windows.Forms.GroupBox groupBoxStockType;
        private System.Windows.Forms.ComboBox comboBoxCatSeasonID;
        private System.Windows.Forms.ComboBox comboBoxCatSearchList;
    }
}

