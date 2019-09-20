using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public JsonResult Index(string idioma = "pt")
        {
            var path = ControllerContext.HttpContext.Server.MapPath($"~/Scripts/Traducao/{idioma}.json");
            using(StreamReader sr = new StreamReader(path, Encoding.Default, true))
            {
                string json = sr.ReadToEnd();
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }
    }
}