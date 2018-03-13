namespace BEProducts
{
    partial class formProductMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProductMain));
            this.panelSearch = new System.Windows.Forms.Panel();
            this.comboBoxProdSearchList = new System.Windows.Forms.ComboBox();
            this.buttonProdSearch = new System.Windows.Forms.Button();
            this.textProdKeyword = new System.Windows.Forms.TextBox();
            this.comboProd = new System.Windows.Forms.ComboBox();
            this.labelProdSearchBy = new System.Windows.Forms.Label();
            this.buttonProdInsert = new System.Windows.Forms.Button();
            this.buttonProdUpdate = new System.Windows.Forms.Button();
            this.buttonProdClear = new System.Windows.Forms.Button();
            this.textBoxProdName = new System.Windows.Forms.TextBox();
            this.labelProdColor = new System.Windows.Forms.Label();
            this.labelProdID = new System.Windows.Forms.Label();
            this.buttonProdDelete = new System.Windows.Forms.Button();
            this.labelCatHint = new System.Windows.Forms.Label();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.textBoxProdSUPSKU = new System.Windows.Forms.TextBox();
            this.labelProdName = new System.Windows.Forms.Label();
            this.textBoxProdBESKU = new System.Windows.Forms.TextBox();
            this.labelProdBESKU = new System.Windows.Forms.Label();
            this.textBoxProdID = new System.Windows.Forms.TextBox();
            this.panelProdResult = new System.Windows.Forms.Panel();
            this.labelProdSearchResult = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.textBoxProdSize = new System.Windows.Forms.TextBox();
            this.textBoxProdDesc = new System.Windows.Forms.TextBox();
            this.textBoxProdColor = new System.Windows.Forms.TextBox();
            this.textBoxProdPriceRetail = new System.Windows.Forms.TextBox();
            this.textBoxProdPricePurch = new System.Windows.Forms.TextBox();
            this.textBoxProdWeight = new System.Windows.Forms.TextBox();
            this.textBoxProdCaseWeight = new System.Windows.Forms.TextBox();
            this.textBoxProdPricePrev = new System.Windows.Forms.TextBox();
            this.labelProdSUPSKU = new System.Windows.Forms.Label();
            this.labelProdDesc = new System.Windows.Forms.Label();
            this.labelProdType = new System.Windows.Forms.Label();
            this.labelProdSupID = new System.Windows.Forms.Label();
            this.labelProdCaseCount = new System.Windows.Forms.Label();
            this.labelProdCatID = new System.Windows.Forms.Label();
            this.labelProdPricePrev = new System.Windows.Forms.Label();
            this.labelProdSize = new System.Windows.Forms.Label();
            this.labelProdPricePurch = new System.Windows.Forms.Label();
            this.labelProdWeight = new System.Windows.Forms.Label();
            this.labelProdPriceRetail = new System.Windows.Forms.Label();
            this.labelProdCaseWeight = new System.Windows.Forms.Label();
            this.labelProdCaseSize = new System.Windows.Forms.Label();
            this.textBoxProdCaseSize = new System.Windows.Forms.TextBox();
            this.comboBoxProdCatID = new System.Windows.Forms.ComboBox();
            this.comboBoxSup = new System.Windows.Forms.ComboBox();
            this.comboBoxCaseCount = new System.Windows.Forms.ComboBox();
            this.comboBoxProdType = new System.Windows.Forms.ComboBox();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            this.panelProdResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelSearch.Controls.Add(this.comboBoxProdSearchList);
            this.panelSearch.Controls.Add(this.buttonProdSearch);
            this.panelSearch.Controls.Add(this.textProdKeyword);
            this.panelSearch.Controls.Add(this.comboProd);
            this.panelSearch.Controls.Add(this.labelProdSearchBy);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1015, 56);
            this.panelSearch.TabIndex = 1;
            // 
            // comboBoxProdSearchList
            // 
            this.comboBoxProdSearchList.FormattingEnabled = true;
            this.comboBoxProdSearchList.Items.AddRange(new object[] {
            "Product ID",
            "Product Name",
            "Category ID",
            "Supplier ID",
            "Any Values"});
            this.comboBoxProdSearchList.Location = new System.Drawing.Point(248, 18);
            this.comboBoxProdSearchList.Name = "comboBoxProdSearchList";
            this.comboBoxProdSearchList.Size = new System.Drawing.Size(134, 21);
            this.comboBoxProdSearchList.TabIndex = 4;
            // 
            // buttonProdSearch
            // 
            this.buttonProdSearch.Location = new System.Drawing.Point(408, 10);
            this.buttonProdSearch.Name = "buttonProdSearch";
            this.buttonProdSearch.Size = new System.Drawing.Size(75, 37);
            this.buttonProdSearch.TabIndex = 3;
            this.buttonProdSearch.Text = "Search";
            this.buttonProdSearch.UseVisualStyleBackColor = true;
            this.buttonProdSearch.Click += new System.EventHandler(this.buttonProdSearch_Click);
            // 
            // textProdKeyword
            // 
            this.textProdKeyword.Location = new System.Drawing.Point(248, 18);
            this.textProdKeyword.Name = "textProdKeyword";
            this.textProdKeyword.Size = new System.Drawing.Size(134, 20);
            this.textProdKeyword.TabIndex = 2;
            this.textProdKeyword.TextChanged += new System.EventHandler(this.textProdKeyword_TextChanged);
            // 
            // comboProd
            // 
            this.comboProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProd.FormattingEnabled = true;
            this.comboProd.Items.AddRange(new object[] {
            "Product ID",
            "Product Name",
            "Category ID",
            "Supplier ID",
            "Any Values"});
            this.comboProd.Location = new System.Drawing.Point(109, 18);
            this.comboProd.Name = "comboProd";
            this.comboProd.Size = new System.Drawing.Size(121, 21);
            this.comboProd.TabIndex = 1;
            this.comboProd.SelectedIndexChanged += new System.EventHandler(this.comboProd_SelectedIndexChanged);
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
            // buttonProdInsert
            // 
            this.buttonProdInsert.Location = new System.Drawing.Point(351, 598);
            this.buttonProdInsert.Name = "buttonProdInsert";
            this.buttonProdInsert.Size = new System.Drawing.Size(75, 34);
            this.buttonProdInsert.TabIndex = 39;
            this.buttonProdInsert.Text = "Insert New";
            this.buttonProdInsert.UseVisualStyleBackColor = true;
            this.buttonProdInsert.Click += new System.EventHandler(this.buttonProdInsert_Click);
            // 
            // buttonProdUpdate
            // 
            this.buttonProdUpdate.Location = new System.Drawing.Point(252, 598);
            this.buttonProdUpdate.Name = "buttonProdUpdate";
            this.buttonProdUpdate.Size = new System.Drawing.Size(75, 34);
            this.buttonProdUpdate.TabIndex = 38;
            this.buttonProdUpdate.Text = "Update";
            this.buttonProdUpdate.UseVisualStyleBackColor = true;
            this.buttonProdUpdate.Click += new System.EventHandler(this.buttonProdUpdate_Click);
            // 
            // buttonProdClear
            // 
            this.buttonProdClear.Location = new System.Drawing.Point(135, 598);
            this.buttonProdClear.Name = "buttonProdClear";
            this.buttonProdClear.Size = new System.Drawing.Size(75, 34);
            this.buttonProdClear.TabIndex = 37;
            this.buttonProdClear.Text = "Clear";
            this.buttonProdClear.UseVisualStyleBackColor = true;
            this.buttonProdClear.Click += new System.EventHandler(this.buttonProdClear_Click);
            // 
            // textBoxProdName
            // 
            this.textBoxProdName.Location = new System.Drawing.Point(144, 152);
            this.textBoxProdName.Multiline = true;
            this.textBoxProdName.Name = "textBoxProdName";
            this.textBoxProdName.Size = new System.Drawing.Size(100, 52);
            this.textBoxProdName.TabIndex = 32;
            this.textBoxProdName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxProdName_KeyPress);
            // 
            // labelProdColor
            // 
            this.labelProdColor.AutoSize = true;
            this.labelProdColor.Location = new System.Drawing.Point(25, 214);
            this.labelProdColor.Name = "labelProdColor";
            this.labelProdColor.Size = new System.Drawing.Size(71, 13);
            this.labelProdColor.TabIndex = 31;
            this.labelProdColor.Text = "Product Color";
            // 
            // labelProdID
            // 
            this.labelProdID.AutoSize = true;
            this.labelProdID.Location = new System.Drawing.Point(25, 75);
            this.labelProdID.Name = "labelProdID";
            this.labelProdID.Size = new System.Drawing.Size(58, 13);
            this.labelProdID.TabIndex = 24;
            this.labelProdID.Text = "Product ID";
            // 
            // buttonProdDelete
            // 
            this.buttonProdDelete.BackColor = System.Drawing.Color.Red;
            this.buttonProdDelete.Location = new System.Drawing.Point(476, 598);
            this.buttonProdDelete.Name = "buttonProdDelete";
            this.buttonProdDelete.Size = new System.Drawing.Size(75, 34);
            this.buttonProdDelete.TabIndex = 40;
            this.buttonProdDelete.Text = "Delete";
            this.buttonProdDelete.UseVisualStyleBackColor = false;
            this.buttonProdDelete.Click += new System.EventHandler(this.buttonProdDelete_Click);
            // 
            // labelCatHint
            // 
            this.labelCatHint.AutoSize = true;
            this.labelCatHint.Location = new System.Drawing.Point(275, 74);
            this.labelCatHint.Name = "labelCatHint";
            this.labelCatHint.Size = new System.Drawing.Size(335, 13);
            this.labelCatHint.TabIndex = 36;
            this.labelCatHint.Text = "**Tip: Click a line below if you want to see detail information in the left.";
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(275, 98);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.ReadOnly = true;
            this.dataGridViewProduct.Size = new System.Drawing.Size(725, 455);
            this.dataGridViewProduct.TabIndex = 35;
            this.dataGridViewProduct.Click += new System.EventHandler(this.dataGridViewProduct_Click);
            // 
            // textBoxProdSUPSKU
            // 
            this.textBoxProdSUPSKU.Location = new System.Drawing.Point(144, 125);
            this.textBoxProdSUPSKU.Name = "textBoxProdSUPSKU";
            this.textBoxProdSUPSKU.Size = new System.Drawing.Size(100, 20);
            this.textBoxProdSUPSKU.TabIndex = 29;
            this.textBoxProdSUPSKU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxProdSUPSKU_KeyPress);
            // 
            // labelProdName
            // 
            this.labelProdName.AutoSize = true;
            this.labelProdName.Location = new System.Drawing.Point(25, 156);
            this.labelProdName.Name = "labelProdName";
            this.labelProdName.Size = new System.Drawing.Size(75, 13);
            this.labelProdName.TabIndex = 28;
            this.labelProdName.Text = "Product Name";
            // 
            // textBoxProdBESKU
            // 
            this.textBoxProdBESKU.Location = new System.Drawing.Point(144, 98);
            this.textBoxProdBESKU.Name = "textBoxProdBESKU";
            this.textBoxProdBESKU.Size = new System.Drawing.Size(100, 20);
            this.textBoxProdBESKU.TabIndex = 27;
            this.textBoxProdBESKU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxProdBESKU_KeyPress);
            // 
            // labelProdBESKU
            // 
            this.labelProdBESKU.AutoSize = true;
            this.labelProdBESKU.Location = new System.Drawing.Point(25, 102);
            this.labelProdBESKU.Name = "labelProdBESKU";
            this.labelProdBESKU.Size = new System.Drawing.Size(46, 13);
            this.labelProdBESKU.TabIndex = 26;
            this.labelProdBESKU.Text = "BE SKU";
            // 
            // textBoxProdID
            // 
            this.textBoxProdID.Location = new System.Drawing.Point(144, 71);
            this.textBoxProdID.Name = "textBoxProdID";
            this.textBoxProdID.Size = new System.Drawing.Size(100, 20);
            this.textBoxProdID.TabIndex = 25;
            this.textBoxProdID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxProdID_KeyPress);
            // 
            // panelProdResult
            // 
            this.panelProdResult.BackColor = System.Drawing.Color.AliceBlue;
            this.panelProdResult.Controls.Add(this.labelProdSearchResult);
            this.panelProdResult.Controls.Add(this.labelResult);
            this.panelProdResult.ForeColor = System.Drawing.Color.MediumBlue;
            this.panelProdResult.Location = new System.Drawing.Point(652, 63);
            this.panelProdResult.Name = "panelProdResult";
            this.panelProdResult.Size = new System.Drawing.Size(168, 28);
            this.panelProdResult.TabIndex = 41;
            // 
            // labelProdSearchResult
            // 
            this.labelProdSearchResult.AutoSize = true;
            this.labelProdSearchResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProdSearchResult.ForeColor = System.Drawing.Color.Blue;
            this.labelProdSearchResult.Location = new System.Drawing.Point(39, 4);
            this.labelProdSearchResult.Name = "labelProdSearchResult";
            this.labelProdSearchResult.Size = new System.Drawing.Size(0, 20);
            this.labelProdSearchResult.TabIndex = 22;
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
            // textBoxProdSize
            // 
            this.textBoxProdSize.Location = new System.Drawing.Point(144, 320);
            this.textBoxProdSize.Name = "textBoxProdSize";
            this.textBoxProdSize.Size = new System.Drawing.Size(100, 20);
            this.textBoxProdSize.TabIndex = 45;
            this.textBoxProdSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxProdSize_KeyPress);
            // 
            // textBoxProdDesc
            // 
            this.textBoxProdDesc.Location = new System.Drawing.Point(144, 237);
            this.textBoxProdDesc.Multiline = true;
            this.textBoxProdDesc.Name = "textBoxProdDesc";
            this.textBoxProdDesc.Size = new System.Drawing.Size(100, 50);
            this.textBoxProdDesc.TabIndex = 43;
            this.textBoxProdDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxProdDesc_KeyPress);
            // 
            // textBoxProdColor
            // 
            this.textBoxProdColor.Location = new System.Drawing.Point(144, 210);
            this.textBoxProdColor.Name = "textBoxProdColor";
            this.textBoxProdColor.Size = new System.Drawing.Size(100, 20);
            this.textBoxProdColor.TabIndex = 42;
            this.textBoxProdColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxProdColor_KeyPress);
            // 
            // textBoxProdPriceRetail
            // 
            this.textBoxProdPriceRetail.Location = new System.Drawing.Point(144, 428);
            this.textBoxProdPriceRetail.Name = "textBoxProdPriceRetail";
            this.textBoxProdPriceRetail.Size = new System.Drawing.Size(100, 20);
            this.textBoxProdPriceRetail.TabIndex = 49;
            this.textBoxProdPriceRetail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxProdPriceRetail_KeyPress);
            // 
            // textBoxProdPricePurch
            // 
            this.textBoxProdPricePurch.Location = new System.Drawing.Point(144, 401);
            this.textBoxProdPricePurch.Name = "textBoxProdPricePurch";
            this.textBoxProdPricePurch.Size = new System.Drawing.Size(100, 20);
            this.textBoxProdPricePurch.TabIndex = 48;
            this.textBoxProdPricePurch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxProdPricePurch_KeyPress);
            // 
            // textBoxProdWeight
            // 
            this.textBoxProdWeight.Location = new System.Drawing.Point(144, 347);
            this.textBoxProdWeight.Name = "textBoxProdWeight";
            this.textBoxProdWeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxProdWeight.TabIndex = 46;
            this.textBoxProdWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxProdWeight_KeyPress);
            // 
            // textBoxProdCaseWeight
            // 
            this.textBoxProdCaseWeight.Location = new System.Drawing.Point(144, 536);
            this.textBoxProdCaseWeight.Name = "textBoxProdCaseWeight";
            this.textBoxProdCaseWeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxProdCaseWeight.TabIndex = 52;
            this.textBoxProdCaseWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxProdCaseWeight_KeyPress);
            // 
            // textBoxProdPricePrev
            // 
            this.textBoxProdPricePrev.Location = new System.Drawing.Point(144, 455);
            this.textBoxProdPricePrev.Name = "textBoxProdPricePrev";
            this.textBoxProdPricePrev.Size = new System.Drawing.Size(100, 20);
            this.textBoxProdPricePrev.TabIndex = 50;
            this.textBoxProdPricePrev.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxProdPricePrev_KeyPress);
            // 
            // labelProdSUPSKU
            // 
            this.labelProdSUPSKU.AutoSize = true;
            this.labelProdSUPSKU.Location = new System.Drawing.Point(25, 129);
            this.labelProdSUPSKU.Name = "labelProdSUPSKU";
            this.labelProdSUPSKU.Size = new System.Drawing.Size(70, 13);
            this.labelProdSUPSKU.TabIndex = 54;
            this.labelProdSUPSKU.Text = "Supplier SKU";
            // 
            // labelProdDesc
            // 
            this.labelProdDesc.AutoSize = true;
            this.labelProdDesc.Location = new System.Drawing.Point(25, 241);
            this.labelProdDesc.Name = "labelProdDesc";
            this.labelProdDesc.Size = new System.Drawing.Size(75, 13);
            this.labelProdDesc.TabIndex = 55;
            this.labelProdDesc.Text = "Product Desc.";
            // 
            // labelProdType
            // 
            this.labelProdType.AutoSize = true;
            this.labelProdType.Location = new System.Drawing.Point(25, 297);
            this.labelProdType.Name = "labelProdType";
            this.labelProdType.Size = new System.Drawing.Size(71, 13);
            this.labelProdType.TabIndex = 56;
            this.labelProdType.Text = "Product Type";
            // 
            // labelProdSupID
            // 
            this.labelProdSupID.AutoSize = true;
            this.labelProdSupID.Location = new System.Drawing.Point(25, 567);
            this.labelProdSupID.Name = "labelProdSupID";
            this.labelProdSupID.Size = new System.Drawing.Size(59, 13);
            this.labelProdSupID.TabIndex = 63;
            this.labelProdSupID.Text = "Supplier ID";
            // 
            // labelProdCaseCount
            // 
            this.labelProdCaseCount.AutoSize = true;
            this.labelProdCaseCount.Location = new System.Drawing.Point(25, 486);
            this.labelProdCaseCount.Name = "labelProdCaseCount";
            this.labelProdCaseCount.Size = new System.Drawing.Size(62, 13);
            this.labelProdCaseCount.TabIndex = 62;
            this.labelProdCaseCount.Text = "Case Count";
            // 
            // labelProdCatID
            // 
            this.labelProdCatID.AutoSize = true;
            this.labelProdCatID.Location = new System.Drawing.Point(25, 377);
            this.labelProdCatID.Name = "labelProdCatID";
            this.labelProdCatID.Size = new System.Drawing.Size(63, 13);
            this.labelProdCatID.TabIndex = 61;
            this.labelProdCatID.Text = "Category ID";
            // 
            // labelProdPricePrev
            // 
            this.labelProdPricePrev.AutoSize = true;
            this.labelProdPricePrev.Location = new System.Drawing.Point(25, 459);
            this.labelProdPricePrev.Name = "labelProdPricePrev";
            this.labelProdPricePrev.Size = new System.Drawing.Size(75, 13);
            this.labelProdPricePrev.TabIndex = 60;
            this.labelProdPricePrev.Text = "Previous Price";
            // 
            // labelProdSize
            // 
            this.labelProdSize.AutoSize = true;
            this.labelProdSize.Location = new System.Drawing.Point(25, 323);
            this.labelProdSize.Name = "labelProdSize";
            this.labelProdSize.Size = new System.Drawing.Size(67, 13);
            this.labelProdSize.TabIndex = 57;
            this.labelProdSize.Text = "Product Size";
            // 
            // labelProdPricePurch
            // 
            this.labelProdPricePurch.AutoSize = true;
            this.labelProdPricePurch.Location = new System.Drawing.Point(25, 405);
            this.labelProdPricePurch.Name = "labelProdPricePurch";
            this.labelProdPricePurch.Size = new System.Drawing.Size(85, 13);
            this.labelProdPricePurch.TabIndex = 59;
            this.labelProdPricePurch.Text = "Price Purchased";
            // 
            // labelProdWeight
            // 
            this.labelProdWeight.AutoSize = true;
            this.labelProdWeight.Location = new System.Drawing.Point(25, 350);
            this.labelProdWeight.Name = "labelProdWeight";
            this.labelProdWeight.Size = new System.Drawing.Size(81, 13);
            this.labelProdWeight.TabIndex = 58;
            this.labelProdWeight.Text = "Product Weight";
            // 
            // labelProdPriceRetail
            // 
            this.labelProdPriceRetail.AutoSize = true;
            this.labelProdPriceRetail.Location = new System.Drawing.Point(25, 432);
            this.labelProdPriceRetail.Name = "labelProdPriceRetail";
            this.labelProdPriceRetail.Size = new System.Drawing.Size(61, 13);
            this.labelProdPriceRetail.TabIndex = 64;
            this.labelProdPriceRetail.Text = "Retail Price";
            // 
            // labelProdCaseWeight
            // 
            this.labelProdCaseWeight.AutoSize = true;
            this.labelProdCaseWeight.Location = new System.Drawing.Point(25, 540);
            this.labelProdCaseWeight.Name = "labelProdCaseWeight";
            this.labelProdCaseWeight.Size = new System.Drawing.Size(68, 13);
            this.labelProdCaseWeight.TabIndex = 65;
            this.labelProdCaseWeight.Text = "Case Weight";
            // 
            // labelProdCaseSize
            // 
            this.labelProdCaseSize.AutoSize = true;
            this.labelProdCaseSize.Location = new System.Drawing.Point(25, 512);
            this.labelProdCaseSize.Name = "labelProdCaseSize";
            this.labelProdCaseSize.Size = new System.Drawing.Size(54, 13);
            this.labelProdCaseSize.TabIndex = 67;
            this.labelProdCaseSize.Text = "Case Size";
            // 
            // textBoxProdCaseSize
            // 
            this.textBoxProdCaseSize.Location = new System.Drawing.Point(144, 508);
            this.textBoxProdCaseSize.Name = "textBoxProdCaseSize";
            this.textBoxProdCaseSize.Size = new System.Drawing.Size(100, 20);
            this.textBoxProdCaseSize.TabIndex = 66;
            this.textBoxProdCaseSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxProdCaseSize_KeyPress);
            // 
            // comboBoxProdCatID
            // 
            this.comboBoxProdCatID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProdCatID.Location = new System.Drawing.Point(144, 373);
            this.comboBoxProdCatID.Name = "comboBoxProdCatID";
            this.comboBoxProdCatID.Size = new System.Drawing.Size(100, 21);
            this.comboBoxProdCatID.TabIndex = 0;
            // 
            // comboBoxSup
            // 
            this.comboBoxSup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSup.Location = new System.Drawing.Point(144, 563);
            this.comboBoxSup.Name = "comboBoxSup";
            this.comboBoxSup.Size = new System.Drawing.Size(100, 21);
            this.comboBoxSup.TabIndex = 68;
            // 
            // comboBoxCaseCount
            // 
            this.comboBoxCaseCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCaseCount.Items.AddRange(new object[] {
            "5",
            "10",
            "12",
            "24",
            "36"});
            this.comboBoxCaseCount.Location = new System.Drawing.Point(144, 482);
            this.comboBoxCaseCount.Name = "comboBoxCaseCount";
            this.comboBoxCaseCount.Size = new System.Drawing.Size(100, 21);
            this.comboBoxCaseCount.TabIndex = 69;
            // 
            // comboBoxProdType
            // 
            this.comboBoxProdType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProdType.Location = new System.Drawing.Point(144, 293);
            this.comboBoxProdType.Name = "comboBoxProdType";
            this.comboBoxProdType.Size = new System.Drawing.Size(100, 21);
            this.comboBoxProdType.TabIndex = 70;
            // 
            // formProductMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 642);
            this.Controls.Add(this.comboBoxProdType);
            this.Controls.Add(this.comboBoxCaseCount);
            this.Controls.Add(this.comboBoxSup);
            this.Controls.Add(this.comboBoxProdCatID);
            this.Controls.Add(this.labelProdCaseSize);
            this.Controls.Add(this.textBoxProdCaseSize);
            this.Controls.Add(this.labelProdCaseWeight);
            this.Controls.Add(this.labelProdPriceRetail);
            this.Controls.Add(this.labelProdSupID);
            this.Controls.Add(this.labelProdCaseCount);
            this.Controls.Add(this.labelProdCatID);
            this.Controls.Add(this.labelProdPricePrev);
            this.Controls.Add(this.labelProdSize);
            this.Controls.Add(this.labelProdPricePurch);
            this.Controls.Add(this.labelProdWeight);
            this.Controls.Add(this.labelProdType);
            this.Controls.Add(this.labelProdDesc);
            this.Controls.Add(this.labelProdSUPSKU);
            this.Controls.Add(this.textBoxProdCaseWeight);
            this.Controls.Add(this.textBoxProdPricePrev);
            this.Controls.Add(this.textBoxProdPriceRetail);
            this.Controls.Add(this.textBoxProdPricePurch);
            this.Controls.Add(this.textBoxProdWeight);
            this.Controls.Add(this.textBoxProdSize);
            this.Controls.Add(this.textBoxProdDesc);
            this.Controls.Add(this.textBoxProdColor);
            this.Controls.Add(this.buttonProdInsert);
            this.Controls.Add(this.buttonProdUpdate);
            this.Controls.Add(this.buttonProdClear);
            this.Controls.Add(this.textBoxProdName);
            this.Controls.Add(this.labelProdColor);
            this.Controls.Add(this.labelProdID);
            this.Controls.Add(this.buttonProdDelete);
            this.Controls.Add(this.labelCatHint);
            this.Controls.Add(this.dataGridViewProduct);
            this.Controls.Add(this.textBoxProdSUPSKU);
            this.Controls.Add(this.labelProdName);
            this.Controls.Add(this.textBoxProdBESKU);
            this.Controls.Add(this.labelProdBESKU);
            this.Controls.Add(this.textBoxProdID);
            this.Controls.Add(this.panelProdResult);
            this.Controls.Add(this.panelSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formProductMain";
            this.Text = "Product Management";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formProductMain_FormClosed);
            this.Load += new System.EventHandler(this.formProductMain_Load);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            this.panelProdResult.ResumeLayout(false);
            this.panelProdResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button buttonProdSearch;
        private System.Windows.Forms.TextBox textProdKeyword;
        private System.Windows.Forms.ComboBox comboProd;
        private System.Windows.Forms.Label labelProdSearchBy;
        private System.Windows.Forms.Button buttonProdInsert;
        private System.Windows.Forms.Button buttonProdUpdate;
        private System.Windows.Forms.Button buttonProdClear;
        private System.Windows.Forms.TextBox textBoxProdName;
        private System.Windows.Forms.Label labelProdColor;
        private System.Windows.Forms.Label labelProdID;
        private System.Windows.Forms.Button buttonProdDelete;
        private System.Windows.Forms.Label labelCatHint;
        private System.Windows.Forms.DataGridView dataGridViewProduct;
        private System.Windows.Forms.TextBox textBoxProdSUPSKU;
        private System.Windows.Forms.Label labelProdName;
        private System.Windows.Forms.TextBox textBoxProdBESKU;
        private System.Windows.Forms.Label labelProdBESKU;
        private System.Windows.Forms.TextBox textBoxProdID;
        private System.Windows.Forms.Panel panelProdResult;
        private System.Windows.Forms.Label labelProdSearchResult;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.TextBox textBoxProdSize;
        private System.Windows.Forms.TextBox textBoxProdDesc;
        private System.Windows.Forms.TextBox textBoxProdColor;
        private System.Windows.Forms.TextBox textBoxProdPriceRetail;
        private System.Windows.Forms.TextBox textBoxProdPricePurch;
        private System.Windows.Forms.TextBox textBoxProdWeight;
        private System.Windows.Forms.TextBox textBoxProdCaseWeight;
        private System.Windows.Forms.TextBox textBoxProdPricePrev;
        private System.Windows.Forms.Label labelProdSUPSKU;
        private System.Windows.Forms.Label labelProdDesc;
        private System.Windows.Forms.Label labelProdType;
        private System.Windows.Forms.Label labelProdSupID;
        private System.Windows.Forms.Label labelProdCaseCount;
        private System.Windows.Forms.Label labelProdCatID;
        private System.Windows.Forms.Label labelProdPricePrev;
        private System.Windows.Forms.Label labelProdSize;
        private System.Windows.Forms.Label labelProdPricePurch;
        private System.Windows.Forms.Label labelProdWeight;
        private System.Windows.Forms.Label labelProdPriceRetail;
        private System.Windows.Forms.Label labelProdCaseWeight;
        private System.Windows.Forms.Label labelProdCaseSize;
        private System.Windows.Forms.TextBox textBoxProdCaseSize;
        private System.Windows.Forms.ComboBox comboBoxProdCatID;
        private System.Windows.Forms.ComboBox comboBoxProdSearchList;
        private System.Windows.Forms.ComboBox comboBoxSup;
        private System.Windows.Forms.ComboBox comboBoxCaseCount;
        private System.Windows.Forms.ComboBox comboBoxProdType;
    }
}

