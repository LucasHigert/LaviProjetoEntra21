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


        // GET: Cidade
        public PacienteRepository repository;

        public PacienteController()
        {
            repository = new PacienteRepository();
        }

        public ActionResult Index()
        {
            if (VerificaLogado() == true)
            {
                List<Paciente> pacientes = repository.ObterTodos();
                ViewBag.Pacientes = pacientes;
                return View();
            }
            else
            {
                return Redirect("/login");
            }
        }

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
            return View();

        }

        //obtem o paciente pelo nome
        [HttpGet]
        public JsonResult ObterPeloNome(string nome)
        {
            PacienteRepository pacienteRepository = new PacienteRepository();
            var pessoas = pacienteRepository.ObterPeloNome(nome);
            var result = new { data = pessoas };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObterPeloPaciente(int id)
        {
            AtendimentoRepository atendimentoRepository = new AtendimentoRepository();
            List<Atendimento> lista = atendimentoRepository.ObterTodosPaciente(id);
            var result = new { data = lista};
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        //[HttpGet]
        //public JsonResult ObterPeloNome(string nome)
        //{
        //    PacienteRepository pacienteRepository = new PacienteRepository();
        //    FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        //    Funcionario funcionario = funcionarioRepository.ObterPeloId(Convert.ToInt32(Session["usuarioLogadoId"]));
        //    var resultado = pacienteRepository.ObterPeloNome(nome);
        //    var result = new { data = resultado };
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}


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

        //Aletar
        #region Alterar
        //public ActionResult Update(int id, int idPosto, string nome, int idade, string cpf, string rne, string passaporte, string telefone, string endereco, string cep, bool sexo, double altura, double peso, string pressao, double temperatura)
        public ActionResult Update(Paciente paciente)
        {
            if (VerificaLogado() == true)
            {
                var alterou = repository.Alterar(paciente);
                return RedirectToAction("index");
                //Paciente paciente = new Paciente();
                //paciente.Id = id;
                //paciente.Nome = nome;
                //paciente.Idade = idade;
                //paciente.Cpf = cpf;
                //paciente.Rne = rne;
                //paciente.Passaporte = passaporte;
                //paciente.Endereco = endereco;
                //paciente.Telefone = telefone;
                //paciente.Cep = cep;
                //paciente.Sexo = sexo;
                //paciente.Altura = altura;
                //paciente.Peso = peso;
                //paciente.Pressao = pressao;
                //paciente.Posto = new Posto();
                //paciente.Posto.Id = idPosto;
                //paciente.Temperatura = temperatura;

                //repository.Alterar(paciente);
                //return RedirectToAction("Index");
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