using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Service
{
    public interface IFeedbackServiceAsync
    {
        Task<int> AddFeedbackAsync(FeedbackRequestModel model);
        Task<int> UpdateFeedbackAsync(FeedbackRequestModel model);
        Task<int> DeleteFeedbackAsync(int Id);
        Task<FeedbackResponseModel> GetFeedbackByIdAsnc(int Id);
        Task<IEnumerable<FeedbackResponseModel>> GetAllFeedbacksAsync();
    }
}
