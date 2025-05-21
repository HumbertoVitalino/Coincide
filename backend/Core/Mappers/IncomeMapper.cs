using Core.Domain;
using Core.Dto;
using Core.UseCase.NewIncomeUseCase.Boundaries;

namespace Core.Mappers;

public static class IncomeMapper
{
    public static Income MapToEntity(this NewIncomeInput input)
    {
        return new Income(
            input.Title,
            input.Value,
            input.Type,
            input.Date,
            input.UserId
        );
    }

    public static IncomeDto MapToDto(this Income income, User user)
    {
        return new IncomeDto(
            income.Id,
            income.Title,
            income.Value,
            income.Description,
            income.Type,
            income.Date,
            user.Balance,
            user.TotalIncome
        );
    }

    public static IEnumerable<IncomeDto> MapToDto(this IEnumerable<Income> incomes)
    {
        return incomes.Select(i => i.MapToDto(i.User));
    }
}
