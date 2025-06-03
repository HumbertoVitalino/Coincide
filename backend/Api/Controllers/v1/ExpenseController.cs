using Api.Mapper;
using Api.Models;
using Core.Commons;
using Core.UseCase.GetAllExpensesUseCase.Boundaries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public sealed class ExpenseController(
    IMediator mediator    
) : BaseController
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Get all expenses for the authenticated user.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(Output), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Output), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        var input = new GetAllExpensesInput(UserId);

        var output = await _mediator.Send(input, cancellationToken);

        if (output.IsValid)
            return Ok(output);
        
        return NotFound(output);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(Output), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Output), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostAsync([FromBody] NewExpenseRequest request, CancellationToken cancellationToken)
    {
        var input = request.MapToInput(UserId);

        var output = await _mediator.Send(input, cancellationToken);

        if(output.IsValid)
            return Ok(output);

        return BadRequest(output);
    }
}
