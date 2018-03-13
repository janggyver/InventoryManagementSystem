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
using LOGIN;





namespace BENewMainMenu
{
    public partial class formNewMainMenu : Form
    {
        public formNewMainMenu()
        {
            InitializeComponent();

            //Locate the form in the center of the screen
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonMaintainDB_Click(object sender, EventArgs e)
        {

            //Form maintainDB = new Form();

            formMaintainDB maintainDB = new formMaintainDB();
            maintainDB.Show();
            this.Hide();
            
        }

        private void formNewMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormLOGIN formLogin = new FormLOGIN();
            formLogin.Show();
        }

    }
}
