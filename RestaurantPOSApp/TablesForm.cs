using RestaurantPOSApp.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RestaurantPOSApp
{
    public partial class Tables : Form

    {   //setting up the dataset and tableadapter 
        DataSet1 ds;
        EmployeesTableAdapter et;
        Form1 menuForm;

        //setting a method to get the data from the table
        private void Get_Data()
        {
            ds = new DataSet1();
            et = new EmployeesTableAdapter();
            et.Fill(ds.Employees);
        }
        // creating a list array to store table info
        public static List<int> TableAvailable = new List<int>
        {
        };
        public Tables()
        {
            InitializeComponent();
        }
        public Tables(Form1 form1)
        {
            menuForm = form1;
            InitializeComponent();

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        //creating a menustrip to allowing this page to connect to inventory
        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            InventoryForm inventory1 = new InventoryForm(this,menuForm);
            inventory1.Show();
            
        }



        //by clicking on the picture, it will allow you to go to invoice form, if the button under the image is lightgreen
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.LightGreen)
            {

                InvoiceForm invoice1 = new InvoiceForm();
                invoice1.Show();
            }
        }
        //by clicking on the picture, it will allow you to go to invoice form, if the button under the image is lightgreen
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.LightGreen)
            {

                InvoiceForm invoice1 = new InvoiceForm();
                invoice1.Show();
            }
        }
        //by clicking on the picture, it will allow you to go to invoice form, if the button under the image is lightgreen
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.LightGreen)
            {

                InvoiceForm invoice1 = new InvoiceForm();
                invoice1.Show();
            }
        }
        //by clicking on the picture, it will allow you to go to invoice form, if the button under the image is lightgreen
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.LightGreen)
            {

                InvoiceForm invoice1 = new InvoiceForm();
                invoice1.Show();
            }
        }
        //by clicking on the picture, it will allow you to go to invoice form, if the button under the image is lightgreen
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.LightGreen)
            {

                InvoiceForm invoice1 = new InvoiceForm();
                invoice1.Show();
            }
        }
        //by clicking on the picture, it will allow you to go to invoice form, if the button under the image is lightgreen
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.LightGreen)
            {

                InvoiceForm invoice1 = new InvoiceForm();
                invoice1.Show();
            }
        }
        //by clicking on the picture, it will allow you to go to invoice form, if the button under the image is lightgreen
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.LightGreen)
            {

                InvoiceForm invoice1 = new InvoiceForm();
                invoice1.Show();
            }
        }
        //by clicking on the picture, it will allow you to go to invoice form, if the button under the image is lightgreen
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor == Color.LightGreen)
            {

                InvoiceForm invoice1 = new InvoiceForm();
                invoice1.Show();
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

        }
        // when the user clicks on the button, it will change the background color to lightgreen,
        //but if it is already light green it will change it back to white. 
        //if the array tableAvailable doesnt containt this table,it will add the table ID to the arraylist,
        //but if its already added, then it will remove it(change it back to white). 
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.White)
            {
                button2.BackColor = Color.LightGreen;

            }
            else
            {
                button2.BackColor = Color.White;
            }
            if (!TableAvailable.Contains(2))
            {
                TableAvailable.Add(2);
            }
            else
            {
                TableAvailable.Remove(2);
            }
        }
        // when the user clicks on the button, it will change the background color to lightgreen,
        //but if it is already light green it will change it back to white. 
        //if the array tableAvailable doesnt containt this table, it will add the table ID to the arraylist,
        //but if its already added, then it will remove it(change it back to white). 
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.White)
            {
                button3.BackColor = Color.LightGreen;
            }
            else
            {
                button3.BackColor = Color.White;
            }
            if (!TableAvailable.Contains(3))
            {
                TableAvailable.Add(3);
            }
            else
            {
                TableAvailable.Remove(3);
            }
        }
        // when the user clicks on the button, it will change the background color to lightgreen,
        //but if it is already light green it will change it back to white. 
        //if the array tableAvailable doesnt containt this table, it will add the table ID to the arraylist,
        //but if its already added, then it will remove it(change it back to white). 
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.White)
            {
                button4.BackColor = Color.LightGreen;
            }
            else
            {
                button4.BackColor = Color.White;
            }
            if (!TableAvailable.Contains(4))
            {
                TableAvailable.Add(4);
            }
            else
            {
                TableAvailable.Remove(4);
            }
        }
        // when the user clicks on the button, it will change the background color to lightgreen,
        //but if it is already light green it will change it back to white. 
        //if the array tableAvailable doesnt containt this table, it will add the table ID to the arraylist,
        //but if its already added, then it will remove it(change it back to white). 
        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.White)
            {
                button5.BackColor = Color.LightGreen;
            }
            else
            {
                button5.BackColor = Color.White;
            }
            if (!TableAvailable.Contains(5))
            {
                TableAvailable.Add(5);
            }
            else
            {
                TableAvailable.Remove(5);
            }
        }
        // when the user clicks on the button, it will change the background color to lightgreen,
        //but if it is already light green it will change it back to white. 
        //if the array tableAvailable doesnt containt this table, it will add the table ID to the arraylist,
        //but if its already added, then it will remove it(change it back to white). 
        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.White)
            {
                button6.BackColor = Color.LightGreen;
            }
            else
            {
                button6.BackColor = Color.White;
            }
            if (!TableAvailable.Contains(6))
            {
                TableAvailable.Add(6);
            }
            else
            {
                TableAvailable.Remove(6);
            }
        }
        // when the user clicks on the button, it will change the background color to lightgreen,
        //but if it is already light green it will change it back to white. 
        //if the array tableAvailable doesnt containt this table, it will add the table ID to the arraylist,
        //but if its already added, then it will remove it(change it back to white). 
        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.White)
            {
                button7.BackColor = Color.LightGreen;
            }
            else
            {
                button7.BackColor = Color.White;
            }
            if (!TableAvailable.Contains(7))
            {
                TableAvailable.Add(7);
            }
            else
            {
                TableAvailable.Remove(7);
            }
        }
        // when the user clicks on the button, it will change the background color to lightgreen,
        //but if it is already light green it will change it back to white. 
        //if the array tableAvailable doesnt containt this table, it will add the table ID to the arraylist,
        //but if its already added, then it will remove it(change it back to white). 
        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor == Color.White)
            {
                button8.BackColor = Color.LightGreen;
            }
            else
            {
                button8.BackColor = Color.White;
            }
            if (!TableAvailable.Contains(8))
            {
                TableAvailable.Add(8);
            }
            else
            {
                TableAvailable.Remove(8);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        // when the user clicks on the button, it will change the background color to lightgreen,
        //but if it is already light green it will change it back to white. 
        //if the array tableAvailable doesnt containt this table, it will add the table ID to the arraylist,
        //but if its already added, then it will remove it(change it back to white). 
        private void Tables_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.menu_frame;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            textBox1.ReadOnly = true;
            Get_Data();
            DataRow[] dr = ds.Employees.Select("EmployeeId = '" + Form1.employeeId + "'");
            if (dr.Length == 0)
            {
                MessageBox.Show("Employee Not Found");

            }
            foreach (DataRow d in dr)
            {

                textBox1.Text = d[1].ToString();
            }
            textBox2.Text = DateTime.Now.ToString("hh: mm tt");

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        // when the user clicks on the button, it will change the background color to lightgreen,
        //but if it is already light green it will change it back to white. 
        //if the array tableAvailable doesnt containt this table, it will add the table ID to the arraylist, 
        //but if its already added, then it will remove it(change it back to white). 
        private void button1_Click(object sender, EventArgs e)
        {
            //id 1
            if (button1.BackColor == Color.White)
            {

                button1.BackColor = Color.LightGreen;



            }
            else
            {
                button1.BackColor = Color.White;

            }
            if (!TableAvailable.Contains(1))
            {
                TableAvailable.Add(1);
            }
            else
            {
                TableAvailable.Remove(1);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //On Logout button click this form is hidden and menuform will be shown
        private void button9_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            menuForm.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
