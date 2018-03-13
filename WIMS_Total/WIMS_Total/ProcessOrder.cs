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

namespace ProcessOrder
{
    public partial class formProcessOrder : Form
    {
        public formProcessOrder()
        {
            InitializeComponent();
            //locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
        }

        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

        int orderID = OrderForWarehouse.formOrderForWarehouse.orderID;
        string invID;
        string orderByID = OrderForWarehouse.formOrderForWarehouse.orderByid;
        string prodID;
        string beSKU;
        string prod_Name;
        double prod_weight;
        int case_count;
        double case_weight;
        int qtyOrdered;
        int qtyDelivered;
        int qtyBackOrdered;
        double weightDeliveredCases;
        string existing_pallet_ID = "0";
        string new_pallet_ID;
        string max_pallet_ID;
        string asm_User;
        int QOHInWH;
        int transientQTY;
        string invLocation;
        int casesAvailableinWH;
        string isBackOrdered;
        string newPalletID;
        string asmUserFullInfo;
        string asmUserID;
        string palletStatus;
        string load_status;
        Boolean allAssigned;
        string orderedLocation;
        string palletDestination;
        Boolean ispalletDuplicated;
        int palletDupNum;
        double totalWeight;
        
       


        private void formProcessOrder_Load(object sender, EventArgs e)
        {

            labelInfo.Text = GlobalMethods.GlobalMethods.USERFULLNAME + "  " + "User ID: " + GlobalMethods.GlobalMethods.USER_ID + " Location:" + GlobalMethods.GlobalMethods.USER_LOCATION_NAME;

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
            textBoxOrdSearchKeyword.BackColor = Color.LightGreen;
            textBoxOrdSearchKeyword.Focus();
            panelItemsInOrder.Visible = true;
            displayOrdItemforProgress();
            textBoxOrdSearchKeyword.Text = orderID.ToString();
            textBoxOrdSearchKeyword.Enabled = false;
            numericUpDownDeliveredCases.Enabled = false;
            buttonModifyOrder.Visible = false;
            buttonConfirmModify.Visible = false;
            numericUpDownDeliveredCases.BackColor = Color.LightGray;
            groupBoxItemSummary.Visible = false;
            groupBoxAssign.Visible = false;
            pictureBoxGreen.Visible = false;
            pictureBoxRed.Visible = false;
            groupBoxPalletweight.Visible = false;

        }
        //;Integrated Security=SSPI


        // Display Ordered Items in DGV 
        public void displayOrdItemforProgress()
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
            int ordItemNum = tableOrdItemList.Rows.Count;
            labelOrdItemResult.Text = ordItemNum.ToString();
        }

