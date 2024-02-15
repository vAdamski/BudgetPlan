using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface ITransactionCategoriesRepository
{
    Task<List<TransactionCategory>> GetTransactionCategoriesWithUnderTransactionCategoriesForCurrentUser(
        CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, string userEmail, CancellationToken cancellationToken = default);
    Task<bool> IsTransactionCategoryUnderCategory(Guid transactionCategoryId);
    Task<bool> IsTransactionCategoryInclude(Guid mainTransactionCategory, Guid transactionCategoryToCheck);
}