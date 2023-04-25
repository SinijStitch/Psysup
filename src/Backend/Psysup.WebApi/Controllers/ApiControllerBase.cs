using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Psysup.Domain.Enums;

namespace Psysup.WebApi.Controllers;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    private Roles? _roles;
    private Guid _userId;

    protected Guid UserId
    {
        get
        {
            if (_userId != Guid.Empty)
            {
                return _userId;
            }

            var value = HttpContext.User.FindFirstValue("id");

            if (value == null)
            {
                return Guid.Empty;
            }

            return _userId = Guid.Parse(value);
        }
    }

    protected Roles UserRoles
    {
        get
        {
            if (_roles != null)
            {
                return _roles.Value;
            }

            var value = HttpContext.User.FindFirstValue("role");

            if (value == null)
            {
                throw new InvalidOperationException("Role was not found");
            }

            _roles = Enum.Parse<Roles>(value);

            return _roles.Value;
        }
    }
}