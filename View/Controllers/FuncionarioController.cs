using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class FuncionarioController : Controller
    {
        private FuncionarioRepository repository;

        public FuncionarioController()
        {
            repository = new FuncionarioRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Funcioarios = repository.ObterTodos();
            return View();
        }


        [HttpPost, Route("alterar")]
        public JsonResult Alterar(Funcionario funcionario)
        {
            var alterou = repository.Alterar(funcionario);
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

        [HttpPost, Route("inserir")]
        public ActionResult Inserir(Funcionario funcionario)
        {
            funcionario.RegistroAtivo = true;
            var id = repository.Inserir(funcionario);
            var resultado = new { id = id };
            return Json(resultado);
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            var funcionario = repository.ObterPeloId(id);
            if (funcionario == null)
            {
                return RedirectToAction("Index");
            }
            PostoRepository repositoryPosto = new PostoRepository();
            ViewBag.Postos = repositoryPosto.ObterTodos();
            CargoRepository repositoryCargo = new CargoRepository();
            ViewBag.Cargos = repositoryCargo.ObterTodos();
            ViewBag.Funcionario = funcionario;
            return View();
        }


        public ActionResult Cadastrar()
        {
            PostoRepository repositoryPosto = new PostoRepository();
            ViewBag.Postos = repositoryPosto.ObterTodos();
            CargoRepository repositoryCargo = new CargoRepository();
            ViewBag.Cargos = repositoryCargo.ObterTodos();
            return View();
        }
    }
}