using HRMSProject.Core;
using Microsoft.AspNetCore.Identity;

namespace HRMSProject.Entity.Concrete
{
	public class AppUser : IdentityUser<Guid>, IBaseEntity
	{
		public string Name { get; set; }
		public string? SecondName { get; set; }
		public string LastName { get; set; }
		public string? SecondLastName { get; set; }
		public string IdentityNumber { get; set; }
		public DateTime BirthDate { get; set; }
		public string BirthPlace { get; set; }
		public byte[]? Photo { get; set; }
		public string Address { get; set; }
		public string Profession { get; set; }
		public string Department { get; set; }
		public DateTime RecruitmentDate { get; set; }
		public DateTime? TerminationDate { get; set; }
		public bool IsActive { get; set; }
		public Guid CompanyId { get; set; }
		public Company Company { get; set; }
	}
}
