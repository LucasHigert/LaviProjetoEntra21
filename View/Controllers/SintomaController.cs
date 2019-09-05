using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    [Route("sintoma/")]
    public class SintomaController : Controller
    {
        SintomaRepository repositorio;

        public SintomaController()
        {
            repositorio = new SintomaRepository();
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var sintoma = repositorio.ObterTodos();
            var resultado = new { data = sintoma };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, Route("inserir")]
        public JsonResult Inserir(Sintoma sintoma)
        {
            sintoma.RegistroAtivo = true;
            bool id = repositorio.Inserir(sintoma);
            var resultado = new { status = id };
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            var apagou = repositorio.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, Route("editar")]
        public JsonResult Update(Sintoma sintoma)
        {
            bool retorno = repositorio.Alterar(sintoma);
            var resultado = new { status = retorno };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Cadastrar()
        {
            ParteCorpoRepository repositorioParteCorpo = new ParteCorpoRepository();
            ViewBag.PartesCorpo = repositorioParteCorpo.ObterTodos();
            return View();
        }


        public ActionResult Index()
        {
            List<Sintoma> sintomas = repositorio.ObterTodos();
            ViewBag.Sintomas = sintomas;
            return View();
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            var sintoma = repositorio.ObterPeloId(id);
            if (sintoma == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Sintoma = sintoma;
            ParteCorpoRepository repositorioParteCorpo = new ParteCorpoRepository();
            ViewBag.PartesCorpo = repositorioParteCorpo.ObterTodos();
            return View();
        }
    }
}