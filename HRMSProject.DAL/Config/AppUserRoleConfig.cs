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
	public class AppUserRoleConfig : IEntityTypeConfiguration<AppUserRole>
	{
		public void Configure(EntityTypeBuilder<AppUserRole> builder)
		{
			//builder.HasData(
			//	new AppUserRole
			//	{
			//		RoleId = Guid.Parse("887eca9d-f2fd-4575-a8ff-b27ce9879512"),
			//		UserId = Guid.Parse("04be0cbb-c8db-47df-9e3c-5ed62327b6ad")
			//	}
			//	);
		}
	}
}
