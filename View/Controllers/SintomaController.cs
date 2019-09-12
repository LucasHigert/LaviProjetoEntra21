using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    [Route("sintoma/")]
    public class SintomaController : Controller
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

        private bool VerificaPermisssao()
        {
            if (VerificaLogado() == false)
            {
                return false;
            }

            if ((Session["usuarioLogadoPermissao"].ToString() == "3") || (Session["usuarioLogadoPermissao"].ToString() == "4") || (Session["usuarioLogadoPermissao"].ToString() == "2"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        SintomaRepository repositorio;

        public SintomaController()
        {
            repositorio = new SintomaRepository();
        }

        public ActionResult Index()
        {
            if (VerificaLogado() == true)
            {
                List<Sintoma> sintomas = repositorio.ObterTodos();
                ViewBag.Sintomas = sintomas;
                return View();
            }
            else
            {
                return Redirect("/login");
            }
        }

        //Apagar
        #region Apagar
        public ActionResult Apagar(int id)
        {
            if (VerificaLogado() == true)
            {
                if (VerificaPermisssao() == true)
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

        //Cadastro
        #region Cadastro
        [HttpPost]
        public ActionResult Inserir(Sintoma sintoma)
        {
            if (VerificaLogado() == true)
            {
                if (VerificaPermisssao() == true)
                {
                    sintoma.RegistroAtivo = true;
                    bool id = repositorio.Inserir(sintoma);
                    if (id == true)
                    {
                        return RedirectToAction("index");
                    }
                    else
                    {
                        return RedirectToAction("cadastro");
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
            if (VerificaLogado() == true)
            {
                if (VerificaPermisssao() == true)
                {

                    ParteCorpoRepository repositorioParteCorpo = new ParteCorpoRepository();
                    ViewBag.PartesCorpo = repositorioParteCorpo.ObterTodos();
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

        //Editar
        #region Editar
        public ActionResult Update(Sintoma sintoma)
        {
            if (VerificaLogado() == true)
            {
                if ((Session["usuarioLogadoPermissao"].ToString() == "4") || (Session["usuarioLogadoPermissao"].ToString() == "3"))
                {
                    bool retorno = repositorio.Alterar(sintoma);
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
                if ((Session["usuarioLogadoPermissao"].ToString() == "4") || (Session["usuarioLogadoPermissao"].ToString() == "3"))
                {
                    var sintoma = repositorio.ObterPeloId(id);
                    if (sintoma == null)
                    {
                        return RedirectToAction("Index");
                    }
                    ParteCorpoRepository repositorioParteCorpo = new ParteCorpoRepository();
                    ViewBag.PartesCorpo = repositorioParteCorpo.ObterTodos();
                    ViewBag.Sintoma = sintoma;
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
    }
}