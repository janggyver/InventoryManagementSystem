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


namespace BEProducts
{
    public partial class formProductMain : Form
    {
        public formProductMain()
        {
            InitializeComponent();
            //Locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
            textBoxProdID.Enabled = false;
            textBoxProdBESKU.Enabled = false;
            buttonProdInsert.Enabled = true;
            buttonProdDelete.Enabled = false;
            buttonProdUpdate.Enabled = false;
            buttonProdDelete.BackColor = Color.Gray;
            textProdKeyword.Focus();
        }

        //Create Connection Object for Database
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

        //Method for display data in Product Datagridview (Commonly used)
        public void FillProdDGV(string valueToSearch1, string valueToSearch2)
        {
            dataGridViewProduct.DataSource = null;
            dataGridViewProduct.Rows.Clear();
            string comboAnyKeySelected = (string)comboProd.SelectedIndex.ToString();
            int searchResult;
            if ((valueToSearch1 == "") || (comboAnyKeySelected == "Any Values"))
            {
                OleDbCommand cmd1 = new OleDbCommand("Select * from PRODUCT WHERE lower(PROD_ID) LIKE'%" + valueToSearch2.ToLower() + "%'"
                        + " OR BE_SKU LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR SUP_SKU LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR lower(PROD_NAME) LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR lower(PROD_COLOR) LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR lower(PROD_DESC) LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR lower(PROD_TYPE) LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR lower(PROD_SIZE) LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR PROD_WEIGHT LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR CAT_ID LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR PRICE_PURCH LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR PRICE_RETAIL LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR PRICE_PREV LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR CASE_COUNT LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR CASE_SIZE LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR CASE_WEIGHT LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR SUP_ID LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "ORDER BY PROD_ID ASC", conn);
                
                OleDbDataAdapter oda1 = new OleDbDataAdapter(cmd1);
                DataTable table1 = new DataTable();
                oda1.Fill(table1);

                //Fill datagridView with the datatable
                dataGridViewProduct.DataSource = table1;
                populateComboBox("CATEGORY", "CAT_ID", comboBoxProdCatID);
                populateComboBox("SUPPLIER", "SUP_ID", comboBoxSup);
                populateComboBox("PRODUCT", "PROD_TYPE", comboBoxProdType);
            }
            else
            {
                OleDbCommand cmd2 = new OleDbCommand("select * from PRODUCT WHERE lower(" + valueToSearch1 + ") LIKE '%" + valueToSearch2.ToLower() + "%' ORDER BY PROD_ID ASC", conn);
                OleDbDataAdapter oda2 = new OleDbDataAdapter(cmd2);
                DataTable table2 = new DataTable();
                oda2.Fill(table2);

                //Fill datagridView with the datatable
                dataGridViewProduct.DataSource = table2;
               
            }

            //To set some properties for DataGridView
            dataGridViewProduct.RowTemplate.Height = 30;
            dataGridViewProduct.AllowUserToAddRows = false;
            //dataGridViewCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //display the number of rows searched(or populated) in dataGridView
            searchResult = (int)dataGridViewProduct.RowCount;
            labelProdSearchResult.Text = searchResult.ToString();
        }

        //Populate data into the datagrdiview when the form loaded and display tooltips when the mouse is on
        private void formProductMain_Load(object sender, EventArgs e)
        {
            FillProdDGV("", "");

            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay =100;
            toolTip1.ReshowDelay = 500;

            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.buttonProdSearch, "Click to search with a keyword");
            toolTip1.SetToolTip(this.textProdKeyword, "Type any keyword to search");
            toolTip1.SetToolTip(this.comboProd, "Choose to set a filter to search by");
            toolTip1.SetToolTip(this.buttonProdClear, "Clear the data displayed above");
            toolTip1.SetToolTip(this.buttonProdUpdate, "Update the data");
            toolTip1.SetToolTip(this.buttonProdInsert, "Insert new data");
            toolTip1.SetToolTip(this.buttonProdDelete, "Delete data. Be Careful please.");

            //comboProd.SelectedIndex = 0;
            textProdKeyword.Focus();
            comboProd.SelectedIndex = 4;

        }
        //Declare variables to recognize the user input
        private bool firstInput = true; // variable to use when a user typed a letter in a textbox to search
        private void textProdKeyword_TextChanged(object sender, EventArgs e)
        {
            //Clear the text in the textBox when a user type something inside
            if (firstInput)
            {
                textProdKeyword.Clear();

                firstInput = false;
            }
        }

