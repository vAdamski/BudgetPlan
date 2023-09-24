using BudgetPlan.Shared.Enums;
using MediatR;

namespace BudgetPlan.Application.TransactionCategories.Commands.AddOverTransactionCategory;

public class AddOverTransactionCategoryCommand : IRequest<Guid>
{
    public string TransactionCategoryName { get; set; } = "";
    public TransactionType TransactionType { get; set; }
}