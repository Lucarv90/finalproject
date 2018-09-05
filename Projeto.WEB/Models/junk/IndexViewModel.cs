using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.WEB.Models
{
    public class IndexViewModel
    {
        public MasterLayoutModel ListaTarefas { get; set; }
        public MasterLayoutModel ListaContatos { get; set; }

       


        public IndexViewModel()
        {
            ListaTarefas = new MasterLayoutModel();
            ListaContatos = new MasterLayoutModel();
        }
    }
}