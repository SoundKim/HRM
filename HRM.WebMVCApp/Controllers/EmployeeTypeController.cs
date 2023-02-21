using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class EmployeeTypeController : Controller
    {
        private readonly IEmployeeTypeServiceAsync employeeTypeServiceAsync;

        public EmployeeTypeController(IEmployeeTypeServiceAsync _employeeTypeServiceAsync)
        {
            employeeTypeServiceAsync = _employeeTypeServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var employeeTypeCollection = await employeeTypeServiceAsync.GetAllEmployeeTypesAsync();
            return View(employeeTypeCollection);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeTypeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeTypeServiceAsync.AddEmployeeTypeAsync(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await employeeTypeServiceAsync.GetEmployeeTypeByIdAsnc(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeTypeRequestModel model)
        {
            try
            {
                await employeeTypeServiceAsync.UpdateEmployeeTypeAsync(model);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await employeeTypeServiceAsync.GetEmployeeTypeByIdAsnc(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeTypeRequestModel model)
        {
            try
            {
                var result = await employeeTypeServiceAsync.DeleteEmployeeTypeAsync(model.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
            
        }
    }
}
