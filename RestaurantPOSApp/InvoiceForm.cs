using RestaurantPOSApp.DataSet1TableAdapters;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantPOSApp
{
    /*
     * class InvoiceForm
     * InvoiceForm acts as the final confirmation for any order.
     * It displays the menu/inventory items meant to be purchased along with price and tax.
     */
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
        Form1 menuForm;
        InventoryForm invinForm;

        // itemID is a 2-dimensional array meant to store the IDs and quantities of the items that are to be ordered.
        int[,] itemID;
        // forInv is a boolean value to indicate whether the order is for a customer or for restocking inventory.
        bool forInv = false;

        int employeeID = int.Parse(Form1.employeeId);
        int orderID, purchaseorderID;
        double salesPrice;
        string writetofile = "";

        /*
         * InvoiceForm default constructor.
         */
        public InvoiceForm()
        {
            InitializeComponent();
        }

        /*
         * InvoiceForm 1 argument constructor
         * Assigns the global variable forInv.
         */
        public InvoiceForm(bool fromInv, InventoryForm invForm)
        {
            invinForm = invForm;
            this.forInv = fromInv;
            InitializeComponent();


        }
        public InvoiceForm(Form1 form1)
        {
            menuForm = form1;
            InitializeComponent();
        }

        /*
         * Function InvoiceForm_Load
         * Upon form load the function will fill database tables, assign global variables and populate itemID array.
         */
        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.menu_frame;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            get_data();
            string name = null;

            // Accesses employee name from ID that was signed in from menuForm.
            DataRow[] dr = ds.Employees.Select("EmployeeID = " + this.employeeID);
            foreach (DataRow d in dr)
            {
                name = d[1].ToString();
            }
            employeeLabel.Text = "Order Placed by: " + name;


            /* 
             * Populates itemID array.
             * First checks whether the order is from menu or inventory.
             * Populates the itemID array by accessing the string list stored in MenuForm/InventoryForm
             */
            if (forInv == false)
            {
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
            }
            else if (forInv)
            {
                itemID = new int[InventoryForm.invOrderedItems.Count, 2];
                int id, qt;

                for (int i = 0; i < InventoryForm.invOrderedItems.Count(); i++)
                {
                    string product = InventoryForm.invOrderedItems[i];
                    string[] temp = product.Split(',');
                    id = int.Parse(temp[0]);
                    qt = int.Parse(temp[1]);

                    itemID[i, 0] = id;
                    itemID[i, 1] = qt;
                }
            }

            display_order();
        }


        /*
         * Function get_data()
         * Fills database tables using DataSet.
         */
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

        /*
         * Function display_order()
         * Displays the order that is to be placed into the listview.
         * Accesses the itemID array and the appropriate database table to populate the listview.
         */
        private void display_order()
        {
            double price = 0;
            double tax;
            DataRow[] dr = null;

            /*
             * Iterates through the itemID array and displays the itemno, name, quantity and price.
             * First checks whether the order is from menu or inventory.
             * Creates a String array to populate with appropriate information
             * Adds to listview
             * Updates total price
             */
            if (forInv == false)
            {
                // itemID.Length is the total number of elements in the array. itemID.Rank is the number of dimensions the array has.
                // Using (itemID.Length / itemID.Rank) allows the for loop to iterate throughout its' entire size.
                for (int i = 0; i < (itemID.Length / itemID.Rank); i++)
                {
                    dr = ds.Menu.Select("MenuID = " + itemID[i, 0]);
                    foreach (DataRow d in dr)
                    {
                        String[] row = { (i + 1).ToString(), d[2].ToString(), itemID[i, 1].ToString(), d[4].ToString() };
                        ListViewItem lvi = new ListViewItem(row);
                        listView1.Items.Add(lvi);
                        price += double.Parse(d[4].ToString()) * double.Parse(itemID[i, 1].ToString());
                        writetofile += (i + 1).ToString() + "\t" + d[2].ToString() + "\t" + itemID[i, 1].ToString() + "\t"
                            + d[4].ToString() + Environment.NewLine;
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
                        String[] row = { (i + 1).ToString(), d[1].ToString(), itemID[i, 1].ToString(), d[2].ToString() };
                        ListViewItem lvi = new ListViewItem(row);
                        listView1.Items.Add(lvi);
                        price += double.Parse(d[2].ToString()) * double.Parse(itemID[i, 1].ToString());
                        writetofile += (i + 1).ToString() + "\t" + d[1].ToString() + "\t" + itemID[i, 1].ToString() + "\t"
                            + d[2].ToString() + Environment.NewLine;
                    }
                }
            }

            //Updating price and tax.
            textBoxPrice.Text = price.ToString();
            tax = Math.Round(price * 0.13, 2);
            textBoxTax.Text = tax.ToString();
            salesPrice = Math.Round(price + tax, 2);
            textBoxTotal.Text = salesPrice.ToString();
        }

        /*
         * Function backToolStripMenuItem_Click
         * Back button MenuStrip implementation.
         * Returns to the previous form based on where the order was placed (menu or inventory).
         * Closes the InvoiceForm.
         */
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Returns to InventoryForm
            if (forInv)
            {
                invinForm.Show();
                this.Close();

            }
            // Returns to MenuForm
            else
            {
                menuForm.Visible = true;
                this.Close();
            }
        }


        /*
         * Function orderConfirmation_Click
         * Upon clicking the Confirmation button the order will be placed the the appropriate database tables will be updated.
         */
        private void orderConfirmation_Click(object sender, EventArgs e)
        {
            // Database updates for customer orders. Updates the Orders and Orderline tables.
            if (forInv == false)
            {
                DataSet1.OrdersRow or = ds.Orders.NewOrdersRow();

                or.OrderDate = DateTime.Now;
                or.EmployeeID = this.employeeID;

                ds.Orders.AddOrdersRow(or);
                ot.Update(ds.Orders);

                // Assigns the global variable orderID to the maximum value of the OrderID column in the Orders table.
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
                string filename = @".\Order" + this.orderID + ".txt";
                File.WriteAllText(filename, writetofile);
                MessageBox.Show("Order " + this.orderID + " sucessfully placed.");
                menuForm.Visible = true;
                this.Close();
            }
            // Database updates for inventory orders. Updates the PurchaseOrders, PurchaseOrderline and Inventory tables.
            else if (forInv == true)
            {
                DataSet1.PurchaseOrdersRow por = ds.PurchaseOrders.NewPurchaseOrdersRow();

                por.PurchaseOrderDate = DateTime.Now;
                por.EmployeeID = this.employeeID;

                ds.PurchaseOrders.AddPurchaseOrdersRow(por);
                pot.Update(ds.PurchaseOrders);

                // Assigns the global variable purchaseorderID to the maximum value of the PurchaseOrderID in the PurchaseOrders table.
                this.purchaseorderID = ds.Tables["PurchaseOrders"].AsEnumerable().Max(x => x.Field<int>("PurchaseOrderID"));

                DataSet1.PurchaseOrderlineRow polr = null;
                int inventoryID = 0;
                int inventoryQuantity = 0;

                for (int i = 0; i < (itemID.Length / itemID.Rank); i++)
                {
                    polr = ds.PurchaseOrderline.NewPurchaseOrderlineRow();
                    polr.PurchaseOrderID = this.purchaseorderID;
                    polr.ProductID = itemID[i, 0];
                    polr.Quantity = itemID[i, 1];

                    ds.PurchaseOrderline.AddPurchaseOrderlineRow(polr);
                    polt.Update(ds.PurchaseOrderline);

                    inventoryID = itemID[i, 0];
                    inventoryQuantity = itemID[i, 1];

                    foreach (DataRow dr in ds.Tables["Inventory"].Select("ProductID = " + inventoryID))
                    {
                        dr[3] = inventoryQuantity;
                    }
                    ds.Tables["Inventory"].AcceptChanges();
                    it.Update(ds.Inventory);
                }
                string filename = @".\PurchaseOrder" + this.purchaseorderID + ".txt";
                File.WriteAllText(filename, writetofile);
                MessageBox.Show("Purchase Order " + this.purchaseorderID + " sucessfully placed.");
                invinForm.Show();
                this.Close();
            }
        }
    }
}
