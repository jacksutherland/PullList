using PullList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace PullList.Controllers
{
    public class StoreController : BaseController
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            NavSelected = NavSection.Employee;
            base.SideNav = Models.SideNav.Store;
            base.OnActionExecuted(filterContext);
        }

        public ActionResult Index()
        {
            return RedirectToAction("PullLists");
        }

        public ActionResult PullLists(PullListFilter id = PullListFilter.Title)
        {
            int storeId = GetCurrentStore().Id;
            StorePullVM model = new StorePullVM()
            {
                Filter = id
            };

            switch (model.Filter)
            {
                case PullListFilter.Title:
                    IQueryable<Pull> pulls = db.Pulls.Where(p => p.Subscription.StoreId == storeId);
                    model.Series = pulls.Select(p => p.Series).Distinct().OrderBy(s => s.Title).ToList();
                    model.Series.ForEach(s =>
                    {
                        s.Count = pulls.Count(p => p.SeriesId == s.Id);
                    });
                    break;
            }

            return View(model);
        }
    }
}
