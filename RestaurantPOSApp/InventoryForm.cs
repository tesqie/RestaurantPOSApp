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
            errorProvider1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
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

            if (int.Parse(txt_qtyH_b.Text) <= 10)
            {
                label12.Visible = true;
            }
            else
            {
                label12.Visible = false;
            }

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

            if (int.Parse(txt_qtyH_b.Text) <= 10)
            {
                label12.Visible = true;
            }
            else
            {
                label12.Visible = false;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            DataRow[] dr;
            string x = txt_productID.Text.ToString();
            string y = txt_price.Text.ToString();
            string z = txt_qtyH_b.Text.ToString();
            int value = 0;
            double value2 = 0;

            if (txt_productID.Text == "" || txt_productID == null)
            {
                errorProvider1.SetError(txt_productID, "Enter a product ID");
            }
            else
            {
                List<String> list = new List<String>();
                dr = ds.Inventory.Select();
                foreach (DataRow d in dr)
                {
                    list.Add(d[0].ToString());
                }
                if (!(list.Contains(txt_productID.Text)))
                {
                    errorProvider1.SetError(txt_productID, "ID does not exist");
                }
                else
                {


                    if (int.TryParse(x, out value))
                    {
                        if (txt_price.Text == "" || txt_price == null)
                        {
                            errorProvider1.SetError(txt_price, "Enter a price");
                        }
                        else
                        {
                            if (double.TryParse(y, out value2))
                            {
                                if (double.Parse(y) > 0)
                                {
                                    if (txt_qtyH_b.Text == "" || txt_qtyH_b == null)
                                    {
                                        errorProvider1.SetError(txt_qtyH_b, "Enter a Qty");
                                    }
                                    else
                                    {
                                        if (int.TryParse(z, out value))
                                        {
                                            if (int.Parse(z) > 0)
                                            {

                                                dr = ds.Inventory.Select("ProductID = " + int.Parse(txt_productID.Text));
                                                foreach (DataRow d in dr)
                                                {
                                                    d[1] = txt_product_name_b.Text;
                                                    d[2] = txt_price.Text;
                                                    d[3] = int.Parse(txt_qtyH_b.Text);
                                                    d[4] = int.Parse(lbl_supplierID.Text);
                                                }

                                                st.Update(ds.Inventory);
                                            }
                                            else { errorProvider1.SetError(txt_qtyH_b, "Enter a Positive QTY"); }
                                        }
                                        else { errorProvider1.SetError(txt_qtyH_b, "Enter a valid QTY"); }
                                    }
                                }
                                else { errorProvider1.SetError(txt_price, "Enter a price greater than 0"); }
                            }
                            else { errorProvider1.SetError(txt_price, "Enter a valid price"); }
                        }

                    }
                    else
                    {
                        errorProvider1.SetError(txt_productID, "Enter a valid ID");
                    }
                }
            }
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            DataRow[] dr;
            string x = txt_qtyB_o.Text.ToString();
            int value = 0;

            if (txt_product_name_o.Text == "" || txt_product_name_o == null)
            {
                errorProvider1.SetError(txt_product_name_o, "Enter an Item");
            }
            else
            {

                if (txt_qtyB_o.Text == "" || txt_qtyB_o == null)
                    errorProvider1.SetError(txt_qtyB_o, "Enter a Qty");
                else
                {
                    List<String> list = new List<String>();
                    dr = ds.Inventory.Select();
                    foreach (DataRow d in dr)
                    {
                        list.Add(d[1].ToString());
                    }
                    if (!(list.Contains(txt_product_name_o.Text)))
                    {
                        errorProvider1.SetError(txt_product_name_o, "Item does not exist");
                    }
                    else
                    {

                        if (int.TryParse(x, out value))
                        {
                            if (int.Parse(x) > 0)
                            {
                                errorProvider1.Clear();
                                dr = ds.Inventory.Select("ProductName = '" + txt_product_name_o.Text + "'");
                                foreach (DataRow d in dr)
                                {

                                    d[3] = int.Parse(txt_qtyH_o.Text) + int.Parse(txt_qtyB_o.Text);
                                    txt_qtyH_o.Text = d[3].ToString();

                                }

                                st.Update(ds.Inventory);
                            }
                            else { errorProvider1.SetError(txt_qtyB_o, "Enter a Positive Number"); }
                        }
                        else
                        {
                            errorProvider1.SetError(txt_qtyB_o, "Enter a Number");
                        }
                    }
                }
            }





        }

        private void txt_product_name_o_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txt_qtyB_o_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txt_productID_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txt_price_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txt_qtyH_b_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.Parse(txt_qtyH_b.Text) <= 10)
            {
                label12.Visible = true;
            }
            else
            {
                label12.Visible = false;
            }
        }
    }
}
