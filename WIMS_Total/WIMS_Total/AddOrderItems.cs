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
using Orders;
using OrderListDetail;

namespace AddOrderItems
{
    public partial class formAddOrderItems : Form
    {
        public formAddOrderItems()
        {
            InitializeComponent();
            //locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
        }

        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");
        //;Integrated Security=SSPI

        int searchedItemsNum;
        int oldOrdQty;
        string originalUserID = GlobalMethods.GlobalMethods.USER_ID;
        string originalUserLocation = GlobalMethods.GlobalMethods.USERLOCATION;
        string tempUserID ="000000";
        string invID;
        string orderID;


        private void formAddOrderItems_Load(object sender, EventArgs e)
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 10;
            toolTip1.ReshowDelay = 500;

            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.pictureBoxDownGreen, "Click to Add Item to Order");

            labelInfo.Text = GlobalMethods.GlobalMethods.USERFULLNAME + "  " + "User ID: " + GlobalMethods.GlobalMethods.USER_ID + " Location:" + GlobalMethods.GlobalMethods.USER_LOCATION_NAME;
            comboBoxOrdSearch.SelectedIndex = 3;
            panelOrdItemsView.Visible = false;
            pictureBoxDownPink.Visible = false;
            pictureBoxDownPink.BackColor = Color.Transparent;
            pictureBoxDownGreen.Visible = false;
            pictureBoxDownGreen.BackColor = Color.Transparent;
            pictureBoxDownBlue.Visible = false;
            pictureBoxDownBlue.BackColor = Color.Transparent;
            pictureBoxDownYellow.Visible = false;
            pictureBoxDownYellow.BackColor = Color.Transparent;
            diplayOrderItems();
            buttonRemove.Enabled = false;
            panelMDetail.Visible = false;
            buttonModItem.Enabled = false;
            textBoxOrdSearchKeyword.BackColor = Color.Yellow;
            textBoxOrdSearchKeyword.Focus();
            panelBasicOrdForm.Visible = false;

        }

       


        //Search Items to Add into the order
        private void buttonOrdSearch_Click(object sender, EventArgs e)
        {
            buttonRemove.Enabled = false;
            buttonModItem.Enabled = false;
            panelMDetail.Visible = false;

            panelOrdItemsView.Visible = true;
            pictureBoxDownPink.Visible = false;
            pictureBoxDownGreen.Visible = false;
            pictureBoxDownBlue.Visible = false;
            pictureBoxDownYellow.Visible = false;
            panelBasicOrdForm.Visible = false;

            diplayOrderItems();
            if (comboBoxOrdSearch.SelectedIndex == 0)
            {
                defaultItemListsToOrder();
                labelSearchItemResult.Text = searchedItemsNum.ToString();

            }

            else if (comboBoxOrdSearch.SelectedIndex == 1)
            {
                scannerItemListsToOrder();
                labelSearchItemResult.Text = searchedItemsNum.ToString();
            }
            else
            {

                displayItemsBy(textBoxOrdSearchKeyword.Text);
                GlobalMethods.GlobalMethods.USER_ID = originalUserID;
                labelSearchItemResult.Text = searchedItemsNum.ToString();
            }



            //panelOrdItemsView.Visible = true;

        }



        //Search BY keywords(INV_ID, BE_SKU, SUP_SKU)
        public void displayItemsBy(string valueTosearch2)
        {
            //if (comboBoxOrdSearch.SelectedIndex = null)
            //{
            //    comboBoxOrdSearch.SelectedIndex = 0;
            //}
            ////Variables to use
            //int ordItemSearchResult;

            int selectedIndexKind = comboBoxOrdSearch.SelectedIndex;
            GlobalMethods.GlobalMethods.VALUETOSEARCH2KEYWORD = valueTosearch2;

            dataGridViewSearchedItems.AllowUserToAddRows = false; // To set allowance for DGV


            switch (selectedIndexKind)
            {
                case 2:
                    {
                        GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD = "I.INV_ID";
                        break;
                    }
                case 3:
                    {
                        GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD = "P.BE_SKU";
                        break;
                    }
                case 4:
                    {
                        GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD = "P.SUP_SKU";
                        break;
                    }

            }


            string toSearchOrderItem = "SELECT I.INV_ID, P.BE_SKU,  I.QOH, ROUND((I.MAX_QTY - I.QOH) / P.CASE_COUNT) AS Req_Case_QTY, P.PROD_NAME, P.PROD_COLOR, P.PROD_DESC, P.PROD_SIZE"
                  + " FROM INVENTORY I, PRODUCT P"
                    + " WHERE lower(" + GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD + ") LIKE '%" + GlobalMethods.GlobalMethods.VALUETOSEARCH2KEYWORD.ToLower() + "%' "
                    + " AND I.LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION + " AND I.PROD_ID = P.PROD_ID "
                    + " ORDER BY P.BE_SKU ASC, " + GlobalMethods.GlobalMethods.VALUETOSEARCH1KEYWORD + " ASC";

            OleDbCommand cmdOrdItem = new OleDbCommand(toSearchOrderItem, conn);
            OleDbDataAdapter odaOrdItem = new OleDbDataAdapter(cmdOrdItem);
            DataTable tableOrdItem = new DataTable();
            //MessageBox.Show(toSearchOrderItem);
            odaOrdItem.Fill(tableOrdItem);
            dataGridViewSearchedItems.DataSource = tableOrdItem;
            searchedItemsNum = dataGridViewSearchedItems.Rows.Count;
            labelSearchItemResult.Text = searchedItemsNum.ToString();
        }

        //Search Default Order lists
        public void defaultItemListsToOrder()
        {
            String defaultOrdSql = "SELECT I.INV_ID, P.BE_SKU,  I.QOH, ROUND((I.MAX_QTY - I.QOH) / P.CASE_COUNT) AS Req_Case_QTY, P.PROD_NAME, P.PROD_COLOR, P.PROD_DESC, P.PROD_SIZE"
                  + " FROM INVENTORY I, PRODUCT P"
                  + " WHERE I.QOH < I.MIN_QTY AND P.PROD_ID = I.PROD_ID AND I.LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION +"";
            OleDbCommand cmddefaultItem = new OleDbCommand(defaultOrdSql, conn);
            OleDbDataAdapter odadefaultItem = new OleDbDataAdapter(cmddefaultItem);
            DataTable tableDefaultItem = new DataTable();
            odadefaultItem.Fill(tableDefaultItem);
            dataGridViewSearchedItems.DataSource = tableDefaultItem;
            searchedItemsNum = dataGridViewSearchedItems.Rows.Count;
            labelSearchItemResult.Text = searchedItemsNum.ToString();
        }



        //Search Manager Order lists (from Scanner)
        public void scannerItemListsToOrder()
        {
            String scannerItemListstoOrdSql = "SELECT DISTINCT AO.INV_ID, P.BE_SKU,  I.QOH, AO.REQ_QTY AS ORD_QTY, P.PROD_NAME, P.PROD_COLOR, P.PROD_DESC, P.PROD_SIZE"
                  + " FROM ADD_ORDER AO, INVENTORY I, PRODUCT P, USERS U"
                  + " WHERE AO.INV_ID = I.INV_ID AND P.PROD_ID = I.PROD_ID AND I.LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION + ""
                  + " AND AO.USER_ID = " + GlobalMethods.GlobalMethods.USER_ID + ""
                  + " ORDER BY P.BE_SKU ASC, AO.INV_ID ASC";
            OleDbCommand cmdScannedItem = new OleDbCommand(scannerItemListstoOrdSql, conn);
            OleDbDataAdapter odaScannedItem = new OleDbDataAdapter(cmdScannedItem);
            DataTable tableScannedItem = new DataTable();
            odaScannedItem.Fill(tableScannedItem);
            dataGridViewSearchedItems.DataSource = tableScannedItem;
            searchedItemsNum = dataGridViewSearchedItems.Rows.Count;
        }


        ////Search Items from the scanner
        //public void ScannedItems()
        //{
        //    String scannedOrdSql = "SELECT I.INV_ID, P.BE_SKU,  I.QOH, ROUND((I.MAX_QTY - A.REQ_QTY) / P.CASE_COUNT) AS Req_Case_QTY, P.PROD_NAME, P.PROD_COLOR, P.PROD_DESC, P.PROD_SIZE"
        //          + " FROM ADD_ORDER A, INVENTORY I, PRODUCT P, USERS U"
        //          + " WHERE I.QOH < I.MIN_QTY AND P.PROD_ID = I.PROD_ID AND I.LOCATION = (SELECT LOCATION FROM USERS WHERE A.USER_ID = U.USER_ID";
        //    OleDbCommand cmdScannedItem = new OleDbCommand(scannedOrdSql, conn);
        //    OleDbDataAdapter odaScannedItem = new OleDbDataAdapter(cmdScannedItem);
        //    DataTable tableScannedItem = new DataTable();
        //    odaScannedItem.Fill(tableScannedItem);
        //    dataGridViewSearchedItems.DataSource = tableScannedItem;
        //    searchedItemsNum = dataGridViewSearchedItems.Rows.Count;
        //}



        //Selects all checkboxes in datagridview
        public void selectAll(){
            //check all items in Datagridview
            foreach (DataGridViewRow rows in dataGridViewSearchedItems.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)rows.Cells[0];
                if (chk.Selected == false)
                {
                    chk.Selected = true;
                }

            }

        }


        // check whether inventory exists.
        public bool isInventory(string inv_ID)
        {
            conn.Open();
            int isInvNum;
            string isInv = "SELECT * "
                    + "FROM INVENTORY "
                    + "WHERE INV_ID LIKE LIKE '%" + inv_ID + "%' ";

            OleDbCommand cmdInv = new OleDbCommand(isInv, conn);
            OleDbDataAdapter odaInv = new OleDbDataAdapter(cmdInv);
            DataTable tableInvList = new DataTable();
            odaInv.Fill(tableInvList);
           // dataGridViewSearchedItems.DataSource = tableInvList;
            isInvNum = tableInvList.Rows.Count;




            if (isInvNum == 0)
            {
                conn.Close();
                return false;

            }
            else
            {
                conn.Close();
                return true;

            }

        }

        //Check whether Product with BE_SKU exists
        public bool isBESKU(string beSKU)
        {
            conn.Open();
            int isbeSKUNum;
            string isBESKU = "SELECT * "
                    + "FROM Product "
                    + "WHERE BE_SKU LIKE '%" + beSKU + "%' ";

            OleDbCommand cmdBESKU = new OleDbCommand(isBESKU, conn);
            OleDbDataAdapter odaBESKU = new OleDbDataAdapter(cmdBESKU);
            DataTable tableBESKUList = new DataTable();
            odaBESKU.Fill(tableBESKUList);
            dataGridViewSearchedItems.DataSource = tableBESKUList;
            isbeSKUNum = tableBESKUList.Rows.Count;




            if (isbeSKUNum == 0)
            {
                conn.Close();
                return false;

            }
            else
            {
                conn.Close();
                return true;

            }

        }

        //Check whether Order Item exists
        public bool isOrderItem(string INV_ID)
        {
           // conn.Open();
            int isOrderItem;
            string ISOrderItemSQL = "SELECT * "
                    + "FROM ORD_ITEM "
                    + "WHERE INV_ID = " + INV_ID + " AND ORDER_ID = " + Orders.formOrders.orderID + "";

            OleDbCommand cmdOrderItem = new OleDbCommand(ISOrderItemSQL, conn);
            OleDbDataAdapter odaOrderItem = new OleDbDataAdapter(cmdOrderItem);
            DataTable tableOrderItemList = new DataTable();
            odaOrderItem.Fill(tableOrderItemList);
            //dataGridViewSearchedItems.DataSource = tableSUPSKUList;
            isOrderItem = tableOrderItemList.Rows.Count;

            
            if (isOrderItem == 0)
            {
                conn.Close();
                return false;

            }
            else
            {
                conn.Close();
                return true;

            }

        }

        //Check whether Product with SUP_SKU exists
        public bool isSUPKU(string SUP_SKU)
        {
            conn.Open();
            int isSUPSKUNum;
            string isBESKU = "SELECT * "
                    + "FROM Product "
                    + "WHERE SUP_SKU LIKE '%" + SUP_SKU + "%' ";

            OleDbCommand cmdSUPSKU = new OleDbCommand(isBESKU, conn);
            OleDbDataAdapter odaSUPSKU = new OleDbDataAdapter(cmdSUPSKU);
            DataTable tableSUPSKUList = new DataTable();
            odaSUPSKU.Fill(tableSUPSKUList);
            dataGridViewSearchedItems.DataSource = tableSUPSKUList;
            isSUPSKUNum = tableSUPSKUList.Rows.Count;




            if (isSUPSKUNum == 0)
            {
                conn.Close();
                return false;

            }
            else
            {
                conn.Close();
                return true;

            }

        }

        ////select all checkbox checked
        private void dataGridViewSearchedItems_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridViewSearchedItems.Rows)
            {
                row.Cells[0].Value = row.Cells[0].Value == null ? false : row.Cells[0].Value;
            }
        }

        //insert searched data into the ORD_ITEM table and refresh
        private void pictureBoxDown_Click(object sender, EventArgs e)
        {
            panelBasicOrdForm.Visible = true;
            GlobalMethods.GlobalMethods.USER_ID = originalUserID;
            string addItems = "INSERT INTO ORD_ITEM (ORDER_ID, INV_ID, ORD_QTY, QTY_DELIVERD, BACK_ORD, USER_ID, PALLET_ID, ASM_USER)"
                     + "VALUES(?, ?, ?, ?, ?, ?, ?, ?)";

            OleDbCommand cmdAddItem = new OleDbCommand(addItems, conn);

            //allocate appropriate entry for controls
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = Orders.formOrders.orderID;
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = dataGridViewSearchedItems.CurrentRow.Cells[0].Value.ToString();
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = textBoxNewOrdCaseQty.Text;
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USER_ID;
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";

            try
            {
                if (isOrderItem(dataGridViewSearchedItems.CurrentRow.Cells[0].Value.ToString()) == false)
                {
                    if (textBoxNewOrdCaseQty.Text == "")
                    {
                        MessageBox.Show("Please input case QTY to order or modify.", "Input Recommentation");
                        textBoxNewOrdCaseQty.Focus();
                    }
                    else
                    {
                        // GlobalMethods.GlobalMethods.ExecMyQuery(cmdAddItem, "inseted");
                        conn.Open();
                        cmdAddItem.ExecuteNonQuery();
                        conn.Close();
                        pictureBoxDownGreen.Visible = false;
                        diplayOrderItems();                    
                    }

                }
                else
                {
                    if (textBoxNewOrdCaseQty.Text == "")
                    {
                        MessageBox.Show("Please input case QTY to order or modify.", "Input Recommentation");
                        textBoxNewOrdCaseQty.Focus();
                    }
                    else
                    {
                        String newdupItemsSql = "SELECT ORD_QTY AS OLD_ORD_Case_QTY"
                            + " FROM ORD_ITEM OI JOIN INVENTORY I ON OI.INV_ID = I.INV_ID JOIN PRODUCT P ON I.PROD_ID = P.PROD_ID"
                            + " WHERE OI.ORDER_ID = " + Orders.formOrders.orderID + " AND OI.INV_ID = "
                            + dataGridViewSearchedItems.CurrentRow.Cells[0].Value.ToString() + "";
                        OleDbCommand cmdDupItem = new OleDbCommand(newdupItemsSql, conn);
                        OleDbDataAdapter odaDupAddingItem = new OleDbDataAdapter(cmdDupItem);
                        DataTable tableDupAddingItem = new DataTable();
                        odaDupAddingItem.Fill(tableDupAddingItem);
                        oldOrdQty = Convert.ToInt32(tableDupAddingItem.Rows[0][0].ToString());
                        // MessageBox.Show(oldOrdQty.ToString());



                        DialogResult ins = MessageBox.Show("Some(or An) Order item(s) exist(s) already. Do you just want to update Order QTY? ", "Item Duplication", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
                        if (ins == DialogResult.Yes)
                        {
                            // MessageBox.Show(newInvLocation.ToString() + prodID); //Debug purpose
                            conn.Open();
                            //to make entry of QOH

                            string updateQOH = "UPDATE ORD_ITEM SET ORD_QTY = ?, USER_ID = ? "
                                    + " WHERE ORDER_ID = " + Orders.formOrders.orderID + ""
                                    + " AND INV_ID = " + dataGridViewSearchedItems.CurrentRow.Cells[0].Value + "";

                            OleDbCommand cmdUpdate = new OleDbCommand(updateQOH, conn);
                            // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());
                            //int newOrdQTY = Convert.ToInt32(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());
                            int newOrdQTY = Convert.ToInt32(textBoxNewOrdCaseQty.Text);

                            cmdUpdate.Parameters.Add("?", OleDbType.VarChar).Value = (oldOrdQty + newOrdQTY);
                            cmdUpdate.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USER_ID;

                            //MessageBox.Show(updateQOH);
                            cmdUpdate.ExecuteNonQuery();
                            pictureBoxDownGreen.Visible = false;
                            diplayOrderItems();
                            //conn.Close();

                        }
                        else
                        {
                            // conn.Close();
                        }
                    }


                }
            }
            catch(OleDbException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                pictureBoxDownGreen.Visible = false;
            }
            //pictureBoxDownGreen.Visible = false;
            

        }


        //Display Order Items
        public void diplayOrderItems()
        {
            String newOrdItemsSql = "SELECT I.INV_ID, P.BE_SKU, I.QOH, ROUND((I.MAX_QTY - I.QOH) / P.CASE_COUNT) Req_Case_QTY, OI.ORD_QTY, P.CASE_COUNT, (OI.ORD_QTY*P.CASE_COUNT) AS Ordered_Tot_Units, OI.USER_ID, P.PROD_NAME, P.PROD_COLOR, P.PROD_DESC, P.PROD_SIZE"
                  + " FROM ORD_ITEM OI, INVENTORY I, PRODUCT P"
                  + " WHERE OI.ORDER_ID = " + Orders.formOrders.orderID + " AND OI.INV_ID = I.INV_ID AND I.PROD_ID = P.PROD_ID"
                  + " ORDER BY P.BE_SKU ASC, OI.INV_ID ASC";
            OleDbCommand cmdafterAddingItem = new OleDbCommand(newOrdItemsSql, conn);
            OleDbDataAdapter odaafterAddingItem = new OleDbDataAdapter(cmdafterAddingItem);
            DataTable tableafterAddingItem = new DataTable();
            odaafterAddingItem.Fill(tableafterAddingItem);
            dataGridViewAddedOrderItems.DataSource = tableafterAddingItem;
            labelOrderedItemsNum.Text = dataGridViewAddedOrderItems.Rows.Count.ToString();

        }

        //Search detail information when clicked
        public void dataGridViewSearchedItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBoxDownPink.Visible = false;
            pictureBoxDownGreen.Visible = false;
            pictureBoxDownBlue.Visible = false;
            pictureBoxDownYellow.Visible = false;

            if (comboBoxOrdSearch.SelectedIndex == 0)
            {
                //buttonOrdSearch_Click(sender, e);
                DialogResult ins = MessageBox.Show("If you want to add all Items at once, choose 'Yes' or want to add 1 Item, choose 'No'", "How to Add?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning); ;
                if (ins == DialogResult.Yes)
                {
                    DialogResult ins2 = MessageBox.Show("All Duplicated Item Order QTYs will be added. Continue?", "Data update Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning); ;
                    if (ins2 == DialogResult.Yes)
                    {
                        pictureBoxDownPink.Visible = true;
                    }
                    else if (ins2 == DialogResult.No)
                    {
                        MessageBox.Show("Please choose an Item again.", "Selection Warning");
                    }

                }
                else if (ins == DialogResult.No)
                {
                    pictureBoxDownYellow.Visible = true;
                }
                else
                {
                    pictureBoxDownPink.Visible = false;
                    pictureBoxDownGreen.Visible = false;
                    pictureBoxDownBlue.Visible = false;
                    pictureBoxDownYellow.Visible = false;
                }
                GlobalMethods.GlobalMethods.USER_ID = tempUserID;
            }
            else if (comboBoxOrdSearch.SelectedIndex == 1)
            {
                pictureBoxDownBlue.Visible = true;
                GlobalMethods.GlobalMethods.USER_ID = originalUserID;
            }
            else
            {
                panelBasicOrdForm.Visible = true;
                pictureBoxDownGreen.Visible = true;
                GlobalMethods.GlobalMethods.USER_ID = originalUserID;
            }

        }


        //Remove an order item from database
        private void buttonRemove_Click(object sender, EventArgs e)
        {

            string delItem = "DELETE FROM ORD_ITEM "
                + "WHERE ORDER_ID = " + Orders.formOrders.orderID + ""
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


        //Change value when a form closed
        private void formAddOrderItems_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalMethods.GlobalMethods.USER_ID = originalUserID;
        }


        //Display Items when clicked
        private void dataGridViewAddedOrderItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //orderID =dataGridViewAddedOrderItems.CurrentRow.Cells[1].Value.ToString();
            invID = dataGridViewAddedOrderItems.CurrentRow.Cells[0].Value.ToString();
            //formOrderListOnly ordList = new formOrderListOnly();
            //ordList.ShowDialog();
            buttonRemove.Enabled = true;
            buttonModItem.Enabled = true;
            panelMDetail.Enabled = true;
            panelMDetail.Visible = false;



        }


        //Modify exisiting Order QTY
        private void buttonModItem_Click(object sender, EventArgs e)
        {
            buttonRemove.Enabled = false;
            panelMDetail.Visible = true;
            buttonModItem.Enabled = false;
            textBoxMInvID.Enabled = false;
            textBoxMBE_SKU.Enabled = false;
            textBoxMSUP_SKU.Enabled = false;
            textBoxModQTY.BackColor = Color.Yellow;
            textBoxModQTY.Focus();


            textBoxMInvID.Text = dataGridViewAddedOrderItems.CurrentRow.Cells[0].Value.ToString();
            textBoxMBE_SKU.Text = dataGridViewAddedOrderItems.CurrentRow.Cells[1].Value.ToString();
            textBoxMSUP_SKU.Text = dataGridViewAddedOrderItems.CurrentRow.Cells[5].Value.ToString();
            textBoxModQTY.Text = dataGridViewAddedOrderItems.CurrentRow.Cells[4].Value.ToString();
            textBoxModQTY.Enabled = true;
        }

        //Add 1 item at one time
        private void pictureBoxDownYellow_Click(object sender, EventArgs e)
        {
            string addItems = "INSERT INTO ORD_ITEM (ORDER_ID, INV_ID, ORD_QTY, QTY_DELIVERD, BACK_ORD, USER_ID, PALLET_ID, ASM_USER)"
         + "VALUES(?, ?, ?, ?, ?, ?, ?, ?)";

            OleDbCommand cmdAddItem = new OleDbCommand(addItems, conn);

            //allocate appropriate entry for controls
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = Orders.formOrders.orderID;
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = dataGridViewSearchedItems.CurrentRow.Cells[0].Value.ToString();
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString();
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USER_ID;
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";

            try
            {
                if (isOrderItem(dataGridViewSearchedItems.CurrentRow.Cells[0].Value.ToString()) == false)
                {

                    // GlobalMethods.GlobalMethods.ExecMyQuery(cmdAddItem, "inseted");
                    conn.Open();
                    cmdAddItem.ExecuteNonQuery();
                    conn.Close();
                    diplayOrderItems();
                }
                else
                {
                    //String newdupItemsSql = "SELECT ORD_QTY AS OLD_ORD_Case_QTY"
                    //    + " FROM ORD_ITEM OI JOIN INVENTORY I ON OI.INV_ID = I.INV_ID JOIN PRODUCT P ON I.PROD_ID = P.PROD_ID"
                    //    + " WHERE OI.ORDER_ID = " + Orders.formOrders.orderID + " AND OI.INV_ID = "
                    //    + dataGridViewSearchedItems.CurrentRow.Cells[0].Value.ToString() + "";
                    //OleDbCommand cmdDupItem = new OleDbCommand(newdupItemsSql, conn);
                    //OleDbDataAdapter odaDupAddingItem = new OleDbDataAdapter(cmdDupItem);
                    //DataTable tableDupAddingItem = new DataTable();
                    //odaDupAddingItem.Fill(tableDupAddingItem);
                    //oldOrdQty = Convert.ToInt32(tableDupAddingItem.Rows[0][0].ToString());
                    //// MessageBox.Show(oldOrdQty.ToString());

                    //DialogResult ins = MessageBox.Show("Some(or An) Order item(s) exist(s) already. Do you just want to update Order QTY? ", "Item Duplication", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
                    //if (ins == DialogResult.Yes)
                    //{
                    //    // MessageBox.Show(newInvLocation.ToString() + prodID); //Debug purpose
                    //    conn.Open();
                    //    //to make entry of QOH
                    //    string updateQOH = "UPDATE ORD_ITEM SET ORD_QTY = ?, USER_ID = ? "
                    //            + " WHERE ORDER_ID = " + Orders.formOrders.orderID + ""
                    //            + " AND INV_ID = " + dataGridViewSearchedItems.CurrentRow.Cells[0].Value + "";

                    //    OleDbCommand cmdUpdate = new OleDbCommand(updateQOH, conn);
                    //    // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());
                    //    int newOrdQTY = Convert.ToInt32(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());
                    //    cmdUpdate.Parameters.Add("?", OleDbType.VarChar).Value = (oldOrdQty + newOrdQTY);
                    //    cmdUpdate.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USER_ID;

                    //    //MessageBox.Show(updateQOH);
                    //    cmdUpdate.ExecuteNonQuery();
                    //    diplayOrderItems();
                    //    //conn.Close();
                    //}
                    //else
                    //{
                    //    // conn.Close();
                    //}

                    pictureBoxDown_Click(sender, e);
                   // conn.Close();
                    
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            pictureBoxDownYellow.Visible = false;
            conn.Close();
        }

        //insert order items into database
        private void pictureBoxDownBlue_Click(object sender, EventArgs e)
        {
            string addItems = "INSERT INTO ORD_ITEM (ORDER_ID, INV_ID, ORD_QTY, QTY_DELIVERD, BACK_ORD, USER_ID, PALLET_ID, ASM_USER)"
         + "VALUES(?, ?, ?, ?, ?, ?, ?, ?)";

            OleDbCommand cmdAddItem = new OleDbCommand(addItems, conn);

            //allocate appropriate entry for controls
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = Orders.formOrders.orderID;
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = dataGridViewSearchedItems.CurrentRow.Cells[0].Value.ToString();
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString();
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USER_ID;
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";
            cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";

            try
            {
                if (isOrderItem(dataGridViewSearchedItems.CurrentRow.Cells[0].Value.ToString()) == false)
                {

                    // GlobalMethods.GlobalMethods.ExecMyQuery(cmdAddItem, "inseted");
                    conn.Open();
                    cmdAddItem.ExecuteNonQuery();
                    conn.Close();
                    diplayOrderItems();
                    //delete Manager Item after adding on Order List
                    string delMgrItem = "DELETE FROM ADD_ORDER "
                        + "WHERE USER_ID = " + GlobalMethods.GlobalMethods.USER_ID + ""
                        + " AND INV_ID = " + dataGridViewSearchedItems.CurrentRow.Cells[0].Value.ToString() + "";
                    OleDbCommand cmdMgrDeleteItem = new OleDbCommand(delMgrItem, conn);
                    //OleDbDataAdapter odaMgrDeleteItem = new OleDbDataAdapter(cmdMgrDeleteItem);
                    //DataTable tableDeleteItem = new DataTable();
                    //odaMgrDeleteItem.Fill(tableDeleteItem);
                    //dataGridViewOrderDetail.DataSource = tableDeleteItem;
                    try
                    {
                        conn.Open();
                        cmdMgrDeleteItem.ExecuteNonQuery();
                        conn.Close();
                        scannerItemListsToOrder();
                        labelSearchItemResult.Text = searchedItemsNum.ToString();

                    }
                    catch (OleDbException exi)
                    {
                        MessageBox.Show(exi.Message.ToString());
                    }
                }
                else
                {
                    String newdupItemsSql = "SELECT ORD_QTY AS OLD_ORD_Case_QTY"
                        + " FROM ORD_ITEM OI JOIN INVENTORY I ON OI.INV_ID = I.INV_ID JOIN PRODUCT P ON I.PROD_ID = P.PROD_ID"
                        + " WHERE OI.ORDER_ID = " + Orders.formOrders.orderID + " AND OI.INV_ID = "
                        + dataGridViewSearchedItems.CurrentRow.Cells[0].Value.ToString() + "";
                    OleDbCommand cmdDupItem = new OleDbCommand(newdupItemsSql, conn);
                    OleDbDataAdapter odaDupAddingItem = new OleDbDataAdapter(cmdDupItem);
                    DataTable tableDupAddingItem = new DataTable();
                    odaDupAddingItem.Fill(tableDupAddingItem);
                    oldOrdQty = Convert.ToInt32(tableDupAddingItem.Rows[0][0].ToString());
                    // MessageBox.Show(oldOrdQty.ToString());

                    DialogResult ins = MessageBox.Show("Some(or An) Order item(s) exist(s) already. Do you just want to update Order QTY? ", "Item Duplication", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
                    if (ins == DialogResult.Yes)
                    {
                        // MessageBox.Show(newInvLocation.ToString() + prodID); //Debug purpose
                        conn.Open();
                        //to make entry of QOH
                        string updateQOH = "UPDATE ORD_ITEM SET ORD_QTY = ?, USER_ID = ? "
                                + " WHERE ORDER_ID = " + Orders.formOrders.orderID + ""
                                + " AND INV_ID = " + dataGridViewSearchedItems.CurrentRow.Cells[0].Value + "";

                        OleDbCommand cmdUpdate = new OleDbCommand(updateQOH, conn);
                        // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());
                        int newOrdQTY = Convert.ToInt32(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());
                        cmdUpdate.Parameters.Add("?", OleDbType.VarChar).Value = (oldOrdQty + newOrdQTY);
                        cmdUpdate.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USER_ID;

                        //MessageBox.Show(updateQOH);
                        cmdUpdate.ExecuteNonQuery();
                        diplayOrderItems();
                        conn.Close();

                        //delete Manager Item after adding on Order List
                        string delMgrItem = "DELETE FROM ADD_ORDER "
                            + "WHERE USER_ID = " + GlobalMethods.GlobalMethods.USER_ID + ""
                            + " AND INV_ID = " + dataGridViewSearchedItems.CurrentRow.Cells[0].Value.ToString() + "";
                        OleDbCommand cmdMgrDeleteItem = new OleDbCommand(delMgrItem, conn);
                        //OleDbDataAdapter odaMgrDeleteItem = new OleDbDataAdapter(cmdMgrDeleteItem);
                        //DataTable tableDeleteItem = new DataTable();
                        //odaMgrDeleteItem.Fill(tableDeleteItem);
                        //dataGridViewOrderDetail.DataSource = tableDeleteItem;
                        try
                        {
                            conn.Open();
                            cmdMgrDeleteItem.ExecuteNonQuery();
                            conn.Close();
                            scannerItemListsToOrder();
                            labelSearchItemResult.Text = searchedItemsNum.ToString();

                        }
                        catch (OleDbException exi)
                        {
                            MessageBox.Show(exi.Message.ToString());
                        }
                    }
                    else
                    {
                        // conn.Close();
                        pictureBoxDown_Click(sender, e);
                        pictureBoxDownGreen.Visible = true;
                    }
                }




            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            pictureBoxDownBlue.Visible = false;
        }
        //change value when combobox index changed
        private void comboBoxOrdSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalMethods.GlobalMethods.USER_ID = originalUserID;
            GlobalMethods.GlobalMethods.USERLOCATION = originalUserLocation;
            dataGridViewSearchedItems.DataSource = null;
            panelOrdItemsView.Visible = false;
            pictureBoxDownPink.Visible = false;
            pictureBoxDownGreen.Visible = false;
            pictureBoxDownBlue.Visible = false;
            pictureBoxDownYellow.Visible = false;


            if (comboBoxOrdSearch.SelectedIndex == 0)
            {
                textBoxOrdSearchKeyword.Enabled = false;
                textBoxOrdSearchKeyword.BackColor = Color.Gray;

            }

            else if (comboBoxOrdSearch.SelectedIndex == 1)
            {
                textBoxOrdSearchKeyword.BackColor = Color.Gray;
            }
            else
            {

                textBoxOrdSearchKeyword.Enabled = true;
                textBoxOrdSearchKeyword.BackColor = Color.Yellow;
                textBoxOrdSearchKeyword.Focus();

            }

        }
        //Modify the case to order manually
        private void buttonModConfirm_Click(object sender, EventArgs e)
        {
            string updateOrdQty = "UPDATE ORD_ITEM SET ORD_QTY = ?, USER_ID = ? "
               + "WHERE ORDER_ID = " +  formOrders.orderID + ""
                + "AND INV_ID = " + textBoxMInvID.Text + "";
            
            OleDbCommand cmdupdateOrdQty = new OleDbCommand(updateOrdQty, conn);
            cmdupdateOrdQty.Parameters.Add("?", OleDbType.VarChar).Value = textBoxModQTY.Text;
            cmdupdateOrdQty.Parameters.Add("?", OleDbType.VarChar).Value = originalUserID;
            
            if (Convert.ToInt32(textBoxModQTY.Text) < 0)
            {
                MessageBox.Show("Order QTY should be positive number. Please try again.", "QTY Input Error Notice");
                textBoxModQTY.Focus();
            }
            else if (Convert.ToInt32(textBoxModQTY.Text) == 0)
            {
                //MessageBox.Show("Order QTY should be positive number. Please try again.", "QTY Input Error Notice");
                //textBoxModQTY.Focus();

               DialogResult ins = MessageBox.Show("When Order QTY equals 0, the Item will be removed from the Order List.", "Item Removal Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); ;
               if (ins == DialogResult.OK)
               {
                   buttonRemove_Click(sender, e);
                   diplayOrderItems();
                   panelMDetail.Visible = false;
                   
               }
               else
               {
                   textBoxModQTY.Focus();
               }
            }
            else
            {
                conn.Open();
                cmdupdateOrdQty.ExecuteNonQuery();
                conn.Close();
                diplayOrderItems();
                panelMDetail.Visible = false;

            }
        }

        //Add all Items into Order list at once
        private void pictureBoxDownPink_Click(object sender, EventArgs e)
        {
            buttonOrdSearch_Click(sender, e);
            for (int i = 0; i < dataGridViewSearchedItems.Rows.Count; i++)
            {
                string addItems = "INSERT INTO ORD_ITEM (ORDER_ID, INV_ID, ORD_QTY, QTY_DELIVERD, BACK_ORD, USER_ID, PALLET_ID, ASM_USER)"
             + "VALUES(?, ?, ?, ?, ?, ?, ?, ?)";

                OleDbCommand cmdAddItem = new OleDbCommand(addItems, conn);

                //allocate appropriate entry for controls
                cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = Orders.formOrders.orderID;
                cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = dataGridViewSearchedItems.Rows[i].Cells[0].Value.ToString();
                cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = dataGridViewSearchedItems.Rows[i].Cells[3].Value.ToString();
                cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";
                cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";
                cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USER_ID;
                cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";
                cmdAddItem.Parameters.Add("?", OleDbType.VarChar).Value = "";

                try
                {
                    if (isOrderItem(dataGridViewSearchedItems.Rows[i].Cells[0].Value.ToString()) == false)
                    {

                        // GlobalMethods.GlobalMethods.ExecMyQuery(cmdAddItem, "inseted");
                        conn.Open();
                        cmdAddItem.ExecuteNonQuery();
                        conn.Close();
                        diplayOrderItems();
                    }
                    else
                    {
                        String newdupItemsSql = "SELECT ORD_QTY"
                            + " FROM ORD_ITEM OI JOIN INVENTORY I ON OI.INV_ID = I.INV_ID JOIN PRODUCT P ON I.PROD_ID = P.PROD_ID"
                            + " WHERE OI.ORDER_ID = " + Orders.formOrders.orderID + " AND OI.INV_ID = "
                            + dataGridViewSearchedItems.Rows[i].Cells[0].Value.ToString() + "";
                        OleDbCommand cmdDupItem = new OleDbCommand(newdupItemsSql, conn);
                        OleDbDataAdapter odaDupAddingItem = new OleDbDataAdapter(cmdDupItem);
                        DataTable tableDupAddingItem = new DataTable();
                        odaDupAddingItem.Fill(tableDupAddingItem);
                        oldOrdQty = Convert.ToInt32(tableDupAddingItem.Rows[0]["ORD_QTY"]);
                        // MessageBox.Show(oldOrdQty.ToString());

                        //Update with add up ORDER QTY
                        // MessageBox.Show(newInvLocation.ToString() + prodID); //Debug purpose
                        conn.Open();
                        //to make entry of QOH
                        string updateQOH = "UPDATE ORD_ITEM SET ORD_QTY = ?, USER_ID = ? "
                                + " WHERE ORDER_ID = " + Orders.formOrders.orderID + ""
                                + " AND INV_ID = " + dataGridViewSearchedItems.Rows[i].Cells[0].Value + "";

                        OleDbCommand cmdUpdate = new OleDbCommand(updateQOH, conn);
                        // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());
                        int newOrdQTY = Convert.ToInt32(dataGridViewSearchedItems.Rows[i].Cells[3].Value.ToString());
                        cmdUpdate.Parameters.Add("?", OleDbType.VarChar).Value = (oldOrdQty + newOrdQTY);
                        cmdUpdate.Parameters.Add("?", OleDbType.VarChar).Value = GlobalMethods.GlobalMethods.USER_ID;

                        //MessageBox.Show(updateQOH);
                        cmdUpdate.ExecuteNonQuery();
                        diplayOrderItems();
                        //conn.Close();

                        //DialogResult ins = MessageBox.Show("Some(or An) Order item(s) exist(s) already. Do you just want to update Order QTY? ", "Item Duplication", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
                        //if (ins == DialogResult.Yes)
                        //{

                        //}
                        //else
                        //{
                        //    // conn.Close();
                        //}

                        //pictureBoxDown_Click(sender, e);
                        // conn.Close();

                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                pictureBoxDownYellow.Visible = false;
                conn.Close();

            }


            pictureBoxDownPink.Visible = false;
        }
    }
}
