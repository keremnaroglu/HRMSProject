using AutoMapper;
using HRMSProject.Entity.Concrete;
using HRMSProject.ViewModels.AppUserVM;
using HRMSProject.ViewModels.AppUserVM.SiteManagerVM;
using HRMSProject.ViewModels.CompanyVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.BLL.MappingProfile
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<AppUser, AppUserDetail>();
			CreateMap<AppUser, AppUserSummary>();

			CreateMap<Company, CompanyDetail>();
			CreateMap<Company, CompanySummary>();
			CreateMap<Company, CompanyCreate>();

			CreateMap<CompanyManagerCreate, AppUser>();
		}
	}
}