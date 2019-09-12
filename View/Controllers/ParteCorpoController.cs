using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ParteCorpoController : Controller
    {
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


        ParteCorpoRepository repositorio;

        public ParteCorpoController()
        {
            repositorio = new ParteCorpoRepository();
        }

        public ActionResult Index()
        {
            if (VerificaLogado() == true)
            {
                List<ParteCorpo> parteCorpos = repositorio.ObterTodos();
                ViewBag.PartesCorpo = parteCorpos;
                return View();
            }
            else
            {
                return Redirect("/login");
            }
        }
        //Inserir
        #region Inserir

        [HttpPost, Route("inserir")]
        public ActionResult Inserir(ParteCorpo parteCorpo)
        {
            if (VerificaLogado() == true)
            {
                if (Session["usuarioLogadoPermissao"].ToString() == "4")
                {
                    parteCorpo.RegistroAtivo = true;
                    bool cadastrado = repositorio.Inserir(parteCorpo);
                    if (cadastrado == true)
                    {
                        return RedirectToAction("index");
                    }
                    else
                    {
                        return RedirectToAction("Cadastrar");
                    }

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

        public ActionResult Cadastrar()
        {
            return VerificaPermisssao();
        }

        #endregion

        //Editar
        #region Editar

        [HttpPost, Route("editar")]
        public ActionResult Update(ParteCorpo parteCorpo)
        {
            if (VerificaLogado() == true)
            {
                if (Session["usuarioLogadoPermissao"].ToString() == "4")
                {
                    bool retorno = repositorio.Alterar(parteCorpo);
                    return RedirectToAction("index");
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
            if (VerificaLogado() == true)
            {
                if (Session["usuarioLogadoPermissao"].ToString() == "4")
                {

                    var partecorpo = repositorio.ObterPeloId(id);
                    if (partecorpo == null)
                    {
                        return RedirectToAction("Index");
                    }
                    ViewBag.ParteCorpo = partecorpo;
                    return View();
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


        //Apagar
        #region Apagar

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            if (VerificaLogado() == false)
            {
                if (Session["usuarioLogadoPermissao"].ToString() == "4")
                {
                    var apagou = repositorio.Apagar(id);
                    return RedirectToAction("index");
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

        #region PartesCorpo
       
        public ActionResult CorpoMasculino()
        {
            if (VerificaLogado() == true)
            {
                return View();
            }
            else
            {
                return Redirect("/login");
            }
        }

        #endregion
    }
}
