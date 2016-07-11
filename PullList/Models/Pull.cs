using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PullList.Models
{
    public class Pull
    {
        public int Id { get; set; }

        [ForeignKey("Series")]
        public int SeriesId { get; set; }
        public virtual Series Series { get; set; }

        [ForeignKey("Subscription")]
        public int SubscriptionId { get; set; }
        public virtual Subscription Subscription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}