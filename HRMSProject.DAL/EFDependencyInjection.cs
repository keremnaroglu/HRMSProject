using HRMSProject.DAL.Concrete.Repositories.Abstract;
using HRMSProject.DAL.Concrete.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.DAL
{
    public static class EFDependencyInjection
    {
        public static void AddScopedDal(this IServiceCollection services)
        {
            services.AddDbContext<HRMSDbContext>()
                .AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<HRMSDbContext>()
                .AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}
