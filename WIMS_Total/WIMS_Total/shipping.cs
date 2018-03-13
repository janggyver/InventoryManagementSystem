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


namespace Shipping
{
    public partial class formShipping : Form
    {
        public formShipping()
        {
            InitializeComponent();
            //locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
        }

        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");
        public string palletID;
        public string invID;
        public int qtyDelivered;
        public string orderID;
        public string shelfLoc;
        public string destinationName;
        public string BESKU;
        public string orderStaus;
        public string prodID;
        public string prodName;
        public int QOHinWH;
        public Boolean allAssembled = false;
        public Boolean allLoaded = false;
        public string palletStatus;
        public string loadStatus;
        public double totalWeight = 0;

        private void formShipping_Load(object sender, EventArgs e)
        {
            labelInfo.Text = GlobalMethods.GlobalMethods.USERFULLNAME + "  " + "User ID: " + GlobalMethods.GlobalMethods.USER_ID + " Location:" + GlobalMethods.GlobalMethods.USER_LOCATION_NAME;
            groupBoxItemSummary.Visible = false;
            displayAsssignedOrder();
            //buttonFinAssembling.Visible = false;
            buttonLoad.Visible = false;
            panelDriverConfirm.Visible = false;
            labelShippingReceipt.Visible = false;
            labelShippingRequest.Visible = true;
            textBoxDriverName.BackColor = Color.White;


        }


        //Display Orders to assigned to the worker
        public void displayAsssignedOrder()
        {
            //string toSearchOrderItem = "SELECT OI.PALLET_ID AS PALLET ID, L.LOCATION_NAME AS SHIP TO, OI.INV_ID AS INV ID, I.SHELF_LOCA, OI.QTY_DELIVERD AS QTY TO ASSEMBLE,  OR.ORDER_ID AS ORDER ID  "

            string toSearchOrderItem = "SELECT OI.PALLET_ID, OI.INV_ID, OI.QTY_DELIVERD, OI.ORDER_ID, PI.PALLET_STATUS, PI.LOAD_STATUS"
            + " FROM ORD_ITEM OI, PALLET_ITEM PI "
            + " WHERE OI.ASM_USER = " + GlobalMethods.GlobalMethods.USER_ID + " AND OI.ORDER_ID = PI.ORDER_ID AND OI.PALLET_ID = PI.PALLET_ID AND OI.INV_ID = PI.INV_ID "
            + " ORDER BY OI.PALLET_ID";

            OleDbCommand cmdOrdItem = new OleDbCommand(toSearchOrderItem, conn);
            OleDbDataAdapter odaOrdItem = new OleDbDataAdapter(cmdOrdItem);
            DataTable tableOrdItemList = new DataTable();
            odaOrdItem.Fill(tableOrdItemList);
            dataGridViewOrderList.DataSource = tableOrdItemList;
            int ordItemNum = tableOrdItemList.Rows.Count;
            labelOrdItemResult.Text = ordItemNum.ToString();
            buttonLoad.Visible = false;


        }

        private void dataGridViewOrderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            palletID = dataGridViewOrderList.CurrentRow.Cells[0].Value.ToString();
            invID = dataGridViewOrderList.CurrentRow.Cells[1].Value.ToString();
            qtyDelivered = Convert.ToInt32(dataGridViewOrderList.CurrentRow.Cells[2].Value.ToString());
            orderID = dataGridViewOrderList.CurrentRow.Cells[3].Value.ToString();
            palletStatus = dataGridViewOrderList.CurrentRow.Cells[4].Value.ToString();
            loadStatus = dataGridViewOrderList.CurrentRow.Cells[5].Value.ToString();
            groupBoxItemSummary.Visible = true;
            conn.Open();
            string findProdID = "SELECT PROD_ID FROM INVENTORY WHERE INV_ID = "+invID+"";
            OleDbCommand cmdProdID = new OleDbCommand(findProdID, conn);
            prodID = cmdProdID.ExecuteScalar().ToString();
            conn.Close();
            conn.Open();
            string findShelfLoc = "SELECT SHELF_LOC FROM INVENTORY WHERE PROD_ID = "+prodID+" AND LOCATION = 0";
            OleDbCommand cmdShelfLoc = new OleDbCommand(findShelfLoc, conn);
            shelfLoc = cmdShelfLoc.ExecuteScalar().ToString();
            conn.Close();
            conn.Open();
            string findBESKU = "SELECT BE_SKU FROM PRODUCT WHERE PROD_ID = "+prodID+"";
            OleDbCommand cmdBESKU = new OleDbCommand(findBESKU, conn);
            BESKU = cmdBESKU.ExecuteScalar().ToString();
            conn.Close();
            conn.Open();
            string findProdName = "SELECT PROD_NAME FROM PRODUCT WHERE PROD_ID = "+prodID+"";
            OleDbCommand cmdProdName = new OleDbCommand(findProdName, conn);
            prodName = cmdProdName.ExecuteScalar().ToString();
            conn.Close();
            conn.Open();
            string findQOH = "SELECT QOH FROM INVENTORY WHERE INV_ID = " + invID + "";
            OleDbCommand cmdQOH = new OleDbCommand(findQOH, conn);
            QOHinWH = Convert.ToInt32(cmdQOH.ExecuteScalar().ToString());
            conn.Close();

