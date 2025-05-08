using Api.Mapper;
using Api.Models;
using Core.Commons;
using Core.UseCase.GetGoalByIdUseCase.Boundaries;
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

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Output), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Output), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var input = new GetGoalByIdInput(id, UserId);
        var output = await _mediator.Send(input, cancellationToken);

        if (output.IsValid)
            return Ok(output);

        return NotFound(output);
    }

    [HttpGet]
    [ProducesResponseType(typeof(Output), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Output), StatusCodes.Status404NotFound)]
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
    [ProducesResponseType(typeof(Output), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Output), StatusCodes.Status400BadRequest)]
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
