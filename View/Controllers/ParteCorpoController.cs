using System.Data.Entity.Migrations.Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace View.Controllers
{
    [Route("partecorpo/")]
    public class ParteCorpoRepository : Controller
    {
        ParteCorpoRepository repository;

        public ParteCorpoRepository()
        {
            repository = new ParteCorpoRepository();
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var parteCorpo = repository.ObterTodos();
            var resultado = new { data = parteCorpo };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, Route("cadastrar")]
        public ActionResult Cadastrar(ParteCorpo parteCorpo)
        {
            int id = repository.Inserir(parteCorpo);
            return RedirectToAction("Editar", new { id = id });
        }

        [HttpPost, Route("editar")]
        public JsonResult Editar(ParteCorpo parteCorpo)
        {

        }
     
    }
}