using AutoBogus;
using Core.Domain;
using Core.Interfaces;
using Core.UseCase.NewIncomeUseCase;
using Core.UseCase.NewIncomeUseCase.Boundaries;
using Moq;

namespace UnitTest.UseCaseTests;

public class NewIncomeUseCaseTest
{
    private readonly Mock<IIncomeRepository> _incomeRepositoryMock;
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly NewIncome _useCase;
    public NewIncomeUseCaseTest()
    {
        _incomeRepositoryMock = new Mock<IIncomeRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _userRepositoryMock = new Mock<IUserRepository>();
        _useCase = new NewIncome(_incomeRepositoryMock.Object, _userRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact(DisplayName = "Handle > Success > Income created successfully")]
    public async Task Handle_ShouldCreateIncomeSuccessfully()
    {
        // Arrange
        var input = new AutoFaker<NewIncomeInput>().Generate();

        // Act
        var result = await _useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.True(result.IsValid);
        Assert.NotNull(result.ErrorMessages);
        Assert.NotNull(result.Result);
        Assert.IsType<Income>(result.Result);
        _incomeRepositoryMock.Verify(repo => repo.Create(It.IsAny<Income>()), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
