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
}