using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Common.Helpers;
using BudgetPlan.Persistence.Respositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetPlan.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = ConnectionStringGetter.GetConnectionString(configuration);
        
        services.AddDbContext<BudgetPlanDbContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging(false));
        services.AddScoped<IBudgetPlanDbContext, BudgetPlanDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddTransient<IBudgetPlanBaseRepository, BudgetPlanBaseRepository>();
        services.AddTransient<ITransactionDetailsRepository, TransactionDetailsRepository>();
        services.AddTransient<ITransactionCategoriesRepository, TransactionCategoriesRepository>();
        services.AddTransient<IBudgetPlanDetailsRepository, BudgetPlanDetailsRepository>();
        services.AddTransient<IBudgetPlanRepository, BudgetPlanRepository>();
        services.AddTransient<IDataAccessRepository, DataAccessRepository>();
        services.AddTransient<IAccessedPersonsRepository, AccessedPersonsRepository>();
        
        return services;
    }
}