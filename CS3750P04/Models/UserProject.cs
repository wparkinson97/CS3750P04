using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS3750P04.Models
{
    public class UserProject
    {
        public int UserProjectId { get; set; }

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public int GroupId { get; set; }
    }
}
