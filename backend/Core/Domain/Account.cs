namespace Core.Domain;

public class Account : Entity
{
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Account(string name, decimal balance, Guid userId)
    {
        Name = name;
        Balance = balance;
        UserId = userId;
    }
}
