using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using BECategory;
using BESeason;
using BEProducts;
using BEInventory;
using BELogIn;
using InventoryP3;
using InventoryNew;
using ListAdjustment;
using AdjustInventory;
using AddOrderItems;
using Orders;
using OrderForWarehouse;
using Shipping;
using GlobalMethods;
using System.Data.OleDb;




namespace BENewMainMenu

{
    public partial class formMaintainDB : Form
    {
        public formMaintainDB()
        {
            InitializeComponent();

            //Locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;

            //if (BELogIn.FormUserLogIn.USERLOCATION == "SJ Warehouse")
            //{

            //}
        }

        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

        //Pop up new form
        private void buttonSeasonMenu_Click(object sender, EventArgs e)
        {
            //ProcessStartInfo start = new ProcessStartInfo();
            //start.FileName = @"C:\ISDP\BESeason\BESeason\bin\Debug\BESeason.exe";
            //Process.Start(start);
        }

        private void buttonProductMenu_Click(object sender, EventArgs e)
        {

            //ProcessStartInfo start = new ProcessStartInfo();
            //start.FileName = @"C:\ISDP\BEProducts\BEProducts\bin\Debug\BEProducts.exe";
            //Process.Start(start);
        }

        private void buttonCategoryMenu_Click(object sender, EventArgs e)
        {
            //ProcessStartInfo start = new ProcessStartInfo();
            //start.FileName = @"C:\ISDP\BECategory\BECategory\obj\Debug\BECategory.exe";
            //Process.Start(start);
        }

        private void formMaintainDB_FormClosed(object sender, FormClosedEventArgs e)
        {
            formNewMainMenu newMainMenu = new formNewMainMenu();
            newMainMenu.Show();
        }

        private void buttonMaintainCategory_Click(object sender, EventArgs e)
        {
            formCategory formCategory = new formCategory();
            formCategory.Show();
            this.Hide();
        }

        private void buttonMaintainSeason_Click(object sender, EventArgs e)
        {
            //ProcessStartInfo start = new ProcessStartInfo();
            //start.FileName = @"C:\ISDP\BESeason\BESeason\bin\Debug\BESeason.exe";
            //Process.Start(start);
            formSeason formSeason = new formSeason();
            formSeason.Show();
            this.Hide();
        }

        private void buttonMaintainProducts_Click(object sender, EventArgs e)
        {
            formProductMain productMain = new formProductMain();
            productMain.Show();
            //this.Hide();
        }

        private void buttonMaintainInventoryDesktop_Click(object sender, EventArgs e)
        {
            FormInventory formInventory = new FormInventory();
            formInventory.Show();
            //this.Hide();
        }

        private void buttonAdjInv_Mobile_Click(object sender, EventArgs e)
        {
            formScannerLogin formScanner = new formScannerLogin();
            formScanner.Show();
            //this.Hide();

        }

        private void buttonManageInv_Click(object sender, EventArgs e)
        {
            formAdjustInventory formAdjInv = new formAdjustInventory();
            formAdjInv.Show();            
            //this.Hide();
        }

        private void buttonListAdjustment_Click(object sender, EventArgs e)
        {
            formListAdjustment listAdjustment = new formListAdjustment();
            listAdjustment.Show();
           // this.Hide();
        }

        private void buttonManageInv3_Click(object sender, EventArgs e)
        {
            formInventoryP3 formInvP3 = new formInventoryP3();
            formInvP3.Show();
            //this.Hide();
            
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            formAddOrderItems formAddOrderItems = new formAddOrderItems();
            formAddOrderItems.Show();
        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            formOrders formOrd = new formOrders();
            this.Hide();
            formOrd.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formOrderForWarehouse formOrdWH = new formOrderForWarehouse();
            this.Hide();
            formOrdWH.ShowDialog();
            this.Show();
        }

        private void buttonOrderMenu_Click(object sender, EventArgs e)
        {
            if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "1")
            {
                formOrderForWarehouse formWH = new formOrderForWarehouse();
                this.Hide();
                formWH.ShowDialog();
                this.Show();
            }
            else if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "2")
            {
                formOrders formOrd = new formOrders();
                this.Hide();
                formOrd.ShowDialog();
                this.Show();
            }
        }

        private void buttonAssemble_Click(object sender, EventArgs e)
        {
            if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "9" || GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "1")
            {

                string toSearchOrderItem = "SELECT OI.PALLET_ID, OI.INV_ID, OI.QTY_DELIVERD, OI.ORDER_ID, PI.PALLET_STATUS, PI.LOAD_STATUS"
                + " FROM ORD_ITEM OI, PALLET_ITEM PI "
                + " WHERE OI.ASM_USER = " + GlobalMethods.GlobalMethods.USER_ID + " AND OI.ORDER_ID = PI.ORDER_ID AND OI.PALLET_ID = PI.PALLET_ID AND OI.INV_ID = PI.INV_ID AND PI.LOAD_STATUS != 'Truck' "
                + " ORDER BY OI.PALLET_ID";

                OleDbCommand cmdOrdItem = new OleDbCommand(toSearchOrderItem, conn);
                OleDbDataAdapter odaOrdItem = new OleDbDataAdapter(cmdOrdItem);
                DataTable tableOrdItemList = new DataTable();
                odaOrdItem.Fill(tableOrdItemList);
                int ordItemNum = tableOrdItemList.Rows.Count;

                if (ordItemNum > 0)
                {
                    formShipping formShipping = new formShipping();
                    this.Hide();
                    formShipping.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("There is no orders to Assemble.", "No Job Order");
                    formShipping formShipping = new formShipping();
                    this.Hide();
                    formShipping.ShowDialog();
                    this.Show();

                }
                


            }

        }

    }
}
