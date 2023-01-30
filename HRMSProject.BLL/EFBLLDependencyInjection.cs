using HRMSProject.BLL.Abstract;
using HRMSProject.BLL.Concrete;
using HRMSProject.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.BLL
{
    public static class EFBLLDependencyInjection
    {
        public static void AddScopeBLL(this IServiceCollection services)
        {
            services.AddScopedDal();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<ICompanyService, CompanyManager>();
        }
    }
}
