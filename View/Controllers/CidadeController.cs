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
            if (Session["usuarioLogadoCargo"] == null)
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

            if ((Session["usuarioLogadoCargo"].ToString() == "Atendente")||(Session["usuarioLogadoCargo"].ToString() == "Medico"))
            {
                return Redirect("/login/sempermissao");
            }
            else
            {
                return View();
            }
        }

        #endregion


        //Cadastro
        #region Cadastro
        public ActionResult Cadastro()
        {
            //Puxa Info dos estados
            EstadoRepository estadoRepository = new EstadoRepository();
            ViewBag.Estados = estadoRepository.ObterTodos(); ;

            return VerificaPermisssao();
        }

        public ActionResult Inserir(Cidade cidade)
        {
            int id = repository.Inserir(cidade);
            return VerificaPermisssao();
        }

        #endregion

        //Apagar
        #region Apagar
        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return VerificaPermisssao();
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
            return VerificaPermisssao();
        }

        public ActionResult Alterar(int id)
        {
            ViewBag.Cidade = repository.ObterPeloId(id);
            EstadoRepository estadoRepository = new EstadoRepository();
            ViewBag.Estados = estadoRepository.ObterTodos();
            return VerificaPermisssao();
        }
        #endregion
    }
}