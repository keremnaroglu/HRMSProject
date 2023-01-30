using HRMSProject.ViewModels.AppUserVM;
using Syst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.BLL.Abstract
{
    public interface IUserService
    {
        ResultService<AppUserDetail> GetDetailById(Guid id);
        ResultService<AppUserSummary> GetSummaryById(Guid id);
        ResultService<AppUserUpdate> UpdateAppUser(AppUserUpdate vm);
    }
}
