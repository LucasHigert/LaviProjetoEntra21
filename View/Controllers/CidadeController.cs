using Model;
using Repository;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class CidadeController : Controller
    {
        private CidadeRepository repository;

        public CidadeController()
        {
            repository = new CidadeRepository();
        }

        [HttpGet, Route("obtertodospeloidestado")]
        public JsonResult ObterTodosPeloIdEstado(int idEstado)
        {
            var cidades = repository.ObterCidadesPeloIdEstado(idEstado);
            var resultado = new { data = cidades };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var cidade = repository.ObterPeloId(id);
            if (cidade == null)
                return HttpNotFound();

            return Json(cidade, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, Route("cadastro")]
        public JsonResult Cadastro(Cidade cidade)
        {
            var id = repository.Inserir(cidade);
            var resultado = new { id = id };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, Route("alterar")]
        public JsonResult Alterar(Cidade cidade)
        {
            var alterou = repository.Alterar(cidade);
            var resultado = new { status = alterou };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index()
        {
            SistemaContext context = new SistemaContext();
            ViewBag.Cidades = context.Cidades.ToList();
            return View();
        }
    }
}