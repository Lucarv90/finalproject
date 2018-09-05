using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Projeto.WEB.Models
{
    public class ContatoCadastroModel
    {
        [MinLength(3, ErrorMessage = "Por favor, informe no minimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do contato.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email.")]
        public string Email { get; set; }
                
        [Required(ErrorMessage = "Por favor, informe o Telefone.")]
        public string Telefone { get; set; }

        public int IdUsuario { set; get; }
    }
}