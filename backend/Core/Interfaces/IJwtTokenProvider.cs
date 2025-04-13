namespace Core.Interfaces;

public interface IJwtTokenProvider
{
    string GenerateToken(Guid id, string email);
}
