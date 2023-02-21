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
    public class InterviewTypeServiceAsync : IInterviewTypeServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IInterviewTypeRepositoryAsync InterviewTypeRepositoryAsync;
        public InterviewTypeServiceAsync(IInterviewTypeRepositoryAsync _InterviewTypeRepositoryAsync)
        {
            InterviewTypeRepositoryAsync = _InterviewTypeRepositoryAsync;
        }

        public async Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            InterviewType InterviewType = new InterviewType()
            {
               Id = model.Id,
               Title = model.Title,
               IsActive = model.IsActive
            };
            return await InterviewTypeRepositoryAsync.InsertAsync(InterviewType);
        }

        public async Task<int> DeleteInterviewTypeAsync(int Id)
        {
            return await InterviewTypeRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypesAsync()
        {
            var result = await InterviewTypeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new InterviewTypeResponseModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    IsActive = model.IsActive
                });
            }
            return null;
        }

        public async Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsnc(int Id)
        {
            var result = await InterviewTypeRepositoryAsync.GetByIdAsync(Id);
            if(result !=null)
            { 
                return new InterviewTypeResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            InterviewType InterviewType = new InterviewType()
            {
                Id = model.Id,
                Title = model.Title,
                IsActive = model.IsActive
            };
            return InterviewTypeRepositoryAsync.UpdateAsync(InterviewType);
        }
    }
}
