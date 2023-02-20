using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServiceAsync employeeServiceAsync;

        public EmployeeController(IEmployeeServiceAsync _employeeServiceAsync)
        {
            employeeServiceAsync = _employeeServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var employeeCollection = await employeeServiceAsync.GetAllEmployeesAsync();
            return View(employeeCollection);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeServiceAsync.AddEmployeeAsync(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await employeeServiceAsync.GetEmployeeByIdAsnc(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeRequestModel model)
        {
            try
            {
                await employeeServiceAsync.UpdateEmployeeAsync(model);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await employeeServiceAsync.GetEmployeeByIdAsnc(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeRequestModel model)
        {
            try
            {
                var result = await employeeServiceAsync.DeleteEmployeeAsync(model.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
            
        }
    }
}
