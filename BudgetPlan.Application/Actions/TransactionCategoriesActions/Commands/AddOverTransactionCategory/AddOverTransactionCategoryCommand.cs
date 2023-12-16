using BudgetPlan.Domain.Enums;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddOverTransactionCategory;

public class AddOverTransactionCategoryCommand : IRequest<Guid>
{
    public string TransactionCategoryName { get; set; } = "";
    public TransactionType TransactionType { get; set; }
}