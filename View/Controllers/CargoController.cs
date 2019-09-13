using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo

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

        private CargoRepository repository;

        public CargoController()
        {
            repository = new CargoRepository();
        }

        //Index
        #region Index
        [HttpGet]
        public ActionResult Index()
        {
            if (VerificaLogado() == true)
            {
                ViewBag.Cargos = repository.ObterTodos();
                return View();

            }
            else
            {
                return Redirect("/login");
            }
        }
        #endregion

        //Apagar
        #region Apagar
        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            if (VerificaLogado() == true)
            {
                if (Session["usuarioLogadoPermissao"].ToString() == "4")
                {
                    repository.Apagar(id);
                    return RedirectToAction("Index");
                }
                else
                {
                    return Redirect("/login/sempermissao");
                }
            }
            else
            {
                return Redirect("/login");
            }
        }
        #endregion

        //Editar
        #region Editar
        [HttpPost, Route("editar")]
        public ActionResult Update(int id, string nome, int nivelpermissao)
        {
            if (VerificaLogado() == true)
            {
                if (Session["usuarioLogadoPermissao"].ToString() == "4")
                {
                    Cargo cargo = new Cargo();
                    cargo.Id = id;
                    cargo.Nome = nome;
                    cargo.NivelPermissao = nivelpermissao;

                    repository.Alterar(cargo);
                    return RedirectToAction("Index");
                }
                else
                {
                    return Redirect("/login/sempermissao");
                }

            }
            else
            {
                return Redirect("/login");
            }
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            Cargo cargo = new Cargo();
            cargo = repository.ObterPeloId(id);
            ViewBag.Cargos = cargo;
            return VerificaPermisssao();
        }
        #endregion

        //Inserir
        #region Inserir
        [HttpPost, Route("inserir")]
        public ActionResult Inserir(Cargo cargo)
        {
            int id = repository.Inserir(cargo);
            return RedirectToAction("Index");
        }

        public ActionResult Cadastrar()
        {
            return VerificaPermisssao();
        }
        #endregion
    }
}