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


namespace BEInventory
{
    public partial class FormInventory : Form
    {
        public FormInventory()
        {
            InitializeComponent();
            //locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;

           // MessageBox.Show(BELogIn.FormUserLogIn.USER_ID);

        }

        //public string User_ID = GlobalMethods.GlobalMethods.USER_ID;
        //public string User_Location = GlobalMethods.GlobalMethods.USERLOCATION;



        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

        private void FormInventory_Load(object sender, EventArgs e)
        {
            // dataGridViewInventory.Visible = false;

            ClearInvProdDetailFields();
            ClearInvDetailFields();
            panelDetailProdInfo.Visible = false;
            panel3.Visible = false;
            panelInvButtons.Visible = false;
            //panelInvProdView.Visible = false;
            panelInvNormal.Visible = true;
            buttonInvAdjust.Enabled = false;
            buttonInvEdit.Enabled = false;
            buttonInvInsertTry.Enabled = false;
            buttonInvDelete.Enabled = false;
            //buttonInvAdjust.BackColor = Color.LightGray;
            //buttonInvDelete.BackColor = Color.LightGray;
            panel3.Visible = false;

        }
        //Display result values into controls
        public void FillInvDGV(string valueTosearch2)
        {
            int invSearchResult;
            string toSearchStatement;
            string valueTosearch1Keyword="";
            int selectedIndexKind = comboBoxInvSearch.SelectedIndex;

            //To set some properties for DataGridView
            //dataGridViewInvProdSearch.RowTemplate.Height = 30;
            //dataGridViewInvProdSearch.AllowUserToAddRows = false;
            switch (selectedIndexKind)
            {
                case 0:
                    {
                        valueTosearch1Keyword = "INV_ID";
                        break;
                    }
                case 1:
                    {
                        valueTosearch1Keyword = "P.PROD_ID";
                        break;
                    }
                case 2:
                    {
                        valueTosearch1Keyword = "P.PROD_NAME";
                        break;
                    }
                case 3:
                    {
                        valueTosearch1Keyword = "P.BE_SKU";
                        break;
                    }
                case 4:
                    {
                        valueTosearch1Keyword = "P.SUP_SKU";
                        break;
                    }

            }
            //toSearchStatement = "SELECT * FROM INVENTORY WHERE INV_ID ==" + valueTosearch2 + "";
            //OleDbCommand cmd = new OleDbCommand(toSearchStatement);

            //joining tables with inner join 
            //toSearchStatement = "SELECT INV_ID, PROD_ID, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, MIN_QTY, MAX_QTY, CASE_COUNT, LOC_NAME "
            //                    +"FROM PRODUCT INNER JOIN INVENTORY USING(PROD_ID) INNER JOIN LOCATION USING(LOCATION)"
            //                    + "WHERE lower("+ valueTosearch1Keyword +") LIKE '%" + valueTosearch2.ToLower() + "%' "
            //                    + "ORDER BY INV_ID ASC, PROD_ID ASC";

            //joining tables and conditions
            toSearchStatement = "SELECT INV_ID, P.PROD_ID, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, MIN_QTY, MAX_QTY, CASE_COUNT, LOC_NAME "
                    + "FROM PRODUCT P, INVENTORY I,LOCATION L"
                    + " WHERE P.PROD_ID = I.PROD_ID AND I.LOCATION = L.LOCATION AND lower(" + valueTosearch1Keyword + ") LIKE '%" + valueTosearch2.ToLower() + "%' "
                    + "ORDER BY INV_ID ASC, PROD_ID ASC";

            OleDbCommand cmd = new OleDbCommand(toSearchStatement, conn);
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataTable table = new DataTable();
            oda.Fill(table);

            if(GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "2") // Access Level of 2 (Warehouse Manager)
            {


            }
            if ((selectedIndexKind == 1) || (selectedIndexKind == 2) || (selectedIndexKind == 3) || (selectedIndexKind == 4))
            {

                if (table.Rows.Count == 0)
                {
                    int invProductSearchResult;
                    string toSearchProdWithoutInvStatement = "SELECT * FROM PRODUCT P WHERE lower(" + valueTosearch1Keyword + ") LIKE '%" + valueTosearch2.ToLower() + "%' "
                            + "ORDER BY PROD_ID ASC";

                    //MessageBox.Show(toSearchProdWithoutInvStatement);
                    OleDbCommand cmdProd = new OleDbCommand(toSearchProdWithoutInvStatement, conn);
                    OleDbDataAdapter odaProd = new OleDbDataAdapter(cmdProd);
                    DataTable tableProd = new DataTable();
                    odaProd.Fill(tableProd);
                    //dataGridViewInvProdSearch.DataSource = tableProd;

                    invProductSearchResult = tableProd.Rows.Count;

                    if (invProductSearchResult == 0)
                    {
                        MessageBox.Show("No results found. Please input another search keyword for Product or Add new Product.", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxInvSearchKeyword.Text = "";
                        textBoxInvSearchKeyword.Focus();
                        ClearInvDetailFields();
                        ClearInvProdDetailFields();
                        panelInvNormal.Visible = true;
                        //panelInvProdView.Visible = false;
                    }
                    else
                    {
                        panelInvNormal.Visible = false;
                        //panelInvProdView.Visible = true;
                        //labelInvProdSearchResult.Text = invProductSearchResult.ToString();

                    }




                }
                else
                {

                    dataGridViewInventory.DataSource = table;

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
                    dataGridViewInventory.RowTemplate.Height = 30;
                    dataGridViewInventory.AllowUserToAddRows = false;
                    invSearchResult = (int)dataGridViewInventory.RowCount;
                    labelInvSearchResult.Text = invSearchResult.ToString();
                }
            }
            else
            {
                if (table.Rows.Count == 0)
                {

                    MessageBox.Show("There is no Inventory Record. You have to search Product first if you want to add new Inventory Record. \n"
                        +"Please search Product first.", "No Inventory Result", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    textBoxInvSearchKeyword.Text = "";
                    textBoxInvSearchKeyword.Focus();
                    ClearInvDetailFields();
                    ClearInvProdDetailFields();
                    comboBoxInvSearch.SelectedIndex = 1;
                    selectedIndexKind = comboBoxInvSearch.SelectedIndex;

                }
                else
                {
                    dataGridViewInventory.DataSource = table;

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
                    dataGridViewInventory.RowTemplate.Height = 30;
                    dataGridViewInventory.AllowUserToAddRows = false;
                    invSearchResult = (int)dataGridViewInventory.RowCount;
                    labelInvSearchResult.Text = invSearchResult.ToString();
                }
            }
        }




        private void buttonInvSearch_Click(object sender, EventArgs e)
        {
          //  panel2.Visible = true;
           FillInvDGV(textBoxInvSearchKeyword.Text);
        }

        //Clear and set with all the control values with default or Set all controls diabled
        public void ClearInvDetailFields()
        {
            textBoxInvID.Text = "";
            textBoxInvProdID.Text = "";
            comboBoxInvLocation.Text = "";
            //textBoxInvShelfLoc.Text = "";
            textBoxInvQOH.Text = "";
            textBoxInvTransientQTY.Text = "";
            textBoxInvMinQTY.Text = "";
            textBoxInvMaxQTY.Text = "";
            comboBoxInvShelfLoc.Text = "";

            textBoxInvID.Enabled = false;
            panelDetailProdInfo.Visible = false;
            //panelInvProdView.Visible = false;
            panelInvNormal.Visible = true;
            textBoxInvSearchKeyword.Text = "";
            textBoxInvSearchKeyword.Focus();
            dataGridViewInventory.DataSource = null;
            labelInvSearchResult.Text = "";
            buttonSaveNewInvWithExist.Visible = false;
            buttonInvInsertTry.Visible = true;
            buttonInvInsertTry.BackColor = Color.LightGreen;
            buttonInvClear.BackColor = Color.LightGreen;
        }

        //Clear and set with all the control values with default or Set all controls diabled
        public void ClearInvProdDetailFields()
        {

            //textBoxProdID.Enabled = false;
            textBoxInvProdBESKU.Enabled = false;
            textBoxInvProdSUPSKU.Enabled = false;
            textBoxInvProdName.Enabled = false;
            textBoxInvProdColor.Enabled = false;
            textBoxInvProdDesc.Enabled = false;
            textBoxInvProdType.Enabled = false;
            textBoxInvProdSize.Enabled = false;
            textBoxInvProdWeight.Enabled = false;
            //textBoxProdCatID.Text = "";
            textBoxInvProdPricePurch.Enabled = false;
            textBoxInvProdPriceRetail.Enabled = false;
            textBoxInvProdPricePrev.Enabled = false;
            comboBoxInvCaseCount.Enabled = false;
            textBoxInvProdCaseSize.Enabled = false;
            textBoxInvProdCaseWeight.Enabled = false;
            //textBoxProdCaseSize.Enabled = false;
            textBoxInvProdCaseWeight.Enabled = false;
            comboBoxInvSup.Enabled = false;
            comboBoxInvProdCatID.Enabled = false;
            //textBoxInvSearchKeyword.Text = "";
            //comboBoxInvSearchList.Visible = false;
            textBoxInvSearchKeyword.Focus();
            comboBoxInvSearch.SelectedIndex = 0;
        }


        private void viewProductDetail(string prodDispKeyword)
        {
            panelDetailProdInfo.Enabled = false;
            comboBoxInvProdCatID.Items.Clear();
            comboBoxInvProdCatID.Text = "";
            populateInvComboBox("CATEGORY", "CAT_ID", comboBoxInvProdCatID);

            comboBoxInvSup.Items.Clear();
            comboBoxInvSup.Text = "";
            populateInvComboBox("SUPPLIER", "SUP_ID", comboBoxInvSup);

            comboBoxInvCaseCount.Items.Clear();
            comboBoxInvCaseCount.Text = "";
            populateInvComboBox("PRODUCT", "CASE_COUNT", comboBoxInvCaseCount);

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

        private void dataGridViewInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string comm = "SELECT * FROM INVENTORY WHERE PROD_ID IN (SELECT PROD_ID FROM PRODUCT WHERE PROD_NAME ='?') AND "
            //    + "LOCATION IN (SELECT LOCATION FROM LOCATION WHERE LOC_NAME ='" + dataGridViewInventory.CurrentRow.Cells[8].Value.ToString()+"')";
            //MessageBox.Show(comm);
            comboBoxInvLocation.Items.Clear();
            comboBoxInvLocation.Text = "";
            populateInvComboBox("LOCATION", "LOC_NAME", comboBoxInvLocation);
            comboBoxInvShelfLoc.Items.Clear();
            comboBoxInvShelfLoc.Text = "";
            populateInvComboBox("INVENTORY", "SHELF_LOC", comboBoxInvShelfLoc);




            panelDetailProdInfo.Visible = true;
            panel3.Visible = true;
            panel3.Enabled = false;
            panelInvButtons.Visible = true;
            buttonInvAdjust.Enabled = true;
            buttonInvEdit.Enabled = true;
            buttonInvInsertTry.Enabled = true;
            buttonInvDelete.Enabled = true;
            buttonInvUpdate.Visible = false;
            buttonInvEdit.Visible = true;

            //OleDbCommand cmd = new OleDbCommand("SELECT * FROM INVENTORY WHERE PROD_ID IN (SELECT PROD_ID FROM PRODUCT WHERE PROD_NAME =?) AND "
            //    + "LOCATION IN (SELECT LOCATION FROM LOCATION WHERE LOC_NAME ='" + dataGridViewInventory.CurrentRow.Cells[8].Value.ToString()+"')", conn);
            //cmd.Parameters.Add("?", OleDbType.VarChar).Value = dataGridViewInventory.CurrentRow.Cells[0].Value.ToString();

            OleDbCommand cmd = new OleDbCommand("SELECT * FROM INVENTORY WHERE INV_ID = "
                        + dataGridViewInventory.CurrentRow.Cells[0].Value.ToString() + "", conn);

            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);

            DataTable table = new DataTable();
            oda.Fill(table);

            textBoxInvID.Text = dataGridViewInventory.CurrentRow.Cells[0].Value.ToString();
            textBoxInvProdID.Text = dataGridViewInventory.CurrentRow.Cells[1].Value.ToString();
            comboBoxInvLocation.Text = dataGridViewInventory.CurrentRow.Cells[10].Value.ToString();
            comboBoxInvShelfLoc.Text = table.Rows[0][3].ToString();
            //textBoxInvShelfLoc.Text = table.Rows[0][3].ToString();
            textBoxInvQOH.Text = table.Rows[0][4].ToString();
            textBoxInvTransientQTY.Text = table.Rows[0][5].ToString();
            textBoxInvMinQTY.Text = table.Rows[0][6].ToString();
            textBoxInvMaxQTY.Text = table.Rows[0][7].ToString();
            // textBoxInvLocation.Text = dataGridViewInventory.CurrentRow.Cells[8].Value.ToString();

            viewProductDetail(textBoxInvProdID.Text);
        }

        //To populate data(values) from the database just to select and prevent to edit.
        public void populateInvComboBox(string tableName, string fieldName, ComboBox comboBoxName)
        {
            OleDbCommand cmd = new OleDbCommand("select distinct(" + fieldName + ") from " + tableName + " ORDER BY " + fieldName + " ASC", conn);
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataTable table = new DataTable();
            oda.Fill(table);

            comboBoxName.Items.Clear();

            foreach (DataRow dr in table.Rows)
            {
                comboBoxName.Items.Add(dr[fieldName].ToString());
            }

        }


        //Clear the data in the inventory controls
        private void buttonProdClear_Click(object sender, EventArgs e)
        {
            ClearInvDetailFields();
            ClearInvProdDetailFields();
            dataGridViewInventory.ClearSelection();
            //dataGridViewInvProdSearch.ClearSelection();
            comboBoxInvSearch.SelectedIndex = 0;
        }


        //Clear text box when the selected index changed
        private void comboBoxInvSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearInvDetailFields();
            dataGridViewInventory.ClearSelection();
            //textBoxInvSearchKeyword.Text = "";
            //textBoxInvSearchKeyword.Focus();
        }

