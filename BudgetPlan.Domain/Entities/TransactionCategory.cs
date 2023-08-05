using BudgetPlan.Domain.Common;
using BudgetPlan.Shared.Enums;

namespace BudgetPlan.Domain.Entities;

public class TransactionCategory : AuditableEntity
{
    public string TransactionCategoryName { get; set; }
    public TransactionType TransactionType { get; set; }
    public int? OverTransactionCategoryId { get; set; }
    public TransactionCategory? OverTransactionCategory { get; set; }
    
    
    public List<BudgetPlanDetails> BudgetPlanDetails { get; set; } = new();
    public List<TransactionDetail> TransactionDetails { get; set; } = new();
    public List<TransactionCategory> SubTransactionCategories { get; set; } = new();
}