using AutoMapper;
using HRMSProject.Entity.Concrete;
using HRMSProject.ViewModels.AppUserVM.SiteManagerVM;
using HRMSProject.ViewModels.CompanyVM;
using HRMSProject.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace HRMSProject.WebUI.Areas.SiteManager.Controllers
{
    [Area("SiteManager")]
    [Authorize(Roles = "SiteManager")]
    public class CompanyManagerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public CompanyManagerController(UserManager<AppUser> usermanager, IMapper mapper, RoleManager<AppRole> rolemanager, SignInManager<AppUser> signinmanager)
        {
            _userManager = usermanager;
            _mapper = mapper;
            _roleManager = rolemanager;
            _signInManager = signinmanager;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<AppUser> appUser = await _userManager.GetUsersInRoleAsync("CompanyManager");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://hrmsprojectwebapi03012023.azurewebsites.net/");
                var response = client.GetAsync("api/Company/getall");
                response.Wait();
                var resultTask = response.Result;
                if (resultTask.IsSuccessStatusCode)
                {
                    var readTask = resultTask.Content.ReadAsAsync<List<CompanySummary>>();
                    readTask.Wait();
                    ViewData["CompanyList"] = readTask.Result;
                    return View(appUser);

                }
                else
                {
                    return NotFound();
                }
            }
        }
        public IActionResult CompanyManagerCreate()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://hrmsprojectwebapi03012023.azurewebsites.net/");
                var response = client.GetAsync("api/Company/getall");
                response.Wait();
                var resultTask = response.Result;
                if (resultTask.IsSuccessStatusCode)
                {
                    var readTask = resultTask.Content.ReadAsAsync<List<CompanySummary>>();
                    readTask.Wait();
                    ViewData["CompanyList"] = new SelectList(readTask.Result, "id", "CompanyName");
                    return View(new CompanyManagerCreate());
                }
                else
                {
                    return NotFound();
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> CompanyManagerCreate(CompanyManagerCreate companyManagerCreate)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser = _mapper.Map<AppUser>(companyManagerCreate);
                appUser.UserName = companyManagerCreate.Email.ToString();
                string password = "Test61.34";//random password generator will be called here
                IdentityResult result = await _userManager.CreateAsync(appUser, password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, "CompanyManager");

					SendEmail sendEmail = new SendEmail()
					{
						To = appUser.UserName,
						Subject = "HRMS activation and password",
						Body = "Link buraya\n\n" + $"Giriş Şifreniz ={password}"
					};
					using (var client = new HttpClient())
                    {
                        
                        client.BaseAddress = new Uri("https://hrmsprojectwebapi03012023.azurewebsites.net/");
                        var response = client.PostAsJsonAsync<SendEmail>("api/Email/SendEmail", sendEmail);
                        response.Wait();
                        var resultTask = response.Result;
                        if(resultTask.IsSuccessStatusCode)
                        {
							return Redirect("/SiteManager");
						}
                    }
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(companyManagerCreate);
        }

    }
}
