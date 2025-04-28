using AutoBogus;
using Bogus;
using Core.Boundaries.Enums;
using Core.Domain;

namespace UnitTest.Fakers;

public class Fakers { }

public class UserFaker : AutoFaker<User>
{
    public UserFaker()
    {
        RuleFor(u => u.Name, f => f.Person.FullName)
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.PasswordHash, _ => new byte[32])
            .RuleFor(u => u.PasswordSalt, _ => new byte[32])
            .RuleFor(u => u.CreatedAt, f => f.Date.Past(3))
            .RuleFor(u => u.UpdatedAt, f => f.Date.Recent(30))
            .RuleFor(u => u.Id, _ => Guid.NewGuid());
    }
}

public class AccountFaker : AutoFaker<Account>
{
    public AccountFaker()
    {
        RuleFor(a => a.Name, f => f.Company.CompanyName())
            .RuleFor(a => a.Balance, f => f.Random.Decimal(0, 10000))
            .RuleFor(a => a.TotalIncome, f => f.Random.Decimal(0, 20000))
            .RuleFor(a => a.TotalExpense, f => f.Random.Decimal(0, 20000))
            .RuleFor(a => a.UserId, _ => Guid.NewGuid())
            .RuleFor(a => a.User, _ => new UserFaker().Generate())
            .RuleFor(a => a.Transactions, _ => new List<Transaction>()) 
            .RuleFor(a => a.CreatedAt, f => f.Date.Past(3))
            .RuleFor(a => a.UpdatedAt, f => f.Date.Recent(30))
            .RuleFor(a => a.Id, _ => Guid.NewGuid());
    }
}

public class TransactionFaker : AutoFaker<Transaction>
{
    public TransactionFaker()
    {
        RuleFor(t => t.Value, f => f.Random.Decimal(1, 5000))
            .RuleFor(t => t.Type, f => f.PickRandom<TransactionsType>())
            .RuleFor(t => t.Category, f => f.PickRandom<TransactionCategory>())
            .RuleFor(t => t.Description, f => f.Lorem.Sentence())
            .RuleFor(d => d.Date, f => f.Date.Past(3))
            .RuleFor(t => t.AccountId, _ => Guid.NewGuid())
            .RuleFor(t => t.UserId, _ => Guid.NewGuid())
            .RuleFor(t => t.User, _ => new UserFaker().Generate())
            .RuleFor(t => t.Account, _ => new AccountFaker().Generate())
            .RuleFor(t => t.CreatedAt, f => f.Date.Past(2))
            .RuleFor(t => t.UpdatedAt, f => f.Date.Recent(30))
            .RuleFor(t => t.Id, _ => Guid.NewGuid());
    }
}
