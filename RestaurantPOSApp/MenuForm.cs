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
    //need 2D array with item and qty
    //String array with item id,qty
    
    public partial class Form1 : Form
    {
        public List<string> orderedItems;
        int listno = 1;
        DataSet1 ds;
        MenuTableAdapter mta;
        public Form1()
        {
            InitializeComponent();
        }
        private void Get_Data()
        {
            ds = new DataSet1();
            mta = new MenuTableAdapter();

            mta.Fill(ds.Menu);

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            InvoiceForm form1 = new InvoiceForm();
            form1.Show();
            Tables tables = new Tables();
            tables.Show();
            Get_Data();
            DataRow[] dr = ds.Menu.Select("MealType = 'Breakfast'");

            label2.Text = dr[0][2].ToString();
            label7.Text = dr[0][3].ToString();
            richTextBox1.Text = dr[0][4].ToString();

            label3.Text = dr[1][2].ToString();
            label8.Text = dr[1][3].ToString();
            richTextBox2.Text = dr[1][4].ToString();

            label4.Text = dr[2][2].ToString();
            label9.Text = dr[2][3].ToString();
            richTextBox3.Text = dr[2][4].ToString();

            label5.Text = dr[3][2].ToString();
            label10.Text = dr[3][3].ToString();
            richTextBox4.Text = dr[3][4].ToString();

            label6.Text = dr[4][2].ToString();
            label11.Text = dr[4][3].ToString();
            richTextBox5.Text = dr[4][4].ToString();

            this.BackgroundImage = Properties.Resources.menu_frame;


        }

       

        private void inventoryToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            InventoryForm f = new InventoryForm();
            f.Show();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            addItemToInv(label2, label7);




        }
        private void addItemToInv(Label name, Label price)
        {
           
            bool taken = false;
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[1].Text == name.Text)
                {
                    int x = int.Parse(item.SubItems[2].Text);
                    double itemPrice = double.Parse(item.SubItems[3].Text);
                    item.SubItems[2].Text = (++x).ToString();
                    item.SubItems[3].Text = (itemPrice * 2).ToString();
                    taken = true;
                }

            }
            if (!taken)
            {
                String[] row = { listno++.ToString(), name.Text, "1", price.Text };
                ListViewItem lvi = new ListViewItem(row);
                listView1.Items.Add(lvi);
            }
            double subtotal = 0;
            foreach (ListViewItem items in listView1.Items)
            {
                subtotal += double.Parse(items.SubItems[3].Text);
            }
            double tax = subtotal * 0.13;
            double total = subtotal + tax;
            textBox1.Text = Math.Round(subtotal, 2).ToString();
            textBox2.Text = Math.Round(tax, 2).ToString();
            textBox3.Text = Math.Round(total, 2).ToString();

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            addItemToInv(label3, label8);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            addItemToInv(label4, label9);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            addItemToInv(label5, label10);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            addItemToInv(label6, label11);
        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            DataRow[] dr = ds.Menu.Select();
            foreach(DataRow)
            foreach (ListViewItem items in listView1.Items)
            {
                items.SubItems[0]
            }
            */
        }
    }
}
