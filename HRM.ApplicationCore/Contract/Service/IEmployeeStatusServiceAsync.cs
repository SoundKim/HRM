using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Service
{
    public interface IEmployeeStatusServiceAsync
    {
        Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel model);
        Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel model);
        Task<int> DeleteEmployeeStatusAsync(int Id);
        Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsnc(int Id);
        Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatussAsync();
    }
}
