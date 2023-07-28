using BudgetPlan.Domain.Enums;

namespace BudgetPlan.Domain.Entities;

public class BudgetPlanDetails
{
    public float Value { get; set; }
    public string Description { get; set; } = "";
    public BudgetPlanType BudgetPlanType { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int? TransactionCategoryId { get; set; }
}