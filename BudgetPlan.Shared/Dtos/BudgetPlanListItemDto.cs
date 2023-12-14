using BudgetPlan.Common.Extension;
using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanListItemDto
{
    public BudgetPlanListItemDto(BudgetPlanBase budgetPlanBase)
    {
        Id = budgetPlanBase.Id;
        From = budgetPlanBase.DateFrom.ToDateOnly();
        To = budgetPlanBase.DateTo.ToDateOnly();
    }
    
    public Guid Id { get; private set; }
    public DateOnly From { get; private set; }
    public DateOnly To { get; private set; }
}