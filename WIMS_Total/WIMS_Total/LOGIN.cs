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
using System.Data.OleDb;
using System.Diagnostics;
using BECategory;
using BESeason;
using BEProducts;
using BEInventory;
using BENewMainMenu;
using InventoryP3;


namespace LOGIN
{
    public partial class FormLOGIN : Form
    {
        public FormLOGIN()
        {
            InitializeComponent();
            //locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormLOGIN_Load(object sender, EventArgs e)
        {
            textBoxUserID.Focus();
        }

        public static bool loggedIn = false;


        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

 
        private void buttonUserLogIn_Click(object sender, EventArgs e)
        {
            loggedIn = GlobalMethods.GlobalMethods.checkLogIn(textBoxUserID.Text, textBoxUserPWD.Text);
            if (loggedIn)
            {
                panelLogInPart_D.Visible = false;
                MessageBox.Show("Welcome " + GlobalMethods.GlobalMethods.USERFULLNAME + "! ");

                formMaintainDB formMaintainDB = new formMaintainDB();
                formMaintainDB.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Sorry. Log In information doesn't match. Please try again.", "Log In Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserPWD.Text = "";
                textBoxUserID.Focus();
            }
        }

        


       //// public static string GLOBAL_USER_ID;
       // public static string DESKTOPUSER_ID;
       // public static string USERFULLNAME;
       // public static string USERLOCATION;

       // //Create the database connection
       // OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

       // private void FormUserLogIn_Load(object sender, EventArgs e)
       // {
       //     textBoxUserPWD.Focus();
       //     panelLogInPart_D.Visible = true;
       //     panelGoToMaintainScreen.Visible = false;
       // }


       // private bool checkLogIn(string id, string pwd)
       // {
       //     string commUsers = "SELECT USER_ID, USER_PASSWORD, USER_FNAME, USER_LNAME, LOCATION FROM USERS";
       //     OleDbCommand cmd = new OleDbCommand(commUsers, conn);
       //     OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
       //     DataTable table = new DataTable();
       //     oda.Fill(table);
       //     string userName = "";
            
       //     int i = table.Rows.Count;
       //     for (int j = 0; j < i; j++)
       //     {
       //         if ((id == table.Rows[j][0].ToString()) && (pwd == table.Rows[j][1].ToString()))
       //         {
       //             userName = table.Rows[j][2].ToString() + " " + table.Rows[j][3].ToString();
       //             USERFULLNAME = userName;
       //             USER_ID = table.Rows[j][0].ToString();
       //             USERLOCATION = table.Rows[j][4].ToString();


       //             return true;

       //         }

       //     }
       //     return false;
       // }

       // //Method to execute query and display message, lists after running
       // public void ExecMyQuery(OleDbCommand ocomd, String myMsg)
       // {
       //     conn.Open();
       //     if (ocomd.ExecuteNonQuery() == 1)
       //     {
       //         MessageBox.Show(myMsg);
       //     }
       //     else
       //     {
       //         MessageBox.Show("Query Not Executed");
       //     }


       //     conn.Close();
       // }

        //private void buttonUserLogIn_Click(object sender, EventArgs e)
        //{
        //    bool loginSucceed = checkLogIn(textBoxUserID.Text, textBoxUserPWD.Text);
        //    if (loginSucceed)
        //    {

        //        //MessageBox.Show("Hello " + userFullName + " !! \nWelcome to BE WIMS!" + "\nUser ID " + USER_ID, "logged in successfully.", MessageBoxButtons.OK, MessageBoxIcon.None);
        //        labelUserFullNameWelcome.Text = "Hello " + USERFULLNAME + "\n\nUser ID: " +USER_ID +"    Department: " + USERLOCATION;
        //        panelLogInPart_D.Visible = false;
        //        panelGoToMaintainScreen.Visible = true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Sorry. Log In information doesn't match. Please try again.", "Log In Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        textBoxUserPWD.Text = "";
        //        textBoxUserID.Focus();
        //    }
                
        //}


        //This button is to demonstrate Mobile Scanner Functions.
        private void buttonScannerDemo_Click(object sender, EventArgs e)
        {
            //formScannerMain formScannerMain = new formScannerMain();
            //formScannerMain.Show();
            formScannerLogin formScannerLogin = new formScannerLogin();
            formScannerLogin.Show();
            this.Hide();

        }


    }
}
