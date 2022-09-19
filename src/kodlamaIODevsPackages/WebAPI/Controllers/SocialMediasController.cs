using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.SocialMedias.Commands.CreateSocialMedia;
using Application.Features.SocialMedias.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocialMediasController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaCommand createSocialMediaCommand)
        {
            CreatedSocialMediaDto result = await Mediator.Send(createSocialMediaCommand);
             return Ok(result);
        }
    }
}