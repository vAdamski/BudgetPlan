using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence.Respositories;

public class TransactionDetailsRepository : ITransactionDetailsRepository
{
    private readonly IBudgetPlanDbContext _ctx;

    public TransactionDetailsRepository(IBudgetPlanDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<TransactionDetail>> GetTransactionsForUserBetweenDates(string userEmail, DateTime dateFrom,
        DateTime dateTo)
    {
         return await _ctx.TransactionDetails.Where(x => x.CreatedBy == userEmail &&
                                                 x.TransactionDate >= dateFrom &&
                                                 x.TransactionDate <= dateTo &&
                                                 x.StatusId == 1)
            .ToListAsync();
    }
}