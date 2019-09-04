using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    [Route("partecorpo/")]
    public class ParteCorpoController : Controller
    {
        ParteCorpoRepository repositorio;

        public ParteCorpoController()
        {
            repositorio = new ParteCorpoRepository();
        }

        public ActionResult Index()
        {
            List<ParteCorpo> parteCorpos = repositorio.ObterTodos();
            ViewBag.PartesCorpo = parteCorpos;
            return View();
        }

        //Inserir
        #region Inserir

        [HttpPost, Route("inserir")]

        public ActionResult Inserir(ParteCorpo parteCorpo)
        {
            parteCorpo.RegistroAtivo = true;
            bool cadastrado = repositorio.Inserir(parteCorpo);
            if (cadastrado == true)
            {
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("Cadastrar");
            }
        }
        
        public ActionResult Cadastrar()
        {
            return View();
        }
        
        #endregion

        //Editar
        #region Editar

        [HttpPost, Route("editar")]
        public ActionResult Update(ParteCorpo parteCorpo)
        {
            bool retorno = repositorio.Alterar(parteCorpo);
            if (retorno == true)
            {
            return RedirectToAction("index");

            }
            else
            {
                return RedirectToAction("cadastrar");
            }
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            var partecorpo = repositorio.ObterPeloId(id);
            if (partecorpo == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.ParteCorpo = partecorpo;
            return View();
        }

        #endregion


        //Apagar
        #region Apagar

        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            var apagou = repositorio.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        
        #endregion

    }
}