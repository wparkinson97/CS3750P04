using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS3750P04.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string ScreenName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool isActive { get; set; }

        public string UserHash { get; set; }
    }
}
