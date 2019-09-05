using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class PacienteController : Controller
    {

        // GET: Cidade
        public PacienteRepository repository;

        public PacienteController()
        {
            repository = new PacienteRepository();
        }

        public ActionResult Index()
        {
            ////var cidades = repository.ObterTodos(cidades);
            //List<Cidade> cidades = repository.ObterTodos();
            //return View();

            List<Paciente> pacientes = repository.ObterTodos();
            ViewBag.Pacientes = pacientes;
            return View();

        }

        public ActionResult Cadastro()
        {
            //cidade.RegistroAtivo = true;
            //var id = repository.Inserir(cidade);
            //var resultado = new { id = id };
            //return View("cadastro");

            //Puxa Info dos estados
            PostoRepository postoRepository = new PostoRepository();
            //List<Posto> postos = postoRepository.ObterTodos();
            ViewBag.Postos = postoRepository.ObterTodos();

            return View();
        }

        public ActionResult Inserir(Paciente paciente)
        {
            int id = repository.Inserir(paciente);
            return RedirectToAction("Index");
            //, new { id = id });
        }

        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id, int idPosto, string nome,int idade,string cpf, string rne,string passaporte, string telefone, string endereco, string cep, bool sexo,double altura, double peso,string pressao )
        {
            Paciente paciente = new Paciente();
            paciente.Id = id;
            paciente.Nome = nome;
            paciente.Idade = idade;
            paciente.Cpf = cpf;
            paciente.Rne = rne;
            paciente.Passaporte = passaporte;
            paciente.Endereco = endereco;
            paciente.Telefone = telefone;
            paciente.Cep = cep;
            paciente.Sexo = sexo;
            paciente.Altura = altura;
            paciente.Peso = peso;
            paciente.Pressao = pressao;
            paciente.Posto = new Posto();
            paciente.Posto.Id = idPosto;

            repository.Alterar(paciente);
            return RedirectToAction("Index");
        }

        public ActionResult Alterar(int id)
        {
            Paciente paciente = new Paciente();
            paciente = repository.ObterPeloId(id);
            ViewBag.Paciente = paciente;
            PostoRepository postoRepository = new PostoRepository();
            ViewBag.Estados = postoRepository.ObterTodos();
            return View();
        }

        public ActionResult ObterTodos()
        {
            List<Paciente> pacientes = repository.ObterTodos();
            ViewBag.Pacientes = pacientes;
            return View();
        }
    }
}