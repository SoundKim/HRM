using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidateServiceAsync candidateServiceAsync;

        public CandidateController(ICandidateServiceAsync _candidateServiceAsync)
        {
            candidateServiceAsync = _candidateServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var candidateCollection = await candidateServiceAsync.GetAllCandidatesAsync();
            return View(candidateCollection);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await candidateServiceAsync.AddCandidateAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await candidateServiceAsync.GetCandidateByIdAsnc(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CandidateRequestModel model)
        {
            try
            {
                await candidateServiceAsync.UpdateCandidateAsync(model);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(model);
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await candidateServiceAsync.GetCandidateByIdAsnc(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CandidateResponseModel model)
        {
            await candidateServiceAsync.DeleteCandidateAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}
