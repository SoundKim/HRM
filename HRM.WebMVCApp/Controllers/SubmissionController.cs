using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRM.WebMVCApp.Controllers
{
    public class SubmissionController : Controller
    {
        private readonly ISubmissionServiceAsync submissionServiceAsync;
        private readonly IJobRequirementServiceAsync jobRequirementServiceAsync;
        private readonly ICandidateServiceAsync candidateServiceAsync;

        public SubmissionController(ISubmissionServiceAsync _submissionServiceAsync, IJobRequirementServiceAsync _jobRequirementServiceAsync, ICandidateServiceAsync _candidateServiceAsync)
        {
            submissionServiceAsync = _submissionServiceAsync;
            jobRequirementServiceAsync = _jobRequirementServiceAsync;
            candidateServiceAsync = _candidateServiceAsync;

        }
        public async Task<IActionResult> Index()
        {
            var submissionCollection = await submissionServiceAsync.GetAllSubmissionsAsync();
            return View(submissionCollection);
        }

        public async Task<IActionResult> Create()
        {
            await GetAllViewBagValues();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubmissionRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await submissionServiceAsync.AddSubmissionAsync(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await submissionServiceAsync.GetSubmissionByIdAsnc(id);
            await GetAllViewBagValues();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SubmissionRequestModel model)
        {
            try
            {
                await submissionServiceAsync.UpdateSubmissionAsync(model);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await submissionServiceAsync.GetSubmissionByIdAsnc(id);
            await GetAllViewBagValues();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SubmissionRequestModel model)
        {
            try
            {
                var result = await submissionServiceAsync.DeleteSubmissionAsync(model.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
            
        }

        [NonAction]
        public async Task GetJobRequirement()
        {
            ViewBag.JobRequirementList = new SelectList(await jobRequirementServiceAsync.GetAllJobRequirementsAsync(), "Id", "Title");
        }

        [NonAction]
        public async Task GetCandidate()
        {
            var result = await candidateServiceAsync.GetAllCandidatesAsync();
            ViewBag.CandidateList = new SelectList( result.Select(x => new { Id = x.Id, Title = x.FirstName + " " + x.LastName }), "Id", "Title");
        }

        [NonAction]
        public async Task GetAllViewBagValues()
        {
            await GetJobRequirement();
            await GetCandidate();
        }
    }
}
