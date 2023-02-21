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
    public class InterviewServiceAsync : IInterviewServiceAsync
    {
        private readonly IInterviewRepositoryAsync interviewRepositoryAsync;
        public InterviewServiceAsync(IInterviewRepositoryAsync _interviewRepositoryAsync)
        {
            interviewRepositoryAsync = _interviewRepositoryAsync;
        }

        public async Task<int> AddInterviewAsync(InterviewRequestModel model)
        {
            Interview interview = new Interview()
            {
                Id = model.Id,
                SubmissionId = model.SubmissionId,
                InterviewRound = model.InterviewRound,
                InterviewTypeId = model.InterviewTypeId,
                InterviewStatusId = model.InterviewStatusId,
                InterviewerId = model.InterviewerId
            };
            return await interviewRepositoryAsync.InsertAsync(interview);
        }

        public async Task<int> DeleteInterviewAsync(int Id)
        {
            return await interviewRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<InterviewResponseModel>> GetAllInterviewsAsync()
        {
            var result = await interviewRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new InterviewResponseModel
                {
                    Id = model.Id,
                    SubmissionId = model.SubmissionId,
                    InterviewRound = model.InterviewRound,
                    InterviewTypeId = model.InterviewTypeId,
                    InterviewStatusId = model.InterviewStatusId,
                    InterviewerId = model.InterviewerId
                });
            }
            return null;
        }

        public async Task<InterviewResponseModel> GetInterviewByIdAsnc(int Id)
        {
            var model = await interviewRepositoryAsync.GetByIdAsync(Id);
            if (model != null)
            {
                return new InterviewResponseModel()
                {
                    Id = model.Id,
                    SubmissionId = model.SubmissionId,
                    InterviewRound = model.InterviewRound,
                    InterviewTypeId = model.InterviewTypeId,
                    InterviewStatusId = model.InterviewStatusId,
                    InterviewerId = model.InterviewerId
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewAsync(InterviewRequestModel model)
        {
            Interview interview = new Interview()
            {
                Id = model.Id,
                SubmissionId = model.SubmissionId,
                InterviewRound = model.InterviewRound,
                InterviewTypeId = model.InterviewTypeId,
                InterviewStatusId = model.InterviewStatusId,
                InterviewerId = model.InterviewerId
            };
            return interviewRepositoryAsync.UpdateAsync(interview);
        }
    }
}
