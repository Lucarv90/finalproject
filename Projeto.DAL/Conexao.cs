using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Projeto.DAL
{
    public class Conexao
    {

        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlTransaction tr;



        protected void OpenConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["cadeiaConexao"].ConnectionString);
            con.Open();
        }

        protected void CloseConnection()
        {
            con.Close();
        }



    }
}
