using AutoBogus;
using Core.UseCase.NewIncomeUseCase.Boundaries;
using Core.Mappers;
using Core.Domain;
using Core.Dto;

namespace UnitTest.MapperTests;

public class IncomeMapperTest
{
    [Fact(DisplayName = "Map > Success > To Entity")]
    public void MapShouldMapToEntityWithSuccess()
    {
        //Arrange
        var input = new AutoFaker<NewIncomeInput>().Generate();

        //Act
        var result = input.MapToEntity();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(input.Title, result.Title);
        Assert.Equal(input.Value, result.Value);
        Assert.Equal(input.Type, result.Type);
        Assert.Equal(input.Date, result.Date);
        Assert.IsType<Income>(result);
    }

    [Fact(DisplayName = "Map > Success > To DTO")]
    public void MapShouldMapToDtoWithSuccess()
    {
        //Arrange
        var income = new AutoFaker<Income>().Generate();

        //Act
        var result = income.MapToDto(income.User);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(income.Id, result.Id);
        Assert.Equal(income.Title, result.Title);
        Assert.Equal(income.Value, result.Value);
        Assert.Equal(income.Description, result.Description);
        Assert.Equal(income.Type, result.Type);
        Assert.Equal(income.Date, result.Date);
        Assert.IsType<IncomeDto>(result);
    }

    [Fact(DisplayName = "Map > Success > To DTO List")]
    public void MapShouldMapToDtoListWithSuccess()
    {
        //Arrange
        var income = new AutoFaker<Income>().Generate(5);

        //Act
        var result = income.MapToDto();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<IncomeDto>>(result);
    }
}
