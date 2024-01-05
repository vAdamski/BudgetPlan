using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Application.Common.Interfaces.Services;
using BudgetPlan.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace BudgetPlan.Application.Services.DeleteTransactionCategory;

public class DeleteTransactionCategoryService : IDeleteTransactionCategoryService
{
    private readonly ITransactionCategoriesRepository _transactionCategoriesRepository;
    private readonly ITransactionDetailsRepository _transactionDetailsRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger<DeleteTransactionCategoryService> _logger;

    public DeleteTransactionCategoryService(
        ITransactionCategoriesRepository transactionCategoriesRepository,
        ICurrentUserService currentUserService,
        ILogger<DeleteTransactionCategoryService> logger, 
        ITransactionDetailsRepository transactionDetailsRepository)
    {
        _transactionCategoriesRepository = transactionCategoriesRepository;
        _currentUserService = currentUserService;
        _logger = logger;
        _transactionDetailsRepository = transactionDetailsRepository;
    }

    public async Task DeleteTransactionCategory(Guid id, CancellationToken cancellationToken = default)
    {
        await DeleteTransactionCategory(id, _currentUserService.Email, cancellationToken);
    }
    
    public async Task DeleteTransactionCategoryWithMigrationItems(Guid id, Guid utcId, CancellationToken cancellationToken = default)
    {
        List<TransactionDetail> transactionDetails = 
            await GetTransactionDetails(id, _currentUserService.Email, cancellationToken);
        
        if (transactionDetails.Any())
            transactionDetails.ForEach(td =>
            {
                td.TransactionCategoryId = utcId;
            });
        
        await _transactionDetailsRepository.UpdateTransactionDetails(transactionDetails, cancellationToken);
        
        await DeleteTransactionCategory(id, _currentUserService.Email, cancellationToken);
    }
    
    private async Task<List<TransactionDetail>> GetTransactionDetails(Guid transactionCategoryId, string userEmail, CancellationToken cancellationToken)
    {
        TransactionCategory transactionCategory;

        try
        {
            transactionCategory = await _transactionCategoriesRepository
                .GetTransactionCategory(transactionCategoryId, userEmail, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
        
        List<TransactionDetail> transactionDetails;

        if (transactionCategory.OverTransactionCategoryId != null)
            transactionDetails = await _transactionDetailsRepository
                .GetTransactionDetailsForUnderTransactionCategory(transactionCategory.Id, userEmail, cancellationToken);
        else
            transactionDetails = await _transactionDetailsRepository
                .GetTransactionDetailsForOverTransactionCategory(transactionCategory.Id, userEmail, cancellationToken);

        return transactionDetails;
    }
    
    private async Task DeleteTransactionCategory(Guid id, string userEmail, CancellationToken cancellationToken)
    {
        List<TransactionDetail> transactionDetails = 
            await GetTransactionDetails(id, userEmail, cancellationToken);
        
        await _transactionDetailsRepository.DeleteRangeAsync(transactionDetails, cancellationToken);
        
        await _transactionCategoriesRepository.DeleteAsync(id, userEmail, cancellationToken);
    }
}