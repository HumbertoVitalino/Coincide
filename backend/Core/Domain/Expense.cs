using Core.Domain.Enums;

namespace Core.Domain;

public class Expense : Entity
{
    public string Title { get; set; }
    public decimal Value { get; set; }
    public string? Description { get; set; }
    public ExpenseType Type { get; set; }
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Expense
    (
        string title,
        decimal value,
        ExpenseType type,
        DateTime date,
        Guid userId
    )
    {
        Title = title;
        Value = value;
        Type = type;
        Date = date;
        UserId = userId;
    }
}
