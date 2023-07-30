using BudgetPlan.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetPlan.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<BudgetPlanDbContext>(options => options.UseSqlServer(ConnectionStringDbContext.GetConnectionString()));

        return services;
    }
}