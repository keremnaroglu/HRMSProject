using HRMSProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.ViewModels.AppUserVM.SiteManagerVM
{
	public class CompanyManagerCreate
	{
		[Display(Name ="Ad")]
		[Required(ErrorMessage ="Lütfen bir isim giriniz")]
		public string Name { get; set; }


		[Display(Name ="İkinci Ad")]
		public string? SecondName { get; set; }


		[Display(Name ="Soyad")]
		[Required(ErrorMessage = "Lütfen bir soyisim giriniz")]
		public string LastName { get; set; }


		[Display(Name = "İkinci Soyad")]
		public string? SecondLastName { get; set; }


		[Display(Name = "T.C. Kimlik Numarası")]
		[Required(ErrorMessage = "Lütfen bir kimlik numarası giriniz")]
		public string IdentityNumber { get; set; }

		[Display(Name = "Doğum Tarihi")]
		[Required(ErrorMessage = "lütfen bir doğum tarihi seçiniz")]
		public DateTime BirthDate { get; set; }

		[Display(Name = "Doğum Yeri")]
		[Required(ErrorMessage = "Lütfen bir doğum yeri giriniz")]
		public string BirthPlace { get; set; }


		[Display(Name ="Fotoğraf")]
		public byte[]? Photo { get; set; }


		[Display(Name ="Telefon Numarası")]
		[Phone(ErrorMessage = "Lütfen bir telefon numarası giriniz.")]
		public string PhoneNumber { get; set; }


		[Display(Name = "Adres")]
		[MinLength(2, ErrorMessage = "Lütfen bir adres giriniz.")]
		public string Address { get; set; }


		[Display(Name = "E-Mail")]
		[EmailAddress(ErrorMessage = "Lütfen bir mail adresi giriniz.")]
		public string Email { get; set; }


		[Display(Name = "Meslek")]
		[Required(ErrorMessage = "Lütfen bir meslek giriniz")]
		public string Profession { get; set; }


		[Display(Name = "Departman")]
		[Required(ErrorMessage = "Lütfen bir departman giriniz")]
		public string Department { get; set; }


		[Display(Name = "İşe Giriş Tarihi")]
		[Required(ErrorMessage = "Lütfen bir işe başlangıç tarihi seçiniz.")]
		public DateTime RecruitmentDate { get; set; }

		[Display(Name = "Aktiflik Durumu")]
		[Required(ErrorMessage = "")]
		public bool IsActive => true;


		public Guid CompanyId { get; set; }

	}
}
