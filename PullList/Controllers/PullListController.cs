using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PullList.Models;
using WebMatrix.WebData;

namespace PullList.Controllers
{
    [Authorize]
    public class PullListController : BaseController
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            NavSelected = NavSection.PullList;
            base.OnActionExecuted(filterContext);
        }

        public ActionResult Index()
        {
            int? subscriptionId = null;
            int userId = WebSecurity.CurrentUserId;
            PullListVM model = new PullListVM();       

            if(Subscriptions.Count() > 0)
            {
                subscriptionId = Subscriptions.First().Id;
                if (subscriptionId.HasValue)
                {
                    model = GetPullListVM(subscriptionId.Value, Subscriptions);
                }
            }

            return View("Subscription", model);
        }

        public ActionResult GetSubscription(int subscription)
        {
            return RedirectToAction("Subscription", new { id = subscription });
        }

        public ActionResult Subscription(int id)
        {
            ViewBag.SubscriptionId = id;
            return View(GetPullListVM(id));
        }

        public PullListVM GetPullListVM(int id, List<Subscription> subscriptions = null)
        {
            int userId = WebSecurity.CurrentUserId;
            PullListVM model = new PullListVM()
            {
                SubscriptionId = id,
                //Subscriptions = subscriptions != null ? subscriptions : db.Subscriptions.Where(s => s.UserId == userId && s.Active && s.Store.Active).ToList()
                Subscriptions = subscriptions != null ? subscriptions : base.Subscriptions
            };

            model.StoreName = model.Subscriptions.FirstOrDefault(s => s.Id == model.SubscriptionId).Store.Name;

            if (model.SubscriptionId.HasValue)
            {
                model.Pulls = db.Pulls.Where(p => p.SubscriptionId == model.SubscriptionId.Value).OrderBy(p => p.Series.Title).ToList();
            }

            return model;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePull(int id, int subscription)
        {
            int userId = WebSecurity.CurrentUserId;
            Pull pull = db.Pulls.FirstOrDefault(p => p.Id == id && p.SubscriptionId == subscription && p.Subscription.UserId == userId);

            if(pull != null)
            {
                db.Pulls.Remove(pull);
                db.SaveChanges();
            }

            return RedirectToAction("Subscription", new { id = subscription });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPull(int id, int subscription)
        {
            int userId = WebSecurity.CurrentUserId;
            Series series = db.Series.FirstOrDefault(s => s.Id == id);
            Subscription subs = db.Subscriptions.FirstOrDefault(s => s.Id == subscription);
            Pull pull = db.Pulls.FirstOrDefault(p => p.SubscriptionId == subscription && p.SeriesId == id);

            if (pull == null && series != null && subs != null)
            {
                db.Pulls.Add(new Pull()
                {
                    StartDate = DateTime.UtcNow,
                    SeriesId = series.Id,
                    SubscriptionId = subs.Id
                });
                db.SaveChanges();
            }

            return RedirectToAction("Subscription", new { id = subscription });
        }

        public ActionResult Search(string title, int subscription)
        {
            ViewBag.SubscriptionId = subscription;

            SeriesSearchVM model = new SeriesSearchVM()
            {
                Title = title,
                SubscriptionId = subscription
            };

            if(!string.IsNullOrWhiteSpace(title))
            {
                model.Series = db.Series.Where(s => s.Title.ToLower().Contains(title.ToLower())).ToList();
            }

            return View(model);
        }
    }
}
