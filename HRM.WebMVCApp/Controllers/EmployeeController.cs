using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRM.WebMVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServiceAsync employeeServiceAsync;
        private readonly IEmployeeTypeServiceAsync employeeTypeServiceAsync;
        private readonly IEmployeeStatusServiceAsync employeeStatusServiceAsync;
        private readonly IEmployeeRoleServiceAsync employeeRoleServiceAsync;

        public EmployeeController(IEmployeeServiceAsync _employeeServiceAsync, IEmployeeTypeServiceAsync _employeeTypeServiceAsync, IEmployeeStatusServiceAsync _employeeStatusServiceAsync, IEmployeeRoleServiceAsync _employeeRoleServiceAsync)
        {
            employeeServiceAsync = _employeeServiceAsync;
            employeeTypeServiceAsync = _employeeTypeServiceAsync;
            employeeStatusServiceAsync = _employeeStatusServiceAsync;
            employeeRoleServiceAsync = _employeeRoleServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var employeeCollection = await employeeServiceAsync.GetAllEmployeesAsync();
            return View(employeeCollection);
        }

        public async Task<IActionResult> Create()
        {
            await GetAllViewBagValues();
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
            await GetAllViewBagValues();
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
            await GetAllViewBagValues();
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

        [NonAction]
        public async Task GetEmployeeTypeStatus()
        {
            ViewBag.EmployeeTypeList = new SelectList(await employeeTypeServiceAsync.GetAllEmployeeTypesAsync(), "Id", "Title");
        }

        [NonAction]
        public async Task GetEmployeeRoleStatus()
        {
            ViewBag.EmployeeRoleList = new SelectList(await employeeRoleServiceAsync.GetAllEmployeeRolesAsync(), "Id", "Title");
        }

        [NonAction]
        public async Task GetEmployeeStatusStatus()
        {
            ViewBag.EmployeeStatusList = new SelectList(await employeeStatusServiceAsync.GetAllEmployeeStatussAsync(), "Id", "Title");
        }

        [NonAction]
        public async Task GetEmployee()
        {
            var result = await employeeServiceAsync.GetAllEmployeesAsync();
            ViewBag.ManagerList = new SelectList(result.Select(x => new { Id = x.Id, Name = x.FirstName + " " + x.LastName }), "Id", "Name");

        }

        public async Task GetAllViewBagValues()
        {
            await GetEmployee();
            await GetEmployeeTypeStatus();
            await GetEmployeeRoleStatus();
            await GetEmployeeStatusStatus();
        }
    }
}
