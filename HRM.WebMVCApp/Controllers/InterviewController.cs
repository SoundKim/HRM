using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HRM.WebMVCApp.Controllers
{
    public class InterviewController : Controller
    {
        private readonly IInterviewServiceAsync interviewServiceAsync;
        private readonly ISubmissionServiceAsync submissionServiceAsync;
        private readonly IInterviewTypeServiceAsync interviewTypeServiceAsync;
        private readonly IInterviewStatusServiceAsync interviewStatusServiceAsync;
        private readonly IEmployeeServiceAsync employeeServiceAsync;

        public InterviewController(IInterviewServiceAsync _interviewServiceAsync, IInterviewStatusServiceAsync _interviewStatusServiceAsync, ISubmissionServiceAsync _submissionServiceAsync, IInterviewTypeServiceAsync _interviewTypeServiceAsync, IEmployeeServiceAsync _employeeServiceAsync)
        {
            interviewServiceAsync = _interviewServiceAsync;
            interviewStatusServiceAsync = _interviewStatusServiceAsync;
            submissionServiceAsync = _submissionServiceAsync;
            interviewTypeServiceAsync = _interviewTypeServiceAsync;
            employeeServiceAsync = _employeeServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var interviewCollection = await interviewServiceAsync.GetAllInterviewsAsync();
            return View(interviewCollection);
        }

        public async Task<IActionResult> Create()
        {
            await GetAllViewBagValues();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InterviewRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewServiceAsync.AddInterviewAsync(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await interviewServiceAsync.GetInterviewByIdAsnc(id);
            await GetAllViewBagValues();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InterviewRequestModel model)
        {
            try
            {
                await interviewServiceAsync.UpdateInterviewAsync(model);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await interviewServiceAsync.GetInterviewByIdAsnc(id);
            await GetAllViewBagValues();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(InterviewRequestModel model)
        {
            try
            {
                var result = await interviewServiceAsync.DeleteInterviewAsync(model.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
            
        }

        [NonAction]
        public async Task GetSubmissionStatus()
        {
            ViewBag.SubmissionList = new SelectList(await submissionServiceAsync.GetAllSubmissionsAsync(), "Id", "Id");
        }

        [NonAction]
        public async Task GetInterviewStatus()
        {
            ViewBag.InterviewStatusList = new SelectList(await interviewStatusServiceAsync.GetAllInterviewStatussAsync(), "Id", "Title");
        }

        [NonAction]
        public async Task GetInterviewType()
        {
            ViewBag.InterviewTypeList = new SelectList(await interviewTypeServiceAsync.GetAllInterviewTypesAsync(), "Id", "Title");
        }

        [NonAction]
        public async Task GetInterviewer()
        {
            var result = await employeeServiceAsync.GetAllEmployeesAsync();
            ViewBag.InterviewerList = new SelectList(result.Select(x => new { Id = x.Id, Name = x.FirstName + " " + x.LastName }), "Id", "Name");

        }

        public async Task GetAllViewBagValues()
        {
            await GetSubmissionStatus();
            await GetInterviewStatus();
            await GetInterviewType();
            await GetInterviewer();
        }
    }
}
