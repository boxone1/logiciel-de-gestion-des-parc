using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using gestionDesParc.Pages;

namespace gestionDesParc.BL
{
    internal class ClsClient
    {

        SqlConnection con = new SqlConnection();
        DAL.ClsDAL DAL = new DAL.ClsDAL();
        clientPage ClientPag = new clientPage();
        

        

        //to lead client data
        /*
        public DataTable load()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADCLIENT", pr);
            
            return dt;
        }
        */

        // add client method
        public void addClient(string ClientName, string Phone, string Adress, DateTime Date)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("clientName", ClientName);
            pr[1] = new SqlParameter("phone", Phone);
            pr[2] = new SqlParameter("adress", Adress);
            pr[3] = new SqlParameter("date", Date);
            //pr[4]= new SqlParameter()
            DAL.open();
            DAL.excute("PR_ADDCLIENT", pr);
            DAL.close();
            
        }


        // edit client 
        public void updateClient(string ClientName, string Phone, string Adress , int ID)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("clientName", ClientName);
            pr[1] = new SqlParameter("phone", Phone);
            pr[2] = new SqlParameter("adress", Adress);
            pr[3] = new SqlParameter("id", ID);
           
            DAL.open();
            DAL.excute("P_EDITCLIENT", pr);
            DAL.close();
            

        }


        // delete client 
        public void deleteClient(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            
            pr[0] = new SqlParameter("id", ID);

            DAL.open();
            DAL.excute("P_DELETECLIENT", pr);
            DAL.close();

        }
       
    }

}
        
    

