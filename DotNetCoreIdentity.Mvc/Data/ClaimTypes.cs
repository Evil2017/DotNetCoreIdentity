using System.Collections.Generic;

namespace DotNetCoreIdentity.Mvc.Data
{
    public static class ClaimTypes
    {
        public static List<string> AllClaimTypeList { get; set; } = new List<string>
        {
            "Edit Albums",
            "Edit Users",
            "Edit Roles",
            "Email"
        };
    }
}
