using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Persistence.Respositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetPlan.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BudgetPlanDbContext>(options => options.UseSqlServer(configuration.GetConnectionString()));
        services.AddScoped<IBudgetPlanDbContext, BudgetPlanDbContext>();
        services.AddTransient<IBudgetPlanBaseRepository, BudgetPlanBaseRepository>();
        services.AddTransient<ITransactionDetailsRepository, TransactionDetailsRepository>();
        services.AddTransient<ITransactionCategoriesRepository, TransactionCategoriesRepository>();
        services.AddTransient<IBudgetPlanDetailsRepository, BudgetPlanDetailsRepository>();
        
        return services;
    }
    
    private static string GetConnectionString(this IConfiguration configuration)
    {
        string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        
        if (string.IsNullOrEmpty(connectionString))
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        
        return connectionString;
    }
}