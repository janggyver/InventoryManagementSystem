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
using System.Data.OleDb;  // To connect to DB
using BECategory;
using BESeason;
using BEProducts;
using BEInventory;
using BELogIn;
using BENewMainMenu;

namespace BECategory
{
    public partial class formCategory : Form
    {
        public formCategory()
        {
            InitializeComponent();

            //Locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;

            textBoxCatID.Enabled = false;
            buttonCatDelete.Enabled = false;
            buttonCatDelete.BackColor = Color.Gray;
            buttonCatUpdate.Enabled = false;
        }
        //Create Connection Object for database
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Date Source=XE; User ID=Bullseye;Password=1111;Unicode=True");


        //Populate data into the datagrdiview when the form loaded and display tooltips when the mouse is on
        private void formCategory_Load(object sender, EventArgs e)
        {
  
            

            
            FillDGV("","");

            
            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.buttonCatSearch, "Click to search with a keyword");
            toolTip1.SetToolTip(this.textCatKeyword, "Type any keyword to search");
            toolTip1.SetToolTip(this.comboBoxCategory, "Choose to set a filter to search by");
            toolTip1.SetToolTip(this.buttonCatClear, "Clear the data displayed above");
            toolTip1.SetToolTip(this.buttonCatUpdate, "Update the data");
            toolTip1.SetToolTip(this.buttonCatInsert, "Insert new data");
            toolTip1.SetToolTip(this.buttonCatDelete, "Delete data. Be Careful please.");
            comboBoxCategory.SelectedIndex = 3;
            ClearFields();

        }
        //Declare variables to recognize the user input
        //private bool firstInput = true; // variable to use when a user typed a letter in a textbox to search



        //Fill data into DataGridView
        public void FillDGV(string valueToSearch1, string valueToSearch2)
        {

            string comboAnyKeySelected = (string)comboBoxCategory.SelectedIndex.ToString();
            int searchResult;


            if ((valueToSearch1 == "") ||(comboAnyKeySelected == "Any Values")) 
            {
                //OleDbCommand cmd = new OleDbCommand("select * from CATEGORY WHERE concat(CAT_ID, lower(CAT_NAME),SEASON_ID) LIKE '%" + valueToSearch2.ToLower() + "%'", conn);

                OleDbCommand cmd = new OleDbCommand("select * from CATEGORY WHERE lower(CAT_ID) LIKE '%" + valueToSearch2.ToLower() + "%'"
                        +" OR lower(CAT_NAME) LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR lower(SHORT_NAME) LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR lower(STOCK_TYPE) LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR lower(SEASON_ID) LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "OR lower(MISC_INFO) LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + "ORDER BY CAT_ID ASC ", conn);


                OleDbDataAdapter oda = new OleDbDataAdapter(cmd);

                DataTable table = new DataTable();
                oda.Fill(table);


                //Fill Datagridview with the DataTable
                dataGridViewCategory.DataSource = table;

                populateComboBox("SEASON", "SEASON_ID", comboBoxCatSeasonID);
               // comboCategory.SelectedIndex = 0;

                //foreach (DataRow row in table.Rows)
                //{
                //    if (row["CAT_ID"].ToString() == valueToSearch2)
                //    {
                //        textBoxTest.Text = row["CAT_Name"].ToString() + row["SHORT_NAME"].ToString();
                //        MessageBox.Show(row["CAT_Name"].ToString() + " " + row["SHORT_NAME"].ToString());
                //    }
                //}

            }
            else
            {
                OleDbCommand cmd = new OleDbCommand("select * from CATEGORY WHERE lower("+valueToSearch1+") LIKE '%" + valueToSearch2.ToLower() + "%'", conn);
                OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
                DataTable table = new DataTable();
                oda.Fill(table);

                //Fill Datagridview with the DataTable
                dataGridViewCategory.DataSource = table;
            }

            //To set some properties for DataGridView
            dataGridViewCategory.RowTemplate.Height = 30;
            dataGridViewCategory.AllowUserToAddRows = false;
            //dataGridViewCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //display the number of rows searched(or populated) in dataGridView
            searchResult = (int)dataGridViewCategory.RowCount;  
            labelSearchResult.Text = searchResult.ToString();

        }

