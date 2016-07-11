using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PullList.Models;

namespace PullList.Models
{
    public class PullListVM
    {
        public int? SubscriptionId { get; set; }

        public string StoreName { get; set; }

        public List<Subscription> Subscriptions { get; set; }

        public List<Pull> Pulls { get; set; }
    }
}