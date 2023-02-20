using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRM.ApplicationCore.Entity
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Column(TypeName = "varchar(11)")]
        public string? SSN { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string? CurrentAddress { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        public int? EmployeeRoleId { get; set; }
        public int? EmployeeTypeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public int? EmployeeStatusId { get; set; }
        public int? ManagerId { get; set; }
        

        //navigation property
        public EmployeeRole EmployeeRole { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
    }
}