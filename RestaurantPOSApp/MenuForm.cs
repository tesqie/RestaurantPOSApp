using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantPOSApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void employeeLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryForm f = new InventoryForm();
            f.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryForm f = new InventoryForm();
            f.Show();
        }
    }
}
