namespace RestaurantPOSApp
{
    partial class InvoiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.orderConfirmation = new System.Windows.Forms.Button();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelTax = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxTax = new System.Windows.Forms.TextBox();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.employeeLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderConfirmation
            // 
            this.orderConfirmation.Location = new System.Drawing.Point(747, 347);
            this.orderConfirmation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.orderConfirmation.Name = "orderConfirmation";
            this.orderConfirmation.Size = new System.Drawing.Size(144, 41);
            this.orderConfirmation.TabIndex = 0;
            this.orderConfirmation.Text = "Confirm Order";
            this.orderConfirmation.UseVisualStyleBackColor = true;
            this.orderConfirmation.Click += new System.EventHandler(this.orderConfirmation_Click);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(700, 205);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(48, 20);
            this.labelPrice.TabIndex = 1;
            this.labelPrice.Text = "Price:";
            // 
            // labelTax
            // 
            this.labelTax.AutoSize = true;
            this.labelTax.Location = new System.Drawing.Point(700, 242);
            this.labelTax.Name = "labelTax";
            this.labelTax.Size = new System.Drawing.Size(38, 20);
            this.labelTax.TabIndex = 2;
            this.labelTax.Text = "Tax:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(700, 276);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(48, 20);
            this.labelTotal.TabIndex = 3;
            this.labelTotal.Text = "Total:";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(779, 205);
            this.textBoxPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.ReadOnly = true;
            this.textBoxPrice.Size = new System.Drawing.Size(112, 26);
            this.textBoxPrice.TabIndex = 4;
            // 
            // textBoxTax
            // 
            this.textBoxTax.Location = new System.Drawing.Point(779, 242);
            this.textBoxTax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTax.Name = "textBoxTax";
            this.textBoxTax.ReadOnly = true;
            this.textBoxTax.Size = new System.Drawing.Size(112, 26);
            this.textBoxTax.TabIndex = 5;
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Location = new System.Drawing.Point(779, 277);
            this.textBoxTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(112, 26);
            this.textBoxTotal.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1043, 33);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(60, 29);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::RestaurantPOSApp.Properties.Resources.logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(12, 34);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(190, 91);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 8;
            this.pictureBoxLogo.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.Item,
            this.Qty,
            this.Price});
            this.listView1.Location = new System.Drawing.Point(30, 17);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(650, 371);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // No
            // 
            this.No.Text = "No";
            // 
            // Item
            // 
            this.Item.Text = "Item";
            // 
            // Qty
            // 
            this.Qty.Text = "Qty";
            // 
            // Price
            // 
            this.Price.Text = "Price";
            // 
            // employeeLabel
            // 
            this.employeeLabel.AutoSize = true;
            this.employeeLabel.Location = new System.Drawing.Point(700, 17);
            this.employeeLabel.Name = "employeeLabel";
            this.employeeLabel.Size = new System.Drawing.Size(51, 20);
            this.employeeLabel.TabIndex = 10;
            this.employeeLabel.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.employeeLabel);
            this.panel1.Controls.Add(this.orderConfirmation);
            this.panel1.Controls.Add(this.labelPrice);
            this.panel1.Controls.Add(this.labelTax);
            this.panel1.Controls.Add(this.textBoxTotal);
            this.panel1.Controls.Add(this.labelTotal);
            this.panel1.Controls.Add(this.textBoxTax);
            this.panel1.Controls.Add(this.textBoxPrice);
            this.panel1.Location = new System.Drawing.Point(12, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1019, 516);
            this.panel1.TabIndex = 11;
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 744);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InvoiceForm";
            this.Text = "Invoice Form";
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button orderConfirmation;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelTax;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxTax;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader Item;
        private System.Windows.Forms.ColumnHeader Qty;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.Label employeeLabel;
        private System.Windows.Forms.Panel panel1;
    }
}

