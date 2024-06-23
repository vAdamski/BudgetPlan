using BudgetPlan.Application.Common.Helpers;
using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Common.Extension;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Application.Managers;

public class TransactionCategoryManager(
	ITransactionCategoriesRepository transactionCategoriesRepository,
	ITransactionDetailsRepository transactionDetailsRepository,
	IBudgetPlanRepository budgetPlanRepository)
	: ITransactionCategoryManager
{
	public async Task<Guid> AddTransactionCategoryAsync(Guid overTransactionCategoryId, string categoryName,
		CancellationToken cancellationToken = default)
	{ 
		ValidateInputs(overTransactionCategoryId, categoryName);
		var mainTransactionCategory =
			await GetMainTransactionCategoryAsync(overTransactionCategoryId, cancellationToken);

		var transactionCategory =
			await AddSubTransactionCategoryAsync(mainTransactionCategory, categoryName, cancellationToken);
		
		await UpdateBudgetPlanAsync(mainTransactionCategory.BudgetPlanId.Value, transactionCategory, cancellationToken);
		
		return transactionCategory.Id;
	}

	public async Task DeleteTransactionCategoryAsync(Guid id, Guid? transactionCategoryItemsDestination = null,
		CancellationToken cancellationToken = default)
	{
		var transactionCategories =
			await transactionCategoriesRepository.GetAllTransactionCategoriesWithTransactionDetails(cancellationToken);

		if (transactionCategoryItemsDestination != null)
			TransactionDetailsMigrationProcess.MigrateTransactionDetails(transactionCategories, id,
				transactionCategoryItemsDestination.Value);

		await transactionCategoriesRepository.UpdateRangeAsync(transactionCategories, cancellationToken);

		await transactionCategoriesRepository.DeleteAsync(id, cancellationToken);
	}

	private void ValidateInputs(Guid overTransactionCategoryId, string categoryName)
	{
		if (overTransactionCategoryId.IsNullOrEmpty())
			throw new ArgumentException("Over transaction category id is null or empty.",
				nameof(overTransactionCategoryId));
		if (string.IsNullOrEmpty(categoryName))
			throw new ArgumentException("Category name cannot be null or empty.", nameof(categoryName));
	}

	private async Task<TransactionCategory> GetMainTransactionCategoryAsync(Guid id,
		CancellationToken cancellationToken)
	{
		var otc = await transactionCategoriesRepository.GetOverTransactionCategoryAsync(id, cancellationToken);
		if (otc == null)
			throw new NotFoundException(nameof(otc), id);

		return otc;
	}

	private async Task<TransactionCategory> AddSubTransactionCategoryAsync(TransactionCategory overTransactionCategory,
		string categoryName, CancellationToken cancellationToken)
	{
		var transactionCategory = overTransactionCategory.AddSubTransactionCategory(categoryName);
		await transactionCategoriesRepository.UpdateAsync(overTransactionCategory, cancellationToken);
		return transactionCategory;
	}

	private async Task UpdateBudgetPlanAsync(Guid budgetPlanId, TransactionCategory transactionCategory,
		CancellationToken cancellationToken)
	{
		if (budgetPlanId.IsNullOrEmpty())
			throw new ArgumentException("Budget plan id is null or empty.", nameof(budgetPlanId));

		var budgetPlan = await budgetPlanRepository.GetByIdAsync(budgetPlanId, cancellationToken);
		foreach (var budgetPlanBase in budgetPlan.BudgetPlanBases)
		{
			budgetPlanBase.AddBudgetPlanDetail(transactionCategory.Id);
		}

		await budgetPlanRepository.UpdateAsync(budgetPlan, cancellationToken);
	}
}