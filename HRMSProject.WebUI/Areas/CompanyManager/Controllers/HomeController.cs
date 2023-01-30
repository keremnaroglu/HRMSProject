using HRMSProject.Entity.Concrete;
using HRMSProject.ViewModels.AppUserVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSProject.WebUI.Areas.CompanyManager.Controllers
{
	[Area("CompanyManager")]
	[Authorize(Roles = "CompanyManager")]
	public class HomeController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		public HomeController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		public IActionResult Index()
		{
			var appuser = _userManager.FindByNameAsync(User.Identity.Name);
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://hrmsprojectwebapi03012023.azurewebsites.net/");
				try
				{
					var response = client.GetAsync("api/AppUser/summary/" + appuser.Result.Id);
					response.Wait();
					var resultTask = response.Result;
					if (response.IsCompletedSuccessfully)
					{
						var readTask = resultTask.Content.ReadAsAsync<AppUserSummary>();
						readTask.Wait();
						return View(readTask.Result);
					}
					else
					{
						return NotFound();
					}
				}
				catch (Exception)
				{
					return BadRequest();
				}


			}
		}

		public IActionResult Detail()
		{
			var appuser = _userManager.FindByNameAsync(User.Identity.Name);
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://hrmsprojectwebapi03012023.azurewebsites.net/");
				var response = client.GetAsync("api/AppUser/detail/" + appuser.Result.Id);
				response.Wait();
				var resultTask = response.Result;
				if (response.IsCompletedSuccessfully)
				{
					var readTask = resultTask.Content.ReadAsAsync<AppUserDetail>();
					readTask.Wait();
					return View(readTask.Result);
				}
				else
				{
					return NotFound();
				}
			}
		}

		[HttpPost]
		public async Task<ActionResult> Detail(AppUserDetail vm)
		{
			if (ModelState.IsValid)
			{
				AppUserUpdate appUserUpdate = new AppUserUpdate()
				{
					Id = vm.Id,
					Address = vm.Address,
					PhoneNumber = vm.PhoneNumber,
					Photo = vm.Photo
				};
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri("https://hrmsprojectwebapi03012023.azurewebsites.net/");
					var response = client.PutAsJsonAsync("api/AppUser", appUserUpdate);
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
