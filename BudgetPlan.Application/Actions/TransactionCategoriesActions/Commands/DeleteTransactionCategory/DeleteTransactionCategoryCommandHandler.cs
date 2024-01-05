using BudgetPlan.Application.Common.Interfaces.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.DeleteTransactionCategory;

public class DeleteTransactionCategoryCommandHandler : IRequestHandler<DeleteTransactionCategoryCommand>
{
    private readonly IDeleteTransactionCategoryService _deleteTransactionCategoryService;
    private readonly ILogger<DeleteTransactionCategoryCommandHandler> _logger;

    public DeleteTransactionCategoryCommandHandler(IDeleteTransactionCategoryService deleteTransactionCategoryService,
        ILogger<DeleteTransactionCategoryCommandHandler> logger)
    {
        _deleteTransactionCategoryService = deleteTransactionCategoryService;
        _logger = logger;
    }
    
    public async Task Handle(DeleteTransactionCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _deleteTransactionCategoryService.DeleteTransactionCategory(request.Id, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while deleting transaction category");
            throw;
        }
    }
}