            calculateTotalWeight(palletID);
            textBoxPalletWeight.Text = totalWeight.ToString();
            textBoxProdID.Text = prodID;
            textBoxBESKU.Text = BESKU;
            textBoxInv_ID.Text = invID;
            textBoxProdName.Text = prodName;
            textBoxQOHinWH.Text = QOHinWH.ToString();
            textBoxShelfLOC.Text = shelfLoc;
            textBoxAssembleCase.Text = qtyDelivered.ToString();
            textBoxPalletID.Text = palletID;
            textBoxPalletID.BackColor = Color.LightBlue;
            textBoxPalletStatus.Text = palletStatus;
            textBoxDriverName.Focus();

            allAssembled = checkAllAssembled();

            if (allAssembled == true)
            {
                buttonFinAssembling.Enabled = true;
                buttonAssemble.Enabled = false;
                //panelDriverConfirm.Visible = false;
            }
            else
            {
                buttonFinAssembling.Enabled = false;
                buttonAssemble.Enabled = true;
                panelDriverConfirm.Visible = false;

            }

            if (loadStatus == "Waiting" && palletStatus == "Palettized")
            {
                buttonFinAssembling.Enabled = true;
                panelDriverConfirm.Visible = false;
            }
            else if (loadStatus == "Loaded" || loadStatus == "Truck")
            {
                conn.Open();
                string findProdDriver = "SELECT DRIVER_NAME FROM ORDERS WHERE ORDER_ID = " + orderID + "";
                OleDbCommand cmdDriverName = new OleDbCommand(findProdDriver, conn);
                string Driver_Name = cmdDriverName.ExecuteScalar().ToString();
                conn.Close();
                textBoxDriverName.Text = Driver_Name;
                buttonFinAssembling.Enabled = false;
                buttonLoad.Enabled = false;
                panelDriverConfirm.Visible = true;
                textBoxDriverName.BackColor = Color.Yellow;
                textBoxDriverName.Enabled = true;
                textBoxDriverName.Focus();
                labelShippingReceipt.Visible = true;
                labelShippingRequest.Visible = false;

            }


            allLoaded = checkAllLoaded();
            if (allLoaded == false)
            {
                panelDriverConfirm.Enabled = true;
            }
            else
            {
                panelDriverConfirm.Enabled = false;
                MessageBox.Show("This Order is Loaded to Truck already.", "Loaded Notification");
            }


        }

        //Assemble item to pallet
        private void buttonAssemble_Click(object sender, EventArgs e)
        {
            conn.Open();
            string updatePalletSQL = "UPDATE PALLET_ITEM SET PALLET_STATUS = 'Palletized'"
            + " WHERE INV_ID = " + invID + " AND ORDER_ID =" + orderID + " AND PALLET_ID = "+palletID+"";
            OleDbCommand cmdUpdatePallet = new OleDbCommand(updatePalletSQL, conn);
            cmdUpdatePallet.ExecuteNonQuery();
            conn.Close();
            allAssembled = checkAllAssembled();
            
            if (allAssembled == true)
            {
                buttonFinAssembling.Enabled = true;
                buttonAssemble.Enabled = false;
            }
            else
            {
                buttonFinAssembling.Enabled = false;
                buttonAssemble.Enabled = true;
            }

            calculateTotalWeight(palletID);
            textBoxPalletWeight.Text = totalWeight.ToString();
            formShipping_Load(sender, e);
   
        }

