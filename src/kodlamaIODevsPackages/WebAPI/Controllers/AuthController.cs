using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Queries.LoginUser;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController:BaseController
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand createUserCommand)
    {
        var accessToken = await Mediator!.Send(createUserCommand);
        return Ok(accessToken);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserQuery loginUserQuery)
    {
        var accessToken = await Mediator!.Send(loginUserQuery);
        return Ok(accessToken);
    }
}