using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.ViewModels.ChangePasswordVM
{
	public class ChangePassword
	{
		[Required(ErrorMessage ="Bu alan boş geçilemez.")]
		public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez."),DataType(DataType.Password),MinLength(6,ErrorMessage ="Şifre 6 karakterden kısa olamaz.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez."), DataType(DataType.Password), Compare("NewPassword",ErrorMessage ="Şifrelerin eşleştiğinden emin olun.")]
        public string NewPasswordConfirm { get; set; }
	}
}
