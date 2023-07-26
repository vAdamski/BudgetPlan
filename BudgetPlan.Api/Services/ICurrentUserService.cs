namespace BudgetPlan.Api.Services;

public interface ICurrentUserService
{
    string Email { get; set; }
    bool IsAuthenticated { get; set; }
    string Name { get; set; }
}