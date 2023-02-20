using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Service
{
    public interface IJobRequirementServiceAsync
    {
        Task<int> AddJobRequirementAsync(JobRequirementRequestModel model);
        Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model);
        Task<int> DeleteJobRequirementAsync(int Id);
        Task<JobRequirementResponseModel> GetJobRequirementByIdAsnc(int Id);
        Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirementsAsync();
    }
}
