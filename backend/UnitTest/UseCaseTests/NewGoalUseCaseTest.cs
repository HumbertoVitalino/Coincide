using Core.Domain;
using Core.Interfaces;
using Core.UseCase.NewGoalUseCase;
using Core.UseCase.NewGoalUseCase.Boundaries;
using Moq;
using AutoBogus;

namespace UnitTest.UseCaseTests;

public class NewGoalUseCaseTest
{
    private readonly Mock<IGoalRepository> _goalRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly NewGoal _useCase;

    public NewGoalUseCaseTest()
    {
        _goalRepositoryMock = new Mock<IGoalRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _useCase = new NewGoal(_goalRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact(DisplayName = "Handle > Success > Goal created successfully")]
    public async Task Handle_ShouldCreateGoalSuccessfully()
    {
        // Arrange
        var input = new AutoFaker<NewGoalInput>().Generate();

        // Act
        var result = await _useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.True(result.IsValid);
        Assert.NotNull(result.ErrorMessages);
        Assert.NotNull(result.Result);
        Assert.IsType<Goal>(result.Result);
        _goalRepositoryMock.Verify(repo => repo.Create(It.IsAny<Goal>()), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
