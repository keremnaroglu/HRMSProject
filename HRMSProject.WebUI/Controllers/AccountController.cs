using HRMSProject.Entity.Concrete;
using HRMSProject.ViewModels.AppUserVM;
using HRMSProject.WebUI.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HRMSProject.WebUI.Controllers
{
    public class AccountController : Controller
    {

        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ISendGridEmail _sendGridEmail;

        public AccountController(RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ISendGridEmail sendGridEmail)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
            _sendGridEmail = sendGridEmail;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                AppUser user = _signInManager.UserManager.FindByNameAsync(User.Identity.Name).Result;
                if (_signInManager.UserManager.IsInRoleAsync(user, "SiteManager").Result)
                    return Redirect("/SiteManager");
                else if (_signInManager.UserManager.IsInRoleAsync(user, "CompanyManager").Result)
                    return Redirect("/CompanyManager");
                else if (_signInManager.UserManager.IsInRoleAsync(user, "User").Result)
                    return Redirect("/CompanyUser");
            }
            return View();
        }

        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction(nameof(Index));
        }

        public ClaimsPrincipal GetUser()
        {
            return User;
        }

        [HttpPost]
        public async Task<ActionResult> Index(AppUserLogin vm)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, vm.RememberMe, lockoutOnFailure: true);
                AppUser user = _signInManager.UserManager.FindByNameAsync(vm.UserName).Result;
                if (result.Succeeded)
                {
                    if (_signInManager.UserManager.IsInRoleAsync(user, "SiteManager").Result)
                        return Redirect("/SiteManager");
                    else if (_signInManager.UserManager.IsInRoleAsync(user, "CompanyManager").Result)
                        return Redirect("/CompanyManager");
                    else if (_signInManager.UserManager.IsInRoleAsync(user, "User").Result)
                        return Redirect("/CompanyUser");
                    else
                        return BadRequest();
                }
                //Will be tested if it needs additional view page
                if (result.IsLockedOut)
                {
                    TempData["Locked"] = "Çok sayıda yanlış giriş yaptınız ve hesabınız kilitlendi. Lütfen daha sonra tekrar deneyiniz";
                    return View(vm);
                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }
            return View(vm);
        }

        #region ForgotPassword Controllers

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM vm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(vm.Email);
                if (user == null)
                {
                    RedirectToAction("ForgotPasswordConfirmation");
                }
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackurl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);

                await _sendGridEmail.SendEmailAsync(vm.Email, "Parola Resetleme Onayı", "Lütfen bu linke tıklayarak parolanızı değiştirin." + "<a href=\"" + callbackurl + "\">link</a>");
                return RedirectToAction("ForgotPasswordConfirmation");
            }
            return View(vm);
        }
        [HttpGet]
        public IActionResult ResetPassword(string code = null)
        {
            return code == null ? View("Error") : View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Email", "Kullanıcı bulunamadı.");
                    return View();
                }
                var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Code, resetPasswordViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("ResetPasswordConfirmation");
                }
            }
            return View(resetPasswordViewModel);
        }

        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        #endregion


    }
}
