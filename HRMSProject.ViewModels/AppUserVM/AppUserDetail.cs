using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.ViewModels.AppUserVM
{
	public class AppUserDetail
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string? SecondName { get; set; }
		public string LastName { get; set; }
		public string? SecondLastName { get; set; }
		public string IdentityNumber { get; set; }
		public DateTime BirthDate { get; set; }
		public string BirthPlace { get; set; }
		public byte[]? Photo { get; set; }

        [Phone(ErrorMessage = "Lütfen Geçerli Bir Telefon Numarası Giriniz.")]
		public string PhoneNumber { get; set; }

		[MinLength(2,ErrorMessage ="Lütfen Geçerli Bir Adres Giriniz.")]
		public string Address { get; set; }

		[EmailAddress(ErrorMessage ="Lütfen Geçerli Bir EMail Adresi Giriniz.")]
		public string Email { get; set; }
		public string Profession { get; set; }
		public string Department { get; set; }
		public DateTime RecruitmentDate { get; set; }
		public DateTime? TerminationDate { get; set; }
		public bool IsActive { get; set; }
	}
}
