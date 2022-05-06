using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prvamvc.Controllers
{
    public class helloworldController : Controller
    {
        // GET: helloworld
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pozdravljen(string ime, int st=3)
        {
            ViewBag.Message = "Pozdravljen " + ime;
            ViewBag.Num = st;
            return View();
        }
    }
}