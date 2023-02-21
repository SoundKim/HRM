using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Service
{
    public interface IInterviewServiceAsync
    {
        Task<int> AddInterviewAsync(InterviewRequestModel model);
        Task<int> UpdateInterviewAsync(InterviewRequestModel model);
        Task<int> DeleteInterviewAsync(int Id);
        Task<InterviewResponseModel> GetInterviewByIdAsnc(int Id);
        Task<IEnumerable<InterviewResponseModel>> GetAllInterviewsAsync();
    }
}
