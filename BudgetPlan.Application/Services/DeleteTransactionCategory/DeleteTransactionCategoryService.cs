using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Application.Common.Interfaces.Services;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Application.Services.DeleteTransactionCategory;

public class DeleteTransactionCategoryService : IDeleteTransactionCategoryService
{
    private readonly ITransactionCategoriesRepository _transactionCategoriesRepository;
    private readonly ITransactionDetailsRepository _transactionDetailsRepository;
    private readonly ICurrentUserService _currentUserService;

    public DeleteTransactionCategoryService(
        ITransactionCategoriesRepository transactionCategoriesRepository,
        ITransactionDetailsRepository transactionDetailsRepository,
        ICurrentUserService currentUserService)
    {
        _transactionCategoriesRepository = transactionCategoriesRepository;
        _currentUserService = currentUserService;
        _transactionDetailsRepository = transactionDetailsRepository;
    }

    public async Task DeleteTransactionCategory(Guid id, CancellationToken cancellationToken = default)
    {
        await DeleteTransactionCategory(id, _currentUserService.Email, cancellationToken);
    }
    
    public async Task DeleteTransactionCategoryWithMigrationItems(Guid id, Guid utcId, CancellationToken cancellationToken = default)
    {
        if (!await IsTransactionCategoryUnderCategory(utcId))
            throw new TransactionCategoryCannotBeOverTransactionCategoryException(utcId);
        
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
        List<TransactionDetail> transactionDetails;

        if (await IsTransactionCategoryUnderCategory(transactionCategoryId))
            transactionDetails = await _transactionDetailsRepository
                .GetTransactionDetailsForUnderTransactionCategory(transactionCategoryId, userEmail, cancellationToken);
        else
            transactionDetails = await _transactionDetailsRepository
                .GetTransactionDetailsForOverTransactionCategory(transactionCategoryId, userEmail, cancellationToken);

        return transactionDetails;
    }
    
    private async Task DeleteTransactionCategory(Guid id, string userEmail, CancellationToken cancellationToken)
    {
        await _transactionCategoriesRepository.DeleteAsync(id, userEmail, cancellationToken);
    }

    private async Task<bool> IsTransactionCategoryUnderCategory(Guid transactionCategoryId)
    {
        return await _transactionCategoriesRepository.IsTransactionCategoryUnderCategory(transactionCategoryId);
    }
}