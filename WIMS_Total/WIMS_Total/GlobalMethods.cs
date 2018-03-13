using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Diagnostics;
using BECategory;
using BESeason;
//using BEProducts;
using BEInventory;
using BENewMainMenu;


namespace GlobalMethods
{
    class GlobalMethods
    {
        public static string USER_ID;
        public static string USERFULLNAME;
        public static string USERLOCATION;
        public static string USER_LOCATION_NAME;
        public static string USER_ACCESS_LEVEL;
        public static string VALUETOSEARCH1KEYWORD;
        public static string VALUETOSEARCH2KEYWORD;
        public static string PROD_ID = null;
        //Create the database connection
        static OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

        //Check Login
        public static bool checkLogIn(string id, string pwd)
        {
            string commUsers = "SELECT USER_ID, USER_PASSWORD, USER_FNAME, USER_LNAME, L.LOCATION, L.LOC_NAME, U.ACCESS_LEVEL FROM USERS U, LOCATION L"
                +" WHERE L.LOCATION = U.LOCATION";
            OleDbCommand cmd = new OleDbCommand(commUsers, conn);
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataTable table = new DataTable();
            oda.Fill(table);
            string userName = "";

            int i = table.Rows.Count;
            for (int j = 0; j < i; j++)
            {
                if ((id == table.Rows[j][0].ToString()) && (pwd == table.Rows[j][1].ToString()))
                {
                    userName = table.Rows[j][2].ToString() + " " + table.Rows[j][3].ToString();
                    USERFULLNAME = userName;
                    USER_ID = table.Rows[j][0].ToString();
                    USERLOCATION = table.Rows[j][4].ToString();
                    USER_LOCATION_NAME = table.Rows[j][5].ToString();
                    USER_ACCESS_LEVEL = table.Rows[j][6].ToString();


                    return true;

                }

            }
            return false;
        }



        //Method to execute query and display message, lists after running
        public static void ExecMyQuery(OleDbCommand ocomd, String myMsg)
        {

            if (ocomd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(myMsg);
            }
            else
            {
                MessageBox.Show("Query Not Executed");
            }

        }

        // Method to check the duplication of inventory within 1 location
        //incloming parameters: location, product id, user_id
        //respoinsibilities: check the location first and check the duplication of each location
        //returns: boolean
        public bool checkInvDuplication(string location, string productid)
        {
            bool isDuplicated = false;

            string dupCheck = "SELECT COUNT(*)" 
                    + " FROM INVENTORY I, LOCATION L, PRODUCT P"
                    + " WHERE I.PROD_ID = P.PROD_ID AND I.LOCATION = L.LOCATION";
            OleDbCommand cmd = new OleDbCommand(dupCheck, conn);
            
            int resultInvCheck = cmd.ExecuteNonQuery();
            if (resultInvCheck >= 1)
            {
                MessageBox.Show("Inventory is already added.", "Inventory Check", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                isDuplicated = true;
            }
            else
            {
                isDuplicated = false;
            }

            return isDuplicated;
        }
        
        //Store transaction to Adjustlist for Auditing
        public static void storeAudit(string inv_id, string qty, string action)
        {
            conn.Open();

            string auditString = "INSERT INTO ADJUSTMENT (ADJ_ID, INV_ID, QTY, ADJUST_TYPE, APPROVED_BY, USER_ID, ADJ_DATE)"
        + "VALUES(ADJ_ID_SEQ.nextval, ?, ?, ?, ?, ?, ?)";

            OleDbCommand cmdAuditAdd = new OleDbCommand(auditString, conn);
            //allocate appropriate entry for controls
            cmdAuditAdd.Parameters.Add("?", OleDbType.VarChar).Value = inv_id;
            cmdAuditAdd.Parameters.Add("?", OleDbType.VarChar).Value = qty;

            cmdAuditAdd.Parameters.Add("?", OleDbType.VarChar).Value = action;
            cmdAuditAdd.Parameters.Add("?", OleDbType.VarChar).Value = USERFULLNAME;
            cmdAuditAdd.Parameters.Add("?", OleDbType.VarChar).Value = USER_ID;
            cmdAuditAdd.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now;


            //MessageBox.Show("실행 9");
            //Run the Query and display message.
            ExecMyQuery(cmdAuditAdd, "Log data for Audit stored.");

            conn.Close();
        }





        //To populate data(values) from the database just to select and prevent to edit.
        public static void populateInvComboBox(string tableName, string fieldName, ComboBox comboBoxName)
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

        /*This part is for checking the user input. For example, if a textbox requires only positive number, it is called and return message.
         * 
         * */

         //1. Only get integer numbers without decimal from textbox

        public static void validNumberWithoutDecimal_KeyPress(TextBox sender, KeyPressEventArgs e)
        {


            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8)) || (e.KeyChar == 7)) // it allows only number, delete and backspacce key
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {
                MessageBox.Show("Please enter only Valid Number or fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }

        //2. Only get double numbers with decimal from textbox


        public static void validNumberWithDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8)) || (e.KeyChar == 7) || (e.KeyChar == 46)) // it allows only number, dot(.), delete and backspacce key
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }

            if (e.Handled == true)
            {

                MessageBox.Show("Please enter only Valid Number or fixed digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
            }
        }

    }
}
