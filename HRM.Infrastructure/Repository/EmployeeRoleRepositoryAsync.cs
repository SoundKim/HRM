using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Entity;
using HRM.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Infrastructure.Repository
{
    public class EmployeeRoleRepositoryAsync: BaseRepositoryAsync<EmployeeRole>, IEmployeeRoleRepositoryAsync
    {
        public EmployeeRoleRepositoryAsync(HRMDbContext _context): base(_context)
        {

        }
    }
}
