using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Application.Common.Interfaces.Services;
using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Services;

public class DeleteTransactionCategoryLogic(
	ITransactionCategoriesRepository transactionCategoriesRepository,
	ITransactionDetailsRepository transactionDetailsRepository,
	IUnitOfWork unitOfWork) : IDeleteTransactionCategoryLogic
{
	public async Task DeleteTransactionCategory(Guid transactionCategoryId, CancellationToken cancellationToken = default)
	{
		await unitOfWork.BeginTransactionAsync();

		try
		{
			var isOverTransactionCategory =
				await transactionCategoriesRepository.IsOverTransactionCategoryAsync(transactionCategoryId, cancellationToken);

			TransactionCategory transactionCategoryToDelete;

			if (isOverTransactionCategory)
			{
				transactionCategoryToDelete = await transactionCategoriesRepository
					.GetOverTransactionCategoryWithTransactionDetailsByIdAsync(transactionCategoryId, cancellationToken);
			}
			else
			{
				transactionCategoryToDelete =
					await transactionCategoriesRepository.GetSubTransactionWithTransactionDetailsByIdAsync(
						transactionCategoryId, cancellationToken);
			}

			List<TransactionDetail> transactionDetailsToDelete = new();

			if (isOverTransactionCategory)
			{
				transactionDetailsToDelete.AddRange(transactionCategoryToDelete.SubTransactionCategories
					.SelectMany(x => x.TransactionDetails));
			}
			else
			{
				transactionDetailsToDelete.AddRange(transactionCategoryToDelete.TransactionDetails);
			}

			await transactionDetailsRepository.DeleteRangeAsync(transactionDetailsToDelete, cancellationToken);
			
			await transactionCategoriesRepository.DeleteAsync(transactionCategoryToDelete, cancellationToken);
		}
		catch (Exception e)
		{
			await unitOfWork.RollbackTransactionAsync();
			throw;
		}

		await unitOfWork.CommitTransactionAsync();
	}
}