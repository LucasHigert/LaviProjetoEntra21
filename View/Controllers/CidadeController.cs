using Model;
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
        // GET: Cidade
        private CidadeRepository repository;

        public CidadeController()
        {
            repository = new CidadeRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("obtercidadespeloidestado")]
        public JsonResult ObterCidadesPeloIdEstado(int idCidade)
        {
            var cidades = repository.ObterCidadesPeloIdEstado(idCidade);
            var resultado = new { data = cidades };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("cidade/")]
        public JsonResult ObterPeloId(int id)
        {
            return Json(repository.ObterPeloId(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Inserir(Cidade cidade)
        {
            cidade.RegistroAtivo = true;
            var id = repository.Inserir(cidade);
            var resultado = new { id = id };
            return Json(resultado);
        }

        [HttpGet]
        public JsonResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Cidade cidade)
        {
            var alterou = repository.Alterar(cidade);
            var resultado = new { status = alterou };
            return Json(resultado);
        }

        [HttpGet]
        public JsonResult ObterTodos()
        {
            var cidades = repository.ObterTodos();
            var resultado = new { data = cidades };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}