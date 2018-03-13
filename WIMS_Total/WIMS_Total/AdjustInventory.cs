using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb; //To connect DB

using BECategory;
using BESeason;
using BEProducts;
using BEInventory;
using BELogIn;
using BENewMainMenu;
using GlobalMethods;
using ProductListOnly;

namespace AdjustInventory
{
    public partial class formAdjustInventory : Form
    {
        public formAdjustInventory()
        {
            InitializeComponent();
            //locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
        }

        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

        private void formAdjustInventory_Load(object sender, EventArgs e)
        {
            labelInfo.Text = GlobalMethods.GlobalMethods.USERFULLNAME + "  " + "User ID: " + GlobalMethods.GlobalMethods.USER_ID + " Location:" + GlobalMethods.GlobalMethods.USER_LOCATION_NAME;
            comboBoxInvSearch.SelectedIndex = 1;

            //set buttons visible, enable property
            hideAll();

        }
        public int existingQOH;
        public int newQOH;
        public int difference = 0; // newQOH - existingQOH;  number of QOH modification
        static string prodID;
        //public string valueTosearch1Keyword;

        //Display result values into controls
        public void FillInvDGV(string valueTosearch2)
        {
            int invSearchResult;
            int prodSearchResult;
            int selectedIndexKind = comboBoxInvSearch.SelectedIndex;
            GlobalMethods.GlobalMethods.VALUETOSEARCH2KEYWORD = valueTosearch2;

            dataGridViewInventory.AllowUserToAddRows = false; // To set allowance for DGV


            switch (selectedIndexKind)
            {
                case 0:
                    {
                        GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD = "INV_ID";
                        break;
                    }
                case 1:
                    {
                        GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD = "PROD_ID";
                        break;
                    }
                case 2:
                    {
                        GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD = "PROD_NAME";
                        break;
                    }
                case 3:
                    {
                        GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD = "BE_SKU";
                        break;
                    }
                case 4:
                    {
                        GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD = "SUP_SKU";
                        break;
                    }

            }


            if (GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD != "INV_ID")
            {

                string toSearchProduct = "SELECT PROD_ID, BE_SKU, SUP_SKU, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, PROD_WEIGHT, CAT_ID, CASE_COUNT, SUP_ID "
                + "FROM PRODUCT "
                + "WHERE lower(" + GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD + ") LIKE '%" + GlobalMethods.GlobalMethods.VALUETOSEARCH2KEYWORD.ToLower() + "%' "
                + "ORDER BY PROD_ID ASC, CAT_ID ASC";



                OleDbCommand cmdProd = new OleDbCommand(toSearchProduct, conn);
                OleDbDataAdapter odaProd = new OleDbDataAdapter(cmdProd);
                DataTable tableProd = new DataTable();
                odaProd.Fill(tableProd);
                prodSearchResult = tableProd.Rows.Count;

                if (prodSearchResult == 0)
                {
                    if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "1") //Access Level of Warehouse Manager
                    {
                        DialogResult ins = MessageBox.Show("No Product found. Do you want to add a new Product?", "Data not found", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (ins == DialogResult.Yes)
                        {
                            formProductMain prodAdd = new formProductMain();

                            prodAdd.ShowDialog();
                            //this.Hide();
                        }
                        else if (ins == DialogResult.No)
                        {
                            MessageBox.Show("Please input another search keyword.", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            comboBoxInvSearch.SelectedIndex = 1;
                            textBoxInvSearchKeyword.Text = "";
                            textBoxInvSearchKeyword.Focus();
                        }
                    }

                    else
                    {
                        MessageBox.Show("Please input another search keyword or Ask Warehouse Manager to add a Product first.", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comboBoxInvSearch.SelectedIndex = 1;
                        textBoxInvSearchKeyword.Text = "";
                        textBoxInvSearchKeyword.Focus();
                    }
                }

                else if (prodSearchResult == 1)
                {

                    if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "1") //Access Level of Warehouse Manager
                    {
                        prodID = tableProd.Rows[0][0].ToString();
                        viewProductDetail(prodID);

                        //if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "1") //Access Level of Warehouse Manager
                        //{



                        //}

                        string toSearchInv = "SELECT INV_ID, PROD_ID, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, MIN_QTY, MAX_QTY, CASE_COUNT, LOC_NAME "
                                + "FROM PRODUCT INNER JOIN INVENTORY USING(PROD_ID) INNER JOIN LOCATION USING(LOCATION)"
                                + "WHERE lower(" + GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD + ") LIKE '%" + GlobalMethods.GlobalMethods.VALUETOSEARCH2KEYWORD.ToLower() + "%' "
                                + "ORDER BY INV_ID ASC, PROD_ID ASC";

                        OleDbCommand cmd1 = new OleDbCommand(toSearchInv, conn);
                        OleDbDataAdapter oda1 = new OleDbDataAdapter(cmd1);
                        DataTable table1 = new DataTable();
                        oda1.Fill(table1);
                        invSearchResult = table1.Rows.Count;

                        if (invSearchResult == 0)
                        {
                            labelInvSearchResult.Text = invSearchResult.ToString();
                            dataGridViewInventory.DataSource = null;
                            MessageBox.Show("No Inventory found. Please add Inventory first.", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            comboBoxInvLocation.Items.Clear();
                            comboBoxInvLocation.Text = "";
                            comboBoxInvShelfLoc.Items.Clear();
                            comboBoxInvShelfLoc.Text = "";
                            GlobalMethods.GlobalMethods.populateInvComboBox("LOCATION", "LOC_NAME", comboBoxInvLocation);
                            GlobalMethods.GlobalMethods.populateInvComboBox("INVENTORY", "SHELF_LOC", comboBoxInvShelfLoc);



                            buttonInsertInv.Visible = false;
                            buttonSaveInv.Visible = true;

                            panelDetailProdInfo.Visible = true;
                            panelDetailInvInfo.Visible = true;
                            panelDetailInvInfo.Enabled = true;
                            textBoxInvID.Enabled = false;
                            textBoxInvID.Text = "";
                            textBoxInvProdID.Enabled = false;
                            comboBoxInvLocation.Enabled = true;
                            comboBoxInvShelfLoc.Enabled = true;
                            textBoxInvQOH.Enabled = false;
                            textBoxInvQOH.Text = "0";
                            textBoxInvTransientQTY.Enabled = false;
                            textBoxInvMinQTY.Enabled = true;
                            textBoxInvMaxQTY.Enabled = true;

                            textBoxInvProdID.Text = prodID;
                            viewProductDetail(prodID);
                        }



                        else
                        {
                            panelInvView.Visible = true;
                            dataGridViewInventory.DataSource = table1;
                            //prodID = table1.Rows[0][0].ToString();
                            labelInvSearchResult.Text = invSearchResult.ToString();
                            dataGridViewInventory.DataSource = table1;
                            dataGridViewInventory.Visible = true;

                            //To set some properties for DataGridView
                            dataGridViewInventory.Columns[0].HeaderText = "Inventory ID";
                            dataGridViewInventory.Columns[1].HeaderText = "Product ID";
                            dataGridViewInventory.Columns[2].HeaderText = "Product Name";
                            dataGridViewInventory.Columns[3].HeaderText = "Product Color";
                            dataGridViewInventory.Columns[4].HeaderText = "Product Description";
                            dataGridViewInventory.Columns[5].HeaderText = "Product Type";
                            dataGridViewInventory.Columns[6].HeaderText = "Product Size";
                            dataGridViewInventory.Columns[7].HeaderText = "Minumum Quantity";
                            dataGridViewInventory.Columns[8].HeaderText = "Maximum Quantity";
                            dataGridViewInventory.Columns[9].HeaderText = "Case Count";
                            dataGridViewInventory.Columns[10].HeaderText = "Location Name";
                            dataGridViewInventory.AllowUserToAddRows = false;
                            invSearchResult = (int)dataGridViewInventory.RowCount;
                            labelInvSearchResult.Text = invSearchResult.ToString();
                        }

                    }
                  else if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "2") //When Access level = 2(Store Manager
                  {
                      prodID = tableProd.Rows[0][0].ToString();
                      viewProductDetail(prodID);


                      string toSearchInv = "SELECT INV_ID, PROD_ID, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, MIN_QTY, MAX_QTY, CASE_COUNT, LOC_NAME "
                              + "FROM PRODUCT INNER JOIN INVENTORY USING(PROD_ID) INNER JOIN LOCATION USING(LOCATION)"
                              + "WHERE lower(" + GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD + ") LIKE '%"
                              + GlobalMethods.GlobalMethods.VALUETOSEARCH2KEYWORD.ToLower() + "%' "
                              + "AND LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION + ""
                              + "ORDER BY INV_ID ASC, PROD_ID ASC";

                      OleDbCommand cmd1 = new OleDbCommand(toSearchInv, conn);
                      OleDbDataAdapter oda1 = new OleDbDataAdapter(cmd1);
                      DataTable table1 = new DataTable();
                      oda1.Fill(table1);
                      invSearchResult = table1.Rows.Count;

                      if (invSearchResult == 0)
                      {
                          labelInvSearchResult.Text = invSearchResult.ToString();
                          dataGridViewInventory.DataSource = null;
                          MessageBox.Show("No Inventory found. Please add Inventory first.", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                          comboBoxInvLocation.Items.Clear();
                          comboBoxInvLocation.Text = "";
                          GlobalMethods.GlobalMethods.populateInvComboBox("LOCATION", "LOC_NAME", comboBoxInvLocation);
                          GlobalMethods.GlobalMethods.populateInvComboBox("INVENTORY", "SHELF_LOC", comboBoxInvShelfLoc);
                          comboBoxInvShelfLoc.Items.Clear();
                          comboBoxInvShelfLoc.Text = "";


                          buttonInsertInv.Visible = false;
                          buttonSaveInv.Visible = true;

                          panelDetailProdInfo.Visible = true;
                          panelDetailInvInfo.Visible = true;
                          panelDetailInvInfo.Enabled = true;
                          textBoxInvID.Enabled = false;
                          textBoxInvID.Text = "";
                          textBoxInvProdID.Enabled = false;
                          comboBoxInvLocation.Enabled = true;
                          comboBoxInvShelfLoc.Enabled = true;
                          textBoxInvQOH.Enabled = false;
                          textBoxInvQOH.Text = "0";
                          textBoxInvTransientQTY.Enabled = false;
                          textBoxInvMinQTY.Enabled = true;
                          textBoxInvMaxQTY.Enabled = true;

                          textBoxInvProdID.Text = prodID;
                          viewProductDetail(prodID);
                      }

                      else
                      {
                          panelInvView.Visible = true;
                          dataGridViewInventory.DataSource = table1;
                          //prodID = table1.Rows[0][0].ToString();
                          labelInvSearchResult.Text = invSearchResult.ToString();
                          dataGridViewInventory.DataSource = table1;
                          dataGridViewInventory.Visible = true;
                          buttonInsertInv.Enabled = false;

                          //To set some properties for DataGridView
                          dataGridViewInventory.Columns[0].HeaderText = "Inventory ID";
                          dataGridViewInventory.Columns[1].HeaderText = "Product ID";
                          dataGridViewInventory.Columns[2].HeaderText = "Product Name";
                          dataGridViewInventory.Columns[3].HeaderText = "Product Color";
                          dataGridViewInventory.Columns[4].HeaderText = "Product Description";
                          dataGridViewInventory.Columns[5].HeaderText = "Product Type";
                          dataGridViewInventory.Columns[6].HeaderText = "Product Size";
                          dataGridViewInventory.Columns[7].HeaderText = "Minumum Quantity";
                          dataGridViewInventory.Columns[8].HeaderText = "Maximum Quantity";
                          dataGridViewInventory.Columns[9].HeaderText = "Case Count";
                          dataGridViewInventory.Columns[10].HeaderText = "Location Name";
                          dataGridViewInventory.AllowUserToAddRows = false;
                          invSearchResult = (int)dataGridViewInventory.RowCount;
                          labelInvSearchResult.Text = invSearchResult.ToString();
                      }
                  }
                }

                else
                {
                    prodID = GlobalMethods.GlobalMethods.PROD_ID;
 
                    if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "1") //Access Level of Warehouse Manager
                    {
                        formProductListOnly formProd = new formProductListOnly(tableProd);
                        formProd.ShowDialog();

                        if (prodID == null)
                        {
                            MessageBox.Show("No data selected. Please try again.", "Selection Warning");
                            textBoxInvSearchKeyword.Focus();
                        }

                        else
                        {


                            prodID = GlobalMethods.GlobalMethods.PROD_ID;

                            string toSearchInv = "SELECT INV_ID, PROD_ID, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, MIN_QTY, MAX_QTY, CASE_COUNT, LOC_NAME "
                                    + "FROM PRODUCT INNER JOIN INVENTORY USING(PROD_ID) INNER JOIN LOCATION USING(LOCATION)"
                                    + "WHERE  PROD_ID = " + prodID + ""
                                    + "ORDER BY INV_ID ASC, PROD_ID ASC";

                            OleDbCommand cmd1 = new OleDbCommand(toSearchInv, conn);
                            OleDbDataAdapter oda1 = new OleDbDataAdapter(cmd1);
                            DataTable table1 = new DataTable();
                            oda1.Fill(table1);
                            invSearchResult = table1.Rows.Count;

                            if (invSearchResult == 0)
                            {
                                labelInvSearchResult.Text = invSearchResult.ToString();
                                dataGridViewInventory.DataSource = null;
                                MessageBox.Show("No Inventory found. Please add Inventory first.", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                comboBoxInvLocation.Items.Clear();
                                comboBoxInvLocation.Text = "";
                                comboBoxInvShelfLoc.Items.Clear();
                                comboBoxInvShelfLoc.Text = "";
                                GlobalMethods.GlobalMethods.populateInvComboBox("LOCATION", "LOC_NAME", comboBoxInvLocation);
                                GlobalMethods.GlobalMethods.populateInvComboBox("INVENTORY", "SHELF_LOC", comboBoxInvShelfLoc);



                                buttonInsertInv.Visible = false;
                                buttonSaveInv.Visible = true;

                                panelDetailProdInfo.Visible = true;
                                panelDetailInvInfo.Visible = true;
                                panelDetailInvInfo.Enabled = true;
                                textBoxInvID.Enabled = false;
                                textBoxInvID.Text = "";
                                textBoxInvProdID.Enabled = false;
                                comboBoxInvLocation.Enabled = true;
                                comboBoxInvShelfLoc.Enabled = true;
                                textBoxInvQOH.Enabled = false;
                                textBoxInvQOH.Text = "0";
                                textBoxInvTransientQTY.Enabled = false;
                                textBoxInvMinQTY.Enabled = true;
                                textBoxInvMaxQTY.Enabled = true;

                                textBoxInvProdID.Text = prodID;
                                viewProductDetail(prodID);

                            }

                            else
                            {
                                panelInvView.Visible = true;
                                dataGridViewInventory.DataSource = table1;
                                //prodID = table1.Rows[0][0].ToString();
                                labelInvSearchResult.Text = invSearchResult.ToString();
                                dataGridViewInventory.DataSource = table1;
                                dataGridViewInventory.Visible = true;

                                //To set some properties for DataGridView
                                dataGridViewInventory.Columns[0].HeaderText = "Inventory ID";
                                dataGridViewInventory.Columns[1].HeaderText = "Product ID";
                                dataGridViewInventory.Columns[2].HeaderText = "Product Name";
                                dataGridViewInventory.Columns[3].HeaderText = "Product Color";
                                dataGridViewInventory.Columns[4].HeaderText = "Product Description";
                                dataGridViewInventory.Columns[5].HeaderText = "Product Type";
                                dataGridViewInventory.Columns[6].HeaderText = "Product Size";
                                dataGridViewInventory.Columns[7].HeaderText = "Minumum Quantity";
                                dataGridViewInventory.Columns[8].HeaderText = "Maximum Quantity";
                                dataGridViewInventory.Columns[9].HeaderText = "Case Count";
                                dataGridViewInventory.Columns[10].HeaderText = "Location Name";
                                dataGridViewInventory.AllowUserToAddRows = false;
                                invSearchResult = (int)dataGridViewInventory.RowCount;
                                labelInvSearchResult.Text = invSearchResult.ToString();
                            }
                        }

                    }
                    else if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "2") //Access Level of Warehouse Manager
                    {
                        formProductListOnly formProd = new formProductListOnly(tableProd);
                        formProd.ShowDialog();
                        prodID = GlobalMethods.GlobalMethods.PROD_ID;
                        if (prodID == null)
                        {
                            MessageBox.Show("No data selected. Please try again.", "Selection Warning");
                            textBoxInvSearchKeyword.Focus();
                        }
                        else
                        {
                            prodID = GlobalMethods.GlobalMethods.PROD_ID;

                            string toSearchInv = "SELECT INV_ID, PROD_ID, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, MIN_QTY, MAX_QTY, CASE_COUNT, LOC_NAME "
                                    + "FROM PRODUCT INNER JOIN INVENTORY USING(PROD_ID) INNER JOIN LOCATION USING(LOCATION)"
                                    + "WHERE  PROD_ID = " + prodID + ""
                                    + "AND LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION + ""
                                    + "ORDER BY INV_ID ASC, PROD_ID ASC";

                            OleDbCommand cmd1 = new OleDbCommand(toSearchInv, conn);
                            OleDbDataAdapter oda1 = new OleDbDataAdapter(cmd1);
                            DataTable table1 = new DataTable();
                            oda1.Fill(table1);
                            invSearchResult = table1.Rows.Count;

                            if (invSearchResult == 0)
                            {
                                labelInvSearchResult.Text = invSearchResult.ToString();
                                dataGridViewInventory.DataSource = null;
                                MessageBox.Show("No Inventory found. Please add Inventory first.", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                comboBoxInvLocation.Items.Clear();
                                comboBoxInvLocation.Text = "";
                                comboBoxInvShelfLoc.Items.Clear();
                                comboBoxInvShelfLoc.Text = "";
                                GlobalMethods.GlobalMethods.populateInvComboBox("LOCATION", "LOC_NAME", comboBoxInvLocation);
                                GlobalMethods.GlobalMethods.populateInvComboBox("INVENTORY", "SHELF_LOC", comboBoxInvShelfLoc);



                                buttonInsertInv.Visible = false;
                                buttonSaveInv.Visible = true;

                                panelDetailProdInfo.Visible = true;
                                panelDetailInvInfo.Visible = true;
                                panelDetailInvInfo.Enabled = true;
                                textBoxInvID.Enabled = false;
                                textBoxInvID.Text = "";
                                textBoxInvProdID.Enabled = false;
                                comboBoxInvLocation.Enabled = true;
                                comboBoxInvShelfLoc.Enabled = true;
                                textBoxInvQOH.Enabled = false;
                                textBoxInvQOH.Text = "0";
                                textBoxInvTransientQTY.Enabled = false;
                                textBoxInvMinQTY.Enabled = true;
                                textBoxInvMaxQTY.Enabled = true;

                                textBoxInvProdID.Text = prodID;
                                viewProductDetail(prodID);

                            }

                            else
                            {
                                panelInvView.Visible = true;
                                dataGridViewInventory.DataSource = table1;
                                //prodID = table1.Rows[0][0].ToString();
                                labelInvSearchResult.Text = invSearchResult.ToString();
                                dataGridViewInventory.DataSource = table1;
                                dataGridViewInventory.Visible = true;
                                buttonInsertInv.Enabled = false;

                                //To set some properties for DataGridView
                                dataGridViewInventory.Columns[0].HeaderText = "Inventory ID";
                                dataGridViewInventory.Columns[1].HeaderText = "Product ID";
                                dataGridViewInventory.Columns[2].HeaderText = "Product Name";
                                dataGridViewInventory.Columns[3].HeaderText = "Product Color";
                                dataGridViewInventory.Columns[4].HeaderText = "Product Description";
                                dataGridViewInventory.Columns[5].HeaderText = "Product Type";
                                dataGridViewInventory.Columns[6].HeaderText = "Product Size";
                                dataGridViewInventory.Columns[7].HeaderText = "Minumum Quantity";
                                dataGridViewInventory.Columns[8].HeaderText = "Maximum Quantity";
                                dataGridViewInventory.Columns[9].HeaderText = "Case Count";
                                dataGridViewInventory.Columns[10].HeaderText = "Location Name";
                                dataGridViewInventory.AllowUserToAddRows = false;
                                invSearchResult = (int)dataGridViewInventory.RowCount;
                                labelInvSearchResult.Text = invSearchResult.ToString();
                            }
                        }
                    }
                }
            }

            else
            {
                if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "1") //Access Level of Warehouse Manager
                {
                    string toSearchInv = "SELECT INV_ID, PROD_ID, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, MIN_QTY, MAX_QTY, CASE_COUNT, LOC_NAME "
                      + "FROM PRODUCT INNER JOIN INVENTORY USING(PROD_ID) INNER JOIN LOCATION USING(LOCATION)"
                      + "WHERE lower(" + GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD + ") LIKE '%" + GlobalMethods.GlobalMethods.VALUETOSEARCH2KEYWORD.ToLower() + "%' "
                      + "ORDER BY INV_ID ASC, PROD_ID ASC";

                    OleDbCommand cmd1 = new OleDbCommand(toSearchInv, conn);
                    OleDbDataAdapter oda1 = new OleDbDataAdapter(cmd1);
                    DataTable table1 = new DataTable();
                    oda1.Fill(table1);
                    invSearchResult = table1.Rows.Count;

                    if (invSearchResult == 0)
                    {

                        dataGridViewInventory.DataSource = null;

                        DialogResult ins = MessageBox.Show("No Inventory found. Please input another search keyword.", "No Inventory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (ins == DialogResult.Yes)
                        {
                            comboBoxInvSearch.SelectedIndex = 1;
                            textBoxInvSearchKeyword.Text = "";
                            textBoxInvSearchKeyword.Focus();

                        }

                    }

                    else
                    {
                        panelInvView.Visible = true;
                        dataGridViewInventory.DataSource = table1;
                        //prodID = table1.Rows[0][0].ToString();
                        labelInvSearchResult.Text = invSearchResult.ToString();
                        dataGridViewInventory.DataSource = table1;
                        dataGridViewInventory.Visible = true;

                        //To set some properties for DataGridView
                        dataGridViewInventory.Columns[0].HeaderText = "Inventory ID";
                        dataGridViewInventory.Columns[1].HeaderText = "Product ID";
                        dataGridViewInventory.Columns[2].HeaderText = "Product Name";
                        dataGridViewInventory.Columns[3].HeaderText = "Product Color";
                        dataGridViewInventory.Columns[4].HeaderText = "Product Description";
                        dataGridViewInventory.Columns[5].HeaderText = "Product Type";
                        dataGridViewInventory.Columns[6].HeaderText = "Product Size";
                        dataGridViewInventory.Columns[7].HeaderText = "Minumum Quantity";
                        dataGridViewInventory.Columns[8].HeaderText = "Maximum Quantity";
                        dataGridViewInventory.Columns[9].HeaderText = "Case Count";
                        dataGridViewInventory.Columns[10].HeaderText = "Location Name";
                        dataGridViewInventory.AllowUserToAddRows = false;
                        invSearchResult = (int)dataGridViewInventory.RowCount;
                        labelInvSearchResult.Text = invSearchResult.ToString();
                    }
                }
                else if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "2") //Access Level of Warehouse Manager
                {
                    string toSearchInv = "SELECT INV_ID, PROD_ID, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, MIN_QTY, MAX_QTY, CASE_COUNT, LOC_NAME "
                      + "FROM PRODUCT INNER JOIN INVENTORY USING(PROD_ID) INNER JOIN LOCATION USING(LOCATION)"
                      + "WHERE lower(" + GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD + ") LIKE '%" + GlobalMethods.GlobalMethods.VALUETOSEARCH2KEYWORD.ToLower() + "%' "
                      + "AND LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION + ""
                      + "ORDER BY INV_ID ASC, PROD_ID ASC";

                    OleDbCommand cmd1 = new OleDbCommand(toSearchInv, conn);
                    OleDbDataAdapter oda1 = new OleDbDataAdapter(cmd1);
                    DataTable table1 = new DataTable();
                    oda1.Fill(table1);
                    invSearchResult = table1.Rows.Count;

                    if (invSearchResult == 0)
                    {

                        dataGridViewInventory.DataSource = null;

                        DialogResult ins = MessageBox.Show("No Inventory found. Please input another search keyword.", "No Inventory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (ins == DialogResult.Yes)
                        {
                            comboBoxInvSearch.SelectedIndex = 1;
                            textBoxInvSearchKeyword.Text = "";
                            textBoxInvSearchKeyword.Focus();

                        }

                    }

                    else
                    {
                        panelInvView.Visible = true;
                        dataGridViewInventory.DataSource = table1;
                        //prodID = table1.Rows[0][0].ToString();
                        labelInvSearchResult.Text = invSearchResult.ToString();
                        dataGridViewInventory.DataSource = table1;
                        dataGridViewInventory.Visible = true;
                        buttonInsertInv.Enabled = false;

                        //To set some properties for DataGridView
                        dataGridViewInventory.Columns[0].HeaderText = "Inventory ID";
                        dataGridViewInventory.Columns[1].HeaderText = "Product ID";
                        dataGridViewInventory.Columns[2].HeaderText = "Product Name";
                        dataGridViewInventory.Columns[3].HeaderText = "Product Color";
                        dataGridViewInventory.Columns[4].HeaderText = "Product Description";
                        dataGridViewInventory.Columns[5].HeaderText = "Product Type";
                        dataGridViewInventory.Columns[6].HeaderText = "Product Size";
                        dataGridViewInventory.Columns[7].HeaderText = "Minumum Quantity";
                        dataGridViewInventory.Columns[8].HeaderText = "Maximum Quantity";
                        dataGridViewInventory.Columns[9].HeaderText = "Case Count";
                        dataGridViewInventory.Columns[10].HeaderText = "Location Name";
                        dataGridViewInventory.AllowUserToAddRows = false;
                        invSearchResult = (int)dataGridViewInventory.RowCount;
                        labelInvSearchResult.Text = invSearchResult.ToString();
                    }
                }
            }
        }


        //Search Inventory
        private void buttonInvSearch_Click(object sender, EventArgs e)
        {
            panelDetailInvInfo.Visible = false;
            panelDetailProdInfo.Visible = false;
            hideAll();
            //  panel2.Visible = true;
            FillInvDGV(textBoxInvSearchKeyword.Text);
            
        }

        //Hide all controls
        private void hideAll()
        {
            //set buttons visible, enable property
            buttonSaveInv.Visible = false;
            buttonInsertInv.Visible = false;
            buttonModInv.Visible = false;
            buttonAdjustInv.Visible = false;
            buttonAdjConfirm.Visible = false;
            panelAdjust.Visible = false;

            panelDetailInvInfo.Visible = false;
            panelDetailProdInfo.Visible = false;
        }

        //Display Detail information
        private void dataGridViewInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //string comm = "SELECT * FROM INVENTORY WHERE PROD_ID IN (SELECT PROD_ID FROM PRODUCT WHERE PROD_NAME ='?') AND "
            //    + "LOCATION IN (SELECT LOCATION FROM LOCATION WHERE LOC_NAME ='" + dataGridViewInventory.CurrentRow.Cells[8].Value.ToString()+"')";
            //MessageBox.Show(comm);

            buttonInsertInv.Visible = true;
            buttonSaveInv.Visible = false;
            buttonAdjConfirm.Visible = false;
            panelAdjust.Visible = false;
            buttonModInv.Enabled = true;
            buttonAdjustInv.Enabled = true;
            buttonInsertInv.Enabled = true;

            comboBoxInvLocation.Items.Clear();
            comboBoxInvLocation.Text = "";
            comboBoxInvShelfLoc.Items.Clear();
            comboBoxInvShelfLoc.Text = "";
            GlobalMethods.GlobalMethods.populateInvComboBox("LOCATION", "LOC_NAME", comboBoxInvLocation);
            GlobalMethods.GlobalMethods.populateInvComboBox("INVENTORY", "SHELF_LOC", comboBoxInvShelfLoc);

            panelDetailProdInfo.Visible = true;
            panelDetailInvInfo.Visible = true;
            panelDetailInvInfo.Enabled = true;
            textBoxInvID.Enabled = false;
            textBoxInvProdID.Enabled = false;
            comboBoxInvLocation.Enabled = false;
            comboBoxInvShelfLoc.Enabled = false;
            textBoxInvQOH.Enabled = false;
            textBoxInvTransientQTY.Enabled = false;
            textBoxInvMinQTY.Enabled = false;
            textBoxInvMaxQTY.Enabled = false;


            //panelInvButtons.Visible = true;
            //buttonInvAdjust.Enabled = true;
            //buttonInvEdit.Enabled = true;
            //buttonInvInsertTry.Enabled = true;
            //buttonInvDelete.Enabled = true;
            //buttonInvUpdate.Visible = false;
            //buttonInvEdit.Visible = true;

            //OleDbCommand cmd = new OleDbCommand("SELECT * FROM INVENTORY WHERE PROD_ID IN (SELECT PROD_ID FROM PRODUCT WHERE PROD_NAME =?) AND "
            //    + "LOCATION IN (SELECT LOCATION FROM LOCATION WHERE LOC_NAME ='" + dataGridViewInventory.CurrentRow.Cells[8].Value.ToString()+"')", conn);
            //cmd.Parameters.Add("?", OleDbType.VarChar).Value = dataGridViewInventory.CurrentRow.Cells[0].Value.ToString();

            OleDbCommand cmd = new OleDbCommand("SELECT * FROM INVENTORY WHERE INV_ID = "
                        + dataGridViewInventory.CurrentRow.Cells[0].Value.ToString() + "", conn);

            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);

            DataTable table = new DataTable();
            oda.Fill(table);
            prodID = dataGridViewInventory.CurrentRow.Cells[1].Value.ToString();

            textBoxInvID.Text = dataGridViewInventory.CurrentRow.Cells[0].Value.ToString();
            textBoxInvProdID.Text = dataGridViewInventory.CurrentRow.Cells[1].Value.ToString();
            comboBoxInvLocation.Text = dataGridViewInventory.CurrentRow.Cells[10].Value.ToString();
            comboBoxInvShelfLoc.Text = table.Rows[0][3].ToString();
            //textBoxInvShelfLoc.Text = table.Rows[0][3].ToString();
            textBoxInvQOH.Text = table.Rows[0][4].ToString();
            existingQOH = Convert.ToInt32(textBoxInvQOH.Text);
            textBoxInvTransientQTY.Text = table.Rows[0][5].ToString();
            textBoxInvMinQTY.Text = table.Rows[0][6].ToString();
            textBoxInvMaxQTY.Text = table.Rows[0][7].ToString();
            // textBoxInvLocation.Text = dataGridViewInventory.CurrentRow.Cells[8].Value.ToString();

            viewProductDetail(prodID);

            buttonAdjustInv.Visible = true;
            buttonModInv.Visible = true;

        }

