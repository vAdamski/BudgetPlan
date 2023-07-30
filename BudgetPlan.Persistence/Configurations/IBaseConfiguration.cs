using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetPlan.Persistence.Configurations;

public interface IBaseConfiguration<T> where T : class
{
    public void Configure(EntityTypeBuilder<T> builder);
}