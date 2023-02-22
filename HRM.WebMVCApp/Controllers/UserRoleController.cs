using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRM.WebMVCApp.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly IUserRoleServiceAsync userRoleServiceAsync;
        private readonly IRoleServiceAsync roleServiceAsync;
        private readonly IUserServiceAsync userServiceAsync;

        public UserRoleController(IUserRoleServiceAsync _userRoleServiceAsync, IRoleServiceAsync _roleServiceAsync, IUserServiceAsync _userServiceAsync)
        {
            userRoleServiceAsync = _userRoleServiceAsync;
            roleServiceAsync = _roleServiceAsync;
            userServiceAsync = _userServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var userRoleCollection = await userRoleServiceAsync.GetAllUserRolesAsync();
            return View(userRoleCollection);
        }

        public async Task<IActionResult> Create()
        {
            await GetAllViewBagValues();
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
            await GetAllViewBagValues();
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
            await GetAllViewBagValues();
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

        [NonAction]
        public async Task GetUser()
        {
            ViewBag.UserList = new SelectList(await userServiceAsync.GetAllUsersAsync(), "Id", "Username");
        }

        [NonAction]
        public async Task GetRole()
        {
            ViewBag.RoleList = new SelectList(await roleServiceAsync.GetAllRolesAsync(), "Id", "Name");
        }

        public async Task GetAllViewBagValues()
        {
            await GetUser();
            await GetRole();
        }
    }
}
