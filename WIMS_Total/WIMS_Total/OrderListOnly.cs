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

namespace OrderListDetail
{
    public partial class formOrderListOnly : Form
    {
        public formOrderListOnly()
        {
            InitializeComponent();
            //locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
        }

        //Create the database connection
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE; User ID=Bullseye; Password=1111;Unicode=True");
        //;Integrated Security=SSPI



        private void formOrderListOnly_Load(object sender, EventArgs e)
        {
            displayDetailOrderInfo();
        }

        private void displayDetailOrderInfo()
        {
            String detailOrdItemsSql = "SELECT I.INV_ID, P.BE_SKU, P.SUP_SKU,  I.QOH, OI.ORD_QTY, P.PROD_NAME, P.PROD_COLOR, P.PROD_DESC, P.PROD_SIZE, I.LOCATION, O.ORDER_STATUS"
      + " FROM ORDERS O JOIN ORD_ITEM OI ON O.ORDER_ID = OI.ORDER_ID JOIN INVENTORY I ON OI.INV_ID = I.INV_ID JOIN PRODUCT P ON I.PROD_ID = P.PROD_ID"
      + " WHERE OI.ORDER_ID = " + Orders.formOrders.orderID + " AND I.INV_ID = "
      + Orders.formOrders.invID + " AND I.LOCATION = " + GlobalMethods.GlobalMethods.USERLOCATION + "";
            //MessageBox.Show(detailOrdItemsSql.ToString());
            OleDbCommand cmdDetailItem = new OleDbCommand(detailOrdItemsSql, conn);
            OleDbDataAdapter odaDetailItem = new OleDbDataAdapter(cmdDetailItem);
            DataTable tableDetailItem = new DataTable();
            odaDetailItem.Fill(tableDetailItem);
            dataGridViewOrderDetail.DataSource = tableDetailItem;

        }

        private void buttonAddItems_Click(object sender, EventArgs e)
        {
            formAddOrderItems addItems = new formAddOrderItems();
            addItems.ShowDialog();
            this.Close();
        }


    }
}
