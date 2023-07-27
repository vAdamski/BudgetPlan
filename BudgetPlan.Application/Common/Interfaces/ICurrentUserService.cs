namespace BudgetPlan.Application.Common.Interfaces;

public interface ICurrentUserService
{
    string Email { get; set; }
    string Name { get; set; }
    bool IsAuthenticated { get; set; }
}