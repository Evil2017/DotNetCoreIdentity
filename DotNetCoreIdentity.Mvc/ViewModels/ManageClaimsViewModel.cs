using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreIdentity.Mvc.ViewModels
{
    public class ManageClaimsViewModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ClaimId { get; set; }

        public List<string> AvailableClaims { get; set; }
    }
}
