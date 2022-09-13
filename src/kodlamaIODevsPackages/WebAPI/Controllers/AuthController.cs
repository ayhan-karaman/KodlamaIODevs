using Application.Features.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController:BaseController
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] CreateUserCommand createUserCommand)
    {
        var accessToken = await Mediator.Send(createUserCommand);
        return Ok(accessToken);
    }
}