        //Search data from the database based on the filter(from the combobox) and keywords(taken from the user)
        private void buttonCatSearch_Click(object sender, EventArgs e)
        {

            string comboSelectedKeyword1 = (string)comboBoxCategory.SelectedIndex.ToString();
            string Keyword2 = textCatKeyword.Text;
            //string searchkeyword2 = textCatKeyword.Text;

            //Get a value from the comboBox and put the field name for the FillDGV() 
            if (comboSelectedKeyword1 == "0")
            {
                comboSelectedKeyword1 = "CAT_ID";
            }
            else if (comboSelectedKeyword1 == "1")
            {
                comboSelectedKeyword1 = "CAT_NAME";
            }

            else if (comboSelectedKeyword1 == "2")
            {
                comboSelectedKeyword1 = "STOCK_TYPE";
            }

            else
            {
                comboSelectedKeyword1 = "";
            }

            if (comboBoxCatSearchList.Visible)
            {
                Keyword2 = comboBoxCatSearchList.Text;
            }
            else
            {
                Keyword2 = textCatKeyword.Text;
            }
            


            FillDGV(comboSelectedKeyword1, Keyword2);



        }

        //Populate data into controls by clicking the datagridview line
        private void dataGridViewCategory_Click(object sender, EventArgs e)
        {
            /*
                OleDbCommand cmd = new OleDbCommand("select distinct(SEASON_ID) from CATEGORY ORDER BY SEASON_ID ASC", conn);
                OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
                DataTable table = new DataTable();
                oda.Fill(table);
             */
                comboBoxCatSeasonID.Items.Clear();
                comboBoxCatSeasonID.Text = "";
  
            populateComboBox("SEASON","SEASON_ID",comboBoxCatSeasonID);
            
            textBoxCatID.Text = dataGridViewCategory.CurrentRow.Cells[0].Value.ToString();
            textBoxCatName.Text = dataGridViewCategory.CurrentRow.Cells[1].Value.ToString();
            textBoxCatShortName.Text = dataGridViewCategory.CurrentRow.Cells[2].Value.ToString();
            comboBoxCatSeasonID.Text = dataGridViewCategory.CurrentRow.Cells[4].Value.ToString();
            //textBoxSeasonID.Text = dataGridViewCategory.CurrentRow.Cells[4].Value.ToString();
            textBoxMiscInfo.Text = dataGridViewCategory.CurrentRow.Cells[5].Value.ToString();
            /*
            foreach(DataRow dr in table.Rows){
                comboBoxCatSeasonID.Items.Add(dr["SEASON_ID"].ToString());
            }
            */


            comboBoxCatSeasonID.SelectedValue = comboBoxCatSeasonID.Items.IsReadOnly;


            if (dataGridViewCategory.CurrentRow.Cells[3].Value.ToString() == "yes")
            {
                radioSeasonal.Checked = true;

            }
            else
            {

                radioRegular.Checked = true;
            }
            textBoxCatID.ReadOnly = true;
            buttonCatInsert.Enabled = false;
            buttonCatDelete.Enabled = true;
            buttonCatUpdate.Enabled = true;
            buttonCatDelete.BackColor = Color.Red;
        }

        //Cancel Button clicked, clear.
        private void buttonCatClear_Click(object sender, EventArgs e)
        {
            ClearFields();

        }


        // Clear all fields and uncheck radio buttons
        public void ClearFields()
        {
            
            textBoxCatID.Text = "";
            textBoxCatName.Text = "";
            textBoxCatShortName.Text = "";
            //textBoxSeasonID.Text = "";
            textBoxMiscInfo.Text = "";
            radioRegular.Checked = false;
            radioSeasonal.Checked = false;
            textBoxCatID.ReadOnly = false;
            //comboBoxCatSeasonID.Items.Clear();
            comboBoxCatSeasonID.SelectedIndex = 0;
            //comboCategory.SelectedIndex = 0;
            textCatKeyword.Text = "";
            textCatKeyword.Focus();
            buttonCatInsert.Enabled = true;
            buttonCatDelete.BackColor = Color.Gray;
            comboBoxCatSearchList.Visible = false;
            textCatKeyword.Visible = true;

        }

