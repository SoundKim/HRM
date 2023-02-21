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
    public class EmployeeStatusServiceAsync : IEmployeeStatusServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IEmployeeStatusRepositoryAsync employeeStatusRepositoryAsync;
        public EmployeeStatusServiceAsync(IEmployeeStatusRepositoryAsync _employeeStatusRepositoryAsync)
        {
            employeeStatusRepositoryAsync = _employeeStatusRepositoryAsync;
        }

        public async Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel model)
        {
            EmployeeStatus employeeStatus = new EmployeeStatus()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                IsActive = model.IsActive
            };
            return await employeeStatusRepositoryAsync.InsertAsync(employeeStatus);
        }

        public async Task<int> DeleteEmployeeStatusAsync(int Id)
        {
            return await employeeStatusRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatussAsync()
        {
            var result = await employeeStatusRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new EmployeeStatusResponseModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    IsActive = model.IsActive
                });
            }
            return null;
        }

        public async Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsnc(int Id)
        {
            var result = await employeeStatusRepositoryAsync.GetByIdAsync(Id);
            if (result != null)
            {
                return new EmployeeStatusResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel model)
        {
            EmployeeStatus employeeStatus = new EmployeeStatus()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                IsActive = model.IsActive
            };
            return employeeStatusRepositoryAsync.UpdateAsync(employeeStatus);
        }
    }
}
