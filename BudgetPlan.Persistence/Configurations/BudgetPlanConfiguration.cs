using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetPlan.Persistence.Configurations;

public class BudgetPlanConfiguration : IBaseConfiguration<Domain.Entities.BudgetPlanEntity>
{
    public void Configure(EntityTypeBuilder<BudgetPlanEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.BudgetPlanBases)
            .WithOne(x => x.BudgetPlanEntity)
            .HasForeignKey(x => x.BudgetPlanEntityId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}