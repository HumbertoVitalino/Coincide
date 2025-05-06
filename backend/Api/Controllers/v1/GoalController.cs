using Api.Mapper;
using Api.Models;
using Core.UseCase.GetGoalsByUserUseCase.Boundaries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public sealed class GoalController(
    IMediator mediator
) : BaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetGoalsAsync(CancellationToken cancellationToken)
    {
        var input = new GetGoalsByUserInput(UserId);
        var output = await _mediator.Send(input, cancellationToken);

        if (output.IsValid)
            return Ok(output);

        return NotFound(output);
    }

    [HttpPost("NewGoal")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> NewGoalAsync(
        [FromBody] NewGoalRequest request,
        CancellationToken cancellationToken)
    {
        var input = request.MapToInput(UserId);
        var output = await _mediator.Send(input, cancellationToken);

        if (output.IsValid)
            return Ok(output);

        return BadRequest(output);
    }
}
