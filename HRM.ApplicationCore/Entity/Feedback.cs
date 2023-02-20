using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Entity
{
    public class Feedback
    {
        public int Id { get; set; }
        public int InterviewId { get; set; }
        public string Description { get; set; }
        public string Abbr { get; set; }

        //navigation property
        public Interview Interview { get; set; }
    }
}
