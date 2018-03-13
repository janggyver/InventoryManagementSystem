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
using AddOrderItems;
using OrderListDetail;

namespace Orders
{
    public partial class formOrders : Form
    {
        public formOrders()
        {
            InitializeComponent();
            //locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            buttonReceive.Visible = false;
            labelInfo.Text = GlobalMethods.GlobalMethods.USERFULLNAME + "  " + "User ID: " + GlobalMethods.GlobalMethods.USER_ID + " Location:" + GlobalMethods.GlobalMethods.USER_LOCATION_NAME;
            //comboBoxOrdSearch.SelectedIndex = 0;
            panelOrderView.Visible = false;

            dateTimePickerOrdSearchStart.Value = (DateTime)System.DateTime.Today;
            dateTimePickerOrdSearchEnd.Value = (DateTime)System.DateTime.Today;
            buttonCreateOrder.Visible = false;

            panelOrdItemsView.Visible = false;

            buttonAddItems.Visible = false;
            buttonRemove.Visible = false;
            buttonSubmitOrder.Visible = false;

            comboBoxSearchBase1.SelectedIndex = 0;
            comboBoxSearchBase2.SelectedIndex = 0;

        }

        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");
        DateTime startDate = System.DateTime.MinValue;
        DateTime endDate = System.DateTime.MaxValue;
        bool orderCreated;
        bool itemsInOrder;
        int ordSearchResult;
        int ordNumBy;
        int ordCreatedNum;

        int ordItemNum;
        public static int orderID;
        public static int invID;
        public static int existingQOH;
        string ordStatus="";
        string baseKind;
        int selectedIndexKind1;
        int selectedIndexKind2;
        string selectedIndexStaus;

        //Search BY keywords(INV_ID, BE_SKU, SUP_SKU) and display 
        public void displayItemsBy()
        {
            selectedIndexKind1 = comboBoxSearchBase1.SelectedIndex;
            selectedIndexKind2 = comboBoxSearchBase2.SelectedIndex;
            string baseword1 = "O.ORDER_STATUS";
            string baseword2 = "";
            string SearchKeyword2 = textBoxOrdSearchKeyword.Text;
            string SearchKeyword1 = "";
            ////Variables to use
            //int ordItemSearchResult;

            if (selectedIndexKind1 == 0)
            {
                SearchKeyword1 = "";
            }
            else if (selectedIndexKind1 == 1)
            {
                SearchKeyword1 = "CREATE";
            }

            else if (selectedIndexKind1 == 2)
            {
                SearchKeyword1 = "SUBMIT";
            }
            else if (selectedIndexKind1 == 3)
            {
                SearchKeyword1 = "RECEIVE";
            }
            //else if (selectedIndexKind1 == 4)
            //{
            //    SearchKeyword1 = "ASSEMBLING";
            //}
            //else if (selectedIndexKind1 == 5)
            //{
            //    SearchKeyword1 = "PREPARED";
            //}
            //else if (selectedIndexKind1 == 6)
            //{
            //    SearchKeyword1 = "IN TRANSIT";
            //}
            else if (selectedIndexKind1 == 4)
            {
                SearchKeyword1 = "DELIVER";
            }

            if (selectedIndexKind2 == 0)
            {
                baseword2 = "I.INV_ID";
            }

            else if (selectedIndexKind2 == 1)
            {
                baseword2 = "P.BE_SKU";
            }
            else if (selectedIndexKind2 == 2)
            {
                baseword2 = "P.SUP_SKU";
            }
            dataGridViewOrders.DataSource = null;

            dataGridViewOrders.AllowUserToAddRows = false; // To set allowance for DGV

            //string toSearchOrderItem = "SELECT I.INV_ID, P.BE_SKU,  I.QOH, ROUND((I.MAX_QTY - I.QOH) / P.CASE_COUNT) AS Req_Case_QTY, P.PROD_NAME, P.PROD_COLOR, P.PROD_DESC, P.PROD_SIZE"
            //      + " FROM INVENTORY I, PRODUCT P"
            //        + " WHERE lower(" + GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD + ") LIKE '%" + GlobalMethods.GlobalMethods.VALUETOSEARCH2KEYWORD.ToLower() + "%' "
            //        + " AND I.LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION + " AND I.PROD_ID = P.PROD_ID "
            //        + " ORDER BY P.BE_SKU ASC, " + GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD + " ASC";
            string toSearchOrderItem ="";
            containsItems();
            if (itemsInOrder == false)
            {
                toSearchOrderItem = "SELECT * "
                + " FROM ORDERS O "
                + " WHERE " + baseword1 + " LIKE '%" + SearchKeyword1 + "%' AND O.LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION + " "
                //+ " lower(" + baseword2 + ") LIKE '%" + SearchKeyword2 + "%' "
                + " ORDER BY O.ORDER_ID DESC";
            }
            else
            {
                toSearchOrderItem = "SELECT DISTINCT O.ORDER_ID, O.USER_ID, O.ORDER_STATUS, O.LOCATION, O.EXPECTED_DT, O.CREATE_DT, O.SUBMIT_DT, O.RECEIVE_DT, O.PROCESS_DT, O.LOAD_DT, O.DELIVER_DT"
                + " FROM ORDERS O JOIN ORD_ITEM OI ON O.ORDER_ID = OI.ORDER_ID JOIN INVENTORY I ON OI.INV_ID = I.INV_ID JOIN PRODUCT P ON I.PROD_ID = P.PROD_ID"
                + " WHERE " + baseword1 + " LIKE '%" + SearchKeyword1 + "%' AND O.LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION + " AND "
                + " lower(" + baseword2 + ") LIKE '%" + SearchKeyword2 + "%' "
                + " ORDER BY O.ORDER_ID DESC";
            }


            OleDbCommand cmdOrdItem = new OleDbCommand(toSearchOrderItem, conn);
            OleDbDataAdapter odaOrdItem = new OleDbDataAdapter(cmdOrdItem);
            DataTable tableOrdItem = new DataTable();
            //MessageBox.Show(toSearchOrderItem);
            odaOrdItem.Fill(tableOrdItem);
            dataGridViewOrders.DataSource = tableOrdItem;
            ordSearchResult = dataGridViewOrders.Rows.Count;
            labelOrdSearchResult.Text = ordSearchResult.ToString();
        }