        //Display Detail Product information when DGV cell clicked
        private void viewProductDetail(string prodDispKeyword)
        {

            panelDetailProdInfo.Enabled = false;
            comboBoxInvProdCatID.Items.Clear();
            comboBoxInvProdCatID.Text = "";
            GlobalMethods.GlobalMethods.populateInvComboBox("CATEGORY", "CAT_ID", comboBoxInvProdCatID);

            comboBoxInvSup.Items.Clear();
            comboBoxInvSup.Text = "";
            GlobalMethods.GlobalMethods.populateInvComboBox("SUPPLIER", "SUP_ID", comboBoxInvSup);

            comboBoxInvCaseCount.Items.Clear();
            comboBoxInvCaseCount.Text = "";
            GlobalMethods.GlobalMethods.populateInvComboBox("PRODUCT", "CASE_COUNT", comboBoxInvCaseCount);

            string comm = "SELECT * FROM PRODUCT WHERE PROD_ID = " + prodDispKeyword + "";
            OleDbCommand cmdProd = new OleDbCommand(comm, conn);
            OleDbDataAdapter odaProd = new OleDbDataAdapter(cmdProd);
            DataTable tableProd = new DataTable();
            odaProd.Fill(tableProd);



            //  textBoxInvProdID.Text = table.Rows[0][0].ToString();
            textBoxInvProdBESKU.Text = tableProd.Rows[0][1].ToString();
            textBoxInvProdSUPSKU.Text = tableProd.Rows[0][2].ToString();
            textBoxInvProdName.Text = tableProd.Rows[0][3].ToString();
            textBoxInvProdColor.Text = tableProd.Rows[0][4].ToString();
            textBoxInvProdDesc.Text = tableProd.Rows[0][5].ToString();
            textBoxInvProdType.Text = tableProd.Rows[0][6].ToString();
            textBoxInvProdSize.Text = tableProd.Rows[0][7].ToString();
            textBoxInvProdWeight.Text = tableProd.Rows[0][8].ToString();
            comboBoxInvProdCatID.Text = tableProd.Rows[0][9].ToString();
            textBoxInvProdPricePurch.Text = tableProd.Rows[0][10].ToString();
            textBoxInvProdPriceRetail.Text = tableProd.Rows[0][11].ToString();
            textBoxInvProdPricePrev.Text = tableProd.Rows[0][12].ToString();
            comboBoxInvCaseCount.Text = tableProd.Rows[0][13].ToString();
            textBoxInvProdCaseSize.Text = tableProd.Rows[0][14].ToString();
            textBoxInvProdCaseWeight.Text = tableProd.Rows[0][15].ToString();
            comboBoxInvSup.Text = tableProd.Rows[0][16].ToString();

        }
        //Confirm Inventory
        private void buttonConfirmInv_Click(object sender, EventArgs e)
        {
            DialogResult ins = MessageBox.Show("Is the QOH number right?", "Confirm Inventory", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (ins == DialogResult.Yes)
            {

                MessageBox.Show("The inventory is confirmed.", "Confirm Inventory");
                difference = 0;

            }

            else if (ins == DialogResult.No)
            {
                DialogResult ins2 = MessageBox.Show("Do you want to make entry of the Product?", "Product Entry", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (ins2 == DialogResult.OK)
                {
                    textBoxInvQOH.Enabled = true;
                    textBoxInvQOH.BackColor = Color.Yellow;
                    textBoxInvQOH.Focus();
                    buttonSaveInv.Visible = false;
                    buttonModInv.Visible = true;
                    existingQOH = Convert.ToInt32(textBoxInvQOH.Text);
                }
            }
        }


        //Try to Modify Inventory
        private void buttonModInv_Click(object sender, EventArgs e)
        {

            textBoxInvQOH.Enabled = true;
            newQOH = Convert.ToInt32(textBoxInvQOH.Text);
            panelAdjust.Visible = false;
            buttonAdjustInv.Enabled = false;
            buttonInsertInv.Enabled = false;

            if (newQOH <= existingQOH)
            {
                MessageBox.Show("To add inventory, it should be greater than the existing QOH", "Input Warning");
                textBoxInvQOH.Focus();

            }

            else
            {
                conn.Open();
                //to make entry of QOH
                string toMakeEntryQOH = "UPDATE INVENTORY SET QOH =? "
                        + " WHERE INV_ID = " + textBoxInvID.Text + "";

                OleDbCommand cmd4 = new OleDbCommand(toMakeEntryQOH, conn);
                cmd4.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvQOH.Text;

                if ((Convert.ToInt32(textBoxInvQOH.Text) > Convert.ToInt32(textBoxInvMaxQTY.Text))|| (Convert.ToInt32(textBoxInvQOH.Text) <= 0))
                {
                    MessageBox.Show("QOH can not be greater than Maximum QTY or it should be positive number. Please try again.", "QTY Input Error Notice");
                    textBoxInvQOH.Focus();
                }
                else
                {
                    if (cmd4.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Product entry has successfully made.", "Completion Entry Notice");
                        difference = newQOH - existingQOH;
                        string toAddQOHTable = "INSERT INTO ADJUSTMENT (ADJ_ID, INV_ID, QTY, ADJUST_TYPE, APPROVED_BY, USER_ID, ADJ_DATE)"
                             + "VALUES(ADJ_ID_SEQ.nextval, ?, ?, ?, ?, ?, ?)";

                        OleDbCommand cmdAdd = new OleDbCommand(toAddQOHTable, conn);
                        //allocate appropriate entry for controls
                        cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvID.Text;
                        cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = Math.Abs(difference);
                        cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = "InvQOHAdd";
                        cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USERFULLNAME;
                        cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USER_ID;
                        cmdAdd.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now;

                        //Run the Query and display message.
                        GlobalMethods.GlobalMethods.ExecMyQuery(cmdAdd, "Log data for Audit stored.");


                        //buttonModInv.Visible = false;

                    }
                    else
                    {
                        MessageBox.Show("Making Entry failed. Try again please.");
                    }
                }



                conn.Close();
            }

        }



        //try to Adjust Inventory
        private void buttonAdjustInv_Click(object sender, EventArgs e)
        {
            buttonModInv.Enabled = false;
            buttonAdjustInv.Visible = false;
            buttonAdjConfirm.Visible = true;
            panelAdjust.Visible = true;
            groupBoxAdjType.Visible = true;
            labelAdj.Visible = true;
            textBoxAdjAmt.Visible = true;
            textBoxAdjAmt.Text = "1";
            radioButtonDamaged.Checked = true;
            textBoxInvQOH.Enabled = false;
            buttonInsertInv.Enabled = false;



        }

        //Adjust Inventory
        private void buttonAdjConfirm_Click(object sender, EventArgs e)
        {

            int adjQTY = 0;
            conn.Open();
           // radioButtonDamaged.Checked = true;
            if ((textBoxAdjAmt.Text == "") || (Convert.ToInt32(textBoxAdjAmt.Text) <= 0))
            {
                MessageBox.Show("Please put the right quantity for adjusting. It should be positive number", "Input Error");
                textBoxAdjAmt.Focus();
            }
            else
            {
                adjQTY = Convert.ToInt32(textBoxAdjAmt.Text);
                newQOH = existingQOH - adjQTY;
                string toAddQOHTable = "INSERT INTO ADJUSTMENT (ADJ_ID, INV_ID, QTY, ADJUST_TYPE, APPROVED_BY, USER_ID, ADJ_DATE)"
                                + "VALUES(ADJ_ID_SEQ.nextval, ?, ?, ?, ?, ?, ?)";

                OleDbCommand cmdAdd = new OleDbCommand(toAddQOHTable, conn);
                //allocate appropriate entry for controls
                cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvID.Text;
                cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = Math.Abs(adjQTY);
                string radioValue;
                if (radioButtonLost.Checked)
                {
                    radioValue = "Lost";
                }
                else if (radioButtonDamaged.Checked)
                {
                    radioValue = "Damaged";
                }
                else
                {
                    radioValue = "Defective";
                }



                cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = radioValue;
                cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USERFULLNAME;
                cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USER_ID;
                cmdAdd.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now;

                //Run the Query and display message.
                GlobalMethods.GlobalMethods.ExecMyQuery(cmdAdd, "Log data for Audit stored.");
                //panelMroughInfo.Visible = false;
                //panelMbottom.Visible = false;
                //textBoxMKeyword.Focus();


                //to make entry of QOH
                string toUpdaeAfterAdjust = "UPDATE INVENTORY SET QOH =? "
                        + " WHERE INV_ID = " + textBoxInvID.Text + "";

                OleDbCommand cmdUpdateQOH = new OleDbCommand(toUpdaeAfterAdjust, conn);
                cmdUpdateQOH.Parameters.Add("?", OleDbType.VarChar).Value = newQOH;
                GlobalMethods.GlobalMethods.ExecMyQuery(cmdUpdateQOH, "Product QOH has updated as well.");


                formAdjustInventory_Load(sender, e);
            }

            conn.Close();
        }


        //Insert Inventory
        private void buttonInsertInv_Click(object sender, EventArgs e)
        {
            buttonInsertInv.Visible = false;
            buttonSaveInv.Visible = true;
            buttonModInv.Enabled = false;
            buttonAdjustInv.Enabled = false;



            comboBoxInvLocation.Items.Clear();
            comboBoxInvLocation.Text = "";
            comboBoxInvShelfLoc.Items.Clear();
            comboBoxInvShelfLoc.Text = "";
            GlobalMethods.GlobalMethods.populateInvComboBox("LOCATION", "LOC_NAME", comboBoxInvLocation);
            GlobalMethods.GlobalMethods.populateInvComboBox("INVENTORY", "SHELF_LOC", comboBoxInvShelfLoc);


            panelDetailProdInfo.Visible = true;
            panelDetailInvInfo.Visible = true;
            panelDetailInvInfo.Enabled = true;
            textBoxInvID.Enabled = false;
            textBoxInvID.Text = "";
            textBoxInvProdID.Enabled = false;
            comboBoxInvLocation.Enabled = true;
            comboBoxInvShelfLoc.Enabled = true;
            textBoxInvQOH.Enabled = false;
            textBoxInvQOH.Text = "0";
            textBoxInvTransientQTY.Enabled = false;
            textBoxInvMinQTY.Enabled = true;
            textBoxInvMaxQTY.Enabled = true;

        }

        //Save Inventory
        private void buttonSaveInv_Click(object sender, EventArgs e)
        {
            conn.Open();
            //int MaxQTY = Convert.ToInt32(textBoxInvMaxQTY.Text);
            //int MinQTY = Convert.ToInt32(textBoxInvMinQTY.Text);
            //if (MaxQTY < MinQTY)
            //{
            //    MessageBox.Show("Maximum QTY should be greater than or equal to Minimum QTY", "Data Warning");
            //    textBoxInvMaxQTY.Focus();
            //}



            try
            {

                int newInvLocation = Convert.ToInt32(GlobalMethods.GlobalMethods.USERLOCATION);
                //comboBoxInvLocation.SelectedIndex = 0;
                //comboBoxInvShelfLoc.SelectedIndex = 0;

                //if (textBoxInvProdID.Text == "")
                //{

                //    MessageBox.Show("The Product ID should be input. Please Search Product first.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    textBoxInvProdID.Focus();
                //    textBoxInvQOH.Text = "Type Numbers";
                //}

                if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "1") //Access Level of Warehouse Manager
                {
                    if (comboBoxInvLocation.Text != "")
                    {
                        //string[,] locationArray = new string[3,2];
                        //locationArray = CreateArray(locationArray, "Location", "INV_ID", "LOC_NAME");
                        if (comboBoxInvLocation.Text == "SJ-Warehouse")
                        {
                            newInvLocation = 0;
                        }
                        else if (comboBoxInvLocation.Text == "McAllister SJ")
                        {
                            newInvLocation = 1;
                        }
                        else if (comboBoxInvLocation.Text == "Sussex")
                        {
                            newInvLocation = 2;
                        }
                    }

                    else
                    {
                        MessageBox.Show("The Department location should be chosen. Please choose location to add Inventory.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comboBoxInvLocation.SelectedIndex = 0;
                    }

                }
                else if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "2") //Access Level of Store Manager
                {
                    if (comboBoxInvLocation.Text != "")
                    {
                        //string[,] locationArray = new string[3,2];
                        //locationArray = CreateArray(locationArray, "Location", "INV_ID", "LOC_NAME");
                        if (comboBoxInvLocation.Text == "SJ-Warehouse")
                        {
                            newInvLocation = 0;
                        }
                        else if (comboBoxInvLocation.Text == "McAllister SJ")
                        {
                            newInvLocation = 1;
                        }
                        else if (comboBoxInvLocation.Text == "Sussex")
                        {
                            newInvLocation = 2;
                        }
                    }

                    else
                    {
                        MessageBox.Show("The Location should be chosen. Please choose location to add Inventory.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comboBoxInvLocation.SelectedIndex = 0;
                    }

                    if (newInvLocation != Convert.ToInt32(GlobalMethods.GlobalMethods.USERLOCATION))
                    {

                        MessageBox.Show("You can only add your store's Inventory. Please try again.", "Location Error");
                        comboBoxInvLocation.Focus();
                        comboBoxInvLocation.ForeColor = Color.Blue;
                    }

                }


                if (comboBoxInvShelfLoc.Text == "")
                {
                    MessageBox.Show("The Shelf location should be chosen. Please choose location to add Inventory.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxInvShelfLoc.Focus();

                }
                else
                {
                    //if (comboBoxInvLocation.SelectedText == "SJ-Warehouse")
                    //{
                    //    //textBoxInvQOH.Enabled = true;
                    //    //MessageBox.Show("The QOH will be 0 if you don't put. Please make sure it.", "Input Default", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    //textBoxInvQOH.Focus();
                    //    textBoxInvQOH.Text = "0";
                    //}
                    //else
                    //{
                    textBoxInvQOH.Enabled = false;
                    //MessageBox.Show("The QOH will be 0 if you don't put. Please make sure it.", "Input Default", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //textBoxInvQOH.Focus();
                    textBoxInvQOH.Text = "0";
                    //}

                    if (textBoxInvTransientQTY.Text == "")
                    {
                        textBoxInvTransientQTY.Text = "";
                    }

                    if (textBoxInvMinQTY.Text == "")
                    {
                        MessageBox.Show("The Minimum Quantity should be input. Please Input number.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxInvMinQTY.Focus();
                    }

                    //else if ((textBoxInvMinQTY.Text=="") && (textBoxInvMaxQTY.Text!="") )
                    //{
                    //    MessageBox.Show("실행 6");
                    //     MessageBox.Show("The Minimum Quantity should be input first. Please Input Minimu Quantity first.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //     textBoxInvMinQTY.Focus();
                    //}

                    else if ((textBoxInvMinQTY.Text != ""))
                    {
                        if ((Convert.ToInt32(textBoxInvMinQTY.Text) % (Convert.ToInt32(comboBoxInvCaseCount.Text)) != 0))
                        {
                            MessageBox.Show("The Minimum Quantity should be multiple of case count. Please make sure it.", "Input Quantity Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxInvMinQTY.Focus();
                        }
                        else if ((Convert.ToInt32(textBoxInvMinQTY.Text) < Convert.ToInt32(comboBoxInvCaseCount.Text)))
                        {
                            MessageBox.Show("The Minimum Quantity should be greater than case count. Please make sure it.", "Input Quantity Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxInvMinQTY.Focus();
                        }
                        else if (textBoxInvMaxQTY.Text == "")
                        {
                            MessageBox.Show("The MaximuM Quantity should be input. Please Input number.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxInvMaxQTY.Focus();
                        }
                        else if (textBoxInvMaxQTY.Text != "")
                        {
                            if ((Convert.ToInt32(textBoxInvMinQTY.Text) > Convert.ToInt32(textBoxInvMaxQTY.Text)))
                            {
                                MessageBox.Show("The Maximum Quantity should be greater than the Minimum Quantity. Please input again..", "Input Quantity Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxInvMaxQTY.Focus();
                            }
                            else if ((Convert.ToInt32(textBoxInvMaxQTY.Text) % (Convert.ToInt32(comboBoxInvCaseCount.Text)) != 0))
                            {
                                MessageBox.Show("The Maximum Quantity should be multiple of case count. Please input again.", "Input Quantity Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBoxInvMaxQTY.Focus();
                            }
                            else
                            {

                                OleDbCommand cmd = new OleDbCommand("INSERT INTO INVENTORY (INV_ID, PROD_ID, LOCATION, SHELF_LOC, QOH, TRANSIENT_QTY, MIN_QTY, MAX_QTY)"
                                       + "VALUES(INV_ID_SEQ.nextval,?,?,?,?,?,?,?)", conn);
                                //cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdID.Text; I replaced with prod_id_seq sequnce
                                //cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdBESKU.Text; I replaced with prod_id_seq sequnce
                                cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvProdID.Text;

                                //allocate appropriate location ID from the location name
                                cmd.Parameters.Add("?", OleDbType.VarChar).Value = newInvLocation;
                                cmd.Parameters.Add("?", OleDbType.VarChar).Value = comboBoxInvShelfLoc.Text;
                                cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvQOH.Text;
                                cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvTransientQTY.Text;
                                cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvMinQTY.Text;
                                cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvMaxQTY.Text;
                                // MessageBox.Show(newInvLocation.ToString());  // Debug purpose
                                string tempProdID = textBoxInvProdID.Text;

                                //Run the Query and display message.
                                DialogResult ins = MessageBox.Show("Do you want to insert new Inventory Record into Database?", "Insert Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (ins == DialogResult.OK)
                                {
                                   // MessageBox.Show(newInvLocation.ToString() + prodID); //Debug purpose

                                    bool dupinv = checkIndDuplication(newInvLocation.ToString(), prodID);
                                    if (dupinv == false)
                                    {


                                        GlobalMethods.GlobalMethods.ExecMyQuery(cmd, "New Inventory data is successfully inserted");


                                        string toAddQOHTable = "INSERT INTO ADJUSTMENT (ADJ_ID, INV_ID, QTY, ADJUST_TYPE, APPROVED_BY, USER_ID, ADJ_DATE)"
                                                + "VALUES(ADJ_ID_SEQ.nextval, ?, ?, ?, ?, ?, ?)";

                                        OleDbCommand cmdAdd = new OleDbCommand(toAddQOHTable, conn);
                                        //allocate appropriate entry for controls
                                        cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvID.Text;
                                        cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvQOH.Text;
                                        cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = "AssignInv";
                                        cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USERFULLNAME;
                                        cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USER_ID;
                                        cmdAdd.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now;


                                        //MessageBox.Show("실행 9");
                                        //Run the Query and display message.
                                        GlobalMethods.GlobalMethods.ExecMyQuery(cmdAdd, "Log data for Audit stored.");

                                        //panelInvNormal.Visible = false;
                                        panelDetailInvInfo.Visible = false;
                                        panelDetailProdInfo.Visible = false;
                                        buttonSaveInv.Visible = false;

                                        string toSearchAfter = "SELECT INV_ID, PROD_ID, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, MIN_QTY, MAX_QTY, CASE_COUNT, LOC_NAME "
                                                + "FROM PRODUCT INNER JOIN INVENTORY USING(PROD_ID) INNER JOIN LOCATION USING(LOCATION)"
                                                  + "WHERE PROD_ID LIKE '%" + tempProdID + "%' "
                                                + "ORDER BY INV_ID ASC, PROD_ID ASC";



                                        OleDbCommand cmdAfter = new OleDbCommand(toSearchAfter, conn);

                                        OleDbDataAdapter odaAfter = new OleDbDataAdapter(cmdAfter);

                                        DataTable tableAfter = new DataTable();
                                        odaAfter.Fill(tableAfter);
                                        dataGridViewInventory.DataSource = tableAfter;
                                        labelInvSearchResult.Text = tableAfter.Rows.Count.ToString();
                                    }
                                    else
                                    {
                                        MessageBox.Show("The Inventory is duplicated.Please make sure it again.", "Duplication Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        comboBoxInvLocation.Focus();
                                    }
                                }

                                else
                                {
                                    comboBoxInvLocation.Focus();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eric Message - Unexpected Error occurred. Please try again or ask Administrator.", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(ex.Message);
                conn.Close();
            }

            conn.Close();

        }


        //Check Inventory Duplication
        public bool checkIndDuplication(string location, string prodid)
        {
            bool invDup = false;

            string checkInvDup = "SELECT * FROM INVENTORY "
                + " WHERE LOCATION = " + location + " AND PROD_ID = " + prodid + " ";
            OleDbCommand cmd = new OleDbCommand(checkInvDup, conn);
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataTable table = new DataTable();
            oda.Fill(table);
            int dupNum1 = table.Rows.Count;

            if (dupNum1 == 0)
            {
                invDup = false;

            }
            else
            {
                invDup = true;
            }
            return invDup;

        }

        //Set value when index changed
        private void comboBoxInvLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newInvLocation = 0;
            if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "2") //Access Level of Store Manager
            {

                if (comboBoxInvLocation.Text != "")
                {
                    //string[,] locationArray = new string[3,2];
                    //locationArray = CreateArray(locationArray, "Location", "INV_ID", "LOC_NAME");
                    if (comboBoxInvLocation.Text == "SJ-Warehouse")
                    {
                        newInvLocation = 0;
                    }
                    else if (comboBoxInvLocation.Text == "McAllister SJ")
                    {
                        newInvLocation = 1;
                    }
                    else if (comboBoxInvLocation.Text == "Sussex")
                    {
                        newInvLocation = 2;
                    }
                }

                else
                {
                    MessageBox.Show("The Location should be chosen. Please choose location to add Inventory.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxInvLocation.SelectedIndex = 0;
                    comboBoxInvLocation.ForeColor = Color.Red;
                }

                if (newInvLocation != Convert.ToInt32(GlobalMethods.GlobalMethods.USERLOCATION))
                {

                    MessageBox.Show("You can only add your store's Inventory. Please try again.", "Location Error");
                    comboBoxInvLocation.Focus();
                    comboBoxInvLocation.ForeColor = Color.Blue;
                }
            }
        }
    }
}
