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
            if ((Session["usuarioLogadoPermissao"].ToString() == "1") || (Session["usuarioLogadoPermissao"].ToString() == "2"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        EncaminhamentoRepository repository;

        public EncaminhamentoController()
        {
            repository = new EncaminhamentoRepository();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Escolha(/*int idAtendimento*/)
        {
            if (VerificaLogado() == true)
            {
                if (VerificaPermisssao() == true)
                {
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

        public ActionResult PostoEncaminhar()
        {
            return View();
        }
        public ActionResult FarmaciaEncaminhar()
        {
            return View();
        }
        public ActionResult HospitalEncaminhar()
        {
            return View();
        }

    }
}