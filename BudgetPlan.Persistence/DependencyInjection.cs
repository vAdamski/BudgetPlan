using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Persistence.Respositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetPlan.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<BudgetPlanDbContext>(options => options.UseSqlServer(ConnectionStringDbContext.GetConnectionString()));
        services.AddScoped<IBudgetPlanDbContext, BudgetPlanDbContext>();
        services.AddTransient<IBudgetPlanBaseRepository, BudgetPlanBaseRepository>();
        services.AddTransient<ITransactionDetailsRepository, TransactionDetailsRepository>();
        services.AddTransient<ITransactionCategoriesRepository, TransactionCategoriesRepository>();
        
        return services;
    }
}