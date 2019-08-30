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
            ////var cidades = repository.ObterTodos(cidades);
            //List<Cidade> cidades = repository.ObterTodos();
            //return View();

            List<Cidade> cidades = repository.ObterTodos();
            ViewBag.Cidades = cidades;
            return View();
        }

        [HttpGet, Route("cidade/")]
        public ActionResult ObterPeloId(int id)
        {
            return Json(repository.ObterPeloId(id), JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public ActionResult Cadastro()
        {
            //cidade.RegistroAtivo = true;
            //var id = repository.Inserir(cidade);
            //var resultado = new { id = id };
            return View("cadastro");
        }

        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id,string nome)
        {
            Cidade cidade = new Cidade();
            cidade.Id = id;
            cidade.Nome = nome;

            repository.Alterar(cidade);
            return RedirectToAction("Index");
        }

        public ActionResult Alterar(int id)
        {
            Cidade cidade = repository.ObterPeloId(id);
            ViewBag.Categoria = cidade;
            return View();
        }


        //[HttpGet, Route("obtertodos")]
        public ActionResult ObterTodos()
        //public JsonResult ObterTodos()
        {
            List<Cidade> cidades = repository.ObterTodos();
            ViewBag.Cidades = cidades;
            return View();

            //var cidades = repository.ObterTodos();
            //var resultado = new { data = cidades };
            //return Json(resultado,
            //    JsonRequestBehavior.AllowGet);
        }
    }
}