using SEJ.Business;
using SEJ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEJ.Web.Controllers
{
    public class AmigoController : Controller
    {
        public ActionResult Index()
        {
            var bus = new AmigoBusiness();
            var amigos = bus.CarregarTodos();
            return View(amigos);
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public bool Adicionar(Amigo amigo)
        {
            try
            {
                var bus = new AmigoBusiness();
                if (amigo.Id != null)
                {
                    bus.Alterar(amigo);
                }
                else
                {
                    bus.Cadastrar(amigo);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public void Excluir(string id)
        {
            try
            {
                var idInt = int.Parse(id);
                var bus = new AmigoBusiness();
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
            var bus = new AmigoBusiness();
            var amigo = bus.CarregarPorId(id);
            return View("Alterar", amigo);
        }
    }
}