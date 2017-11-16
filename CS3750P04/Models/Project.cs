using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS3750P04.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        
        public string ProjectName { get; set; }

        public bool Active { get; set; }
    }
}
