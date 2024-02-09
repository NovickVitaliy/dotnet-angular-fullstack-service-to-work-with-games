using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace GameProject.Identity.IdentityHelpers.AuthorizationAttributes.EmailConfirmed;

public class EmailConfirmedPolicyProvider : IAuthorizationPolicyProvider
{
    private const string PolicyPrefix = "EmailConfirmed";
    public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

    public EmailConfirmedPolicyProvider(IOptions<AuthorizationOptions> options)
    {
        FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
    }
    
    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (policyName.StartsWith(PolicyPrefix, StringComparison.OrdinalIgnoreCase)
            && bool.TryParse(policyName.Substring(PolicyPrefix.Length), out bool emailConfirmedNeeded))
        {
            var policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
            policy.AddRequirements(new EmailConfirmedAttribute(emailConfirmedNeeded));
            return Task.FromResult<AuthorizationPolicy?>(policy.Build());
        }
        return Task.FromResult<AuthorizationPolicy?>(null);
    }

    public async Task<AuthorizationPolicy> GetDefaultPolicyAsync()
    {
        return await FallbackPolicyProvider.GetDefaultPolicyAsync();
    }

    public async Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
    {
        return await FallbackPolicyProvider.GetFallbackPolicyAsync();
    }
}