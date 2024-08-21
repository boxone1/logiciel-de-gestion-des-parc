using gestionDesParc.Pages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestionDesParc.BL
{
    internal class ClsPymentLog
    { 
      SqlConnection con = new SqlConnection();
        DAL.ClsDAL DAL;
    public int id;



        //to lead client data
        //load data
        public DataTable load()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("P_LOADPAYMENTS", pr);

            return dt;
        }

        public DataTable loadPayments()
        {
            DAL = new DAL.ClsDAL();
            SqlParameter[] pr = new SqlParameter[1];

            pr[0] = new SqlParameter("ID", id);
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.ExecuteQuery("P_LOADPAYMENTS", pr);
            DAL.close();
            return dt;
        }


        // add client method
        public void addPayment(int clientID, float payment, DateTime Date)
    {
            DAL = new DAL.ClsDAL();
            SqlParameter[] pr = new SqlParameter[3];
        pr[0] = new SqlParameter("Payment", payment);
        pr[1] = new SqlParameter("clientID", clientID);
        pr[2] = new SqlParameter("date", Date);

        DAL.open();
            MessageBox.Show(clientID.ToString());
            DAL.excute("P_MAKEPAYMENT", pr);
        DAL.close();

    }


    // edit client 
    public void editPayment(double payment,int id)
    {
            DAL = new DAL.ClsDAL();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("Payment",payment);
            pr[1] = new SqlParameter("id",id);
            DAL.open();
            DAL.excute("P_EDITPAYMENT", pr);
            DAL.close();
            
    }


    // delete client 
    public void deletePayment(int ID)
    {
            DAL = new DAL.ClsDAL();
            SqlParameter[] pr = new SqlParameter[1];

        pr[0] = new SqlParameter("id", ID);

        DAL.open();
        DAL.excute("P_DELETEPAYMENT", pr);
        DAL.close();

    }

}

}
        
    