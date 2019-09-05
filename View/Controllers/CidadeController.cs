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

            List<Cidade> cidades = repository.ObterTodos();
            ViewBag.Cidades = cidades;
            return View();

        }

        //Cadastro
        #region Cadastro
        public ActionResult Cadastro()
        {
           
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
        }

        #endregion

        //Apagar
        #region Apagar
        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
        }

        #endregion

        //Alterar
        #region Alterar
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
            ViewBag.Cidade = repository.ObterPeloId(id);
            EstadoRepository estadoRepository = new EstadoRepository();
            ViewBag.Estados = estadoRepository.ObterTodos();
            return View();
        }
        #endregion
    }
}