using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    [Route("paciente/")]
    public class PacienteController : Controller
    {
        private PacienteRepository repository;

        public PacienteController()
        {
            repository = new PacienteRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet,Route("obterpacientespeloidcidade")]
        public JsonResult ObterPacientesPeloIdCidade(int idCidade)
        {
            var pacientes = repository.ObterPacientesPeloIdCidade(idCidade);
            var resultado = new { data = pacientes };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("paciente/")]
        public JsonResult ObterPeloId(int id)
        {
            return Json(repository.ObterPeloId(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Inserir(Paciente paciente)
        {
            paciente.RegistroAtivo = true;
            var id = repository.Inserir(paciente);
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
        public JsonResult Update(Paciente paciente)
        {
            var alterou = repository.Alterar(paciente);
            var resultado = new { status = alterou };
            return Json(resultado);
        }
    }
}