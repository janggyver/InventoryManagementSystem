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
using AdjustInventory;
using GlobalMethods;

namespace InventoryNew
{
    public partial class formInventoryNew : Form
    {
        public formInventoryNew()
        {
            InitializeComponent();
            //locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;

           // MessageBox.Show(BELogIn.FormUserLogIn.USER_ID);
        }

        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

        private void formInventory_New_Load(object sender, EventArgs e)
        {
            labelInfo.Text = GlobalMethods.GlobalMethods.USERFULLNAME + "  " + "User ID: " + GlobalMethods.GlobalMethods.USER_ID + " Location:" + GlobalMethods.GlobalMethods.USER_LOCATION_NAME;
            //panelInvNormal.Visible = false;
            panelDetailInvInfo.Visible = false;
            panelDetailProdInfo.Visible = false;
            panelInvProdView.Visible = false;
            panelInvButtons.Visible = false;
        }

        static string prodID;
        //Display result values into controls
        public void FillInvDGV(string valueTosearch2)
        {

            //int invSearchResult;
            string valueTosearch1Keyword = "";
            int selectedIndexKind = comboBoxInvSearch.SelectedIndex;
            int prodSearchResult;
            //To set some properties for DataGridView
            //dataGridViewInvProdSearch.RowTemplate.Height = 30;
            dataGridViewInvProdSearch.AllowUserToAddRows = false;
            switch (selectedIndexKind)
            {

                case 0:
                    {
                        valueTosearch1Keyword = "PROD_ID";
                        break;
                    }
                case 1:
                    {
                        valueTosearch1Keyword = "PROD_NAME";
                        break;
                    }
                case 2:
                    {
                        valueTosearch1Keyword = "BE_SKU";
                        break;
                    }
                case 3:
                    {
                        valueTosearch1Keyword = "SUP_SKU";
                        break;
                    }

            }

 
            toSearchProduct = "SELECT PROD_ID, BE_SKU, SUP_SKU, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, PROD_WEIGHT, CAT_ID, CASE_COUNT, SUP_ID "
                            + "FROM PRODUCT "
                            + "WHERE lower(" + valueTosearch1Keyword + ") LIKE '%" + valueTosearch2.ToLower() + "%' "
                            + "ORDER BY PROD_ID ASC, CAT_ID ASC";

            OleDbCommand cmd1 = new OleDbCommand(toSearchProduct, conn);
            OleDbDataAdapter oda1 = new OleDbDataAdapter(cmd1);
            DataTable table1 = new DataTable();
            oda1.Fill(table1);
            prodSearchResult = table1.Rows.Count;

            if (prodSearchResult == 0)
            {
                dataGridViewInvProdSearch.DataSource = null;
                MessageBox.Show("No Product found. Please input another search keyword or Add new Product.", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBoxInvSearchKeyword.Text = "";
                textBoxInvSearchKeyword.Focus();
            }

            else
            {
                panelInvProdView.Visible = true;
                dataGridViewInvProdSearch.DataSource = table1;
                prodID = table1.Rows[0][0].ToString();
                labelInvProdSearchResult.Text = prodSearchResult.ToString();
            }
        }

            //else
            //{
            //    MessageBox.Show("ex 19");
            //    if (table1.Rows.Count == 0)
            //    {
            //        dataGridViewInvProdSearch.DataSource = null;
            //        //dataGridViewInventory.DataSource = null;

            //        MessageBox.Show("There is no Inventory Record. You have to search Product first if you want to add new Inventory Record. \n"
            //            + "Please search Product first.", "No Inventory Result", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //        textBoxInvSearchKeyword.Text = "";
            //        textBoxInvSearchKeyword.Focus();
            //        //ClearInvDetailFields();
            //       // ClearInvProdDetailFields();
            //        comboBoxInvSearch.SelectedIndex = 1;
            //        selectedIndexKind = comboBoxInvSearch.SelectedIndex;

            //    }
            //    else
            //    {
            //        //dataGridViewInventory.DataSource = table1;
            //        dataGridViewInvProdSearch.Visible = false;
            //        //dataGridViewInventory.Visible = true;

            //        //To set some properties for DataGridView
            //        //dataGridViewInventory.Columns[0].HeaderText = "Inventory ID";
            //        //dataGridViewInventory.Columns[1].HeaderText = "Product ID";
            //        //dataGridViewInventory.Columns[2].HeaderText = "Product Name";
            //        //dataGridViewInventory.Columns[3].HeaderText = "Product Color";
            //        //dataGridViewInventory.Columns[4].HeaderText = "Product Description";
            //        //dataGridViewInventory.Columns[5].HeaderText = "Product Type";
            //        //dataGridViewInventory.Columns[6].HeaderText = "Product Size";
            //        //dataGridViewInventory.Columns[7].HeaderText = "Minumum Quantity";
            //        //dataGridViewInventory.Columns[8].HeaderText = "Maximum Quantity";
            //        //dataGridViewInventory.Columns[9].HeaderText = "Case Count";
            //        //dataGridViewInventory.Columns[10].HeaderText = "Location Name";
            //        //dataGridViewInventory.RowTemplate.Height = 30;
            //        //dataGridViewInventory.AllowUserToAddRows = false;
            //        //invSearchResult = (int)dataGridViewInventory.RowCount;
            //        //labelInvSearchResult.Text = invSearchResult.ToString();
            //    }


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
            OleDbCommand cmd = new OleDbCommand(comm, conn);
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataTable table = new DataTable();
            oda.Fill(table);

            //  textBoxInvProdID.Text = table.Rows[0][0].ToString();
            textBoxInvProdBESKU.Text = table.Rows[0][1].ToString();
            textBoxInvProdSUPSKU.Text = table.Rows[0][2].ToString();
            textBoxInvProdName.Text = table.Rows[0][3].ToString();
            textBoxInvProdColor.Text = table.Rows[0][4].ToString();
            textBoxInvProdDesc.Text = table.Rows[0][5].ToString();
            textBoxInvProdType.Text = table.Rows[0][6].ToString();
            textBoxInvProdSize.Text = table.Rows[0][7].ToString();
            textBoxInvProdWeight.Text = table.Rows[0][8].ToString();
            comboBoxInvProdCatID.Text = table.Rows[0][9].ToString();
            textBoxInvProdPricePurch.Text = table.Rows[0][10].ToString();
            textBoxInvProdPriceRetail.Text = table.Rows[0][11].ToString();
            textBoxInvProdPricePrev.Text = table.Rows[0][12].ToString();
            comboBoxInvCaseCount.Text = table.Rows[0][13].ToString();
            textBoxInvProdCaseSize.Text = table.Rows[0][14].ToString();
            textBoxInvProdCaseWeight.Text = table.Rows[0][15].ToString();
            comboBoxInvSup.Text = table.Rows[0][16].ToString();

        }

