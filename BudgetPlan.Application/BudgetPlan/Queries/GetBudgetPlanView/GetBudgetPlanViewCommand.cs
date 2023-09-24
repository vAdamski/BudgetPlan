using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.BudgetPlan.Queries.GetBudgetPlanView;

public class GetBudgetPlanViewCommand : IRequest<BudgetPlanViewModel>
{
    public Guid BudgetPlanId { get; set; }
}