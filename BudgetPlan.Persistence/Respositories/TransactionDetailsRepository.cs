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

    
}