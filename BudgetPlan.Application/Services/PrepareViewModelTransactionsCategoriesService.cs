using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Application.Common.Interfaces.Services;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.Dtos;
using Microsoft.Extensions.Logging;

namespace BudgetPlan.Application.Services;

public class PrepareViewModelTransactionsCategoriesService : IPrepareViewModelTransactionsCategoriesService
{
    private readonly ITransactionCategoriesRepository _transactionCategoriesRepository;
    private readonly ILogger<PrepareViewModelTransactionsCategoriesService> _logger;

    public PrepareViewModelTransactionsCategoriesService(
        ITransactionCategoriesRepository transactionCategoriesRepository,
        ILogger<PrepareViewModelTransactionsCategoriesService> logger)
    {
        _transactionCategoriesRepository = transactionCategoriesRepository;
        _logger = logger;
    }

    public async Task<List<BudgetPlanOverTransactionCategoryDto>> PrepareViewModelTransactionsCategories(
        CancellationToken cancellationToken = default)
    {
        try
        {
            var transactionCategories = await GetTransactionCategories(cancellationToken);
            
            return PrepareViewModelOverTransactionCategories(transactionCategories);
        }
        catch (Exception e)
        {
            _logger.LogError("Error while preparing view model transactions categories.", e);
            throw;
        }
    }

    private List<BudgetPlanOverTransactionCategoryDto> PrepareViewModelOverTransactionCategories(
        List<TransactionCategory> transactionCategories)
    {
        try
        {
            var overTransactionCategories = GetOverTransactionCategories(transactionCategories);
        
            var budgetPlanOverTransactionCategoryDtos = new List<BudgetPlanOverTransactionCategoryDto>();

            foreach (var overTransactionCategory in overTransactionCategories)
            {
                var underTransactionCategories = GetUnderTransactionCategoriesForOverTransactionCategory(
                    transactionCategories, overTransactionCategory.Id);
            
                budgetPlanOverTransactionCategoryDtos.Add(new BudgetPlanOverTransactionCategoryDto(overTransactionCategory, underTransactionCategories));
            }

            return budgetPlanOverTransactionCategoryDtos;
        }
        catch (Exception e)
        {
            _logger.LogError("Error while preparing view model over transaction categories.", e);
            throw;
        }
    }

    private async Task<List<TransactionCategory>> GetTransactionCategories(CancellationToken cancellationToken)
    {
        try
        {
            return await _transactionCategoriesRepository.GetTransactionCategoriesWithUnderTransactionCategoriesForCurrentUser(cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private List<TransactionCategory> GetOverTransactionCategories(List<TransactionCategory> transactionCategories)
    {
        return transactionCategories.Where(x => x.OverTransactionCategoryId == null).ToList();
    }

    private List<TransactionCategory> GetUnderTransactionCategoriesForOverTransactionCategory(
        List<TransactionCategory> transactionCategories, Guid overTransactionCategoryId)
    {
        return transactionCategories.Where(x => x.OverTransactionCategoryId == overTransactionCategoryId).ToList();
    }
}

public interface ITransactionCategoriesDtoFillerService
{
    Task<List<BudgetPlanOverTransactionCategoryDto>> FillUnderTransactionCategoriesDtos(
        List<BudgetPlanOverTransactionCategoryDto> transactionCategories, CancellationToken cancellationToken = default);
}

public class TransactionCategoriesDtoFillerService : ITransactionCategoriesDtoFillerService
{
    public TransactionCategoriesDtoFillerService()
    {
        
    }
    
    public Task<List<BudgetPlanOverTransactionCategoryDto>> FillUnderTransactionCategoriesDtos(List<BudgetPlanOverTransactionCategoryDto> transactionCategories, CancellationToken cancellationToken = default)
    {
        foreach (var transactionCategory in transactionCategories)
        {
            foreach (var underTransactionCategory in transactionCategory.UnderTransactionCategoryDtos)
            {
                
            }
        }

        throw new NotImplementedException();
    }
    
    
}