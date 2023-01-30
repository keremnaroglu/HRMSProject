using HRMSProject.Entity.Concrete;
using HRMSProject.ViewModels.CompanyVM;
using Syst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.BLL.Abstract
{
	public interface ICompanyService
	{
		ResultService<CompanyCreate> Add(CompanyCreate entity);
		ResultService<CompanyDetail> GetDetailById(Guid id);
		ResultService<CompanySummary> GetSummaryById(Guid id);
		ResultService<CompanyUpdate> UpdateCompany(CompanyUpdate vm);
        ResultService<CompanySummary> GetAll();
    }
}
