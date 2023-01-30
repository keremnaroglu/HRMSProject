using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.ViewModels.CompanyVM
{
	public class CompanyUpdate
	{
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string MersisNo { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public byte[]? Photo { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string EMail { get; set; }
        public int EmployeeNumber { get; set; }
        public DateTime FoundationYear { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
