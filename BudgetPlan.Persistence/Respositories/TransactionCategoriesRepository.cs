using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence.Respositories;

public class TransactionCategoriesRepository : ITransactionCategoriesRepository
{
    private readonly IBudgetPlanDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public TransactionCategoriesRepository(IBudgetPlanDbContext context,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }


    // TODO: Pass user email as parameter
    public async Task<List<TransactionCategory>> GetTransactionCategoriesWithUnderTransactionCategoriesForCurrentUser(
        CancellationToken cancellationToken = default)
    {
        var categoriesWithDetails = await _context
            .TransactionCategories
            .Where(x => x.CreatedBy == _currentUserService.Email &&
                        x.StatusId == 1 &&
                        x.OverTransactionCategoryId == null)
            .Include(x => x.SubTransactionCategories)
            .ToListAsync(cancellationToken);

        return categoriesWithDetails;
    }

    public async Task DeleteAsync(Guid id, string userEmail, CancellationToken cancellationToken = default)
    {
        if (id == Guid.Empty)
            throw new ArgumentNullException(nameof(id));

        if (string.IsNullOrEmpty(userEmail))
            throw new ArgumentNullException(nameof(userEmail));

        var transactionCategory = await _context.TransactionCategories.Where(x =>
                x.Id == id &&
                x.CreatedBy == userEmail &&
                x.StatusId == 1)
            .Include(x => x.SubTransactionCategories)
            .FirstOrDefaultAsync(cancellationToken);

        if (transactionCategory == null)
            throw new TransactionCategoryNotFoundException(id);

        _context.TransactionCategories.Remove(transactionCategory);

        await _context.SaveChangesAsync();
    }

    public async Task<TransactionCategory> GetTransactionCategory(Guid id, string userEmail,
        CancellationToken cancellationToken = default)
    {
        if (id == Guid.Empty)
            throw new ArgumentNullException(nameof(id));

        if (string.IsNullOrEmpty(userEmail))
            throw new ArgumentNullException(nameof(userEmail));

        var transactionCategory = await _context.TransactionCategories
            .Include(x => x.SubTransactionCategories)
            .Where(x =>
                x.Id == id &&
                x.CreatedBy == userEmail &&
                x.StatusId == 1)
            .FirstOrDefaultAsync(cancellationToken);

        if (transactionCategory == null)
            throw new TransactionCategoryNotFoundException(id);

        return transactionCategory;
    }

    public async Task<bool> IsTransactionCategoryUnderCategory(Guid transactionCategoryId)
    {
        var transactionCategory = await _context.TransactionCategories
            .Where(x => x.Id == transactionCategoryId &&
                        x.StatusId == 1)
            .FirstOrDefaultAsync();

        if (transactionCategory == null)
            throw new TransactionCategoryNotFoundException(transactionCategoryId);

        return transactionCategory.OverTransactionCategoryId != null;
    }

    public async Task<bool> IsTransactionCategoryInclude(Guid mainTransactionCategoryId, Guid transactionCategoryIdToCheck)
    {
        return await _context.TransactionCategories
            .AsSplitQuery()
            .AnyAsync(x => x.Id == mainTransactionCategoryId &&
                      x.SubTransactionCategories.Any(x => x.Id == transactionCategoryIdToCheck));
    }
}