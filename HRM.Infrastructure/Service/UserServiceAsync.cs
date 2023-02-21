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
    public class UserServiceAsync : IUserServiceAsync
    {
        private readonly IUserRepositoryAsync userRepositoryAsync;
        public UserServiceAsync(IUserRepositoryAsync _userRepositoryAsync)
        {
            userRepositoryAsync = _userRepositoryAsync;
        }

        public async Task<int> AddUserAsync(UserRequestModel model)
        {
            User user = new User()
            {
                Id = model.Id,
                Username = model.Username,
                EmailId = model.EmailId,
                Password= model.Password
            };
            return await userRepositoryAsync.InsertAsync(user);
        }

        public async Task<int> DeleteUserAsync(int Id)
        {
            return await userRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsersAsync()
        {
            var result = await userRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new UserResponseModel
                {
                    Id = model.Id,
                    Username = model.Username,
                    EmailId = model.EmailId,
                    Password= model.Password
                    
                  
                });
            }
            return null;
        }

        public async Task<UserResponseModel> GetUserByIdAsnc(int Id)
        {
            var model = await userRepositoryAsync.GetByIdAsync(Id);
            if (model != null)
            {
                return new UserResponseModel()
                {
                    Id = model.Id,
                    Username = model.Username,
                    EmailId = model.EmailId,
                    Password= model.Password
                    
                  
                };
            }
            return null;
        }

        public Task<int> UpdateUserAsync(UserRequestModel model)
        {
            User user = new User()
            {
                Id = model.Id,
                Username = model.Username,
                EmailId = model.EmailId,
                Password= model.Password
                
              
            };
            return userRepositoryAsync.UpdateAsync(user);
        }
    }
}
