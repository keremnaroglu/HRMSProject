using HRMSProject.WebAPI.Models;

namespace HRMSProject.WebAPI.Services
{
    public interface IEmailService
    {
        void SendEmail(SendEmail request);
    }
}
