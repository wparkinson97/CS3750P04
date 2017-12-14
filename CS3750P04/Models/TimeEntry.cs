using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS3750P04.Models
{
    public class TimeEntry
    {
        public long TimeEntryId { get; set; }

        public int UserId { get; set; }

        public int GroupId { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime? TimeStop { get; set; }

        public bool Deleted { get; set; }

        public string EntryComment { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
