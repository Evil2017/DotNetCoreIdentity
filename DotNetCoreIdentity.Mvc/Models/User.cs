using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreIdentity.Mvc.Models
{
    public class User : IdentityUser<int>
    {
        // 学号
        //Identity中已经存在的方法，要重写override
        [Required]
        public override string UserName { get; set; }

        //姓名
        [Required]
        public string Name { get; set; }

        //手机号
        //Identity中已经存在的方法，要重写override
        [StringLength(14, MinimumLength = 11)]
        public override string PhoneNumber { get; set; }

        //邮箱
        //Identity中已经存在的方法，要重写override
        public override string Email { get; set; }
    }
}
