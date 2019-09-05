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

        public ActionResult Index()
        {
            List<Posto> postos = repository.ObterTodos();
            ViewBag.Postos = postos;
            return View();
        }

        //Apagar
        #region Apagar
        [HttpGet]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            return RedirectToAction("index");
        }
        #endregion

        //Alterar
        #region Alterar
        [HttpPost]
        public ActionResult Update(Posto posto)
        {
            var alterou = repository.Alterar(posto);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            var posto = repository.ObterPeloId(id);
            if (posto == null)
            {
                return RedirectToAction("Index");
            }
            CidadeRepository repositoryCidade = new CidadeRepository();
            ViewBag.Cidades = repositoryCidade.ObterTodos();
            ViewBag.Posto = posto;
            return View();
        }

        #endregion


        //Cadastar
        #region Cadastrar                
        [HttpPost]
        public ActionResult Inserir(Posto posto)
        {
            posto.RegistroAtivo = true;
            var id = repository.Inserir(posto);
            return RedirectToAction("index");
        }

        public ActionResult Cadastrar()
        {
            CidadeRepository repositoryCidade = new CidadeRepository();
            ViewBag.Cidades = repositoryCidade.ObterTodos();
            return View();
        }
        #endregion
    }
}