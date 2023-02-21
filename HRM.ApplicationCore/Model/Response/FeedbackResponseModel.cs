using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.ApplicationCore.Entity;

namespace HRM.ApplicationCore.Model.Response
{
    public class FeedbackResponseModel
    {
        public int Id { get; set; }
        public int InterviewId { get; set; }
        public string Description { get; set; }
        public string Abbr { get; set; }
    }
}