        //Search data from the database based on the filter(from the combobox) and keywords(taken from the user)
        private void buttonProdSearch_Click(object sender, EventArgs e)
        {
            string comboSelectedKeyword1 = (string)comboProd.SelectedIndex.ToString();
            string searchkeyword2 = textProdKeyword.Text;

            //Get a value from the comboBox and put the field name for the FillDGV() 
            if (comboSelectedKeyword1 == "0")
            {
                comboSelectedKeyword1 = "PROD_ID";
            }
            else if (comboSelectedKeyword1 == "1")
            {
                comboSelectedKeyword1 = "PROD_NAME";
            }

            else if (comboSelectedKeyword1 == "2")
            {
                comboSelectedKeyword1 = "CAT_ID";
            }

            else if (comboSelectedKeyword1 == "3")
            {
                comboSelectedKeyword1 = "SUP_ID";
            }

            else
            {
                comboSelectedKeyword1 = "";
            }

            string Keyword2 = textProdKeyword.Text;


            if (comboBoxProdSearchList.Visible)
            {
                Keyword2 = comboBoxProdSearchList.Text;
            }
            else
            {
                Keyword2 = textProdKeyword.Text;
            }

            FillProdDGV(comboSelectedKeyword1, Keyword2);
            textProdKeyword.Focus();
        }

        //Populate data into controls by clicking the datagridview line
        private void dataGridViewProduct_Click(object sender, EventArgs e)
        {
            //comboBoxProdCatID.Items.Clear();
            //comboBoxProdCatID.Text = "";
            textBoxProdBESKU.Enabled = true;

           // populateComboBox("CATEGORY", "CAT_ID", comboBoxProdCatID);

            textBoxProdID.Text = dataGridViewProduct.CurrentRow.Cells[0].Value.ToString();
            textBoxProdBESKU.Text = dataGridViewProduct.CurrentRow.Cells[1].Value.ToString();
            textBoxProdSUPSKU.Text = dataGridViewProduct.CurrentRow.Cells[2].Value.ToString();
            textBoxProdName.Text = dataGridViewProduct.CurrentRow.Cells[3].Value.ToString();
            textBoxProdColor.Text = dataGridViewProduct.CurrentRow.Cells[4].Value.ToString();
            textBoxProdDesc.Text = dataGridViewProduct.CurrentRow.Cells[5].Value.ToString();
            //textBoxProdType.Text = dataGridViewProduct.CurrentRow.Cells[6].Value.ToString();

            comboBoxProdType.Text = dataGridViewProduct.CurrentRow.Cells[6].Value.ToString();
            textBoxProdSize.Text = dataGridViewProduct.CurrentRow.Cells[7].Value.ToString();
            textBoxProdWeight.Text = dataGridViewProduct.CurrentRow.Cells[8].Value.ToString();
            comboBoxProdCatID.Text = dataGridViewProduct.CurrentRow.Cells[9].Value.ToString();
            //textBoxProdCatID.Text = dataGridViewProduct.CurrentRow.Cells[9].Value.ToString();

            textBoxProdPricePurch.Text = dataGridViewProduct.CurrentRow.Cells[10].Value.ToString();
            //textBoxProdPricePurch.Text = string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("en-US"), "{0:C2}", dataGridViewProduct.CurrentRow.Cells[10]);

            textBoxProdPriceRetail.Text = dataGridViewProduct.CurrentRow.Cells[11].Value.ToString();
            textBoxProdPricePrev.Text = dataGridViewProduct.CurrentRow.Cells[12].Value.ToString();
            comboBoxCaseCount.Text = dataGridViewProduct.CurrentRow.Cells[13].Value.ToString();
            textBoxProdCaseSize.Text = dataGridViewProduct.CurrentRow.Cells[14].Value.ToString();
            textBoxProdCaseWeight.Text = dataGridViewProduct.CurrentRow.Cells[15].Value.ToString();
            comboBoxSup.Text = dataGridViewProduct.CurrentRow.Cells[16].Value.ToString();
            textBoxProdID.ReadOnly = true;
            buttonProdInsert.Enabled = false;
            buttonProdDelete.Enabled = true;
            buttonProdUpdate.Enabled = true;
            buttonProdDelete.BackColor = Color.Red;


        }

