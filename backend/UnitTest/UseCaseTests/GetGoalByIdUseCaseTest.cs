using AutoBogus;
using Core.Domain;
using Core.Interfaces;
using Core.UseCase.GetGoalByIdUseCase;
using Core.UseCase.GetGoalByIdUseCase.Boundaries;
using Moq;

namespace UnitTest.UseCaseTests;

public class GetGoalByIdUseCaseTest
{
    private readonly Mock<IGoalRepository> _goalRepositoryMock;
    private readonly GetGoalById _useCase;

    public GetGoalByIdUseCaseTest()
    {
        _goalRepositoryMock = new Mock<IGoalRepository>();
        _useCase = new GetGoalById(_goalRepositoryMock.Object);
    }

    [Fact(DisplayName = "GetGoalById > Success > Goal found")]
    public async Task GetGoalById_Success()
    {
        // Arrange
        var input = new AutoFaker<GetGoalByIdInput>().Generate();

        var goal = new AutoFaker<Goal>()
            .RuleFor(g => g.Id, f => input.Id)
            .RuleFor(g => g.UserId, f => input.UserId)
            .Generate();

        _goalRepositoryMock.Setup(repo => repo.GetById(input.Id)).ReturnsAsync(goal);

        // Act
        var result = await _useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.True(result.IsValid);
        Assert.NotNull(result.Result);
        Assert.Equal(goal.Id, input.Id);
    }

    [Fact(DisplayName = "GetGoalById > Fail > Goal not found")]
    public async Task GetGoalById_Fail()
    {
        // Arrange
        var input = new AutoFaker<GetGoalByIdInput>().Generate();        

        // Act
        var result = await _useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.False(result.IsValid);
        Assert.NotNull(result.ErrorMessages);
        Assert.Contains(result.ErrorMessages, e => e == "Goal not found");
    }

    [Fact(DisplayName = "GetGoalById > Fail > Goal not found for user")]
    public async Task GetGoalById_Fail_ForUser()
    {
        // Arrange
        var input = new AutoFaker<GetGoalByIdInput>().Generate();
        var goal = new AutoFaker<Goal>()
            .RuleFor(g => g.Id, f => input.Id)
            .RuleFor(g => g.UserId, f => new Guid())
            .Generate();

        _goalRepositoryMock.Setup(repo => repo.GetById(input.Id)).ReturnsAsync(goal);

        // Act
        var result = await _useCase.Handle(input, CancellationToken.None);

        // Assert
        Assert.False(result.IsValid);
        Assert.NotNull(result.ErrorMessages);
        Assert.Contains(result.ErrorMessages, e => e == "User not authorized to access this goal");
    }
}
