using AutoBogus;
using Core.Domain;
using Core.Dto;
using Core.Mappers;
using Core.UseCase.NewAccountUseCase.Boundaries;
using UnitTest.Fakers;

namespace UnitTest.MapperTests;

public class AccountMapperTest
{
    [Fact(DisplayName = "Map >> Success >> When mapping a NewAccountInput to Account entity")]
    public async Task MapShouldMapToEntityWithSuccess()
    {
        // Arrange
        var input = new AutoFaker<NewAccountInput>()
            .RuleFor(x => x.Name, f => f.Company.CompanyName())
            .RuleFor(x => x.UserId, _ => Guid.NewGuid())
            .Generate();

        // Act
        var account = input.MapToEntity();

        // Assert
        Assert.NotNull(account);
        Assert.Equal(input.Name, account.Name);
        Assert.Equal(input.UserId, account.UserId);
        Assert.Equal(0, account.Balance);        // Garantir DefaultValue
        Assert.Equal(0, account.TotalIncome);
        Assert.Equal(0, account.TotalExpense);
        Assert.IsType<Account>(account);
    }

    [Fact(DisplayName = "Map >> Success >> When mapping an Account to a DTO")]
    public async Task MapShouldMapWithSuccessWhenMappingToADto()
    {
        // Arrange
        var account = new AccountFaker().Generate();

        // Act
        var accountDto = account.MapToDto();

        // Assert
        Assert.NotNull(accountDto);
        Assert.Equal(account.Name, accountDto.Name);
        Assert.Equal(account.Balance, accountDto.Balance);
        Assert.Equal(account.TotalIncome, accountDto.TotalIncome);
        Assert.Equal(account.TotalExpense, accountDto.TotalExpense);
        Assert.Equal(account.User.Email, accountDto.Email);
        Assert.IsType<AccountDto>(accountDto);
    }

    [Fact(DisplayName = "Map >> Success >> When mapping a list of Accounts to DTOs")]
    public async Task MapShouldMapWithSuccessWhenMappingAListOfAccountsToDtos()
    {
        // Arrange
        var accounts = new AccountFaker().Generate(5);

        // Act
        var accountDtos = accounts.MapToDto();

        // Assert
        Assert.NotNull(accountDtos);
        Assert.Equal(accounts.Count, accountDtos.Count());
        Assert.All(accountDtos, dto => Assert.IsType<AccountDto>(dto));
    }
}
