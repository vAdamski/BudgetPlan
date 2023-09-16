using MediatR;

namespace BudgetPlan.Application.BudgetPlan.Commands.CreateBudgetPlan;

public class CreateBudgetPlanCommand : IRequest<int>
{
    private readonly DateTime _date;
    
    public CreateBudgetPlanCommand(DateTime date)
    {
        if (date == null)
        {
            throw new ArgumentNullException(nameof(date));
        }
        
        _date = date;
    }
    
    public int Year => _date.Year;
    public int Month => _date.Month;
}