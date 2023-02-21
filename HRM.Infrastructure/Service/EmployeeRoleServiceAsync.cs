using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Entity;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Infrastructure.Service
{
    public class EmployeeRoleServiceAsync : IEmployeeRoleServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IEmployeeRoleRepositoryAsync employeeRoleRepositoryAsync;
        public EmployeeRoleServiceAsync(IEmployeeRoleRepositoryAsync _employeeRoleRepositoryAsync)
        {
            employeeRoleRepositoryAsync = _employeeRoleRepositoryAsync;
        }

        public async Task<int> AddEmployeeRoleAsync(EmployeeRoleRequestModel model)
        {
            EmployeeRole employeeRole = new EmployeeRole()
            {
               Id = model.Id,
               Title = model.Title,
               Description = model.Description,
               IsActive = model.IsActive
            };
            return await employeeRoleRepositoryAsync.InsertAsync(employeeRole);
        }

        public async Task<int> DeleteEmployeeRoleAsync(int Id)
        {
            return await employeeRoleRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<EmployeeRoleResponseModel>> GetAllEmployeeRolesAsync()
        {
            var result = await employeeRoleRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new EmployeeRoleResponseModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    IsActive = model.IsActive
                });
            }
            return null;
        }

        public async Task<EmployeeRoleResponseModel> GetEmployeeRoleByIdAsnc(int Id)
        {
            var result = await employeeRoleRepositoryAsync.GetByIdAsync(Id);
            if(result !=null)
            { 
                return new EmployeeRoleResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeRoleAsync(EmployeeRoleRequestModel model)
        {
            EmployeeRole employeeRole = new EmployeeRole()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                IsActive = model.IsActive
            };
            return employeeRoleRepositoryAsync.UpdateAsync(employeeRole);
        }
    }
}
