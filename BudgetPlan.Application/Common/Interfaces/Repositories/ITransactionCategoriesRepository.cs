using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface ITransactionCategoriesRepository
{
    Task<List<TransactionCategory>> GetTransactionCategoriesWithUnderTransactionCategoriesForCurrentUser(
        CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, string userEmail, CancellationToken cancellationToken = default);

    Task<TransactionCategory> GetTransactionCategory(Guid id, string userEmail,
        CancellationToken cancellationToken = default);
}