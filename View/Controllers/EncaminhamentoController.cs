using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    [Route("encaminhamento/")]
    public class EncaminhamentoController : Controller
    {
        EncaminhamentoRepository repository;

        public EncaminhamentoController()
        {
            repository = new EncaminhamentoRepository();
        }

        public ActionResult Index()
        {
            List<Encaminhamento> encaminhamentos = repository.ObterTodosPeloStatus(0);
            ViewBag.Encaminhamentos = encaminhamentos;
            return View();
        }
        
        //Apagar
        #region Apagar
        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("index");
        }
#endregion
        
        //Alterar
        #region Editar
        public ActionResult Update(Encaminhamento encaminhamento)
        {
            repository.Alterar(encaminhamento);
            return RedirectToAction("index");
        }

        public ActionResult Alterar(int id)
        {
            var encaminhamento = repository.ObterPeloId(id);
            if (encaminhamento == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Encaminhamento = encaminhamento;
            PostoRepository repositoryPosto = new PostoRepository();
            ViewBag.Postos = repositoryPosto.ObterTodos();
            return View();
        }

        #endregion

        //Inserir
        #region Inserir
        public ActionResult Cadastrar()
        {
            PostoRepository repositoryPosto = new PostoRepository();
            ViewBag.Postos = repositoryPosto.ObterTodos();
            return View();
        }

        public ActionResult Inserir(Encaminhamento encaminhamento)
        {
            encaminhamento.Status = 0;
            int id = repository.Inserir(encaminhamento);
            return RedirectToAction("index");
        }

        #endregion

    }
}