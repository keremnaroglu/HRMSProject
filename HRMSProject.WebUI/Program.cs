using HRMSProject.BLL.MappingProfile;
using HRMSProject.DAL;
using HRMSProject.Entity.Concrete;
using HRMSProject.WebUI.Helpers;
using HRMSProject.WebUI.Interfaces;
using HRMSProject.WebUI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HRMSDbContext>();
builder.Services.AddIdentity<AppUser, AppRole>()
		.AddEntityFrameworkStores<HRMSDbContext>()
		.AddDefaultTokenProviders()
		.AddUserStore<UserStore<AppUser, AppRole, HRMSDbContext, Guid, IdentityUserClaim<Guid>, AppUserRole, IdentityUserLogin<Guid>, IdentityUserToken<Guid>, IdentityRoleClaim<Guid>>>()
		.AddRoleStore<RoleStore<AppRole, HRMSDbContext, Guid, AppUserRole, IdentityRoleClaim<Guid>>>()
		.AddSignInManager();

//Injection for Email SendGrid Service
builder.Services.AddTransient<ISendGridEmail, SendGridEmail>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration.GetSection("SendGrid"));

#region Identity options Configuration
builder.Services.Configure<IdentityOptions>(options =>
{
	options.Password.RequiredLength = 8;
	options.Password.RequireLowercase = true;
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
	options.Lockout.MaxFailedAccessAttempts = 5;
	//options.SignIn.RequireConfirmedAccount = true;
});
#endregion


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapAreaControllerRoute(
		name: "areas",
		areaName: "SiteManager",
		pattern: "sitemanager/{controller=Home}/{action=Index}/{id?}");

	endpoints.MapAreaControllerRoute(
			name: "areas",
			areaName: "CompanyManager",
			pattern: "CompanyManager/{controller=Home}/{action=Index}/{id?}"
		  );
	endpoints.MapAreaControllerRoute(
			name: "areas",
			areaName: "CompanyUser",
			pattern: "CompanyUser/{controller=Home}/{action=Index}/{id?}"
		  );

	app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Account}/{action=Index}/{id?}");

});

app.Run();
