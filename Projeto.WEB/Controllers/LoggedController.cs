using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.WEB.Models;
using Projeto.DAL;
using Projeto.Entidades;

namespace Projeto.WEB.Controllers
{
    public class LoggedController : Controller
    {
        // GET: Logged
        [Authorize]
        public ActionResult Index()
        {

            List<ConsultaTarefaModel> lista = new List<ConsultaTarefaModel>();
            try
            {

                TarefaRepositorio rep = new TarefaRepositorio();
                foreach (Tarefa t in rep.FindAll())
                {

                    ConsultaTarefaModel model = new ConsultaTarefaModel();
                    UsuarioRepositorio repUsuario = new UsuarioRepositorio();



                    t.Usuario = new Usuario();
                    t.Usuario = repUsuario.FindByLogin(User.Identity.Name);


                    model.IdTarefa = t.IdTarefa;
                    model.Nome = t.Nome;
                    model.DataEntrega = t.DataEntrega;
                    model.Descricao = t.Descricao;

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

       //Tarefa\Edicao
        public ActionResult Edicao()
        {
            TarefaEdicaoModel model = new TarefaEdicaoModel();

            try
            {
                UsuarioRepositorio repUsuaruio = new UsuarioRepositorio();

                Tarefa t = new Tarefa();
                t.Usuario = repUsuaruio.FindByLogin(User.Identity.Name);



                int idTarefa = int.Parse(Request.QueryString["id"]);


                model.IdTarefa = t.IdTarefa;
                model.Nome = t.Nome;
                model.Descricao = t.Descricao;
                model.DataEntrega = t.DataEntrega;

                TarefaRepositorio rep = new TarefaRepositorio();
                rep.Update(t);
                ViewBag.Mensagem = "Tarefa atualizada com sucesso.";

            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edicao(TarefaEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioRepositorio repUsuario = new UsuarioRepositorio();

                    Tarefa t = new Tarefa();
                    t.Usuario = repUsuario.FindByLogin(User.Identity.Name);

                    t.IdTarefa = model.IdTarefa;
                    t.Nome = model.Nome;
                    t.Descricao = model.Descricao;
                    t.DataEntrega = model.DataEntrega;



                    TarefaRepositorio rep = new TarefaRepositorio();
                    rep.Update(t); //gravando..
                    ViewBag.Mensagem = "Tarefa atualizada com sucesso.";
                    ModelState.Clear(); //limpar os campos do formulário..

                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }

            return View();

        }

        // GET: Contato/Excluir
        public ActionResult Excluir()
        {
            TarefaExclusaoModel model = new TarefaExclusaoModel();

            try
            {
                int idTarefa = int.Parse(Request.QueryString["id"]);

                TarefaRepositorio rep = new TarefaRepositorio();
                Tarefa t = rep.FindById(idTarefa);

                model.IdTarefa = t.IdTarefa;
                model.Nome = t.Nome;
                model.Descricao = t.Descricao;
                model.DataEntrega = t.DataEntrega;

            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }



            return View(model);
        }

        [HttpDelete]
        public ActionResult Excluir(TarefaExclusaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioRepositorio repUsuario = new UsuarioRepositorio();

                    Tarefa t = new Tarefa();
                    t.Usuario = repUsuario.FindByLogin(User.Identity.Name);



                    t.IdTarefa = model.IdTarefa;
                    t.Nome = model.Nome;
                    t.Descricao = model.Descricao;
                    t.DataEntrega = model.DataEntrega;



                    TarefaRepositorio rep = new TarefaRepositorio();
                    //rep.Delete(t); //gravando..
                    ViewBag.Mensagem = "Tarefa excluída com sucesso.";
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