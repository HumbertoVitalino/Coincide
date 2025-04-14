using Core.Commons;
using Core.Interfaces;
using Core.Mappers;
using Core.UseCase.NewAccountUseCase.Boundaries;
using MediatR;

namespace Core.UseCase.NewAccountUseCase;

public class NewAccount(
    IAccountRepository accountRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<NewAccountInput, Output>
{
    private readonly IAccountRepository _accountRepository = accountRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Output> Handle(NewAccountInput input, CancellationToken cancellationToken)
    {
        var output = new Output();

        var account = input.MapToEntity();

        _accountRepository.Create(account);
        await _unitOfWork.CommitAsync(cancellationToken);
        
        output.AddResult(account);
        return output;
    }
}
