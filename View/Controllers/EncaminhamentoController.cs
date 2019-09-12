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

        private bool VerificaPermisssao()
        {
            if ((Session["usuarioLogadoPermissao"].ToString() == "1") || (Session["usuarioLogadoPermissao"].ToString() == "2") ||
                (Session["usuarioLogadoPermissao"].ToString() == "3"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

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
            if (VerificaLogado() == true)
            {
                if (VerificaPermisssao() == true)
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

        //Alterar
        #region Editar
        public ActionResult Update(Encaminhamento encaminhamento)
        {
            if (VerificaLogado() == true)
            {
                if (VerificaPermisssao() == true)
                {

                    repository.Alterar(encaminhamento);
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
                if (VerificaPermisssao() == true)
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
                else
                {
                    return Redirect("/login/sempermisssao");
                }
            }
            else
            {
                return Redirect("/login");
            }
        }

        #endregion

        //Inserir
        #region Inserir
        public ActionResult Cadastrar()
        {
            if (VerificaLogado() == true)
            {
                if (VerificaPermisssao() == true)
                {

                    PostoRepository repositoryPosto = new PostoRepository();
                    ViewBag.Postos = repositoryPosto.ObterTodos();
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

        public ActionResult Inserir(Encaminhamento encaminhamento)
        {
            if (VerificaLogado() == true)
            {
                if (VerificaPermisssao() == true)
                {

                    encaminhamento.Status = 0;
                    int id = repository.Inserir(encaminhamento);
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

    }
}