using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace gestionDesParc.DAL
{
    

    internal class ClsDAL
    {
        SqlConnection con = new SqlConnection();

        // constructor
        public ClsDAL()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-VDJQ28O\SQLEXPRESS;Initial Catalog=DBGP;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
        }
        // open connection 
        public void open()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void close()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Close();
            }
        }
        //function to read data
        public DataTable read(String store,SqlParameter[] pr)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            if (pr != null)
            {
                cmd.Parameters.AddRange(pr);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public string[] ReadColumnAsArray(string store, SqlParameter[] pr, string columnName)
{
    try
    {
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;

            if (pr != null)
            {
                cmd.Parameters.AddRange(pr);
            }

            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<string> values = new List<string>();

                foreach (DataRow row in dt.Rows)
                {
                    if (row[columnName] != DBNull.Value)
                    {
                        values.Add(row[columnName].ToString());
                    }
                }

                return values.ToArray();
            }
        }
    }
    catch (Exception ex)
    {
        // Handle or log the exception
        throw new ApplicationException("An error occurred while reading the data.", ex);
    }
}


        //excute to insert edit and delete
        public void excute(String store, SqlParameter[] pr)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            if (pr != null)
            {
                cmd.Parameters.AddRange(pr);
            }
            cmd.ExecuteNonQuery();
        }

       /* public DataTable ExecuteQuery(string storedProcedure, SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(storedProcedure, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }*/
        public DataTable ExecuteQuery(string store, SqlParameter[] pr)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            if (pr != null)
            {
                cmd.Parameters.AddRange(pr);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}
