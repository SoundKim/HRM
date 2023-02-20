using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Entity
{
    public class Interview
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public int InterviewRound { get; set; }
        public int InterviewTypeId { get; set; }
        public int InterviewStatusId { get; set; }
        public int InterviewerId { get; set; }
        
        //Navigation Properties
        public Submission Submission { get; set; }
        public InterviewType InterviewType { get; set; }
        public InterviewStatus InterviewStatus { get; set; }
        public Employee Interviewer { get; set; }
    }
}
