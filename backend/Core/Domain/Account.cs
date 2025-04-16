namespace Core.Domain;

public class Account : Entity
{
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense {  get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public Account() { }

    public Account(string name, decimal balance, decimal totalIncome, decimal totalExpense, Guid userId)
    {
        Name = name;
        Balance = balance;
        TotalIncome = totalIncome;
        TotalExpense = totalExpense;
        UserId = userId;
    }
}
