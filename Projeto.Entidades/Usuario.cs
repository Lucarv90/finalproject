using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }

        public List<Contato> Contatos { get; set; }

        public List<Tarefa> Tarefas { get; set; }

      

        public Usuario()
        {

        }

        public Usuario(int idUsuario, string nome, string login, string senha,
            DateTime dataCadastro)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Login = login;
            Senha = senha;
            DataCadastro = DataCadastro;
        }


        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}", IdUsuario, Nome, Login, Senha, DataCadastro);
        }


    }
}
