using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace Katalog_v_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Main()
        {
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Main", "Home");
        }
    }
}