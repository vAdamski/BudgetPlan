using BudgetPlan.Shared.Enums;
using MediatR;

namespace BudgetPlan.Application.TransactionCategories.Commands.AddOverTransactionCategory;

public class AddOverTransactionCategoryCommand : IRequest<int>
{
    public string TransactionCategoryName { get; set; } = "";
    public TransactionType TransactionType { get; set; }
    public int? OverTransactionCategoryId { get; set; }
}