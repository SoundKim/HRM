using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class InterviewTypeController : Controller
    {
        private readonly IInterviewTypeServiceAsync interviewTypeServiceAsync;

        public InterviewTypeController(IInterviewTypeServiceAsync _interviewTypeServiceAsync)
        {
            interviewTypeServiceAsync = _interviewTypeServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var interviewTypeCollection = await interviewTypeServiceAsync.GetAllInterviewTypesAsync();
            return View(interviewTypeCollection);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InterviewTypeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewTypeServiceAsync.AddInterviewTypeAsync(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await interviewTypeServiceAsync.GetInterviewTypeByIdAsnc(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InterviewTypeRequestModel model)
        {
            try
            {
                await interviewTypeServiceAsync.UpdateInterviewTypeAsync(model);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await interviewTypeServiceAsync.GetInterviewTypeByIdAsnc(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(InterviewTypeRequestModel model)
        {
            try
            {
                var result = await interviewTypeServiceAsync.DeleteInterviewTypeAsync(model.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
            
        }
    }
}
