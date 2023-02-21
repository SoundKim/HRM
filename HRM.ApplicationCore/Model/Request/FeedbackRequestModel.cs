using HRM.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Request
{
    public class FeedbackRequestModel
    {
        public int Id { get; set; }
        public int InterviewId { get; set; }
        public string Description { get; set; }
        public string Abbr { get; set; }

    }
}
