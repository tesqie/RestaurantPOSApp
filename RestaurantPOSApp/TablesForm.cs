using RestaurantPOSApp.DataSet1TableAdapters;
using System;
using System.Collections;
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
    public partial class Tables : Form

    {
        DataSet1 ds;
        EmployeesTableAdapter et;
        private void Get_Data()
        {
            ds = new DataSet1();
            et = new EmployeesTableAdapter();
            et.Fill(ds.Employees);
        }
        public static List<int> TableAvailable = new List<int>
        {
        };
        public Tables()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MenuForm menu1 = new MenuForm(); 
            //menu1.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryForm inventory1 = new InventoryForm();
            inventory1.Show();
        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.LightGreen)
            {

                InvoiceForm invoice1 = new InvoiceForm();
                invoice1.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.LightGreen)
            {

                InvoiceForm invoice1 = new InvoiceForm();
                invoice1.Show();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.LightGreen)
            {

                InvoiceForm invoice1 = new InvoiceForm();
                invoice1.Show();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.LightGreen)
            {

                InvoiceForm invoice1 = new InvoiceForm();
                invoice1.Show();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.LightGreen)
            {

                InvoiceForm invoice1 = new InvoiceForm();
                invoice1.Show();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.LightGreen)
            {

                InvoiceForm invoice1 = new InvoiceForm();
                invoice1.Show();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.LightGreen)
            {

                InvoiceForm invoice1 = new InvoiceForm();
                invoice1.Show();
            }
        }

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

        private void Tables_Load(object sender, EventArgs e)
        {
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
            textBox2.Text = DateTime.Now.TimeOfDay.ToString();

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

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

        private void button9_Click(object sender, EventArgs e)
        {
            Form1 MenuForm = new Form1();
            MenuForm.Show();
        }
    }
}
