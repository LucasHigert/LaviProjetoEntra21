using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ParteCorpoController : Controller
    {
        // GET: ParteCorpo
        private ParteCorpoRepository repository;

        public ParteCorpoController()
        {
            repository = new ParteCorpoRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

     
    }
}