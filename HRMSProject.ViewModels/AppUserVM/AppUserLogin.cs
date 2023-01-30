using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.ViewModels.AppUserVM
{
	public class AppUserLogin
	{
		[Required(ErrorMessage ="Kullanıcı adı boş bırakılamaz.")]
		public string UserName { get; set; }
		[Required(ErrorMessage ="Şifre alanı boş bırakılamaz.")]
		public string Password { get; set; }

		public bool RememberMe { get; set; }
	}
}
