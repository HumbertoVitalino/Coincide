using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Core.Interfaces;

public interface IJwtTokenProvider : IOperationFilter
{
    string GenerateToken(Guid id, string email);
    void Apply(OpenApiOperation operation, OperationFilterContext context);
}
