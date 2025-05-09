using AutoBogus;
using Core.Domain;
using Core.Interfaces;
using Core.UseCase.GetGoalByIdUseCase.Boundaries;
using Core.UseCase.GetGoalsByUserUseCase;
using Core.UseCase.GetGoalsByUserUseCase.Boundaries;
using Moq;

namespace UnitTest.UseCaseTests;

public class GetGoalsByUserUseCaseTest
{
    private readonly Mock<IGoalRepository> _goalRepositoryMock;
    private readonly GetGoalsByUser _useCase;

    public GetGoalsByUserUseCaseTest()
    {
        _goalRepositoryMock = new Mock<IGoalRepository>();
        _useCase = new GetGoalsByUser(_goalRepositoryMock.Object);
    }

    [Fact(DisplayName = "GetGoalByUserId > Success > Goals found")]
    public async Task GetGoalsByUser_Success()
    {
        // Arrange
        var input = new AutoFaker<GetGoalsByUserInput>().Generate();

        var goal = new AutoFaker<Goal>()
            .RuleFor(g => g.Id, f => input.Id)
            .RuleFor(g => g.UserId, f => input.Id)
            .Generate(5);

        _goalRepositoryMock.Setup(repo => repo.GetByUserId(input.Id)).ReturnsAsync(goal);

        // Act
        var result = await _useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.True(result.IsValid);
        Assert.NotNull(result.Result);
        Assert.Equal(5, goal.Count);
    }
}

