using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlobalMethods;
using System.Data.OleDb;
using System.Data.Sql;
//using AddOrderItems;
//using OrderListDetail;
using ProcessOrder;

namespace OrderForWarehouse
{
    public partial class formOrderForWarehouse : Form
    {
        public formOrderForWarehouse()
        {
            InitializeComponent();
            //locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
        }


        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");
        //;Integrated Security=SSPI

        int searchedItemsNum;
        string originalUserID = GlobalMethods.GlobalMethods.USER_ID;
        string originalUserLocation = GlobalMethods.GlobalMethods.USERLOCATION;
        //string tempUserID = "000000";
        //string invID;
        //string orderID;
        int selectedIndexKind1;
        int selectedIndexKind2;
        //string selectedOrderStatus;
        public static int orderID;
        public string orderLocation;
        public static string orderByid;
        public string invID;
        //public int existingQOH;

        public int resultInvinWH;
        public string beSKU;
        public string prodID;
        string ordStatus;

        public int countOrderToModify = 0;

        public  int ordItemNum;
        public int QOHinWH;
        public int transQTY;
        public int minQTYinWH;
        public int maxQTYinWH;

        public string isBackOrdered = "N"; //   Convert.ToChar(78); //N

        public int movingTransinWH;
        public int movingQOHinWH;

        public int casecount;
        public int caseOrdered; // for individual Order
        public int caseDelivered;
        public int backOrderedCases;
        public int itemUnitsPerOrderID;
        public int totalunitsPerItemperOrderID;
        public int totalunitsPerItemfromAllStores; //Sum of each store with itemUnitesPerOrderID

        public int totalItemCasesOrderedfromAllStores=0;
        //public int caseOrderedperItemfromEachStore;
        //public int totalUnitsOrderedItemallOrder;


        public int casesAvailableinWH;
        string baseword1 = "";
        string baseword2 = "";
        string SearchKeyword2; 
        string SearchKeyword1 = "";



        private void formOrderForWarehouse_Load(object sender, EventArgs e)
        {
            groupBoxOrderSummary.Visible = false;
            panelDetailProdInfo.Visible = false;
            comboBoxSearchBase1.SelectedIndex = 0;
            comboBoxSearchBase2.SelectedIndex = 0;
            labelInfo.Text = GlobalMethods.GlobalMethods.USERFULLNAME + "  " + "User ID: " + GlobalMethods.GlobalMethods.USER_ID + " Location:" + GlobalMethods.GlobalMethods.USER_LOCATION_NAME;
            panelOrdItemsView.Visible = false;
            pictureBoxWarning.Visible = false;
            //pictureBoxDownPink.Visible = false;
            //pictureBoxDownPink.BackColor = Color.Transparent;
            //pictureBoxDownGreen.Visible = false;
            //pictureBoxDownGreen.BackColor = Color.Transparent;
            //pictureBoxDownBlue.Visible = false;
            //pictureBoxDownBlue.BackColor = Color.Transparent;
            //pictureBoxDownYellow.Visible = false;
            //pictureBoxDownYellow.BackColor = Color.Transparent;
            //diplayOrderItems();
            //buttonRemove.Enabled = false;
            //panelMDetail.Visible = false;
            //buttonModItem.Enabled = false;
            textBoxOrdSearchKeyword.BackColor = Color.Yellow;
            textBoxOrdSearchKeyword.Focus();
            panelItemsInOrder.Visible = false;
            buttonReceive.Visible = false;
            buttonDetailProductInfo.Visible = false;
            panelIventroyInfoforOrder.Visible = false;
            buttonProcess.Visible = false;
        }


