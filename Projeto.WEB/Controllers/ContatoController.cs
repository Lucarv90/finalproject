
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
    public class ContatoController : Controller
    {
        // GET: Contato/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Contato/Edicao
        public ActionResult Edicao()
        {
            ContatoEdicaoModel model = new ContatoEdicaoModel();

            try
            {
                UsuarioRepositorio repUsuaruio = new UsuarioRepositorio();

                Contato c = new Contato();
                c.Usuario = repUsuaruio.FindByLogin(User.Identity.Name);



                int idContato = int.Parse(Request.QueryString["id"]);
                             
                
                model.IdContato = c.IdContato;
                model.Nome = c.Nome;
                model.Telefone = c.Telefone;
                model.Email = c.Email;

                ContatoRepositorio rep = new ContatoRepositorio();
                rep.Update(c);
                ViewBag.Mensagem = "Contato atualizado com sucesso.";

            }
            catch(Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            return View(model);
        }

        // GET: Contato/Excluir
        public ActionResult Excluir()
        {
            ContatoExclusaoModel model = new ContatoExclusaoModel();

            try
            {
                int idContato = int.Parse(Request.QueryString["id"]);

                ContatoRepositorio rep = new ContatoRepositorio();
                Contato c = rep.FindById(idContato);

                model.IdContato = c.IdContato;
                model.Nome = c.Nome;
                model.Telefone = c.Telefone;
                model.Email = c.Email;

            }
            catch(Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

           
            
            return View(model);
        }



        public ActionResult Consulta()
        {
            List<ConsultaContatoModel> lista = new List<ConsultaContatoModel>();
            try
            {

                ContatoRepositorio rep = new ContatoRepositorio();
                foreach (Contato c in rep.FindAll())
                {

                    ConsultaContatoModel model = new ConsultaContatoModel();
                    UsuarioRepositorio repUsuario = new UsuarioRepositorio();



                    c.Usuario = new Usuario();
                    c.Usuario = repUsuario.FindByLogin(User.Identity.Name);


                    model.IdContato = c.IdContato;
                    model.Nome = c.Nome;
                    model.Email = c.Email;
                    model.Telefone = c.Telefone;



                    lista.Add(model); //adicionar na lista..

                }


            }
            catch (Exception e)
            {
                //gerar mensagem de erro..
                ViewBag.Mensagem = e.Message;
            }
            //enviando a model..            



            return View(lista);

        }

        [HttpPost]
        public ActionResult Cadastro(ContatoCadastroModel model)
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

        [HttpPost]
        public ActionResult Edicao(ContatoEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioRepositorio repUsuario = new UsuarioRepositorio();

                    Contato c = new Contato();
                    c.Usuario = repUsuario.FindByLogin(User.Identity.Name);

                    c.IdContato = model.IdContato;
                    c.Nome = model.Nome;
                    c.Email = model.Email;
                    c.Telefone = model.Telefone;



                    ContatoRepositorio rep = new ContatoRepositorio();
                    rep.Update(c); //gravando..
                    ViewBag.Mensagem = "Contato Atualizado com sucesso.";
                    ModelState.Clear(); //limpar os campos do formulário..

                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }

            return View();

        }


        [HttpDelete]
        public ActionResult Excluir(ContatoExclusaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioRepositorio repUsuario = new UsuarioRepositorio();

                    Contato c = new Contato();
                    c.Usuario = repUsuario.FindByLogin(User.Identity.Name);

                   

                    c.IdContato = model.IdContato;
                    c.Nome = model.Nome;
                    c.Email = model.Email;
                    c.Telefone = model.Telefone;



                    ContatoRepositorio rep = new ContatoRepositorio();
                    rep.Delete(c); //gravando..
                    ViewBag.Mensagem = "Contato excluído com sucesso.";
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