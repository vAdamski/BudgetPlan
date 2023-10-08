using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanUnderTransactionCategoryDto
{
    public BudgetPlanUnderTransactionCategoryDto()
    {
        
    }

    public BudgetPlanUnderTransactionCategoryDto(TransactionCategory transactionCategory)
    {
        if (transactionCategory == null)
            throw new ArgumentException("Transaction category cannot be null.");
        if (transactionCategory.OverTransactionCategoryId == null)
            throw new ArgumentException("Transaction category is not under category.");
            
        UnderCategoryId = transactionCategory.Id;
        UnderCategoryName = transactionCategory.TransactionCategoryName;
    }
    
    public Guid UnderCategoryId { get; set; }
    public string UnderCategoryName { get; set; }
    public BudgetPlanDetailsDto BudgetPlanDetailsDto { get; set; }
}