        //Search BY keywords(INV_ID, BE_SKU, SUP_SKU) and display information
        public void displayItemsBy()
        {
            selectedIndexKind1 = comboBoxSearchBase1.SelectedIndex;
            selectedIndexKind2 = comboBoxSearchBase2.SelectedIndex;
            baseword1 = "O.ORDER_STATUS";
            baseword2="";
            SearchKeyword2 = textBoxOrdSearchKeyword.Text;
            SearchKeyword1="";
            ////Variables to use
            //int ordItemSearchResult;

            if(selectedIndexKind1 == 0){
                SearchKeyword1 = " NOT LIKE '%CREATE%'";
            }
            //else if (selectedIndexKind1 == 1)
            //{
            //    SearchKeyword1 = "CREATE";
            //}

            else if(selectedIndexKind1 == 1){
                SearchKeyword1 = "LIKE '%SUBMIT%'";
            }
            else if(selectedIndexKind1 == 2){
                SearchKeyword1 = "LIKE '%RECEIVE%'";
            }
            else if(selectedIndexKind1 == 3){
                SearchKeyword1 = "LIKE '%ASSEMBLING%'";
            }
            else if(selectedIndexKind1 == 4){
                SearchKeyword1 = "LIKE '%PREPARED%'";
            }
            else if(selectedIndexKind1 == 5){
                SearchKeyword1 = "LIKE '%IN TRANSIT%'";
            }
            else if(selectedIndexKind1 == 6){
                SearchKeyword1 = "LIKE '%DELIVERE%'";
            }

            if(selectedIndexKind2 == 0){
                baseword2 = "I.INV_ID";
            }

            else if(selectedIndexKind2 ==1){
                baseword2 = "P.BE_SKU";
            }
            else if(selectedIndexKind2 == 2){
                baseword2 = "P.SUP_SKU";
            }
            else if (selectedIndexKind2 == 3)
            {
                baseword2 = "O.LOCATION";
            }


            dataGridViewSearchedItems.AllowUserToAddRows = false; // To set allowance for DGV

            //string toSearchOrderItem = "SELECT I.INV_ID, P.BE_SKU,  I.QOH, ROUND((I.MAX_QTY - I.QOH) / P.CASE_COUNT) AS Req_Case_QTY, P.PROD_NAME, P.PROD_COLOR, P.PROD_DESC, P.PROD_SIZE"
            //      + " FROM INVENTORY I, PRODUCT P"
            //        + " WHERE lower(" + GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD + ") LIKE '%" + GlobalMethods.GlobalMethods.VALUETOSEARCH2KEYWORD.ToLower() + "%' "
            //        + " AND I.LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION + " AND I.PROD_ID = P.PROD_ID "
            //        + " ORDER BY P.BE_SKU ASC, " + GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD + " ASC";

            string toSearchOrderItem;
            if(checkBoxByList.Checked == false)
            {
                toSearchOrderItem = "SELECT DISTINCT O.ORDER_ID, O.USER_ID, O.ORDER_STATUS, O.LOCATION, O.EXPECTED_DT, O.CREATE_DT, O.SUBMIT_DT, O.RECEIVE_DT, O.PROCESS_DT, O.LOAD_DT, O.DELIVER_DT, O.DRIVER_NAME"
                    + " FROM ORDERS O JOIN ORD_ITEM OI ON O.ORDER_ID = OI.ORDER_ID JOIN INVENTORY I ON OI.INV_ID = I.INV_ID JOIN PRODUCT P ON I.PROD_ID = P.PROD_ID"
                    + " WHERE " + baseword1 + " " +SearchKeyword1+ " AND "
                    + " lower(" + baseword2 + ") LIKE '%" + SearchKeyword2 + "%' "
                    + " ORDER BY O.ORDER_ID DESC";

                OleDbCommand cmdOrdItem = new OleDbCommand(toSearchOrderItem, conn);
                OleDbDataAdapter odaOrdItem = new OleDbDataAdapter(cmdOrdItem);
                DataTable tableOrdItem = new DataTable();
                //MessageBox.Show(toSearchOrderItem);
                odaOrdItem.Fill(tableOrdItem);
                dataGridViewSearchedItems.DataSource = tableOrdItem;
                searchedItemsNum = dataGridViewSearchedItems.Rows.Count;
                labelSearchItemResult.Text = searchedItemsNum.ToString();
            }
            else

            {
                if (textBoxOrdSearchKeyword.Text == "")
                {
                    dataGridViewSearchedItems.DataSource = null;
                    panelOrdItemsView.Visible = false;
                    MessageBox.Show("Please input a keyword to search", "Input Instruction");
                    textBoxOrdSearchKeyword.Focus();
                }
                else
                {
                    checkedItemList();
                }

            }

            
        }


