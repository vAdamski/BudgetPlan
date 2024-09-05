using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetPlan.Persistence.Configurations;

public class TransactionDetailsConfiguration : IBaseConfiguration<TransactionDetail>
{
    public void Configure(EntityTypeBuilder<TransactionDetail> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Value).IsRequired();
        builder.Property(x => x.Description).IsRequired(false);
        builder.Property(x => x.TransactionDate).IsRequired();
        builder.Property(x => x.TransactionCategoryId).IsRequired();
        builder.Property(x => x.AccessId).IsRequired();
        
        builder.HasOne(x => x.TransactionCategory)
            .WithMany(y => y.TransactionDetails)
            .HasForeignKey(x => x.TransactionCategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Access)
            .WithMany(y => y.TransactionDetails)
            .HasForeignKey(x => x.AccessId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}