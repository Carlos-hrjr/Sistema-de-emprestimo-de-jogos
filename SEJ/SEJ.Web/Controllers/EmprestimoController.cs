using SEJ.Business;
using SEJ.Entidades;
using SEJ.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEJ.Web.Controllers
{
    public class EmprestimoController : Controller
    {

        EmprestimoBusiness bus = new EmprestimoBusiness();

        public ActionResult Index()
        {
            var emprestimos = bus.CarregarTodos();

            return View(emprestimos);
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            var model = new EmprestimoVM();
            model.Jogos = CarregarJogos().Select(x => new SelectListItem() {
                Value = x.Id.ToString(),
                Text = x.Descricao
            });
            model.Amigos = CarregarAmigos().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            });

            return View(model);
        }

        [HttpPost]
        public void Adicionar(Emprestimo emprestimo)
        {
            emprestimo.DataEmprestimo = DateTime.Now;
            bus.Cadastrar(emprestimo);
        }

        [HttpGet]
        public ActionResult Historico()
        {
            var historico = bus.CarregarHistorico();
            return View(historico);
        }

        [HttpPost]
        public void Devolver(string id)
        {
            var idInt = int.Parse(id);
            bus.Devolver(idInt);
        }

        #region AJAX

        [HttpGet]
        public IList<Amigo> CarregarAmigos()
        {
            var amigoBus = new AmigoBusiness();
            return amigoBus.CarregarTodos();
        }


        [HttpGet]
        public IList<Jogo> CarregarJogos()
        {
            var jogoBus = new JogoBusiness();
            return jogoBus.CarregarNaoEmprestados();
        }
        #endregion

    }

}