using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace PullList.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (WebSecurity.IsAuthenticated)
            {
                return RedirectToAction("/", "PullList");
            }

            return View();
        }

    }
}
