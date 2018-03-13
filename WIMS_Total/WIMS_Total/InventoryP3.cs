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
using BEProducts;

namespace InventoryP3
{
    public partial class formInventoryP3 : Form
    {
        public formInventoryP3()
        {
            InitializeComponent();
            //locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
        }

        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

        private void formInventoryP3_Load(object sender, EventArgs e)
        {
            labelInfo.Text = GlobalMethods.GlobalMethods.USERFULLNAME + "  " + "User ID: " + GlobalMethods.GlobalMethods.USER_ID + " Location:" + GlobalMethods.GlobalMethods.USER_LOCATION_NAME;

        }

        //Display result values into controls
        public void FillInvDGV(string valueTosearch2)
        {
            int invSearchResult;
            int prodSearchResult;
            string baseSelectedTosearch = "";
            int selectedBaseIndex = comboBoxInvSearch.SelectedIndex;

            dataGridViewInventory.AllowUserToAddRows = false; // To set allowance for DGV

            switch (selectedBaseIndex)  //define the base to search
            {
                case 0:
                    {
                        baseSelectedTosearch = "INV_ID";
                        break;
                    }
                case 1:
                    {
                        baseSelectedTosearch = "PROD_ID";
                        break;
                    }
                case 2:
                    {
                        baseSelectedTosearch = "PROD_NAME";
                        break;
                    }
                case 3:
                    {
                        baseSelectedTosearch = "BE_SKU";
                        break;
                    }
                case 4:
                    {
                        baseSelectedTosearch = "SUP_SKU";
                        break;
                    }
            }




            if (GlobalMethods.GlobalMethods.USER_ACCESS_LEVEL == "2") //Access Level of Warehouse Manager
            {
                //    if (baseSelectedTosearch != "INV_ID")
                //    {
                //        string toSearchProduct = "SELECT PROD_ID, BE_SKU, SUP_SKU, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, PROD_WEIGHT, CAT_ID, CASE_COUNT, SUP_ID "
                //        + "FROM PRODUCT "
                //        + "WHERE lower(" + baseSelectedTosearch + ") LIKE '%" + valueTosearch2.ToLower() + "%' "
                //        + "ORDER BY PROD_ID ASC, CAT_ID ASC";

                //        OleDbCommand cmdProd = new OleDbCommand(toSearchProduct, conn);
                //        OleDbDataAdapter odaProd = new OleDbDataAdapter(cmdProd);
                //        DataTable tableProd = new DataTable();
                //        odaProd.Fill(tableProd);
                //        prodSearchResult = tableProd.Rows.Count;

                //        if (prodSearchResult == 0)
                //        {
                //            DialogResult ins = MessageBox.Show("No Product found. Do you want to add a new Product", "Data not found", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                //            if (ins == DialogResult.Yes)
                //            {
                //                formProductMain prodAdd = new formProductMain();
                //                prodAdd.Show();
                //                this.Hide();
                //            }
                //            else if (ins == DialogResult.No)
                //            {
                //                MessageBox.Show("Please input another search keyword.", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //                comboBoxInvSearch.SelectedIndex = 1;
                //                textBoxInvSearchKeyword.Text = "";
                //                textBoxInvSearchKeyword.Focus();
                //            }

                //        }
                //        else
                //        {
                //            string searchInvStatement = "SELECT INV_ID, PROD_ID, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, MIN_QTY, MAX_QTY, CASE_COUNT, LOC_NAME "
                //     + "FROM PRODUCT INNER JOIN INVENTORY USING(PROD_ID) INNER JOIN LOCATION USING(LOCATION)"
                //     + "WHERE lower(" + baseSelectedTosearch + ") LIKE '%" + valueTosearch2.ToLower() + "%' "
                //     + "ORDER BY INV_ID ASC, PROD_ID ASC";

                //            OleDbCommand cmdInv = new OleDbCommand(searchInvStatement, conn);
                //            OleDbDataAdapter odaInv = new OleDbDataAdapter(cmdInv);
                //            DataTable tableInv = new DataTable();
                //            odaInv.Fill(tableInv);
                //            invSearchResult = tableInv.Rows.Count;


                //        }


                //    }


                //    string searchInvStatement = "SELECT INV_ID, PROD_ID, PROD_NAME, PROD_COLOR, PROD_DESC, PROD_TYPE, PROD_SIZE, MIN_QTY, MAX_QTY, CASE_COUNT, LOC_NAME "
                //                    +"FROM PRODUCT INNER JOIN INVENTORY USING(PROD_ID) INNER JOIN LOCATION USING(LOCATION)"
                //                    + "WHERE lower("+ baseSelectedTosearch +") LIKE '%" + valueTosearch2.ToLower() + "%' "
                //                    + "ORDER BY INV_ID ASC, PROD_ID ASC";

                //    OleDbCommand cmd1 = new OleDbCommand(searchInvStatement, conn);
                //    OleDbDataAdapter oda1 = new OleDbDataAdapter(cmd1);
                //    DataTable table1 = new DataTable();
                //    oda1.Fill(table1);
                //    invSearchResult = table1.Rows.Count;

                //    if (invSearchResult == 0)
                //    {
                //        dataGridViewInventory.DataSource = null;
                //        MessageBox.Show("No Inventory found. Please input another search keyword or Add Inventory first.", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        textBoxInvSearchKeyword.Text = "";
                //        textBoxInvSearchKeyword.Focus();
                //    }


                //}
            }


        }






    }
}