        private void buttonInvSearch_Click(object sender, EventArgs e)
        {
            //  panel2.Visible = true;
            FillInvDGV(textBoxInvSearchKeyword.Text);
        }

        private void dataGridViewInvProdSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            prodID = dataGridViewInvProdSearch.CurrentRow.Cells[0].Value.ToString();
            panelDetailProdInfo.Visible = true;
            viewProductDetail(prodID);
            panelInvButtons.Visible = true;
            buttonInvAdjust.Enabled = true;
            panelDetailInvInfo.Visible = true;
            textBoxInvID.Enabled = false;
            textBoxInvProdID.Text = prodID;
            textBoxInvProdID.Enabled = false;
            textBoxInvQOH.Text = "0";
            textBoxInvQOH.Enabled = false;

            GlobalMethods.GlobalMethods.populateInvComboBox("LOCATION", "LOC_NAME", comboBoxInvLocation);
            GlobalMethods.GlobalMethods.populateInvComboBox("INVENTORY", "SHELF_LOC", comboBoxInvShelfLoc);
            comboBoxInvLocation.SelectedIndex = 0;    
        }

        // Assign a Inventory to Location
        private void buttonInvInsertTry_Click(object sender, EventArgs e)
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

                int newInvLocation = 0;
                comboBoxInvLocation.SelectedIndex = 0;

                if (textBoxInvProdID.Text == "")
                {

                    MessageBox.Show("The Product ID should be input. Please Search Product first.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxInvProdID.Focus();
                    textBoxInvQOH.Text = "Type Numbers";
                }


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
                    else
                    {
                        MessageBox.Show("The Department location should be chosen. Please choose location to add Inventory.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                }
                if (comboBoxInvShelfLoc.Text == "")
                {
                    MessageBox.Show("The Shelf location should be chosen. Please choose location to add Inventory.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxInvShelfLoc.Focus();

                }
                else
                {
                    if (comboBoxInvLocation.SelectedText == "SJ-Warehouse")
                    {
                        //textBoxInvQOH.Enabled = true;
                        //MessageBox.Show("The QOH will be 0 if you don't put. Please make sure it.", "Input Default", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //textBoxInvQOH.Focus();
                        textBoxInvQOH.Text = "0";
                    }
                    else
                    {
                        textBoxInvQOH.Enabled = false;
                        //MessageBox.Show("The QOH will be 0 if you don't put. Please make sure it.", "Input Default", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //textBoxInvQOH.Focus();
                        textBoxInvQOH.Text = "0";
                    }

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


                                //Run the Query and display message.
                                DialogResult ins = MessageBox.Show("Do you want to insert new Inventory Record into Database?", "Insert Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (ins == DialogResult.OK)
                                {
                                    GlobalMethods.GlobalMethods.ExecMyQuery(cmd, "New Inventory data is successfully inserted");
                                }

                                string toAddQOHTable = "INSERT INTO ADJUSTMENT (ADJ_ID, INV_ID, QTY, ADJUST_TYPE, APPROVED_BY, USER_ID, ADJ_DATE)"
                                        + "VALUES(ADJ_ID_SEQ.nextval, ?, ?, ?, ?, ?, ?)";

                                OleDbCommand cmdAdd = new OleDbCommand(toAddQOHTable, conn);
                                //allocate appropriate entry for controls
                                cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvID.Text;
                                cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvQOH.Text;
                                cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = "AssignInv";
                                cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USERFULLNAME;
                                cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USER_ID;
                                cmdAdd.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Today;

                                //MessageBox.Show("실행 9");
                                //Run the Query and display message.
                                GlobalMethods.GlobalMethods.ExecMyQuery(cmdAdd, "Log data for Audit stored.");

                                //panelInvNormal.Visible = false;
                                panelDetailInvInfo.Visible = false;
                                panelDetailProdInfo.Visible = false;
                                panelInvProdView.Visible = false;
                                panelInvButtons.Visible = false;

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

        public string toSearchProduct { get; set; }


        //To move to Adjust screen
        private void buttonInvAdjust_Click(object sender, EventArgs e)
        {
            formAdjustInventory formAdjustInv = new formAdjustInventory();
            formAdjustInv.Show();

        }
    }
}
