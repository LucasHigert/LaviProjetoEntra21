using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    [Route("sintoma/")]
    public class SintomaController : Controller
    {
        SintomaRepository repositorio;

        public SintomaController()
        {
            repositorio = new SintomaRepository();
        }

        public ActionResult Index()
        {
            List<Sintoma> sintomas = repositorio.ObterTodos();
            ViewBag.Sintomas = sintomas;
            return View();
        }

        //Apagar
        #region Apagar
        public ActionResult Apagar(int id)
        {
            var apagou = repositorio.Apagar(id);
            return RedirectToAction("index");
        }
        #endregion

        //Cadastro
        #region Cadastro
        [HttpPost]
        public ActionResult Inserir(Sintoma sintoma)
        {
            sintoma.RegistroAtivo = true;
            bool id = repositorio.Inserir(sintoma);
            if (id == true)
            {
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("cadastro");
            }

        }

        public ActionResult Cadastrar()
        {
            ParteCorpoRepository repositorioParteCorpo = new ParteCorpoRepository();
            ViewBag.PartesCorpo = repositorioParteCorpo.ObterTodos();
            return View();
        }

        #endregion

        //Editar
        #region Editar
        public ActionResult Update(Sintoma sintoma)
        {
            bool retorno = repositorio.Alterar(sintoma);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            var sintoma = repositorio.ObterPeloId(id);
            if (sintoma == null)
            {
                return RedirectToAction("Index");
            }
            ParteCorpoRepository repositorioParteCorpo = new ParteCorpoRepository();
            ViewBag.PartesCorpo = repositorioParteCorpo.ObterTodos();
            ViewBag.Sintoma = sintoma;
            return View();
        }
        #endregion
    }
}