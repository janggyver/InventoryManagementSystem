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
using System.Globalization; // To display DateTime
using BECategory;
using BESeason;
using BEProducts;
using BEInventory;
using BELogIn;
using BENewMainMenu;

namespace BESeason
{
    public partial class formSeason : Form
    {
        public formSeason()
        {
            InitializeComponent();

            //Locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
            buttonSeasonDelete.Enabled = false;
            buttonSeasonUpdate.Enabled = false;
            buttonSeasonDelete.BackColor = Color.Gray;
            buttonForcedEdit.Visible = false;
            buttonForcedUpdate.Visible = false;
        }
        //Create Connection Object for database
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Date Source=XE; User ID=Bullseye;Password=1111;Unicode=True");

        //Populate data into the datagrdiview when the form loaded and display tooltips when the mouse is on
        private void formSeason_Load(object sender, EventArgs e)
        {
            FillSeasonDGV("", "");


            //MessageBox.Show(dateTimePickerSeasonEnd.Value.ToString());
            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;

            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.buttonSeasonSearch, "Click to search with a keyword");
            toolTip1.SetToolTip(this.textSeasonKeyword, "Type any keyword to search");
            toolTip1.SetToolTip(this.comboSeason, "Choose to set a filter to search by");
            toolTip1.SetToolTip(this.buttonSeasonClear, "Clear the data displayed above");
            toolTip1.SetToolTip(this.buttonSeasonUpdate, "Update the data");
            toolTip1.SetToolTip(this.buttonSeasonInsert, "Insert new data");
            toolTip1.SetToolTip(this.buttonSeasonDelete, "Delete data. Be Careful please.");
            ClearFields();
            comboSeason.SelectedIndex = 2;
        }

        //Fill data into DataGridView
        public void FillSeasonDGV(string valueToSearch1, string valueToSearch2)
        {

            string comboAnyKeySelected = (string)comboSeason.SelectedIndex.ToString();
            int searchResult;


            if ((valueToSearch1 == "") || (comboAnyKeySelected == "Any Values"))
            {
                //OleDbCommand cmd = new OleDbCommand("select * from CATEGORY WHERE concat(CAT_ID, lower(CAT_NAME),SEASON_ID) LIKE '%" + valueToSearch2.ToLower() + "%'", conn);

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM SEASON WHERE lower(SEASON_ID) LIKE '%" + valueToSearch2.ToLower() + "%'"
                        + " OR lower(SEASON_DESC) LIKE '%" + valueToSearch2.ToLower() + "%'  ORDER BY lower(SEASON_ID) ASC"
                        , conn);

                OleDbDataAdapter oda = new OleDbDataAdapter(cmd);

                DataTable table = new DataTable();
                oda.Fill(table);

                //Fill Datagridview with the DataTable
                dataGridViewSeason.DataSource = table;

            }
            else
            {
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM SEASON WHERE lower(" + valueToSearch1 + ") LIKE '%" + valueToSearch2.ToLower() + "%' ORDER BY lower(SEASON_ID) ASC", conn);
                OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
                DataTable table = new DataTable();
                oda.Fill(table);

                //Fill Datagridview with the DataTable
                dataGridViewSeason.DataSource = table;
            }

