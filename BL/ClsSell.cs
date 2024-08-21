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
    internal class ClsSell
    {
        DAL.ClsDAL DAL;
        int id;

        public DataTable loadBill()
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


        public string[] getArticlesName()
        {
            DAL = new DAL.ClsDAL();
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            DAL = new DAL.ClsDAL();
            dt = DAL.read("P_GETARTICLENAME", pr);
            List<string> articles = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                articles.Add(dr["Name"].ToString());
            }

            return articles.ToArray();
        }

        public string[] GetArticlesName()
        {
            try
            {
                DAL = new DAL.ClsDAL();
                SqlParameter[] pr = null; // or initialize with actual parameters if needed
                string[] articleNames = DAL.ReadColumnAsArray("P_GETARTICLENAME", pr, "Name");
                return articleNames;
            }
            catch (Exception ex)
            {
                // Handle or log the exception as necessary
                MessageBox.Show("An error occurred while retrieving article names: " + ex.Message);
                return new string[0]; // Return an empty array in case of error
            }
        }
        public string[] GetClientsName()
        {
            try
            {
                DAL = new DAL.ClsDAL();
                SqlParameter[] pr = null; // or initialize with actual parameters if needed
                string[] articleNames = DAL.ReadColumnAsArray("getclientsnames", pr, "Name");
                return articleNames;
            }
            catch (Exception ex)
            {
                // Handle or log the exception as necessary
                MessageBox.Show("An error occurred while retrieving article names: " + ex.Message);
                return new string[0]; // Return an empty array in case of error
            }
        }

        public string[] getPrices(string articleName)
        {
            try
            {
                DAL = new DAL.ClsDAL();
                SqlParameter[] pr = null; // or initialize with actual parameters if needed
                string[] articlePrices = DAL.ReadColumnAsArray("P_GETARTICLEPRICE", pr, "Name");
                return articlePrices;
            }
            catch (Exception ex)
            {
                // Handle or log the exception as necessary
                MessageBox.Show("An error occurred while retrieving article names: " + ex.Message);
                return new string[0]; // Return an empty array in case of error
            }
        }





    }




}
