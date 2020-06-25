using System.ComponentModel.DataAnnotations;

namespace DotNetCoreIdentity.Mvc.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "账号")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "密码")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
