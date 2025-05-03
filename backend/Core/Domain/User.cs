namespace Core.Domain;

public class User : Entity
{
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public double Balance { get; set; } = 0.0;


    public User() {}
    public User(string name, string email, byte[] passwordHash, byte[] passwordSalt)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}
