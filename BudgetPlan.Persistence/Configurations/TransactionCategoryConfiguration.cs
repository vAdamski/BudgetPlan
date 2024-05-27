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
        
        
        builder.HasOne(x => x.OverTransactionCategory)
            .WithMany(y => y.SubTransactionCategories)
            .HasForeignKey(x => x.OverTransactionCategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.BudgetPlan)
            .WithMany(y => y.TransactionCategories)
            .HasForeignKey(x => x.BudgetPlanId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Access)
            .WithMany(y => y.TransactionCategories)
            .HasForeignKey(x => x.AccessId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}