        //To populate data(values) from the database just to select and prevent to edit.
        public void populateComboBox(string tableName, string fieldName, ComboBox comboBoxName)
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

        //Clear all controls empty
        private void buttonProdClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        ////Method to execute query and display message, lists after running
        //public void ExecMyQuery(OleDbCommand ocomd, String myMsg)
        //{
        //    conn.Open();
        //    if (ocomd.ExecuteNonQuery() == 1)
        //    {
        //        MessageBox.Show(myMsg);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Query Not Executed");
        //    }

        //    FillProdDGV("", "");
        //    conn.Close();
        //}

        //Insert new data into database from the user input
        private void buttonProdInsert_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {

            if (textBoxProdWeight.Text == "")
            {
                textBoxProdWeight.Text = "0";
            }


            //if (textBoxProdCaseWeight.Text == "")
            //{
            //    textBoxProdCaseWeight.Text = "0";
            //}
            //MessageBox.Show(Double.Parse(textBoxProdWeight.Text).ToString());
            //MessageBox.Show(Double.Parse(comboBoxCaseCount.Text).ToString());

            OleDbCommand cmd = new OleDbCommand("INSERT INTO PRODUCT (PROD_ID, BE_SKU, SUP_SKU, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE,PROD_WEIGHT"
                                       + ",CAT_ID, PRICE_PURCH, PRICE_RETAIL, PRICE_PREV, CASE_COUNT, CASE_SIZE, CASE_WEIGHT, SUP_ID)"
                                    + "VALUES(prod_id_seq.nextval,prod_BESKU_seq.nextVal,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", conn);
            //cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdID.Text; I replaced with prod_id_seq sequnce
            //cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdBESKU.Text; I replaced with prod_id_seq sequnce
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdSUPSKU.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdName.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdColor.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdDesc.Text;
            //cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdType.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = comboBoxProdType.Text;

            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdSize.Text;

            cmd.Parameters.Add("?", OleDbType.Double).Value = Double.Parse(textBoxProdWeight.Text);
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = comboBoxProdCatID.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdPricePurch.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdPriceRetail.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdPricePrev.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = comboBoxCaseCount.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdCaseSize.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = Double.Parse(textBoxProdWeight.Text)*Double.Parse(comboBoxCaseCount.Text);
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = comboBoxSup.Text;

            textBoxProdCaseWeight.Enabled = false;


                if ((string.IsNullOrWhiteSpace(textBoxProdCaseSize.Text)))
                {
                    MessageBox.Show("The Case Size of Product or Case Weight is not allowed left empty. Please try again.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBoxProdCaseSize.Focus();
                }
                //Range Check of Product Size
                else if ((Convert.ToDouble(textBoxProdCaseSize.Text) > 5) || (Convert.ToDouble(textBoxProdCaseSize.Text) < 0.2))
                {
                    MessageBox.Show("The Case Size of Product is out of range (O.2~5.0). Please try again.", "Number Range Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBoxProdCaseSize.Focus();
                }


                     
                else
                {
                    //Run the Query and display message.
                    DialogResult ins = MessageBox.Show("Do you want to insert new Product Record into Database?", "Insert Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (ins == DialogResult.OK)
                    {
                       GlobalMethods.GlobalMethods.ExecMyQuery(cmd, "New data is successfully inserted");
                       buttonProdSearch_Click(sender, e);
                       buttonProdClear_Click(sender, e);
                    }

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show("Eric Message: Unexpected Error occurred. Please try again or ask Administrator.", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBoxProdID.Text = "";
                textBoxProdID.Focus();
                MessageBox.Show(ex.Message);
            }



            conn.Close();
         
          
        }

        //Update database based on the values of the controls that user input
        private void buttonProdUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();

            OleDbCommand cmd = new OleDbCommand("UPDATE PRODUCT SET BE_SKU=?, SUP_SKU=?, PROD_NAME=?, PROD_COLOR=?, PROD_DESC=?, PROD_TYPE=?,"
                                        + "PROD_SIZE=?,PROD_WEIGHT=?,CAT_ID=?, PRICE_PURCH=?, PRICE_RETAIL=?, PRICE_PREV=?, CASE_COUNT=?,"
                                        + "CASE_SIZE=?, CASE_WEIGHT=?, SUP_ID=? WHERE PROD_ID=?", conn);
  
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdBESKU.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdSUPSKU.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdName.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdColor.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdDesc.Text;
            //cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdType.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = comboBoxProdType.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdSize.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdWeight.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = comboBoxProdCatID.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdPricePurch.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdPriceRetail.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdPricePrev.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = comboBoxCaseCount.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdCaseSize.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = Double.Parse(textBoxProdWeight.Text) * Double.Parse(comboBoxCaseCount.Text);


           // textBoxProdCaseSize.Enabled = false;
           // textBoxProdCaseWeight.Enabled = false;
           // cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdCaseSize.Text;
           // cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdCaseWeight.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = comboBoxSup.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdID.Text;
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxProdSize.Text))
                {
                    MessageBox.Show("The Size of Product is not allowed left empty. Please try again.", "Number Range Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBoxProdCaseSize.Focus();
                }
                //Range Check of Product Size
                else if ((Convert.ToDouble(textBoxProdCaseSize.Text) > 5) || (Convert.ToDouble(textBoxProdCaseSize.Text) < 0.2))
                {
                    MessageBox.Show("The Size of Product is out of range (O.2~5.0). Please try again.", "Number Range Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBoxProdCaseSize.Focus();
                }

                else
                {
                    //Run the Query and display message.
                    DialogResult upd = MessageBox.Show("Do you want to update this Record with new value into Database?", "Update Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (upd == DialogResult.OK)
                    {
                        GlobalMethods.GlobalMethods.ExecMyQuery(cmd, "Data is successfully updated.");
                    }
                }

            }
            catch(Exception exed)
            {
                MessageBox.Show("Unexpected Error occurred. Please try again or ask Administrator.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(exed.ToString());
            }

            conn.Close();
        }

        //Delete the data from the database chosen
        private void buttonProdDelete_Click(object sender, EventArgs e)
        {
            conn.Open();

            try
            {
                OleDbCommand cmd = new OleDbCommand("DELETE FROM PRODUCT WHERE PROD_ID=?", conn);
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxProdID.Text;
                //Run the Query and display message.
                DialogResult ins = MessageBox.Show("Do you really want to delete the selected Product Record from Database?", "Delete Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (ins == DialogResult.OK)
                {
                    GlobalMethods.GlobalMethods.ExecMyQuery(cmd, "Data is successfully deleted");
                    OleDbCommand commit = new OleDbCommand("commit");
                    ClearFields();
                }
                buttonProdSearch_Click(sender, e);


            }
            catch (Exception exe)
            {
                MessageBox.Show("Unexpected Error occurred. Please try again or ask Administrator.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(exe.ToString());
            }


            conn.Close();
            dataGridViewProduct.DataSource = null;
            dataGridViewProduct.Rows.Clear();
        }

        //Clear and set with all the control values with default
        public void ClearFields()
        {

            textBoxProdID.Text = "";
            textBoxProdBESKU.Text = "";
            textBoxProdSUPSKU.Text = "";
            textBoxProdName.Text = "";
            textBoxProdColor.Text = "";
            textBoxProdDesc.Text = "";
           // textBoxProdType.Text = "";
            comboBoxProdType.SelectedIndex = 0;
            textBoxProdSize.Text = "";
            textBoxProdWeight.Text = "";
            //textBoxProdCatID.Text = "";
            textBoxProdPricePurch.Text = "";
            textBoxProdPriceRetail.Text = "";
            textBoxProdPricePrev.Text = "";
            comboBoxCaseCount.SelectedIndex = 0;

            textBoxProdCaseSize.Text = "";
            textBoxProdCaseWeight.Text = "";
            //textBoxProdCaseSize.Enabled = false;
            textBoxProdCaseWeight.Enabled = false;
            comboBoxSup.SelectedIndex = 0;
            comboBoxProdCatID.SelectedIndex = 0;
            textProdKeyword.Text = "";
            textProdKeyword.Focus();
            buttonProdInsert.Enabled = true;
            textBoxProdBESKU.Enabled = false;
            buttonProdDelete.Enabled = false;
            buttonProdUpdate.Enabled = false;
            buttonProdDelete.BackColor = Color.Gray;
        }

        //Only get numbers with fixed digit from textbox 
        private void textBoxProdID_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 6;
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8)) && ((textBoxProdID.TextLength <= MaxDigit - 1) || (e.KeyChar == 8)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("Please enter only Number or fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }
        //Only get numbers with fixed digit from textbox 
        private void textBoxProdBESKU_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 6;
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8)) && ((textBoxProdBESKU.TextLength <= MaxDigit - 1) || (e.KeyChar == 8)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("Please enter only Number or fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }

        //Only get numbers with fixed digit from textbox 
        private void textBoxProdSUPSKU_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 12;
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8)) && ((textBoxProdSUPSKU.TextLength <= MaxDigit - 1) || (e.KeyChar == 8)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("Please enter only Number or fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }

        //Only get user input with fixed digits from textbox 
        private void textBoxProdName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 30;
            if ((textBoxProdName.TextLength <= MaxDigit - 1) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("The input data is too long. Please enter within fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }

        //Only get user input with fixed digits from textbox 
        private void textBoxProdColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 15;
            if ((textBoxProdColor.TextLength <= MaxDigit - 1) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("The input data is too long. Please enter within fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }

        //Only get user input with fixed digits from textbox 
        private void textBoxProdDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 30;
            if ((textBoxProdColor.TextLength <= MaxDigit - 1) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("The input data is too long. Please enter within fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }
        ////Only get user input with fixed digits from textbox 
        //private void textBoxProdType_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    int MaxDigit = 15;
        //    if ((textBoxProdType.TextLength <= MaxDigit - 1) || (e.KeyChar == 8))
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //    {
        //        e.Handled = true;
        //    }

        //    if (e.Handled == true)
        //    {
        //        MessageBox.Show("The input data is too long. Please enter within fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //        e.Handled = true;
        //    }
        //}

        //Only get user input with fixed digits from textbox 
        private void textBoxProdSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 7;
            if ((textBoxProdSize.TextLength <= MaxDigit - 1) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("The input data is too long. Please enter within fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }

        //Only get numbers with fixed digit of double from textbox 
        private void textBoxProdWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            int MaxDigit = 7; // +1 than the database filed size
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8) || (e.KeyChar==46)) && ((textBoxProdWeight.TextLength <= MaxDigit - 1) || (e.KeyChar == 8)))
            {
                e.Handled = false;
            }

            else 
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("Please enter only Valid Double Number or fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }
        /*
        //Only get user input with fixed digit's integer number from textbox 
        private void textBoxProdCatID_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 3;
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8)) && ((textBoxProdCatID.TextLength <= MaxDigit - 1) || (e.KeyChar == 8)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("Please enter only Number or fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }
         * */

        //Only get numbers with fixed digit of double from textbox 
        private void textBoxProdPricePurch_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 8; // +1 than the database filed size
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8) || (e.KeyChar == 46)) && ((textBoxProdPricePurch.TextLength <= MaxDigit - 1) || (e.KeyChar == 8)))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("Please enter only Valid Double Number or fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }

        //Only get numbers with fixed digit of double from textbox 
        private void textBoxProdPriceRetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 7; // +1 than the database filed size
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8) || (e.KeyChar == 46)) && ((textBoxProdPriceRetail.TextLength <= MaxDigit - 1) || (e.KeyChar == 8)))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("Please enter only Valid Double Number or fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }

        //Only get numbers with fixed digit of double from textbox 
        private void textBoxProdPricePrev_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 7; // +1 than the database filed size
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8) || (e.KeyChar == 46)) && ((textBoxProdPricePrev.TextLength <= MaxDigit - 1) || (e.KeyChar == 8)))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("Please enter only Valid Double Number or fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }

        /*
        //Only get user input with fixed digit's integer number from textbox
        private void textBoxProdCaseCount_KeyPress(object sender, KeyPressEventArgs e)
        {
                    
            int MaxDigit = 3;
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8)) && ((textBoxProdCaseCount.TextLength <= MaxDigit - 1) || (e.KeyChar == 8)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("Please enter only Number or fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }
         * */

        //Only get numbers with fixed digit of double from textbox 
        private void textBoxProdCaseSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 7; // +1 than the database filed size
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8) || (e.KeyChar == 46)) && ((textBoxProdCaseSize.TextLength <= MaxDigit - 1) || (e.KeyChar == 8)))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("Please enter only Valid Double Number or fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }

        //Only get numbers with fixed digit of double from textbox 
        private void textBoxProdCaseWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 7; // +1 than the database filed size
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8) || (e.KeyChar == 46)) && ((textBoxProdCaseWeight.TextLength <= MaxDigit - 1) || (e.KeyChar == 8)))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("Please enter only Valid Double Number or fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }

        /*
        //Only get user input with fixed digit's integer number from textbox
        private void textBoxProdSupID_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 5;
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8)) && ((textBoxProdSupID.TextLength <= MaxDigit - 1) || (e.KeyChar == 8)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("Please enter only Number or fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }
        */

        //When the selected Index is changed from the combobox, focus on the keyword textbox
        private void comboProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();

            int comboSelectedIndex = comboProd.SelectedIndex;

            //Get a value from the comboBox and put the field name for the FillDGV() 
            if (comboSelectedIndex == 0)
            {
                comboBoxProdSearchList.Items.Clear();
                comboBoxProdSearchList.Visible = true;
                populateComboBox("PRODUCT","PROD_ID",comboBoxProdSearchList);
                textProdKeyword.Visible = false;
                textProdKeyword.Text = comboBoxProdSearchList.Text;

                comboBoxProdSearchList.Focus();
                comboBoxProdSearchList.SelectedIndex = 0;

            }
            else if (comboSelectedIndex == 2)
            {
                comboBoxProdSearchList.Items.Clear();
                comboBoxProdSearchList.Visible = true;
                populateComboBox("CATEGORY", "CAT_ID", comboBoxProdSearchList);
                textProdKeyword.Visible = false;
                textProdKeyword.Text = comboBoxProdSearchList.Text;
                comboBoxProdSearchList.Focus();
                comboBoxProdSearchList.SelectedIndex = 0;

            }            
            else
            {
                comboBoxProdSearchList.Visible = false;
                textProdKeyword.Visible = true;
            }

        }

        //Clear Datagridview when a form closed
        private void formProductMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataGridViewProduct.DataSource = null;
            dataGridViewProduct.Rows.Clear();
           // formMaintainDB formMaintainDB = new formMaintainDB();
           // formMaintainDB.Show();
           // this.Hide();

        }
   

    }
}
