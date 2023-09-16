using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface ITransactionCategoriesRepository
{
    Task<List<TransactionCategory>> GetTransactionCategoriesWithDetailsForCurrentUser();
}