            //To set some properties for DataGridView
            dataGridViewSeason.RowTemplate.Height = 30;
            dataGridViewSeason.AllowUserToAddRows = false;
            dataGridViewSeason.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //display the number of rows searched(or populated) in dataGridView
            searchResult = (int)dataGridViewSeason.RowCount;
            labelSearchResult.Text = searchResult.ToString();
            //comboSeason.SelectedIndex = 0;

        }

        //Populate data into controls by clicking the datagridview line
        private void dataGridViewSeason_Click(object sender, EventArgs e)
        {
            textBoxSeasonID.Text = dataGridViewSeason.CurrentRow.Cells[0].Value.ToString();
            textBoxSeasonDesc.Text = dataGridViewSeason.CurrentRow.Cells[1].Value.ToString();
            dateTimePickerSeasonStart.Value = (DateTime)dataGridViewSeason.CurrentRow.Cells[2].Value;
            dateTimePickerSeasonEnd.Value = (DateTime)dataGridViewSeason.CurrentRow.Cells[3].Value;
            textBoxSeasonID.ReadOnly = true;
            buttonSeasonInsert.Enabled = false;
            buttonSeasonDelete.Enabled = true;
            buttonSeasonUpdate.Enabled = true;
            buttonSeasonDelete.BackColor = Color.Red;
            //buttonSeasonUpdate.BackColor = Color.SkyBlue;


            if ((dateTimePickerSeasonStart.Value < System.DateTime.Today) && (dateTimePickerSeasonEnd.Value >= System.DateTime.Today))
            {
                dateTimePickerSeasonStart.Enabled = false;
                dateTimePickerSeasonEnd.Enabled = true;
                buttonForcedEdit.Visible = false;

            }
            else if ((dateTimePickerSeasonStart.Value >= System.DateTime.Today) && (dateTimePickerSeasonEnd.Value < System.DateTime.Today)){
                dateTimePickerSeasonStart.Enabled = true;
                dateTimePickerSeasonEnd.Enabled = false;
                buttonForcedEdit.Visible = false;
            }
            
            else if ((dateTimePickerSeasonStart.Value < System.DateTime.Today) && (dateTimePickerSeasonEnd.Value < System.DateTime.Today))
            {
                buttonForcedEdit.Visible =true;
                dateTimePickerSeasonStart.Enabled = false;
                dateTimePickerSeasonEnd.Enabled = false;
              

            }
            else{
                dateTimePickerSeasonStart.Enabled = true;
                dateTimePickerSeasonEnd.Enabled = true;
            }


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
        //Initialize all controls as default
        private void buttonSeasonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // Clear all fields and uncheck radio buttons
        public void ClearFields()
        {
            textBoxSeasonID.Text = "";
            textBoxSeasonDesc.Text = "";
            dateTimePickerSeasonStart.Value = (DateTime)System.DateTime.Today;
            dateTimePickerSeasonEnd.Value = (DateTime)System.DateTime.Today;
            textBoxSeasonID.ReadOnly = false;
            textSeasonKeyword.Text = "";
            textSeasonKeyword.Focus();
            buttonSeasonInsert.Enabled = true;
            buttonSeasonDelete.BackColor = Color.Gray;
            buttonSeasonDelete.Enabled = false;
            buttonSeasonUpdate.Enabled = false;
            comboBoxSeasonSearchList.Visible = false;
            textSeasonKeyword.Visible = true;
            dateTimePickerSeasonStart.Enabled = true;
            dateTimePickerSeasonEnd.Enabled = true;
            buttonForcedUpdate.Visible = false;
            buttonForcedEdit.Visible = false;
         

        }


        //Update Season information
        private void buttonSeasonUpdate_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("UPDATE SEASON SET SEASON_DESC=?, SEASON_START=?, SEASON_END=? WHERE SEASON_ID=?", conn);

            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxSeasonDesc.Text;
            cmd.Parameters.Add("?", OleDbType.Date).Value = dateTimePickerSeasonStart.Value;
            cmd.Parameters.Add("?", OleDbType.Date).Value = dateTimePickerSeasonEnd.Value;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxSeasonID.Text;

            try
            {
                 if(dateTimePickerSeasonStart.Value > dateTimePickerSeasonEnd.Value)
                {
               MessageBox.Show("The Season End Date should be future including today or Season Start Date. Please enter the new Season date.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               dateTimePickerSeasonEnd.Value = (DateTime)dateTimePickerSeasonStart.Value;
               dateTimePickerSeasonEnd.Focus();
                }

                else
                {
                    //Run the Query and display message.
                    DialogResult upd = MessageBox.Show("Do you want to update this Record with new value into Database?", "Update Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (upd == DialogResult.OK)
                    {
                        ExecMyQuery(cmd, "New data is successfully updated");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected Error occurred. Please try again or ask Administrator.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBoxSeasonID.Text = "";
                textBoxSeasonID.Focus();
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

            FillSeasonDGV("", "");
            conn.Close();

        }

        //Insert Season data
        private void buttonSeasonInsert_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO SEASON (SEASON_ID, SEASON_DESC, SEASON_START, SEASON_END) "
                                       + "VALUES(?,?,?,?)", conn);
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxSeasonID.Text;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxSeasonDesc.Text;
            cmd.Parameters.Add("?", OleDbType.Date).Value = dateTimePickerSeasonStart.Value;
            cmd.Parameters.Add("?", OleDbType.Date).Value = dateTimePickerSeasonEnd.Value;

            try
            {
                if (string.IsNullOrWhiteSpace(textBoxSeasonID.Text))
                {
                    MessageBox.Show("The Season ID is not allowed left empty. Please try again.", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBoxSeasonID.Focus();
                }


                else if (seasonDateValidation()){
                     //Run the Query and display message.
                    DialogResult ins = MessageBox.Show("Do you want to insert new Product Record into Database?", "Insert Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (ins == DialogResult.OK)
                    {
                        ExecMyQuery(cmd, "New data is successfully inserted");
                    }
                }

            }
            catch (OleDbException ex)
            {
                switch (ex.ErrorCode)
                {

                    case -2147217873:
                        {
                            
                            MessageBox.Show("The Seoson ID is duplicated. Please enter the other Season ID.", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            conn.Close();
                            break;
                        }
                }
             //   MessageBox.Show("The Seoson ID is duplicated. Please enter the other Season ID.", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBoxSeasonID.Text="";
                textBoxSeasonID.Focus();
            }

        }

        //delete a record from a database table
        private void buttonSeasonDelete_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM SEASON WHERE SEASON_ID=?", conn);
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxSeasonID.Text;
            try
            {
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
                MessageBox.Show("Unexpected Error occurred. Please try again or ask Administrator.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBoxSeasonID.Text = "";
                textBoxSeasonID.Focus();
            }

        }

        //Check the input data
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

        //Check the input data
        private void textBoxSeasonDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 15;
            if ((textBoxSeasonDesc.TextLength <= MaxDigit - 1) || (e.KeyChar == 8))
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

        //Search data from the database based on the filter(from the combobox) and keywords(taken from the user)
        private void buttonSeasonSearch_Click(object sender, EventArgs e)
        {
            string comboSelectedKeyword1 = (string)comboSeason.SelectedIndex.ToString();
            string Keyword2 = textSeasonKeyword.Text;

            //Get a value from the comboBox and put the field name for the FillDGV() 
            if (comboSelectedKeyword1 == "0")
            {
                comboSelectedKeyword1 = "SEASON_ID";
            }
            else if (comboSelectedKeyword1 == "1")
            {
                comboSelectedKeyword1 = "SEASON_DESC";

            }

            else
            {
                comboSelectedKeyword1 = "";
            }

            if (comboBoxSeasonSearchList.Visible)
            {
                Keyword2 = comboBoxSeasonSearchList.Text;
            }
            else
            {
                Keyword2 = textSeasonKeyword.Text;
            }
            


            FillSeasonDGV(comboSelectedKeyword1, Keyword2);


        }

        //Season Rule Validation
        public bool seasonDateValidation()
        {
           if (dateTimePickerSeasonStart.Value < System.DateTime.Today)
           {
               MessageBox.Show("The Season Start Date should be future including today. Please enter the other Season ID.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               dateTimePickerSeasonStart.Value = (DateTime)System.DateTime.Today;
               dateTimePickerSeasonEnd.Value = (DateTime)System.DateTime.Today;
               dateTimePickerSeasonStart.Focus();
               return false;
           }
           else if (dateTimePickerSeasonStart.Value > dateTimePickerSeasonEnd.Value)
           {
               MessageBox.Show("The Season End Date should be future including today or Season Start Date. Please enter the new Season date.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               dateTimePickerSeasonEnd.Value = (DateTime)dateTimePickerSeasonStart.Value;
               dateTimePickerSeasonEnd.Focus();
               return false;
           }

           else
           {
               return true;
           }
          
        }

        /*
        //Season ID duplicated Validation
        public bool seasonIDValidation()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT count(SEASON_ID) FROM SEASON where SEASON_ID=?", conn);
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxSeasonID.Text.ToLower();
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            
            if (oda.ToString() == "1")
            {

            }
            DataTable table = new DataTable();
            oda.Fill(table);

            ExecMyQuery(cmd, "New data is successfully updated");
            return true;
        }

        */
        //Declare variables to recognize the user input
        private bool firstInput = true; // variable to use when a user typed a letter in a textbox to search
        private void textSeasonKeyword_TextChanged(object sender, EventArgs e)
        {
            //Clear the text in the textBox when a user type something inside
            if (firstInput)
            {
                textSeasonKeyword.Clear();

                firstInput = false;
            }
        }

        //Set teh value and do basic functions
        private void comboSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();
            int comboSelectedIndex = comboSeason.SelectedIndex;

            //Get a value from the comboBox and put the field name for the FillDGV() 
            if (comboSelectedIndex == 0)
            {
                comboBoxSeasonSearchList.Items.Clear();
                comboBoxSeasonSearchList.Visible = true;
                populateComboBox("SEASON", "SEASON_ID", comboBoxSeasonSearchList);
                textSeasonKeyword.Visible = false;
                textSeasonKeyword.Text = comboBoxSeasonSearchList.Text;

                comboBoxSeasonSearchList.Focus();
                comboBoxSeasonSearchList.SelectedIndex = 0;

            }
            /*
        else if (comboSelectedIndex == 2)
        {
            comboBoxSeasonSearchList.Items.Clear();
            comboBoxSeasonSearchList.Visible = true;
            populateComboBox("CATEGORY", "STOCK_TYPE", comboBoxSeasonSearchList);
            textSeasonKeyword.Visible = false;
            textSeasonKeyword.Text = comboBoxSeasonSearchList.Text;
            comboBoxSeasonSearchList.Focus();
            comboBoxSeasonSearchList.SelectedIndex = 0;
       
        }
                 */
            else
            {
                comboBoxSeasonSearchList.Visible = false;
                textSeasonKeyword.Visible = true;

            }
        }

        //When an Adminstrator wants to modify data, this button makes to update by force with Forced Update button Click
        private void buttonForcedEdit_Click(object sender, EventArgs e)
        {

            buttonForcedUpdate.Visible = true;
            buttonForcedEdit.Visible = false;
            dateTimePickerSeasonStart.Enabled = true;
            dateTimePickerSeasonEnd.Enabled = true;


    }
        //Update data by force
        private void buttonForcedUpdate_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("UPDATE SEASON SET SEASON_DESC=?, SEASON_START=?, SEASON_END=? WHERE SEASON_ID=?", conn);

            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxSeasonDesc.Text;
            cmd.Parameters.Add("?", OleDbType.Date).Value = (DateTime)dateTimePickerSeasonStart.Value;
            cmd.Parameters.Add("?", OleDbType.Date).Value = (DateTime)dateTimePickerSeasonEnd.Value;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxSeasonID.Text;


            try
            {
                
                if (dateTimePickerSeasonStart.Value > dateTimePickerSeasonEnd.Value)
                {
                    MessageBox.Show("The Season End Date should be future than a Season Start Date. Please enter the new Season date.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    dateTimePickerSeasonEnd.Focus();
                }

                else
                {
                    //Run the Query and display message.
                    DialogResult upd = MessageBox.Show("Do you want to update this Record with new value into Database by force?", "Update Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (upd == DialogResult.OK)
                    {
                        ExecMyQuery(cmd, "Data is successfully updated by force.");
                        buttonForcedUpdate.Visible = false;
                        buttonForcedEdit.Visible = false;
                        dateTimePickerSeasonStart.Enabled = true;
                        dateTimePickerSeasonEnd.Enabled = true;
                        ClearFields();
                    }
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected Error occurred. Please ask Administrator.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBoxSeasonID.Text = "";
                textBoxSeasonID.Focus();
            }
        }

        //Formclosed Event hanadling
        private void formSeason_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMaintainDB formMaintainDB = new formMaintainDB();
            formMaintainDB.Show();
            this.Hide();
        }

        }
}
