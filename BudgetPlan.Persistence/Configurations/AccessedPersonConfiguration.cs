using BudgetPlan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetPlan.Persistence.Configurations;

public class AccessedPersonConfiguration : IBaseConfiguration<AccessedPerson>
{
    public void Configure(EntityTypeBuilder<AccessedPerson> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();
        
        builder.Property(x => x.Email).IsRequired();
    }
}