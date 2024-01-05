using BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.DeleteTransactionCategory;
using BudgetPlan.Application.Common.Interfaces.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.DeleteTransactionCategoryWithMigrationAction;

public class DeleteTransactionCategoryWithMigrationActionCommandHandler : IRequestHandler<DeleteTransactionCategoryWithMigrationActionCommand>
{
    private readonly IDeleteTransactionCategoryService _deleteTransactionCategoryService;
    private readonly ILogger<DeleteTransactionCategoryCommandHandler> _logger;

    public DeleteTransactionCategoryWithMigrationActionCommandHandler(
        IDeleteTransactionCategoryService deleteTransactionCategoryService,
        ILogger<DeleteTransactionCategoryCommandHandler> logger)
    {
        _deleteTransactionCategoryService = deleteTransactionCategoryService;
        _logger = logger;
    }

    public async Task Handle(DeleteTransactionCategoryWithMigrationActionCommand request, 
        CancellationToken cancellationToken)
    {
        try
        {
            await _deleteTransactionCategoryService
                .DeleteTransactionCategoryWithMigrationItems(request.Id, request.MigrationId, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while deleting transaction category");
            throw;
        }
    }
}