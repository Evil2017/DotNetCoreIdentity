using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreIdentity.Mvc.Models
{
    public class ApplicationUser : IdentityUser<int>
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

        public ApplicationUser()
        {
            Claims = new List<ApplicationUserClaim>();
            Logins = new List<IdentityUserLogin<int>>();
            Tokens = new List<IdentityUserToken<int>>();
            UserRoles = new List<IdentityUserRole<int>>();
        }

        [MaxLength(18)]
        public string IdCardNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public ICollection<ApplicationUserClaim> Claims { get; set; }
        public ICollection<IdentityUserLogin<int>> Logins { get; set; }
        public ICollection<IdentityUserToken<int>> Tokens { get; set; }
        public ICollection<IdentityUserRole<int>> UserRoles { get; set; }
    }
}
