using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Psysup.WebApi.Controllers;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
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
}