using HRMSProject.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.DAL.Config
{
	public class AppRoleConfig : IEntityTypeConfiguration<AppRole>
	{
		public void Configure(EntityTypeBuilder<AppRole> builder)
		{
			builder.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
			//builder.HasData(new AppRole
			//{
			//	Id = Guid.Parse("887eca9d-f2fd-4575-a8ff-b27ce9879512"),
			//	Name = "SiteManager",
			//	NormalizedName = "SITEMANAGER",
			//	ConcurrencyStamp = Guid.NewGuid().ToString()
			//},
			//new AppRole
			//{
			//	Id = Guid.Parse("85e91ac1-7143-49a7-b7d2-ceb5abbea096"),
			//	Name = "CompanyManager",
			//	NormalizedName = "COMPANYMANAGER",
			//	ConcurrencyStamp = Guid.NewGuid().ToString()
			//},
			//new AppRole
			//{
			//	Id = Guid.Parse("b9079b6a-34e5-4b88-89ec-da91daccaaa5"),
			//	Name = "User",
			//	NormalizedName = "USER",
			//	ConcurrencyStamp = Guid.NewGuid().ToString()
			//});
		}
	}
}
