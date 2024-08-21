using BudgetPlan.Application.Common.Interfaces.Services;
using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.DeleteTransactionCategory;

public class DeleteTransactionCategoryCommandHandler(IDeleteTransactionCategoryLogic deleteTransactionCategoryLogic) : IRequestHandler<DeleteTransactionCategoryCommand>
{
	public async Task Handle(DeleteTransactionCategoryCommand request, CancellationToken cancellationToken)
	{
		await deleteTransactionCategoryLogic.DeleteTransactionCategory(request.TransactionCategory, cancellationToken);
	}
}