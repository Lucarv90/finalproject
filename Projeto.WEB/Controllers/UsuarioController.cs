using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.WEB.Models;
using Projeto.Entidades;
using Projeto.DAL;
using Projeto.UTIL;

namespace Projeto.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Cadastro()
        {
            return View();

        }        

        [HttpPost]
        public ActionResult Cadastro(UsuarioCadastroModel model)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    if (model.Senha.Equals(model.SenhaConfirm))
                    {
                        UsuarioRepositorio rep = new UsuarioRepositorio();
                        if (!rep.HasLogin(model.Login))
                        {
                            Criptografia c = new Criptografia();
                            Usuario u = new Usuario();
                            u.Nome = model.NomeUsr;
                            u.Login = model.Login;
                            u.Senha = c.EncriptarSenha(model.Senha);
                            u.DataCadastro = DateTime.Now;

                            rep.Insert(u);
                            ViewBag.Mensagem = "Usuario cadastrado com sucesso.";
                            ModelState.Clear();

                        }
                        else
                        {

                            ViewBag.Mensagem = "Login já cadastrado, por favor tente outro.";

                        }
                    }
                    else
                    {
                        ViewBag.Mensagem = "Senhas não conferem, por favor tente novamente.";

                    }
                }                      
            }
            catch (Exception e)
            {
                //exibindo mensagem de erro..
                ViewBag.Mensagem = e.Message;
            }
            
            return View();

        }
        

    }
}