        //private void buttonOrdSearch_Click(object sender, EventArgs e)
        //{
        //    displayItemsBy();
        //}
        /*
         * 
         * 




        //Search (Existing) Order(s)
        public void fillOrderDGV(DateTime start, DateTime end)
        {

            //Variables to use


            startDate = dateTimePickerOrdSearchStart.Value;
            endDate = dateTimePickerOrdSearchEnd.Value;
            baseKind="";
            //DateTime startDate = dateTimePickerOrdSearchStart.Value;
            //DateTime endDate = dateTimePickerOrdSearchEnd.Value;

            int selectedIndexKind = comboBoxOrdSearch.SelectedIndex;


            dataGridViewOrders.AllowUserToAddRows = false; // To set allowance for DGV


            switch (selectedIndexKind)
            {
                case 0:
                    {
                        baseKind = "CREATE_DT";
                        break;
                    }
                case 1:
                    {
                        baseKind = "SUBMIT_DT";
                        break;
                    }
                case 2:
                    {
                        baseKind = "RECEIVE_DT";
                        break;
                    }
                case 3:
                    {
                        baseKind = "PROCESS_DT";
                        break;
                    }
                case 4:
                    {
                        baseKind = "LOAD_DT";
                        break;
                    }
                case 5:
                    {
                        baseKind = "DELIVER_DT";
                        break;
                    }


            }

            if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "1")
            {
                //buttonReceive.Visible = true;
                //buttonSubmitOrder.Visible = false;
                string toSearchOrderList = "SELECT * "
                        + "FROM ORDERS "
                    //    + "WHERE LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION + ""
                    // + "WHERE " + baseDateKind + " >= '" + start + "' AND "+ baseDateKind + " <= '" + end + "'"
                    //+ "'"+ start +"'"+ " AND " + "'"+end + "'"
                        + " ORDER BY ORDER_ID ASC, " + baseKind + " ASC ";
                OleDbCommand cmdOrder = new OleDbCommand(toSearchOrderList, conn);
                OleDbDataAdapter odaOrdItem = new OleDbDataAdapter(cmdOrder);
                DataTable tableOrdList = new DataTable();
                odaOrdItem.Fill(tableOrdList);
                dataGridViewOrders.DataSource = tableOrdList;
                ordSearchResult = tableOrdList.Rows.Count;
                labelOrdSearchResult.Text = ordSearchResult.ToString();
            }
            else if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "2")
            {
                buttonReceive.Visible = false;
                //buttonSubmitOrder.Visible = true;
                string toSearchOrderList = "SELECT * "
                        + "FROM ORDERS "
                        + "WHERE LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION + ""
                    // + "WHERE " + baseDateKind + " >= '" + start + "' AND "+ baseDateKind + " <= '" + end + "'"
                    //+ "'"+ start +"'"+ " AND " + "'"+end + "'"
                        + " ORDER BY ORDER_ID ASC, " + baseKind + " ASC ";
                OleDbCommand cmdOrder = new OleDbCommand(toSearchOrderList, conn);
                OleDbDataAdapter odaOrdItem = new OleDbDataAdapter(cmdOrder);
                DataTable tableOrdList = new DataTable();
                odaOrdItem.Fill(tableOrdList);
                dataGridViewOrders.DataSource = tableOrdList;
                ordSearchResult = tableOrdList.Rows.Count;
                labelOrdSearchResult.Text = ordSearchResult.ToString();
            }

            
        }         * */

