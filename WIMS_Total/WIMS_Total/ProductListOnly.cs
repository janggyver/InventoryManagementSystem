using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdjustInventory;
using GlobalMethods;
using System.Data.OleDb; //To connect DB

namespace ProductListOnly
{
    public partial class formProductListOnly : Form
    {
        public formProductListOnly()
        {
            // TODO: Complete member initialization

        }

        public formProductListOnly(DataTable prodTable)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            dataGridViewProdLists.DataSource = prodTable;
        }





        private void dataGridViewProdLists_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DialogResult ins = MessageBox.Show("Do you want to add a new Inventory for this Product? ", "Choose a Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ins == DialogResult.Yes)
            {


                GlobalMethods.GlobalMethods.PROD_ID = dataGridViewProdLists.CurrentRow.Cells[0].Value.ToString();

                this.Close();

            }

        }

        //private void formProductListOnly_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    DialogResult ins = MessageBox.Show("Do you really want to close this form without selection? ", "Select Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (ins == DialogResult.Yes)
        //    {

        //        this.Close();
        //        formAdjustInventory parentForm = new formAdjustInventory();
        //        parentForm.Show();
        //        this.Close();

        //    }
        //}


    }
}
