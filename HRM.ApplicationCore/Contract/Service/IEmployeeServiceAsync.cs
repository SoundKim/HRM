using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Service
{
    public interface IEmployeeServiceAsync
    {
        Task<int> AddEmployeeAsync(EmployeeRequestModel model);
        Task<int> UpdateEmployeeAsync(EmployeeRequestModel model);
        Task<int> DeleteEmployeeAsync(int Id);
        Task<EmployeeResponseModel> GetEmployeeByIdAsnc(int Id);
        Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeesAsync();
    }
}
