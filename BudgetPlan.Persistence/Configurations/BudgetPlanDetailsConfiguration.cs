using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetPlan.Persistence.Configurations;

public class BudgetPlanDetailsConfiguration : IBaseConfiguration<BudgetPlanDetails>
{
    public void Configure(EntityTypeBuilder<BudgetPlanDetails> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ExpectedAmount).HasDefaultValue(0f).IsRequired();
        builder.Property(x => x.BudgetPlanType).IsRequired();
        

        builder.HasOne(x => x.BudgetPlanBase)
            .WithMany(x => x.BudgetPlanDetailsList)
            .HasForeignKey(x => x.BudgetPlanId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.TransactionCategory)
            .WithMany(x => x.BudgetPlanDetails)
            .HasForeignKey(x => x.TransactionCategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}