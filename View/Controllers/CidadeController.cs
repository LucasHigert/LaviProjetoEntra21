using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class CidadeController : Controller
    {
        // GET: Cidade
        private CidadeRepository repository;

        public CidadeController()
        {
            repository = new CidadeRepository();
        }

        public ActionResult Index()
        {
            ////var cidades = repository.ObterTodos(cidades);
            //List<Cidade> cidades = repository.ObterTodos();
            //return View();

            List<Cidade> cidades = repository.ObterTodos();
            ViewBag.Cidades = cidades;
            return View();
        }

        public ActionResult Cadastro()
        {
            //cidade.RegistroAtivo = true;
            //var id = repository.Inserir(cidade);
            //var resultado = new { id = id };
            //return View("cadastro");

            //Puxa Info dos estados
            EstadoRepository estadoRepository = new EstadoRepository();
            List<Estado> estados = estadoRepository.ObterTodos();
            ViewBag.Estados = estados;

            return View();
        }

        public ActionResult Inserir(Cidade cidade)
        {
            int id = repository.Inserir(cidade);
            return RedirectToAction("Index");
            //, new { id = id });
        }

        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id, int idEstado, string nome)
        {
            Cidade cidade = new Cidade();
            cidade.Id = id;
            cidade.Nome = nome;
            cidade.Estado = new Estado();
            cidade.Estado.Id = idEstado;

            repository.Alterar(cidade);
            return RedirectToAction("Index");
        }

        public ActionResult Alterar(int id)
        {
            Cidade cidade = new Cidade();
            cidade = repository.ObterPeloId(id);
            ViewBag.Cidade = cidade;
            EstadoRepository estadoRepository = new EstadoRepository();
            ViewBag.Estados = estadoRepository.ObterTodos();
            return View();
        }

        public ActionResult ObterTodos()
        {
            List<Cidade> cidades = repository.ObterTodos();
            ViewBag.Cidades = cidades;
            return View();
        }
    }
}