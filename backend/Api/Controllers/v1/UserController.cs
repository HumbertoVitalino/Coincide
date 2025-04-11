using Api.Controllers.Models;
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UserRegisterAsync([FromBody] UserRegisterRequest request, CancellationToken cancellationToken)
    {
        var output = await _mediator.Send(request, cancellationToken);

        return Ok(output);
    }
}
