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
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }
    }
}
