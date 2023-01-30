using HRMSProject.DAL.Config;
using HRMSProject.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.DAL
{
	public class HRMSDbContext : IdentityDbContext<AppUser,AppRole,Guid,IdentityUserClaim<Guid>,AppUserRole,IdentityUserLogin<Guid>,IdentityRoleClaim<Guid>,IdentityUserToken<Guid>>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer
				(@"Server=tcp:hrmsql.database.windows.net,1433;
				Initial Catalog=HRMSDatabase;
				Persist Security Info=False;
				User ID=hrmsadmin;
				Password=Hrms125698743;
				MultipleActiveResultSets=False;
				Encrypt=True;TrustServerCertificate=False;"
				);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Custom context class inherit from IdentityDbContext<ApplicationUser, Role, TKey> and use fluent api for auto generate guid keys.
			base.OnModelCreating(modelBuilder);
			new AppUserRoleConfig().Configure(modelBuilder.Entity<AppUserRole>());
			new AppUserConfig().Configure(modelBuilder.Entity<AppUser>());
			new CompanyConfig().Configure(modelBuilder.Entity<Company>());
			new AppRoleConfig().Configure(modelBuilder.Entity<AppRole>());
		}
	}
}
