using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PullList.Models
{
    public class UserDetail
    {
        public int Id { get; set; }

        public bool Active { get; set; }

        public bool IsAdmin { get; set; }

        [ForeignKey("UserProfile")]
        public int UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool SMSNotifications { get; set; }

        public bool EmailNotifications { get; set; }
    }
}