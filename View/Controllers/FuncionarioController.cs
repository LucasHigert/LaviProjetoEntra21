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

        [HttpGet, Route("Obtertodospeloidposto")]
        public JsonResult ObterTodosPeloIdPosto(int idPosto)
        {
            var funcionarios = repository.ObterFuncionariosPeloIdPosto(idPosto);
            var resultado = new { data = funcionarios };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("Obtertodospeloidcargo")]
        public JsonResult ObterTodosPelIdCargos(int idCargos)
        {
            var funcionarios = repository.ObterFuncionarioPeloIdCargo(idCargos);
            var resultado = new { data = funcionarios };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var funcionario = repository.ObterPeloId(id);
            if (funcionario == null) return HttpNotFound();

            return Json(funcionario, JsonRequestBehavior.AllowGet);
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
    }
}