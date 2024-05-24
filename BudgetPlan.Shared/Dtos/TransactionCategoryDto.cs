using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Shared.Dtos;

public class TransactionCategoryDto
{
    public Guid Id { get; }
    public string TransactionCategoryName { get; }

    public TransactionCategoryDto(TransactionCategory transactionCategory)
    {
        Id = transactionCategory.Id;
        TransactionCategoryName = transactionCategory.TransactionCategoryName;
    }
}