using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetByIdTechnology;
using Application.Features.Technologies.Queries.GetListTechnology;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TechnologiesController:BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTechnologyQuery getListTechnology = new() {PageRequest = pageRequest};
        TechnologyListModel technologyListModel = await Mediator!.Send(getListTechnology);
        return Ok(technologyListModel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdTechnologyQuery getByIdTechnologyQuery)
    {
        TechnologyGetByIdDto technologyGetByIdDto = await Mediator!.Send(getByIdTechnologyQuery);
        return Ok(technologyGetByIdDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
    {
        CreatedTechnologyDto result = await Mediator!.Send(createTechnologyCommand);

        return Created("", result);
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
    {
        UpdatedTechnologyDto result = await Mediator!.Send(updateTechnologyCommand);

        return Created("", result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromRoute] DeleteTechnologyCommand deleteTechnologyCommand)
    {
        DeletedTechnologyDto result = await Mediator!.Send(deleteTechnologyCommand);

        return Created("", result);
    }
}