namespace BudgetPlan.Application.Common.Interfaces.Services;

public interface IDeleteTransactionCategoryService
{
    Task DeleteTransactionCategory(Guid id, CancellationToken cancellationToken = default);
    Task DeleteTransactionCategoryWithMigrationItems(Guid transactionCategoryToDeleteId, Guid underTransactionCategoryMigrationToId, CancellationToken cancellationToken = default);
}