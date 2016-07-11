using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PullList.Models
{
    public class SeriesSearchVM
    {
        public string Title { get; set; }

        public List<Series> Series { get; set; }

        public int SubscriptionId { get; set; }
    }
}