using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace DotNetCoreIdentity.Mvc.Auth
{
    public class AdministratorsHandler : AuthorizationHandler<QualifiedUserRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            QualifiedUserRequirement requirement)
        {
            if (context.User.IsInRole("Administrators"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
