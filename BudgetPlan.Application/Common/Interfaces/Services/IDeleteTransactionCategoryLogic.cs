namespace BudgetPlan.Application.Common.Interfaces.Services;

public interface IDeleteTransactionCategoryLogic
{
	Task DeleteTransactionCategory(Guid transactionCategoryId, CancellationToken cancellationToken = default);
}