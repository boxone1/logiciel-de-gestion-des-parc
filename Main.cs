using gestionDesParc.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gestionDesParc.Pages;
using gestionDesParc.addPages;
using gestionDesParc.DAL;
using gestionDesParc.BL;
using System.Runtime.InteropServices;


namespace gestionDesParc
{
    public partial class Main : Form
    {
        String state;
        int ID;
        // client vars
        ClsClient clsClient;

        /// <summary>
        /// /////////////
        /// </summary>
        clientPage client = new clientPage();
        clientAdd addClient;
        sell sellpage;
        Purchase article;
        stockPage stockpage;
        sellLog sellsLog;
        purchasePage purchasepage;
        supplierPage supplierpage;
        DBGPEntities4 db;
        TB_BILL Bill;
        Main main;
        public int id;


        Array array;
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
