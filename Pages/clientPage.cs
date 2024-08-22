using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using gestionDesParc.addPages;
using System.Data.Entity;


namespace gestionDesParc.Pages
{
    public partial class clientPage : UserControl
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataTable dt;
        addClient AddClient;
        public Main main ;
        paymentLog paymentlog;
        TB_CLIENT tbClient;
        DBGPEntities4 db;
       



        int id;


        public clientPage()
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
                var sql = "SELECT ID,ClientName AS الاسم,Phone AS الهاتف,Adress AS العنوان,Debt AS الديون,Date AS التاريخ  From TB_CLIENT";
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
            main = new Main();
            AddClient = new addClient();
            AddClient.state = "add";
            AddClient.personState = "client";
            AddClient.Show();
            
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            db = new DBGPEntities4();
            id= Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value); 
            AddClient = new addClient();
            AddClient.id = id;
            AddClient.state = "update";
            AddClient.personState = "client";
            tbClient = db.TB_CLIENT.Where(x => x.ID == id).FirstOrDefault();
            AddClient.txt_name.Text = tbClient.ClientName;
            AddClient.txt_adress.Text =tbClient.Phone;
            AddClient.txt_phone.Text =tbClient.Adress;
            AddClient.Show();
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {


            DialogResult dialogResult = MessageBox.Show("هل انت متاكد من حذف هذا الزبون؟", "عملية حذف", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                db = new DBGPEntities4();
                tbClient = new TB_CLIENT();
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                tbClient = db.TB_CLIENT.Where(x => x.ID == id).FirstOrDefault();
                db.Entry(tbClient).State = EntityState.Deleted;
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
            dgp.LoadData("clientPage");
            
            dgp.printFunction();
        }
      

        private void btn_payment_Click(object sender, EventArgs e)
        {
            // paymentlog = new paymentLog();
            loadPaymentsLog();
            //log.loadPayments();
        }

        //////////////////
        ///psyments log data loading
       
        /*
        
        private void loadPaymentsLog()
        {
            try
            {
                DataTable dt = new DataTable();
                paymentlog = new paymentLog();
                paymentlog.lbl_id.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                paymentlog.lbl_name.Text = dataGridView1.CurrentRow.Cells["الاسم"].Value.ToString();
                log.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                dt = log.loadPayments();
                paymentlog.dataGridView1.DataSource = dt;
                paymentlog.dataGridView1.Columns[0].Visible = false;
                paymentlog.dataGridView1.Columns[1].HeaderText = "المبلغ";
                paymentlog.dataGridView1.Columns[2].HeaderText = "التاريخ";

                

                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                db = new DBGPEntities4();
                var clientPayments = db.TB_PAYMENT.Where(x => x.ID_Client == id).ToArray();
                tbClient = db.TB_CLIENT.Where(x => x.ID == id).FirstOrDefault();
                double sum = 0;
                foreach (var item in clientPayments)
                {
                    sum = Convert.ToDouble(item.Payment);
                }
                paymentlog.lbl_payments.Text = sum.ToString();
                paymentlog.lbl_debt.Text = tbClient.Debt.ToString();
                paymentlog.id = id;

                paymentlog.Show();
            }
            catch {}
        }*/
        private void loadPaymentsLog()
        {
            db = new DBGPEntities4();
            id= Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            DataTable dt = new DataTable();
            paymentlog = new paymentLog();
            paymentlog.lbl_id.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            paymentlog.lbl_name.Text = dataGridView1.CurrentRow.Cells["الاسم"].Value.ToString();
            paymentlog.dataGridView1.Columns[1].HeaderText = "المبلغ";
            paymentlog.dataGridView1.Columns[2].HeaderText = "التاريخ";

            var payments = db.TB_PAYMENT.Where(x=>x.ID_Client==id).ToArray();

           // dt.Columns.Add("ID");
            dt.Columns.Add("Payment");
            dt.Columns.Add("Date");

            foreach (var item in payments)
            {
                
                dt.Rows.Add( item.Payment,item.Date);
            
            }
            paymentlog.dataGridView1.DataSource = dt;
            paymentlog.Show();
                

                



        }



      

        private void btn_search_Click_1(object sender, EventArgs e)
        {
            search();
        }


        // search function

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
