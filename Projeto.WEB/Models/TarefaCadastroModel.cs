using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Projeto.WEB.Models
{
    public class TarefaCadastroModel
    {
        [MinLength(3, ErrorMessage = "Por favor, informe no minimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome da tarefa.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de entrega.")]
        public DateTime DataEntrega  { get; set; }

        [MaxLength(2000, ErrorMessage = "Por favor, informe no maximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, descreva a sua tarefa.")]
        public string Descricao { get; set; }

        public int IdUsuario { set; get; }


     }
}