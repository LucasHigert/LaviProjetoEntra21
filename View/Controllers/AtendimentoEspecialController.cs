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

        static string lingua = "";

        public ActionResult InstrucoesEspecial(string lang)
        {
            if (VerificaLogado() == true)
            {
                lingua = lang;
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

        [HttpPost]
        public JsonResult Apagar(int idSintoma, int idAtendimento)
        {
            AtendimentoParteCorpoSintomaRepository repository = new AtendimentoParteCorpoSintomaRepository();
            var resultado = repository.Apagar(idSintoma, idAtendimento);
            var retorno = new { results = resultado };
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ParteCorpoEspecial(int idAtendimento)
        {
            if (VerificaLogado() == true)
            {
                AtendimentoRepository atendimentoRepository = new AtendimentoRepository();
                ViewBag.Atendimento = atendimentoRepository.ObterPeloId(idAtendimento);
                PacienteRepository pacienteRepository = new PacienteRepository();
                Paciente paciente = pacienteRepository.ObterPeloId(idAtendimento);
                if (paciente.Lingua == 2)
                {
                    Change("fr-HT");
                }
                else
                {
                    Change("fr-FR");
                }
                return View();
            }
            else
            {
                return Redirect("/login");
            }
        }

        [HttpGet]
        public JsonResult ObterSintomaAtendimento(int idAtendimento)
        {
            AtendimentoParteCorpoSintomaRepository repository = new AtendimentoParteCorpoSintomaRepository();
            List<AtendimentoParteCorpoSintoma> listaRepository = repository.ObterPeloIdAtentimento(idAtendimento);
            List<object> listaSintoma = new List<object>();
            for (int i = 0; i < listaRepository.Count; i++)
            {
                if (lingua == "fr-HT")
                {

                    listaSintoma.Add(new { Nome = listaRepository[i].Sintoma.TraducaoCriolo, id = listaRepository[i].IdSintoma });
                }
                else
                {
                    listaSintoma.Add(new { Nome = listaRepository[i].Sintoma.TraducaoFrances, id = listaRepository[i].IdSintoma });
                }
            }

            var result = new { data = listaSintoma };
            return Json(result, JsonRequestBehavior.AllowGet);
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
                if (lingua == "fr-HT")
                {

                    ListaRetorno.Add(new
                    {
                        id = sintoma.Id,
                        text = sintoma.TraducaoCriolo,
                    });
                }
                else
                {
                    ListaRetorno.Add(new
                    {
                        id = sintoma.Id,
                        text = sintoma.TraducaoFrances,
                    });
                }
            }
            var resultado = new
            {
                results = ListaRetorno
            };

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InserirSintoma(int idAtendimento, int idSintoma, int nivelDor)
        {
            AtendimentoParteCorpoSintomaRepository repository = new AtendimentoParteCorpoSintomaRepository();
            AtendimentoParteCorpoSintoma sintoma = new AtendimentoParteCorpoSintoma();
            sintoma.IdAtendimento = idAtendimento;
            sintoma.IdSintoma = idSintoma;
            sintoma.NiverDor = nivelDor;
            int id = repository.Inserir(sintoma);
            var resultado = new { id = id };
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region Paciente

        //Json para buscar e lista o nome do(s) paciente(s)
        [HttpGet]
        public JsonResult ObterPeloNome(string nome)
        {
            PacienteRepository pacienteRepository = new PacienteRepository();
            FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
            Funcionario funcionario = funcionarioRepository.ObterPeloId(Convert.ToInt32(Session["usuarioLogadoId"]));
            var pessoas = pacienteRepository.ObterEstrangeiroNome(nome,funcionario.IdPosto);
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
                if (Session["usuarioLogadoPermissao"].ToString() == "1")
                {
                    atendimento.Status = 1;

                }
                else if (Session["usuarioLogadoPermissao"].ToString() == "4")
                {
                    atendimento.Status = 2;
                }
                else
                {
                    atendimento.Status = (Convert.ToInt32(Session["usuarioLogadoPermissao"]) - 1);
                }
                FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                Funcionario funcionario = funcionarioRepository.ObterPeloId(Convert.ToInt32(Session["usuarioLogadoId"]));
                atendimento.IdPosto = funcionario.IdPosto;
                atendimentoRepository.Inserir(atendimento);
                if (Session["usuarioLogadoPermissao"].ToString() == "1")
                {
                    return Redirect("/atendimentoespecial/FinalizaCadastro?id=" + idPaciente);
                }
                else
                {
                    return Redirect("/atendimentoespecial/ParteCorpoEspecial?idAtendimento=" + atendimento.Id);
                }
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
                string cookie = Request.Cookies["Language"].Value;
                if (cookie == "fr-HT")
                {
                    paciente.Lingua = 1;
                }
                else if (cookie == "fr-FR")
                {
                    paciente.Lingua = 2;
                }
                else
                {
                    paciente.Lingua = 0;
                }
                paciente.RegistroAtivo = true;
                pacienteRepository.Inserir(paciente);

                AtendimentoRepository atendimentoRepository = new AtendimentoRepository();
                Atendimento atendimento = new Atendimento();
                atendimento.IdFuncionario = Convert.ToInt32(Session["usuarioLogadoId"]);
                atendimento.IdPaciente = paciente.Id;
                atendimento.DataAtendimento = DateTime.Now;
                atendimento.IdPosto = funcionario.IdPosto;
                if (Session["usuarioLogadoPermissao"].ToString() == "1")
                {
                    atendimento.Status = 1;

                }
                else if(Session["usuarioLogadoPermissao"].ToString() == "4")
                {
                    atendimento.Status = 2;
                }else
                {
                    atendimento.Status = (Convert.ToInt32(Session["usuarioLogadoPermissao"]) - 1);
                }

                atendimentoRepository.Inserir(atendimento);

                if (Session["usuarioLogadoPermissao"].ToString() == "1")
                {
                    return Redirect("/atendimentoespecial/FinalizaCadastro?id=" + paciente.Id);
                }
                else
                {

                    return Redirect("/atendimentoespecial/ParteCorpoEspecial?idAtendimento=" + atendimento.Id);
                }
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

        public ActionResult FinalizaCadastro(int id)
        {
            ViewBag.Atendimento = id;
            return View();
        }

        [HttpPost]
        public ActionResult InserirObservacao(int id, string observacao)
        {
            if (observacao == null)
            {
                observacao = "";
            }
            AtendimentoRepository atendimentoRepository = new AtendimentoRepository();
            Atendimento atendimentoOriginal = atendimentoRepository.ObterPeloId(id);
            atendimentoOriginal.Observacao = observacao;
            atendimentoRepository.Alerar(atendimentoOriginal);
            return Redirect("/atendimento");
        }
        #endregion

        #endregion
    }
}