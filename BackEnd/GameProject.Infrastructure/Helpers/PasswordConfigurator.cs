using Microsoft.AspNetCore.Identity;

namespace GameProject.Identity.Helpers;

public static class PasswordConfigurator
{
    public static PasswordOptions ConfigurePasswordOptions(this PasswordOptions passwordOptions)
    {
        passwordOptions.RequireDigit = false;
        passwordOptions.RequiredLength = 4;
        passwordOptions.RequireLowercase = false;
        passwordOptions.RequireNonAlphanumeric = false;
        passwordOptions.RequireUppercase = false;
        passwordOptions.RequiredUniqueChars = 0;

        return passwordOptions;
    }
}