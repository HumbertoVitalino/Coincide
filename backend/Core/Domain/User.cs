namespace Core.Domain;

public class User : Entity
{
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public decimal Balance { get; set; } = 0;
    public decimal TotalIncome { get; set; } = 0;
    public decimal TotalExpense { get; set; } = 0;
    public ICollection<Goal> Goals { get; set; } = new List<Goal>();
    public ICollection<Income> Incomes { get; set; } = new List<Income>();
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public User() {}
    public User(string name, DateTime birthday, string email, byte[] passwordHash, byte[] passwordSalt)
    {
        Name = name;
        Birthday = birthday;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}
