using Model;
using Repository;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class PacienteController : Controller
    {
        public PacienteRepository repository;

        public PacienteController()
        {
            repository = new PacienteRepository();
        }

        public ActionResult Index()
        {
            if (VerificaLogado() == true)
            {
                if (Session["usuarioLogadoPermissao"].ToString() != "4")
                {
                    FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                    Funcionario funcionario = funcionarioRepository.ObterPeloId(Convert.ToInt32(Session["usuarioLogadoId"]));
                    List<Paciente> pacientes = repository.ObterTodosPosto(funcionario.IdPosto);
                    ViewBag.Pacientes = pacientes;
                    return View();
                }
                else
                {
                    List<Paciente> pacientes = repository.ObterTodos();
                    ViewBag.Pacientes = pacientes;
                    return View();
                }
            }
            else
            {
                return Redirect("/login");
            }
        }

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


        #region JQuery
        public JsonResult ObterPeloNome(string nome)
        {
            PacienteRepository pacienteRepository = new PacienteRepository();
            FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
            Funcionario funcionario = funcionarioRepository.ObterPeloId(Convert.ToInt32(Session["usuarioLogadoId"]));
            var resultado = pacienteRepository.ObterPeloNome(nome, funcionario.IdPosto);
            var result = new { data = resultado };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
     
        
        // GET: Cidade
        public JsonResult ObterPeloId(int id)
        {
            PacienteRepository pacienteRepository = new PacienteRepository();
            Paciente paciente = pacienteRepository.ObterPeloId(id);
            var result = new { data = paciente.Nome };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        //Inserir
        #region Inserir
        public ActionResult Cadastro()
        {

            if (VerificaLogado() == true)
            {

                //Puxa Info dos estados
                PostoRepository postoRepository = new PostoRepository();
                //List<Posto> postos = postoRepository.ObterTodos();
                ViewBag.Postos = postoRepository.ObterTodos();
                return View();
            }
            else
            {
                return Redirect("/login");
            }
        }

        public ActionResult Inserir(Paciente paciente)
        {
            if (VerificaLogado() == true)
            {

                FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                Funcionario funcionario = funcionarioRepository.ObterPeloId(Convert.ToInt32(Session["usuarioLogadoID"]));
                paciente.IdPosto = funcionario.IdPosto;
                repository.Inserir(paciente);
                return RedirectToAction("Index");
            }
            else
            {
                return Redirect("/login");

            }
        }
        #endregion


        #region Documentos
        public ActionResult Documento()
        {
            if (Session["usuarioLogadoPermissao"].ToString() == "1")
            {
                return Redirect("/login/sempermissao");
            }
            else
            {
                return View();

            }

        }

        //obtem o paciente pelo nome
        //[HttpGet]
        //public JsonResult ObterPeloNome(string nome)
        //{
        //    PacienteRepository pacienteRepository = new PacienteRepository();
        //    var pessoas = pacienteRepository.ObterPeloNome(nome);
        //    var result = new { data = pessoas };
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public JsonResult ObterPeloPaciente(int id)
        {
            AtendimentoRepository atendimentoRepository = new AtendimentoRepository();
            List<Atendimento> lista = atendimentoRepository.ObterTodosPaciente(id);
            var result = new { data = lista };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //Apagar
        #region Apagar
        public ActionResult Apagar(int id)
        {
            if (VerificaLogado() == true)
            {
                repository.Apagar(id);
                return RedirectToAction("Index");
            }
            else
            {
                return Redirect("/login");
            }
        }
        #endregion

        //Alterar
        #region Alterar
        //public ActionResult Update(int id, int idPosto, string nome, int idade, string cpf, string rne, string passaporte, string telefone, string endereco, string cep, bool sexo, double altura, double peso, string pressao, double temperatura)
        public ActionResult Update(Paciente paciente)
        {
            if (VerificaLogado() == true)
            {
                var alterou = repository.Alterar(paciente);
                repository.Alterar(paciente);
                return RedirectToAction("Index");
            }
            else
            {
                return Redirect("/login");

            }

        }

        public ActionResult Alterar(int id)
        {
            if (VerificaLogado() == true)
            {
                Paciente paciente = new Paciente();
                paciente = repository.ObterPeloId(id);
                ViewBag.Paciente = paciente;
                PostoRepository postoRepository = new PostoRepository();
                ViewBag.Postos = postoRepository.ObterTodos();
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