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
        PurchaseOrdersTableAdapter pot;
        PurchaseOrderlineTableAdapter polt;

        int[,] itemID;


        bool forInv = false;
        int employeeID = 1;
        int orderID, purchaseorderID;
        int tableID;
        double salesPrice;

        public InvoiceForm()
        {
            InitializeComponent();
            get_data();
            
            itemID = new int[Form1.orderedItems.Count, 2];

            int id, qt;
            for (int i = 0; i < Form1.orderedItems.Count(); i++)
            {
                string product = Form1.orderedItems[i];
                string[] temp = product.Split(',');
                id = int.Parse(temp[0]);
                qt = int.Parse(temp[1]);

                itemID[i, 0] = id;
                itemID[i, 1] = qt;
            }

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
            pot = new PurchaseOrdersTableAdapter();
            polt = new PurchaseOrderlineTableAdapter();

            mt.Fill(ds.Menu);
            it.Fill(ds.Inventory);
            et.Fill(ds.Employees);
            ot.Fill(ds.Orders);
            olt.Fill(ds.Orderline);
            st.Fill(ds.Suppliers);
            pot.Fill(ds.PurchaseOrders);
            polt.Fill(ds.PurchaseOrderline);
        }

        private void display_order()
        {
            double price = 0;
            double tax;
            DataRow[] dr = null;

            if (forInv == false)
            {
                for (int i = 0; i < (itemID.Length / itemID.Rank); i++)
                {
                    dr = ds.Menu.Select("MenuID = " + itemID[i, 0]);
                    foreach (DataRow d in dr)
                    {
                        richTextBox1.Text += d[1] + "\t" + d[2] + "\t" + d[3] + "\t";
                        richTextBox1.Text += "Qty: " + itemID[i, 1] + "\n";
                        //price += double.Parse(d[3].ToString()) * double.Parse(itemID[i, 1].ToString());
                    }
                }
            }
            else if (forInv == true)
            {
                for (int i = 0; i < (itemID.Length / itemID.Rank); i++)
                {
                    dr = ds.Inventory.Select("ProductID = " + itemID[i, 0]);
                    foreach (DataRow d in dr)
                    {
                        richTextBox1.Text += d[1] + "\t" + d[2] + "\t" + d[3] + "\t";
                        richTextBox1.Text += "Qty: " + itemID[i, 1] + "\n";
                        price += double.Parse(d[3].ToString()) * double.Parse(itemID[i, 1].ToString());
                    }
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
            if (forInv == false)
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
            else if (forInv == true)
            {
                DataSet1.PurchaseOrdersRow por = ds.PurchaseOrders.NewPurchaseOrdersRow();

                por.PurchaseOrderDate = DateTime.Now;
                por.EmployeeID = this.employeeID;

                ds.PurchaseOrders.AddPurchaseOrdersRow(por);
                pot.Update(ds.PurchaseOrders);

                this.purchaseorderID = ds.Tables["PurchaseOrders"].AsEnumerable().Max(x => x.Field<int>("PurchaseOrderID"));

                DataSet1.PurchaseOrderlineRow polr = null;

                for (int i = 0; i < (itemID.Length / itemID.Rank); i++)
                {
                    polr = ds.PurchaseOrderline.NewPurchaseOrderlineRow();
                    polr.PurchaseOrderID = this.purchaseorderID;
                    polr.ProductID = itemID[i, 0];
                    polr.Quantity = itemID[i, 1];

                    ds.PurchaseOrderline.AddPurchaseOrderlineRow(polr);
                    polt.Update(ds.PurchaseOrderline);
                }
            }
        }
    }
}
