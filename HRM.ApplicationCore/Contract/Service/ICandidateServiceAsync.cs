using HRM.ApplicationCore.Model;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Service
{
    public interface ICandidateServiceAsync
    {
        Task<int> AddCandidateAsync(CandidateRequestModel model);
        Task<int> UpdateCandidateAsync(CandidateRequestModel model);
        Task<int> DeleteCandidateAsync(int Id);
        Task<CandidateResponseModel> GetCandidateByIdAsnc(int Id);
        Task<IEnumerable<CandidateResponseModel>> GetAllCandidatesAsync();
    }
}
