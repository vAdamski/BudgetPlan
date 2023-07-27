using BudgetPlan.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetPlan.Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddDbContext<BudgetPlanDbContext>(options => options.UseSqlServer(ConnectionStringDbContext.GetConnectionString()));
        services.AddScoped<IBudgetPlanDbContext, BudgetPlanDbContext>();

        return services;
    }
}