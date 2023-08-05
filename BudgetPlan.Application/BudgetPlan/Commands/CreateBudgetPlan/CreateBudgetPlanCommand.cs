using MediatR;

namespace BudgetPlan.Application.BudgetPlan.Commands.CreateBudgetPlan;

public class CreateBudgetPlanCommand : IRequest<int>
{
    public DateTime Date { get; set; }
    public int Year => Date.Year;
    public int Month => Date.Month;
}