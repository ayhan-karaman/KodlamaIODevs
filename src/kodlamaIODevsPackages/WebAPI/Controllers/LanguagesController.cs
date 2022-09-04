using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Dtos.Language.Dtos;
using Application.Features.Languages.Models;
using Application.Features.Languages.Queries.GetListLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController:BaseController
{
      
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListLanguageQuery = new() {PageRequest = pageRequest};
            
            LanguageListModel result = await Mediator.Send(getListLanguageQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreatedLanguageDto result = await Mediator.Send(createLanguageCommand);

            return Created("add", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteLanguageCommand deleteLanguageCommand)
        {
            var result = await Mediator.Send(deleteLanguageCommand);

            return Created("deleted", result);
        }
}