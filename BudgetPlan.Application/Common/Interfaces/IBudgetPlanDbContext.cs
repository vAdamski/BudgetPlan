using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.Common.Interfaces;

public interface IBudgetPlanDbContext
{
    DbSet<TransactionCategory> TransactionCategories { get; set; }
    DbSet<TransactionDetails> TransactionDetails { get; set; }
    DbSet<BudgetPlanDetails> BudgetPlanDetails { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}