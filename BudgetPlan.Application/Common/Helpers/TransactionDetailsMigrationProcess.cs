using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Application.Common.Helpers;

public static class TransactionDetailsMigrationProcess
{
	public static void MigrateTransactionDetails(List<TransactionCategory> transactionCategories,
		Guid transactionCategoryIdFrom, Guid transactionCategoryIdTo)
	{
		var transactionCategoryMigrateFrom =
			FindTransactionCategoryInStack.FindTransactionCategoryRecursively(transactionCategories, transactionCategoryIdFrom);
		
		var transactionCategoryMigrateTo =
			FindTransactionCategoryInStack.FindTransactionCategoryRecursively(transactionCategories, transactionCategoryIdTo);
		
		if (transactionCategoryMigrateFrom == null)
			throw new NotFoundException(nameof(TransactionCategory), transactionCategoryIdFrom);
		
		if (transactionCategoryMigrateTo == null)
			throw new NotFoundException(nameof(TransactionCategory), transactionCategoryIdTo);
		
		if (transactionCategoryMigrateTo.IsOverCategory)
			throw new Exception("Cannot migrate transaction details to over transaction category.");
			
		List<TransactionDetail> transactionDetailsToMigrate = new();

		if (transactionCategoryMigrateFrom.IsOverCategory)
		{
			foreach (var subTransactionCategory in transactionCategoryMigrateFrom.SubTransactionCategories)
			{
				transactionDetailsToMigrate.AddRange(subTransactionCategory.TransactionDetails);
				subTransactionCategory.ClearTransactionDetails();
			}
		}
		else
		{
			transactionDetailsToMigrate.AddRange(transactionCategoryMigrateFrom.TransactionDetails);
			transactionCategoryMigrateFrom.ClearTransactionDetails();
		}
		
		transactionDetailsToMigrate.ForEach(transactionDetail => transactionDetail.UpdateTransactionCategory(transactionCategoryIdTo));
		
		transactionCategoryMigrateTo.AddTransactionDetails(transactionDetailsToMigrate);
	}
}