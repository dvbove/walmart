using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Walmart.Prova.Web.Controllers
{
    public class EstadoController : Controller
    {
        public ActionResult Lista()
        {
            return View(Walmart.Prova.Site.Business.Estado.Listar());
        }

        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult Editar(int id)
        {
            var estado = Site.Business.Estado.Obter(id);
            return View(estado);
        }

        [HttpPost]
        public ActionResult Gravar(Model.Estado estado)
        {
            Site.Business.Estado.Gravar(estado);

            return RedirectToAction("Lista", "Estado");
        }

        [HttpPost]
        public ActionResult Atualizar(Model.Estado estado)
        {
            Site.Business.Estado.Atualizar(estado);

            return RedirectToAction("Lista", "Estado");
        }

        public ActionResult Excluir(int id)
        {
            bool success = Site.Business.Estado.Apagar(id);

            object result = success ? "OK" : "ERROR"; // have this be your object that you will return
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
