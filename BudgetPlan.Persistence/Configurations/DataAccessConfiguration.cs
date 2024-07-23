using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetPlan.Persistence.Configurations;

public class DataAccessConfiguration : IBaseConfiguration<DataAccess>
{
    public void Configure(EntityTypeBuilder<DataAccess> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.HasMany(x => x.AccessedPersons)
            .WithOne(y => y.DataAccess)
            .IsRequired()
            .HasForeignKey(x => x.DataAccessId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}