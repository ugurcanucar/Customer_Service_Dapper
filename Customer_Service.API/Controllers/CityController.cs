using Customer_Service.Application.Mediatr.Commands.City;
using Customer_Service.Application.Mediatr.Queries.City;
using Customer_Service.Application.Mediatr.Queries.Customer;
using MediatR;
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
        var query = new GetCityByIdQuery(){Id = id};
        var result = await _mediator.Send(query);
        if (result == null)
        {
            return NotFound(Empty);
        }
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> AddCity(AddNewCityCommand query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCity(UpdateCityCommand query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCity(DeleteCityCommand query)
    {
        return Ok(await _mediator.Send(query));
    }
}