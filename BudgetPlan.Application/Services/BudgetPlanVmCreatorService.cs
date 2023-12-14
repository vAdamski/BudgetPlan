using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Common.Extension;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.Dtos;
using BudgetPlan.Shared.ViewModels;
using Microsoft.Extensions.Logging;

namespace BudgetPlan.Application.Services;

public class BudgetPlanVmCreatorService : IBudgetPlanVmCreatorService
{
    private readonly IBudgetPlanBaseRepository _budgetPlanBaseRepository;
    private readonly ITransactionCategoriesRepository _transactionCategoriesRepository;
    private readonly ITransactionDetailsRepository _transactionDetailsRepository;
    private readonly ILogger<IBudgetPlanBaseRepository> _logger;
    private readonly string userEmail = string.Empty;

    public BudgetPlanVmCreatorService(IBudgetPlanBaseRepository budgetPlanBaseRepository,
        ITransactionCategoriesRepository transactionCategoriesRepository,
        ILogger<IBudgetPlanBaseRepository> logger,
        ITransactionDetailsRepository transactionDetailsRepository,
        ICurrentUserService currentUserService)
    {
        _budgetPlanBaseRepository = budgetPlanBaseRepository;
        _transactionCategoriesRepository = transactionCategoriesRepository;
        _transactionDetailsRepository = transactionDetailsRepository;
        userEmail = currentUserService.Email;
        _logger = logger;
    }

    public async Task<BudgetPlanViewModel> Create(Guid budgetPlanId)
    {
        BudgetPlanBase budgetPlanBase;

        try
        {
            budgetPlanBase = await GetBudgetPlan(budgetPlanId);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }

        List<BudgetPlanOverTransactionCategoryDto> otc = await GetOverTransactionCategories();
        
        otc = await FillUnderCategoriesWithTransactionDetails(otc, budgetPlanBase);

        BudgetPlanViewModel vm = new BudgetPlanViewModel(otc);

        return vm;
    }

    private async Task<BudgetPlanBase> GetBudgetPlan(Guid budgetPlanId)
    {
        try
        {
            return await _budgetPlanBaseRepository.GetByIdWithBudgetPlanDetailsList(budgetPlanId);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
    }

    private async Task<List<BudgetPlanOverTransactionCategoryDto>> GetOverTransactionCategories()
    {
        var transactionCategories = await _transactionCategoriesRepository
            .GetTransactionCategoriesWithUnderTransactionCategoriesForCurrentUser();

        List<BudgetPlanOverTransactionCategoryDto> tcs = new();

        transactionCategories.ForEach(otc =>
        {
            tcs.Add(new BudgetPlanOverTransactionCategoryDto(otc, otc.SubTransactionCategories));
        });

        return tcs;
    }

    private async Task<List<BudgetPlanOverTransactionCategoryDto>> FillUnderCategoriesWithTransactionDetails(
        List<BudgetPlanOverTransactionCategoryDto> otcs, BudgetPlanBase budgetPlanBase)
    {
        var transactionDetails =
            await _transactionDetailsRepository.GetTransactionsForUserBetweenDates(userEmail, budgetPlanBase.DateFrom,
                budgetPlanBase.DateTo);

        otcs.ForEach(otc =>
        {
            otc.UnderTransactionCategoryDtos.ForEach(utc =>
            {
                var x = transactionDetails
                    .Where(td => td.TransactionCategoryId == utc.UnderCategoryId)
                    .GroupBy(td => td.TransactionDate)
                    .Select(g => new TransactionItemsForDayDto(g.Key.ToDateOnly(), g.Select(x => new TransactionItemDto(x)).ToList()))
                    .ToList();

                double amountAllocated = budgetPlanBase.BudgetPlanDetailsList
                    .First(bpd => bpd.TransactionCategoryId == utc.UnderCategoryId).ExpectedAmount;
                
                utc.BudgetPlanDetailsDto = new BudgetPlanDetailsDto(x, amountAllocated);
            });
        });
        
        return otcs;
    }
}

