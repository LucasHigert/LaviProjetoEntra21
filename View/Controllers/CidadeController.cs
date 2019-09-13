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
            if (VerificaLogado() == true)
            {

                return View();
            }
            else
            {
                return Redirect("/login");
            }

        }

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

        private bool VerificaPermisssao()
        {
            if ((Session["usuarioLogadoPermissao"].ToString() == "4"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        //Cadastro
        #region Cadastro
        public ActionResult Cadastro()
        {
            if (VerificaLogado() == true)
            {
                if (VerificaPermisssao() == true)
                {
                    //Puxa Info dos estados
                    EstadoRepository estadoRepository = new EstadoRepository();
                    ViewBag.Estados = estadoRepository.ObterTodos(); ;

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

        public ActionResult Inserir(Cidade cidade)
        {
            if (VerificaLogado() == true)
            {
                if (VerificaPermisssao() == true)
                {
                    int id = repository.Inserir(cidade);

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
        #region Alterar
        public ActionResult Update(int id, int idEstado, string nome)
        {
            if (VerificaLogado() == true)
            {
                if (VerificaPermisssao() == true)
                {
                    Cidade cidade = new Cidade();
                    cidade.Id = id;
                    cidade.Nome = nome;
                    cidade.Estado = new Estado();
                    cidade.Estado.Id = idEstado;

                    repository.Alterar(cidade);
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
                if(VerificaPermisssao() == true)
                {
                    ViewBag.Cidade = repository.ObterPeloId(id);
                    EstadoRepository estadoRepository = new EstadoRepository();
                    ViewBag.Estados = estadoRepository.ObterTodos();

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
    }
}