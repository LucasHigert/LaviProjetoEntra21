using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    [Route("partecorpo/")]
    public class ParteCorpoController : Controller
    {
        ParteCorpoRepository repositorio;

        public ParteCorpoController()
        {
            repositorio = new ParteCorpoRepository();
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var parteCorpo = repositorio.ObterTodos();
            var resultado = new { data = parteCorpo };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, Route("inserir")]
        public JsonResult Inserir(ParteCorpo parteCorpo)
        {
            parteCorpo.RegistroAtivo = true;
            bool id = repositorio.Inserir(parteCorpo);
            var resultado = new { status = id };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, Route("editar")]
        public JsonResult Update(ParteCorpo parteCorpo)
        {
            bool retorno = repositorio.Alterar(parteCorpo);
            var resultado = new { status = retorno };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            var apagou = repositorio.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            List<ParteCorpo> parteCorpos = repositorio.ObterTodos();
            ViewBag.PartesCorpo = parteCorpos;
            return View();
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            var partecorpo = repositorio.ObterPeloId(id);
            if (partecorpo == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.ParteCorpo = partecorpo;
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }


    }
}