using System.Reflection;
using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Common;
using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence;

public class BudgetPlanDbContext : DbContext, IBudgetPlanDbContext
{
    private readonly IDateTime _dateTime;
    private readonly ICurrentUserService _userService;

    public BudgetPlanDbContext(DbContextOptions<BudgetPlanDbContext> options) : base(options)
    {
    }

    public BudgetPlanDbContext(DbContextOptions<BudgetPlanDbContext> options, IDateTime dateTime,
        ICurrentUserService userService) : base(options)
    {
        _dateTime = dateTime;
        _userService = userService;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    public DbSet<TransactionCategory> TransactionCategories { get; set; }
    public DbSet<TransactionDetail> TransactionDetails { get; set; }
    public DbSet<BudgetPlanDetails> BudgetPlanDetails { get; set; }
    public DbSet<BudgetPlanBase> BudgetPlanBases { get; set; }
    public DbSet<Access> Accesses { get; set; }
    public DbSet<AccessedPerson> AccessedPersons { get; set; }
    public DbSet<BudgetPlanEntity> BudgetPlanEntities { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Deleted:
                    entry.Entity.ModifiedBy = _userService.Email;
                    entry.Entity.Modified = _dateTime.Now;
                    entry.Entity.Inactivated = _dateTime.Now;
                    entry.Entity.InactivatedBy = _userService.Email;
                    entry.Entity.StatusId = 0;
                    entry.State = EntityState.Modified;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedBy = _userService.Email;
                    entry.Entity.Modified = _dateTime.Now;
                    break;
                case EntityState.Added:
                    entry.Entity.CreatedBy = _userService.Email;
                    entry.Entity.Created = _dateTime.Now;
                    entry.Entity.StatusId = 1;
                    break;
                default:
                    break;
            }
        }

        foreach (var entry in ChangeTracker.Entries<ValueObject>())
        {
            switch (entry.State)
            {
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    break;
                default:
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}