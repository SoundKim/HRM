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
    public class EmployeeTypeServiceAsync : IEmployeeTypeServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IEmployeeTypeRepositoryAsync employeeTypeRepositoryAsync;
        public EmployeeTypeServiceAsync(IEmployeeTypeRepositoryAsync _employeeTypeRepositoryAsync)
        {
            employeeTypeRepositoryAsync = _employeeTypeRepositoryAsync;
        }

        public async Task<int> AddEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            EmployeeType employeeType = new EmployeeType()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                IsActive = model.IsActive
            };
            return await employeeTypeRepositoryAsync.InsertAsync(employeeType);
        }

        public async Task<int> DeleteEmployeeTypeAsync(int Id)
        {
            return await employeeTypeRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<EmployeeTypeResponseModel>> GetAllEmployeeTypesAsync()
        {
            var result = await employeeTypeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new EmployeeTypeResponseModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    IsActive = model.IsActive
                });
            }
            return null;
        }

        public async Task<EmployeeTypeResponseModel> GetEmployeeTypeByIdAsnc(int Id)
        {
            var result = await employeeTypeRepositoryAsync.GetByIdAsync(Id);
            if (result != null)
            {
                return new EmployeeTypeResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            EmployeeType employeeType = new EmployeeType()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                IsActive = model.IsActive
            };
            return employeeTypeRepositoryAsync.UpdateAsync(employeeType);
        }
    }
}
