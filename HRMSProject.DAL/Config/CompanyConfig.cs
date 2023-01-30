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
	public class CompanyConfig : IEntityTypeConfiguration<Company>
	{
		public static byte[] ReadFile(string sPath)
		{
			byte[] data = null;
			FileInfo fInfo = new FileInfo(sPath);
			long numBytes = fInfo.Length;
			FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
			BinaryReader br = new BinaryReader(fStream);
			data = br.ReadBytes((int)numBytes);
			fStream.Close();
			br.Close();
			return data;
		}
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder.Property(c => c.Id).IsRequired();
			builder.HasKey(c => c.Id);
			builder.Property(c => c.CompanyName).HasMaxLength(50).IsRequired().IsUnicode();
			builder.Property(c => c.CompanyTitle).HasMaxLength(50).IsRequired().IsUnicode();
			builder.Property(c => c.MersisNo).HasMaxLength(25).IsUnicode().IsRequired();
			builder.Property(c => c.TaxNo).HasMaxLength(25).IsUnicode().IsRequired();
			builder.Property(c => c.TaxOffice).HasMaxLength(100).IsUnicode().IsRequired();
			builder.Property(c => c.Phone).IsRequired();
			builder.Property(c => c.Adress).IsRequired();
			builder.Property(c => c.EMail).IsRequired();
			builder.Property(c => c.EmployeeNumber).IsRequired();
			builder.Property(c => c.FoundationYear).IsRequired().HasColumnType("date");
			builder.Property(c => c.ContractStartDate).IsRequired().HasColumnType("date");
			builder.Property(c => c.ContractEndDate).IsRequired().HasColumnType("date");
			builder.Property(c => c.IsActive).IsRequired().HasDefaultValue(true);
			builder.HasMany(c => c.appUsers).WithOne(u => u.Company).HasForeignKey(u => u.CompanyId);

			//builder.HasData(
			//	new Company
			//	{
			//		Id = Guid.Parse("c8087a98-198b-48fa-b552-0ddf75bf269b"),
			//		CompanyName = "Bilge Adam Bilgisayar ve Eğitim Hizmetleri",
			//		CompanyTitle = "Sanayi ve Ticaret Anonim Şirketi",
			//		MersisNo = "0171022969900017",
			//		TaxNo = "1710229699",
			//		TaxOffice = "Sarıyer Vergi Dairesi Müdürlüğü",
			//		Phone = "444 33 30",
			//		Adress = "Reşitpaşa Mahallesi Katar Caddesi B301/4 İstanbul/Sarıyer",
			//		EMail = "info@bilgeadam.com",
			//		EmployeeNumber = 500,
			//		FoundationYear = new DateTime(2003, 12, 22),
			//		ContractStartDate = new DateTime(2023, 01, 05),
			//		ContractEndDate = new DateTime(2024, 01, 05),
			//		IsActive = true,
			//		Photo = ReadFile("Resources/ba-logo.png")
			//	},
			//	new Company
			//	{
			//		Id = Guid.Parse("8bb609f9-79ef-473b-9a99-2caea184e6fd"),
			//		CompanyName = "Bige Adam Boost",
			//		CompanyTitle = "Sanayi ve Ticaret Anonim Şirketi",
			//		MersisNo = "0171022969900017",
			//		TaxNo = "1710229699",
			//		TaxOffice = "Sarıyer Vergi Dairesi Müdürlüğü",
			//		Phone = "444 33 30",
			//		Adress = "Reşitpaşa Mahallesi Katar Caddesi B301/4 İstanbul/Sarıyer",
			//		EMail = "info@bilgeadamboost.com",
			//		EmployeeNumber = 500,
			//		FoundationYear = new DateTime(2003, 12, 22),
			//		ContractStartDate = new DateTime(2023, 01, 05),
			//		ContractEndDate = new DateTime(2024, 01, 05),
			//		IsActive = true,
			//		Photo = ReadFile("Resources/ba-logo.png")
			//	});
		}
	}
}
