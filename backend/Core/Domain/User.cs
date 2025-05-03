namespace Core.Domain;

public class User : Entity
{
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public decimal Balance { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }


    public User() {}
    public User(string name, string email, byte[] passwordHash, byte[] passwordSalt)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}
