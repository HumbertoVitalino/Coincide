namespace Core.Domain;

public class Goal : Entity
{
    public string Title { get; set; }
    public decimal TargetAmount { get; set; }
    public decimal GoalBalance { get; set; } = 0;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal MonthlyExpectedValue { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Goal(
        string title,
        decimal targetAmount,
        string? description,
        DateTime startDate,
        DateTime endDate,
        decimal monthlyExpectedValue,
        Guid userId)
    {
        Title = title;
        TargetAmount = targetAmount;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        MonthlyExpectedValue = monthlyExpectedValue;
        UserId = userId;
    }
}
