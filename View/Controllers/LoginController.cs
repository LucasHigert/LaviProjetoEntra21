using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sair()
        {
            Session["usuarioLogadoId"] = null;
            Session["usuarioLogadoCargo"] = null;
            return RedirectToAction("index");
        }

        public ActionResult VerificaLogin(string login, string senha)
        {
            FuncionarioRepository repository = new FuncionarioRepository();
            Funcionario funcionario = repository.BuscarFuncionario(login, senha);
            if (funcionario != null)
            {
                Session["usuarioLogadoId"] = funcionario.Id;
                Session["usuarioLogadoCargo"] = funcionario.Cargo.Nome;
                return Redirect("/instrucoes/index");
            }
            else
            {
               return RedirectToAction("index");
            }
        }

        public ActionResult SemPermissao()
        {
            return View();
        }
    }
}