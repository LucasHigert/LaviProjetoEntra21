using Model;
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

        
        public ActionResult VerificaLogin(string login, string senha)
        {
            
            return Redirect("/instrucoes/index");
        }
    }
}