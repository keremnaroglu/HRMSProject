using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.ViewModels.CompanyVM
{
	public class CompanySummary
	{
        public Guid id { get; set; }
        public byte[]? Photo { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
    }
}
