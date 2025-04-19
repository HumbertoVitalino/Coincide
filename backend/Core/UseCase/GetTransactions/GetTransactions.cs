using Core.Commons;
using Core.Interfaces;
using Core.Mappers;
using Core.UseCase.GetTransactions.Boundaries;
using MediatR;

namespace Core.UseCase.GetTransactions;

public class GetTransactions(
    ITransactionRepository repository
) : IRequestHandler<GetTransactionsInput, Output>
{
    private readonly ITransactionRepository _repository = repository;
    public async Task<Output> Handle(GetTransactionsInput input, CancellationToken cancellationToken)
    {
        var output = new Output();

        var transactions = await _repository.GetAllAsync(input.UserId, cancellationToken);

        if (!transactions.Any())
        {
            output.AddErrorMessage("Unable to find any transaction for this user!");
            return output;
        }

        var dto = transactions.MapToDto();

        output.AddResult(dto);
        return output;
    }
}
