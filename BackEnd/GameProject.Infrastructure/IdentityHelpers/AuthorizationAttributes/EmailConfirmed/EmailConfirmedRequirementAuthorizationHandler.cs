using GameProject.Identity.IdentityHelpers.Claims;
using Microsoft.AspNetCore.Authorization;

namespace GameProject.Identity.IdentityHelpers.AuthorizationAttributes.EmailConfirmed;

public class EmailConfirmedRequirementAuthorizationHandler : AuthorizationHandler<EmailConfirmedAttribute>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmailConfirmedAttribute requirement)
    {
        var emailConfirmedClaim = context.User.Claims.FirstOrDefault(claim => claim.Type == ApplicationClaims.EmailConfirmed);

        if (emailConfirmedClaim == null)
        {
            return Task.CompletedTask;
        }

        if (bool.TryParse(emailConfirmedClaim.Value, out bool _))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;    }
}