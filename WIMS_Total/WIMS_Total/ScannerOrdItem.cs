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
using ScannerMain;
using GlobalMethods;
using ManagerModifyItem;

namespace ScannerOrdItem
{
    public partial class formScannerOrdItem : Form
    {

        public formScannerOrdItem()
        {
            InitializeComponent();
            //Locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
        }


        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

        public int existingQOH;
        //public int ordindividualQTY = 0;
        public int ordCaseQTY = 0;
        public int newQOH; // newQOH - existingQOH;  number of QOH modification
        int minQTY = 0;
        int maxQTY = 0;
        int caseQTY = 0;
        string invid = "";

        private void formScannerOrdItem_Load(object sender, EventArgs e)
        {
            textBoxMKeyword.Enabled = false;

            // Displays user login information on the top of the Scanner Screen

            labelInfo.Text = GlobalMethods.GlobalMethods.USERFULLNAME + "  " + "User ID: " + GlobalMethods.GlobalMethods.USER_ID + " Location:" + GlobalMethods.GlobalMethods.USER_LOCATION_NAME;
            //panelMroughInfo.Visible = false;
            //panelMbottom.Visible = false;
            textBoxMKeyword.Text = ScannerMain.formScannerMain.searchedKeyword;

            displaySearchedInfo();
            existingQOH = Convert.ToInt32(textBoxMQOH.Text);
            textBoxOrdAmt.BackColor = Color.Yellow;
            labelDetailIntroOrd.Visible = false;
            textBoxOrdAmt.Focus();
        }


        //Display detail information when clicked
        public void displaySearchedInfo()
        {
            //To search when the enter is pressed in Search TExtbox
            string valueTosearchM = ScannerMain.formScannerMain.searchedKeyword;
            string BaseField = ScannerMain.formScannerMain.BaseField;


            //string BaseField = "P.BE_SKU";
            //if (valueTosearchM.Length == 12)
            //{
            //    BaseField = "P.SUP_ID";
            //}

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

                    // int existedQOH = Convert.ToInt32(textBoxMQOH.Text);
                    maxQTY = Convert.ToInt32(table2.Rows[0][7].ToString());
                    minQTY = Convert.ToInt32(table2.Rows[0][6].ToString());
                    caseQTY = Convert.ToInt32(table2.Rows[0][20].ToString());
                    invid = table2.Rows[0][0].ToString();

                }
                else
                {
                    panelMroughInfo.Visible = false;
                    MessageBox.Show("There is no Inventory. Please add Inventory first or try again.");
                    textBoxMKeyword.Focus();

                }
            }

        }




        //private void formScannerAdjust_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    this.Close();
        //    formScannerMain main = new formScannerMain();
        //    main.Show();
        //}


        //Close this form
        private void buttonBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //Display detail product information
        private void panelMroughInfo_Click_1(object sender, EventArgs e)
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
                   + "Minimum QTY: " + minQTY + "\n"
                   + "Maximum QTY: " + maxQTY + "\n"
                   + "Case Count : " + caseQTY + "\n"
                   + "Case Weight : " + table3.Rows[0][14].ToString() + "\n", "Detail Product Information");
        }

        //Add a scanned Item into temporary table (ADD_ORDER)
        private void buttonAddtoOrd_Click(object sender, EventArgs e)
        {

            int inputNum;
            if (textBoxOrdAmt.Text == "" || !Int32.TryParse(textBoxOrdAmt.Text, out inputNum) || Convert.ToInt32(textBoxOrdAmt.Text) < 0)
            {
                MessageBox.Show("Please enter the Positive number of amount to Order.", "Input Require");
                textBoxOrdAmt.Focus();

            }
            else
            {
                ordCaseQTY = Convert.ToInt32(textBoxOrdAmt.Text);
                string addMgrList = "INSERT INTO ADD_ORDER (ADD_ORDER_ID, INV_ID, REQ_QTY, USER_ID) "
                  + "VALUES(ADD_ORDER_ID_SEQ.nextVal, ?, " + ordCaseQTY + ", " + GlobalMethods.GlobalMethods.USER_ID + ")";

                OleDbCommand cmdAddMgrList = new OleDbCommand(addMgrList, conn);
                cmdAddMgrList.Parameters.Add("?", OleDbType.VarChar).Value = invid;

                //Run the Query and display message.
                DialogResult ins = MessageBox.Show("Do you want to add an Item to Order?", "Add Item to Order", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (ins == DialogResult.OK)
                {
                    conn.Open();
                    GlobalMethods.GlobalMethods.ExecMyQuery(cmdAddMgrList, "New data is successfully inserted");
                    //GlobalMethods.GlobalMethods.storeAudit("", "", "CREATE");
                    conn.Close();
                }
                this.Close();
                //formMgrModifyItem.ActiveForm.Activate();
                formScannerMain.ActiveForm.Activate();
            }



        }
        //Calculate value of total units ordered
        private void textBoxOrdAmt_MouseClick(object sender, MouseEventArgs e)
        {
            labelDetailIntroOrd.Visible = true;
            labelDetailIntroOrd.Text = caseQTY + " Units / Case";
        }


    }
}
