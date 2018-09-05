using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.WEB.Models;
using Projeto.Entidades;
using Projeto.DAL;

namespace Projeto.WEB.Controllers
{

    public class TARCTTController : Controller
    {
        // GET: TrefaContato
        [Authorize]
        public ActionResult CadastroTAR()
        {
            return View();
        }
        [Authorize]
        public ActionResult CadastroCTT()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroTAR(TarefaCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioRepositorio repUsuario = new UsuarioRepositorio();
                    
                    Tarefa t = new Tarefa();
                    t.Usuario = repUsuario.FindByLogin(User.Identity.Name);             

                    t.Nome = model.Nome;
                    t.DataEntrega = model.DataEntrega;
                    t.Descricao = model.Descricao;

                    TarefaRepositorio rep = new TarefaRepositorio();
                    rep.Insert(t); //gravando..
                    ViewBag.Mensagem = "Tarefa cadastrada com sucesso.";
                    ModelState.Clear(); //limpar os campos do formulário..

                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View();
        }



        [HttpPost]
        public ActionResult CadastroCTT(ContatoCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioRepositorio repUsuario = new UsuarioRepositorio();

                    Contato c = new Contato();
                    c.Usuario = repUsuario.FindByLogin(User.Identity.Name);

                    c.Nome = model.Nome;
                    c.Email = model.Email;
                    c.Telefone = model.Telefone;
                    


                    ContatoRepositorio rep = new ContatoRepositorio();
                    rep.Insert(c); //gravando..
                    ViewBag.Mensagem = "Contato cadastrado com sucesso.";
                    ModelState.Clear(); //limpar os campos do formulário..

                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View();
        }
    }


}
