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
        public JsonResult ObterTodos()
        {
            var postos = repository.ObterTodos();
            var resultado = new { data = postos };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("posto/")]
        public JsonResult ObterPeloId(int id)
        {
            var posto = repository.ObterPeloId(id);
            return Json(posto, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
                
        [HttpPost, Route("editar")]
        public JsonResult Update(Posto posto)
        {
            var alterou = repository.Alterar(posto);
            var resultado = new { status = alterou };
            return Json(resultado);
        }

        [HttpPost, Route("inserir")]
        public ActionResult Inserir(Posto posto)
        {
            posto.RegistroAtivo = true;
            var id = repository.Inserir(posto);
            var resultado = new { id = id };
            return Json(resultado);
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            var posto = repository.ObterPeloId(id);
            if (posto == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Posto = posto;
            return View();
        }


        public ActionResult Cadastrar()
        {
            CidadeRepository repositoryCidade = new CidadeRepository();
            ViewBag.Cidades = repositoryCidade.ObterTodos();
            return View();
        }

        

        

        
    }
}