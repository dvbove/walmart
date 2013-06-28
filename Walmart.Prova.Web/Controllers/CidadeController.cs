using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Walmart.Prova.Web.Controllers
{
    public class CidadeController : Controller
    {
        public ActionResult Lista()
        {
            return View(Walmart.Prova.Site.Business.Cidade.Listar());
        }

        public ActionResult Novo()
        {
            Model.Cidade cidade = new Model.Cidade();
            cidade.Estados = Walmart.Prova.Site.Business.Estado.Listar();

            return View(cidade);
        }

        public ActionResult Editar(int id)
        {
            var cidade = Site.Business.Cidade.Obter(id);
            cidade.Estados = Walmart.Prova.Site.Business.Estado.Listar();

            return View(cidade);
        }

        [HttpPost]
        public ActionResult Gravar(Model.Cidade cidade)
        {
            Site.Business.Cidade.Gravar(cidade);

            return RedirectToAction("Lista", "Cidade");
        }

        [HttpPost]
        public ActionResult Atualizar(Model.Cidade cidade)
        {
            Site.Business.Cidade.Atualizar(cidade);

            return RedirectToAction("Lista", "Cidade");
        }

        public ActionResult Excluir(int id)
        {
            bool success = Site.Business.Cidade.Apagar(id);

            object result = success ? "OK" : "ERROR"; // have this be your object that you will return
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
