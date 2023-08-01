using Customer_Service.Application.Interfaces;
using Customer_Service.Application.Mediatr.Commands.Customer;
using Customer_Service.Application.Mediatr.Queries.Customer;
using Customer_Service.DTO.Customer;
using Customer_Service.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Service_API.Controllers;

[Route("api/Customer")]
[Authorize]
[ApiController]
public class CustomerController : ControllerBase
{
     private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    { 
        _mediator = mediator;
    }

    [HttpGet] 
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllCustomerQuery();
        return Ok(await _mediator.Send(query));
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginCommand customer)
    {
       LoginResponseDto? loginResponse= await _mediator.Send(customer);
        if (loginResponse == null)
        {
            return NotFound(Empty);
        }
        return Ok(loginResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetCustomerByIdQuery() { Id = id });
        if (result == null)
        {
            return NotFound(Empty);
        }
        return Ok(result);
    }

    [HttpPost]
    [Route("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterCustomerCommand customer)
    { 
        var data = await _mediator.Send(customer);
        return Ok(data);
    }
  
    [HttpPut]
    public async Task<IActionResult> Update(UpdateCustomerCommand customer)
    {
        var data = await _mediator.Send(customer);
        return Ok(data);
    }
}