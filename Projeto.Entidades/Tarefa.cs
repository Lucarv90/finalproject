using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Tarefa
    {
        public int IdTarefa { get; set; }
        public string Nome { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Descricao { get; set; }

        public int IdUsuario { set; get; }

        public Usuario Usuario { get; set; }

        public Tarefa()
        {

        }

        public Tarefa(int idTarefa, string nome, DateTime dataEntrega, string descricao, int idUsuario)
        {
            IdTarefa = idTarefa;
            Nome = nome;
            DataEntrega = dataEntrega;
            Descricao = descricao;
            IdUsuario = IdUsuario;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", IdTarefa, Nome, DataEntrega, Descricao);
        }

    }
}
