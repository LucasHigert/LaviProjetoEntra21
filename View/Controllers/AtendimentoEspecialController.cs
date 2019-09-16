using Model;
using Repository.Repository;
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


        #region Mudança de Lingua
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
        #endregion

        #region Index e Repository
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

        private PacienteRepository pacienteRepository = new PacienteRepository();
        #endregion

        [HttpGet]
        public JsonResult ObterPeloNome(string nome)
        {
            PacienteRepository pacienteRepository = new PacienteRepository();
            var pessoas = pacienteRepository.ObterPeloNome(nome);
            var result = new { data = pessoas };
            return Json(result, JsonRequestBehavior.AllowGet);
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

        public ActionResult ParteCorpoEspecial(string idPaciente)
        {
            if (VerificaLogado() == true)
            {
                ViewBag.Paciente = pacienteRepository.ObterPeloId(Convert.ToInt32(idPaciente));
                return View();
            }
            else
            {
                return Redirect("/login");
            }
        }

        #region Paciente
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

        public ActionResult InserirPaciente(Paciente paciente)
        {
            if (VerificaLogado() == true)
            {
                FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                Funcionario funcionario = funcionarioRepository.ObterPeloId(Convert.ToInt32(Session["usuarioLogadoId"]));
                paciente.IdPosto = funcionario.IdPosto;
                paciente.RegistroAtivo = true;
                pacienteRepository.Inserir(paciente);
                return Redirect("/atendimentoespecial/ParteCorpoEspecial?idPaciente="+paciente.Id);
            }
            else
            {
                return Redirect("/login");

            }
        }
        #endregion

    }
}