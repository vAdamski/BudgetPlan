using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Shared.Dtos;

public class OverTransactionCategoryDto
{
    public OverTransactionCategoryDto()
    {
        
    }
    
    public OverTransactionCategoryDto(TransactionCategory transactionCategory)
    {
        Id = transactionCategory.Id;
        TransactionCategoryName = transactionCategory.TransactionCategoryName;
    }
    
    public Guid Id { get; set; }
    public string TransactionCategoryName { get; set; }
    public List<TransactionCategoryDto> TransactionCategoryDtos { get; set; } = new();
}