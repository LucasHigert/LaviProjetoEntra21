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
    public class PostoController : Controller
    {
        // GET: Posto

        private PostoRepository repository;

        public PostoController()
        {
            repository = new PostoRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Posto> postos = repository.ObterTodos();
            ViewBag.Postos = postos;
            return View();
        }

        [HttpGet]
        public ActionResult ObterTodos()
        {
            var postos = repository.ObterTodos();
            var resultado = new { data = postos };
            return View();
        }

        [HttpGet, Route("posto/")]
        public JsonResult ObterPeloId(int id)
        {
            var posto = repository.ObterPeloId(id);
            return Json(posto, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");            
        }

        [HttpPost, Route("editar")]
        public ActionResult Update(int id, int idCidade, string nome, string cep)
        {
            Posto posto = new Posto();
            posto.Id = id;
            posto.IdCidade = idCidade;
            posto.Nome = nome;
            posto.Cep = cep;

            repository.Alterar(posto);
            return RedirectToAction("Index");           
        }

        [HttpPost, Route("inserir")]
        public ActionResult Inserir(Posto posto)
        {
            int id = repository.Inserir(posto);
            return RedirectToAction("Index");            
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            Posto posto = new Posto();
            posto = repository.ObterPeloId(id);
            ViewBag.Posto = posto;
            CidadeRepository repositoryCidade = new CidadeRepository();
            ViewBag.Cidades = repositoryCidade.ObterTodos();
            return View();            
        }


        public ActionResult Cadastrar()
        {
            CidadeRepository repositoryCidade = new CidadeRepository();
            List<Cidade> cidades = repositoryCidade.ObterTodos();
            ViewBag.Cidades = cidades;
            return View();
        }
    }
}