using BudgetPlan.Domain.Enums;
using MediatR;

namespace BudgetPlan.Application.TransactionCategories.Commands.AddTransactionCategory;

public class AddTransactionCategoryCommand : IRequest<int>
{
    public string TransactionCategoryName { get; set; } = "";
    public TransactionType TransactionType { get; set; }
    public int? OverTransactionCategoryId { get; set; }
}