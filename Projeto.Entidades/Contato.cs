using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Contato
    {
        public int IdContato { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }


        public Contato()
        {

        }

        public Contato(int idContato, string nome, string email, string telefone, int idUsuario)
        {
            IdContato = idContato;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            IdUsuario = IdUsuario;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", IdContato, Nome, Email, Telefone);
        }


    }
}
