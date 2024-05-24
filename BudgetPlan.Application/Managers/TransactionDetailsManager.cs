using BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.AddTransactionDetail;
using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Application.Common.Interfaces.Repositories;

namespace BudgetPlan.Application.Managers;

public class TransactionDetailsManager(ITransactionCategoriesRepository transactionCategoriesRepository)
	: ITransactionDetailsManager
{
	public async Task<Guid> CreateAsync(AddTransactionDetailCommand request,
		CancellationToken cancellationToken = default)
	{
		var transactionCategory =
			await transactionCategoriesRepository.GetByIdAsync(request.TransactionCategoryId, cancellationToken);

		var transactionDetail = transactionCategory.AddTransactionDetail(request.Value, request.Description, request.TransactionDate);

		await transactionCategoriesRepository.UpdateAsync(transactionCategory, cancellationToken);

		return transactionDetail.Id;
	}
}