using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using gestionDesParc.addPages;
using gestionDesParc.BL;
using gestionDesParc;

namespace gestionDesParc.Pages
{
    public partial class paymentLog : Form
    {

        SqlConnection con;
        DataTable dt;
        SqlDataAdapter da;
        DAL.ClsDAL DAL = new DAL.ClsDAL();
        clientPage clientpage = new clientPage();
        
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
            ClsPymentLog clsPaymenet = new ClsPymentLog();
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            clsPaymenet.deletePayment(id);
            LoadData();
        }

      
    }
}

