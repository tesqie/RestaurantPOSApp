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


        /* public void TableAvaliable()
         {
             for (int i = 0; i < buttons.Length; i++)
             {
                 //it's important to have this; closing over the loop variable would be bad
                 int index = i;
                 buttons[i].Click += (sender, args) => SomeMethod(buttons[index], index);
             }
         }
         /*public void TablesAvailable()
         {
             int Count = 0;

             ArrayList ar = new ArrayList();
             ar.Add(button1.BackColor == Color.LightGreen);
             ar.Add(button2.BackColor == Color.LightGreen);
             ar.Add(button3.BackColor == Color.LightGreen);
             ar.Add(button4.BackColor == Color.LightGreen);
             ar.Add(button5.BackColor == Color.LightGreen);
             ar.Add(button6.BackColor == Color.LightGreen);
             ar.Add(button7.BackColor == Color.LightGreen);
             ar.Add(button8.BackColor == Color.LightGreen);


             // Count the elements in the ArrayList.
             int c = ar.Count;
             Console.WriteLine(c);

         }*/


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
            if (button1.BackColor == Color.White)
            {
                button1.BackColor = Color.LightGreen;
            }
            else
            {
                button1.BackColor = Color.White;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.White)
            {
                button2.BackColor = Color.LightGreen;
                //ar.Add(
            }
            else
            {
                button2.BackColor = Color.White;
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
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Tables_Load(object sender, EventArgs e)
        {


        }
    }
}
