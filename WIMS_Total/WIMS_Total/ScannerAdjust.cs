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
using ScannerMain;

namespace ScannerAdjust
{
    public partial class formScannerAdjust : Form
    {


        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

        public int existingQOH;
        public int adjQTY = 0;
        public int newQOH; // newQOH - existingQOH;  number of QOH modification




        public formScannerAdjust()
        {
            InitializeComponent();
            //Locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void ScannerAdjust_Load(object sender, EventArgs e)
        {

            radioButtonLost.Select();
            textBoxMKeyword.Enabled = false;

            // Displays user login information on the top of the Scanner Screen

            labelInfo.Text = GlobalMethods.GlobalMethods.USERFULLNAME + "  " + "User ID: " + GlobalMethods.GlobalMethods.USER_ID + " Location:" + GlobalMethods.GlobalMethods.USER_LOCATION_NAME;
            //panelMroughInfo.Visible = false;
            //panelMbottom.Visible = false;
            textBoxMKeyword.Text = ScannerMain.formScannerMain.searchedKeyword;
            textBoxAdjAmt.BackColor = Color.Yellow;
            displaySearchedInfo();
            existingQOH = Convert.ToInt32(textBoxMQOH.Text);
            textBoxAdjAmt.Focus();
        }

        //Display searched Information
        public void displaySearchedInfo()
        {
            //To search when the enter is pressed in Search TExtbox
            string valueTosearchM = ScannerMain.formScannerMain.searchedKeyword;


            string BaseField = "P.BE_SKU";
            if (valueTosearchM.Length == 12)
            {
                BaseField = "P.SUP_ID";
            }

            //Check whetehr product exists or not
            string ToSearchProductSQLInScanner = "SELECT BE_SKU, SUP_SKU "
              + "FROM PRODUCT P"
              + " WHERE " + BaseField + " = " + valueTosearchM + "";

            OleDbCommand cmd = new OleDbCommand(ToSearchProductSQLInScanner, conn);
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataTable table = new DataTable();
            oda.Fill(table);

            if (table.Rows.Count == 0)
            {
                panelMroughInfo.Visible = false;
                panelMbottom.Visible = false;

                MessageBox.Show("There is no Product. Please add Product first or try again.");
                textBoxMKeyword.Focus();


            }
            else
            {
                string ToSearchSQLInScanner = "SELECT INV_ID, I.PROD_ID, I.LOCATION, SHELF_LOC, QOH, TRANSIENT_QTY, MIN_QTY, MAX_QTY,"
                        + "BE_SKU, SUP_SKU, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, PROD_WEIGHT, CAT_ID,"
                        + "PRICE_PURCH, PRICE_RETAIL, PRICE_PREV, CASE_COUNT, CASE_WEIGHT, P.SUP_ID, L.LOC_NAME "
                        + "FROM INVENTORY I, PRODUCT P, LOCATION L"
                        + " WHERE P.PROD_ID = I.PROD_ID AND I.LOCATION = L.LOCATION AND " + BaseField + " = " + valueTosearchM + " AND "
                        + "I.LOCATION =" + GlobalMethods.GlobalMethods.USERLOCATION + "";

                // MessageBox.Show(ToSearchSQLInScanner);
                OleDbCommand cmd2 = new OleDbCommand(ToSearchSQLInScanner, conn);
                OleDbDataAdapter oda2 = new OleDbDataAdapter(cmd2);
                DataTable table2 = new DataTable();
                oda2.Fill(table2);

                // MessageBox.Show(table2.Rows.Count.ToString());

                if (table2.Rows.Count != 0)
                {

                    //Display basic search results
                    //panelMroughInfo.Enabled = false;
                    panelMroughInfo.Visible = true;
                    textBoxMInvID.Text = table2.Rows[0][0].ToString();
                    textBoxMProdID.Text = table2.Rows[0][1].ToString();
                    textBoxMBE_SKU.Text = table2.Rows[0][8].ToString();
                    textBoxMSUP_SKU.Text = table2.Rows[0][9].ToString();
                    textBoxMProdName.Text = table2.Rows[0][10].ToString();
                    comboBoxMShelfLoc.Text = table2.Rows[0][3].ToString();
                    textBoxMQOH.Text = table2.Rows[0][4].ToString();
                    textBoxMInvID.Enabled = false;
                    textBoxMProdID.Enabled = false;
                    textBoxMBE_SKU.Enabled = false;
                    textBoxMSUP_SKU.Enabled = false;
                    textBoxMProdName.Enabled = false;
                    comboBoxMShelfLoc.Enabled = false;
                    textBoxMQOH.Enabled = false;
                    panelMbottom.Visible = true;
                   // int existedQOH = Convert.ToInt32(textBoxMQOH.Text);


                }
                else
                {
                    panelMroughInfo.Visible = false;
                    panelMbottom.Visible = false;
                    MessageBox.Show("There is no Inventory. Please add Inventory first or try again.");
                    textBoxMKeyword.Focus();

                }
            }

        }


        //Display detail information
        private void panelMroughInfo_Click(object sender, EventArgs e)
        {
            string ToSearchSQLInScanner = "SELECT PROD_NAME, TRANSIENT_QTY, MIN_QTY, MAX_QTY,"
         + "PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, PROD_WEIGHT, CAT_ID,"
         + "PRICE_PURCH, PRICE_RETAIL, PRICE_PREV, CASE_COUNT, CASE_WEIGHT "
         + "FROM PRODUCT P, INVENTORY I"
         + " WHERE P.PROD_ID = I.PROD_ID AND P.PROD_ID = " + textBoxMProdID.Text + "";

            OleDbCommand cmd3 = new OleDbCommand(ToSearchSQLInScanner, conn);
            OleDbDataAdapter oda3 = new OleDbDataAdapter(cmd3);
            DataTable table3 = new DataTable();
            oda3.Fill(table3);
            MessageBox.Show("Product Name: " + table3.Rows[0][0].ToString() + "\n"
                   + "Transient QTY: " + table3.Rows[0][1].ToString() + "\n"
                   + "Minimum QTY: " + table3.Rows[0][2].ToString() + "\n"
                   + "Maximum QTY: " + table3.Rows[0][3].ToString() + "\n"
                   + "Case Count : " + table3.Rows[0][13].ToString() + "\n"
                   + "Case Weight : " + table3.Rows[0][14].ToString() + "\n", "Detail Product Information");

        }


        //private void formScannerAdjust_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    this.Close();
        //    formScannerMain main = new formScannerMain();
        //    main.Show();
        //}

        //Go back to previous screen
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        //Confirm Adjustment
        private void buttonMAdjustConfirm_Click(object sender, EventArgs e)
        {
            conn.Open();

            int adjQTY = Convert.ToInt32(textBoxAdjAmt.Text);
            newQOH = existingQOH-adjQTY;
            string toAddQOHTable = "INSERT INTO ADJUSTMENT (ADJ_ID, INV_ID, QTY, ADJUST_TYPE, APPROVED_BY, USER_ID, ADJ_DATE)"
        + "VALUES(ADJ_ID_SEQ.nextval, ?, ?, ?, ?, ?, ?)";

            OleDbCommand cmdAdd = new OleDbCommand(toAddQOHTable, conn);
            //allocate appropriate entry for controls
            cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxMInvID.Text;
            cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = Math.Abs(adjQTY);
            string radioValue;
            if(radioButtonLost.Checked)
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
            cmdAdd.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Today;

            //Run the Query and display message.
            GlobalMethods.GlobalMethods.ExecMyQuery(cmdAdd, "Log data for Audit stored.");
            //panelMroughInfo.Visible = false;
            //panelMbottom.Visible = false;
            //textBoxMKeyword.Focus();


            //to make entry of QOH
            string toUpdaeAfterAdjust = "UPDATE INVENTORY SET QOH =? "
                    + " WHERE INV_ID = " + textBoxMInvID.Text + "";

            OleDbCommand cmdUpdateQOH = new OleDbCommand(toUpdaeAfterAdjust, conn);
            cmdUpdateQOH.Parameters.Add("?", OleDbType.VarChar).Value = newQOH;
            GlobalMethods.GlobalMethods.ExecMyQuery(cmdUpdateQOH, "Product QOH has updated as well.");
            
            conn.Close();
        }

        public int newQTY { get; set; }

        //Adjustment QTY is allowed on positive 6 digits number 
        //Only get numbers with fixed digit from textbox 
        private void textBoxAdjAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 6;
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8)) && ((textBoxAdjAmt.TextLength <= MaxDigit - 1) || (e.KeyChar == 8)))
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
    }
}
