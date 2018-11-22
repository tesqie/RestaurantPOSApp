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
        public static List<string> orderedItems;
        int listno = 1;
        DataSet1 ds;
        MenuTableAdapter mta;
        public string employeeId;
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
            Get_Data();
            TimeSpan now = DateTime.Now.TimeOfDay;
            TimeSpan startAM = new TimeSpan(24, 0, 0);
            TimeSpan endAM = new TimeSpan(11, 0, 0);
            TimeSpan startLunch = new TimeSpan(11, 0, 1);
            TimeSpan endLunch = new TimeSpan(15, 0, 0);
            TimeSpan startDinner = new TimeSpan(15, 0, 1);
            TimeSpan endDinner = new TimeSpan(23, 59, 59);
            DataRow[] dr = { };
            if (now > startAM && now < endAM)
            {
                dr = ds.Menu.Select("MenuType = 'Breakfast'");
                label1.Text = "Breakfast Menu";
                pictureBox1.Image = Properties.Resources.bagel;

            }
            else if (now > startLunch && now < endLunch)
            {
                dr = ds.Menu.Select("MenuType = 'Lunch'");
                label1.Text = "Lunch Menu";
                
            }
            else if (now > startDinner && now < endDinner) 
            {
                dr = ds.Menu.Select("MenuType = 'Dinner'");
                label1.Text = "Dinner Menu";
                pictureBox1.Image = Properties.Resources.steak;
            }

            label2.Text = dr[0][2].ToString();
            label7.Text = dr[0][4].ToString();
            richTextBox1.Text = dr[0][3].ToString();

            label3.Text = dr[1][2].ToString();
            label8.Text = dr[1][4].ToString();
            richTextBox2.Text = dr[1][3].ToString();

            label4.Text = dr[2][2].ToString();
            label9.Text = dr[2][4].ToString();
            richTextBox3.Text = dr[2][3].ToString();

            label5.Text = dr[3][2].ToString();
            label10.Text = dr[3][4].ToString();
            richTextBox4.Text = dr[3][3].ToString();

            label6.Text = dr[4][2].ToString();
            label11.Text = dr[4][4].ToString();
            richTextBox5.Text = dr[4][3].ToString();
            this.BackgroundImage = Properties.Resources.menu_frame;
            this.BackgroundImageLayout = ImageLayout.Stretch;

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
        private void removeItemFromInv(Label name,Label price)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[1].Text == name.Text)
                {
                    int x = int.Parse(item.SubItems[2].Text);
                    if(x == 1)
                    {
                        item.Remove();
                    }
                    double itemPrice = double.Parse(item.SubItems[3].Text);
                    item.SubItems[2].Text = (--x).ToString();
                    item.SubItems[3].Text = (itemPrice - double.Parse(price.Text)).ToString();
                    
                }
            }
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
                    item.SubItems[3].Text = (itemPrice + double.Parse(price.Text)).ToString();
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
        {
            Get_Data();
            DataRow[] dr = ds.Menu.Select();
            
            List<string> items = new List<string>();
            List<string> qty = new List<string>();
            orderedItems = new List<string>();
            foreach(ListViewItem item in listView1.Items)
            {
                items.Add(item.SubItems[1].Text);
                qty.Add(item.SubItems[2].Text);
            }
            int i = 0;
            foreach(DataRow d in dr)
            {
                if (items.Contains(d[2].ToString()))
                {
                    orderedItems.Add(d[0].ToString() +"," +qty[i]);
                    i++;
                }
            }
            InvoiceForm invForm = new InvoiceForm();
            invForm.Show();
            

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            removeItemFromInv(label2, label7);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            removeItemFromInv(label3, label8);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            removeItemFromInv(label4, label9);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            removeItemFromInv(label5, label10);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            removeItemFromInv(label6, label11);
        }

        private void employeeLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (panel6.Visible)
            {
                panel6.Visible = false;
            }
            else
            {
                panel6.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Get_Data();
            DataRow[] dr = ds.Employees.Select();
            foreach(DataRow d in dr)
            {
                if(d[2].ToString() == textBox4.Text && d[3].ToString() == textBox5.Text)
                {
                    employeeId = d[0].ToString();
                    Tables tablesForm = new Tables();
                    tablesForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username/Password combination");
                }
            }  
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
