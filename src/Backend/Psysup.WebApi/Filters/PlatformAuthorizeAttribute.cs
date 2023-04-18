using Microsoft.AspNetCore.Authorization;
using Psysup.Domain.Enums;

namespace Psysup.WebApi.Filters;

public class PlatformAuthorizeAttribute : AuthorizeAttribute
{
    public PlatformAuthorizeAttribute()
    {
    }

    public PlatformAuthorizeAttribute(Roles roles)
    {
        Roles = roles.ToString();
    }
}