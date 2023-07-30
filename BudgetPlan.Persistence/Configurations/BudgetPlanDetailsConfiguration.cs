using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetPlan.Persistence.Configurations;

public class BudgetPlanDetailsConfiguration : IBaseConfiguration<BudgetPlanDetails>
{
    public void Configure(EntityTypeBuilder<BudgetPlanDetails> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Value).HasDefaultValue(0f).IsRequired();
        builder.Property(x => x.Description);
        builder.Property(x => x.BudgetPlanType).IsRequired();
        builder.Property(x => x.DateFrom).IsRequired();
        builder.Property(x => x.DateTo).IsRequired();
    }
}