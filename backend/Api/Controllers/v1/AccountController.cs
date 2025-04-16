using Api.Controllers.Models;
using Api.Mapper;
using Core.UseCase.GetAccount.Boundaries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AccountController(
    IMediator mediator
) : BaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("Account")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        var input = new GetAccountInput(UserId);

        var output = await _mediator.Send(input, cancellationToken);

        if (output.IsValid)
            return Ok(output);

        return BadRequest(output);
    }

    [HttpPost("NewAccount")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> NewAccountAsync([FromBody] NewAccountRequest request, CancellationToken cancellationToken)
    {
        var input = request.MapToInput(UserId);

        var output = await _mediator.Send(input, cancellationToken);

        if (output.IsValid)
            return Ok(output);

        return BadRequest(output);
    }
}
