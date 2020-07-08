using System.ComponentModel.DataAnnotations;

namespace DotNetCoreIdentity.Mvc.ViewModels
{
    public class LoginViewModel
    {
        //[Required]
        [Display(Name = "用户名/邮件")]
        public string Email { get; set; }
        [Display(Name = "账号")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "密码")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "记住?")]
        public bool RememberMe { get; set; }
    }
}
