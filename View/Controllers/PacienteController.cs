using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class PacienteController : Controller
    {

        private PacienteRepository repository;

        public PacienteController()
        {
            repository = new PacienteRepository();
        }

        public ActionResult Index()
        {
            List<Paciente> pacientes = repository.ObterTodos();
            ViewBag.Pacientes = pacientes;
            return View();
        }

        public JsonResult ObterPacientesPeloIdCidade(int idCidade)
        {
            var pacientes = repository.ObterPacientesPeloIdCidade(idCidade);
            var resultado = new { data = pacientes };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObterPeloId(int id)
        {
            return Json(repository.ObterPeloId(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Inserir(Paciente paciente)
        {
            int id = repository.Inserir(paciente);
            return RedirectToAction("Cadastro");

        }



        public JsonResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Paciente paciente)
        {
            var alterou = repository.Alterar(paciente);
            var resultado = new { status = alterou };
            return Json(resultado);
        }

        public ActionResult Alterar()
        {
            return View("Alterar");
        }

        public ActionResult ObterTodos()
        {
            List<Paciente> pacientes = repository.ObterTodos();
            ViewBag.Pacientes = pacientes;
            return View();
        }
    }
}