        //Add new inventory
        private void buttonProdInsertTry_Click(object sender, EventArgs e)
        {
            textBoxInvID.Enabled = false;
            setControlsAfterAddInvButton();


        }
        //Method to execute query and display message, lists after running
        public void ExecMyQuery(OleDbCommand ocomd, String myMsg)
        {
            conn.Open();
            if (ocomd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(myMsg);
            }
            else
            {
                MessageBox.Show("Query Not Executed");
            }

            FillInvDGV("");
            conn.Close();
        }

        /*
        private void dataGridViewInvProdSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panelDetailProdInfo.Visible = true;
            viewProductDetail(dataGridViewInvProdSearch.CurrentRow.Cells[0].Value.ToString());
            textBoxInvProdID.Text = dataGridViewInvProdSearch.CurrentRow.Cells[0].Value.ToString();
            buttonInvEdit.Enabled = false;
            buttonInvAdjust.Enabled = false;
            buttonInvDelete.Enabled = false;
            populateInvComboBox("LOCATION", "LOC_NAME", comboBoxInvLocation);
          //  string comm = "SELECT INV_ID_SEQ FROM DUAL";
          //  OleDbCommand cmdSEQ = new OleDbCommand(comm, conn);
          //  OleDbDataAdapter oda = new OleDbDataAdapter(cmdSEQ);
          ////  DataTable tableSEQ = new DataTable();
          ////  oda.Fill(tableSEQ);

          //  //  textBoxInvProdID.Text = table.Rows[0][0].ToString();
          //  textBoxInvID.Text = oda.v
          //      //tableSEQ.Rows[0][0].ToString();
        }

        */
       //Set controls after clicking add new inventory
        private void setControlsAfterAddInvButton()
        {
            panel3.Enabled = true;
            textBoxInvID.Text = "";
            textBoxInvProdID.Enabled = false;
            comboBoxInvLocation.SelectedIndex = 0;
            comboBoxInvLocation.Enabled = true;
            comboBoxInvShelfLoc.Text = "";
            textBoxInvQOH.Text = "0";
            textBoxInvQOH.Enabled = false;
            textBoxInvTransientQTY.Text = "";
            textBoxInvMinQTY.Text = "";
            textBoxInvMaxQTY.Text = "";

            buttonInvDelete.Enabled = false;
            buttonInvEdit.Enabled = false;
            buttonInvAdjust.Enabled = false;
            buttonSaveNewInvWithExist.Visible = true;
            buttonSaveNewInvWithExist.BackColor = Color.LightGreen;
            buttonInvInsertTry.Visible = false;
            buttonInvUpdate.Visible = false;


        }

