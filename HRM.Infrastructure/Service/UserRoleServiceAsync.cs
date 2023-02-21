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
    public class UserRoleServiceAsync : IUserRoleServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IUserRoleRepositoryAsync UserRoleRepositoryAsync;
        public UserRoleServiceAsync(IUserRoleRepositoryAsync _UserRoleRepositoryAsync)
        {
            UserRoleRepositoryAsync = _UserRoleRepositoryAsync;
        }

        public async Task<int> AddUserRoleAsync(UserRoleRequestModel model)
        {
            UserRole UserRole = new UserRole()
            {
               Id = model.Id,
               UserId = model.UserId,
               RoleId = model.RoleId
            };
            return await UserRoleRepositoryAsync.InsertAsync(UserRole);
        }

        public async Task<int> DeleteUserRoleAsync(int Id)
        {
            return await UserRoleRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<UserRoleResponseModel>> GetAllUserRolesAsync()
        {
            var result = await UserRoleRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new UserRoleResponseModel
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    RoleId = model.RoleId
                });
            }
            return null;
        }

        public async Task<UserRoleResponseModel> GetUserRoleByIdAsnc(int Id)
        {
            var result = await UserRoleRepositoryAsync.GetByIdAsync(Id);
            if(result !=null)
            { 
                return new UserRoleResponseModel()
                {
                    Id = result.Id,
                    UserId = result.UserId,
                    RoleId = result.RoleId
                };
            }
            return null;
        }

        public Task<int> UpdateUserRoleAsync(UserRoleRequestModel model)
        {
            UserRole UserRole = new UserRole()
            {
                Id = model.Id,
                UserId = model.UserId,
                RoleId = model.RoleId
            };
            return UserRoleRepositoryAsync.UpdateAsync(UserRole);
        }
    }
}
