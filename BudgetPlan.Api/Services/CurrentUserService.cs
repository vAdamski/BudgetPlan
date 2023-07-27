using System.Security.Claims;
using BudgetPlan.Application.Common.Interfaces;
using IdentityModel;

namespace BudgetPlan.Api.Services;

public class CurrentUserService : ICurrentUserService
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool IsAuthenticated { get; set; }
    public string Name { get; set; }

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        Email= httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Email);
        Name = httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Name);
        FirstName = httpContextAccessor.HttpContext?.User?.FindFirstValue("firstName");
        LastName = httpContextAccessor.HttpContext?.User?.FindFirstValue("lastName");
        FullName = $"{FirstName} {LastName}";

        IsAuthenticated = !string.IsNullOrEmpty(Email);
    }
}