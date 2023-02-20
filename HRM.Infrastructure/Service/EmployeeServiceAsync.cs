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
    public class EmployeeServiceAsync : IEmployeeServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IEmployeeRepositoryAsync employeeRepositoryAsync;
        public EmployeeServiceAsync(IEmployeeRepositoryAsync _employeeRepositoryAsync)
        {
            employeeRepositoryAsync = _employeeRepositoryAsync;
        }

        public async Task<int> AddEmployeeAsync(EmployeeRequestModel model)
        {
            Employee employee = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailId = model.EmailId,
                Phone = model.Phone,
                HireDate = model.HireDate,
                DOB = model.DOB,
                ManagerId = model.ManagerId
            };
            return await employeeRepositoryAsync.InsertAsync(employee);
        }

        public async Task<int> DeleteEmployeeAsync(int Id)
        {
            return await employeeRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeesAsync()
        {
            var result = await employeeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new EmployeeResponseModel
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailId = model.EmailId,
                    Phone = model.Phone,
                    HireDate = model.HireDate,
                    DOB = model.DOB,
                    ManagerId = model.ManagerId
                });
            }
            return null;
        }

        public async Task<EmployeeResponseModel> GetEmployeeByIdAsnc(int Id)
        {
            var result = await employeeRepositoryAsync.GetByIdAsync(Id);
            if(result !=null)
            { 
                return new EmployeeResponseModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    EmailId = result.EmailId,
                    Phone = result.Phone,
                    HireDate = result.HireDate,
                    DOB = result.DOB,
                    ManagerId = result.ManagerId
                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeAsync(EmployeeRequestModel model)
        {
            Employee employee = new Employee()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailId = model.EmailId,
                Phone = model.Phone,
                HireDate = model.HireDate,
                DOB = model.DOB,
                ManagerId = model.ManagerId
            };
            return employeeRepositoryAsync.UpdateAsync(employee);
        }
    }
}
