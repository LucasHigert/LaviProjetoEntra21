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
        public ActionResult ObterTodos()
        {
            var cargos = repository.ObterTodos();
            var resultado = new { data = cargos };
            return View();
        }

        [HttpGet, Route("cargo/")]
        public JsonResult ObterPeloId(int id)
        {
            return Json(repository.ObterPeloId(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost, Route("editar")]
        public ActionResult Update(int id, string nome)
        {
            Cargo cargo = new Cargo();
            cargo.Id = id;           
            cargo.Nome = nome;

            repository.Alterar(cargo);
            return RedirectToAction("Index");
        }

        [HttpPost, Route("inserir")]
        public ActionResult Inserir(Cargo cargo)
        {
            int id = repository.Inserir(cargo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            Cargo cargo = new Cargo();
            cargo = repository.ObterPeloId(id);
            ViewBag.Cargos = cargo;            
            return View();
        }

        public ActionResult Cadastrar()
        {           
            return View();
        }

    }
}