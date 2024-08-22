using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using gestionDesParc.addPages;
using System.Data.Entity;
namespace gestionDesParc.Pages
{
    public partial class sellLog : UserControl
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataTable dt;
        public Main main;
        TB_SELL tbsell;
        TB_BILL Bill;
        DBGPEntities4 db;
        int id;
        sell sell;

        FRM_BILL billfrm;


        public sellLog()
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
                var sql = "SELECT ID,ClientName ,Payment ,Debt ,Date  From TB_SELL";
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
            sell=new sell();
            Form parentForm = this.FindForm();
            Panel displayPanel = parentForm.Controls.Find("display_Panel", true).FirstOrDefault() as Panel;
            if (displayPanel != null)
            {
                displayPanel.Controls.Clear();
                sell.Dock = DockStyle.Fill;
                displayPanel.Controls.Add(sell);

            }


        }



        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل انت متاكد من حذف هذا الزبون؟", "عملية حذف", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                db = new DBGPEntities4();
            tbsell = new TB_SELL();
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            tbsell = db.TB_SELL.Where(x => x.ID == id).FirstOrDefault();
            db.Entry(tbsell).State = EntityState.Deleted;
            db.SaveChanges();


            LoadData();

            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("لم يتم الحذف");
            }


        }

       
        private void printdocument(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap imagebmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(imagebmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(imagebmp, 120, 120);

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();

        }


        private void btn_bill_Click(object sender, EventArgs e)
        {
            loadBillInformations();
        }


        private void loadBillInformations()
        {
            try
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                Bill = new TB_BILL();
                tbsell = new TB_SELL();
                dt = new DataTable();
                db = new DBGPEntities4();
                billfrm = new FRM_BILL();

                tbsell = db.TB_SELL.Where(x => x.ID == id).FirstOrDefault();

                var list = db.TB_BILL.Where(x => x.IDSell == id).ToArray();

                dt.Columns.Add("ArticleName", typeof(string));
                dt.Columns.Add("Quantity", typeof(float));
                dt.Columns.Add("Unity", typeof(string));
                dt.Columns.Add("Price", typeof(float));
                dt.Columns.Add("Discount", typeof(float));
                dt.Columns.Add("AfterDiscount", typeof(float));
                dt.Columns.Add("Total", typeof(float));
                

                foreach (var item in list)
                {
                    dt.Rows.Add(item.Article, item.Quantity, item.Unity, item.Price, item.Discount, item.Discount, item.TotalPrice);

                }

                billfrm.dataGridView1.DataSource = dt
                    ;
                billfrm.lbl_clientName.Text = tbsell.ClientName.ToString();
                billfrm.lbl_billDate.Text = tbsell.Date.ToString();
                billfrm.lbl_printDate.Text = DateTime.Now.ToString();
                billfrm.lbl_totalPrice.Text = tbsell.Payment.ToString();
                billfrm.lbl_billId.Text = tbsell.ID.ToString();
                billfrm.lbl_rest.Text = tbsell.Debt.ToString();
              //  billfrm.dataGridView1.Columns["Unity"].Width = 20;
               

                billfrm.dataGridView1.Columns["ArticleName"].HeaderText = "اسم المادة";
                billfrm.dataGridView1.Columns["Quantity"].HeaderText = "الكمية";
                billfrm.dataGridView1.Columns["Unity"].HeaderText = "الوحدة";
                billfrm.dataGridView1.Columns["Price"].HeaderText = "السعر";
                billfrm.dataGridView1.Columns["Discount"].HeaderText = "تخفيض";
                billfrm.dataGridView1.Columns["AfterDiscount"].HeaderText = "السعر بعد التخفيض";
                billfrm.dataGridView1.Columns["Total"].HeaderText = "المجموع";




                billfrm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //edit sell operation

        private void btn_edit_Click(object sender, EventArgs e)
        {
            sell sell = new sell();
           // sell.idSell = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            editBilll();
            sell.state = "edit";
            sell.sellId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);



        }
        /*
        private void loadbill()
        { // id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            // Access the parent form to get the display panel
            Form parentForm = this.FindForm();
            Panel displayPanel = parentForm.Controls.Find("display_Panel", true).FirstOrDefault() as Panel;

            if (displayPanel != null)
            {
                MessageBox.Show("click");
                displayPanel.Controls.Clear();
                sell = new sell();
                sell.Dock = DockStyle.Fill;
                displayPanel.Controls.Add(sell);

            }




        }*/



        private void editBilll()
        {
            try
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                Bill = new TB_BILL();
                tbsell = new TB_SELL();
                sell = new sell();
                dt = new DataTable();
                db = new DBGPEntities4();
                var totalPrice = 0.0;
                Form parentForm = this.FindForm();
                Panel displayPanel = parentForm.Controls.Find("display_Panel", true).FirstOrDefault() as Panel;



                tbsell = db.TB_SELL.Where(x => x.ID == id).FirstOrDefault();

                var list = db.TB_BILL.Where(x => x.IDSell == id).ToArray();

                /*    dt.Columns.Add("ArticleName", typeof(string));
                    dt.Columns.Add("Quantity", typeof(float));
                    dt.Columns.Add("Unity", typeof(string));
                    dt.Columns.Add("Price", typeof(float));
                    dt.Columns.Add("Discount", typeof(float));
                    dt.Columns.Add("AfterDiscount", typeof(float));
                    dt.Columns.Add("Total", typeof(float));
                */
                foreach (var item in list)
                {
                     sell.dataGridView1.Rows.Add(item.Article, item.Quantity, item.Unity, item.Price, item.Discount,item.PriceAfterDiscount, item.TotalPrice, item.Discount);
                    totalPrice += Convert.ToDouble(item.TotalPrice);
                    sell.txt_total.Text=totalPrice.ToString();
                    
                }
               // sell.dataGridView1.DataSource = dt;

                if (displayPanel != null)
                {
                    displayPanel.Controls.Clear();
                    sell.Dock = DockStyle.Fill;
                    displayPanel.Controls.Add(sell);

                }

            }
            catch { }

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

                if (row.Cells["ClientName"].Value != null)
                {
                    string clientName = row.Cells["ClientName"].Value.ToString();
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
            dataGridPreview dgp = new dataGridPreview() ;
            dgp.LoadData("sellsLog");
            dgp.printFunction();
        }

        private void sellLog_Load(object sender, EventArgs e)
        {

        }
    }
}