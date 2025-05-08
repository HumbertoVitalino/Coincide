using Api.Mapper;
using Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class UserController(
    IMediator mediator
) : ControllerBase 
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("Register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterRequest request, CancellationToken cancellationToken)
    {
        var input = request.MapToInput();

        var output = await _mediator.Send(input, cancellationToken);

        return Ok(output);
    }

    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequest request, CancellationToken cancellationToken)
    {
        var input = request.MapToInput();

        var output = await _mediator.Send(input, cancellationToken);

        if (output.IsValid)
            return Ok(output);

        return BadRequest(output);
    }
}
