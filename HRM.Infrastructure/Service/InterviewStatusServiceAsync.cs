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
    public class InterviewStatusServiceAsync : IInterviewStatusServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IInterviewStatusRepositoryAsync InterviewStatusRepositoryAsync;
        public InterviewStatusServiceAsync(IInterviewStatusRepositoryAsync _InterviewStatusRepositoryAsync)
        {
            InterviewStatusRepositoryAsync = _InterviewStatusRepositoryAsync;
        }

        public async Task<int> AddInterviewStatusAsync(InterviewStatusRequestModel model)
        {
            InterviewStatus InterviewStatus = new InterviewStatus()
            {
               Id = model.Id,
               Title = model.Title,
               IsActive = model.IsActive
            };
            return await InterviewStatusRepositoryAsync.InsertAsync(InterviewStatus);
        }

        public async Task<int> DeleteInterviewStatusAsync(int Id)
        {
            return await InterviewStatusRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<InterviewStatusResponseModel>> GetAllInterviewStatussAsync()
        {
            var result = await InterviewStatusRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new InterviewStatusResponseModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    IsActive = model.IsActive
                });
            }
            return null;
        }

        public async Task<InterviewStatusResponseModel> GetInterviewStatusByIdAsnc(int Id)
        {
            var result = await InterviewStatusRepositoryAsync.GetByIdAsync(Id);
            if(result !=null)
            { 
                return new InterviewStatusResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewStatusAsync(InterviewStatusRequestModel model)
        {
            InterviewStatus InterviewStatus = new InterviewStatus()
            {
                Id = model.Id,
                Title = model.Title,
                IsActive = model.IsActive
            };
            return InterviewStatusRepositoryAsync.UpdateAsync(InterviewStatus);
        }
    }
}
