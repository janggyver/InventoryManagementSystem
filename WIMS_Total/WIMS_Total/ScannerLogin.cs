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
using InventoryP3;
using GlobalMethods;
using ScannerMain;
using System.Diagnostics.Tracing;


namespace InventoryP3
{
    public partial class formScannerLogin : Form
    {

        // public static string GLOBAL_USER_ID;
        //public static string M_USER_ID;
        //public static string M_USERFULLNAME;
        //public static string M_USERLOCATION;

        public static bool loggedIn = false;


        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

        public formScannerLogin()
        {
            InitializeComponent();

            //Locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void formScannerLogin_Load(object sender, EventArgs e)
        {
            textBoxMUserID.Focus();
        }

        private void buttonUserLogIn_Click(object sender, EventArgs e)
        {
            loggedIn = GlobalMethods.GlobalMethods.checkLogIn(textBoxMUserID.Text, textBoxMUserPWD.Text);
            if (loggedIn)
            {
                panelLoginPart.Visible = false;
                MessageBox.Show("Welcome " + GlobalMethods.GlobalMethods.USERFULLNAME + "! ");

                formScannerMain formScannerMain = new formScannerMain();
                formScannerMain.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Sorry. Log In information doesn't match. Please try again.", "Log In Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMUserPWD.Text = "";
                textBoxMUserID.Focus();
            }
        }



    }
}
