using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.WEB.Models
{
    public class TarefaExclusaoModel
    {
        public int IdTarefa { get; set; }
        public string Nome { get; set; }         
        public DateTime DataEntrega { get; set; }
        public string Descricao { get; set; }
    }
}