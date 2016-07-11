using PullList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PullList.Controllers
{
    public class AboutController : BaseController
    {
        public ActionResult Index()
        {
            NavSelected = NavSection.About;
            return View();
        }

    }
}
