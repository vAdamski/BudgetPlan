using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface ITransactionDetailsRepository
{
    Task<List<TransactionDetail>> GetTransactionsForUserBetweenDates(string userEmail, DateTime dateFrom,
        DateTime dateTo);
}