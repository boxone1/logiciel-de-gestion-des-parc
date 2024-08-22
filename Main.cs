using gestionDesParc.Pages;
using System;
using System.Data;
using System.Windows.Forms;


namespace gestionDesParc
{
    public partial class Main : Form
    {
     
        // client vars
        
        clientPage client = new clientPage();
        sell sellpage;
        Purchase article;
        stockPage stockpage;
        sellLog sellsLog;
        purchasePage purchasepage;
        supplierPage supplierpage;
        public int id;

        public Main()
        {
            InitializeComponent();

            
        }

        private void btn_client_Click(object sender, EventArgs e)
        {
            DisplayClientPage();
            
           
        }

        // Method to display the clientPage UserControl
        private void DisplayClientPage()
        {
            try
            {
                client = new clientPage();
              
                display_panel.Controls.Clear();
                display_panel.Controls.Add(client);
                client.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void btn_sell_Click(object sender, EventArgs e)
        {
            try
            {
                sellpage = new sell();

                display_panel.Controls.Clear();
                display_panel.Controls.Add(sellpage);
                sellpage.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_sellsLog_Click(object sender, EventArgs e)
        {
            sellsLog = new sellLog();

            display_panel.Controls.Clear();
            display_panel.Controls.Add(sellsLog);
            sellsLog.Dock = DockStyle.Fill;
        }

        public void showeSellform(DataTable dt)
        {

            sellpage = new sell();
            sellpage.dataGridView1.DataSource = dt;
            display_panel.Controls.Clear();
           
            display_panel.Controls.Add(sellpage);
            sellpage.Dock = DockStyle.Fill;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void display_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_stock_Click(object sender, EventArgs e)
        {
            stockpage = new stockPage();
            //stockpage.dataGridView1.DataSource = dt;
            display_panel.Controls.Clear();

            display_panel.Controls.Add(stockpage);
            stockpage.Dock = DockStyle.Fill;

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            article = new Purchase();
            //stockpage.dataGridView1.DataSource = dt;
            display_panel.Controls.Clear();

            display_panel.Controls.Add(article);
            article.Dock = DockStyle.Fill;
        }

        private void btn_purchases_Click(object sender, EventArgs e)
        {
            purchasepage = new purchasePage();
            //stockpage.dataGridView1.DataSource = dt;
            display_panel.Controls.Clear();

            display_panel.Controls.Add(purchasepage);
            purchasepage.Dock = DockStyle.Fill;
        }

        private void btn_supplier_Click(object sender, EventArgs e)
        {
            supplierpage = new supplierPage();
            //stockpage.dataGridView1.DataSource = dt;
            display_panel.Controls.Clear();

            display_panel.Controls.Add(supplierpage);
            supplierpage.Dock = DockStyle.Fill;
        }
    }
}
