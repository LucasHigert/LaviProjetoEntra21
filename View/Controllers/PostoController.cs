using Repository;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class PostoController : Controller
    {
        // GET: Posto

        private PostoRepository repository;

        public PostoController()
        {
            repository = new PostoRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("posto/")]
        public JsonResult ObterPeloId(int id)
        {
            var posto = repository.ObterPeloId(id);
            return Json(posto, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObterTodos()
        {
            var postos = repository.ObterTodos();
            var resultado = new { data = postos };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}