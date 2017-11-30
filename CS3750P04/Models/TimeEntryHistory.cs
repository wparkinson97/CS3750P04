using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS3750P04.Models
{
    public class TimeEntryHistory
    {
        public long TimeEntryHistoryId { get; set; }

        public long TimeEntryId { get; set; }

        public string ChangedField { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
