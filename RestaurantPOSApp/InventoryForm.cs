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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int p_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            string name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string price = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            int qty = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            int supplier = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

            txt_productID.Text = p_id.ToString();
            txt_product_name_o.Text = name;
            txt_product_name_b.Text = name;
            txt_price.Text = price;
            txt_qtyH_o.Text = qty.ToString();
            txt_qtyH_b.Text = qty.ToString();
            lbl_supplierID.Text = supplier.ToString();
            txt_supplierID.Text = supplier.ToString();

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int p_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            string name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string price = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            int qty = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            int supplier = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

            txt_productID.Text = p_id.ToString();
            txt_product_name_o.Text = name;
            txt_product_name_b.Text = name;
            txt_price.Text = price;
            txt_qtyH_o.Text = qty.ToString();
            txt_qtyH_b.Text = qty.ToString();
            lbl_supplierID.Text = supplier.ToString();
            txt_supplierID.Text = supplier.ToString();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            DataRow[] dr = ds.Inventory.Select("ProductID = " + int.Parse(txt_productID.Text));
            foreach (DataRow d in dr)
            {
                d[1] = txt_product_name_b.Text;
                d[2] = txt_price.Text;
                d[3] = int.Parse(txt_qtyH_b.Text);
                d[4] = int.Parse(lbl_supplierID.Text);
            }

            st.Update(ds.Inventory);
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            DataRow[] dr = ds.Inventory.Select("ProductName = '" + txt_product_name_o.Text + "'");
            foreach (DataRow d in dr)
            {

                d[3] = int.Parse(txt_qtyH_o.Text) + int.Parse(txt_qtyB_o.Text);
                txt_qtyH_o.Text = d[3].ToString();

            }

            st.Update(ds.Inventory);
        }
    }
}
