using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entidades;
using System.Data.SqlClient;

namespace Projeto.DAL
{
    public class TarefaRepositorio : Conexao
    {
        public void Insert(Tarefa t)
        {
            OpenConnection();
            string query = "insert into Tarefa(Nome, DataEntrega, Descricao, IdUsuario) "
                         + "values(@Nome, @DataEntrega, @Descricao, @IdUsuario)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", t.Nome);
            cmd.Parameters.AddWithValue("@DataEntrega", t.DataEntrega);
            cmd.Parameters.AddWithValue("@Descricao", t.Descricao);
            cmd.Parameters.AddWithValue("@IdUsuario", t.Usuario.IdUsuario);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public void Update(Tarefa t)
        {
            OpenConnection();

            string query = "update Tarefa set Nome = @Nome, DataEntrega = @DataEntrega, Descricao = @Descricao, "
                         + "IdUsuario = @IdUsuario where IdTarefa = @IdTarefa";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdTarefa", t.IdTarefa);
            cmd.Parameters.AddWithValue("@Nome", t.Nome);
            cmd.Parameters.AddWithValue("@DataEntrega", t.DataEntrega);
            cmd.Parameters.AddWithValue("@Descricao", t.Descricao);
            cmd.Parameters.AddWithValue("@IdUsuario", t.Usuario.IdUsuario);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public void Delete(int idTarefa)
        {
            OpenConnection();

            string query = "delete from Tarefa where IdTarefa = @IdTarefa";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdTarefa", idTarefa);
            cmd.ExecuteNonQuery();

            
            CloseConnection();
        }

        public List<Tarefa> FindAll()
        {
            OpenConnection();


            string query = "select * from Tarefa";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Tarefa> lista = new List<Tarefa>();

            while (dr.Read())
            {
                Tarefa t = new Tarefa();
                t.Usuario = new Usuario();

                t.IdTarefa = Convert.ToInt32(dr["IdTarefa"]);
                t.Nome = Convert.ToString(dr["Nome"]);
                t.DataEntrega = Convert.ToDateTime(dr["DataEntrega"]);
                t.Descricao = Convert.ToString(dr["Descricao"]);
                t.Usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);

                lista.Add(t);
            }
                        
            CloseConnection();
            return lista;
        }

        public Tarefa FindById(int idTarefa)
        {
            OpenConnection();
            string query = "select * from Tarefa where IdTarefa = @IdTarefa";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdTarefa", idTarefa);
            dr = cmd.ExecuteReader();
            Tarefa t = null; 
                             
            if (dr.Read())
            {
                t = new Tarefa();
                t.Usuario = new Usuario();
                t.IdTarefa = Convert.ToInt32(dr["IdTarefa"]);
                t.Nome = Convert.ToString(dr["Nome"]);
                t.DataEntrega = Convert.ToDateTime(dr["DataEntrega"]);
                t.Descricao = Convert.ToString(dr["Descricao"]);
                t.Usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
            }
            CloseConnection();
            return t; 
        }

        
    }
}