        //Search orders by keyword
        private void buttonOrdSearch_Click(object sender, EventArgs e)
        {
            buttonAddItems.Visible = false;
            buttonRemove.Visible = false;
            buttonSubmitOrder.Visible = false;

            if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "2" || GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "1")
            {

                if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "2")
                {
                    dataGridViewOrders.DataSource = null;
                    labelOrdSearchResult.Text = "0";
                    isCreatedOrder();

                    if (orderCreated == false)
                    {
                        buttonCreateOrder.Visible = true;
                    }
                    else
                    {
                        buttonCreateOrder.Visible = false;
                    }
                }

                panelOrderView.Visible = true;
                panelOrdItemsView.Visible = false;
                displayItemsBy();
            }

            else
            {
                MessageBox.Show("Permission Denied.", "Authority Error");
            }

        }


        //Create New order
        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            conn.Open();
            
            //OleDbCommand cmd = new OleDbCommand("INSERT INTO ORDERS (ORDER_ID, USER_ID, ORDER_STATUS, LOCATION, EXPECTED_DT, CREATE_DT, SUBMIT_DT, RECEIVE_DT, PROCESS_DT, LOAD_DT, DELIVER_DT) "
            //                           + "VALUES(ORDER_ID_SEQ.nextVal,?,?,?,?,?,?,?,?,?,?)", conn);
            OleDbCommand cmd = new OleDbCommand("INSERT INTO ORDERS (ORDER_ID, USER_ID, ORDER_STATUS, LOCATION, CREATE_DT) "
                           + "VALUES(ORDER_ID_SEQ.nextVal,?,?,?,?)", conn);

            cmd.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USER_ID;
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = "CREATE";
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USERLOCATION;
            //cmd.Parameters.Add("?", OleDbType.Date).Value = "";
            cmd.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now;
            //cmd.Parameters.Add("?", OleDbType.Date).Value = "";
            //cmd.Parameters.Add("?", OleDbType.Date).Value = "";
            //cmd.Parameters.Add("?", OleDbType.Date).Value = "";
            //cmd.Parameters.Add("?", OleDbType.Date).Value = "";
            //cmd.Parameters.Add("?", OleDbType.Date).Value = "";

            //Run the Query and display message.
            DialogResult ins = MessageBox.Show("Do you want to Create a New Order?", "Create New Order Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ins == DialogResult.OK)
            {
                GlobalMethods.GlobalMethods.ExecMyQuery(cmd, "New data is successfully inserted");
                GlobalMethods.GlobalMethods.storeAudit("", "", "CREATE");
            }

            /*
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxSeasonID.Text))
                {
                    MessageBox.Show("The Season ID is not allowed left empty. Please try again.", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBoxSeasonID.Focus();
                }


                else if (seasonDateValidation())
                {
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
                textBoxSeasonID.Text = "";
                textBoxSeasonID.Focus();
            }
             */

            conn.Close();
            displayItemsBy();
            
        }

        //Check whether the created order is or not
        public bool isCreatedOrder()
        {
            conn.Open();

            string toSearchOrderCreated = "SELECT * "
                    + "FROM ORDERS "
                    + "WHERE ORDER_STATUS = 'CREATE' AND USER_ID = " + GlobalMethods.GlobalMethods.USER_ID + " AND LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION + "";

            OleDbCommand cmdOrd = new OleDbCommand(toSearchOrderCreated, conn);
            OleDbDataAdapter odaOrd = new OleDbDataAdapter(cmdOrd);
            DataTable tableOrdList = new DataTable();
            odaOrd.Fill(tableOrdList);
            dataGridViewOrders.DataSource = tableOrdList;
            ordCreatedNum = tableOrdList.Rows.Count;

            if(ordCreatedNum == 0)
            {
                conn.Close();
                return orderCreated = false;
                
            }
            else
            {
                conn.Close();
                return orderCreated = true;
                
            }

 
        }

        //check whether the order has items in it or not
        public bool containsItems()
        {
            conn.Open();

            //string toSearchOrderCreated = "SELECT * "
            //        + "FROM ORDERS "
            //        + "WHERE ORDER_STATUS = 'CREATE' AND USER_ID = " + GlobalMethods.GlobalMethods.USER_ID + " AND LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION + "";


            string toSearchOrderItem = "SELECT * "
                + "FROM ORD_ITEM "
                + "WHERE ORDER_ID = " + orderID + ""
                + " ORDER BY INV_ID";

            OleDbCommand cmdOrdItem = new OleDbCommand(toSearchOrderItem, conn);
            OleDbDataAdapter odaOrdItem = new OleDbDataAdapter(cmdOrdItem);
            DataTable tableOrdItemList = new DataTable();
            odaOrdItem.Fill(tableOrdItemList);

            int orditemsNum = tableOrdItemList.Rows.Count;

            if (orditemsNum == 0)
            {
                conn.Close();
                return itemsInOrder = false;

            }
            else
            {
                conn.Close();
                return itemsInOrder = true;

            }


        }



        //Display info when Clicked
        private void dataGridViewOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            orderID = Convert.ToInt32(dataGridViewOrders.CurrentRow.Cells[0].Value);
            ordStatus = dataGridViewOrders.CurrentRow.Cells[2].Value.ToString();

            if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "1")
            {
                if (ordStatus == "CREATE")
                {
                    buttonAddItems.Visible = false;
                    buttonRemove.Visible = false;
                    buttonSubmitOrder.Visible = false;
                    buttonRemove.Enabled = false;
                    buttonReceive.Visible = false;
                }
                else if(ordStatus =="SUBMIT")
                {
                    buttonAddItems.Visible = false;
                    buttonRemove.Visible = false;
                    buttonSubmitOrder.Visible = false;
                    buttonReceive.Visible = true;
                }

            }
            if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "2")
            {
                if (ordStatus == "CREATE")
                {
                    buttonAddItems.Visible = true;
                    buttonRemove.Visible = true;
                    buttonSubmitOrder.Visible = true;
                    buttonRemove.Enabled = false;
                    buttonReceive.Visible = false;
                }
                else
                {
                    buttonAddItems.Visible = false;
                    buttonRemove.Visible = false;
                    buttonSubmitOrder.Visible = false;
                    buttonReceive.Visible = false;
                }

            }


            diplayOrderItems();
            panelOrdItemsView.Visible = true;

        }

        //Display orders in DGV
        public void diplayOrderItems()
        {
            string toSearchOrderItem = "SELECT * "
                    + "FROM ORD_ITEM "
                    + "WHERE ORDER_ID = " + orderID +""
                    + " ORDER BY INV_ID" ;

            OleDbCommand cmdOrdItem = new OleDbCommand(toSearchOrderItem, conn);
            OleDbDataAdapter odaOrdItem = new OleDbDataAdapter(cmdOrdItem);
            DataTable tableOrdItemList = new DataTable();
            odaOrdItem.Fill(tableOrdItemList);
            dataGridViewOrdItems.DataSource = tableOrdItemList;
            ordItemNum = tableOrdItemList.Rows.Count;
            labelOrdItemResult.Text = ordItemNum.ToString();

            //if (dataGridViewOrdItems.RowCount > 0)
            //{
            //    existingQOH = Convert.ToInt32(dataGridViewOrdItems.CurrentRow.Cells[3].Value);
            //}


        }

        //Add an Item
        private void buttonAddItems_Click(object sender, EventArgs e)
        {
            formAddOrderItems addItems = new formAddOrderItems();
            this.Hide();
            addItems.ShowDialog();
            this.Show();
            diplayOrderItems();
           // this.Refresh();
        }


        //View Detail Order Information
        private void dataGridViewOrdItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                //orderID = Convert.ToInt32(dataGridViewOrdItems.CurrentRow.Cells[1].Value.ToString());
                invID = Convert.ToInt32(dataGridViewOrdItems.CurrentRow.Cells[1].Value.ToString());
                //formOrderListOnly ordList = new formOrderListOnly();
                //ordList.ShowDialog();
                buttonAddItems.Enabled = true;
                buttonRemove.Enabled = true;
                buttonSubmitOrder.Enabled = true;


        }

        //Remove ordered item from the database when seleced
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            string delItem = "DELETE FROM ORD_ITEM "
                + "WHERE ORDER_ID = " + orderID + ""
                + "AND INV_ID = " + invID + "";
            OleDbCommand cmdDeleteItem = new OleDbCommand(delItem, conn);
            OleDbDataAdapter odaDeleteItem = new OleDbDataAdapter(cmdDeleteItem);
            DataTable tableDeleteItem = new DataTable();
            odaDeleteItem.Fill(tableDeleteItem);
            //dataGridViewOrderDetail.DataSource = tableDeleteItem;

            DialogResult ins = MessageBox.Show("Do you want to delete Item from Order? ", "Item Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
            if (ins == DialogResult.Yes)
            {
                conn.Open();
                cmdDeleteItem.ExecuteNonQuery();
                conn.Close();
                diplayOrderItems();
            }
            else
            {
                //conn.Close();
            }

        }

        //Submit order by Access Level 2
        private void buttonSubmitOrder_Click(object sender, EventArgs e)
        {
            DialogResult ins = MessageBox.Show("Do you want to submit an Order? ", "Order Submission", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
            if (ins == DialogResult.Yes)
            {
                // MessageBox.Show(newInvLocation.ToString() + prodID); //Debug purpose
                conn.Open();
                //to make entry of QOH
                string submitOrder = "UPDATE ORDERS SET ORDER_STATUS =?, EXPECTED_DT = ?, SUBMIT_DT =? "
                        + " WHERE ORDER_ID = " + Orders.formOrders.orderID + ""
                        + " AND LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION +"";

                OleDbCommand cmdsubmitOrder = new OleDbCommand(submitOrder, conn);
                // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());

                cmdsubmitOrder.Parameters.Add("?", OleDbType.VarChar).Value = "SUBMIT";
                cmdsubmitOrder.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now.AddDays(7);
                cmdsubmitOrder.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now;

                //MessageBox.Show(updateQOH);
                cmdsubmitOrder.ExecuteNonQuery();
                diplayOrderItems();
                conn.Close();

                GlobalMethods.GlobalMethods.storeAudit("","","SUBMIT");
                buttonOrdSearch.PerformClick();


            }
            else
            {
                // conn.Close();
            }
        }


    }
}
