using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entidades;
using System.Data.SqlClient;

namespace Projeto.DAL
{
    public class ContatoRepositorio : Conexao
    {
        public void Insert(Contato c)
        {
            OpenConnection();
            string query = "insert into Contato(Nome, Email, Telefone, IdUsuario) "
                         + "values(@Nome, @Email, @Telefone, @IdUsuario)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.Parameters.AddWithValue("@Telefone", c.Telefone);
            cmd.Parameters.AddWithValue("@IdUsuario", c.Usuario.IdUsuario);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public void Update(Contato c)
        {
            OpenConnection();

            string query = "update Contato set Nome = @Nome, Email = @Email, Telefone = @Telefone, "
                         + "IdUsuario = @IdUsuario where IdContato = @IdContato";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Idcontato", c.IdContato);
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.Parameters.AddWithValue("@Telefone", c.Telefone);
            cmd.Parameters.AddWithValue("@IdUsuario", c.Usuario.IdUsuario);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public void Delete(int idContato)
        {
            OpenConnection();

            string query = "delete from Contato where IdContato = @IdContato";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdContato", idContato);
            cmd.ExecuteNonQuery();


            CloseConnection();
        }

        public List<Contato> FindAll()
        {
            OpenConnection();


            string query = "select * from Contato";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Contato> lista = new List<Contato>();

            while (dr.Read())
            {
                Contato c = new Contato();
                c.Usuario = new Usuario();

                c.IdContato = Convert.ToInt32(dr["IdContato"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Email = Convert.ToString(dr["Email"]);
                c.Telefone = Convert.ToString(dr["Telefone"]);
                c.Usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);

                lista.Add(c);
            }

            CloseConnection();
            return lista;
        }

        public Contato FindById(int idContato)
        {
            OpenConnection();
            string query = "select * from Contato where Contato = @IdContato";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdContato", idContato);
            dr = cmd.ExecuteReader();
            Contato c = null;

            if (dr.Read())
            {
                c = new Contato();
                c.Usuario = new Usuario();
                c.IdContato = Convert.ToInt32(dr["IdContato"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Email = Convert.ToString(dr["Email"]);
                c.Telefone = Convert.ToString(dr["Telefone"]);
                c.Usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
            }
            CloseConnection();
            return c;
        }

        public void Delete(Contato c)
        {
            throw new NotImplementedException();
        }
    }
}
