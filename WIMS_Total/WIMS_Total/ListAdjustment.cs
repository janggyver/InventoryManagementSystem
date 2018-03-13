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
using System.Data.OleDb; //To connect DB

using BECategory;
using BESeason;
using BEProducts;
using BEInventory;
using BELogIn;
using BENewMainMenu;
using AdjustInventory;
using GlobalMethods;


namespace ListAdjustment
{
    public partial class formListAdjustment : Form
    {
        public formListAdjustment()
        {
            InitializeComponent();
            //locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
        }

        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");

        private void buttonAdjSearch_Click(object sender, EventArgs e)
        {
            //joining tables with inner join 
            string toSearchAdj = "SELECT * "
                                + "FROM ADJUSTMENT "
                               // + "WHERE lower(" + valueTosearch1Keyword + ") LIKE '%" + valueTosearch2.ToLower() + "%' "
                                + "ORDER BY ADJ_DATE DESC, ADJ_ID ASC";

            OleDbCommand cmd1 = new OleDbCommand(toSearchAdj, conn);
            OleDbDataAdapter oda1 = new OleDbDataAdapter(cmd1);
            DataTable table1 = new DataTable();
            oda1.Fill(table1);

            dataGridViewAdjResults.DataSource = table1;
            dataGridViewAdjResults.Columns[6].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss tt";
        }




    }
}
