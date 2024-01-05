namespace BudgetPlan.Application.Common.Interfaces.Services;

public interface IDeleteTransactionCategoryService
{
    Task DeleteTransactionCategory(Guid id, CancellationToken cancellationToken = default);
    Task DeleteTransactionCategoryWithMigrationItems(Guid id, Guid utcId, CancellationToken cancellationToken = default);
}