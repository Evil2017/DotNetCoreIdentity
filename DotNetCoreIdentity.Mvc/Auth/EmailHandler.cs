using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreIdentity.Mvc.Auth
{
    public class EmailHandler : AuthorizationHandler<EmailRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            EmailRequirement requirement)
        {
            var claim = context.User.Claims.FirstOrDefault(x => x.Type == "Email");

            if (claim != null)
            {
                if (claim.Value.EndsWith(requirement.RequiredEmail))
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }

    }
}
