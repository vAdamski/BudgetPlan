using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetPlan.Persistence.Configurations;

public class BudgetPlanEntityConfiguration : IBaseConfiguration<BudgetPlanEntity>
{
    public void Configure(EntityTypeBuilder<BudgetPlanEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.HasOne(x => x.DataAccess)
            .WithMany(y => y.BudgetPlanEntities)
            .HasForeignKey(x => x.DataAccessId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.BudgetPlanBases)
            .WithOne(y => y.BudgetPlanEntity)
            .HasForeignKey(x => x.BudgetPlanEntityId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}