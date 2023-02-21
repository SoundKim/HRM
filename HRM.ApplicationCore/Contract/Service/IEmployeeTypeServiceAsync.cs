using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Service
{
    public interface IEmployeeTypeServiceAsync
    {
        Task<int> AddEmployeeTypeAsync(EmployeeTypeRequestModel model);
        Task<int> UpdateEmployeeTypeAsync(EmployeeTypeRequestModel model);
        Task<int> DeleteEmployeeTypeAsync(int Id);
        Task<EmployeeTypeResponseModel> GetEmployeeTypeByIdAsnc(int Id);
        Task<IEnumerable<EmployeeTypeResponseModel>> GetAllEmployeeTypesAsync();
    }
}
