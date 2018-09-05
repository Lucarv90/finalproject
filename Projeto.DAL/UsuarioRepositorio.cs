using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entidades;
using System.Data.SqlClient;

namespace Projeto.DAL
{
    public class UsuarioRepositorio : Conexao
    {
        public void Insert(Usuario u)
        {
            OpenConnection();
            string query = "insert into Usuario(Nome,Login,Senha,DataCadastro) "
                         + "values(@Nome, @Login, @Senha, @DataCadastro)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", u.Nome);
            cmd.Parameters.AddWithValue("@Login", u.Login);
            cmd.Parameters.AddWithValue("@Senha", u.Senha);
            cmd.Parameters.AddWithValue("@DataCadastro", u.DataCadastro);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public bool HasLogin(string login)
        {
            OpenConnection();
            string query = "select count(*) from Usuario where Login = @Login";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Login", login);
            int qtd = Convert.ToInt32(cmd.ExecuteScalar());
            CloseConnection();
            return qtd > 0; //true, false
        }

        public Usuario FindByLoginSenha(string login, string senha)
        {
            OpenConnection();
            string query = "select * from Usuario where Login = @Login and Senha = @Senha";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Login", login);
            cmd.Parameters.AddWithValue("@Senha", senha);
            dr = cmd.ExecuteReader();
            Usuario u = null; //sem espaço de memória
            if (dr.Read()) //se usuario foi encontrado..
            {
                u = new Usuario(); //instanciando..
                u.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                u.Nome = Convert.ToString(dr["Nome"]);
                u.Login = Convert.ToString(dr["Login"]);
                u.Senha = Convert.ToString(dr["Senha"]);
                u.DataCadastro = Convert.ToDateTime(dr["DataCadastro"]);
            }
            CloseConnection();
            return u;

        }

        public Usuario FindByLogin(string login)
        {
            OpenConnection();
            string query = "select * from Usuario where Login = @Login";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Login", login);
            dr = cmd.ExecuteReader();
            Usuario u = null; //sem espaço de memória
            if (dr.Read()) //se usuario foi encontrado..
            {
                u = new Usuario(); //instanciando..
                u.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                u.Nome = Convert.ToString(dr["Nome"]);
                u.Login = Convert.ToString(dr["Login"]);
                u.Senha = Convert.ToString(dr["Senha"]);
                u.DataCadastro = Convert.ToDateTime(dr["DataCadastro"]);
            }
            CloseConnection();
            return u;

        }
    }
}
