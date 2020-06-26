using System.ComponentModel.DataAnnotations;

namespace DotNetCoreIdentity.Mvc.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "学号")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "手机号")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "Password Error")]
        public string ConfirmPassword { get; set; }
    }
}
