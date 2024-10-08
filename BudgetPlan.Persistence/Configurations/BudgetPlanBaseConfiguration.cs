using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetPlan.Persistence.Configurations;

public class BudgetPlanBaseConfiguration : IBaseConfiguration<BudgetPlanBase>
{
    public void Configure(EntityTypeBuilder<BudgetPlanBase> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).ValueGeneratedNever();
        
        builder.Property(x => x.DateFrom).IsRequired();
        builder.Property(x => x.DateTo).IsRequired();
        
        builder.Property(x => x.BudgetPlanEntityId).IsRequired();
        builder.Property(x => x.DataAccessId).IsRequired();
        
        builder.HasOne(x => x.DataAccess)
            .WithMany(y => y.BudgetPlanBases)
            .HasForeignKey(x => x.DataAccessId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.BudgetPlanEntity)
            .WithMany(y => y.BudgetPlanBases)
            .HasForeignKey(x => x.BudgetPlanEntityId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}