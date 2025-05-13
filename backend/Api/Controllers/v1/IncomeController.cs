using Api.Mapper;
using Api.Models;
using Core.Commons;
using Core.UseCase.GetAllIncomesUseCase.Boundaries;
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

    /// <summary>  
    /// Retrieves all income entries for the authenticated user.  
    /// </summary>  
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>  
    /// <returns>Returns an Output containing the operation result.</returns>
    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(Output), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Output), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var input = new GetAllIncomesInput(UserId);

        var output = await _mediator.Send(input, cancellationToken);

        if (output.IsValid)
            return Ok(output);

        return BadRequest(output);
    }

    /// <summary>  
    /// Handles the creation of a new income entry.  
    /// </summary>  
    /// <param name="request">The request object containing the details of the new income.</param>  
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>  
    /// <returns>Returns an IActionResult containing the operation result.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Output), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Output), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostAsync([FromBody] NewIncomeRequest request, CancellationToken cancellationToken)
    {
        var input = request.MapToInput(UserId);

        var output = await _mediator.Send(input, cancellationToken);

        if (output.IsValid)
            return Ok(output);

        return BadRequest(output);
    }
}
