using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Application.Common.Interfaces;

public interface IBudgetPlanDbContext
{
    DbSet<TransactionCategory> TransactionCategories { get; set; }
    DbSet<TransactionDetail> TransactionDetails { get; set; }
    DbSet<Domain.Entities.BudgetPlanDetails> BudgetPlanDetails { get; set; }
    DbSet<Domain.Entities.BudgetPlan> BudgetPlans { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}