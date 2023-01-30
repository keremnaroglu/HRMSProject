using HRMSProject.BLL.Abstract;
using HRMSProject.Entity.Concrete;
using HRMSProject.ViewModels.AppUserVM;
using HRMSProject.ViewModels.CompanyVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMSProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : Controller
	{
		private readonly ICompanyService _companyService;
		public CompanyController(ICompanyService service)
		{
			_companyService = service;
		}

		[Route("create")]
		[HttpPost]
		public IActionResult Create(CompanyCreate vm)
		{
			_companyService.Add(vm);
			return View();
		}

        [Route("getall")]
        [HttpGet]
        public ActionResult<List<CompanySummary>> GetAll()
		{
            if (_companyService.GetAll() == null)
            {
                return NotFound();
			}
			List<CompanySummary> result = _companyService.GetAll().ListData;
			return result;
        }
    }
}
