using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Management;
using gestionDesParc.addPages;
using gestionDesParc.Pages;
using gestionDesParc.BL;
using System.Drawing.Printing;
using System.Security.Cryptography;
using System.Drawing.Configuration;
using System.Data.Entity.Spatial;
using System.Data.Entity;


namespace gestionDesParc.Pages
{
    public partial class stockPage : UserControl
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataTable dt;
        TB_STOCK stock;
        DBGPEntities4 db;
        Purchase addArticle;
        
        public Main main ;
        
        int id;


        public stockPage()
        {
            InitializeComponent();
            LoadData();
        }



        public void LoadData()
        {
            try
            {
                con = new SqlConnection();
                dt = new DataTable();
                con.ConnectionString = (@"Data Source=DESKTOP-VDJQ28O\SQLEXPRESS;Initial Catalog=DBGP;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
                var sql = "SELECT ID,ArticleName AS الاسم,Quantity As الكمية,Type As النوع  ,Price As السعر,Price2 As السعر2,LoadingPrice As  الشحن  From TB_STOCK";
                da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            addArticle = new Purchase();
            Form parentForm = this.FindForm();
            Panel displayPanel = parentForm.Controls.Find("display_Panel", true).FirstOrDefault() as Panel;
            if (displayPanel != null)
            {
                displayPanel.Controls.Clear();
                addArticle.Dock = DockStyle.Fill;
                displayPanel.Controls.Add(addArticle);

            }


        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
          
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل انت متاكد من حذف هذا الزبون؟", "عملية حذف", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            stock = new TB_STOCK();
            db = new DBGPEntities4();
            stock = db.TB_STOCK.Where(x => x.ID == id).FirstOrDefault();
            db.Entry(stock).State = EntityState.Deleted;
            db.SaveChanges();


            LoadData();

            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("لم يتم الحذف");
            }


        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            dataGridPreview dgp = new dataGridPreview();
            dgp.LoadData("stockPage");

            dgp.printFunction();


        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            search();
        }



        private void search()
        {
            string searchText = txt_search.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                // If search text is empty, make all rows visible
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
            currencyManager1.SuspendBinding();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Skip the new row placeholder
                if (row.IsNewRow) continue;

                if (row.Cells["الاسم"].Value != null)
                {
                    string clientName = row.Cells["الاسم"].Value.ToString();
                    if (clientName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
                else
                {
                    row.Visible = false;
                }
            }

            currencyManager1.ResumeBinding();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            search();
        }
    }
}
