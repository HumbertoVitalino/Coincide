using Api.Controllers.Models;
using Api.Mapper;
using AutoBogus;
using Core.Domain;
using Core.Mappers;
using Core.UseCase.UserRegisterUseCase.Boundaries;

namespace UnitTest.MapperTests;

public class UserMapperTest
{
    [Fact(DisplayName = "Map > Success > To Entity")]
    public void MapShouldMapToEntityWithSuccess()
    {
        //Arrange
        var input = new AutoFaker<UserRegisterInput>().Generate();

        //Act
        var result = input.MapToEntity();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(input.Name, result.Name);
        Assert.Equal(input.Birthday, result.Birthday);
        Assert.Equal(input.Email, result.Email);
        Assert.True(result.TotalExpense == 0);
        Assert.True(result.TotalIncome == 0);
        Assert.True(result.Balance == 0);
        Assert.IsType<User>(result);
    }

    [Fact(DisplayName = "Map > Success > To Input")]
    public void MapShouldMapToInputWithSuccess()
    {
        //Arrange
        var request = new AutoFaker<UserRegisterRequest>().Generate();

        //Act
        var result = request.MapToInput();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(request.Name, result.Name);
        Assert.Equal(request.Birthday, result.Birthday);
        Assert.Equal(request.Email, result.Email);
        Assert.IsType<UserRegisterInput>(result);
    }
}
