using RestaurantPOSApp.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace RestaurantPOSApp
{

    public partial class Form1 : Form
    {
        DataSet1 ds;
        MenuTableAdapter mta;
        EmployeesTableAdapter eta;
        Tables tablesForm;

        //public List for Invoice form to access the items that were ordered
        public static List<string> orderedItems;
        //list no for items added
        int listno = 1;
        //employee id for Invoice form and table form to access
        public static string employeeId = null;
        bool tableFormInit = false;
        

        public Form1()
        {
            InitializeComponent();
        }

        //Method to access the DB
        private void Get_Data()
        {
            ds = new DataSet1();
            mta = new MenuTableAdapter();
            eta = new EmployeesTableAdapter();

            mta.Fill(ds.Menu);
            eta.Fill(ds.Employees);

        }


        /*  Different menu is shown depending on thr time of day
         * There is 3 menu types, Breakfast, lunch and dinner
         * 
         * 
         * 
         */
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
                pictureBox6.Image = Properties.Resources.omelette;
                pictureBox2.Image = Properties.Resources.toast;
                pictureBox3.Image = Properties.Resources.frenchtoast;
                pictureBox4.Image = Properties.Resources.bacon;

            }
            else if (now > startLunch && now < endLunch)
            {
                dr = ds.Menu.Select("MenuType = 'Lunch'");
                label1.Text = "Lunch Menu";
                pictureBox1.Image = Properties.Resources.meatburger;
                pictureBox6.Image = Properties.Resources.chickenburger;
                pictureBox2.Image = Properties.Resources.veggieburger;
                pictureBox3.Image = Properties.Resources.chickensalad;
                pictureBox4.Image = Properties.Resources.shawarma;

            }
            else if (now > startDinner && now < endDinner)
            {
                dr = ds.Menu.Select("MenuType = 'Dinner'");
                label1.Text = "Dinner Menu";
                pictureBox1.Image = Properties.Resources.steak;
                pictureBox6.Image = Properties.Resources.primerib;
                pictureBox2.Image = Properties.Resources.pasta;
                pictureBox3.Image = Properties.Resources.salad;
                pictureBox4.Image = Properties.Resources.garlicbread;


            }
            //Assigning menu item names from the DB
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

            //Setting the background of the form
            this.BackgroundImage = Properties.Resources.menu_frame;
            this.BackgroundImageLayout = ImageLayout.Stretch;

        }

        //Adding specific item to listview
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            addItemToInv(label2, label7);
        }

        //Method to remove a certain item from the ListView, 1 Click is 1 qty
        //If qty is 1 then it will be removed
        private void removeItemFromInv(Label name, Label price)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[1].Text == name.Text)
                {
                    int x = int.Parse(item.SubItems[2].Text);
                    if (x == 1)
                    {
                        item.Remove();
                    }
                    double itemPrice = double.Parse(item.SubItems[3].Text);
                    item.SubItems[2].Text = (--x).ToString();
                    item.SubItems[3].Text = (itemPrice - double.Parse(price.Text)).ToString();

                }
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
        //Method to add items to ListView, each click adds 1 qty
        //Also updates the sub total and tax
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
        //Adding specific item to listview
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            addItemToInv(label3, label8);
        }
        //Adding specific item to listview
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            addItemToInv(label4, label9);
        }
        //Adding specific item to listview
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            addItemToInv(label5, label10);
        }
        //Adding specific item to listview
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            addItemToInv(label6, label11);
        }

        //Sending order details to Invoice
        private void button1_Click(object sender, EventArgs e)
        {
            //Employee must login first
            if (employeeId == null)
            {
                MessageBox.Show("Please have an employee login first");
                return;
            }
            //Employee must select table to be used
            if(Tables.TableAvailable.Count == 0)
            {
                MessageBox.Show("No tables are available");
                return;
            }
            Get_Data();
            DataRow[] dr = ds.Menu.Select();
            List<string> items = new List<string>();
            List<string> qty = new List<string>();
            orderedItems = new List<string>();
            
            foreach (ListViewItem item in listView1.Items)
            {
                items.Add(item.SubItems[1].Text);
                qty.Add(item.SubItems[2].Text);
            }
            int i = 0;
            //Adding items to the public list orderedItems, for Invoice form to use
            foreach (DataRow d in dr)
            {
                if (items.Contains(d[2].ToString()))
                {
                    orderedItems.Add(d[0].ToString() + "," + qty[i]);
                    i++;
                }
            }
            //Displaying Inv form and making this form hidden
             this.Visible = false;
             InvoiceForm invForm = new InvoiceForm(this);
             invForm.Show(this);
        }
        //Removing specific item from listview
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            removeItemFromInv(label2, label7);
        }
        //Removing specific item from listview
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            removeItemFromInv(label3, label8);
        }
        //Removing specific item from listview
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            removeItemFromInv(label4, label9);
        }
        //Removing specific item from listview
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            removeItemFromInv(label5, label10);
        }
        //Removing specific item from listview
        private void pictureBox15_Click(object sender, EventArgs e)
        {
            removeItemFromInv(label6, label11);
        }
        //Adding a dropdown menu for employee to login
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

        //On login Click, checks if the emplyee username and password are in the DB
        private void button2_Click(object sender, EventArgs e)
        {
            Get_Data();
            DataRow[] dr = ds.Employees.Select();
            foreach (DataRow d in dr)
            {
                if (d[2].ToString() == textBox4.Text && d[3].ToString() == textBox5.Text)
                {
                    employeeId = d[0].ToString();
                    this.Visible = false;
                    if (!tableFormInit)
                    {
                        tablesForm = new Tables(this);
                        tablesForm.Show(this);
                        tableFormInit = true;
                    }
                    else
                        tablesForm.Show(this);
                    return;
                }
            }
            MessageBox.Show("Invalid Username/Password combination");
        }
    }
}
