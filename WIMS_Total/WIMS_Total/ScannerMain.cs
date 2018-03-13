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
using ScannerAdjust;
using ScannerOrdItem;
using ManagerModifyItem;

namespace ScannerMain
{
    public partial class formScannerMain : Form
    {


        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

        public int existingQOH;
        public int newQOH;
        public int difference = 0; // newQOH - existingQOH;  number of QOH modification
        public static string searchedKeyword; // used in Adjust form to display detail information
        public static string valueTosearchM;
        public static string BaseField = "";
        public static int mgrOrdItemresultnum = 0;
        public formScannerMain()
        {
            InitializeComponent();
            
            //Locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
        }

        // Displays user login information on the top of the Scanner Screen
        private void formScannerMain_Load(object sender, EventArgs e)
        {
            textBoxMKeyword.Focus();
            labelInfo.Text = GlobalMethods.GlobalMethods.USERFULLNAME + "  " + "User ID: " + GlobalMethods.GlobalMethods.USER_ID + " Location:" + GlobalMethods.GlobalMethods.USER_LOCATION_NAME;
            panelMroughInfo.Visible = false;
            panelMbottom.Visible = false;
            buttonConfirmInv.Visible = false;
            panelMultiResult.Visible = false;
           

        }



        public void buttonMSearch_Click(object sender, EventArgs e)
        {
            //To search when the enter is pressed in Search TExtbox
             valueTosearchM = textBoxMKeyword.Text;
            //string BaseField = "";
            if (valueTosearchM == "")
            {
                MessageBox.Show("Please enter BE SKU or Supplier SKU.", "Input Error");
                textBoxMKeyword.Focus();
            }
            else if (valueTosearchM.Length > 12 || valueTosearchM.Length < 6)
            {
                MessageBox.Show("Please input 6 or 12 digis number.", "Input Digit Error");
                textBoxMBE_SKU.Focus();
            }

            else { 

                    if (valueTosearchM.Length == 12)
                    {
                        BaseField = "P.SUP_SKU";
                    }
                    else if(valueTosearchM.Length == 6){
                        BaseField = "P.BE_SKU";
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

                        buttonPerformInv.Visible = true;
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
                        if (table2.Rows.Count == 1)
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
                            buttonPerformInv.Enabled = true;
                            buttonPerformInv.Visible = true;
                            searchedKeyword = valueTosearchM;
                            existingQOH = Convert.ToInt32(textBoxMQOH.Text);
                        }
                        else if (table2.Rows.Count >= 2)
                        {
                            panelMultiResult.Visible = true;
                            GlobalMethods.GlobalMethods.populateInvComboBox("INVENTORY", "INV_ID", comboBoxMultipleResult);
                            comboBoxMultipleResult_SelectedIndexChanged(sender, e);

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
        }

        private void panelMroughInfo_Click(object sender, EventArgs e)
        {
            string ToSearchSQLInScanner = "SELECT PROD_NAME, TRANSIENT_QTY, MIN_QTY, MAX_QTY,"
                    + "PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, PROD_WEIGHT, CAT_ID,"
                    + "PRICE_PURCH, PRICE_RETAIL, PRICE_PREV, CASE_COUNT, CASE_WEIGHT, I.LOCATION "
                    + "FROM PRODUCT P, INVENTORY I"
                    + " WHERE P.PROD_ID = I.PROD_ID AND P.PROD_ID = " + textBoxMProdID.Text + "AND I.LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION +"";

            OleDbCommand cmd3 = new OleDbCommand(ToSearchSQLInScanner, conn);
            OleDbDataAdapter oda3 = new OleDbDataAdapter(cmd3);
            DataTable table3 = new DataTable();
            oda3.Fill(table3);
            MessageBox.Show("Product Name: " + table3.Rows[0][0].ToString() + "\n"
                    + "Product Colour: " + table3.Rows[0][4].ToString() + "\n"
                   + "Transient QTY: " + table3.Rows[0][1].ToString() + "\n"
                   + "Minimum QTY: " + table3.Rows[0][2].ToString() + "\n"
                   + "Maximum QTY: " + table3.Rows[0][3].ToString() + "\n"
                   + "Case Count : " + table3.Rows[0][13].ToString() + "\n"
                   + "Case Weight : " + table3.Rows[0][14].ToString() + "\n", "Detail ProductName Information");

        }

        private void buttonMConfirm_Click(object sender, EventArgs e)
        {



            DialogResult ins = MessageBox.Show("Is the QOH number right?", "Confirm Inventory", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (ins == DialogResult.Yes)
            {

                MessageBox.Show("The inventory is confirmed.", "Confirm Inventory");
                difference = 0;

            }

            else if (ins == DialogResult.No)
            {
                DialogResult ins2 = MessageBox.Show("Do you want to make entry of the Product?", "Product Entry", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if(ins2 == DialogResult.OK){
                    textBoxMQOH.Enabled = true;
                    textBoxMQOH.BackColor = Color.Yellow;
                    textBoxMQOH.Focus();
                    buttonPerformInv.Visible = false;
                    buttonConfirmInv.Visible = true;
                    existingQOH = Convert.ToInt32(textBoxMQOH.Text);
                }
            }
        }


        private void buttonConfirmInv_Click(object sender, EventArgs e)
        {

           
            newQOH = Convert.ToInt32(textBoxMQOH.Text);

            if (newQOH <= existingQOH)
            {
                MessageBox.Show("To add inventory, it should be greater than the existing QOH", "Input Warning");
                textBoxMQOH.Focus();
            }
            else
            {
                conn.Open();
                //to make entry of QOH
                string toMakeEntryQOH = "UPDATE INVENTORY SET QOH =? "
                        + " WHERE INV_ID = " + textBoxMInvID.Text + "";

                OleDbCommand cmd4 = new OleDbCommand(toMakeEntryQOH, conn);
                cmd4.Parameters.Add("?", OleDbType.VarChar).Value = textBoxMQOH.Text;

                if (cmd4.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Product entry has successfully made.", "Completion Entry Notice");
                    difference = newQOH - existingQOH;

                }
                else
                {
                    MessageBox.Show("Making Entry failed. Try again please.");
                }


                string toAddQOHTable = "INSERT INTO ADJUSTMENT (ADJ_ID, INV_ID, QTY, ADJUST_TYPE, APPROVED_BY, USER_ID, ADJ_DATE)"
                        + "VALUES(ADJ_ID_SEQ.nextval, ?, ?, ?, ?, ?, ?)";

                OleDbCommand cmdAdd = new OleDbCommand(toAddQOHTable, conn);
                //allocate appropriate entry for controls
                cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = textBoxMInvID.Text;
                cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = Math.Abs(difference);
                cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = "Add";
                cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USERFULLNAME;
                cmdAdd.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USER_ID;
                cmdAdd.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now;

                //Run the Query and display message.
                GlobalMethods.GlobalMethods.ExecMyQuery(cmdAdd, "Log data for Audit stored.");
                panelMroughInfo.Visible = false;
                panelMbottom.Visible = false;
                textBoxMKeyword.Focus();
                buttonConfirmInv.Visible = false;
                buttonPerformInv.Visible = true;
                conn.Close();
            }

        }

        private void buttonMAdjust_Click(object sender, EventArgs e)
        {
            formScannerAdjust formScannerAdjust = new formScannerAdjust();
            formScannerAdjust.Show();
        }


        //Adjustment QTY is allowed on positive 6 digits number 
        //Only get numbers with fixed digit from textbox 
        private void textBoxMKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            int MaxDigit = 12;
            if ((char.IsNumber(e.KeyChar) || (e.KeyChar == 8)) && ((textBoxMKeyword.TextLength <= MaxDigit - 1) || (e.KeyChar == 8)))
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

        //Display information when combobox value changed.
        private void comboBoxMultipleResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ToSearchSQLInScannerMulti = "SELECT INV_ID, I.PROD_ID, I.LOCATION, SHELF_LOC, QOH, TRANSIENT_QTY, MIN_QTY, MAX_QTY,"
                    + "BE_SKU, SUP_SKU, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, PROD_WEIGHT, CAT_ID,"
                    + "PRICE_PURCH, PRICE_RETAIL, PRICE_PREV, CASE_COUNT, CASE_WEIGHT, P.SUP_ID, L.LOC_NAME "
                    + "FROM INVENTORY I, PRODUCT P, LOCATION L"
                    + " WHERE P.PROD_ID = I.PROD_ID AND I.LOCATION = L.LOCATION AND " + BaseField + " = " + valueTosearchM + " AND "
                    + "I.LOCATION =" + GlobalMethods.GlobalMethods.USERLOCATION + " AND"
                    + "INV_ID =" + comboBoxMultipleResult.Text + "";

            // MessageBox.Show(ToSearchSQLInScanner);
            OleDbCommand cmdMulti = new OleDbCommand(ToSearchSQLInScannerMulti, conn);
            OleDbDataAdapter odaMulti = new OleDbDataAdapter(cmdMulti);
            DataTable tableMulti = new DataTable();
            odaMulti.Fill(tableMulti);


            //Display basic search results
            //panelMroughInfo.Enabled = false;
            panelMroughInfo.Visible = true;
            textBoxMInvID.Text = tableMulti.Rows[0][0].ToString();
            textBoxMProdID.Text = tableMulti.Rows[0][1].ToString();
            textBoxMBE_SKU.Text = tableMulti.Rows[0][8].ToString();
            textBoxMSUP_SKU.Text = tableMulti.Rows[0][9].ToString();
            textBoxMProdName.Text = tableMulti.Rows[0][10].ToString();
            comboBoxMShelfLoc.Text = tableMulti.Rows[0][3].ToString();
            textBoxMQOH.Text = tableMulti.Rows[0][4].ToString();
            textBoxMInvID.Enabled = false;
            textBoxMProdID.Enabled = false;
            textBoxMBE_SKU.Enabled = false;
            textBoxMSUP_SKU.Enabled = false;
            textBoxMProdName.Enabled = false;
            comboBoxMShelfLoc.Enabled = false;
            textBoxMQOH.Enabled = false;
            panelMbottom.Visible = true;
            buttonPerformInv.Enabled = true;
            buttonPerformInv.Visible = true;
            searchedKeyword = valueTosearchM;
            existingQOH = Convert.ToInt32(textBoxMQOH.Text);
        }

        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            
        //Display Manager Order List
            formScannerMain_Load(sender, e);


            if (isOrdItems(valueTosearchM) == true)
            {
                formMgrModifyItem mgrMod = new formMgrModifyItem();
                mgrMod.ShowDialog();
            }
            else
            {
                formScannerOrdItem scOrdItem = new formScannerOrdItem();
                scOrdItem.ShowDialog();
            }



        }

        public bool isOrdItems(string value)
        {
            valueTosearchM = value;

            if (valueTosearchM.Length == 12)
            {
                BaseField = "P.SUP_SKU";
            }
            else if (valueTosearchM.Length == 6)
            {
                BaseField = "P.BE_SKU";
            }


            string ordList = "SELECT AO.INV_ID, P.BE_SKU, AO.REQ_QTY"
           + " FROM ADD_ORDER AO , INVENTORY I, PRODUCT P, LOCATION L"
           + " WHERE AO.INV_ID = I.INV_ID AND P.PROD_ID = I.PROD_ID AND I.LOCATION = L.LOCATION AND "
           + BaseField + " = " + valueTosearchM + " AND "
           + "I.LOCATION =" + GlobalMethods.GlobalMethods.USERLOCATION + "";

            // MessageBox.Show(ToSearchSQLInScanner);
            OleDbCommand cmdOrdList = new OleDbCommand(ordList, conn);
            OleDbDataAdapter odaOrdList = new OleDbDataAdapter(cmdOrdList);
            DataTable tableOrdList = new DataTable();
            odaOrdList.Fill(tableOrdList);
            mgrOrdItemresultnum = tableOrdList.Rows.Count;

            if (mgrOrdItemresultnum == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
