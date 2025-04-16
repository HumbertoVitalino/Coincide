namespace Core.Dto;

public sealed record AccountDto(string Name, decimal Balance, decimal TotalIncome, decimal TotalExpense, string Email);
