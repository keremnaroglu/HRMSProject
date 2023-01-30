using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.ViewModels.AppUserVM
{
	public class ForgotPasswordVM
	{
		[Required]
		[EmailAddress,MinLength(3),MaxLength(30)]
		public string Email { get; set; }
	}
}
