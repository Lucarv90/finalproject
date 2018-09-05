﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.Entidades;

namespace Projeto.WEB.Models
{
    public class ConsultaTarefaModel
    {
        public int IdTarefa { get; set; }
        public string Nome { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Descricao { get; set; }
        public int IdUsuario { set; get; }
    }
}