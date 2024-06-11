using MediatR;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.DeleteTransactionCategory;

public class DeleteTransactionCategoryCommandHandler : IRequestHandler<DeleteTransactionCategoryCommand>
{
	public async Task Handle(DeleteTransactionCategoryCommand request, CancellationToken cancellationToken)
	{
		
	}
}