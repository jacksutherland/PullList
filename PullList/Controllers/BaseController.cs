using System.Web.Mvc;
using System.Linq;
using WebMatrix.WebData;
using PullList.DataAccess;
using PullList.Models;
using System.Collections.Generic;

namespace PullList.Controllers
{
    public class BaseController : Controller
    {
        protected DataContext db = new DataContext();
        protected List<Subscription> Subscriptions { get; set; }

        public NavSection NavSelected { get; set; }
        public SideNav SideNav { get; set; }        
        
        private Store _store { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (WebSecurity.IsAuthenticated)
            {
                int userId = WebSecurity.CurrentUserId;
                ViewBag.Employee = db.Employees.FirstOrDefault(e => e.UserId == userId);

                Subscriptions = db.Subscriptions.Where(s => s.UserId == userId && s.Active && s.Store.Active).ToList();
                if(Subscriptions.Count() > 0)
                {
                    ViewBag.SubscriptionId = Subscriptions.First().Id;
                }
            }

            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewBag.NavSelected = this.NavSelected;
            ViewBag.SideNav = this.SideNav;

            if (WebSecurity.IsAuthenticated)
            {
                ViewBag.UserName = WebSecurity.CurrentUserName;
            }

            base.OnActionExecuted(filterContext);
        }

        protected string SerializePartial(string partial, object model)
        {
            ViewData.Model = model;

            string html;
            System.IO.StringWriter sw = new System.IO.StringWriter();
            ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, partial);
            ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
            viewResult.View.Render(viewContext, sw);

            html = sw.GetStringBuilder().ToString();

            return html;
        }

        public Store GetCurrentStore()
        {
            if (_store == null)
            {
                _store = db.Employees.FirstOrDefault(e => e.UserId == WebSecurity.CurrentUserId).Store;
            }
            return _store;
        }
    }
}