        //Update database based on the values of the controls that user input
        private void buttonCatUpdate_Click(object sender, EventArgs e)
        {

            OleDbCommand cmd = new OleDbCommand("UPDATE CATEGORY SET CAT_NAME=?, SHORT_NAME=?, STOCK_TYPE=?, SEASON_ID=?, MISC_INFO=? WHERE CAT_ID=?", conn);


            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxCatName.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxCatShortName.Text;
            if (radioSeasonal.Checked)
            {
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = "yes";
            }
            else
            {
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = "no";
            }

            //cmd.Parameters.Add("?", OleDbType.VarChar).Value = comboBoxCatSeasonID.SelectedItem.ToString();
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = comboBoxCatSeasonID.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxMiscInfo.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxCatID.Text;

            //Run the Query and display message.
            DialogResult upd = MessageBox.Show("Do you want to update this Record with new value into Database?", "Update Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (upd == DialogResult.OK)
            {
                ExecMyQuery(cmd, "New data is successfully updated");
            }


        }


        //Insert new data into database from the user input
        private void buttonCatInsert_Click(object sender, EventArgs e)
        {
            populateComboBox("CATEGORY", "SEASON_ID", comboBoxCatSeasonID);
            OleDbCommand cmd = new OleDbCommand("INSERT INTO CATEGORY (CAT_ID, CAT_NAME, SHORT_NAME, STOCK_TYPE, SEASON_ID, MISC_INFO)"
                              + "VALUES(category_seq.nextval,?,?,?,?,?)", conn);

            //cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxCatID.Text; I replaced it with sequence 
            
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxCatName.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxCatShortName.Text;

            try
            {

                if (radioSeasonal.Checked)
                {
                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = "yes";
                }
                else
                {
                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = "no";
                }

                cmd.Parameters.Add("?", OleDbType.VarChar).Value = comboBoxCatSeasonID.SelectedItem.ToString();
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxMiscInfo.Text;

                //Run the Query and display message.
                DialogResult ins = MessageBox.Show("Do you want to insert new Product Record into Database?", "Insert Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (ins == DialogResult.OK)
                {
                    ExecMyQuery(cmd, "New data is successfully inserted");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The Category ID is duplicated. Please enter the other Category ID.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBoxCatID.Text = "";
                textBoxCatID.Focus();
            }





        }


        //Delete the data from the database chosen
        private void buttonCatDelete_Click(object sender, EventArgs e)
        {
            try
            {

                OleDbCommand cmd = new OleDbCommand("DELETE FROM CATEGORY WHERE CAT_ID=?", conn);
                cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxCatID.Text;
                //Run the Query and display message.
                DialogResult ins = MessageBox.Show("Do you really want to delete the selected Product Record from Database?", "Delete Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (ins == DialogResult.OK)
                {
                    ExecMyQuery(cmd, "Data is successfully deleted");
                    ClearFields();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("This category is used in other table like product. Please make sure it first, and try it again.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

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

            FillDGV("", "");
            conn.Close();

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

        //Only get numbers with fixed digit from textbox 
        private void textBoxCatID_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 3;
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8)) && ((textBoxCatID.TextLength <= MaxDigit-1) || (e.KeyChar == 8)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if(e.Handled == true)
            {
                MessageBox.Show("Please enter only Number or fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }
        //Only get user input with fixed digits from textbox 
        private void textBoxCatName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 50;
            if ((textBoxCatName.TextLength <= MaxDigit - 1) || (e.KeyChar == 8)) 
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

        //Validate the input length of Textbox
        private void textBoxCatShortName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 30;
            if ((textBoxCatShortName.TextLength <= MaxDigit - 1) || (e.KeyChar == 8))
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
        /*
        //Only get user input with fixed digits from textbox 
        private void textBoxSeasonID_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 15;
            if ((textBoxSeasonID.TextLength <= MaxDigit - 1) || (e.KeyChar == 8))
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
        */
        //Check the input data
        private void textBoxMiscInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 50;
            if ((textBoxMiscInfo.TextLength <= MaxDigit - 1) || (e.KeyChar == 8))
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

        //When the selected Index is changed from the combobox, run ClearFields()
        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();
            int comboSelectedIndex = comboBoxCategory.SelectedIndex;

            //Get a value from the comboBox and put the field name for the FillDGV() 
            if (comboSelectedIndex == 0)
            {
                comboBoxCatSearchList.Items.Clear();
                comboBoxCatSearchList.Visible = true;
                populateComboBox("CATEGORY","CAT_ID",comboBoxCatSearchList);
                textCatKeyword.Visible = false;
                textCatKeyword.Text = comboBoxCatSearchList.Text;

                comboBoxCatSearchList.Focus();
                comboBoxCatSearchList.SelectedIndex = 0;

            }
            else if (comboSelectedIndex == 2)
            {
                comboBoxCatSearchList.Items.Clear();
                comboBoxCatSearchList.Visible = true;
                populateComboBox("CATEGORY", "STOCK_TYPE", comboBoxCatSearchList);
                textCatKeyword.Visible = false;
                textCatKeyword.Text = comboBoxCatSearchList.Text;
                comboBoxCatSearchList.Focus();
                comboBoxCatSearchList.SelectedIndex = 0;

            }            
            else
            {
                comboBoxCatSearchList.Visible = false;
                textCatKeyword.Visible = true;
            }

        }
        //Form Closed Event.
        private void formCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMaintainDB formMaintainDB = new formMaintainDB();
            this.Hide();
            formMaintainDB.Show();

        }

    }
}
