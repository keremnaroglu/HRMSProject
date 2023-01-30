using HRMSProject.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.DAL.Config
{
	public class AppUserConfig : IEntityTypeConfiguration<AppUser>
	{
		public static byte[] ReadFile(string sPath)
		{
			//Initialize byte array with a null value initially.
			byte[] data = null;

			//Use FileInfo object to get file size.
			FileInfo fInfo = new FileInfo(sPath);
			long numBytes = fInfo.Length;

			//Open FileStream to read file
			FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

			//Use BinaryReader to read file stream into byte array.
			BinaryReader br = new BinaryReader(fStream);

			//When you use BinaryReader, you need to supply number of bytes
			//to read from file.
			//In this case we want to read entire file. 
			//So supplying total number of bytes.
			data = br.ReadBytes((int)numBytes);
			fStream.Close();
			br.Close();
			return data;
		}
		public void Configure(EntityTypeBuilder<AppUser> builder)
		{
			builder.Property(u => u.Name).HasMaxLength(25).IsRequired().IsUnicode();
			builder.Property(u => u.LastName).HasMaxLength(25).IsRequired().IsUnicode();
			builder.Property(u => u.SecondName).HasMaxLength(25).IsUnicode();
			builder.Property(u => u.SecondLastName).HasMaxLength(25).IsUnicode();
			builder.Property(u => u.IdentityNumber).IsRequired();
			builder.Property(u => u.BirthDate).IsRequired().HasColumnType("date");
			builder.Property(u => u.BirthPlace).IsRequired().HasMaxLength(50);
			builder.Property(u => u.PhoneNumber).IsRequired();
			builder.Property(u => u.Address).IsRequired();
			builder.Property(u => u.Email).IsRequired();
			builder.Property(u => u.Profession).IsRequired();
			builder.Property(u => u.Department).IsRequired();
			builder.Property(u => u.RecruitmentDate).IsRequired().HasColumnType("date");
			builder.Property(u => u.TerminationDate).HasColumnType("date");
			builder.Property(u => u.IsActive).IsRequired().HasDefaultValue(true);
			builder.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
			builder.HasOne(u => u.Company).WithMany(c => c.appUsers).HasForeignKey(u => u.CompanyId);

			//SiteManager Seed
			//var siteManager = new AppUser
			//{
			//	UserName = "admin@admin.com",
			//	NormalizedUserName = "ADMIN@ADMIN.COM",
			//	Id = Guid.Parse("04be0cbb-c8db-47df-9e3c-5ed62327b6ad"),
			//	Name = "Hüseyin",
			//	LastName = "Erdin",
			//	IdentityNumber = "00000000000",
			//	BirthDate = new DateTime(1996, 09, 04),
			//	BirthPlace = "Samsun",
			//	PhoneNumber = "05301243955",
			//	PhoneNumberConfirmed = true,
			//	Address = "Kocaeli",
			//	Email = "admin@admin.com",
			//	NormalizedEmail = "ADMIN@ADMIN.COM",
			//	Profession = "Site Yöneticisi",
			//	Department = "İnsan Kaynakları",
			//	RecruitmentDate = new DateTime(2022, 08, 01),
			//	IsActive = true,
			//	Photo = ReadFile("Resources/avatar-5.jpg"),
			//	EmailConfirmed = true,
			//	ConcurrencyStamp = Guid.NewGuid().ToString(),
			//	SecurityStamp = Guid.NewGuid().ToString(),
			//	CompanyId = Guid.Parse("c8087a98-198b-48fa-b552-0ddf75bf269b")
			//};
			//siteManager.PasswordHash = CreatePasswordHash(siteManager, "Admin61.");

			//builder.HasData(siteManager);
		}
		//private string CreatePasswordHash(AppUser user, string password)
		//{
		//	var passwordHasher = new PasswordHasher<AppUser>();
		//	return passwordHasher.HashPassword(user, password);
		//}
	}
}
