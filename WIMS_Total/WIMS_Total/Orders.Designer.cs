namespace Orders
{
    partial class formOrders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formOrders));
            this.panelOrderView = new System.Windows.Forms.Panel();
            this.labelInfoOrderView = new System.Windows.Forms.Label();
            this.labelProdIntro = new System.Windows.Forms.Label();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.panelSearchResultNum = new System.Windows.Forms.Panel();
            this.labelOrdSearchResult = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.comboBoxSearchBase2 = new System.Windows.Forms.ComboBox();
            this.comboBoxSearchBase1 = new System.Windows.Forms.ComboBox();
            this.textBoxOrdSearchKeyword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerOrdSearchEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerOrdSearchStart = new System.Windows.Forms.DateTimePicker();
            this.buttonOrdSearch = new System.Windows.Forms.Button();
            this.panelScLoginTitle = new System.Windows.Forms.Panel();
            this.buttonMLogout = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelProdSearchBy = new System.Windows.Forms.Label();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.panelOrdItemsView = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewOrdItems = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelOrdItemResult = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonAddItems = new System.Windows.Forms.Button();
            this.buttonSubmitOrder = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonReceive = new System.Windows.Forms.Button();
            this.panelOrderView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.panelSearchResultNum.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelScLoginTitle.SuspendLayout();
            this.panelOrdItemsView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrdItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOrderView
            // 
            this.panelOrderView.Controls.Add(this.labelInfoOrderView);
            this.panelOrderView.Controls.Add(this.labelProdIntro);
            this.panelOrderView.Controls.Add(this.dataGridViewOrders);
            this.panelOrderView.Controls.Add(this.panelSearchResultNum);
            this.panelOrderView.Location = new System.Drawing.Point(0, 125);
            this.panelOrderView.Name = "panelOrderView";
            this.panelOrderView.Size = new System.Drawing.Size(984, 157);
            this.panelOrderView.TabIndex = 141;
            // 
            // labelInfoOrderView
            // 
            this.labelInfoOrderView.AutoSize = true;
            this.labelInfoOrderView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfoOrderView.Location = new System.Drawing.Point(10, 12);
            this.labelInfoOrderView.Name = "labelInfoOrderView";
            this.labelInfoOrderView.Size = new System.Drawing.Size(121, 17);
            this.labelInfoOrderView.TabIndex = 118;
            this.labelInfoOrderView.Text = "■ Order List(s)";
            // 
            // labelProdIntro
            // 
            this.labelProdIntro.AutoSize = true;
            this.labelProdIntro.Location = new System.Drawing.Point(160, 12);
            this.labelProdIntro.Name = "labelProdIntro";
            this.labelProdIntro.Size = new System.Drawing.Size(339, 13);
            this.labelProdIntro.TabIndex = 110;
            this.labelProdIntro.Text = "**Tip: Click a line below if you want to see detail Order Item Information";
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewOrders.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewOrders.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewOrders.Location = new System.Drawing.Point(13, 35);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOrders.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewOrders.Size = new System.Drawing.Size(963, 115);
            this.dataGridViewOrders.TabIndex = 117;
            this.dataGridViewOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrders_CellClick);
            // 
            // panelSearchResultNum
            // 
            this.panelSearchResultNum.BackColor = System.Drawing.Color.AliceBlue;
            this.panelSearchResultNum.Controls.Add(this.labelOrdSearchResult);
            this.panelSearchResultNum.Controls.Add(this.label3);
            this.panelSearchResultNum.ForeColor = System.Drawing.Color.MediumBlue;
            this.panelSearchResultNum.Location = new System.Drawing.Point(807, 4);
            this.panelSearchResultNum.Name = "panelSearchResultNum";
            this.panelSearchResultNum.Size = new System.Drawing.Size(168, 28);
            this.panelSearchResultNum.TabIndex = 111;
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
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Results found";
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelSearch.Controls.Add(this.comboBoxSearchBase2);
            this.panelSearch.Controls.Add(this.comboBoxSearchBase1);
            this.panelSearch.Controls.Add(this.textBoxOrdSearchKeyword);
            this.panelSearch.Controls.Add(this.label2);
            this.panelSearch.Controls.Add(this.label1);
            this.panelSearch.Controls.Add(this.dateTimePickerOrdSearchEnd);
            this.panelSearch.Controls.Add(this.dateTimePickerOrdSearchStart);
            this.panelSearch.Controls.Add(this.buttonOrdSearch);
            this.panelSearch.Controls.Add(this.panelScLoginTitle);
            this.panelSearch.Controls.Add(this.labelProdSearchBy);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(984, 89);
            this.panelSearch.TabIndex = 140;
            // 
            // comboBoxSearchBase2
            // 
            this.comboBoxSearchBase2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchBase2.FormattingEnabled = true;
            this.comboBoxSearchBase2.Items.AddRange(new object[] {
            "Inventory ID",
            "BE SKU",
            "Supplier SKU"});
            this.comboBoxSearchBase2.Location = new System.Drawing.Point(235, 20);
            this.comboBoxSearchBase2.Name = "comboBoxSearchBase2";
            this.comboBoxSearchBase2.Size = new System.Drawing.Size(101, 21);
            this.comboBoxSearchBase2.TabIndex = 163;
            // 
            // comboBoxSearchBase1
            // 
            this.comboBoxSearchBase1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchBase1.FormattingEnabled = true;
            this.comboBoxSearchBase1.Items.AddRange(new object[] {
            "All Orders",
            "CREATE",
            "SUBMIT",
            "RECEIVED",
            "DELIVERED"});
            this.comboBoxSearchBase1.Location = new System.Drawing.Point(123, 20);
            this.comboBoxSearchBase1.Name = "comboBoxSearchBase1";
            this.comboBoxSearchBase1.Size = new System.Drawing.Size(106, 21);
            this.comboBoxSearchBase1.TabIndex = 160;
            // 
            // textBoxOrdSearchKeyword
            // 
            this.textBoxOrdSearchKeyword.Location = new System.Drawing.Point(342, 20);
            this.textBoxOrdSearchKeyword.Name = "textBoxOrdSearchKeyword";
            this.textBoxOrdSearchKeyword.Size = new System.Drawing.Size(134, 20);
            this.textBoxOrdSearchKeyword.TabIndex = 161;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 134;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 133;
            this.label1.Text = "From";
            // 
            // dateTimePickerOrdSearchEnd
            // 
            this.dateTimePickerOrdSearchEnd.CustomFormat = "dd/MMM/yyyy";
            this.dateTimePickerOrdSearchEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOrdSearchEnd.Location = new System.Drawing.Point(315, 51);
            this.dateTimePickerOrdSearchEnd.Name = "dateTimePickerOrdSearchEnd";
            this.dateTimePickerOrdSearchEnd.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerOrdSearchEnd.TabIndex = 132;
            // 
            // dateTimePickerOrdSearchStart
            // 
            this.dateTimePickerOrdSearchStart.CustomFormat = "dd/MMM/yyyy";
            this.dateTimePickerOrdSearchStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOrdSearchStart.Location = new System.Drawing.Point(163, 51);
            this.dateTimePickerOrdSearchStart.Name = "dateTimePickerOrdSearchStart";
            this.dateTimePickerOrdSearchStart.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerOrdSearchStart.TabIndex = 131;
            // 
            // buttonOrdSearch
            // 
            this.buttonOrdSearch.Location = new System.Drawing.Point(480, 12);
            this.buttonOrdSearch.Name = "buttonOrdSearch";
            this.buttonOrdSearch.Size = new System.Drawing.Size(75, 37);
            this.buttonOrdSearch.TabIndex = 3;
            this.buttonOrdSearch.Text = "Search";
            this.buttonOrdSearch.UseVisualStyleBackColor = true;
            this.buttonOrdSearch.Click += new System.EventHandler(this.buttonOrdSearch_Click);
            // 
            // panelScLoginTitle
            // 
            this.panelScLoginTitle.AutoSize = true;
            this.panelScLoginTitle.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelScLoginTitle.Controls.Add(this.buttonMLogout);
            this.panelScLoginTitle.Controls.Add(this.labelInfo);
            this.panelScLoginTitle.Location = new System.Drawing.Point(561, 0);
            this.panelScLoginTitle.Name = "panelScLoginTitle";
            this.panelScLoginTitle.Size = new System.Drawing.Size(423, 30);
            this.panelScLoginTitle.TabIndex = 130;
            // 
            // buttonMLogout
            // 
            this.buttonMLogout.ForeColor = System.Drawing.Color.Sienna;
            this.buttonMLogout.Location = new System.Drawing.Point(345, 4);
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
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(37, 96);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateOrder.TabIndex = 142;
            this.buttonCreateOrder.Text = "Create Order";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // panelOrdItemsView
            // 
            this.panelOrdItemsView.Controls.Add(this.label4);
            this.panelOrdItemsView.Controls.Add(this.label5);
            this.panelOrdItemsView.Controls.Add(this.dataGridViewOrdItems);
            this.panelOrdItemsView.Controls.Add(this.panel1);
            this.panelOrdItemsView.Location = new System.Drawing.Point(0, 296);
            this.panelOrdItemsView.Name = "panelOrdItemsView";
            this.panelOrdItemsView.Size = new System.Drawing.Size(984, 157);
            this.panelOrdItemsView.TabIndex = 143;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 17);
            this.label4.TabIndex = 118;
            this.label4.Text = "■ Item(s) in Order";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(433, 13);
            this.label5.TabIndex = 110;
            this.label5.Text = "**Tip: Click a line below if you want to see detail Order Item Information or mod" +
    "ify order item";
            // 
            // dataGridViewOrdItems
            // 
            this.dataGridViewOrdItems.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewOrdItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewOrdItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrdItems.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOrdItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewOrdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewOrdItems.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewOrdItems.Location = new System.Drawing.Point(13, 35);
            this.dataGridViewOrdItems.Name = "dataGridViewOrdItems";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOrdItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewOrdItems.Size = new System.Drawing.Size(963, 115);
            this.dataGridViewOrdItems.TabIndex = 117;
            this.dataGridViewOrdItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrdItems_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.labelOrdItemResult);
            this.panel1.Controls.Add(this.label7);
            this.panel1.ForeColor = System.Drawing.Color.MediumBlue;
            this.panel1.Location = new System.Drawing.Point(807, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 28);
            this.panel1.TabIndex = 111;
            // 
            // labelOrdItemResult
            // 
            this.labelOrdItemResult.AutoSize = true;
            this.labelOrdItemResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrdItemResult.ForeColor = System.Drawing.Color.Blue;
            this.labelOrdItemResult.Location = new System.Drawing.Point(29, 4);
            this.labelOrdItemResult.Name = "labelOrdItemResult";
            this.labelOrdItemResult.Size = new System.Drawing.Size(19, 20);
            this.labelOrdItemResult.TabIndex = 22;
            this.labelOrdItemResult.Text = "#";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(83, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Results found";
            // 
            // buttonAddItems
            // 
            this.buttonAddItems.Location = new System.Drawing.Point(348, 478);
            this.buttonAddItems.Name = "buttonAddItems";
            this.buttonAddItems.Size = new System.Drawing.Size(100, 40);
            this.buttonAddItems.TabIndex = 144;
            this.buttonAddItems.Text = "Add or Modify Order Items";
            this.buttonAddItems.UseVisualStyleBackColor = true;
            this.buttonAddItems.Click += new System.EventHandler(this.buttonAddItems_Click);
            // 
            // buttonSubmitOrder
            // 
            this.buttonSubmitOrder.Location = new System.Drawing.Point(681, 478);
            this.buttonSubmitOrder.Name = "buttonSubmitOrder";
            this.buttonSubmitOrder.Size = new System.Drawing.Size(100, 40);
            this.buttonSubmitOrder.TabIndex = 145;
            this.buttonSubmitOrder.Text = "Submit Order";
            this.buttonSubmitOrder.UseVisualStyleBackColor = true;
            this.buttonSubmitOrder.Click += new System.EventHandler(this.buttonSubmitOrder_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(456, 478);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(100, 40);
            this.buttonRemove.TabIndex = 147;
            this.buttonRemove.Text = "Remove Item";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonReceive
            // 
            this.buttonReceive.Location = new System.Drawing.Point(13, 478);
            this.buttonReceive.Name = "buttonReceive";
            this.buttonReceive.Size = new System.Drawing.Size(100, 40);
            this.buttonReceive.TabIndex = 148;
            this.buttonReceive.Text = "Receive Order";
            this.buttonReceive.UseVisualStyleBackColor = true;
            // 
            // formOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 536);
            this.Controls.Add(this.buttonReceive);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonSubmitOrder);
            this.Controls.Add(this.buttonAddItems);
            this.Controls.Add(this.panelOrdItemsView);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.panelOrderView);
            this.Controls.Add(this.panelSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formOrders";
            this.Text = "Order Management - Store Manager";
            this.Load += new System.EventHandler(this.Orders_Load);
            this.panelOrderView.ResumeLayout(false);
            this.panelOrderView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.panelSearchResultNum.ResumeLayout(false);
            this.panelSearchResultNum.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelScLoginTitle.ResumeLayout(false);
            this.panelScLoginTitle.PerformLayout();
            this.panelOrdItemsView.ResumeLayout(false);
            this.panelOrdItemsView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrdItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOrderView;
        private System.Windows.Forms.Label labelInfoOrderView;
        private System.Windows.Forms.Label labelProdIntro;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Panel panelSearchResultNum;
        private System.Windows.Forms.Label labelOrdSearchResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button buttonOrdSearch;
        private System.Windows.Forms.Panel panelScLoginTitle;
        private System.Windows.Forms.Button buttonMLogout;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelProdSearchBy;
        private System.Windows.Forms.DateTimePicker dateTimePickerOrdSearchStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerOrdSearchEnd;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Panel panelOrdItemsView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewOrdItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelOrdItemResult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonAddItems;
        private System.Windows.Forms.Button buttonSubmitOrder;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonReceive;
        private System.Windows.Forms.ComboBox comboBoxSearchBase2;
        private System.Windows.Forms.ComboBox comboBoxSearchBase1;
        private System.Windows.Forms.TextBox textBoxOrdSearchKeyword;
    }
}