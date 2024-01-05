using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface ITransactionDetailsRepository
{
    Task<List<TransactionDetail>> GetTransactionsForUserBetweenDates(string userEmail, DateTime dateFrom,
        DateTime dateTo);

    Task<List<TransactionDetail>> GetTransactionDetailsForUnderTransactionCategory(Guid id, string userEmail,
        CancellationToken cancellationToken = default);

    Task<List<TransactionDetail>> GetTransactionDetailsForOverTransactionCategory(Guid id,
        string userEmail, CancellationToken cancellationToken = default);

    Task UpdateTransactionDetails(List<TransactionDetail> transactionDetails,
        CancellationToken cancellationToken = default);

    Task DeleteRangeAsync(List<TransactionDetail> transactionDetails, CancellationToken cancellationToken = default);
}