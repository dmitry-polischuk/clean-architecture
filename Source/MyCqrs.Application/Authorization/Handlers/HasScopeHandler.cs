using Microsoft.AspNetCore.Authorization;
using PushNotificationService.Application.Common.Authorization.Requirements;
using System.Linq;
using System.Threading.Tasks;

namespace PushNotificationService.Application.Common.Authorization.Handlers
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            HasScopeRequirement requirement)
        {

            if (!context.User.HasClaim(c => c.Type == "scope" ))
                return Task.CompletedTask;

            var scopes = context.User.FindAll(c => c.Type.ToLower() == "scope").Select(s => s.Value).ToList();

            if (requirement.Scopes.All(s => scopes.Contains(s.ToString().ToLower())))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
