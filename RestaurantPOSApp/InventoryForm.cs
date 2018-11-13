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
    public partial class InventoryForm : Form

    {
        DataSet1 ds;


        InventoryTableAdapter st;
        SuppliersTableAdapter ct;
        public InventoryForm()
        {
            InitializeComponent();
        }

        private void get_data()
        {
            ds = new DataSet1();

            st = new InventoryTableAdapter();
            st.Fill(ds.Inventory);

            ct = new SuppliersTableAdapter();
            ct.Fill(ds.Suppliers);

        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.menu_frame;
            get_data();
            dataGridView1.DataSource = ds.Inventory;
            panel3.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel2.Show();
        }
    }
}
