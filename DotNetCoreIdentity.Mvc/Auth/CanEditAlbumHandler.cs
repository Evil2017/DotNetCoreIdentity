using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace DotNetCoreIdentity.Mvc.Auth
{
    public class CanEditAlbumHandler : AuthorizationHandler<QualifiedUserRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            QualifiedUserRequirement requirement)
        {
            if (context.User.HasClaim(x => x.Type == "Edit Albums"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
