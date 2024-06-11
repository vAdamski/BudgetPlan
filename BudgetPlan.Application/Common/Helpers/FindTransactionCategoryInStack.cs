using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Helpers;

public static class FindTransactionCategoryInStack
{
	public static TransactionCategory FindTransactionCategoryRecursively(
		List<TransactionCategory> transactionCategories,
		Guid id)
	{
		var foundCategory = transactionCategories.FirstOrDefault(category => category.Id == id);

		if (foundCategory != null)
		{
			return foundCategory;
		}

		return FindInNestedCategories(transactionCategories, id);
	}

	private static TransactionCategory FindInNestedCategories(List<TransactionCategory> transactionCategories, Guid id)
	{
		foreach (var transactionCategory in transactionCategories)
		{
			var nestedCategories = transactionCategory.SubTransactionCategories.ToList();

			if (!nestedCategories.Any())
			{
				continue;
			}

			var foundCategory = FindTransactionCategoryRecursively(nestedCategories, id);

			if (foundCategory != null)
			{
				return foundCategory;
			}
		}

		return null;
	}
}