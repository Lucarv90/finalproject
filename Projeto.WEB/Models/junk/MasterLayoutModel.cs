using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.WEB.Models;

namespace Projeto.WEB.Models
{
    public class MasterLayoutModel
    {
        public ConsultaTarefaModel ConsultaTarefaModel { set; get; }
        public ConsultaContatoModel ConsultaContatoModel { set; get; }

        internal void Add(List<MasterLayoutModel> listaTAR)
        {
            throw new NotImplementedException();
        }

    }
}