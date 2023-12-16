using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.BudgetPlanActions.Queries.GetBudgetPlanView;

public class GetBudgetPlanViewCommand : IRequest<BudgetPlanViewModel>
{
    public Guid BudgetPlanId { get; set; }
}