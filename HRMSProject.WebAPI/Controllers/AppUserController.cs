 
using HRMSProject.BLL.Abstract;
using HRMSProject.DAL;
using HRMSProject.ViewModels.AppUserVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Syst;

namespace HRMSProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : Controller
    {
        private readonly IUserService _userService;
        public AppUserController(IUserService service)
        {
            _userService = service;
        }
        

        [Route("summary/{id:Guid}")] 
        [HttpGet]
        public ActionResult<AppUserSummary> GetAppUserSummaryById(Guid id) 
        {
            if (id == null)
            {
                return BadRequest();
            }
            AppUserSummary appUserSummary = _userService.GetSummaryById(id).Data;
            if (appUserSummary == null)
            {
                return NotFound();
            }

            return appUserSummary;
        }
        [Route("detail/{id:Guid}")] 
        [HttpGet]
        public ActionResult<AppUserDetail> GetAppUserDetailById(Guid id) 
        {
            if (id == null)
            {
                return BadRequest();
            }
            AppUserDetail appUserDetail = _userService.GetDetailById(id).Data;
            if (appUserDetail == null)
            {
                return NotFound();
            }

            return appUserDetail;
        }
        
        [HttpPut]
        public ActionResult<AppUserUpdate> PutUser(AppUserUpdate user)
        {
           
            _userService.UpdateAppUser(user);

            return user;
        }

      

    }
}
