using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class SubmissionController : Controller
    {
        private readonly ISubmissionServiceAsync submissionServiceAsync;

        public SubmissionController(ISubmissionServiceAsync _submissionServiceAsync)
        {
            submissionServiceAsync = _submissionServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var submissionCollection = await submissionServiceAsync.GetAllSubmissionsAsync();
            return View(submissionCollection);
        }

        public IActionResult Create()
        {
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
    }
}
