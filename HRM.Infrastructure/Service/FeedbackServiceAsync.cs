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
    public class FeedbackServiceAsync : IFeedbackServiceAsync
    {
        private readonly IFeedbackRepositoryAsync feedbackRepositoryAsync;
        public FeedbackServiceAsync(IFeedbackRepositoryAsync _feedbackRepositoryAsync)
        {
            feedbackRepositoryAsync = _feedbackRepositoryAsync;
        }

        public async Task<int> AddFeedbackAsync(FeedbackRequestModel model)
        {
            Feedback feedback = new Feedback()
            {
                Id = model.Id,
                InterviewId = model.InterviewId,
                Description = model.Description,
                Abbr = model.Abbr
            };
            return await feedbackRepositoryAsync.InsertAsync(feedback);
        }

        public async Task<int> DeleteFeedbackAsync(int Id)
        {
            return await feedbackRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<FeedbackResponseModel>> GetAllFeedbacksAsync()
        {
            var result = await feedbackRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new FeedbackResponseModel
                {
                    Id = model.Id,
                    InterviewId = model.InterviewId,
                    Description = model.Description,
                    Abbr = model.Abbr
                });
            }
            return null;
        }

        public async Task<FeedbackResponseModel> GetFeedbackByIdAsnc(int Id)
        {
            var model = await feedbackRepositoryAsync.GetByIdAsync(Id);
            if (model != null)
            {
                return new FeedbackResponseModel()
                {
                    Id = model.Id,
                    InterviewId = model.InterviewId,
                    Description = model.Description,
                    Abbr = model.Abbr
                };
            }
            return null;
        }

        public Task<int> UpdateFeedbackAsync(FeedbackRequestModel model)
        {
            Feedback feedback = new Feedback()
            {
                Id = model.Id,
                InterviewId = model.InterviewId,
                Description = model.Description,
                Abbr = model.Abbr
            };
            return feedbackRepositoryAsync.UpdateAsync(feedback);
        }
    }
}
