using Moq;
using Core.UseCase.GetAccount;
using Core.Interfaces;
using Core.Domain;
using Core.UseCase.GetAccount.Boundaries;
using Core.Dto;
using AutoBogus;

namespace UnitTest.UseCaseTests;

public class GetAccountAsyncTests
{
    private readonly Mock<IAccountRepository> _repositoryMock;
    private readonly GetAccountAsync _useCase;

    public GetAccountAsyncTests()
    {
        _repositoryMock = new Mock<IAccountRepository>();
        _useCase = new GetAccountAsync(_repositoryMock.Object);
    }

    [Fact(DisplayName = "Handle >> Success >> When you have accounts")]
    public async Task Handle_WhenAccountsExist_ShouldReturnAccounts()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var accounts = new List<Account>
        {
            new Account("Conta Corrente", 1000m, 5000m, 4000m, userId)
            {
                User = new User { Email = "test@email.com" }
            }
        };

        _repositoryMock
            .Setup(repo => repo.GetAsync(userId))
            .ReturnsAsync(accounts);

        var input = new AutoFaker<GetAccountInput>()
            .RuleFor(x => x.Id, _ => userId);

        // Act
        var result = await _useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.True(result.IsValid);
        Assert.NotNull(result.Result);
        var accountDtos = Assert.IsAssignableFrom<IEnumerable<AccountDto>>(result.Result);
        Assert.Single(accountDtos);
        Assert.Equal("Conta Corrente", accountDtos.First().Name);
        Assert.Equal(1000m, accountDtos.First().Balance);
        Assert.Equal(5000m, accountDtos.First().TotalIncome);
        Assert.Equal(4000m, accountDtos.First().TotalExpense);
    }

    [Fact(DisplayName = "Handle >> Fail >> When no accounts Exist")]
    public async Task Handle_WhenNoAccountsExist_ShouldReturnErrorMessage()
    {
        // Arrange
        var userId = Guid.NewGuid();

        _repositoryMock
            .Setup(repo => repo.GetAsync(userId))
            .ReturnsAsync(new List<Account>());

        var input = new AutoFaker<GetAccountInput>();

        // Act
        var result = await _useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains("Unable to find any account for this user!", result.ErrorMessages);
    }
}
