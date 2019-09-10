using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class FuncionarioController : Controller
    {
        private FuncionarioRepository repository;

        public FuncionarioController()
        {
            repository = new FuncionarioRepository();
        }

        public ActionResult Index()
        {
            ViewBag.Funcionarios = repository.ObterTodos();
            return View();
        }

        //Alterar
        #region Alterar
        public ActionResult Update(Funcionario funcionario)
        {
            funcionario.RegistroAtivo = true;
            repository.Alterar(funcionario);
            return RedirectToAction("index");
        }

        public ActionResult Alterar(int id)
        {
            var funcionario = repository.ObterPeloId(id);
            if (funcionario == null)
            {
                return RedirectToAction("Index");
            }
            PostoRepository repositoryPosto = new PostoRepository();
            ViewBag.Postos = repositoryPosto.ObterTodos();
            CargoRepository repositoryCargo = new CargoRepository();
            ViewBag.Cargos = repositoryCargo.ObterTodos();
            ViewBag.Funcionario = funcionario;
            return View();
        }

        #endregion

        //Apagar
        #region Apagar
        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("index");
        }
        #endregion

        //Inserir
        #region Cadastro
        public ActionResult Inserir(Funcionario funcionario)
        {
            funcionario.RegistroAtivo = true;
            repository.Inserir(funcionario);
            return RedirectToAction("index");
        }


        public ActionResult Cadastrar()
        {
            PostoRepository repositoryPosto = new PostoRepository();
            ViewBag.Postos = repositoryPosto.ObterTodos();
            CargoRepository repositoryCargo = new CargoRepository();
            ViewBag.Cargos = repositoryCargo.ObterTodos();
            return View();
        }

        #endregion
    }
}