using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class InstrucoesController : Controller
    {
        //Verificações do login
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

        public ActionResult Index()
        {
            if (VerificaLogado() == false)
            {
                return Redirect("/login");
            }
            FuncionarioRepository repository = new FuncionarioRepository();
            ViewBag.Funcionario = repository.ObterPeloId(Convert.ToInt32(Session["usuarioLogadoId"]));
            return View();
        }

        public ActionResult InstrucaoHaitiano()
        {
            if (VerificaLogado() == false)
            {
                return Redirect("/login");
            }
            FuncionarioRepository repository = new FuncionarioRepository();
            ViewBag.Funcionario = repository.ObterPeloId(Convert.ToInt32(Session["usuarioLogadoId"]));
            return View();
        }
    }


}