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
    public class CandidateResponseModel
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mobile { get; set; }

        public string EmailId { get; set; }

        public string? ResumeUrl { get; set; }
    }
}
