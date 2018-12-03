using RestaurantPOSApp.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace RestaurantPOSApp
{
    public partial class InventoryForm : Form

    {
        public static List<string> invOrderedItems;

        // Create Dataset and Table Adapters
        DataSet1 ds;
        EmployeesTableAdapter et;
        InventoryTableAdapter st;
        SuppliersTableAdapter ct;
        Tables tableForm;
        Form1 menuForm;

        public InventoryForm()
        {
            InitializeComponent();
        }
        public InventoryForm(Tables tableForm, Form1 menuForm)
        {
            this.tableForm = tableForm;
            this.menuForm = menuForm;
            InitializeComponent();
        }

        //connection to the database
        private void get_data()
        {
            ds = new DataSet1();

            st = new InventoryTableAdapter();
            st.Fill(ds.Inventory);

            ct = new SuppliersTableAdapter();
            ct.Fill(ds.Suppliers);

            et = new EmployeesTableAdapter();
            et.Fill(ds.Employees);

        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            //setting Background picture
            this.BackgroundImage = Properties.Resources.menu_frame;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetDesktopLocation(300, 100);

            // get the username from inventory table
            get_data();
            dataGridView1.DataSource = ds.Inventory;

            DataRow[] dr = ds.Employees.Select("EmployeeID = " + int.Parse(Form1.employeeId));
            foreach (DataRow d in dr)
            {
                label13.Text = label13.Text + d[1].ToString() + " ?";
            }

            // Create time and date for now
            DateTime date = new DateTime();
            date = System.DateTime.Now;
            label15.Text = date.ToShortDateString();
            label18.Text = date.ToShortTimeString();


            panel3.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        //Bring up the Edit Inventory tab -Edit button
        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Show();
            errorProvider1.Clear();
        }

        //Bring up the Order Inventory tab  -Order button
        private void button4_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            panel3.Hide();
            panel2.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        // Fill in information once clicked on datagridview - Row click
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

        // Fill in information once clicked on datagridview - Cell click
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

        //Update the database
        private void btn_update_Click(object sender, EventArgs e)
        {
            //varaibales to test if int or string
            DataRow[] dr;
            string x = txt_productID.Text.ToString();
            string y = txt_price.Text.ToString();
            string z = txt_qtyH_b.Text.ToString();
            int value = 0;
            double value2 = 0;

            // Validate Product ID
            if (txt_productID.Text == "" || txt_productID == null)
            {
                errorProvider1.SetError(txt_productID, "Enter a product ID");
            }
            else
            {// Validate Item in list or not
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

                    // Validate if Price is int or string
                    if (int.TryParse(x, out value))
                    {
                        // Validate if Price is NULL
                        if (txt_price.Text == "" || txt_price == null)
                        {
                            errorProvider1.SetError(txt_price, "Enter a price");
                        }
                        else
                        {
                            // Validate if Qty is int or String
                            if (double.TryParse(y, out value2))
                            {
                                if (double.Parse(y) > 0)
                                {
                                    // Validate if Qty is NULL
                                    if (txt_qtyH_b.Text == "" || txt_qtyH_b == null)
                                    {
                                        errorProvider1.SetError(txt_qtyH_b, "Enter a Qty");
                                    }
                                    else
                                    {
                                        // Validate if Product ID is int or String
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
            // Variable to test of QTY is int or String
            DataRow[] dr;
            string x = txt_qtyB_o.Text.ToString();
            int value = 0;

            // Validate if Product Name is NULL
            if (txt_product_name_o.Text == "" || txt_product_name_o == null)
            {
                errorProvider1.SetError(txt_product_name_o, "Enter an Item");
            }
            else
            {
                // Validate if Qty is NULL
                if (txt_qtyB_o.Text == "" || txt_qtyB_o == null)
                    errorProvider1.SetError(txt_qtyB_o, "Enter a Qty");
                else
                {
                    // Validate if inventory is in the list
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
                        // Validate if Qty is int or String 
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
                                AddItems(txt_productID.Text, txt_product_name_o.Text, txt_qtyB_o.Text);
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

        // Check if Qty entered is greater than threshold
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

        // Add Items to the list that will be passed to invoice form
        private void AddItems(String id, String name, String qty)
        {


            bool taken = false;
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.SubItems[1].Text == name)
                {
                    int x = int.Parse(item.SubItems[2].Text);
                    int y = int.Parse(txt_qtyB_o.Text);
                    item.SubItems[2].Text = (x + y).ToString();
                    taken = true;
                }

            }
            if (!taken)
            {
                String[] items = { id, name, qty };
                ListViewItem listItem = new ListViewItem(items);
                listView2.Items.Add(listItem);
            }
        }

        // Remove all Items from the list in the listbox
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView2.Items)
            {
                item.Remove();
            }
        }

        // Remove items from inventory list
        private void removeItemFromInv(Label name, Label price)
        {
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.SubItems[1].Text == name.Text)
                {
                    int x = int.Parse(item.SubItems[2].Text);
                    if (x == 1)
                    {
                        item.Remove();
                    }
                    item.SubItems[2].Text = (--x).ToString();

                }
            }
        }

        // Add items selected and their qtys to two arrays
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            List<string> qty = new List<string>();
            invOrderedItems = new List<string>();
            int i = 0;
            if (listView2.Items.Count == 0)
            {
                listView2.Text = "Empty List, Please Select an Item to order";
            }
            else
            {
                listView2.Text = "";
                foreach (ListViewItem item in listView2.Items)
                {
                    items.Add(item.SubItems[0].Text);
                    qty.Add(item.SubItems[2].Text);
                    invOrderedItems.Add(items[i].ToString() + "," + qty[i].ToString());
                    i++;
                }


                InvoiceForm invForm = new InvoiceForm(true,this);
                invForm.Show();
                this.Visible = false;
            }
        }

        // Go to the menuform
        private void label14_Click(object sender, EventArgs e)
        {
            //Form1 invForm = new Form1();
            menuForm.Show();
            this.Hide();
        }

        // Go to the menuform
        private void label13_Click(object sender, EventArgs e)
        {
            //Form1 invForm = new Form1();
            menuForm.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableForm.Show();
            this.Close();

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuForm.Show();
            this.Close();
        }
    }
}
