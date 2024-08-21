using System.Reflection;
using BudgetPlan.Application.Builders;
using BudgetPlan.Application.Common.Behaviours;
using BudgetPlan.Application.Common.Interfaces.Builders;
using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Application.Common.Interfaces.Services;
using BudgetPlan.Application.Managers;
using BudgetPlan.Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetPlan.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // DI
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        // Services
        services.AddTransient<ITransactionCategoryManager, TransactionCategoryManager>();
        services.AddTransient<IBudgetPlanManager, BudgetPlanManager>();
        services.AddTransient<ITransactionDetailsManager, TransactionDetailsManager>();
        services.AddTransient<IBudgetPlanDetailsManager, BudgetPlanDetailsManager>();
        services.AddTransient<IBudgetPlanBaseViewModelBuilder, BudgetPlanBaseViewModelBuilder>();
        services.AddTransient<IBudgetPlanBaseManager, BudgetPlanBaseManager>();
        services.AddTransient<IDataAccessManager, DataAccessManager>();
        
        services.AddTransient<IDeleteTransactionCategoryLogic, DeleteTransactionCategoryLogic>();
        services.AddTransient<ITransactionCategoryDataSummaryCollector, TransactionCategoryTransactionCategoryDataSummaryCollector>();
        services.AddTransient<IIncomesExpenseDataSummaryCollector, IncomesExpenseDataSummaryCollector>();
        
        // Pipelines
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        
        return services;
    }
}