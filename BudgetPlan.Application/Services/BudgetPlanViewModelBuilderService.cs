using System.Runtime.Intrinsics.X86;
using BudgetPlan.Application.Common.Interfaces.Services;
using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.BudgetPlan.Queries.GetBudgetPlanView;

public class BudgetPlanViewModelBuilderService : IBudgetPlanViewModelBuilderService
{
    private readonly IPrepareViewModelTransactionsCategoriesService _prepareViewModelTransactionsCategoriesService;

    public BudgetPlanViewModelBuilderService(IPrepareViewModelTransactionsCategoriesService prepareViewModelTransactionsCategoriesService)
    {
        _prepareViewModelTransactionsCategoriesService = prepareViewModelTransactionsCategoriesService;
    }
    
    public async Task<BudgetPlanViewModel> Build(Guid budgetPlanId, CancellationToken cancellationToken = default)
    {
        var transactionCategoriesViewModel = await _prepareViewModelTransactionsCategoriesService.PrepareViewModelTransactionsCategories(cancellationToken);
        
        
        
        var vm = new BudgetPlanViewModel(transactionCategoriesViewModel);

        return vm;
    }
}

