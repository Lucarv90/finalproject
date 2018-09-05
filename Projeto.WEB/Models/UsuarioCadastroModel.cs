using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.WEB.Models
{
    public class UsuarioCadastroModel
    {
        [Required(ErrorMessage ="Por favor, informe um nome de usuário")]
        public string NomeUsr { get; set; }

        [Required(ErrorMessage = "Por favor, informe um Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Por favor, informe uma Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Por favor, confirme sua senha")]
        public string SenhaConfirm { get; set; }
    }
}