using Api.Controllers.Models;
using Api.Mapper;
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

    [HttpPost("NewAccount")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> NewAccountAsync([FromBody] NewAccountRequest request, CancellationToken cancellationToken)
    {
        var userId = UserId;
        var input = request.MapToInput(userId);

        var output = await _mediator.Send(input, cancellationToken);

        return Ok(output);
    }
}
