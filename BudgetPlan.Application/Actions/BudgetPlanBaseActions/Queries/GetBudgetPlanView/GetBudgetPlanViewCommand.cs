using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.BudgetPlanBaseActions.Queries.GetBudgetPlanView;

public class GetBudgetPlanViewCommand : IRequest<BudgetPlanViewModel>
{
    public Guid BudgetPlanId { get; set; }
}