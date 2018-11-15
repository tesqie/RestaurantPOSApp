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
    public partial class InvoiceForm : Form
    {
        DataSet1 ds;
        MenuTableAdapter mt;
        InventoryTableAdapter it;
        EmployeesTableAdapter et;
        OrdersTableAdapter ot;
        OrderlineTableAdapter olt;
        SuppliersTableAdapter st;

        int[,] itemID = new int[,] { { 1, 4 }, { 3, 2 }, { 5, 1 } };
        int employeeID = 1;
        int orderID;
        int tableID;
        double salesPrice;

        public InvoiceForm()
        {
            InitializeComponent();
            get_data();
            //this.itemID = arr;
            //this.employeeID = employeeID;
            display_order();
        }

        private void get_data()
        {
            ds = new DataSet1();
            mt = new MenuTableAdapter();
            it = new InventoryTableAdapter();
            et = new EmployeesTableAdapter();
            ot = new OrdersTableAdapter();
            olt = new OrderlineTableAdapter();
            st = new SuppliersTableAdapter();

            mt.Fill(ds.Menu);
            it.Fill(ds.Inventory);
            et.Fill(ds.Employees);
            ot.Fill(ds.Orders);
            olt.Fill(ds.Orderline);
            st.Fill(ds.Suppliers);
        }

        private void display_order()
        {
            double price = 0;
            double tax;
            DataRow[] dr = null;
            for (int i = 0; i < (itemID.Length / itemID.Rank); i++)
            {
                dr = ds.Menu.Select("MenuID = " + itemID[i, 0]);
                foreach (DataRow d in dr)
                {
                    richTextBox1.Text += d[1] + "\t" + d[2] + "\t" + d[3] + "\t";
                    richTextBox1.Text += "Qty: " + itemID[i, 1] + "\n";
                    price += double.Parse(d[3].ToString()) * double.Parse(itemID[i, 1].ToString());
                }
            }

            textBoxPrice.Text = price.ToString();
            tax = price * 0.13;
            textBoxTax.Text = tax.ToString();
            salesPrice = price + tax;
            textBoxTotal.Text = salesPrice.ToString();
        }

        private void orderConfirmation_Click(object sender, EventArgs e)
        {
            DataSet1.OrdersRow or = ds.Orders.NewOrdersRow();

            or.OrderDate = DateTime.Now;
            or.EmployeeID = this.employeeID;

            ds.Orders.AddOrdersRow(or);
            ot.Update(ds.Orders);

            this.orderID = ds.Tables["Orders"].AsEnumerable().Max(x => x.Field<int>("OrderID"));

            DataSet1.OrderlineRow olr = null;

            for (int i = 0; i < (itemID.Length / itemID.Rank); i++)
            {
                olr = ds.Orderline.NewOrderlineRow();
                olr.OrderID = this.orderID;
                olr.MenuID = itemID[i, 0];
                olr.Quantity = itemID[i, 1];

                ds.Orderline.AddOrderlineRow(olr);
                olt.Update(ds.Orderline);
            }
        }
    }
}
