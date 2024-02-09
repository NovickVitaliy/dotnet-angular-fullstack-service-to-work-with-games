using Microsoft.AspNetCore.Authorization;

namespace GameProject.Identity.IdentityHelpers.AuthorizationAttributes.EmailConfirmed;

public class EmailConfirmedAttribute : AuthorizeAttribute, IAuthorizationRequirement, IAuthorizationRequirementData
{
    public bool EmailConfirmed { get; set; }

    public EmailConfirmedAttribute(bool emailConfirmed)
    {
        EmailConfirmed = emailConfirmed;
    }

    public IEnumerable<IAuthorizationRequirement> GetRequirements()
    {
        yield return this;
    }
}