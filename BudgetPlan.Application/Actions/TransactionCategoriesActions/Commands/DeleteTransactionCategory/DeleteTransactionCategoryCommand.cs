using BudgetPlan.Common.Extension;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.DeleteTransactionCategory;

public class DeleteTransactionCategoryCommand : IRequest
{
	public Guid TransactionCategory { get; }
	public Guid? TransactionCategoryMigrationDestination { get; }

	public DeleteTransactionCategoryCommand(Guid transactionCategory, Guid? transactionCategoryMigrationDestination)
	{
		if (transactionCategory.IsNullOrEmpty())
			throw new AggregateException();
		
		TransactionCategory = transactionCategory;
		TransactionCategoryMigrationDestination = transactionCategoryMigrationDestination;
	}
}