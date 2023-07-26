using System.Security.Claims;
using IdentityModel;

namespace BudgetPlan.Api.Services;

public class CurrentUserService : ICurrentUserService
{
    public string Email { get; set; }
    public bool IsAuthenticated { get; set; }
    public string Name { get; set; }

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        var email = httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Email);
        Name = httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Name);
        Email = email;

        IsAuthenticated = !string.IsNullOrEmpty(email);
    }
}