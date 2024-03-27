using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Common.Extension;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence.Respositories;

public class TransactionDetailsRepository : ITransactionDetailsRepository
{
    private readonly IBudgetPlanDbContext _ctx;

    public TransactionDetailsRepository(IBudgetPlanDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<TransactionDetail>> GetTransactionDetailsForOverTransactionCategory(Guid id,
        string userEmail, CancellationToken cancellationToken = default)
    {
        var otc = await _ctx.TransactionCategories
            .Where(otc => otc.Id == id && otc.CreatedBy == userEmail)
            .IsActive()
            .Include(otc => otc.SubTransactionCategories)
            .ThenInclude(utc => utc.TransactionDetails)
            .FirstOrDefaultAsync(cancellationToken);

        if (otc == null)
            throw new OverTransactionCategoryNotFoundException($"TransactionCategory with Id = {id} has not been found for this user!");
        
        var transactionDetails = new List<TransactionDetail>();
        
        otc.SubTransactionCategories.ForEach(utc =>
        {
            transactionDetails.AddRange(utc.TransactionDetails);
        });
        
        return transactionDetails;
    }

    public async Task<List<TransactionDetail>> GetTransactionDetailsForUnderTransactionCategory(Guid id,
        string userEmail, CancellationToken cancellationToken = default)
    {
        var utc = await _ctx.TransactionCategories
            .Where(utc => utc.Id == id && utc.CreatedBy == userEmail)
            .IsActive()
            .Include(utc => utc.TransactionDetails)
            .FirstOrDefaultAsync(cancellationToken);

        if (utc == null)
            throw new UnderTransactionCategoryNotFoundException($"Under transaction category with Id = {id} has not");

        return utc.TransactionDetails;
    }

    public async Task UpdateTransactionDetails(List<TransactionDetail> transactionDetails, CancellationToken cancellationToken = default)
    {
        _ctx.TransactionDetails.UpdateRange(transactionDetails);
        await _ctx.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRangeAsync(List<TransactionDetail> transactionDetails, CancellationToken cancellationToken = default)
    {
        _ctx.TransactionDetails.RemoveRange(transactionDetails);
        await _ctx.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<TransactionDetail>> GetTransactionsForUserBetweenDates(string userEmail, DateOnly dateFrom,
        DateOnly dateTo)
    {
        DateTime dateFromWithTime = dateFrom.ToDateTime();
        DateTime dateToWithTime = dateTo.ToDateTime();
        
        return await _ctx.TransactionDetails.Where(x => x.CreatedBy == userEmail &&
                                                        x.TransactionDate >= dateFromWithTime &&
                                                        x.TransactionDate <= dateToWithTime)
            .IsActive()
            .ToListAsync();
    }
}