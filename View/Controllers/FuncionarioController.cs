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

        private ActionResult VerificaPermisssao()
        {
            if (VerificaLogado() == false)
            {
                return Redirect("/login");
            }

            if ((Session["usuarioLogadoPermissao"].ToString() == "1") || (Session["usuarioLogadoPermissao"].ToString() == "2") ||
                (Session["usuarioLogadoPermissao"].ToString() == "3"))
            {
                return Redirect("/login/sempermissao");
            }
            else
            {
                return View();
            }
        }

        #endregion


        private FuncionarioRepository repository;

        public FuncionarioController()
        {
            repository = new FuncionarioRepository();
        }

        public ActionResult Index()
        {
            if (VerificaLogado() == true)
            {
                if (Session["usuarioLogadoPermissao"].ToString() != "4")
                {

                    Funcionario funcionario = repository.ObterPeloId(Convert.ToInt32(Session["usuarioLogadoId"]));
                    ViewBag.Funcionarios = repository.ObterFuncionariosPeloIdPosto(funcionario.IdPosto);
                    return View();
                }
                else
                {
                    ViewBag.Funcionarios = repository.ObterTodos();
                    return View();
                }
            }
            else
            {
                return Redirect("/login");
            }
        }

        //Alterar
        #region Alterar
        public ActionResult Update(Funcionario funcionario)
        {
            if (VerificaLogado() == true)
            {

                if ((Session["usuarioLogadoPermissao"].ToString() == "4") || (Session["usuarioLogadoId"].ToString() == funcionario.Id.ToString()))
                {
                    funcionario.RegistroAtivo = true;
                    repository.Alterar(funcionario);
                    return RedirectToAction("index");
                }
                else
                {
                    return Redirect("/login/sempermissao");
                }
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
                if ((Session["usuarioLogadoPermissao"].ToString() == "4") || (id.ToString() == Session["usuarioLogadoId"].ToString()))
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
                else
                {
                    return Redirect("/login/sempermissao");
                }
            }
            else
            {
                return Redirect("/login");
            }
        }

        #endregion

        //Apagar
        #region Apagar
        public ActionResult Apagar(int id)
        {
            if (VerificaLogado() == true)
            {
                if (Session["usuarioLogadoPermissao"].ToString() == "4")
                {
                    repository.Apagar(id);
                    return RedirectToAction("index");

                }
                else
                {
                    return Redirect("/login/sempermissao");
                }
            }
            else
            {
                return Redirect("/login");
            }
        }
        #endregion

        //Inserir
        #region Cadastro
        public ActionResult Inserir(Funcionario funcionario)
        {
            if (VerificaLogado() == true)
            {
                if (Session["usuarioLogadoPermissao"].ToString() == "4")
                {
                    funcionario.RegistroAtivo = true;
                    repository.Inserir(funcionario);
                    return RedirectToAction("index");

                }
                else
                {
                    return Redirect("/login/sempermissao");
                }
            }
            else
            {
                return Redirect("/login");
            }
        }


        public ActionResult Cadastrar()
        {
            PostoRepository repositoryPosto = new PostoRepository();
            ViewBag.Postos = repositoryPosto.ObterTodos();
            CargoRepository repositoryCargo = new CargoRepository();
            ViewBag.Cargos = repositoryCargo.ObterTodos();
            return VerificaPermisssao();
        }

        #endregion
    }
}