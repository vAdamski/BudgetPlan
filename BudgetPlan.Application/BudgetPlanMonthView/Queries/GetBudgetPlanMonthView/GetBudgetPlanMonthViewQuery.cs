using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.BudgetPlanMonthView.Queries.GetBudgetPlanMonthView;

public class GetBudgetPlanMonthViewQuery : IRequest<BudgetPlanDetailsViewModel>
{
    public DateTime DateTime { get; set; }
}