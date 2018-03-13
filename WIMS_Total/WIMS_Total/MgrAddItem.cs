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
using ScannerMain;
using System.IO;
using System.Data.OleDb;

namespace ManagerModifyItem
{
    public partial class formMgrModifyItem : Form
    {
        public formMgrModifyItem()
        {
            InitializeComponent();
            //Locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;


        }

        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

        private void formMgrModifyItem_Load(object sender, EventArgs e)
        {
            labelInfo.Text = GlobalMethods.GlobalMethods.USERFULLNAME + "  " + "User ID: " + GlobalMethods.GlobalMethods.USER_ID + " Location:" + GlobalMethods.GlobalMethods.USER_LOCATION_NAME;

            displayOrdItems();
            buttonRemove.Enabled = false;
            buttonModItem.Enabled = false;
            panelMDetail.Visible = false;
        }

        //Display Manager Order List
        public void displayOrdItems()
        {
            string ordList = "SELECT AO.ADD_ORDER_ID, AO.INV_ID, P.BE_SKU, P.SUP_SKU, AO.REQ_QTY"
           + " FROM ADD_ORDER AO , INVENTORY I, PRODUCT P, LOCATION L"
           + " WHERE AO.INV_ID = I.INV_ID AND P.PROD_ID = I.PROD_ID AND I.LOCATION = L.LOCATION AND "
           + "I.LOCATION =" + GlobalMethods.GlobalMethods.USERLOCATION + "";

            // MessageBox.Show(ToSearchSQLInScanner);
            OleDbCommand cmdOrdList = new OleDbCommand(ordList, conn);
            OleDbDataAdapter odaOrdList = new OleDbDataAdapter(cmdOrdList);
            DataTable tableOrdList = new DataTable();
            odaOrdList.Fill(tableOrdList);
            dataGridViewOrdList.DataSource = tableOrdList;
            dataGridViewOrdList.Columns["ADD_ORDER_ID"].Visible = false;
            dataGridViewOrdList.Columns["INV_ID"].Visible = false;
            labelOrdSearchResult.Text = dataGridViewOrdList.RowCount.ToString();
            if (dataGridViewOrdList.RowCount == 0)
            {
                this.Close();
            }
           
        }

        private void dataGridViewOrdList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonRemove.Enabled = true;
            buttonModItem.Enabled = true;
            panelMDetail.Visible = false;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {

            string delItem = "DELETE FROM ADD_ORDER "
                + "WHERE ADD_ORDER_ID = " + dataGridViewOrdList.CurrentRow.Cells[0].Value.ToString() + ""
                + "AND INV_ID = " + dataGridViewOrdList.CurrentRow.Cells[1].Value.ToString() + "";

            OleDbCommand cmdDeleteItem = new OleDbCommand(delItem, conn);
            try
            {
                conn.Open();
                cmdDeleteItem.ExecuteNonQuery();
                formMgrModifyItem_Load(sender, e);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



            //OleDbDataAdapter odaDeleteItem = new OleDbDataAdapter(cmdDeleteItem);
            //DataTable tableDeleteItem = new DataTable();
            //odaDeleteItem.Fill(tableDeleteItem);
            //dataGridViewOrderDetail.DataSource = tableDeleteItem;
        }

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


            textBoxMInvID.Text = dataGridViewOrdList.CurrentRow.Cells[1].Value.ToString();
            textBoxMBE_SKU.Text = dataGridViewOrdList.CurrentRow.Cells[2].Value.ToString();
            textBoxMSUP_SKU.Text = dataGridViewOrdList.CurrentRow.Cells[3].Value.ToString();
            textBoxModQTY.Text = dataGridViewOrdList.CurrentRow.Cells[4].Value.ToString();
            textBoxModQTY.Enabled = true;
        }


        //update order qty from scanner
        private void buttonModConfirm_Click(object sender, EventArgs e)
        {
            string updateOrdQty = "UPDATE ADD_ORDER SET REQ_QTY = ? "
               + "WHERE ADD_ORDER_ID = " + dataGridViewOrdList.CurrentRow.Cells[0].Value.ToString() + ""
                + "AND INV_ID = " + dataGridViewOrdList.CurrentRow.Cells[1].Value.ToString() + "";
            
            OleDbCommand cmdupdateOrdQty = new OleDbCommand(updateOrdQty, conn);
            cmdupdateOrdQty.Parameters.Add("?", OleDbType.VarChar).Value = textBoxModQTY.Text;
            
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
                    displayOrdItems();
                    panelMDetail.Visible = false;
                    formMgrModifyItem_Load(sender, e);

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
                displayOrdItems();
                formMgrModifyItem_Load(sender, e);
            }
        }


    }


    


}
