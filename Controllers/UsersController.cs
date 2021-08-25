using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandlingMiddleware.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpGet("get-user")]
    public IActionResult GetUserByUserName(string userName)
    {
        ArgumentNullException.ThrowIfNull(userName);
        return Ok();
    }
}
