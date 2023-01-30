using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.ViewModels.CompanyVM
{
	public class CompanyCreate
	{
		[MaxLength(50,ErrorMessage ="Şirket Adı 50 Karakterden Uzun Olamaz.")]
		public string CompanyName { get; set; }

		[MaxLength(50,ErrorMessage ="Şirket Ünvanı 50 Karakterden Uzun Olamaz.")]
		public string CompanyTitle { get; set; }

		[Range(1,25,ErrorMessage ="Mersis Numarası 25 Karakterden Uzun Olamaz.")]
		public string MersisNo { get; set; }

		[Range(1,25,ErrorMessage ="Vergi Numarası 25 Karakterden Uzun Olamaz.")]
		public string TaxNo { get; set; }

		[MaxLength(100,ErrorMessage ="Vergi Dairesi Adı 100 Karakterden Uzun Olamaz.")]
		public string TaxOffice { get; set; }

		[Required(ErrorMessage ="Fotoğraf Alanı Boş Geçilemez.")]
		public byte[]? Photo { get; set; }

		[Phone(ErrorMessage = "Lütfen Geçerli Bir Telefon Numarası Giriniz.")]
		public string Phone { get; set; }

		[MinLength(2,ErrorMessage = "Lütfen Geçerli Bir Adres Giriniz.")]
		public string Adress { get; set; }

		[EmailAddress(ErrorMessage = "Lütfen Geçerli Bir EMail Adresi Giriniz.")]
		public string EMail { get; set; }

		[Required(ErrorMessage ="Çalışan Sayısı Boş Geçilemez.")]
		public int EmployeeNumber { get; set; }

		[Required(ErrorMessage ="Kuruluş Yılı Boş Geçilemez.")]
		public DateTime FoundationYear { get; set; }

		[Required(ErrorMessage ="Sözleşme Başlangıç Tarihi Boş Geçilemez.")]
		public DateTime ContractStartDate { get; set; }

		[Required(ErrorMessage ="Sözleşme Bitiş Tarihi Boş Geçilemez.")]
		public DateTime ContractEndDate { get; set; }

		[Required(ErrorMessage ="Aktiflik Durumu Boş Bırakılamaz.")]
		public bool IsActive { get; set; }
	}
}
