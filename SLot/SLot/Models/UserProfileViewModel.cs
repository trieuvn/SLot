using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLot.Models
{
    public class UserProfileViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
    }
}