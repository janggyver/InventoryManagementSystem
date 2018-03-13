namespace BEInventory
{
    partial class FormInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInventory));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonInvSearch = new System.Windows.Forms.Button();
            this.textBoxInvSearchKeyword = new System.Windows.Forms.TextBox();
            this.comboBoxInvSearch = new System.Windows.Forms.ComboBox();
            this.labelProdSearchBy = new System.Windows.Forms.Label();
            this.dataGridViewInventory = new System.Windows.Forms.DataGridView();
            this.comboBoxInvCaseCount = new System.Windows.Forms.ComboBox();
            this.comboBoxInvSup = new System.Windows.Forms.ComboBox();
            this.comboBoxInvProdCatID = new System.Windows.Forms.ComboBox();
            this.labelProdCaseSize = new System.Windows.Forms.Label();
            this.textBoxInvProdCaseSize = new System.Windows.Forms.TextBox();
            this.labelProdCaseWeight = new System.Windows.Forms.Label();
            this.labelProdPriceRetail = new System.Windows.Forms.Label();
            this.labelProdSupID = new System.Windows.Forms.Label();
            this.labelProdCaseCount = new System.Windows.Forms.Label();
            this.labelProdCatID = new System.Windows.Forms.Label();
            this.labelProdPricePrev = new System.Windows.Forms.Label();
            this.labelProdSize = new System.Windows.Forms.Label();
            this.labelProdPricePurch = new System.Windows.Forms.Label();
            this.labelProdWeight = new System.Windows.Forms.Label();
            this.labelProdType = new System.Windows.Forms.Label();
            this.labelProdDesc = new System.Windows.Forms.Label();
            this.labelProdSUPSKU = new System.Windows.Forms.Label();
            this.textBoxInvProdCaseWeight = new System.Windows.Forms.TextBox();
            this.textBoxInvProdPricePrev = new System.Windows.Forms.TextBox();
            this.textBoxInvProdPriceRetail = new System.Windows.Forms.TextBox();
            this.textBoxInvProdPricePurch = new System.Windows.Forms.TextBox();
            this.textBoxInvProdWeight = new System.Windows.Forms.TextBox();
            this.textBoxInvProdSize = new System.Windows.Forms.TextBox();
            this.textBoxInvProdType = new System.Windows.Forms.TextBox();
            this.textBoxInvProdDesc = new System.Windows.Forms.TextBox();
            this.textBoxInvProdColor = new System.Windows.Forms.TextBox();
            this.textBoxInvProdName = new System.Windows.Forms.TextBox();
            this.labelProdColor = new System.Windows.Forms.Label();
            this.labelProdDetail = new System.Windows.Forms.Label();
            this.textBoxInvProdSUPSKU = new System.Windows.Forms.TextBox();
            this.labelProdName = new System.Windows.Forms.Label();
            this.textBoxInvProdBESKU = new System.Windows.Forms.TextBox();
            this.labelProdBESKU = new System.Windows.Forms.Label();
            this.panelDetailProdInfo = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelInvDetail = new System.Windows.Forms.Label();
            this.comboBoxInvShelfLoc = new System.Windows.Forms.ComboBox();
            this.comboBoxInvLocation = new System.Windows.Forms.ComboBox();
            this.textBoxInvMinQTY = new System.Windows.Forms.TextBox();
            this.textBoxInvMaxQTY = new System.Windows.Forms.TextBox();
            this.labelInvMaxQTY = new System.Windows.Forms.Label();
            this.labelInventoryID = new System.Windows.Forms.Label();
            this.textBoxInvProdID = new System.Windows.Forms.TextBox();
            this.textBoxInvID = new System.Windows.Forms.TextBox();
            this.labelInvLocation = new System.Windows.Forms.Label();
            this.labelInvQOH = new System.Windows.Forms.Label();
            this.labelInvProdID = new System.Windows.Forms.Label();
            this.labelInvTransientQTY = new System.Windows.Forms.Label();
            this.textBoxInvQOH = new System.Windows.Forms.TextBox();
            this.textBoxInvTransientQTY = new System.Windows.Forms.TextBox();
            this.labelInvShelfLoc = new System.Windows.Forms.Label();
            this.labelInvMinQTY = new System.Windows.Forms.Label();
            this.labelInvHint = new System.Windows.Forms.Label();
            this.panelInvResult = new System.Windows.Forms.Panel();
            this.labelInvSearchResult = new System.Windows.Forms.Label();
            this.labelInvResult = new System.Windows.Forms.Label();
            this.buttonInvInsertTry = new System.Windows.Forms.Button();
            this.buttonInvEdit = new System.Windows.Forms.Button();
            this.buttonInvClear = new System.Windows.Forms.Button();
            this.buttonInvDelete = new System.Windows.Forms.Button();
            this.buttonInvAdjust = new System.Windows.Forms.Button();
            this.panelInvNormal = new System.Windows.Forms.Panel();
            this.labelInvView = new System.Windows.Forms.Label();
            this.buttonSaveNewInvWithExist = new System.Windows.Forms.Button();
            this.panelInvButtons = new System.Windows.Forms.Panel();
            this.buttonInvUpdate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            this.panelDetailProdInfo.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelInvResult.SuspendLayout();
            this.panelInvNormal.SuspendLayout();
            this.panelInvButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.buttonInvSearch);
            this.panel1.Controls.Add(this.textBoxInvSearchKeyword);
            this.panel1.Controls.Add(this.comboBoxInvSearch);
            this.panel1.Controls.Add(this.labelProdSearchBy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 56);
            this.panel1.TabIndex = 2;
            // 
            // buttonInvSearch
            // 
            this.buttonInvSearch.Location = new System.Drawing.Point(408, 10);
            this.buttonInvSearch.Name = "buttonInvSearch";
            this.buttonInvSearch.Size = new System.Drawing.Size(75, 37);
            this.buttonInvSearch.TabIndex = 3;
            this.buttonInvSearch.Text = "Search";
            this.buttonInvSearch.UseVisualStyleBackColor = true;
            this.buttonInvSearch.Click += new System.EventHandler(this.buttonInvSearch_Click);
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
            "Inventory ID",
            "Product ID",
            "Product Name",
            "BE SKU",
            "Supplier SKU",
            "Any Values"});
            this.comboBoxInvSearch.Location = new System.Drawing.Point(109, 18);
            this.comboBoxInvSearch.Name = "comboBoxInvSearch";
            this.comboBoxInvSearch.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInvSearch.TabIndex = 1;
            this.comboBoxInvSearch.SelectedIndexChanged += new System.EventHandler(this.comboBoxInvSearch_SelectedIndexChanged);
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
            // dataGridViewInventory
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewInventory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewInventory.Location = new System.Drawing.Point(13, 38);
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInventory.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewInventory.Size = new System.Drawing.Size(963, 113);
            this.dataGridViewInventory.TabIndex = 36;
            this.dataGridViewInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInventory_CellClick);
            // 
            // comboBoxInvCaseCount
            // 
            this.comboBoxInvCaseCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInvCaseCount.Location = new System.Drawing.Point(398, 201);
            this.comboBoxInvCaseCount.Name = "comboBoxInvCaseCount";
            this.comboBoxInvCaseCount.Size = new System.Drawing.Size(100, 21);
            this.comboBoxInvCaseCount.TabIndex = 103;
            // 
            // comboBoxInvSup
            // 
            this.comboBoxInvSup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInvSup.Location = new System.Drawing.Point(398, 282);
            this.comboBoxInvSup.Name = "comboBoxInvSup";
            this.comboBoxInvSup.Size = new System.Drawing.Size(100, 21);
            this.comboBoxInvSup.TabIndex = 102;
            // 
            // comboBoxInvProdCatID
            // 
            this.comboBoxInvProdCatID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInvProdCatID.Location = new System.Drawing.Point(398, 92);
            this.comboBoxInvProdCatID.Name = "comboBoxInvProdCatID";
            this.comboBoxInvProdCatID.Size = new System.Drawing.Size(100, 21);
            this.comboBoxInvProdCatID.TabIndex = 70;
            // 
            // labelProdCaseSize
            // 
            this.labelProdCaseSize.AutoSize = true;
            this.labelProdCaseSize.Location = new System.Drawing.Point(279, 231);
            this.labelProdCaseSize.Name = "labelProdCaseSize";
            this.labelProdCaseSize.Size = new System.Drawing.Size(54, 13);
            this.labelProdCaseSize.TabIndex = 101;
            this.labelProdCaseSize.Text = "Case Size";
            // 
            // textBoxInvProdCaseSize
            // 
            this.textBoxInvProdCaseSize.Location = new System.Drawing.Point(398, 227);
            this.textBoxInvProdCaseSize.Name = "textBoxInvProdCaseSize";
            this.textBoxInvProdCaseSize.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvProdCaseSize.TabIndex = 100;
            // 
            // labelProdCaseWeight
            // 
            this.labelProdCaseWeight.AutoSize = true;
            this.labelProdCaseWeight.Location = new System.Drawing.Point(279, 259);
            this.labelProdCaseWeight.Name = "labelProdCaseWeight";
            this.labelProdCaseWeight.Size = new System.Drawing.Size(68, 13);
            this.labelProdCaseWeight.TabIndex = 99;
            this.labelProdCaseWeight.Text = "Case Weight";
            // 
            // labelProdPriceRetail
            // 
            this.labelProdPriceRetail.AutoSize = true;
            this.labelProdPriceRetail.Location = new System.Drawing.Point(279, 151);
            this.labelProdPriceRetail.Name = "labelProdPriceRetail";
            this.labelProdPriceRetail.Size = new System.Drawing.Size(61, 13);
            this.labelProdPriceRetail.TabIndex = 98;
            this.labelProdPriceRetail.Text = "Retail Price";
            // 
            // labelProdSupID
            // 
            this.labelProdSupID.AutoSize = true;
            this.labelProdSupID.Location = new System.Drawing.Point(279, 286);
            this.labelProdSupID.Name = "labelProdSupID";
            this.labelProdSupID.Size = new System.Drawing.Size(59, 13);
            this.labelProdSupID.TabIndex = 97;
            this.labelProdSupID.Text = "Supplier ID";
            // 
            // labelProdCaseCount
            // 
            this.labelProdCaseCount.AutoSize = true;
            this.labelProdCaseCount.Location = new System.Drawing.Point(279, 205);
            this.labelProdCaseCount.Name = "labelProdCaseCount";
            this.labelProdCaseCount.Size = new System.Drawing.Size(62, 13);
            this.labelProdCaseCount.TabIndex = 96;
            this.labelProdCaseCount.Text = "Case Count";
            // 
            // labelProdCatID
            // 
            this.labelProdCatID.AutoSize = true;
            this.labelProdCatID.Location = new System.Drawing.Point(279, 96);
            this.labelProdCatID.Name = "labelProdCatID";
            this.labelProdCatID.Size = new System.Drawing.Size(63, 13);
            this.labelProdCatID.TabIndex = 95;
            this.labelProdCatID.Text = "Category ID";
            // 
            // labelProdPricePrev
            // 
            this.labelProdPricePrev.AutoSize = true;
            this.labelProdPricePrev.Location = new System.Drawing.Point(279, 178);
            this.labelProdPricePrev.Name = "labelProdPricePrev";
            this.labelProdPricePrev.Size = new System.Drawing.Size(75, 13);
            this.labelProdPricePrev.TabIndex = 94;
            this.labelProdPricePrev.Text = "Previous Price";
            // 
            // labelProdSize
            // 
            this.labelProdSize.AutoSize = true;
            this.labelProdSize.Location = new System.Drawing.Point(19, 263);
            this.labelProdSize.Name = "labelProdSize";
            this.labelProdSize.Size = new System.Drawing.Size(67, 13);
            this.labelProdSize.TabIndex = 91;
            this.labelProdSize.Text = "Product Size";
            // 
            // labelProdPricePurch
            // 
            this.labelProdPricePurch.AutoSize = true;
            this.labelProdPricePurch.Location = new System.Drawing.Point(279, 124);
            this.labelProdPricePurch.Name = "labelProdPricePurch";
            this.labelProdPricePurch.Size = new System.Drawing.Size(85, 13);
            this.labelProdPricePurch.TabIndex = 93;
            this.labelProdPricePurch.Text = "Price Purchased";
            // 
            // labelProdWeight
            // 
            this.labelProdWeight.AutoSize = true;
            this.labelProdWeight.Location = new System.Drawing.Point(19, 290);
            this.labelProdWeight.Name = "labelProdWeight";
            this.labelProdWeight.Size = new System.Drawing.Size(81, 13);
            this.labelProdWeight.TabIndex = 92;
            this.labelProdWeight.Text = "Product Weight";
            // 
            // labelProdType
            // 
            this.labelProdType.AutoSize = true;
            this.labelProdType.Location = new System.Drawing.Point(19, 236);
            this.labelProdType.Name = "labelProdType";
            this.labelProdType.Size = new System.Drawing.Size(71, 13);
            this.labelProdType.TabIndex = 90;
            this.labelProdType.Text = "Product Type";
            // 
            // labelProdDesc
            // 
            this.labelProdDesc.AutoSize = true;
            this.labelProdDesc.Location = new System.Drawing.Point(19, 180);
            this.labelProdDesc.Name = "labelProdDesc";
            this.labelProdDesc.Size = new System.Drawing.Size(75, 13);
            this.labelProdDesc.TabIndex = 89;
            this.labelProdDesc.Text = "Product Desc.";
            // 
            // labelProdSUPSKU
            // 
            this.labelProdSUPSKU.AutoSize = true;
            this.labelProdSUPSKU.Location = new System.Drawing.Point(19, 68);
            this.labelProdSUPSKU.Name = "labelProdSUPSKU";
            this.labelProdSUPSKU.Size = new System.Drawing.Size(70, 13);
            this.labelProdSUPSKU.TabIndex = 88;
            this.labelProdSUPSKU.Text = "Supplier SKU";
            // 
            // textBoxInvProdCaseWeight
            // 
            this.textBoxInvProdCaseWeight.Location = new System.Drawing.Point(398, 255);
            this.textBoxInvProdCaseWeight.Name = "textBoxInvProdCaseWeight";
            this.textBoxInvProdCaseWeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvProdCaseWeight.TabIndex = 87;
            // 
            // textBoxInvProdPricePrev
            // 
            this.textBoxInvProdPricePrev.Location = new System.Drawing.Point(398, 174);
            this.textBoxInvProdPricePrev.Name = "textBoxInvProdPricePrev";
            this.textBoxInvProdPricePrev.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvProdPricePrev.TabIndex = 86;
            // 
            // textBoxInvProdPriceRetail
            // 
            this.textBoxInvProdPriceRetail.Location = new System.Drawing.Point(398, 147);
            this.textBoxInvProdPriceRetail.Name = "textBoxInvProdPriceRetail";
            this.textBoxInvProdPriceRetail.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvProdPriceRetail.TabIndex = 85;
            // 
            // textBoxInvProdPricePurch
            // 
            this.textBoxInvProdPricePurch.Location = new System.Drawing.Point(398, 120);
            this.textBoxInvProdPricePurch.Name = "textBoxInvProdPricePurch";
            this.textBoxInvProdPricePurch.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvProdPricePurch.TabIndex = 84;
            // 
            // textBoxInvProdWeight
            // 
            this.textBoxInvProdWeight.Location = new System.Drawing.Point(138, 287);
            this.textBoxInvProdWeight.Name = "textBoxInvProdWeight";
            this.textBoxInvProdWeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvProdWeight.TabIndex = 83;
            // 
            // textBoxInvProdSize
            // 
            this.textBoxInvProdSize.Location = new System.Drawing.Point(138, 260);
            this.textBoxInvProdSize.Name = "textBoxInvProdSize";
            this.textBoxInvProdSize.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvProdSize.TabIndex = 82;
            // 
            // textBoxInvProdType
            // 
            this.textBoxInvProdType.Location = new System.Drawing.Point(138, 232);
            this.textBoxInvProdType.Name = "textBoxInvProdType";
            this.textBoxInvProdType.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvProdType.TabIndex = 81;
            // 
            // textBoxInvProdDesc
            // 
            this.textBoxInvProdDesc.Location = new System.Drawing.Point(138, 176);
            this.textBoxInvProdDesc.Multiline = true;
            this.textBoxInvProdDesc.Name = "textBoxInvProdDesc";
            this.textBoxInvProdDesc.Size = new System.Drawing.Size(100, 50);
            this.textBoxInvProdDesc.TabIndex = 80;
            // 
            // textBoxInvProdColor
            // 
            this.textBoxInvProdColor.Location = new System.Drawing.Point(138, 149);
            this.textBoxInvProdColor.Name = "textBoxInvProdColor";
            this.textBoxInvProdColor.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvProdColor.TabIndex = 79;
            // 
            // textBoxInvProdName
            // 
            this.textBoxInvProdName.Location = new System.Drawing.Point(138, 91);
            this.textBoxInvProdName.Multiline = true;
            this.textBoxInvProdName.Name = "textBoxInvProdName";
            this.textBoxInvProdName.Size = new System.Drawing.Size(100, 52);
            this.textBoxInvProdName.TabIndex = 78;
            // 
            // labelProdColor
            // 
            this.labelProdColor.AutoSize = true;
            this.labelProdColor.Location = new System.Drawing.Point(19, 153);
            this.labelProdColor.Name = "labelProdColor";
            this.labelProdColor.Size = new System.Drawing.Size(71, 13);
            this.labelProdColor.TabIndex = 77;
            this.labelProdColor.Text = "Product Color";
            // 
            // labelProdDetail
            // 
            this.labelProdDetail.AutoSize = true;
            this.labelProdDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProdDetail.Location = new System.Drawing.Point(19, 14);
            this.labelProdDetail.Name = "labelProdDetail";
            this.labelProdDetail.Size = new System.Drawing.Size(159, 13);
            this.labelProdDetail.TabIndex = 71;
            this.labelProdDetail.Text = "Detail Product Information ";
            // 
            // textBoxInvProdSUPSKU
            // 
            this.textBoxInvProdSUPSKU.Location = new System.Drawing.Point(138, 64);
            this.textBoxInvProdSUPSKU.Name = "textBoxInvProdSUPSKU";
            this.textBoxInvProdSUPSKU.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvProdSUPSKU.TabIndex = 76;
            // 
            // labelProdName
            // 
            this.labelProdName.AutoSize = true;
            this.labelProdName.Location = new System.Drawing.Point(19, 95);
            this.labelProdName.Name = "labelProdName";
            this.labelProdName.Size = new System.Drawing.Size(75, 13);
            this.labelProdName.TabIndex = 75;
            this.labelProdName.Text = "Product Name";
            // 
            // textBoxInvProdBESKU
            // 
            this.textBoxInvProdBESKU.Location = new System.Drawing.Point(138, 37);
            this.textBoxInvProdBESKU.Name = "textBoxInvProdBESKU";
            this.textBoxInvProdBESKU.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvProdBESKU.TabIndex = 74;
            // 
            // labelProdBESKU
            // 
            this.labelProdBESKU.AutoSize = true;
            this.labelProdBESKU.Location = new System.Drawing.Point(19, 41);
            this.labelProdBESKU.Name = "labelProdBESKU";
            this.labelProdBESKU.Size = new System.Drawing.Size(46, 13);
            this.labelProdBESKU.TabIndex = 73;
            this.labelProdBESKU.Text = "BE SKU";
            // 
            // panelDetailProdInfo
            // 
            this.panelDetailProdInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetailProdInfo.Controls.Add(this.textBoxInvProdType);
            this.panelDetailProdInfo.Controls.Add(this.labelProdBESKU);
            this.panelDetailProdInfo.Controls.Add(this.comboBoxInvCaseCount);
            this.panelDetailProdInfo.Controls.Add(this.textBoxInvProdBESKU);
            this.panelDetailProdInfo.Controls.Add(this.comboBoxInvSup);
            this.panelDetailProdInfo.Controls.Add(this.labelProdName);
            this.panelDetailProdInfo.Controls.Add(this.comboBoxInvProdCatID);
            this.panelDetailProdInfo.Controls.Add(this.textBoxInvProdSUPSKU);
            this.panelDetailProdInfo.Controls.Add(this.labelProdCaseSize);
            this.panelDetailProdInfo.Controls.Add(this.labelProdDetail);
            this.panelDetailProdInfo.Controls.Add(this.textBoxInvProdCaseSize);
            this.panelDetailProdInfo.Controls.Add(this.labelProdColor);
            this.panelDetailProdInfo.Controls.Add(this.labelProdCaseWeight);
            this.panelDetailProdInfo.Controls.Add(this.textBoxInvProdName);
            this.panelDetailProdInfo.Controls.Add(this.labelProdPriceRetail);
            this.panelDetailProdInfo.Controls.Add(this.textBoxInvProdColor);
            this.panelDetailProdInfo.Controls.Add(this.labelProdSupID);
            this.panelDetailProdInfo.Controls.Add(this.textBoxInvProdDesc);
            this.panelDetailProdInfo.Controls.Add(this.labelProdCaseCount);
            this.panelDetailProdInfo.Controls.Add(this.textBoxInvProdSize);
            this.panelDetailProdInfo.Controls.Add(this.labelProdCatID);
            this.panelDetailProdInfo.Controls.Add(this.textBoxInvProdWeight);
            this.panelDetailProdInfo.Controls.Add(this.labelProdPricePrev);
            this.panelDetailProdInfo.Controls.Add(this.textBoxInvProdPricePurch);
            this.panelDetailProdInfo.Controls.Add(this.labelProdSize);
            this.panelDetailProdInfo.Controls.Add(this.textBoxInvProdPriceRetail);
            this.panelDetailProdInfo.Controls.Add(this.labelProdPricePurch);
            this.panelDetailProdInfo.Controls.Add(this.textBoxInvProdPricePrev);
            this.panelDetailProdInfo.Controls.Add(this.labelProdWeight);
            this.panelDetailProdInfo.Controls.Add(this.textBoxInvProdCaseWeight);
            this.panelDetailProdInfo.Controls.Add(this.labelProdType);
            this.panelDetailProdInfo.Controls.Add(this.labelProdSUPSKU);
            this.panelDetailProdInfo.Controls.Add(this.labelProdDesc);
            this.panelDetailProdInfo.Location = new System.Drawing.Point(462, 218);
            this.panelDetailProdInfo.Name = "panelDetailProdInfo";
            this.panelDetailProdInfo.Size = new System.Drawing.Size(529, 323);
            this.panelDetailProdInfo.TabIndex = 106;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.labelInvDetail);
            this.panel3.Controls.Add(this.comboBoxInvShelfLoc);
            this.panel3.Controls.Add(this.comboBoxInvLocation);
            this.panel3.Controls.Add(this.textBoxInvMinQTY);
            this.panel3.Controls.Add(this.textBoxInvMaxQTY);
            this.panel3.Controls.Add(this.labelInvMaxQTY);
            this.panel3.Controls.Add(this.labelInventoryID);
            this.panel3.Controls.Add(this.textBoxInvProdID);
            this.panel3.Controls.Add(this.textBoxInvID);
            this.panel3.Controls.Add(this.labelInvLocation);
            this.panel3.Controls.Add(this.labelInvQOH);
            this.panel3.Controls.Add(this.labelInvProdID);
            this.panel3.Controls.Add(this.labelInvTransientQTY);
            this.panel3.Controls.Add(this.textBoxInvQOH);
            this.panel3.Controls.Add(this.textBoxInvTransientQTY);
            this.panel3.Controls.Add(this.labelInvShelfLoc);
            this.panel3.Controls.Add(this.labelInvMinQTY);
            this.panel3.Location = new System.Drawing.Point(28, 218);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(260, 323);
            this.panel3.TabIndex = 107;
            // 
            // labelInvDetail
            // 
            this.labelInvDetail.AutoSize = true;
            this.labelInvDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvDetail.Location = new System.Drawing.Point(22, 14);
            this.labelInvDetail.Name = "labelInvDetail";
            this.labelInvDetail.Size = new System.Drawing.Size(164, 13);
            this.labelInvDetail.TabIndex = 104;
            this.labelInvDetail.Text = "Detail Inventory Information";
            // 
            // comboBoxInvShelfLoc
            // 
            this.comboBoxInvShelfLoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxInvShelfLoc.Location = new System.Drawing.Point(143, 133);
            this.comboBoxInvShelfLoc.Name = "comboBoxInvShelfLoc";
            this.comboBoxInvShelfLoc.Size = new System.Drawing.Size(100, 21);
            this.comboBoxInvShelfLoc.TabIndex = 125;
            // 
            // comboBoxInvLocation
            // 
            this.comboBoxInvLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInvLocation.Location = new System.Drawing.Point(143, 100);
            this.comboBoxInvLocation.Name = "comboBoxInvLocation";
            this.comboBoxInvLocation.Size = new System.Drawing.Size(100, 21);
            this.comboBoxInvLocation.TabIndex = 116;
            this.comboBoxInvLocation.SelectedIndexChanged += new System.EventHandler(this.comboBoxInvLocation_SelectedIndexChanged);
            // 
            // textBoxInvMinQTY
            // 
            this.textBoxInvMinQTY.Location = new System.Drawing.Point(143, 223);
            this.textBoxInvMinQTY.Name = "textBoxInvMinQTY";
            this.textBoxInvMinQTY.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvMinQTY.TabIndex = 122;
            // 
            // textBoxInvMaxQTY
            // 
            this.textBoxInvMaxQTY.Location = new System.Drawing.Point(143, 254);
            this.textBoxInvMaxQTY.Name = "textBoxInvMaxQTY";
            this.textBoxInvMaxQTY.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvMaxQTY.TabIndex = 123;
            // 
            // labelInvMaxQTY
            // 
            this.labelInvMaxQTY.AutoSize = true;
            this.labelInvMaxQTY.Location = new System.Drawing.Point(24, 258);
            this.labelInvMaxQTY.Name = "labelInvMaxQTY";
            this.labelInvMaxQTY.Size = new System.Drawing.Size(76, 13);
            this.labelInvMaxQTY.TabIndex = 124;
            this.labelInvMaxQTY.Text = "Maximum QTY";
            // 
            // labelInventoryID
            // 
            this.labelInventoryID.AutoSize = true;
            this.labelInventoryID.Location = new System.Drawing.Point(24, 41);
            this.labelInventoryID.Name = "labelInventoryID";
            this.labelInventoryID.Size = new System.Drawing.Size(65, 13);
            this.labelInventoryID.TabIndex = 119;
            this.labelInventoryID.Text = "Inventory ID";
            // 
            // textBoxInvProdID
            // 
            this.textBoxInvProdID.Location = new System.Drawing.Point(143, 68);
            this.textBoxInvProdID.Name = "textBoxInvProdID";
            this.textBoxInvProdID.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvProdID.TabIndex = 107;
            // 
            // textBoxInvID
            // 
            this.textBoxInvID.Location = new System.Drawing.Point(143, 37);
            this.textBoxInvID.Name = "textBoxInvID";
            this.textBoxInvID.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvID.TabIndex = 120;
            // 
            // labelInvLocation
            // 
            this.labelInvLocation.AutoSize = true;
            this.labelInvLocation.Location = new System.Drawing.Point(24, 103);
            this.labelInvLocation.Name = "labelInvLocation";
            this.labelInvLocation.Size = new System.Drawing.Size(48, 13);
            this.labelInvLocation.TabIndex = 108;
            this.labelInvLocation.Text = "Location";
            // 
            // labelInvQOH
            // 
            this.labelInvQOH.AutoSize = true;
            this.labelInvQOH.Location = new System.Drawing.Point(24, 165);
            this.labelInvQOH.Name = "labelInvQOH";
            this.labelInvQOH.Size = new System.Drawing.Size(31, 13);
            this.labelInvQOH.TabIndex = 110;
            this.labelInvQOH.Text = "QOH";
            // 
            // labelInvProdID
            // 
            this.labelInvProdID.AutoSize = true;
            this.labelInvProdID.Location = new System.Drawing.Point(24, 72);
            this.labelInvProdID.Name = "labelInvProdID";
            this.labelInvProdID.Size = new System.Drawing.Size(58, 13);
            this.labelInvProdID.TabIndex = 106;
            this.labelInvProdID.Text = "Product ID";
            // 
            // labelInvTransientQTY
            // 
            this.labelInvTransientQTY.AutoSize = true;
            this.labelInvTransientQTY.Location = new System.Drawing.Point(24, 196);
            this.labelInvTransientQTY.Name = "labelInvTransientQTY";
            this.labelInvTransientQTY.Size = new System.Drawing.Size(76, 13);
            this.labelInvTransientQTY.TabIndex = 112;
            this.labelInvTransientQTY.Text = "Transient QTY";
            // 
            // textBoxInvQOH
            // 
            this.textBoxInvQOH.Location = new System.Drawing.Point(143, 161);
            this.textBoxInvQOH.Name = "textBoxInvQOH";
            this.textBoxInvQOH.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvQOH.TabIndex = 113;
            // 
            // textBoxInvTransientQTY
            // 
            this.textBoxInvTransientQTY.Location = new System.Drawing.Point(143, 192);
            this.textBoxInvTransientQTY.Name = "textBoxInvTransientQTY";
            this.textBoxInvTransientQTY.Size = new System.Drawing.Size(100, 20);
            this.textBoxInvTransientQTY.TabIndex = 114;
            // 
            // labelInvShelfLoc
            // 
            this.labelInvShelfLoc.AutoSize = true;
            this.labelInvShelfLoc.Location = new System.Drawing.Point(24, 134);
            this.labelInvShelfLoc.Name = "labelInvShelfLoc";
            this.labelInvShelfLoc.Size = new System.Drawing.Size(75, 13);
            this.labelInvShelfLoc.TabIndex = 117;
            this.labelInvShelfLoc.Text = "Shelf Location";
            // 
            // labelInvMinQTY
            // 
            this.labelInvMinQTY.AutoSize = true;
            this.labelInvMinQTY.Location = new System.Drawing.Point(24, 227);
            this.labelInvMinQTY.Name = "labelInvMinQTY";
            this.labelInvMinQTY.Size = new System.Drawing.Size(73, 13);
            this.labelInvMinQTY.TabIndex = 118;
            this.labelInvMinQTY.Text = "Minimum QTY";
            // 
            // labelInvHint
            // 
            this.labelInvHint.AutoSize = true;
            this.labelInvHint.Location = new System.Drawing.Point(174, 12);
            this.labelInvHint.Name = "labelInvHint";
            this.labelInvHint.Size = new System.Drawing.Size(435, 13);
            this.labelInvHint.TabIndex = 110;
            this.labelInvHint.Text = "**Tip: Click a line below if you want to see detail Inventory Inforamtion or Mana" +
    "ge Inventory";
            // 
            // panelInvResult
            // 
            this.panelInvResult.BackColor = System.Drawing.Color.AliceBlue;
            this.panelInvResult.Controls.Add(this.labelInvSearchResult);
            this.panelInvResult.Controls.Add(this.labelInvResult);
            this.panelInvResult.ForeColor = System.Drawing.Color.MediumBlue;
            this.panelInvResult.Location = new System.Drawing.Point(808, 4);
            this.panelInvResult.Name = "panelInvResult";
            this.panelInvResult.Size = new System.Drawing.Size(168, 28);
            this.panelInvResult.TabIndex = 111;
            // 
            // labelInvSearchResult
            // 
            this.labelInvSearchResult.AutoSize = true;
            this.labelInvSearchResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvSearchResult.ForeColor = System.Drawing.Color.Blue;
            this.labelInvSearchResult.Location = new System.Drawing.Point(29, 4);
            this.labelInvSearchResult.Name = "labelInvSearchResult";
            this.labelInvSearchResult.Size = new System.Drawing.Size(0, 20);
            this.labelInvSearchResult.TabIndex = 22;
            // 
            // labelInvResult
            // 
            this.labelInvResult.AutoSize = true;
            this.labelInvResult.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelInvResult.Location = new System.Drawing.Point(83, 7);
            this.labelInvResult.Name = "labelInvResult";
            this.labelInvResult.Size = new System.Drawing.Size(72, 13);
            this.labelInvResult.TabIndex = 21;
            this.labelInvResult.Text = "Results found";
            // 
            // buttonInvInsertTry
            // 
            this.buttonInvInsertTry.Location = new System.Drawing.Point(32, 122);
            this.buttonInvInsertTry.Name = "buttonInvInsertTry";
            this.buttonInvInsertTry.Size = new System.Drawing.Size(75, 34);
            this.buttonInvInsertTry.TabIndex = 114;
            this.buttonInvInsertTry.Text = "Add Inventory";
            this.buttonInvInsertTry.UseVisualStyleBackColor = true;
            this.buttonInvInsertTry.Click += new System.EventHandler(this.buttonProdInsertTry_Click);
            // 
            // buttonInvEdit
            // 
            this.buttonInvEdit.Location = new System.Drawing.Point(32, 66);
            this.buttonInvEdit.Name = "buttonInvEdit";
            this.buttonInvEdit.Size = new System.Drawing.Size(75, 34);
            this.buttonInvEdit.TabIndex = 113;
            this.buttonInvEdit.Text = "Edit Inventory";
            this.buttonInvEdit.UseVisualStyleBackColor = true;
            this.buttonInvEdit.Click += new System.EventHandler(this.buttonInvEdit_Click);
            // 
            // buttonInvClear
            // 
            this.buttonInvClear.Location = new System.Drawing.Point(32, 12);
            this.buttonInvClear.Name = "buttonInvClear";
            this.buttonInvClear.Size = new System.Drawing.Size(75, 34);
            this.buttonInvClear.TabIndex = 112;
            this.buttonInvClear.Text = "Clear";
            this.buttonInvClear.UseVisualStyleBackColor = true;
            this.buttonInvClear.Click += new System.EventHandler(this.buttonProdClear_Click);
            // 
            // buttonInvDelete
            // 
            this.buttonInvDelete.BackColor = System.Drawing.Color.Red;
            this.buttonInvDelete.Location = new System.Drawing.Point(32, 251);
            this.buttonInvDelete.Name = "buttonInvDelete";
            this.buttonInvDelete.Size = new System.Drawing.Size(75, 34);
            this.buttonInvDelete.TabIndex = 115;
            this.buttonInvDelete.Text = "Delete";
            this.buttonInvDelete.UseVisualStyleBackColor = false;
            this.buttonInvDelete.Click += new System.EventHandler(this.buttonInvDelete_Click);
            // 
            // buttonInvAdjust
            // 
            this.buttonInvAdjust.BackColor = System.Drawing.SystemColors.Control;
            this.buttonInvAdjust.Location = new System.Drawing.Point(32, 178);
            this.buttonInvAdjust.Name = "buttonInvAdjust";
            this.buttonInvAdjust.Size = new System.Drawing.Size(75, 34);
            this.buttonInvAdjust.TabIndex = 116;
            this.buttonInvAdjust.Text = "Adjust Inventory";
            this.buttonInvAdjust.UseVisualStyleBackColor = false;
            // 
            // panelInvNormal
            // 
            this.panelInvNormal.Controls.Add(this.labelInvHint);
            this.panelInvNormal.Controls.Add(this.labelInvView);
            this.panelInvNormal.Controls.Add(this.panelInvResult);
            this.panelInvNormal.Controls.Add(this.dataGridViewInventory);
            this.panelInvNormal.Location = new System.Drawing.Point(12, 62);
            this.panelInvNormal.Name = "panelInvNormal";
            this.panelInvNormal.Size = new System.Drawing.Size(984, 157);
            this.panelInvNormal.TabIndex = 118;
            // 
            // labelInvView
            // 
            this.labelInvView.AutoSize = true;
            this.labelInvView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvView.Location = new System.Drawing.Point(13, 11);
            this.labelInvView.Name = "labelInvView";
            this.labelInvView.Size = new System.Drawing.Size(146, 17);
            this.labelInvView.TabIndex = 118;
            this.labelInvView.Text = "■ Inventory List(s)";
            // 
            // buttonSaveNewInvWithExist
            // 
            this.buttonSaveNewInvWithExist.Location = new System.Drawing.Point(17, 122);
            this.buttonSaveNewInvWithExist.Name = "buttonSaveNewInvWithExist";
            this.buttonSaveNewInvWithExist.Size = new System.Drawing.Size(75, 49);
            this.buttonSaveNewInvWithExist.TabIndex = 120;
            this.buttonSaveNewInvWithExist.Text = "Save New Inventory";
            this.buttonSaveNewInvWithExist.UseVisualStyleBackColor = true;
            this.buttonSaveNewInvWithExist.Click += new System.EventHandler(this.buttonAddNewInvWithExist_Click);
            // 
            // panelInvButtons
            // 
            this.panelInvButtons.Controls.Add(this.buttonInvUpdate);
            this.panelInvButtons.Controls.Add(this.buttonInvDelete);
            this.panelInvButtons.Controls.Add(this.buttonSaveNewInvWithExist);
            this.panelInvButtons.Controls.Add(this.buttonInvAdjust);
            this.panelInvButtons.Controls.Add(this.buttonInvInsertTry);
            this.panelInvButtons.Controls.Add(this.buttonInvEdit);
            this.panelInvButtons.Controls.Add(this.buttonInvClear);
            this.panelInvButtons.Location = new System.Drawing.Point(309, 227);
            this.panelInvButtons.Name = "panelInvButtons";
            this.panelInvButtons.Size = new System.Drawing.Size(133, 314);
            this.panelInvButtons.TabIndex = 121;
            // 
            // buttonInvUpdate
            // 
            this.buttonInvUpdate.Location = new System.Drawing.Point(15, 67);
            this.buttonInvUpdate.Name = "buttonInvUpdate";
            this.buttonInvUpdate.Size = new System.Drawing.Size(75, 34);
            this.buttonInvUpdate.TabIndex = 121;
            this.buttonInvUpdate.Text = "Update Inventory";
            this.buttonInvUpdate.UseVisualStyleBackColor = true;
            this.buttonInvUpdate.Click += new System.EventHandler(this.buttonInvUpdate_Click);
            // 
            // FormInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1018, 735);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelDetailProdInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelInvNormal);
            this.Controls.Add(this.panelInvButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInventory";
            this.Text = "Inventory Management";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormInventory_FormClosed);
            this.Load += new System.EventHandler(this.FormInventory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            this.panelDetailProdInfo.ResumeLayout(false);
            this.panelDetailProdInfo.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelInvResult.ResumeLayout(false);
            this.panelInvResult.PerformLayout();
            this.panelInvNormal.ResumeLayout(false);
            this.panelInvNormal.PerformLayout();
            this.panelInvButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonInvSearch;
        private System.Windows.Forms.TextBox textBoxInvSearchKeyword;
        private System.Windows.Forms.ComboBox comboBoxInvSearch;
        private System.Windows.Forms.Label labelProdSearchBy;
        private System.Windows.Forms.DataGridView dataGridViewInventory;
        private System.Windows.Forms.ComboBox comboBoxInvCaseCount;
        private System.Windows.Forms.ComboBox comboBoxInvSup;
        private System.Windows.Forms.ComboBox comboBoxInvProdCatID;
        private System.Windows.Forms.Label labelProdCaseSize;
        private System.Windows.Forms.TextBox textBoxInvProdCaseSize;
        private System.Windows.Forms.Label labelProdCaseWeight;
        private System.Windows.Forms.Label labelProdPriceRetail;
        private System.Windows.Forms.Label labelProdSupID;
        private System.Windows.Forms.Label labelProdCaseCount;
        private System.Windows.Forms.Label labelProdCatID;
        private System.Windows.Forms.Label labelProdPricePrev;
        private System.Windows.Forms.Label labelProdSize;
        private System.Windows.Forms.Label labelProdPricePurch;
        private System.Windows.Forms.Label labelProdWeight;
        private System.Windows.Forms.Label labelProdType;
        private System.Windows.Forms.Label labelProdDesc;
        private System.Windows.Forms.Label labelProdSUPSKU;
        private System.Windows.Forms.TextBox textBoxInvProdCaseWeight;
        private System.Windows.Forms.TextBox textBoxInvProdPricePrev;
        private System.Windows.Forms.TextBox textBoxInvProdPriceRetail;
        private System.Windows.Forms.TextBox textBoxInvProdPricePurch;
        private System.Windows.Forms.TextBox textBoxInvProdWeight;
        private System.Windows.Forms.TextBox textBoxInvProdSize;
        private System.Windows.Forms.TextBox textBoxInvProdType;
        private System.Windows.Forms.TextBox textBoxInvProdDesc;
        private System.Windows.Forms.TextBox textBoxInvProdColor;
        private System.Windows.Forms.TextBox textBoxInvProdName;
        private System.Windows.Forms.Label labelProdColor;
        private System.Windows.Forms.Label labelProdDetail;
        private System.Windows.Forms.TextBox textBoxInvProdSUPSKU;
        private System.Windows.Forms.Label labelProdName;
        private System.Windows.Forms.TextBox textBoxInvProdBESKU;
        private System.Windows.Forms.Label labelProdBESKU;
        private System.Windows.Forms.Panel panelDetailProdInfo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxInvMinQTY;
        private System.Windows.Forms.TextBox textBoxInvMaxQTY;
        private System.Windows.Forms.Label labelInvMaxQTY;
        private System.Windows.Forms.Label labelInventoryID;
        private System.Windows.Forms.TextBox textBoxInvProdID;
        private System.Windows.Forms.TextBox textBoxInvID;
        private System.Windows.Forms.Label labelInvLocation;
        private System.Windows.Forms.Label labelInvQOH;
        private System.Windows.Forms.Label labelInvProdID;
        private System.Windows.Forms.Label labelInvTransientQTY;
        private System.Windows.Forms.TextBox textBoxInvQOH;
        private System.Windows.Forms.TextBox textBoxInvTransientQTY;
        private System.Windows.Forms.Label labelInvShelfLoc;
        private System.Windows.Forms.Label labelInvMinQTY;
        private System.Windows.Forms.Label labelInvHint;
        private System.Windows.Forms.Panel panelInvResult;
        private System.Windows.Forms.Label labelInvSearchResult;
        private System.Windows.Forms.Label labelInvResult;
        private System.Windows.Forms.Button buttonInvInsertTry;
        private System.Windows.Forms.Button buttonInvEdit;
        private System.Windows.Forms.Button buttonInvClear;
        private System.Windows.Forms.Button buttonInvDelete;
        private System.Windows.Forms.ComboBox comboBoxInvLocation;
        private System.Windows.Forms.ComboBox comboBoxInvShelfLoc;
        private System.Windows.Forms.Label labelInvDetail;
        private System.Windows.Forms.Button buttonInvAdjust;
        private System.Windows.Forms.Panel panelInvNormal;
        private System.Windows.Forms.Label labelInvView;
        private System.Windows.Forms.Button buttonSaveNewInvWithExist;
        private System.Windows.Forms.Panel panelInvButtons;
        private System.Windows.Forms.Button buttonInvUpdate;
    }
}

