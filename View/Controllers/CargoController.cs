using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        private CargoRepository repository;

        public CargoController()
        {
            repository = new CargoRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Cargos = repository.ObterTodos();
            return View();
        }

        [HttpGet]
        public JsonResult ObterTodos()
        {
            var cargos = repository.ObterTodos();
            var resultado = new { data = cargos };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("cargo/")]
        public JsonResult ObterPeloId(int id)
        {
            return Json(repository.ObterPeloId(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, Route("editar")]
        public JsonResult Update(Cargo cargo)
        {
            var alterou = repository.Alterar(cargo);
            var resultado = new { status = alterou };
            return Json(resultado);
        }

    }
}