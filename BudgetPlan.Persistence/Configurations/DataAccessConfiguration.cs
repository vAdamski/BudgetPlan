using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetPlan.Persistence.Configurations;

public class DataAccessConfiguration : IBaseConfiguration<DataAccess>
{
    public void Configure(EntityTypeBuilder<DataAccess> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.AccessedPersons)
            .WithOne(y => y.DataAccess)
            .HasForeignKey(x => x.DataAccessId);
    }
}