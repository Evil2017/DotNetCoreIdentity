using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreIdentity.Mvc.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            Claims = new List<IdentityUserClaim<int>>();
            Logins = new List<IdentityUserLogin<int>>();
            Tokens = new List<IdentityUserToken<int>>();
            UserRoles = new List<IdentityUserRole<int>>();
        }

        [MaxLength(18)]
        public string IdCardNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public ICollection<IdentityUserClaim<int>> Claims { get; set; }
        public ICollection<IdentityUserLogin<int>> Logins { get; set; }
        public ICollection<IdentityUserToken<int>> Tokens { get; set; }
        public ICollection<IdentityUserRole<int>> UserRoles { get; set; }
        public string Name { get; internal set; }
    }
}
