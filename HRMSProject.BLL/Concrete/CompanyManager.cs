using AutoMapper;
using HRMSProject.BLL.Abstract;
using HRMSProject.DAL.Concrete.Repositories.Abstract;
using HRMSProject.Entity.Concrete;
using HRMSProject.ViewModels.CompanyVM;
using Syst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.BLL.Concrete
{
	public class CompanyManager : ICompanyService
	{
		private readonly ICompanyRepository _companyRepository;
		private readonly IMapper _mapper;
		public CompanyManager(ICompanyRepository companyRepository, IMapper mapper)
		{
			_companyRepository = companyRepository;
			_mapper = mapper;
		}
        public ResultService<CompanySummary> GetAll()
        {
            ResultService<CompanySummary> result = new ResultService<CompanySummary>();
            
            List<Company> companies = _companyRepository.GetAll().ToList();
            if (companies != null)
            {
                result.ListData = _mapper.Map<List<CompanySummary>>(companies);
            }
            else
            {
                result.AddError("Hata Oluştu", "Kayıt bulunamadı.");
            }
            return result;

        }

        public ResultService<CompanyCreate> Add(CompanyCreate entity)
		{
			ResultService<CompanyCreate> result= new ResultService<CompanyCreate>();
			try
			{
				Company company = _mapper.Map<Company>(entity);
				company.Id=Guid.NewGuid();
				_companyRepository.Add(company);
				result.Data = entity;
			}
			catch (Exception)
			{
				result.AddError("Hata Oluştu", "Ekleme işlemi başarısız");
			}
			return result;
		}

		public ResultService<CompanyDetail> GetDetailById(Guid id)
		{
			ResultService<CompanyDetail> result = new ResultService<CompanyDetail>();
			Company company = _companyRepository.Get(x => x.Id == id);
			if (company != null)
			{
				result.Data = _mapper.Map<CompanyDetail>(company);
			}
			else
			{
				result.AddError("Hata Oluştu", "Kayıt bulunamadı.");
			}
			return result;
		}

		public ResultService<CompanySummary> GetSummaryById(Guid id)
		{
			ResultService<CompanySummary> result = new ResultService<CompanySummary>();
			Company company = _companyRepository.Get(x => x.Id == id);
			if (company != null)
			{
				result.Data = _mapper.Map<CompanySummary>(company);
			}
			else
			{
				result.AddError("Hata Oluştu", "Kayıt bulunamadı.");
			}
			return result;
		}

		public ResultService<CompanyUpdate> UpdateCompany(CompanyUpdate vm)
		{
			ResultService<CompanyUpdate> result = new ResultService<CompanyUpdate>();
			try
			{
				Company company = _companyRepository.Get(x => x.Id == vm.Id);
				company.CompanyName = vm.CompanyName;
				company.CompanyTitle = vm.CompanyTitle;
				company.MersisNo = vm.MersisNo;
				company.TaxNo = vm.TaxNo;
				company.TaxOffice = vm.TaxOffice;
				company.Photo = company.Photo;
				company.Phone = vm.Phone;
				company.Adress = vm.Adress;
				company.EMail = vm.EMail;
				company.EmployeeNumber = vm.EmployeeNumber;
				company.FoundationYear = vm.FoundationYear;
				company.ContractStartDate = vm.ContractStartDate;
				company.ContractEndDate = vm.ContractEndDate;
				company.IsActive = vm.IsActive;
				_companyRepository.Update(company);
				result.Data = vm;
			}
			catch (Exception)
			{
				result.Data = vm;
				result.AddError("Güncelleme Hatası", "Güncelleme işlemi başarısız.");
			}
			return result;
		}
	}
}
