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

        //Verificações do login
        #region Verificações Login
        private bool VerificaLogado()
        {
            if (Session["usuarioLogadoId"] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ActionResult VerificaPermisssao()
        {
            if (VerificaLogado() == false)
            {
                return Redirect("/login");
            }

            if ((Session["usuarioLogadoPermissao"].ToString() == "1") || (Session["usuarioLogadoPermissao"].ToString() == "2") ||
                (Session["usuarioLogadoPermissao"].ToString() == "3"))
            {
                return Redirect("/login/sempermissao");
            }
            else
            {
                return View();
            }
        }

        #endregion



        private PostoRepository repository;

        public PostoController()
        {
            repository = new PostoRepository();
        }

        public ActionResult Index()
        {
            if (VerificaLogado() == false)
            {
                return Redirect("/login");
            }
            List<Posto> postos = repository.ObterTodos();
            ViewBag.Postos = postos;
            return View();
        }

        //Apagar
        #region Apagar
        public ActionResult Apagar(int id)
        {
            if (Session["usuarioLogadoPermissao"].ToString() == "4")
            {
            var apagou = repository.Apagar(id);
                return RedirectToAction("index");
            }
            else
            {
                return Redirect("/login/sempermissao");
            }
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
            return VerificaPermisssao();
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
            return VerificaPermisssao();
        }
        #endregion
    }
}