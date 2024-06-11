using BudgetPlan.Application.Common.Helpers;
using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Common.Extension;
using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Managers;

public class TransactionCategoryManager(ITransactionCategoriesRepository transactionCategoriesRepository, ITransactionDetailsRepository transactionDetailsRepository)
	: ITransactionCategoryManager
{
	public async Task<Guid> AddTransactionCategoryAsync(Guid overTransactionCategoryId,
		string categoryName, CancellationToken cancellationToken = default)
	{
		if (overTransactionCategoryId.IsNullOrEmpty())
			throw new ArgumentException("Over transaction category id id is null or empty.",
				nameof(overTransactionCategoryId));

		if (string.IsNullOrEmpty(categoryName))
			throw new ArgumentException("Category name cannot be null or empty.", nameof(categoryName));

		var otc = await transactionCategoriesRepository.GetOverTransactionCategoryAsync(overTransactionCategoryId,
			cancellationToken);

		var transactionCategory = otc.AddSubTransactionCategory(categoryName);

		await transactionCategoriesRepository.UpdateAsync(otc, cancellationToken);

		return transactionCategory.Id;
	}

	public async Task DeleteTransactionCategoryAsync(Guid id, Guid? transactionCategoryItemsDestination = null,
		CancellationToken cancellationToken = default)
	{
		var transactionCategories = await transactionCategoriesRepository.GetAllTransactionCategoriesWithTransactionDetails(cancellationToken);
		
		if (transactionCategoryItemsDestination != null)
			TransactionDetailsMigrationProcess.MigrateTransactionDetails(transactionCategories, id, transactionCategoryItemsDestination.Value);
		
		await transactionCategoriesRepository.UpdateRangeAsync(transactionCategories, cancellationToken);
		
		await transactionCategoriesRepository.DeleteAsync(id, cancellationToken);
	}
}