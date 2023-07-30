using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.Dtos;
using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Services;

public class TransactionCategoryListViewModelFactory : ITransactionCategoryListViewModelFactory
{
    public TransactionCategoryListViewModel Create(List<TransactionCategory> transactionCategories)
    {
        var transactionCategoryListViewModel = new TransactionCategoryListViewModel();

        foreach (var overTransactionCategory in transactionCategories.Where(x => x.OverTransactionCategoryId == null)
                     .ToList())
        {
            var overTransactionCategoryDto = new OverTransactionCategoryDto
            {
                Id = overTransactionCategory.Id,
                TransactionCategoryName = overTransactionCategory.TransactionCategoryName,
            };

            foreach (var transactionCategory in transactionCategories.Where(y =>
                         y.OverTransactionCategoryId == overTransactionCategory.Id))
            {
                overTransactionCategoryDto.TransactionCategoryDtos.Add(new TransactionCategoryDto
                {
                    Id = transactionCategory.Id,
                    TransactionCategoryName = transactionCategory.TransactionCategoryName
                });
            }
            
            transactionCategoryListViewModel.OverTransactionCategoryList.Add(overTransactionCategoryDto);
        }

        return transactionCategoryListViewModel;
    }
}