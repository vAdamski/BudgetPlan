using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetPlan.Persistence.Configurations;

public class BudgetPlanConfiguration : IBaseConfiguration<Domain.Entities.BudgetPlan>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.BudgetPlan> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.BudgetPlanBases)
            .WithOne(x => x.BudgetPlan)
            .HasForeignKey(x => x.BudgetPlanId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}