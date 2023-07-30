using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Common.Interfaces;

public interface ITransactionCategoryListViewModelFactory
{
    TransactionCategoryListViewModel Create(List<TransactionCategory> transactionCategories);
}