using Core.Boundaries.Enums;

namespace Core.Domain;

public class Transaction : Entity
{    
    public decimal Value { get; set; }
    public TransactionsType Type { get; set; }
    public TransactionCategory Category { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Transaction() { }

    public Transaction(
        decimal value,
        string? description,
        TransactionsType type,
        TransactionCategory category,
        DateTime date,
        Guid accountId,
        Guid userId)
    {
        Value = value;
        Description = description;
        Type = type;
        Category = category;
        Date = date;
        AccountId = accountId;
        UserId = userId;
    }
}