        private void buttonAddNewInvWithExist_Click(object sender, EventArgs e)
        {

            try
            {
                int newInvLocation = 0;

                if (textBoxInvProdID.Text=="")
                {

                    MessageBox.Show("The Product ID should be input. Please Search Product first.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxInvProdID.Focus();
                    textBoxInvQOH.Text = "Type Numbers";
                }
                if (comboBoxInvLocation.Text!="")
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
                    else if(comboBoxInvLocation.Text == "Sussex")
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
                     if (comboBoxInvLocation.SelectedText=="SJ-Warehouse")
                     {
                         textBoxInvQOH.Enabled = true;
                         MessageBox.Show("The QOH will be 0 if you don't put. Please make sure it.", "Input Default", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         textBoxInvQOH.Focus();
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
                            MessageBox.Show("The Maximu Quantity should be input. Please Input number.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                cmd.Parameters.Add("?", OleDbType.VarChar).Value = comboBoxInvShelfLoc.SelectedItem.ToString();
                                cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvQOH.Text;
                                cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvTransientQTY.Text;
                                cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvMinQTY.Text;
                                cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvMaxQTY.Text;

                                //Run the Query and display message.
                                DialogResult ins = MessageBox.Show("Do you want to insert new Inventory Record into Database?", "Insert Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (ins == DialogResult.OK)
                                {
                                    ExecMyQuery(cmd, "New data is successfully inserted");
                                }

                            }
                        }
                    }
                }
            }




            catch (Exception )
            {
                MessageBox.Show("Eric Message - Unexpected Error occurred. Please try again or ask Administrator.", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                textBoxInvProdID.Focus();
            }
        }

        //private string CreateArray(string locationArray, string p1, string p2, string p3)
        //{
        //    throw new NotImplementedException();
        //}


        // Create an Array to figure out sequence number 
        public string[,] CreateArray(string[,] newArray , string tableName, string fieldName1, string fieldName2)
        {
           // int arrayCount = 0;
            //string [,] locationArray;
            OleDbCommand cmd = new OleDbCommand("SELECT "+ fieldName1 + "," + fieldName2 + " FROM " + tableName + "" , conn);
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable table = new DataTable();
            oda.Fill(table);
            //foreach(DataRow dr in table.Rows){
            //    arrayCount++;
            //}

            newArray = new string[table.Rows.Count, table.Columns.Count];
   
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for(int j=0; j < table.Columns.Count; j++)
                {
                    newArray[i, j] = table.Rows[i][j].ToString();
                        //Columns[i][j].Value.Tostring(), (table.Columns[i][j+1].Value.Tostring()));
                }

            }

                return newArray;
        }

        //Delete Inventory
        private void buttonInvDelete_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("DELETE FROM INVENTORY WHERE INV_ID=?", conn);
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvID.Text;
                //Run the Query and display message.
                DialogResult ins = MessageBox.Show("Do you really want to delete selected Inventory Record from Database?", "Delete Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (ins == DialogResult.OK)
                {
                    ExecMyQuery(cmd, "Data is successfully deleted");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eric Message - Unexpected Error occurred. Please try again or ask Administrator.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        //Update(Modify) Inventory
        private void buttonInvEdit_Click(object sender, EventArgs e)
        {
            panel3.Enabled = true;
            textBoxInvProdID.Enabled = false;
            comboBoxInvLocation.Enabled = false;
            comboBoxInvShelfLoc.Enabled = true;
            textBoxInvQOH.Enabled = true;
            textBoxInvTransientQTY.Enabled = true;
            textBoxInvMinQTY.Enabled = true;
            textBoxInvMaxQTY.Enabled = true;

            buttonInvEdit.Visible = false;
            buttonInvUpdate.Visible = true;
            buttonInvUpdate.BackColor = Color.LightGreen;
            buttonInvInsertTry.Enabled = false;
            buttonInvAdjust.Enabled = false;
            buttonInvDelete.Enabled = false;



              
        }

        //Save updated Inventory Data into Database
        private void buttonInvUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxInvShelfLoc.Text == "")
                {
                    MessageBox.Show("The Shelf location should be chosen or input. Please try again.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxInvShelfLoc.Focus();
                }
                else
                {
                    if (textBoxInvQOH.Text == "")
                    {
                        MessageBox.Show("The QOH will be 0 if you don't put. Please make sure it.", "Input Default", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxInvQOH.Text = "0";
                        textBoxInvQOH.Focus();
                    }
                    else
                    {
                        if ((Convert.ToInt32(textBoxInvQOH.Text) <= (Convert.ToInt32(textBoxInvMaxQTY.Text))))
                        {
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
                                        MessageBox.Show("The Maximu Quantity should be input. Please Input number.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                            OleDbCommand cmd = new OleDbCommand("UPDATE INVENTORY SET SHELF_LOC=?, QOH=?, TRANSIENT_QTY=?, MIN_QTY=?, MAX_QTY=?"
                                                                       + " WHERE INV_ID=?", conn);

                                            cmd.Parameters.Add("?", OleDbType.VarChar).Value = comboBoxInvShelfLoc.Text;
                                            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvQOH.Text;
                                            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvTransientQTY.Text;
                                            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvMinQTY.Text;
                                            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvMaxQTY.Text;
                                            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxInvID.Text;

                                            //Run the Query and display message.
                                            DialogResult upd = MessageBox.Show("Do you want to update this Record with new value into Database?", "Update Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                            if (upd == DialogResult.OK)
                                            {
                                                ExecMyQuery(cmd, "New data is successfully updated");
                                            }

                                        }
                                    }
                                }
                        }
                        else{
                            MessageBox.Show("QOH can not be greater than Maxmum Quantity.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxInvQOH.Focus();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                MessageBox.Show("Unexpected Error occurred. Please try again or ask Administrator.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
        //Allow to modify QOH if the location is Warehouse
        private void comboBoxInvLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxInvLocation.Text == "SJ-Warehouse")
            {
                textBoxInvQOH.Enabled = true;
            }
            else
            {
                textBoxInvQOH.Enabled = false;
            }
        }

        private void FormInventory_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMaintainDB formMaintainDB = new formMaintainDB();
            formMaintainDB.Show();
            this.Hide();
        }
    }
}
