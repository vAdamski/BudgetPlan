using BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.AddTransactionDetail;
using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Managers;

public class TransactionDetailsManager(
	ITransactionCategoriesRepository transactionCategoriesRepository,
	ITransactionDetailsRepository transactionDetailsRepository)
	: ITransactionDetailsManager
{
	public async Task<Guid> CreateAsync(AddTransactionDetailCommand request,
		CancellationToken cancellationToken = default)
	{
		var transactionCategory =
			await transactionCategoriesRepository.GetByIdAsync(request.TransactionCategoryId, cancellationToken);

		var transactionDetail =
			transactionCategory.AddTransactionDetail(request.Value, request.Description, request.TransactionDate);

		await transactionCategoriesRepository.UpdateAsync(transactionCategory, cancellationToken);

		return transactionDetail.Id;
	}

	public async Task UpdateAsync(Guid requestId, UpdateTransactionDetailsViewModel requestViewModel,
		CancellationToken cancellationToken = default)
	{
		TransactionDetail transactionDetail =
			await transactionDetailsRepository.GetByIdAsync(requestId, cancellationToken);
		
		transactionDetail.Update(requestViewModel.Value, requestViewModel.Description, requestViewModel.Date);

		await transactionDetailsRepository.UpdateAsync(transactionDetail, cancellationToken);
	}

	public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
	{
		await transactionDetailsRepository.DeleteAsync(id, cancellationToken);
	}
}