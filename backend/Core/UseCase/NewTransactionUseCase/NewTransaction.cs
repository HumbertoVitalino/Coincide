using Core.Boundaries.Enums;
using Core.Commons;
using Core.Interfaces;
using Core.Mappers;
using Core.UseCase.NewTransactionUseCase.Boundaries;
using MediatR;

namespace Core.UseCase.NewTransactionUseCase;

public class NewTransaction(
    ITransactionRepository repository,
    IAccountRepository accountRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<NewTransactionInput, Output>
{
    private readonly ITransactionRepository _repository = repository;
    private readonly IAccountRepository _accountRepository = accountRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Output> Handle(NewTransactionInput input, CancellationToken cancellationToken)
    {
        var output = new Output();

        var account = await _accountRepository.GetAsync(input.UserId, input.AccountName);

        if (account == null)
        {
            output.AddErrorMessage("Unable to find any account for this name.");
            return output;
        }

        var transaction = input.MapToEntity(account);

        if (transaction.Type == TransactionsType.Expense)
        {
            account.Balance -= transaction.Value;
            account.TotalExpense += transaction.Value;
        }

        if (transaction.Type == TransactionsType.Income)
        {
            account.Balance += transaction.Value;
            account.TotalIncome += transaction.Value;
        }

        _repository.Create(transaction);
        await _unitOfWork.CommitAsync(cancellationToken);

        var dto = transaction.MapToDto();

        output.AddResult(dto);
        return output;
    }
}
