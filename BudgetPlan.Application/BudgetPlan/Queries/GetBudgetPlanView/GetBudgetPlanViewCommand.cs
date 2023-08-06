using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.BudgetPlan.Queries.GetBudgetPlanView;

public class GetBudgetPlanViewCommand : IRequest<BudgetPlanViewModel>
{
    public DateTime DateTime { get; set; }
    public int Year => DateTime.Year;
    public int Month => DateTime.Month;
}