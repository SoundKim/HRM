using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Service
{
    public interface IInterviewStatusServiceAsync
    {
        Task<int> AddInterviewStatusAsync(InterviewStatusRequestModel model);
        Task<int> UpdateInterviewStatusAsync(InterviewStatusRequestModel model);
        Task<int> DeleteInterviewStatusAsync(int Id);
        Task<InterviewStatusResponseModel> GetInterviewStatusByIdAsnc(int Id);
        Task<IEnumerable<InterviewStatusResponseModel>> GetAllInterviewStatussAsync();
    }
}
