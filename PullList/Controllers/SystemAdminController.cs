using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PullList.Models;

namespace PullList.Controllers
{
    [Authorize]
    public class SystemAdminController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Stores()
        {
            List<Store> stores = db.Stores.ToList();

            return View(stores);
        }

        public ActionResult AddStore()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStore(Store model)
        {
            if(ModelState.IsValid)
            {
                db.Stores.Add(model);
                db.SaveChanges();
                return RedirectToAction("Stores");
            }

            return View(model);
        }

        public ActionResult EditStore(int id)
        {
            Store store = db.Stores.FirstOrDefault(s => s.Id == id);

            return View(store);
        }

        [HttpPost]
        public ActionResult EditStore(Store model)
        {
            Store store = db.Stores.Where(s => s.Id == model.Id).FirstOrDefault();

            if (store != null)
            {
                store.Active = model.Active;
                store.Name = model.Name;
                store.Address = model.Address;
                store.Email = model.Email;
                store.Phone = model.Phone;
                db.SaveChanges();
                return RedirectToAction("Stores");
            }

            return View(model);
        }
    }
}
