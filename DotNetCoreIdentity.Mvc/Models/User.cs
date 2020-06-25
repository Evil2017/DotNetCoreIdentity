using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreIdentity.Mvc.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }
        [Display(Name = "密码")]
        [Required]
        public string UserPwd { get; set; }
        public string Nothing { get; set; }
    }
}
