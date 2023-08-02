using Customer_Service_API.Attributes;
using Customer_Service.Application.Mediatr.Commands.City;
using Customer_Service.Application.Mediatr.Queries.City;
using Customer_Service.Application.Mediatr.Queries.Customer;
using Customer_Service.DTO.Base;
using Customer_Service.DTO.City;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Service_API.Controllers;

[Route("api/City")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly IMediator _mediator;

    public CityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetCitiesQuery();
        return Ok(await _mediator.Send(query));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetCityByIdQuery() { Id = id };
        var result = await _mediator.Send(query);
        if (result == null)
        {
            return NoContent();
            
        }
            
        return Ok(result);
    }

    [HttpPost]
    [Validation]
    public async Task<IActionResult> AddCity(AddNewCityCommand query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPut]
    [Validation]
    public async Task<IActionResult> UpdateCity(UpdateCityCommand query)
    {
        UpdateCityDto? updatedCityDto =await _mediator.Send(query);
        if (updatedCityDto == null)
        {
            return NoContent();
        }
        
        return Ok(updatedCityDto);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCity(int id)
    {
        DeleteCityCommand command = new DeleteCityCommand() { Id = id };
        bool isDeleted = await _mediator.Send(command);
        ResponseModel model = new ResponseModel()
        {
            StatusCode = isDeleted?200:400,
            Message = isDeleted?"City Deleted":"There is a error while deleting."
        };
        return new ObjectResult(model)
        {
            StatusCode = isDeleted?200:400,
        };
    }
}