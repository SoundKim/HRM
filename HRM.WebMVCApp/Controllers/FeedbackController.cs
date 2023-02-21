using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackServiceAsync feedbackServiceAsync;
        
        public FeedbackController(IFeedbackServiceAsync _feedbackServiceAsync)
        {
            feedbackServiceAsync = _feedbackServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var feedbackCollection = await feedbackServiceAsync.GetAllFeedbacksAsync();
            return View(feedbackCollection);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FeedbackRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await feedbackServiceAsync.AddFeedbackAsync(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await feedbackServiceAsync.GetFeedbackByIdAsnc(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FeedbackRequestModel model)
        {
            try
            {
                await feedbackServiceAsync.UpdateFeedbackAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await feedbackServiceAsync.GetFeedbackByIdAsnc(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(FeedbackRequestModel model)
        {
            try
            {
                var result = await feedbackServiceAsync.DeleteFeedbackAsync(model.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }
    }
}
