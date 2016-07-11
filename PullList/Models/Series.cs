using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PullList.Models
{
    public class Series
    {
        public int Id { get; set; }

        public bool Active { get; set; }

        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int Volume { get; set; }

        public string Image { get; set; }

        [NotMapped]
        public int Count { get; set; }
    }
}