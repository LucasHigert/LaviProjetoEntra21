using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class AtendimentoEspecialController : Controller
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


        #endregion

        //Método que irá mudar a lingua do sistema
        public void Change(String lang)
        {
            if (lang != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
                HttpCookie cookie = new HttpCookie("Language");
                cookie.Value = lang;
                Response.Cookies.Add(cookie);
            }

        }

        public ActionResult Index()
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

        public ActionResult InstrucoesEspecial(string lang)
        {
            if (VerificaLogado() == true)
            {
                Change(lang);
                return View();

            }
            else
            {
                return Redirect("/login");
            }

        }

        public ActionResult ParteCorpoEspecial()
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

        public ActionResult BuscaPaciente()
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

        public ActionResult CadastroPacienteEspecial()
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
    }
}