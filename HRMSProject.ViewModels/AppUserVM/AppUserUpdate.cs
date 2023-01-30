namespace HRMSProject.ViewModels.AppUserVM
{
	public class AppUserUpdate
	{
		public Guid Id { get; set; }
		public byte[]? Photo { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
	}
}
