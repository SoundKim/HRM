using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Service
{
    public interface IRoleServiceAsync
    {
        Task<int> AddRoleAsync(RoleRequestModel model);
        Task<int> UpdateRoleAsync(RoleRequestModel model);
        Task<int> DeleteRoleAsync(int Id);
        Task<RoleResponseModel> GetRoleByIdAsnc(int Id);
        Task<IEnumerable<RoleResponseModel>> GetAllRolesAsync();
    }
}
