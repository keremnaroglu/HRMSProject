using HRMSProject.DAL;
using HRMSProject.Entity.Concrete;
using HRMSProject.ViewModels.AppUserVM;
using HRMSProject.ViewModels.CompanyVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Syst;

namespace HRMSProject.WebUI.Areas.SiteManager.Controllers
{
	[Area("SiteManager")]
	[Authorize(Roles = "SiteManager")]
	public class CompanyController : Controller
	{
        public IActionResult Index()
		{
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://hrmsprojectwebapi03012023.azurewebsites.net/");
                var response = client.GetAsync("api/Company/getall");
                response.Wait();
                var resultTask = response.Result;
                if (response.IsCompletedSuccessfully)
                {
                    var readTask = resultTask.Content.ReadAsAsync<List<CompanySummary>>();
					readTask.Wait();
                    return View(readTask.Result);
                }
                else
                {
                    return NotFound();
                }
            }
        }

		public ActionResult Create()
		{
			return View();
		}
		
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(CompanyCreate vm)
		{
			if (ModelState.IsValid)
			{
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri("https://hrmsprojectwebapi03012023.azurewebsites.net/");
					var response = client.PostAsJsonAsync("api/Company/create", vm);
					response.Wait();
					var resultTask = response.Result;
					if (response.IsCompletedSuccessfully)
					{
						return View(vm);
					}
					else
					{
						return NotFound();
					}
				}
			}
			else
			{
				return View(vm);
			}
		}
	}
}
