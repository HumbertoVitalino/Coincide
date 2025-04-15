﻿using Core.Commons;
using Core.Interfaces;
using Core.Mappers;
using Core.UseCase.GetAccount.Boundaries;
using MediatR;

namespace Core.UseCase.GetAccount;

public class GetAccountAsync(
    IAccountRepository repository
) : IRequestHandler<GetAccountInput, Output>
{
    private readonly IAccountRepository _repository = repository;
    public async Task<Output> Handle(GetAccountInput input, CancellationToken cancellationToken)
    {
        var output = new Output();

        var account = await _repository.GetAsync(input.Id);

        if (account == null)
        {
            output.AddErrorMessage("Unable to find any account for this user!");
            return output;
        }

        var dto = account.MapToDto();

        output.AddResult(dto);
        return output;
    }
}
