using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Enums;

namespace BudgetPlan.Shared.Dtos;

public class BudgetPlanOverTransactionCategoryDto
{
    public BudgetPlanOverTransactionCategoryDto()
    {
        
    }

    public BudgetPlanOverTransactionCategoryDto(TransactionCategory transactionCategory)
    {
        if (transactionCategory == null)
            throw new ArgumentException("Transaction category cannot be null.");
        if (transactionCategory.OverTransactionCategoryId != null)
            throw new ArgumentException("Transaction category is not over category.");
        
        OverCategoryName = transactionCategory.TransactionCategoryName;
        TransactionType = transactionCategory.TransactionType;
    }
    
    public BudgetPlanOverTransactionCategoryDto(TransactionCategory transactionCategory, List<TransactionCategory> underTransactionCategories)
    {
        if (transactionCategory == null)
            throw new ArgumentException("Transaction category cannot be null.");
        if (transactionCategory.OverTransactionCategoryId != null)
            throw new ArgumentException("Transaction category is not over category.");
        if (underTransactionCategories.Any(x => x.OverTransactionCategoryId == null))
            throw new ArgumentException("Any of the subcategories is not a subcategory");
        
        OverCategoryName = transactionCategory.TransactionCategoryName;
        TransactionType = transactionCategory.TransactionType;
        UnderTransactionCategoryDtos = underTransactionCategories.Select(x => new BudgetPlanUnderTransactionCategoryDto(x)).ToList();
    }
    
    public string OverCategoryName { get; set; }
    public TransactionType TransactionType { get; set; }

    public double SumOfAllCategories =>
        UnderTransactionCategoryDtos.Sum(x => x.BudgetPlanDetailsDto.ValueOfTransactionItemsForDays);

    public List<BudgetPlanUnderTransactionCategoryDto> UnderTransactionCategoryDtos { get; set; }
}