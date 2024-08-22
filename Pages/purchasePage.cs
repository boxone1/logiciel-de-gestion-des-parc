using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity;
namespace gestionDesParc.Pages
{
    public partial class purchasePage : UserControl
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataTable dt;

        DBGPEntities4 db;

        int id;

        Purchase purchase;
        TB_ARTICLE tbArticle;
        TB_PURCHASE tbPurchase;
        FRM_BILL billfrm;


        public purchasePage()
        {
            InitializeComponent();
            LoadData();
        }


        // load date from database
        public void LoadData()
        {
            try
            {
                con = new SqlConnection();
                dt = new DataTable();
                con.ConnectionString = (@"Data Source=DESKTOP-VDJQ28O\SQLEXPRESS;Initial Catalog=DBGP;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
                var sql = "SELECT ID,SupplierName,PaymentState ,Debt,payment,Date  From TB_PURCHASE";
                da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                dataGridView1.Columns["ID"].HeaderText = "التسلسل";
                dataGridView1.Columns["SupplierName"].HeaderText = "المورد";
                dataGridView1.Columns["PaymentState"].HeaderText = "حالة الدفع";
                dataGridView1.Columns["Debt"].HeaderText = "الديون";
                dataGridView1.Columns["payment"].HeaderText = "المدفوعات";
                dataGridView1.Columns["Date"].HeaderText = "تاريخ الشراء";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {

                purchase = new Purchase();

                db = new DBGPEntities4();
                Form parentForm = this.FindForm();
                Panel displayPanel = parentForm.Controls.Find("display_Panel", true).FirstOrDefault() as Panel;

                if (displayPanel != null)
                {
                    displayPanel.Controls.Clear();
                    purchase.Dock = DockStyle.Fill;
                    displayPanel.Controls.Add(purchase);

                }

            }
            catch { }

        }



        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل انت متاكد من حذف هذا الزبون؟", "عملية حذف", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                db = new DBGPEntities4();
            tbPurchase = new TB_PURCHASE();
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            tbPurchase = db.TB_PURCHASE.Where(x => x.ID == id).FirstOrDefault();
            db.Entry(tbPurchase).State = EntityState.Deleted;
            db.SaveChanges();


            LoadData();


            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("لم يتم الحذف");
            }

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

                if (row.Cells["SupplierName"].Value != null)
                {
                    string clientName = row.Cells["SupplierName"].Value.ToString();
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

        private void btn_print_Click(object sender, EventArgs e)
        {
            dataGridPreview dgp = new dataGridPreview();
            dgp.LoadData("purchasePage");
            dgp.printFunction();
        }
        private void btn_bill_Click(object sender, EventArgs e)
        {
            loadBillInformations();
        }

        // load the bill information to bill form for preview
        private void loadBillInformations()
        {
            try
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                tbArticle = new TB_ARTICLE();
                tbPurchase = new TB_PURCHASE();
                dt = new DataTable();
                db = new DBGPEntities4();
                billfrm = new FRM_BILL();

                

                dt.Columns.Add("ArticleName", typeof(string));
                dt.Columns.Add("Quantity", typeof(float));
                dt.Columns.Add("Unity", typeof(string));
                dt.Columns.Add("purchasePrice", typeof(float));
                dt.Columns.Add("unloadingPrice", typeof(float));
                dt.Columns.Add("transportationPrice", typeof(float));
                
                

                var list = db.TB_ARTICLE.Where(x => x.ID_Purchase == id).ToArray();

                foreach (var item in list)
                {
                    dt.Rows.Add(item.Name, item.Quantity, item.Unity, item.PurchasePrice,item.Transport, item.Unload);

                }
                tbPurchase = db.TB_PURCHASE.Where(x => x.ID == id).FirstOrDefault();

                billfrm.dataGridView1.DataSource = dt;
                
                billfrm.lbl_clientName.Text = tbPurchase.SupplierName.ToString();
                billfrm.lbl_billDate.Text = tbPurchase.Date.ToString();
                billfrm.lbl_printDate.Text = DateTime.Now.ToString();
                billfrm.lbl_totalPrice.Text = tbPurchase.Payment.ToString();
                billfrm.lbl_billId.Text = tbPurchase.ID.ToString();
                billfrm.lbl_rest.Text = tbPurchase.Debt.ToString();
                //  billfrm.dataGridView1.Columns["Unity"].Width = 20;


                billfrm.dataGridView1.Columns["ArticleName"].HeaderText = "اسم المادة";
                billfrm.dataGridView1.Columns["Quantity"].HeaderText = "الكمية";
                billfrm.dataGridView1.Columns["Unity"].HeaderText = "الوحدة";
                billfrm.dataGridView1.Columns["purchasePrice"].HeaderText = "ثمن الشراء";
                billfrm.dataGridView1.Columns["unloadingPrice"].HeaderText = "ثمن التوصيل";
                billfrm.dataGridView1.Columns["transportationPrice"].HeaderText = "ثمن التفريغ";
               




                billfrm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}