using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PullList.Models
{
    public enum PullListFilter { Title = 1, User = 2 }

    public class StorePullVM
    {
        public PullListFilter Filter { get; set; }

        public List<Series> Series { get; set; }
    }
}