        //figure out Assign Status
        public Boolean checkAllAssembled()
        {
            conn.Open();
            allAssembled = false;
            string allItemSQL = "SELECT COUNT(*) FROM PALLET_ITEM WHERE PALLET_STATUS = 'Incomplete' AND ORDER_ID = "+orderID+" AND PALLET_ID = "+palletID+"" ;
            OleDbCommand cmdallItem = new OleDbCommand(allItemSQL, conn);
            int allItemNum = Convert.ToInt32(cmdallItem.ExecuteScalar().ToString());
            conn.Close();

            if (allItemNum == 0)
            {
                return allAssembled = true;
            }
            else
            {
                return allAssembled = false;
            }
        }


        //figure out load Status
        public Boolean checkAllLoaded()
        {
            conn.Open();
            allLoaded = false;
            string allLoadedSQL = "SELECT COUNT(*) FROM PALLET_ITEM WHERE LOAD_STATUS = 'Waiting' OR LOAD_STATUS = 'Loaded' AND ORDER_ID = " + orderID + " AND PALLET_ID = " + palletID + "";
            OleDbCommand cmdallLoaded = new OleDbCommand(allLoadedSQL, conn);
            int allLoadedNum = Convert.ToInt32(cmdallLoaded.ExecuteScalar().ToString());
            conn.Close();

            if (allLoadedNum == 0)
            {
                return allLoaded = true;
            }
            else
            {
                return allLoaded = false;
            }
        }

        //Finish Assembling and change order Status
        private void buttonFinAssembling_Click(object sender, EventArgs e)
        {

            conn.Open();
            string updateOrder = "UPDATE ORDERS SET ORDER_STATUS = 'PREPARED'"
            + " WHERE ORDER_ID = " + orderID + "";

            OleDbCommand cmdUpdate = new OleDbCommand(updateOrder, conn);
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("All Items are prepared to load.", "Finish Assembling");

            buttonLoad.Visible = true;
            buttonLoad.Enabled = true;
            buttonFinAssembling.Enabled = false;
        }

        //find total weight
        public void calculateTotalWeight(string palID)
        {
            totalWeight = 0.0;
            string weightSQL = "SELECT (P.CASE_WEIGHT*OI.QTY_DELIVERD)"
                + " FROM PRODUCT P, INVENTORY I, ORDERS O, ORD_ITEM OI"
                + " WHERE P.PROD_ID = I.PROD_ID AND I.INV_ID = OI.INV_ID AND O.ORDER_ID = OI.ORDER_ID AND OI.PALLET_ID = " + palID + "";
            OleDbCommand cmdCal = new OleDbCommand(weightSQL, conn);
            OleDbDataAdapter odaCal = new OleDbDataAdapter(cmdCal);
            DataTable tableCal = new DataTable();
            odaCal.Fill(tableCal);


            for (int i = 0; i < tableCal.Rows.Count; i++)
            {
                totalWeight += Convert.ToDouble(tableCal.Rows[i][0].ToString());
            }

        }
        //loaded by staff
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string toSearchOrderItem = "SELECT OI.PALLET_ID, OI.INV_ID, OI.QTY_DELIVERD, OI.ORDER_ID, PI.PALLET_STATUS, PI.LOAD_STATUS"
            + " FROM ORD_ITEM OI, PALLET_ITEM PI "
            + " WHERE OI.ASM_USER = " + GlobalMethods.GlobalMethods.USER_ID + " AND OI.ORDER_ID = PI.ORDER_ID AND OI.PALLET_ID = PI.PALLET_ID AND OI.INV_ID = PI.INV_ID "
            + " ORDER BY OI.PALLET_ID";

            OleDbCommand cmdOrdItem = new OleDbCommand(toSearchOrderItem, conn);
            OleDbDataAdapter odaOrdItem = new OleDbDataAdapter(cmdOrdItem);
            DataTable tableOrdItemList = new DataTable();
            odaOrdItem.Fill(tableOrdItemList);
            dataGridViewOrderList.DataSource = tableOrdItemList;
            int ordItemNum = tableOrdItemList.Rows.Count;

            for (int i = 0; i < ordItemNum; i++)
            {
                invID = dataGridViewOrderList.Rows[i].Cells[1].Value.ToString();
                orderID = dataGridViewOrderList.Rows[i].Cells[3].Value.ToString();
                palletID = dataGridViewOrderList.Rows[i].Cells[0].Value.ToString();
                conn.Open();
                string updatePalletSQL = "UPDATE PALLET_ITEM SET LOAD_STATUS = 'Loaded'"
                + " WHERE INV_ID = " + invID + " AND ORDER_ID =" + orderID + " AND PALLET_ID = " + palletID + "";
                OleDbCommand cmdUpdatePallet = new OleDbCommand(updatePalletSQL, conn);
                cmdUpdatePallet.ExecuteNonQuery();
                conn.Close();
            }



