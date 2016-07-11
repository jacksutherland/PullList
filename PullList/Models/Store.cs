using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PullList.Models
{
    public enum PullType { Ongoing = 1, Monthly = 2 }

    public class Store
    {
        public int Id { get; set; }

        public bool Active { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public PullType PullType { get; set; }
    }
}