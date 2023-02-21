using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly IUserRoleServiceAsync userRoleServiceAsync;

        public UserRoleController(IUserRoleServiceAsync _userRoleServiceAsync)
        {
            userRoleServiceAsync = _userRoleServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var userRoleCollection = await userRoleServiceAsync.GetAllUserRolesAsync();
            return View(userRoleCollection);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRoleRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await userRoleServiceAsync.AddUserRoleAsync(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await userRoleServiceAsync.GetUserRoleByIdAsnc(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserRoleRequestModel model)
        {
            try
            {
                await userRoleServiceAsync.UpdateUserRoleAsync(model);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await userRoleServiceAsync.GetUserRoleByIdAsnc(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserRoleRequestModel model)
        {
            try
            {
                var result = await userRoleServiceAsync.DeleteUserRoleAsync(model.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
            
        }
    }
}
