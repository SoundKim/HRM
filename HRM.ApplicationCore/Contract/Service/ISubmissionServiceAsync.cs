using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Service
{
    public interface ISubmissionServiceAsync
    {
        Task<int> AddSubmissionAsync(SubmissionRequestModel model);
        Task<int> UpdateSubmissionAsync(SubmissionRequestModel model);
        Task<int> DeleteSubmissionAsync(int Id);
        Task<SubmissionResponseModel> GetSubmissionByIdAsnc(int Id);
        Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissionsAsync();
    }
}
