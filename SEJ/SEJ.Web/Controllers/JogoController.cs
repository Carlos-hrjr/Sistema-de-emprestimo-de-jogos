using SEJ.Business;
using SEJ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEJ.Web.Controllers
{
    public class JogoController : Controller
    {
        // GET: Jogo
        [HttpGet]
        public ActionResult Index()
        {
            var bus = new JogoBusiness();
            var jogos = bus.CarregarTodos();
            return View(jogos);
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public void Adicionar(Jogo jogo)
        {
            
            var bus = new JogoBusiness();
            if (jogo.Id != null)
            {
                bus.Alterar(jogo);
            }
            else
            {
                bus.Cadastrar(jogo);
            }
            
        }

        [HttpPost]
        public void Excluir(string id)
        {
            try
            {
                var idInt = int.Parse(id);
                var bus = new JogoBusiness();
                bus.Excluir(idInt);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            var bus = new JogoBusiness();
            var jogo = bus.CarregarPorId(id);
            return View("Alterar", jogo);
        } 
    }
}