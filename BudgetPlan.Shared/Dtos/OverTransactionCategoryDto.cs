using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Shared.Dtos;

public class OverTransactionCategoryDto
{
    public Guid Id { get; }
    public string TransactionCategoryName { get; }
    public List<TransactionCategoryDto> TransactionCategoryDtos { get; } = new();

    public OverTransactionCategoryDto(TransactionCategory transactionCategory, List<TransactionCategory> subTransactionCategories)
    {
        Id = transactionCategory.Id;
        TransactionCategoryName = transactionCategory.TransactionCategoryName;
        TransactionCategoryDtos = subTransactionCategories.Select(tc => new TransactionCategoryDto(tc)).ToList();
    }
}