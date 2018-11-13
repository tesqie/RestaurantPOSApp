using RestaurantPOSApp.DataSet1TableAdapters;
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
        DataSet1 ds;
        MenuTableAdapter mta;
        public Form1()
        {
            InitializeComponent();
        }
        private void Get_Data()
        {

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void inventoryToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            InventoryForm f = new InventoryForm();
            f.Show();

        }
    }
}
