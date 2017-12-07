using CS3750P04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS3750P04.ViewModels
{
    public class UserViewModel
    {
        public User selectedUser { get; set; }
        public Group selectedGroup { get; set; }
        public IEnumerable<TimeEntry> timeEntries { get; set; }
    }
}
