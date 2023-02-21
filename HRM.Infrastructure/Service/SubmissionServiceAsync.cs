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
    public class SubmissionServiceAsync : ISubmissionServiceAsync
    {
        private readonly ISubmissionRepositoryAsync submissionRepositoryAsync;
        public SubmissionServiceAsync(ISubmissionRepositoryAsync _submissionRepositoryAsync)
        {
            submissionRepositoryAsync = _submissionRepositoryAsync;
        }

        public async Task<int> AddSubmissionAsync(SubmissionRequestModel model)
        {
            Submission submission = new Submission()
            {
                Id = model.Id,
                CandidateId = model.CandidateId,
                JobRequirementId = model.JobRequirementId,
                AppliedOn= model.AppliedOn
            };
            return await submissionRepositoryAsync.InsertAsync(submission);
        }

        public async Task<int> DeleteSubmissionAsync(int Id)
        {
            return await submissionRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissionsAsync()
        {
            var result = await submissionRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new SubmissionResponseModel
                {
                    Id = model.Id,
                    CandidateId = model.CandidateId,
                    JobRequirementId = model.JobRequirementId,
                    AppliedOn= model.AppliedOn
                    
                  
                });
            }
            return null;
        }

        public async Task<SubmissionResponseModel> GetSubmissionByIdAsnc(int Id)
        {
            var model = await submissionRepositoryAsync.GetByIdAsync(Id);
            if (model != null)
            {
                return new SubmissionResponseModel()
                {
                    Id = model.Id,
                    CandidateId = model.CandidateId,
                    JobRequirementId = model.JobRequirementId,
                    AppliedOn= model.AppliedOn
                    
                  
                };
            }
            return null;
        }

        public Task<int> UpdateSubmissionAsync(SubmissionRequestModel model)
        {
            Submission submission = new Submission()
            {
                Id = model.Id,
                CandidateId = model.CandidateId,
                JobRequirementId = model.JobRequirementId,
                AppliedOn= model.AppliedOn
                
              
            };
            return submissionRepositoryAsync.UpdateAsync(submission);
        }
    }
}
