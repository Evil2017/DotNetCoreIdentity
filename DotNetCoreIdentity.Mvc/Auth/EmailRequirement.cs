using Microsoft.AspNetCore.Authorization;

namespace DotNetCoreIdentity.Mvc.Auth
{
    public class EmailRequirement : IAuthorizationRequirement
    {
        public string RequiredEmail { get; set; }

        public EmailRequirement(string requiredEmail)
        {
            RequiredEmail = requiredEmail;
        }
    }
}
