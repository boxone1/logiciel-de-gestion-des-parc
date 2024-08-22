using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using gestionDesParc.addPages;
using System.Data.Entity;

namespace gestionDesParc.Pages
{
    public partial class paymentLog : Form
    {

        SqlConnection con;
        DataTable dt;
        SqlDataAdapter da;
        clientPage clientpage = new clientPage();
        DBGPEntities4 db;
        TB_PAYMENT tbPayemnt;
        
        public int id;

        public paymentLog()
        {
            InitializeComponent();
            //LoadData();
            clientpage.LoadData();



        }

      

        //load payement data
        public void LoadData()
        {
            try
            {
                con = new SqlConnection();
                dt = new DataTable();
                con.ConnectionString = (@"Data Source=DESKTOP-VDJQ28O\SQLEXPRESS;Initial Catalog=DBGP;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
                var sql = "SELECT ID,Payment AS المدفوعات,Date AS التاريخ  From TB_PAYMENT WHERE ID_CLIENT= "+id;
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
            
            addPayment addpayment = new addPayment();
            addpayment.state = "add";
            addpayment.clientID = Convert.ToInt32(lbl_id.Text);

            addpayment.ShowDialog();
            LoadData();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {

            addPayment addPaymenet = new addPayment();
            addPaymenet.txt_paymentAmount.Text = dataGridView1.CurrentRow.Cells["payment"].Value.ToString();
            addPaymenet.oldPayment = Convert.ToDouble(dataGridView1.CurrentRow.Cells["payment"].Value);
            addPaymenet.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            addPaymenet.state = "update";
            addPaymenet.ShowDialog();
            LoadData();

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            /* ClsPymentLog clsPaymenet = new ClsPymentLog();
             id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
             clsPaymenet.deletePayment(id);
            */
            deletPayment();
            LoadData();
        }

        private void deletPayment()
        {
            db = new DBGPEntities4();
            tbPayemnt = db.TB_PAYMENT.Where(x => x.ID_Client == id).FirstOrDefault();
            if (tbPayemnt != null) {
                db.Entry(tbPayemnt).State = EntityState.Deleted;
                db.SaveChanges();
            }

        }

      
    }
}

