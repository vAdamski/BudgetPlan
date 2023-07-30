using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetPlan.Persistence.Configurations;

public class TransactionCategoryConfiguration : IBaseConfiguration<TransactionCategory>
{
    public void Configure(EntityTypeBuilder<TransactionCategory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TransactionCategoryName).IsRequired();
        builder.Property(x => x.TransactionType).IsRequired();
        builder.Property(x => x.OverTransactionCategoryId).IsRequired(false);
        
        builder.HasMany(x => x.BudgetPlanDetails)
            .WithOne(x => x.TransactionCategory);
    }
}