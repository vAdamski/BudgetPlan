using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Common.Extension;

namespace BudgetPlan.Application.Managers;

public class TransactionCategoryManager(ITransactionCategoriesRepository transactionCategoriesRepository) : ITransactionCategoryManager
{
	public async Task<Guid> AddTransactionCategoryAsync(Guid overTransactionCategoryId,
		string categoryName, CancellationToken cancellationToken = default)
	{
		
		if (overTransactionCategoryId.IsNullOrEmpty())
			throw new ArgumentException("Over transaction category id id is null or empty.", nameof(overTransactionCategoryId));

		if (string.IsNullOrEmpty(categoryName))
			throw new ArgumentException("Category name cannot be null or empty.", nameof(categoryName));

		var otc = await transactionCategoriesRepository.GetOverTransactionCategoryAsync(overTransactionCategoryId, cancellationToken);

		var transactionCategory = otc.AddSubTransactionCategory(categoryName);

		await transactionCategoriesRepository.UpdateAsync(otc, cancellationToken);

		return transactionCategory.Id;
	}
}