            conn.Open();
            string updateOrder = "UPDATE ORDERS SET ORDER_STATUS = 'PREPARED'"
            + " WHERE ORDER_ID = " + orderID + "";

            OleDbCommand cmdUpdate = new OleDbCommand(updateOrder, conn);
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("All Items are loaded to truck and waiting for driver's confirm.", "Loading Completed");

            formShipping_Load(sender, e);

            buttonLoad.Visible = false;
            groupBoxItemSummary.Visible = false;
            panelDriverConfirm.Visible = true;
            textBoxDriverName.Enabled = true;
            textBoxDriverName.Focus();
            textBoxDriverName.BackColor = Color.Yellow;
            labelShippingReceipt.Visible = true;
            labelShippingRequest.Visible = false;

        }

        //Driver confirms the pallets
        private void buttonDriverConfirm_Click(object sender, EventArgs e)
        {
            if (textBoxDriverName.Text == "")
            {
                MessageBox.Show("Pleasee enter Driver's name", "Data Request");
                textBoxDriverName.Focus();
            }
            else
            {


                DialogResult ins = MessageBox.Show("Do you confirm Pallets are right? ", "Confirm to Load", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
                if (ins == DialogResult.Yes)
                {
                                        string toSearchOrderItem = "SELECT OI.PALLET_ID, OI.INV_ID, OI.QTY_DELIVERD, OI.ORDER_ID, PI.PALLET_STATUS, PI.LOAD_STATUS"
                    + " FROM ORD_ITEM OI, PALLET_ITEM PI "
                    + " WHERE OI.ASM_USER = " + GlobalMethods.GlobalMethods.USER_ID + " AND OI.ORDER_ID = PI.ORDER_ID AND OI.PALLET_ID = PI.PALLET_ID AND OI.INV_ID = PI.INV_ID "
                    + " ORDER BY OI.PALLET_ID";

                    OleDbCommand cmdOrdItem = new OleDbCommand(toSearchOrderItem, conn);
                    OleDbDataAdapter odaOrdItem = new OleDbDataAdapter(cmdOrdItem);
                    DataTable tableOrdItemList = new DataTable();
                    odaOrdItem.Fill(tableOrdItemList);
                    dataGridViewOrderList.DataSource = tableOrdItemList;
                    int ordItemNum = tableOrdItemList.Rows.Count;

                    for (int i = 0; i < ordItemNum; i++)
                    {
                        invID = dataGridViewOrderList.Rows[i].Cells[1].Value.ToString();
                        orderID = dataGridViewOrderList.Rows[i].Cells[3].Value.ToString();
                        palletID = dataGridViewOrderList.Rows[i].Cells[0].Value.ToString();
                        conn.Open();
                        string updatePalletSQL = "UPDATE PALLET_ITEM SET LOAD_STATUS = 'Truck'"
                        + " WHERE INV_ID = " + invID + " AND ORDER_ID =" + orderID + " AND PALLET_ID = " + palletID + "";
                        OleDbCommand cmdUpdatePallet = new OleDbCommand(updatePalletSQL, conn);
                        cmdUpdatePallet.ExecuteNonQuery();
                        conn.Close();
                    }



                    conn.Open();
                    string loadOrder = "UPDATE ORDERS SET ORDER_STATUS =?, LOAD_DT = ?, DRIVER_NAME = ? "
                            + " WHERE ORDER_ID = " + orderID + "";

                    OleDbCommand cmdloadOrder = new OleDbCommand(loadOrder, conn);
                    // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());

                    cmdloadOrder.Parameters.Add("?", OleDbType.VarChar).Value = "IN TRANSIT";
                    //cmdreceiveOrder.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now.AddDays(7);
                    cmdloadOrder.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now;
                    cmdloadOrder.Parameters.Add("?", OleDbType.VarChar).Value = textBoxDriverName.Text;

                    //MessageBox.Show(updateQOH);
                    cmdloadOrder.ExecuteNonQuery();
                    //buttonOrdSearch_Click(sender, e);
                    conn.Close();

                    GlobalMethods.GlobalMethods.storeAudit("", "", "Shipped");
                    formShipping_Load(sender, e);
                }
                else
                {
                    formShipping_Load(sender, e);
                }

            }
        }
    }
}
