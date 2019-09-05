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
            List<Paciente> pacientes = repository.ObterTodos();
            ViewBag.Pacientes = pacientes;
            return View();
        }

        public ActionResult Cadastro()
        {
            

            //Puxa Info dos estados
            PostoRepository postoRepository = new PostoRepository();
            List<Posto> postos = postoRepository.ObterTodos();
            ViewBag.Postos = postos;    

            return View();
        }

        public ActionResult Inserir(Paciente paciente)
        {
            int id = repository.Inserir(paciente);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id, int idPosto, string nome)
        {
            Paciente paciente = new Paciente();
            paciente.Id = id;
            paciente.Nome = nome;
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

       
    }
}