        //search checked box items
        public void checkedItemList()
        {

            string toSearchOrderItem = "SELECT O.ORDER_ID, O.USER_ID, O.ORDER_STATUS, O.LOCATION, O.EXPECTED_DT,O.SUBMIT_DT, O.RECEIVE_DT, P.PROD_ID, P.PROD_NAME, I.INV_ID, I.QOH, P.CASE_COUNT, OI.ORD_QTY  "
                + " FROM ORDERS O JOIN ORD_ITEM OI ON O.ORDER_ID = OI.ORDER_ID JOIN INVENTORY I ON OI.INV_ID = I.INV_ID JOIN PRODUCT P ON I.PROD_ID = P.PROD_ID"
                + " WHERE " + baseword1 + " " + SearchKeyword1 + " AND"
                + " lower(" + baseword2 + ") = " + SearchKeyword2 + ""
                + " ORDER BY O.ORDER_ID DESC";

            OleDbCommand cmdOrdItem = new OleDbCommand(toSearchOrderItem, conn);
            OleDbDataAdapter odaOrdItem = new OleDbDataAdapter(cmdOrdItem);
            DataTable tableOrdItem = new DataTable();
            //MessageBox.Show(toSearchOrderItem);
            odaOrdItem.Fill(tableOrdItem);
            dataGridViewSearchedItems.DataSource = tableOrdItem;
            searchedItemsNum = dataGridViewSearchedItems.Rows.Count;
            labelSearchItemResult.Text = searchedItemsNum.ToString();



            if (tableOrdItem.Rows.Count > 0)
            {
                prodID = dataGridViewSearchedItems.Rows[0].Cells[7].ToString();
                //checkWHInventory(prodID);

                for (int i = 0; i < dataGridViewSearchedItems.Rows.Count; i++)
                {
                    invID = tableOrdItem.Rows[i][9].ToString();
                    //prodID = tableOrdItem.Rows[i][7].ToString();
                    casecount = Convert.ToInt32(tableOrdItem.Rows[i][11].ToString());
                    caseOrdered = Convert.ToInt32(tableOrdItem.Rows[i][12].ToString());
                    //count total cases ordered, total units ordered
                    itemUnitsPerOrderID = casecount * caseOrdered;
                    totalItemCasesOrderedfromAllStores += itemUnitsPerOrderID;


                    //totalUnitsOrderedwithItemallOrder += totalunitsOrderwithItemperOrder;

                }
                if (selectedIndexKind1 == 1)
                {
                    panelIventroyInfoforOrder.Visible = true;
                    textBoxTotOrderUnit.Text = totalItemCasesOrderedfromAllStores.ToString();
                    textBoxInvWH.Text = QOHinWH.ToString();

                    if (totalunitsPerItemfromAllStores > QOHinWH || itemUnitsPerOrderID > QOHinWH)
                    {
                        pictureBoxWarning.Visible = true;
                    }
                    else
                    {
                        pictureBoxWarning.Visible = false;
                    }
                }
                else
                {
                    panelIventroyInfoforOrder.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("There is no Items found. Please try again.", "No Result");
                textBoxOrdSearchKeyword.Focus();
                panelIventroyInfoforOrder.Visible = false;
            }

        }


        //Display searched Items detail
        private void dataGridViewSearchedItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            countOrderToModify = 0;
            buttonReceive.Visible = false;
            orderID = Convert.ToInt32(dataGridViewSearchedItems.CurrentRow.Cells[0].Value);
            ordStatus = dataGridViewSearchedItems.CurrentRow.Cells[2].Value.ToString();
            orderLocation = dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString();
            orderByid = dataGridViewSearchedItems.CurrentRow.Cells[1].Value.ToString();

            buttonModifyOrder.Enabled = true;
            buttonConfirmModify.Enabled = false;
            textBoxCaseOrdered.Enabled = false;

            if (ordStatus == "SUBMIT")
            {
               buttonProcess.Visible = true;

            }
            else
            {
                buttonProcess.Visible = false;
            }


            //if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "2")
            //{
            //    if (ordStatus == "CREATE")
            //    {
            //        buttonAddItems.Visible = true;
            //        buttonRemove.Visible = true;
            //        buttonSubmitOrder.Visible = true;
            //        buttonRemove.Enabled = false;
            //        buttonReceive.Visible = false;
            //    }
            //    else
            //    {
            //        buttonAddItems.Visible = false;
            //        buttonRemove.Visible = false;
            //        buttonSubmitOrder.Visible = false;
            //        buttonReceive.Visible = false;
            //    }

            //}


            diplayOrderItems();
            panelOrdItemsView.Visible = true;
            panelItemsInOrder.Visible = true;
            groupBoxOrderSummary.Visible = false;
            panelIventroyInfoforOrder.Visible = false;
        }

        //Display ordered items
        public void diplayOrderItems()
        {

            string toSearchOrderItem = "SELECT * "
                    + "FROM ORD_ITEM "
                    + "WHERE ORDER_ID = " + orderID + ""
                    + " ORDER BY INV_ID";

            OleDbCommand cmdOrdItem = new OleDbCommand(toSearchOrderItem, conn);
            OleDbDataAdapter odaOrdItem = new OleDbDataAdapter(cmdOrdItem);
            DataTable tableOrdItemList = new DataTable();
            odaOrdItem.Fill(tableOrdItemList);
            dataGridViewOrdItems.DataSource = tableOrdItemList;
            ordItemNum = tableOrdItemList.Rows.Count;
            labelOrdItemResult.Text = ordItemNum.ToString();


            for (int i = 0; i < dataGridViewOrdItems.Rows.Count; i++)
            {
                invID = tableOrdItemList.Rows[i][1].ToString();  //  .CurrentRow.Cells[1].Value.ToString();
                findQOHinWHforInv();
                if (QOHinWH < 0)
                {
                    countOrderToModify++;
                    pictureBoxWarning.Visible = true;
                    dataGridViewOrdItems.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                }

            }

            if (ordStatus == "RECEIVE" || ordStatus == "ASSEMBLING")
            {
                if (countOrderToModify <= 0)
                {
                    buttonProcess.Visible = true;
                }
                else
                {
                    buttonProcess.Visible = false;
                }
            }
            else
            {
                buttonProcess.Visible = false;
            }




        }


