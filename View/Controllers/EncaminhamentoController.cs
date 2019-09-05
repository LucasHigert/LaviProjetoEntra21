using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    [Route("encaminhamento/")]
    public class EncaminhamentoController : Controller
    {
        EncaminhamentoRepository repository;

        public EncaminhamentoController()
        {
            repository = new EncaminhamentoRepository();
        }

        [HttpGet, Route("obtertodospelostatus")]
        public JsonResult ObterTodosPeloStatus(int status)
        {
            var encaminhamento = repository.ObterTodosPeloStatus(status);
            var resultado = new { data = encaminhamento };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost, Route("inserir")]
        public JsonResult Inserir(Encaminhamento encaminhamento)
        {
            encaminhamento.Status = 0;
            int id = repository.Inserir(encaminhamento);
            var resultado = new { status = id };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        [HttpPost, Route("editar")]
        public JsonResult Update(Encaminhamento encaminhamento)
        {
            bool retorno = repository.Alterar(encaminhamento);
            var resultado = new { status = retorno };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cadastrar()
        {
            PostoRepository repositoryPosto = new PostoRepository();
            ViewBag.Postos = repositoryPosto.ObterTodos();
            return View();
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            var encaminhamento = repository.ObterPeloId(id);
            if (encaminhamento == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Encaminhamento = encaminhamento;
            PostoRepository repositoryPosto = new PostoRepository();
            ViewBag.Postos = repositoryPosto.ObterTodos();
            return View();
        }

        public ActionResult Index()
        {
            List<Encaminhamento> encaminhamentos = repository.ObterTodosPeloStatus(0);
            ViewBag.Encaminhamentos = encaminhamentos;
            return View();
        }
    }
}