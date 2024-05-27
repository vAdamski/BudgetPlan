using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Enums;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddOverTransactionCategory;

public class AddOverTransactionCategoryCommand : IRequest<Guid>
{
    public Guid BudgetPlanId { get; }
    public string Name { get; }
    public TransactionType TransactionType { get; }

    public AddOverTransactionCategoryCommand(Guid budgetPlanId, string name, TransactionType transactionType)
    {
        BudgetPlanId = budgetPlanId;
        Name = name;
        TransactionType = transactionType;
    }
}