        //Check the inventory is enough
        public void checkWHInventory(string prodID)
        {
            string toSearchInvItem = "SELECT * "
                + " FROM INVENTORY "
                + " WHERE PROD_ID = " + prodID + " AND LOCATION = 0";

            OleDbCommand cmdInvItem = new OleDbCommand(toSearchInvItem, conn);
            OleDbDataAdapter odaInvItem = new OleDbDataAdapter(cmdInvItem);
            DataTable tableOrdItem = new DataTable();
            //MessageBox.Show(toSearchOrderItem);
            if (tableOrdItem.Rows.Count > 0)
            {
                QOHinWH = Convert.ToInt32(tableOrdItem.Rows[0][4].ToString());
                transQTY = Convert.ToInt32(tableOrdItem.Rows[0][5].ToString());
                minQTYinWH = Convert.ToInt32(tableOrdItem.Rows[0][6].ToString());
                maxQTYinWH = Convert.ToInt32(tableOrdItem.Rows[0][7].ToString());
            }
            //textBoxInvWH.Text = QOHinWH.ToString();



            
        }
        //Search Items
        private void buttonOrdSearch_Click(object sender, EventArgs e)
        {
            totalItemCasesOrderedfromAllStores = 0;
            groupBoxOrderSummary.Visible = false;
            panelItemsInOrder.Visible = false;
            panelOrdItemsView.Visible = true;
            displayItemsBy();
            panelDetailProdInfo.Visible = false;
            buttonReceive.Visible = false;
            buttonDetailProductInfo.Visible = false;
        }


        ////find total cases per order
        //public void totalCasesOrdered()
        //{

        //    string toSearchOrderItem = "SELECT  "
        //            + "FROM ORD_ITEM "
        //            + "WHERE ORDER_ID = " + orderID + ""
        //            + " ORDER BY INV_ID";

        //    OleDbCommand cmdOrdItem = new OleDbCommand(toSearchOrderItem, conn);
        //    OleDbDataAdapter odaOrdItem = new OleDbDataAdapter(cmdOrdItem);
        //    DataTable tableOrdItemList = new DataTable();
        //    odaOrdItem.Fill(tableOrdItemList);
        //    dataGridViewOrdItems.DataSource = tableOrdItemList;
        //    ordItemNum = tableOrdItemList.Rows.Count;
        //    labelOrdItemResult.Text = ordItemNum.ToString();

        //}


     


        //find detail iventory information and use it later
        public void findeInvDetailInfo()
        {
            String detailOrdItemsSql = "SELECT I.INV_ID, P.BE_SKU, P.PROD_ID, P.CASE_COUNT, P.SUP_SKU, I.QOH, OI.ORD_QTY, P.PROD_NAME, P.PROD_COLOR, P.PROD_DESC, P.PROD_SIZE, I.LOCATION, O.ORDER_STATUS"
      + " FROM ORDERS O JOIN ORD_ITEM OI ON O.ORDER_ID = OI.ORDER_ID JOIN INVENTORY I ON OI.INV_ID = I.INV_ID JOIN PRODUCT P ON I.PROD_ID = P.PROD_ID"
      + " WHERE OI.ORDER_ID = " + orderID + " AND I.INV_ID = "
      +   invID + " AND I.LOCATION = " + orderLocation + "";
            //MessageBox.Show(detailOrdItemsSql.ToString());
            OleDbCommand cmdDetailItem = new OleDbCommand(detailOrdItemsSql, conn);
            OleDbDataAdapter odaDetailItem = new OleDbDataAdapter(cmdDetailItem);
            DataTable tableDetailItem = new DataTable();
            odaDetailItem.Fill(tableDetailItem);
            dataGridViewOrderDetail.DataSource = tableDetailItem;

            casecount = Convert.ToInt32(tableDetailItem.Rows[0][3].ToString());
            textBoxUnitsPerCase.Text = casecount.ToString();
            
            beSKU = tableDetailItem.Rows[0][1].ToString();
            textBoxBESKU.Text = beSKU.ToString();
            prodID = tableDetailItem.Rows[0][2].ToString();
            textBoxProdID.Text = prodID.ToString();

            itemUnitsPerOrderID = casecount * caseOrdered;
            textBoxUnitsOrdered.Text = itemUnitsPerOrderID.ToString();
            casesAvailableinWH = QOHinWH / casecount ;
            caseOrdered = Convert.ToInt32(dataGridViewOrdItems.CurrentRow.Cells[2].Value.ToString());
            textBoxTransQTY.Text = transQTY.ToString();

        }


        //Display detail Information when clicked
        private void dataGridViewOrdItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonDetailProductInfo.Visible = true;
            orderID = Convert.ToInt32(dataGridViewOrdItems.CurrentRow.Cells[0].Value);
            invID = dataGridViewOrdItems.CurrentRow.Cells[1].Value.ToString();
            caseOrdered = Convert.ToInt32(dataGridViewOrdItems.CurrentRow.Cells[2].Value);
            if (dataGridViewOrdItems.CurrentRow.Cells[3].Value.ToString() == "")
            {
                caseDelivered = 0;
            }
            else
            {
                caseDelivered = Convert.ToInt32(dataGridViewOrdItems.CurrentRow.Cells[3].Value);
            }



