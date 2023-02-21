using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Response
{
    public class UserResponseModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string EmailId { get; set; }

        public string Password { get; set; }
    }
}
