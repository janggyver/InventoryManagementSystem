namespace BESeason
{
    partial class formSeason
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSeason));
            this.labelSeasonSearchBy = new System.Windows.Forms.Label();
            this.buttonSeasonDelete = new System.Windows.Forms.Button();
            this.buttonSeasonInsert = new System.Windows.Forms.Button();
            this.buttonSeasonUpdate = new System.Windows.Forms.Button();
            this.buttonSeasonClear = new System.Windows.Forms.Button();
            this.labelSeasonHint = new System.Windows.Forms.Label();
            this.dataGridViewSeason = new System.Windows.Forms.DataGridView();
            this.textBoxSeasonDesc = new System.Windows.Forms.TextBox();
            this.labelSeasonDesc = new System.Windows.Forms.Label();
            this.textBoxSeasonID = new System.Windows.Forms.TextBox();
            this.labelSeasonID = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxSeasonSearchList = new System.Windows.Forms.ComboBox();
            this.buttonSeasonSearch = new System.Windows.Forms.Button();
            this.textSeasonKeyword = new System.Windows.Forms.TextBox();
            this.comboSeason = new System.Windows.Forms.ComboBox();
            this.panelResult = new System.Windows.Forms.Panel();
            this.labelSearchResult = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelSeasonStartDate = new System.Windows.Forms.Label();
            this.labelSeasonEndDate = new System.Windows.Forms.Label();
            this.dateTimePickerSeasonStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSeasonEnd = new System.Windows.Forms.DateTimePicker();
            this.buttonForcedEdit = new System.Windows.Forms.Button();
            this.buttonForcedUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeason)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSeasonSearchBy
            // 
            this.labelSeasonSearchBy.AutoSize = true;
            this.labelSeasonSearchBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSeasonSearchBy.Location = new System.Drawing.Point(25, 20);
            this.labelSeasonSearchBy.Name = "labelSeasonSearchBy";
            this.labelSeasonSearchBy.Size = new System.Drawing.Size(78, 16);
            this.labelSeasonSearchBy.TabIndex = 0;
            this.labelSeasonSearchBy.Text = "Search by";
            // 
            // buttonSeasonDelete
            // 
            this.buttonSeasonDelete.BackColor = System.Drawing.Color.Red;
            this.buttonSeasonDelete.Location = new System.Drawing.Point(476, 350);
            this.buttonSeasonDelete.Name = "buttonSeasonDelete";
            this.buttonSeasonDelete.Size = new System.Drawing.Size(75, 34);
            this.buttonSeasonDelete.TabIndex = 41;
            this.buttonSeasonDelete.Text = "Delete";
            this.buttonSeasonDelete.UseVisualStyleBackColor = false;
            this.buttonSeasonDelete.Click += new System.EventHandler(this.buttonSeasonDelete_Click);
            // 
            // buttonSeasonInsert
            // 
            this.buttonSeasonInsert.Location = new System.Drawing.Point(351, 350);
            this.buttonSeasonInsert.Name = "buttonSeasonInsert";
            this.buttonSeasonInsert.Size = new System.Drawing.Size(75, 34);
            this.buttonSeasonInsert.TabIndex = 40;
            this.buttonSeasonInsert.Text = "Insert New";
            this.buttonSeasonInsert.UseVisualStyleBackColor = true;
            this.buttonSeasonInsert.Click += new System.EventHandler(this.buttonSeasonInsert_Click);
            // 
            // buttonSeasonUpdate
            // 
            this.buttonSeasonUpdate.Location = new System.Drawing.Point(252, 350);
            this.buttonSeasonUpdate.Name = "buttonSeasonUpdate";
            this.buttonSeasonUpdate.Size = new System.Drawing.Size(75, 34);
            this.buttonSeasonUpdate.TabIndex = 39;
            this.buttonSeasonUpdate.Text = "Update";
            this.buttonSeasonUpdate.UseVisualStyleBackColor = true;
            this.buttonSeasonUpdate.Click += new System.EventHandler(this.buttonSeasonUpdate_Click);
            // 
            // buttonSeasonClear
            // 
            this.buttonSeasonClear.Location = new System.Drawing.Point(135, 350);
            this.buttonSeasonClear.Name = "buttonSeasonClear";
            this.buttonSeasonClear.Size = new System.Drawing.Size(75, 34);
            this.buttonSeasonClear.TabIndex = 38;
            this.buttonSeasonClear.Text = "Clear";
            this.buttonSeasonClear.UseVisualStyleBackColor = true;
            this.buttonSeasonClear.Click += new System.EventHandler(this.buttonSeasonClear_Click);
            // 
            // labelSeasonHint
            // 
            this.labelSeasonHint.AutoSize = true;
            this.labelSeasonHint.Location = new System.Drawing.Point(263, 74);
            this.labelSeasonHint.Name = "labelSeasonHint";
            this.labelSeasonHint.Size = new System.Drawing.Size(335, 13);
            this.labelSeasonHint.TabIndex = 37;
            this.labelSeasonHint.Text = "**Tip: Click a line below if you want to see detail information in the left.";
            // 
            // dataGridViewSeason
            // 
            this.dataGridViewSeason.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeason.Location = new System.Drawing.Point(263, 98);
            this.dataGridViewSeason.Name = "dataGridViewSeason";
            this.dataGridViewSeason.ReadOnly = true;
            this.dataGridViewSeason.Size = new System.Drawing.Size(548, 237);
            this.dataGridViewSeason.TabIndex = 36;
            this.dataGridViewSeason.Click += new System.EventHandler(this.dataGridViewSeason_Click);
            // 
            // textBoxSeasonDesc
            // 
            this.textBoxSeasonDesc.Location = new System.Drawing.Point(132, 110);
            this.textBoxSeasonDesc.Multiline = true;
            this.textBoxSeasonDesc.Name = "textBoxSeasonDesc";
            this.textBoxSeasonDesc.Size = new System.Drawing.Size(100, 42);
            this.textBoxSeasonDesc.TabIndex = 28;
            this.textBoxSeasonDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSeasonDesc_KeyPress);
            // 
            // labelSeasonDesc
            // 
            this.labelSeasonDesc.AutoSize = true;
            this.labelSeasonDesc.Location = new System.Drawing.Point(13, 114);
            this.labelSeasonDesc.Name = "labelSeasonDesc";
            this.labelSeasonDesc.Size = new System.Drawing.Size(99, 13);
            this.labelSeasonDesc.TabIndex = 27;
            this.labelSeasonDesc.Text = "Season Description";
            // 
            // textBoxSeasonID
            // 
            this.textBoxSeasonID.Location = new System.Drawing.Point(132, 71);
            this.textBoxSeasonID.Name = "textBoxSeasonID";
            this.textBoxSeasonID.Size = new System.Drawing.Size(100, 20);
            this.textBoxSeasonID.TabIndex = 26;
            this.textBoxSeasonID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSeasonID_KeyPress);
            // 
            // labelSeasonID
            // 
            this.labelSeasonID.AutoSize = true;
            this.labelSeasonID.Location = new System.Drawing.Point(13, 75);
            this.labelSeasonID.Name = "labelSeasonID";
            this.labelSeasonID.Size = new System.Drawing.Size(91, 13);
            this.labelSeasonID.TabIndex = 25;
            this.labelSeasonID.Text = "Season ID(Name)";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.comboBoxSeasonSearchList);
            this.panel1.Controls.Add(this.buttonSeasonSearch);
            this.panel1.Controls.Add(this.textSeasonKeyword);
            this.panel1.Controls.Add(this.comboSeason);
            this.panel1.Controls.Add(this.labelSeasonSearchBy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 56);
            this.panel1.TabIndex = 24;
            // 
            // comboBoxSeasonSearchList
            // 
            this.comboBoxSeasonSearchList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSeasonSearchList.FormattingEnabled = true;
            this.comboBoxSeasonSearchList.Items.AddRange(new object[] {
            "Season ID",
            "Season Description",
            "Any Values"});
            this.comboBoxSeasonSearchList.Location = new System.Drawing.Point(248, 18);
            this.comboBoxSeasonSearchList.Name = "comboBoxSeasonSearchList";
            this.comboBoxSeasonSearchList.Size = new System.Drawing.Size(134, 21);
            this.comboBoxSeasonSearchList.TabIndex = 4;
            // 
            // buttonSeasonSearch
            // 
            this.buttonSeasonSearch.Location = new System.Drawing.Point(408, 10);
            this.buttonSeasonSearch.Name = "buttonSeasonSearch";
            this.buttonSeasonSearch.Size = new System.Drawing.Size(75, 37);
            this.buttonSeasonSearch.TabIndex = 3;
            this.buttonSeasonSearch.Text = "Search";
            this.buttonSeasonSearch.UseVisualStyleBackColor = true;
            this.buttonSeasonSearch.Click += new System.EventHandler(this.buttonSeasonSearch_Click);
            // 
            // textSeasonKeyword
            // 
            this.textSeasonKeyword.Location = new System.Drawing.Point(248, 18);
            this.textSeasonKeyword.Name = "textSeasonKeyword";
            this.textSeasonKeyword.Size = new System.Drawing.Size(134, 20);
            this.textSeasonKeyword.TabIndex = 2;
            this.textSeasonKeyword.TextChanged += new System.EventHandler(this.textSeasonKeyword_TextChanged);
            // 
            // comboSeason
            // 
            this.comboSeason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSeason.FormattingEnabled = true;
            this.comboSeason.Items.AddRange(new object[] {
            "Season ID",
            "Season Description",
            "Any Values"});
            this.comboSeason.Location = new System.Drawing.Point(109, 18);
            this.comboSeason.Name = "comboSeason";
            this.comboSeason.Size = new System.Drawing.Size(121, 21);
            this.comboSeason.TabIndex = 1;
            this.comboSeason.SelectedIndexChanged += new System.EventHandler(this.comboSeason_SelectedIndexChanged);
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
            this.panelResult.TabIndex = 42;
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
            // labelSeasonStartDate
            // 
            this.labelSeasonStartDate.AutoSize = true;
            this.labelSeasonStartDate.Location = new System.Drawing.Point(13, 176);
            this.labelSeasonStartDate.Name = "labelSeasonStartDate";
            this.labelSeasonStartDate.Size = new System.Drawing.Size(94, 13);
            this.labelSeasonStartDate.TabIndex = 43;
            this.labelSeasonStartDate.Text = "Season Start Date";
            // 
            // labelSeasonEndDate
            // 
            this.labelSeasonEndDate.AutoSize = true;
            this.labelSeasonEndDate.Location = new System.Drawing.Point(13, 232);
            this.labelSeasonEndDate.Name = "labelSeasonEndDate";
            this.labelSeasonEndDate.Size = new System.Drawing.Size(91, 13);
            this.labelSeasonEndDate.TabIndex = 45;
            this.labelSeasonEndDate.Text = "Season End Date";
            // 
            // dateTimePickerSeasonStart
            // 
            this.dateTimePickerSeasonStart.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerSeasonStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSeasonStart.Location = new System.Drawing.Point(132, 176);
            this.dateTimePickerSeasonStart.Name = "dateTimePickerSeasonStart";
            this.dateTimePickerSeasonStart.Size = new System.Drawing.Size(100, 20);
            this.dateTimePickerSeasonStart.TabIndex = 47;
            // 
            // dateTimePickerSeasonEnd
            // 
            this.dateTimePickerSeasonEnd.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerSeasonEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSeasonEnd.Location = new System.Drawing.Point(132, 228);
            this.dateTimePickerSeasonEnd.Name = "dateTimePickerSeasonEnd";
            this.dateTimePickerSeasonEnd.Size = new System.Drawing.Size(100, 20);
            this.dateTimePickerSeasonEnd.TabIndex = 48;
            // 
            // buttonForcedEdit
            // 
            this.buttonForcedEdit.BackColor = System.Drawing.Color.Lime;
            this.buttonForcedEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonForcedEdit.Location = new System.Drawing.Point(585, 350);
            this.buttonForcedEdit.Name = "buttonForcedEdit";
            this.buttonForcedEdit.Size = new System.Drawing.Size(75, 34);
            this.buttonForcedEdit.TabIndex = 41;
            this.buttonForcedEdit.Text = "Forced Edit";
            this.buttonForcedEdit.UseVisualStyleBackColor = false;
            this.buttonForcedEdit.Click += new System.EventHandler(this.buttonForcedEdit_Click);
            // 
            // buttonForcedUpdate
            // 
            this.buttonForcedUpdate.BackColor = System.Drawing.Color.MediumTurquoise;
            this.buttonForcedUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonForcedUpdate.Location = new System.Drawing.Point(666, 350);
            this.buttonForcedUpdate.Name = "buttonForcedUpdate";
            this.buttonForcedUpdate.Size = new System.Drawing.Size(75, 34);
            this.buttonForcedUpdate.TabIndex = 49;
            this.buttonForcedUpdate.Text = "Forced Update";
            this.buttonForcedUpdate.UseVisualStyleBackColor = false;
            this.buttonForcedUpdate.Click += new System.EventHandler(this.buttonForcedUpdate_Click);
            // 
            // formSeason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 400);
            this.Controls.Add(this.buttonForcedUpdate);
            this.Controls.Add(this.dateTimePickerSeasonEnd);
            this.Controls.Add(this.dateTimePickerSeasonStart);
            this.Controls.Add(this.labelSeasonEndDate);
            this.Controls.Add(this.labelSeasonStartDate);
            this.Controls.Add(this.buttonForcedEdit);
            this.Controls.Add(this.buttonSeasonDelete);
            this.Controls.Add(this.buttonSeasonInsert);
            this.Controls.Add(this.buttonSeasonUpdate);
            this.Controls.Add(this.buttonSeasonClear);
            this.Controls.Add(this.labelSeasonHint);
            this.Controls.Add(this.dataGridViewSeason);
            this.Controls.Add(this.textBoxSeasonDesc);
            this.Controls.Add(this.labelSeasonDesc);
            this.Controls.Add(this.textBoxSeasonID);
            this.Controls.Add(this.labelSeasonID);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelResult);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formSeason";
            this.Text = "Season Management";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formSeason_FormClosed);
            this.Load += new System.EventHandler(this.formSeason_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeason)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelResult.ResumeLayout(false);
            this.panelResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSeasonSearchBy;
        private System.Windows.Forms.Button buttonSeasonDelete;
        private System.Windows.Forms.Button buttonSeasonInsert;
        private System.Windows.Forms.Button buttonSeasonUpdate;
        private System.Windows.Forms.Button buttonSeasonClear;
        private System.Windows.Forms.Label labelSeasonHint;
        private System.Windows.Forms.DataGridView dataGridViewSeason;
        private System.Windows.Forms.TextBox textBoxSeasonDesc;
        private System.Windows.Forms.Label labelSeasonDesc;
        private System.Windows.Forms.TextBox textBoxSeasonID;
        private System.Windows.Forms.Label labelSeasonID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSeasonSearch;
        private System.Windows.Forms.TextBox textSeasonKeyword;
        private System.Windows.Forms.ComboBox comboSeason;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.Label labelSearchResult;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label labelSeasonStartDate;
        private System.Windows.Forms.Label labelSeasonEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerSeasonStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerSeasonEnd;
        private System.Windows.Forms.ComboBox comboBoxSeasonSearchList;
        private System.Windows.Forms.Button buttonForcedEdit;
        private System.Windows.Forms.Button buttonForcedUpdate;
    }
}

