using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Service
{
    public interface IJobCategoryServiceAsync
    {
        Task<int> AddJobCategoryAsync(JobCategoryRequestModel model);
        Task<int> UpdateJobCategoryAsync(JobCategoryRequestModel model);
        Task<int> DeleteJobCategoryAsync(int Id);
        Task<JobCategoryResponseModel> GetJobCategoryByIdAsnc(int Id);
        Task<IEnumerable<JobCategoryResponseModel>> GetAllJobCategorysAsync();
    }
}
