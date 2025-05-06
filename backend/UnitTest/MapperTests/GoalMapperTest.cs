using AutoBogus;
using Core.Domain;
using Core.UseCase.NewGoalUseCase.Boundaries;
using Core.Mappers;
using Core.Dto;

namespace UnitTest.MapperTests;

public class GoalMapperTest
{
    [Fact(DisplayName = "Map > Success > To Entity")]
    public void MapShouldMapToEntityWithSuccess()
    {
        //Arrange
        var input = new AutoFaker<NewGoalInput>().Generate();

        //Act
        var result = input.MapToEntity();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(input.Title, result.Title);
        Assert.Equal(input.Description, result.Description);
        Assert.Equal(input.TargetAmount, result.TargetAmount);
        Assert.Equal(input.StartDate, result.StartDate);
        Assert.Equal(input.EndDate, result.EndDate);
        Assert.IsType<Goal>(result);
    }

    [Fact(DisplayName = "Map > Success > To Dto")]
    public void MapShouldMapToDtoWithSuccess()
    {
        //Arrange
        var goal = new AutoFaker<Goal>().Generate();

        //Act
        var result = goal.MapToDto();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(goal.Id, result.Id);
        Assert.Equal(goal.Title, result.Title);
        Assert.Equal(goal.Description, result.Description);
        Assert.Equal(goal.TargetAmount, result.TargetAmount);
        Assert.Equal(goal.StartDate, result.StartDate);
        Assert.Equal(goal.EndDate, result.EndDate);
        Assert.IsType<GoalDto>(result);
    }

    [Fact(DisplayName = "Map > Success > To Dto List")]
    public void MapShouldMapToDtoListWithSuccess()
    {
        //Arrange
        var goals = new AutoFaker<Goal>().Generate(5);

        //Act
        var result = goals.MapToDto();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(goals.Count(), result.Count());
        Assert.IsAssignableFrom<IEnumerable<GoalDto>>(result);
    }
}
