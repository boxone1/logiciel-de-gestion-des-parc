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
using DGVPrinterHelper;
using System.Data.Entity;
using System.Net.Sockets;


namespace gestionDesParc.Pages
{
    public partial class supplierPage : UserControl
    {
        DBGPEntities4 db;
        SqlConnection con;
        SqlDataAdapter da;
        DataTable dt;
        addSupplier supplier;
        public Main main ;
       // ClsPymentLog log = new ClsPymentLog();
        paymentLog paymentlog;
        addPayment payments;
        TB_SUPPLIER tbSupplier;
        TB_SUPPLIER_PAYMENTS supplierPayment;
        addClient addSupplier;
        



        int id;


        public supplierPage()
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
                var sql = "SELECT ID,SupplierName AS الاسم,Phone AS الهاتف,Adress AS العنوان,Debt AS الديون,Date AS التاريخ  From TB_SUPPLIER";
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
            addSupplier = new addClient();
            addSupplier.state = "add";
            addSupplier.personState = "supplier";
            addSupplier.Show();

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            db = new DBGPEntities4();
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            addSupplier = new addClient();
            addSupplier.id = id;
            addSupplier.state = "update";
            addSupplier.personState = "supplier";
            tbSupplier = db.TB_SUPPLIER.Where(x => x.ID == id).FirstOrDefault();
            addSupplier.txt_name.Text = tbSupplier.SupplierName;
            addSupplier.txt_adress.Text = tbSupplier.Phone;
            addSupplier.txt_phone.Text = tbSupplier.Adress;
            addSupplier.Show();

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {


            DialogResult dialogResult = MessageBox.Show("هل انت متاكد من حذف هذا المورد؟", "عملية حذف", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                db = new DBGPEntities4();
                tbSupplier = new TB_SUPPLIER();
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                tbSupplier = db.TB_SUPPLIER.Where(x => x.ID == id).FirstOrDefault();
                db.Entry(tbSupplier).State = EntityState.Deleted;
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
            dgp.LoadData("supplierPage");

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
        private void loadPaymentsLog()
        {
            try
            {
                // Retrieve the selected ID from the DataGridView
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

                // Initialize the database context
                using (var db = new DBGPEntities4())
                {
                    // Initialize the payment log form
                    var paymentlog = new paymentLog();
                    paymentlog.lbl_id.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                    paymentlog.lbl_name.Text = dataGridView1.CurrentRow.Cells["الاسم"].Value.ToString();

                    // Prepare DataTable for payments
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ID", typeof(int));
                    dt.Columns.Add("Payment", typeof(double));
                    dt.Columns.Add("Date", typeof(DateTime));

                    // Fetch payments for the selected supplier
                    var paymentslist = db.TB_SUPPLIER_PAYMENTS.Where(x => x.IDSupplier == id).ToList();
                    foreach (var payment in paymentslist)
                    {
                        dt.Rows.Add(payment.ID, payment.Payment, payment.Date);
                    }

                    // Bind DataTable to DataGridView
                    paymentlog.dataGridView1.DataSource = dt;
                    paymentlog.dataGridView1.Columns[0].Visible = false;
                    paymentlog.dataGridView1.Columns[1].HeaderText = "المبلغ";
                    paymentlog.dataGridView1.Columns[2].HeaderText = "التاريخ";

                    // Calculate and display total payments for the client
                    var clientPayments = db.TB_PAYMENT.Where(x => x.ID_Client == id).ToArray();
                    var tbSupplier = db.TB_SUPPLIER.FirstOrDefault(x => x.ID == id);
                    double sum = 0;
                    foreach (var item in clientPayments)
                    {
                        sum += Convert.ToDouble(item.Payment);
                    }
                    paymentlog.lbl_payments.Text = sum.ToString();
                    paymentlog.lbl_debt.Text = tbSupplier?.Debt.ToString() ?? "0";
                    paymentlog.id = id;

                    // Show the payment log form
                    paymentlog.Show();
                }
            }
            catch (Exception ex)
            {
                // Display or log the exception for debugging purposes
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            dataGridPreview dvp = new dataGridPreview();
            dvp.Show();
        }

        private void btn_search_Click_1(object sender, EventArgs e)
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
