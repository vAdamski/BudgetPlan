using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetPlan.Persistence.Configurations;

public class BudgetPlanDetailsConfiguration : IBaseConfiguration<BudgetPlanDetails>
{
    public void Configure(EntityTypeBuilder<BudgetPlanDetails> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.ExpectedAmount).HasDefaultValue(0f).IsRequired();
        builder.Property(x => x.BudgetPlanType).IsRequired();

        builder.HasOne(x => x.BudgetPlanBase)
            .WithMany(y => y.BudgetPlanDetailsList)
            .HasForeignKey(x => x.BudgetPlanBaseId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(x => x.TransactionCategory)
            .WithMany(y => y.BudgetPlanDetails)
            .HasForeignKey(x => x.TransactionCategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.DataAccess)
            .WithMany(y => y.BudgetPlanDetails)
            .HasForeignKey(x => x.DataAccessId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}