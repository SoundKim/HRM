using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Entity
{
    public class Candidate
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        [Required]

        [Column(TypeName = "varchar(100)")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? ResumeUrl { get; set; }
    }
}
