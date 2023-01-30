using HRMSProject.WebAPI.Models;
using HRMSProject.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMSProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [Route("SendEmail")]
        [HttpPost]
        public IActionResult SendEmail(SendEmail request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }
        //dummykun@outlook.com
        //Dummydes54123.
    }
}
