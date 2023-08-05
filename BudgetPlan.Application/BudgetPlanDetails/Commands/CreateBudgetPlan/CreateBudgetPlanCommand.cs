using MediatR;

namespace BudgetPlan.Application.BudgetPlanDetails.Commands.CreateBudgetPlanDetailsForMonthView;

public class CreateBudgetPlanCommand : IRequest<int>
{
    public DateTime Date { get; set; }
    public int Year => Date.Year;
    public int Month => Date.Month;
}