            if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "1")
            {

                if (ordStatus == "SUBMIT")
                {

                    buttonReceive.Visible = true;
                    //buttonAddItems.Visible = false;
                    //buttonRemove.Visible = false;
                    //buttonSubmitOrder.Visible = false;
                    //buttonRemove.Enabled = false;
                    //buttonReceive.Visible = false;
                    buttonProcess.Visible = false;
                }
                else if (ordStatus == "RECEIVE")
                {
                    buttonModifyOrder.Enabled = true;
                    buttonConfirmModify.Enabled = false;
                    findQOHinWHforInv();
                    findeInvDetailInfo();
                    //displayQOHinWHforInv();
                    groupBoxOrderSummary.Visible = true;
                    buttonReceive.Visible = false;
                    //checkWHInventory(prodID);
                    panelIventroyInfoforOrder.Visible = true;
                    panelIventroyInfoforOrder.Visible = true;
                    //itemUnitsPerOrderID = casecount * caseOrdered;
                    
                    textBoxTotOrderUnit.Text = itemUnitsPerOrderID.ToString();
                    textBoxInvWH.Text = QOHinWH.ToString();
                    textBoxTransQTY.Text = transQTY.ToString();
                    textBoxQOHinWH.Text = QOHinWH.ToString();
                    textBoxUnitsOrdered.Text = itemUnitsPerOrderID.ToString();
                    textBoxCaseOrdered.Text = caseOrdered.ToString();
                    textBoxDeliveredCases.Text = caseDelivered.ToString();
                    textBoxBackOrderedCases.Text = backOrderedCases.ToString();
                    casesAvailableinWH = QOHinWH / casecount;
                    textBoxAvailCaseinWH.Text = casesAvailableinWH.ToString();
                    //textBoxTransQTY.Text = transQTY.ToString();
                   // if (totalunitsPerItemfromAllStores > QOHinWH || itemUnitsPerOrderID > QOHinWH)
                   if ( QOHinWH < 0)
                    {
                        pictureBoxWarning.Visible = true;

                        dataGridViewOrdItems.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
                       
                    }
                    else
                    {
                        pictureBoxWarning.Visible = false;
                    }

                   if (countOrderToModify == 0)
                   {
                       buttonProcess.Visible = true;
                   }




                }

            }


        }

        //Display QOH for INV ID
        public void findQOHinWHforInv()
        {

            string toSearchOrderItem = "SELECT QOH, TRANSIENT_QTY, MIN_QTY, MAX_QTY"
                    + " FROM INVENTORY "
                    + " WHERE PROD_ID =  (SELECT PROD_ID FROM INVENTORY WHERE INV_ID = "+  invID + ") AND LOCATION = 0";
            
            OleDbCommand cmdItem = new OleDbCommand(toSearchOrderItem, conn);
            OleDbDataAdapter odaItem = new OleDbDataAdapter(cmdItem);
            DataTable tableItemList = new DataTable();
            odaItem.Fill(tableItemList);
            //dataGridViewOrdItems.DataSource = tableOrdItemList;
            QOHinWH = Convert.ToInt32(tableItemList.Rows[0][0].ToString());
            //MessageBox.Show(QOHinWH.ToString());
            if (tableItemList.Rows[0][1].ToString() == "")
            {
                transQTY = 0;
            }
            else
            {
                transQTY = Convert.ToInt32(tableItemList.Rows[0][1].ToString());
            }

            //checkWHInventory(prodID);
            minQTYinWH = Convert.ToInt32(tableItemList.Rows[0][2].ToString());
            maxQTYinWH = Convert.ToInt32(tableItemList.Rows[0][3].ToString());
            //resultInvinWH = tableItemList.Rows.Count;
            //textBoxQOHinWH.Text = QOHinWH.ToString();
            //textBoxUnitsOrdered.Text = itemUnitsPerOrderID.ToString();
            //textBoxTotOrderUnit.Text = itemUnitsPerOrderID.ToString();
            textBoxTransQTY.Text = transQTY.ToString();


            //for (int i = 0; i < dataGridViewOrdItems.Rows.Count; i++)
            //{
            //    totalCasesOrdered += Convert.ToInt32(dataGridViewOrdItems.Rows[i].Cells[2].Value.ToString());
            //}
            //labelCaseTotal.Text = totalCasesOrdered.ToString();
        }

        //Display detail product information
        private void buttonDetailProductInfo_Click(object sender, EventArgs e)
        {
            panelDetailProdInfo.Visible = true;
            findeInvDetailInfo();
            findQOHinWHforInv();
            panelItemsInOrder.Visible = false;
        }

        //Closing a form
        private void buttonClose_Click(object sender, EventArgs e)
        {
            panelDetailProdInfo.Visible = false;
            panelItemsInOrder.Visible = true;
        }


        //receive Order and change status to "RECEIVE"
        private void buttonReceive_Click(object sender, EventArgs e)
        {
            DialogResult ins = MessageBox.Show("Do you want to Receive an Order? ", "Order Receive", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
            if (ins == DialogResult.Yes)
            {
                // MessageBox.Show(newInvLocation.ToString() + prodID); //Debug purpose
                conn.Open();
                //to make entry of QOH
                string receiveOrder = "UPDATE ORDERS SET ORDER_STATUS =?, RECEIVE_DT = ? "
                        + " WHERE ORDER_ID = " + orderID + "";

                OleDbCommand cmdreceiveOrder = new OleDbCommand(receiveOrder, conn);
                // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());

                cmdreceiveOrder.Parameters.Add("?", OleDbType.VarChar).Value = "RECEIVE";
                //cmdreceiveOrder.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now.AddDays(7);
                cmdreceiveOrder.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now;

                //MessageBox.Show(updateQOH);
                cmdreceiveOrder.ExecuteNonQuery();
                //buttonOrdSearch_Click(sender, e);
                conn.Close();

                GlobalMethods.GlobalMethods.storeAudit("", "", "RECEIVE");

                for (int i = 0; i < dataGridViewOrdItems.Rows.Count; i++)
                {
                    conn.Open();


                    backOrderedCases = 0;
                    //find invID
                    if (dataGridViewOrdItems.CurrentRow.Cells[3].Value.ToString() == "")
                    {
                        caseOrdered = Convert.ToInt32(dataGridViewOrdItems.Rows[i].Cells[2].Value);
                        caseDelivered = Convert.ToInt32(dataGridViewOrdItems.Rows[i].Cells[2].Value);
                    }
                    else
                    {
                        caseOrdered = Convert.ToInt32(dataGridViewOrdItems.Rows[i].Cells[2].Value);
                        caseDelivered = Convert.ToInt32(dataGridViewOrdItems.Rows[i].Cells[3].Value);
                    }
                    
                    orderID = Convert.ToInt32(dataGridViewOrdItems.Rows[i].Cells[0].Value.ToString());
                    invID = dataGridViewOrdItems.Rows[i].Cells[1].Value.ToString();

                    //caseDelivered = Convert.ToInt32(dataGridViewOrdItems.Rows[i].Cells[2].Value.ToString());
                    //FIND casecount
                    string casecountFind = "select CASE_COUNT, PROD_ID from PRODUCT where PROD_ID = (SELECT PROD_ID FROM INVENTORY WHERE INV_ID = " + invID +")";
                    OleDbCommand cmdCasecount = new OleDbCommand(casecountFind, conn);
                    OleDbDataAdapter odatemp1 = new OleDbDataAdapter(cmdCasecount);
                    DataTable tableCaseCount = new DataTable();
                    odatemp1.Fill(tableCaseCount);
                    casecount = Convert.ToInt32(tableCaseCount.Rows[0][0].ToString());
                    prodID =tableCaseCount.Rows[0][1].ToString();
                    
                    
                    //to make entry of QOH
                    string receiveOrd = "UPDATE ORD_ITEM SET QTY_DELIVERD = ?, BACK_ORD = ? "
                            + " WHERE ORDER_ID = " + orderID + " AND INV_ID = " + invID + "";
                    OleDbCommand cmdreceiveOrd = new OleDbCommand(receiveOrd, conn);
                    // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());

//                    if (dataGridViewOrdItems.CurrentRow.Cells[3].Value.ToString() == "")
//                    {
//                        caseDelivered = Convert.ToInt32(dataGridViewOrdItems.Rows[i].Cells[2].Value.ToString());
//;                    }
//                    else
//                    {
//                        caseDelivered = Convert.ToInt32(dataGridViewOrdItems.CurrentRow.Cells[3].Value);
//                    }
                    backOrderedCases = caseOrdered - caseDelivered;


                    if (backOrderedCases > 0)
                    {
                        isBackOrdered = "Y";
                    }
                    else
                    {
                        isBackOrdered = "N";
                    }

                    cmdreceiveOrd.Parameters.Add("?", OleDbType.Integer).Value = caseDelivered;
                    cmdreceiveOrd.Parameters.Add("?", OleDbType.Char).Value = isBackOrdered;

                    //MessageBox.Show(updateQOH);
                    cmdreceiveOrd.ExecuteNonQuery();

                    conn.Close();
                    //updateOrdItem();
                    //updateInventory();
                    //Update Inventory=============================================================
                    conn.Open();


                    //FIND warehouse INV_ID
                    string whInvIDSQL = "select inv_id from inventory where location= 0 and PROD_ID = " + prodID + " ";
                    OleDbCommand cmdwhInvID = new OleDbCommand(whInvIDSQL, conn);
                    OleDbDataAdapter odawhInvID = new OleDbDataAdapter(cmdwhInvID);
                    DataTable tablewhInvID = new DataTable();
                    odawhInvID.Fill(tablewhInvID);
                    string whInvID = tablewhInvID.Rows[0][0].ToString();


                    
                    //FIND QOH, TRANSIENT QTY
                    string whInvSQL = "select QOH, TRANSIENT_QTY, MIN_QTY, MAX_QTY from inventory where INV_ID = " + whInvID + "";
                    OleDbCommand cmdwhInv = new OleDbCommand(whInvSQL, conn);
                    OleDbDataAdapter odawhInv = new OleDbDataAdapter(cmdwhInv);
                    DataTable tablewhInv = new DataTable();
                    odawhInv.Fill(tablewhInv);
                    QOHinWH = Convert.ToInt32(tablewhInv.Rows[0][0].ToString());
                    string transQTYstring = tablewhInv.Rows[0][1].ToString();

                    if (transQTYstring == "")
                    {
                        transQTY = 0;

                    }
                    else
                    {
                        transQTY = Convert.ToInt32(transQTYstring);
                    }



                    itemUnitsPerOrderID = caseDelivered * casecount;
                    transQTY = itemUnitsPerOrderID;
                    QOHinWH -= transQTY;

                    string updateWHInvSQL = "UPDATE INVENTORY SET QOH = ?, TRANSIENT_QTY = ? "
                         + " WHERE INV_ID = " + whInvID + "";
                    OleDbCommand cmdupdateWHInv = new OleDbCommand(updateWHInvSQL, conn);
                    // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());

                    cmdupdateWHInv.Parameters.Add("?", OleDbType.Integer).Value = QOHinWH;
                    cmdupdateWHInv.Parameters.Add("?", OleDbType.Integer).Value = transQTY;

                    //cmdreceiveOrder.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now.AddDays(7);

                    //MessageBox.Show(updateQOH);
                    cmdupdateWHInv.ExecuteNonQuery();
                    conn.Close();



                }
                buttonOrdSearch.Refresh();
            }
            else
            {
                // conn.Close();
            }
            buttonOrdSearch_Click(sender, e);
        }

        //Update Order Item
        public void updateOrdItem()
        {

            //findeInvDetailInfo();
            //findQOHinWHforInv();
            conn.Open();
            //to make entry of QOH
            string receiveOrder = "UPDATE ORD_ITEM SET QTY_DELIVERD = ? "
                    + " WHERE ORDER_ID = " + orderID + " AND INV_ID = "+ invID +"" ;

            OleDbCommand cmdreceiveOrder = new OleDbCommand(receiveOrder, conn);
            // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());
            int orderedCaseQTY = Convert.ToInt32(dataGridViewOrdItems.CurrentRow.Cells[2].Value.ToString());
            cmdreceiveOrder.Parameters.Add("?", OleDbType.VarChar).Value = caseDelivered.ToString();
            //cmdreceiveOrder.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now.AddDays(7);

            //MessageBox.Show(updateQOH);
            cmdreceiveOrder.ExecuteNonQuery();
            transQTY = caseDelivered * casecount; 
            conn.Close();

            conn.Open();
            //to make entry of QOH

            //string receiveInv = "UPDATE INVENTORY SET QOH = ?, TRANSIENT_QTY = ? "
            //        + " WHERE INV_ID = " + invID + "";
            //OleDbCommand cmdreceiveInv = new OleDbCommand(receiveInv, conn);
            //// MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());
            //int tempQOHinWH = QOHinWH - transQTY;
            //cmdreceiveInv.Parameters.Add("?", OleDbType.Integer).Value = tempQOHinWH;
            //cmdreceiveInv.Parameters.Add("?", OleDbType.Integer).Value = transQTY;
            ////cmdreceiveOrder.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now.AddDays(7);

            ////MessageBox.Show(updateQOH);
            //cmdreceiveInv.ExecuteNonQuery();
            //conn.Close();

            //conn.Open();
            //to make entry of QOH

            //string updateWHInv = "UPDATE INVENTORY SET QOH = ?, TRANSIENT_QTY = ? "
            //        + " WHERE LOCATION = 0 AND (INV_ID = (SELECT INV_ID FROM INVENTORY WHERE PROD_ID = (SELECT PROD_ID FROM INVENTORY WHERE INV_ID = " + invID + ")))";


            conn.Close();

            updateWHInventory();




        }

        //Update Warehouse Inventory
        public void updateWHInventory()
        {
            conn.Open();
            string temp1 = "select inv_id from inventory where location=0 and prod_id = " + prodID + " ";
            OleDbCommand cmdtemp1 = new OleDbCommand(temp1, conn);
            OleDbDataAdapter odatemp1 = new OleDbDataAdapter(cmdtemp1);
            DataTable tabletemp1 = new DataTable();
            odatemp1.Fill(tabletemp1);
            string temp1_1 = tabletemp1.Rows[0][0].ToString();
            string updateWHInv = "UPDATE INVENTORY SET QOH = ?, TRANSIENT_QTY = ? "
                 + " WHERE INV_ID = " + temp1_1 + "";
            OleDbCommand cmdupdateWHInv = new OleDbCommand(updateWHInv, conn);
            // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());
            int tempQOHinWH = QOHinWH - transQTY;
            cmdupdateWHInv.Parameters.Add("?", OleDbType.Integer).Value = tempQOHinWH;
            cmdupdateWHInv.Parameters.Add("?", OleDbType.Integer).Value = transQTY;

            //cmdreceiveOrder.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now.AddDays(7);

            //MessageBox.Show(updateQOH);
            cmdupdateWHInv.ExecuteNonQuery();
            conn.Close();
        }

        //Try to Modify an Ordered Item
        private void buttonModifyOrder_Click(object sender, EventArgs e)
        {
            buttonModifyOrder.Enabled = false;
            buttonConfirmModify.Enabled = true;
            textBoxDeliveredCases.Enabled = true;
            textBoxDeliveredCases.BackColor = Color.Yellow;

        }

        //Confirm Modify of Ordered Item
        private void buttonConfirmModify_Click(object sender, EventArgs e)
        {

            conn.Open();
            string temp1 = "select inv_id from inventory where location=0 and prod_id = " + prodID + " ";
            OleDbCommand cmdtemp1 = new OleDbCommand(temp1, conn);
            OleDbDataAdapter odatemp1 = new OleDbDataAdapter(cmdtemp1);
            DataTable tabletemp1 = new DataTable();
            odatemp1.Fill(tabletemp1);
            string temp1_1 = tabletemp1.Rows[0][0].ToString();
            conn.Close();
            
            conn.Open();
            //to make entry of QOH
            string modInv = "UPDATE INVENTORY SET QOH = ?, TRANSIENT_QTY = ? "
                 + " WHERE INV_ID = " + temp1_1 + "";

            OleDbCommand cmdmodInv = new OleDbCommand(modInv, conn);
            // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());

            int newCase = Convert.ToInt32(textBoxDeliveredCases.Text);
            int gap;
            int tempQOHinWH2;
            backOrderedCases = caseOrdered - newCase;
            gap = (newCase - caseDelivered) *casecount;
            //transQTY = gap * casecount;

            tempQOHinWH2 = QOHinWH - gap;
            transQTY = transQTY + gap;
            //if (gap < 0)
            //{
            //    tempQOHinWH2 = QOHinWH - gap;
            //    transQTY = transQTY+gap;
            //}
            //else
            //{
            //    tempQOHinWH2 = QOHinWH - gap;
            //    transQTY = transQTY+gap;
            //}

            cmdmodInv.Parameters.Add("?", OleDbType.Integer).Value = tempQOHinWH2;
            cmdmodInv.Parameters.Add("?", OleDbType.Integer).Value = transQTY;
            //cmdreceiveOrder.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now.AddDays(7);

            //MessageBox.Show(updateQOH);
            cmdmodInv.ExecuteNonQuery();
            conn.Close();


            conn.Open();
            //to make entry of QOH
     //       string modOrd = "UPDATE ORD_ITEM SET ORD_QTY = " + newCase + ", QTY_DELIVERD = " + newCase + ""
     //+ " WHERE INV_ID = " + invID + " AND ORDER_ID =" + orderID + "";
            if (backOrderedCases > 0)
            {
                isBackOrdered ="Y";

            }
            else
            {
                isBackOrdered = "N";

            }

            //if (backOrderedCases <= 0)
            //{
            //    countOrderToModify--;
            //}
            //else if (backOrderedCases > 0)
            //{
            //    countOrderToModify++;
            //}




            string modOrd = "UPDATE ORD_ITEM SET QTY_DELIVERD = " + newCase + ", BACK_ORD = ? "
                 + " WHERE INV_ID = " + invID + " AND ORDER_ID ="+orderID+"" ;

            OleDbCommand cmdmodOrd = new OleDbCommand(modOrd, conn);
            cmdmodOrd.Parameters.Add("?", OleDbType.Char).Value = isBackOrdered;
            
            // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());
            cmdmodOrd.ExecuteNonQuery();

            conn.Close();
            buttonModifyOrder.Enabled = true;
            buttonConfirmModify.Enabled = false;
            buttonOrdSearch_Click(sender, e);
            panelIventroyInfoforOrder.Visible = false;
        }

        //To Process. change status and date
        private void buttonProcess_Click(object sender, EventArgs e)
        {
            DialogResult ins = MessageBox.Show("Do you want to start to assign or re-assign Order? ", "Order Processing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
            if (ins == DialogResult.Yes)
            {
                // MessageBox.Show(newInvLocation.ToString() + prodID); //Debug purpose
                conn.Open();

                string processOrder = "UPDATE ORDERS SET ORDER_STATUS =?, PROCESS_DT = ? "
                        + " WHERE ORDER_ID = " + orderID + "";

                OleDbCommand cmdprocessOrder = new OleDbCommand(processOrder, conn);
                // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());

                cmdprocessOrder.Parameters.Add("?", OleDbType.VarChar).Value = "ASSEMBLING";
                //cmdreceiveOrder.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now.AddDays(7);
                cmdprocessOrder.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now;

                //MessageBox.Show(updateQOH);
                cmdprocessOrder.ExecuteNonQuery();
                //buttonOrdSearch_Click(sender, e);

                GlobalMethods.GlobalMethods.storeAudit("", "", "Assembling");
                conn.Close();

                            formProcessOrder formProcess = new formProcessOrder();
                this.Hide();
                formProcess.ShowDialog();
                this.Show();
                buttonOrdSearch_Click(sender, e);

             
            }
            else
            {
                // conn.Close();
            }

        }

    }
}

