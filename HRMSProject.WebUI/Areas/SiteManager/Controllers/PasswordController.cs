using HRMSProject.BLL.Concrete;
using HRMSProject.Entity.Concrete;
using HRMSProject.ViewModels.AppUserVM;
using HRMSProject.ViewModels.ChangePasswordVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSProject.WebUI.Areas.SiteManager.Controllers
{
    [Authorize]
    [Area("SiteManager")]
    public class PasswordController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public PasswordController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(new ChangePassword());
        }

        [HttpPost]
        public async Task<IActionResult> Index(ChangePassword vm)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
                IdentityResult result = await _userManager.ChangePasswordAsync(appUser, vm.CurrentPassword, vm.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", "Hatalı şifre.");
                }
            }
            return View(vm);
        }
    }
}
