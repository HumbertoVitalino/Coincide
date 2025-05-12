using Api.Mapper;
using Core.Commons;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public sealed class IncomeController(
    IMediator mediator
) : BaseController
{
    private readonly IMediator _mediator = mediator;
    
    [HttpPost]
    [ProducesResponseType(typeof(Output), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Output), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostAsync([FromBody] Models.NewIncomeRequest request, CancellationToken cancellationToken)
    {
        var input = request.MapToInput(UserId);

        var output = await _mediator.Send(input, cancellationToken);

        if (output.IsValid)
            return Ok(output);

        return BadRequest(output);
    }
}
