using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Service
{
    public interface IUserServiceAsync
    {
        Task<int> AddUserAsync(UserRequestModel model);
        Task<int> UpdateUserAsync(UserRequestModel model);
        Task<int> DeleteUserAsync(int Id);
        Task<UserResponseModel> GetUserByIdAsnc(int Id);
        Task<IEnumerable<UserResponseModel>> GetAllUsersAsync();
    }
}