        //find detail information for the items
        public void displayDetailProductInfo(){
            totalWeight = 0.0;
            if (existing_pallet_ID != "" || new_pallet_ID != null || newPalletID != null)
            {
                calculateTotalWeight(existing_pallet_ID);
            }


            string detailProudctInfo = "SELECT * FROM PRODUCT"
                + " WHERE PROD_ID in (SELECT PROD_ID FROM INVENTORY WHERE INV_ID =" + invID + ")";
            OleDbCommand cmdProdInfo = new OleDbCommand(detailProudctInfo, conn);
            OleDbDataAdapter odaDetailProd = new OleDbDataAdapter(cmdProdInfo);
            DataTable tableProdInfo = new DataTable();
            odaDetailProd.Fill(tableProdInfo);
            prodID = tableProdInfo.Rows[0][0].ToString();
            textBoxProdID.Text = prodID;
            beSKU = tableProdInfo.Rows[0][1].ToString();
            textBoxBESKU.Text = beSKU;
            prod_Name = tableProdInfo.Rows[0][3].ToString(); 
            textBoxProdName.Text = prod_Name;
            prod_weight = Convert.ToDouble(tableProdInfo.Rows[0][8].ToString());
            textBoxProdWeight.Text = prod_weight.ToString();
            case_count = Convert.ToInt32(tableProdInfo.Rows[0][13].ToString());
            textBoxCaseCount.Text = case_count.ToString();
            case_weight = prod_weight * case_count;
            textBoxCaseWeight.Text = case_weight.ToString();
            textBoxInv_ID.Text = invID;
            textBoxCaseOrdered.Text = qtyOrdered.ToString();
            numericUpDownDeliveredCases.Value = qtyDelivered;
            weightDeliveredCases = qtyDelivered * case_weight;
            textBoxDeliveredCaseWgt.Text = weightDeliveredCases.ToString();
            textBoxBackOrderedCases.Text = qtyBackOrdered.ToString();
            numericUpDownDeliveredCases.Enabled = false;
            textBoxPalletWeight.Text = totalWeight.ToString();

            string detailInvInfo = "SELECT * FROM INVENTORY"
                + " WHERE PROD_ID = " + prodID + " AND LOCATION = 0";
            OleDbCommand cmdInvInfo = new OleDbCommand(detailInvInfo, conn);
            OleDbDataAdapter odaDetailInv = new OleDbDataAdapter(cmdInvInfo);
            DataTable tableInvInfo = new DataTable();
            odaDetailInv.Fill(tableInvInfo);
            invLocation = tableInvInfo.Rows[0][2].ToString();
            QOHInWH = Convert.ToInt32(tableInvInfo.Rows[0][4].ToString());
            transientQTY = Convert.ToInt32(tableInvInfo.Rows[0][5].ToString());
            if (tableInvInfo.Rows[0][5].ToString() == null)
            {
                transientQTY = 0;
            }
            else
            {
                transientQTY = Convert.ToInt32(tableInvInfo.Rows[0][5].ToString());
            }

            textBoxQOHinWH.Text = QOHInWH.ToString();
            textBoxTransQTY.Text = transientQTY.ToString();
            casesAvailableinWH = QOHInWH / case_count;
            textBoxAvailCaseinWH.Text = casesAvailableinWH.ToString();
            groupBoxPalletweight.Visible = true;

            
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

        //Event for clicking cell
        public void dataGridViewOrdItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            allAssigned = checkAllAssigned();
            if (allAssigned == false)
            {
                pictureBoxRed.Visible = true;
                pictureBoxGreen.Visible = false;
                groupBoxAssign.Visible = true;
                buttonModifyOrder.Visible = true;
                buttonConfirmModify.Visible = false;
                groupBoxItemSummary.Visible = true;
                invID = dataGridViewOrdItems.CurrentRow.Cells[1].Value.ToString();
                qtyOrdered = Convert.ToInt32(dataGridViewOrdItems.CurrentRow.Cells[2].Value.ToString());
                qtyDelivered = Convert.ToInt32(dataGridViewOrdItems.CurrentRow.Cells[3].Value.ToString());
                qtyBackOrdered = qtyOrdered - qtyDelivered;
                if (dataGridViewOrdItems.CurrentRow.Cells[6].Value.ToString() == null || dataGridViewOrdItems.CurrentRow.Cells[6].Value.ToString() == "")
                {
                    //existing_pallet_ID = "";
                    new_pallet_ID = (Convert.ToInt32(max_pallet_ID) + 1).ToString();
                    numericUpDownPalletID.Value = Convert.ToInt32(max_pallet_ID) + 1;

                }
                else
                {
                    existing_pallet_ID = dataGridViewOrdItems.CurrentRow.Cells[6].Value.ToString();
                    //comboBoxPalletID.SelectedText = existing_pallet_ID;
                    numericUpDownPalletID.Value = Convert.ToInt32(existing_pallet_ID);
                }

                asm_User = dataGridViewOrdItems.CurrentRow.Cells[7].Value.ToString();

                //populatePalletComboBox();
                displayDetailProductInfo();
                populatePickerComboBox();
            }
            else
            {
                pictureBoxGreen.Visible = true;
                pictureBoxRed.Visible = false;
                DialogResult ins = MessageBox.Show("All Items assigned. Do you want to re-assign?", "All Assigned Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
                if (ins == DialogResult.Yes)
                {
                    groupBoxAssign.Visible = true;
                    buttonModifyOrder.Visible = true;
                    buttonConfirmModify.Visible = false;
                    groupBoxItemSummary.Visible = true;
                    invID = dataGridViewOrdItems.CurrentRow.Cells[1].Value.ToString();
                    qtyOrdered = Convert.ToInt32(dataGridViewOrdItems.CurrentRow.Cells[2].Value.ToString());
                    qtyDelivered = Convert.ToInt32(dataGridViewOrdItems.CurrentRow.Cells[3].Value.ToString());
                    qtyBackOrdered = qtyOrdered - qtyDelivered;
                    if (dataGridViewOrdItems.CurrentRow.Cells[6].Value.ToString() == null || dataGridViewOrdItems.CurrentRow.Cells[6].Value.ToString() == "")
                    {
                        existing_pallet_ID = "";
                    }
                    else
                    {
                        existing_pallet_ID = dataGridViewOrdItems.CurrentRow.Cells[6].Value.ToString();
                        numericUpDownPalletID.Value = Convert.ToInt32(existing_pallet_ID);
                    }

                    asm_User = dataGridViewOrdItems.CurrentRow.Cells[7].Value.ToString();
                    displayDetailProductInfo();
                    populatePalletNumericButton();
                    populatePickerComboBox();
                }

                else if (ins == DialogResult.No)
                {
                    this.Close();
                }
            }


        }

        //Try to Modify an Ordered Item
        private void buttonModifyOrder_Click(object sender, EventArgs e)
        {
            buttonModifyOrder.Visible = false;
            buttonConfirmModify.Visible = true;
            buttonConfirmModify.Enabled = true;
            numericUpDownDeliveredCases.Enabled = true;
            numericUpDownDeliveredCases.BackColor = Color.Yellow;
            groupBoxAssign.Visible = false;
        }

        //Confirm an modified Ordered QTY
        private void buttonConfirmModify_Click(object sender, EventArgs e)
        {
            conn.Open();
            //to make entry of QOH
            string modInv = "UPDATE INVENTORY SET QOH = ?, TRANSIENT_QTY = ? "
                 + " WHERE PROD_ID = " + prodID + " and LOCATION = 0";

            OleDbCommand cmdmodInv = new OleDbCommand(modInv, conn);
            // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());

            //int newCase = Convert.ToInt32(numericUpDownDeliveredCases.Value.ToString());
            //int gap;
            //int tempQOHinWH2;
            //int newBackOrderedCases = qtyDelivered - newCase;
            //gap = (newCase - qtyDelivered) * case_count;
            ////transQTY = gap * casecount;

            //tempQOHinWH2 = QOHInWH - gap;
            //int newtransQTY = transientQTY + gap;
            ////if (gap < 0)
            ////{
            ////    tempQOHinWH2 = QOHinWH - gap;
            ////    transQTY = transQTY+gap;
            ////}
            ////else
            ////{
            ////    tempQOHinWH2 = QOHinWH - gap;
            ////    transQTY = transQTY+gap;
            ////}

            cmdmodInv.Parameters.Add("?", OleDbType.Integer).Value = textBoxQOHinWH.Text;
            cmdmodInv.Parameters.Add("?", OleDbType.Integer).Value = textBoxTransQTY.Text;
            //cmdreceiveOrder.Parameters.Add("?", OleDbType.Date).Value = System.DateTime.Now.AddDays(7);

            //MessageBox.Show(updateQOH);
            cmdmodInv.ExecuteNonQuery();
            conn.Close();


            conn.Open();
            int newCase = Convert.ToInt32(numericUpDownDeliveredCases.Value.ToString());
            int newBackOrderedCases = qtyOrdered -  newCase;
            //to make entry of QOH
            //       string modOrd = "UPDATE ORD_ITEM SET ORD_QTY = " + newCase + ", QTY_DELIVERD = " + newCase + ""
            //+ " WHERE INV_ID = " + invID + " AND ORDER_ID =" + orderID + "";
            if (newBackOrderedCases > 0)
            {
               isBackOrdered = "Y";

            }
            else
            {
                isBackOrdered = "N";

            }




            string modOrd = "UPDATE ORD_ITEM SET QTY_DELIVERD = " + newCase + ", BACK_ORD = ? "
                 + " WHERE INV_ID = " + invID + " AND ORDER_ID =" + orderID + "";

            OleDbCommand cmdmodOrd = new OleDbCommand(modOrd, conn);
            cmdmodOrd.Parameters.Add("?", OleDbType.Char).Value = isBackOrdered;

            // MessageBox.Show(dataGridViewSearchedItems.CurrentRow.Cells[3].Value.ToString());
            cmdmodOrd.ExecuteNonQuery();

            conn.Close();
            buttonModifyOrder.Enabled = true;
            buttonConfirmModify.Enabled = false;
            formProcessOrder_Load(sender, e);

        }

        //deduct delivered QTY
        //private void numericUpDownDeliveredCases_KeyUp(object sender, KeyEventArgs e)
        //{
        //    int tempCaseQTYDelivered = Convert.ToInt32(numericUpDownDeliveredCases.Value.ToString());
        //    int tempGap = (qtyDelivered - tempCaseQTYDelivered) * case_count;
        //    int tempQOHInWH = QOHInWH + tempGap;
        //    int tempTransientQTY = transientQTY - tempGap;

        //    textBoxQOHinWH.Text = tempQOHInWH.ToString();
        //    textBoxTransQTY.Text = tempTransientQTY.ToString();

        //}

        private void numericUpDownDeliveredCases_ValueChanged(object sender, EventArgs e)
        {
            int tempCaseQTYDelivered = Convert.ToInt32(numericUpDownDeliveredCases.Value.ToString());
            int tempGap = (qtyDelivered - tempCaseQTYDelivered) * case_count;
            double tempGapWGT = (qtyDelivered - tempCaseQTYDelivered) * case_weight;
            int tempGapBackOrdered = qtyOrdered - tempCaseQTYDelivered;
            int tempQOHInWH = QOHInWH + tempGap;
            int tempTransientQTY = transientQTY - tempGap;
            double tempDeliveredCaseWGT = weightDeliveredCases - tempGapWGT;


            textBoxQOHinWH.Text = tempQOHInWH.ToString();
            textBoxTransQTY.Text = tempTransientQTY.ToString();
            textBoxDeliveredCaseWgt.Text = tempDeliveredCaseWGT.ToString();
            textBoxAvailCaseinWH.Text = (tempQOHInWH / case_count).ToString();
            textBoxBackOrderedCases.Text = tempGapBackOrdered.ToString();
        }


        //To populate data(values) from the database 
        public void populatePalletNumericButton()
        {

            ////comboBoxPalletID.Items.Clear();


            //comboBoxPalletID.Items.Clear();
            //comboBoxPalletID.Items.Add("New_Pallet");

            //string palletSQL = "SELECT PALLET_ID FROM PALLET_ITEM";
            //OleDbCommand cmdPallet = new OleDbCommand(palletSQL, conn);
            //OleDbDataAdapter odaPallet = new OleDbDataAdapter(cmdPallet);
            //DataTable tablePallet = new DataTable();
            //odaPallet.Fill(tablePallet);
            //foreach (DataRow dr in tablePallet.Rows)
            //{
            //    comboBoxPalletID.Items.Add(dr["PALLET_ID"].ToString());
            //}
        }


        //To populate pickers from the database just to select and prevent to edit.
        public void populatePickerComboBox()
        {
            //string palletSQL = "SELECT PALLET_ID FROM PALLET_ITEM";
            //OleDbCommand cmdPallet = new OleDbCommand(palletSQL, conn);
            //OleDbDataAdapter odaPallet = new OleDbDataAdapter(cmdPallet);
            //DataTable tablePallet = new DataTable();
            //odaPallet.Fill(tablePallet);

            //comboBoxPalletID.Items.Clear();

            //foreach (DataRow dr in tablePallet.Rows)
            //{
            //    comboBoxPalletID.Items.Add(dr["PALLET_ID"].ToString());
            //}
            conn.Open();
            string pickerSQL = "SELECT USER_ID || ': ' || USER_FNAME || ' ' || USER_LNAME AS PICKER FROM USERS "
                + "WHERE LOCATION = 0 AND ACCESS_LEVEL=9";
    //        string pickerSQL = "SELECT USER_ID FROM USERS "
    //+ "WHERE LOCATION = 0 AND ACCESS_LEVEL=9";
            OleDbCommand cmdPicker = new OleDbCommand(pickerSQL, conn);
            OleDbDataAdapter odaPicker = new OleDbDataAdapter(cmdPicker);
            DataTable tablePicker = new DataTable();
            odaPicker.Fill(tablePicker);

            comboBoxPickerName.Items.Clear();
            for (int i = 0; i < tablePicker.Rows.Count; i++)
            {
                comboBoxPickerName.Items.Add(tablePicker.Rows[i][0].ToString());
            }
            comboBoxPickerName.SelectedIndex = 1;
            conn.Close();

        }

        //Pallet ID created
        private void numericUpDownPalletID_ValueChanged(object sender, EventArgs e)
        {
            newPalletID = numericUpDownPalletID.Value.ToString();

        }

        private void comboBoxPalletID_Click(object sender, EventArgs e)
        {
            if (comboBoxPalletID.SelectedIndex == 0)
            {
                conn.Open();
                string maxSQL = "SELECT PALLET_ID FROM PALLET_ITEM ";
                OleDbCommand cmdMax = new OleDbCommand(maxSQL, conn);
                OleDbDataAdapter odaMax = new OleDbDataAdapter(cmdMax);
                DataTable tableMax = new DataTable();
                odaMax.Fill(tableMax);

                int palletIDCount = tableMax.Rows.Count;

                if (palletIDCount == 0)
                {
                    string dropSEQ = "DROP SEQUENCE PALLET_ID_SEQ";
                    OleDbCommand cmddropSEQ = new OleDbCommand(dropSEQ, conn);
                    cmddropSEQ.ExecuteNonQuery();

                    string createSEQ = "CREATE SEQUENCE PALLET_ID_SEQ START WITH 1 INCREMENT BY 1 MINVALUE 1 MAXVALUE 9999999 ";
                    OleDbCommand cmdCreateSEQ = new OleDbCommand(createSEQ, conn);
                    cmdCreateSEQ.ExecuteNonQuery();

                    string palletSQL = "SELECT PALLET_ID_SEQ.NEXTVAL FROM DUAL";
                    OleDbCommand cmdPallet = new OleDbCommand(palletSQL, conn);
                    newPalletID = cmdPallet.ExecuteScalar().ToString();


                }
                else
                {
                    string palletSQL = "SELECT PALLET_ID_SEQ.NEXTVAL FROM DUAL";
                    OleDbCommand cmdPallet = new OleDbCommand(palletSQL, conn);

                }

                comboBoxPalletID.Items.Add(newPalletID.ToString());

                conn.Close();
            }

        }


        //Assign an item with a worker and pallet
        private void buttonAssign_Click(object sender, EventArgs e)
        {
            DialogResult ins = MessageBox.Show("Do you want to assign or modify to Pallet? ", "Order Processing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
            if (ins == DialogResult.Yes)
            {
                conn.Open();
                //new_pallet_ID = comboBoxPalletID.Text;
                new_pallet_ID = numericUpDownPalletID.Value.ToString();
                asmUserFullInfo = comboBoxPickerName.Text;
                asmUserID = asmUserFullInfo.Split(':')[0];
                if (existing_pallet_ID == null || existing_pallet_ID == "")
                {
                    existing_pallet_ID = new_pallet_ID;
                }

                string isPalleted = "SELECT * FROM PALLET_ITEM WHERE ORDER_ID = " + orderID + " AND INV_ID =" + invID + " AND PALLET_ID = " + existing_pallet_ID + "";
                OleDbCommand cmdIsPallet = new OleDbCommand(isPalleted, conn);
                OleDbDataAdapter odaIsPallet = new OleDbDataAdapter(cmdIsPallet);
                DataTable tableIsPallet = new DataTable();
                odaIsPallet.Fill(tableIsPallet);
                int isPallettedNum = tableIsPallet.Rows.Count;
                checkPalletDuplication();
                //totalWeight += weightDeliveredCases;

                if (isPallettedNum > 0)
                {
                    string delPalletSQL = "DELETE PALLET_ITEM WHERE ORDER_ID = " + orderID + " AND INV_ID =" + invID + " AND PALLET_ID = " + existing_pallet_ID + "";
                    OleDbCommand cmdDelPallet = new OleDbCommand(delPalletSQL, conn);
                    cmdDelPallet.ExecuteNonQuery();

                    //totalWeight -= weightDeliveredCases;
                    string insertnewPalletSQL = "INSERT INTO PALLET_ITEM(ORDER_ID, PALLET_ID, INV_ID, PALLET_STATUS, LOAD_STATUS)"
                      + " VALUES(" + orderID + ", " + new_pallet_ID + ", " + invID + ", 'Palletized', 'Loaded')";
                    OleDbCommand cmdInsertNewPallet = new OleDbCommand(insertnewPalletSQL, conn);
                    cmdInsertNewPallet.ExecuteNonQuery();
                    //totalWeight += weightDeliveredCases;

                }
                else if (isPallettedNum == 0)
                {
                    if (palletDupNum == 0)
                    {
                        string insertPalletSQL = "INSERT INTO PALLET_ITEM(ORDER_ID, PALLET_ID, INV_ID, PALLET_STATUS, LOAD_STATUS)"
                            + " VALUES(" + orderID + ", " + new_pallet_ID + ", " + invID + ", 'Incomplete', 'Waiting')";
                        OleDbCommand cmdInsertPallet = new OleDbCommand(insertPalletSQL, conn);
                        cmdInsertPallet.ExecuteNonQuery();
                        GlobalMethods.GlobalMethods.storeAudit("", "", "Assigned");
                        //totalWeight += weightDeliveredCases;

                        string ordItem = "UPDATE ORD_ITEM SET PALLET_ID = " + new_pallet_ID + ", ASM_USER = " + asmUserID + ""
                        + " WHERE INV_ID = " + invID + " AND ORDER_ID =" + orderID + "";
                        OleDbCommand cmdordItem = new OleDbCommand(ordItem, conn);
                        cmdordItem.ExecuteNonQuery();

                        formProcessOrder_Load(sender, e);


                    }
                    else
                    {
                        MessageBox.Show("Pallet ID is duplicated. Please choose another pallet or add new pallet ID", "Pallet ID Duplication");
                        //comboBoxPalletID.SelectedIndex = 1;
                        numericUpDownPalletID.Value = Convert.ToInt32(new_pallet_ID);

                    }

                }

                conn.Close();




            }

        }

        //figure out the Pallet Status
        public void checkPalletStatus()
        {
            string palletStatusSQL = "SELECT PALLET_STATUS FROM PALLET_ITEM WHERE ORDER_ID = " + orderID + " AND INV_ID =" + invID + " AND PALLET_ID = " + existing_pallet_ID + "";
            OleDbCommand cmdPalletStatus = new OleDbCommand(palletStatusSQL, conn);
            palletStatus = cmdPalletStatus.ExecuteScalar().ToString();
        }

        //figure out Pallet matches the location & status
        public void checkPalletDuplication()
        {

            string palletDuplicationSQL = "SELECT PALLET_ID, ORDER_ID FROM PALLET_ITEM WHERE PALLET_ID =" + new_pallet_ID + " AND INV_ID = "+invID+"";
            OleDbCommand cmdpalletDuplication = new OleDbCommand(palletDuplicationSQL, conn);
            OleDbDataAdapter odaPalletDuplication = new OleDbDataAdapter(cmdpalletDuplication);
            DataTable tablePalletDuplication = new DataTable();
            odaPalletDuplication.Fill(tablePalletDuplication);
            palletDupNum = tablePalletDuplication.Rows.Count;

            //if (palletDupNum > 0)
            //{

            //}
            
            //palletDupNum = Convert.ToInt32(cmdpalletDuplication.ExecuteScalar().ToString());
        }

        //figure out the Load Status
        public void checkLoadStatus()
        {
            string loadStatusSQL = "SELECT LOAD_STATUS FROM PALLET_ITEM WHERE ORDER_ID = " + orderID + " AND INV_ID =" + invID + " AND PALLET_ID = " + existing_pallet_ID + "";
            OleDbCommand cmdLoadStatus = new OleDbCommand(loadStatusSQL, conn);
            load_status = cmdLoadStatus.ExecuteScalar().ToString();
        }


        //figure out the Ordered location
        public void checkOrderedLocation()
        {
            string orderedLocationSQL = "SELECT LOCATION FROM INVENTORY WHERE INV_ID =" + invID + "";
            OleDbCommand cmdorderedLocation = new OleDbCommand(orderedLocationSQL, conn);
            orderedLocation = cmdorderedLocation.ExecuteScalar().ToString();
        }

        //figure out the Pallet location (destination)
        public void checkPalletDestination()
        {
            checkOrderedLocation();
            string palletDestinationSQL = "SELECT LOCATION FROM INVENTORY WHERE INV_ID =" + invID + "";
            OleDbCommand cmdPalletDestination = new OleDbCommand(palletDestinationSQL, conn);
            palletDestination = cmdPalletDestination.ExecuteScalar().ToString();
        }



        //figure out Assign Status
        public Boolean checkAllAssigned()
        {
            conn.Open();
            allAssigned = false;
            string allItemSQL = "SELECT COUNT(*) FROM ORD_ITEM WHERE ORDER_ID = " + orderID + "";
            OleDbCommand cmdallItem = new OleDbCommand(allItemSQL, conn);
            int allItemNum = Convert.ToInt32(cmdallItem.ExecuteScalar().ToString());
            conn.Close();

            conn.Open();
            string allAssignedtatusSQL = "SELECT COUNT(ASM_USER) FROM ORD_ITEM WHERE ORDER_ID = " + orderID + "";
            OleDbCommand cmdallAssignedtatus = new OleDbCommand(allAssignedtatusSQL, conn);
            int assignedNum = Convert.ToInt32(cmdallAssignedtatus.ExecuteScalar().ToString());
            conn.Close();
            if (allItemNum == assignedNum)
            {
                if (assignedNum == 0)
                {
                    conn.Open();
                    //find max pallet ID
                    string maxPalletID = "SELECT MAX(PALLET_ID) FROM ORD_ITEM";
                    OleDbCommand cmdmaxPalletID = new OleDbCommand(maxPalletID, conn);
                    conn.Close();
                    max_pallet_ID = cmdmaxPalletID.ExecuteScalar().ToString();
                    new_pallet_ID = max_pallet_ID + 1;

                    new_pallet_ID = (Convert.ToInt32(max_pallet_ID) + 1).ToString();
                    return allAssigned = false;
                }

                else
                {
                    conn.Open();
                    string assignedPallet = "SELECT DISTINCT PALLET_ID FROM ORD_ITEM WHERE ORDER_ID = " + orderID + "";
                    OleDbCommand cmdAssignedPalletID = new OleDbCommand(assignedPallet, conn);
                    existing_pallet_ID = cmdAssignedPalletID.ExecuteScalar().ToString();
                    conn.Close();
                    return allAssigned = true;
                }

                
            }
            else
            {
                if (assignedNum == 0)
                {
                    conn.Open();
                    //find max pallet ID
                    string maxPalletID = "SELECT MAX(PALLET_ID) FROM ORD_ITEM";
                    OleDbCommand cmdmaxPalletID = new OleDbCommand(maxPalletID, conn);
                    max_pallet_ID = cmdmaxPalletID.ExecuteScalar().ToString();
                    conn.Close();
                    new_pallet_ID = max_pallet_ID + 1;

                    new_pallet_ID = (Convert.ToInt32(max_pallet_ID) + 1).ToString();
                    return allAssigned = false;
                }

                return allAssigned = false;
            }
        }


    }
}
