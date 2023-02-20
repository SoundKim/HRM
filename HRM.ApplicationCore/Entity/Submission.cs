using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Entity
{
    public class Submission
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int JobRequirementId { get; set; }
        public DateTime AppliedOn { get; set; }

        //navigational properties
        public Candidate Candidate { get; set; }
        public JobRequirement JobRequirement { get; set; }
    }
}
