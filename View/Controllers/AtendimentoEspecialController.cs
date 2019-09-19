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

        #region Index e Instruções
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
        #endregion

        #region Parte Corpo
        public ActionResult ParteCorpoEspecial(int idAtendimento)
        {
            if (VerificaLogado() == true)
            {
                AtendimentoRepository atendimentoRepository = new AtendimentoRepository();
                ViewBag.Atendimento = atendimentoRepository.ObterPeloId(idAtendimento);
                return View();
            }
            else
            {
                return Redirect("/login");
            }
        }

        //Obtem os sintomas para preencher na modal
        [HttpGet]
        public JsonResult ObterSintomaParte(int id)
        {
            SintomaRepository sintomaRepository = new SintomaRepository();
            List<Sintoma> ListaSelect = sintomaRepository.ObterTodosPeloCorpo(id);
            List<object> ListaRetorno = new List<object>();
            foreach (Sintoma sintoma in ListaSelect)
            {
                ListaRetorno.Add(new
                {
                    id = sintoma.Id,
                    text = sintoma.Nome,
                });
            }
            var resultado = new
            {
                results = ListaRetorno
            };

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InserirSintoma(int idSintoma)
        {
            return null;
        }

        #endregion
        
        #region Paciente

        //Json para buscar e lista o nome do(s) paciente(s)
        [HttpGet]
        public JsonResult ObterPeloNome(string nome)
        {
            PacienteRepository pacienteRepository = new PacienteRepository();
            var pessoas = pacienteRepository.ObterPeloNome(nome);
            var result = new { data = pessoas };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        // É feito a listagem de pacientes e entao o usuario seleciona um, redurecionado para este controller que irá inserir um atendimento
        [HttpGet]
        public ActionResult InserirAtendimento(int idPaciente)
        {
            if (VerificaLogado() == true)
            {

                AtendimentoRepository atendimentoRepository = new AtendimentoRepository();
                Atendimento atendimento = new Atendimento();
                atendimento.IdFuncionario = Convert.ToInt32(Session["usuarioLogadoId"]);
                atendimento.IdPaciente = idPaciente;
                atendimento.DataAtendimento = DateTime.Now;
                FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                Funcionario funcionario = funcionarioRepository.ObterPeloId(Convert.ToInt32(Session["usuarioLogadoId"]));
                atendimento.IdPosto = funcionario.IdPosto;
                atendimentoRepository.Inserir(atendimento);
                return RedirectToAction("ParteCorpoEspecial");
            }
            else
            {
                return Redirect("/login");
            }
        }

        //Insere um novo paciente e cria um atendimento
        public ActionResult InserirPaciente(Paciente paciente)
        {
            if (VerificaLogado() == true)
            {
                FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                Funcionario funcionario = funcionarioRepository.ObterPeloId(Convert.ToInt32(Session["usuarioLogadoId"]));
                paciente.IdPosto = funcionario.IdPosto;
                paciente.RegistroAtivo = true;
                pacienteRepository.Inserir(paciente);

                AtendimentoRepository atendimentoRepository = new AtendimentoRepository();
                Atendimento atendimento = new Atendimento();
                atendimento.IdFuncionario = Convert.ToInt32(Session["usuarioLogadoId"]);
                atendimento.IdPaciente = paciente.Id;
                atendimento.DataAtendimento = DateTime.Now;
                atendimento.IdPosto = funcionario.IdPosto;
                atendimentoRepository.Inserir(atendimento);
                return Redirect("/atendimentoespecial/ParteCorpoEspecial?idAtendimento=" + atendimento.Id);
            }
            else
            {
                return Redirect("/login");

            }
        }

        #region Telas
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

        #endregion

        #endregion
    }
}