using BudgetPlan.Shared.Dtos;

namespace BudgetPlan.Shared.ViewModels;

public class BudgetPlanListViewModel
{
    public BudgetPlanListViewModel(List<BudgetPlanListItemDto> budgetPlans)
    {
        if (budgetPlans is null)
        {
            BudgetPlans = new();
        }
        
        BudgetPlans = budgetPlans;
    }
    
    public List<BudgetPlanListItemDto> BudgetPlans { get; private set; }
}