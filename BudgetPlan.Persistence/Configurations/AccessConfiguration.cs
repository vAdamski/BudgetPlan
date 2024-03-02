using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetPlan.Persistence.Configurations;

public class AccessConfiguration : IBaseConfiguration<Access>
{
    public void Configure(EntityTypeBuilder<Access> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.AccessedPersons)
            .WithOne(x => x.Access)
            .HasForeignKey(x => x.AccessId);

        builder.HasMany(x => x.BudgetPlanBases)
            .WithOne(x => x.Access)
            .HasForeignKey(x => x.AccessId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(x => x.BudgetPlanDetails)
            .WithOne(x => x.Access)
            .HasForeignKey(x => x.AccessId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(x => x.TransactionCategories)
            .WithOne(x => x.Access)
            .HasForeignKey(x => x.AccessId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(x => x.TransactionDetails)
            .WithOne(x => x.Access)
            .HasForeignKey(x => x.AccessId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}