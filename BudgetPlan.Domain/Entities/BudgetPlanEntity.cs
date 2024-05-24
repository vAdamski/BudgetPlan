using BudgetPlan.Domain.Common;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Domain.Entities;

public class BudgetPlanEntity : AuditableEntity
{
    private List<BudgetPlanBase> _budgetPlanBases = new();
    private List<TransactionCategory> _transactionCategories = new();

    public string Name { get; private set; }

    public Guid? DataAccessId { get; private set; }
    public DataAccess? DataAccess { get; private set; }

    public IReadOnlyCollection<BudgetPlanBase> BudgetPlanBases => _budgetPlanBases.AsReadOnly();
    public IReadOnlyCollection<TransactionCategory> TransactionCategories => _transactionCategories.AsReadOnly();

    private BudgetPlanEntity()
    {
    }

    public static BudgetPlanEntity Create(string name, string email)
    {
        if (string.IsNullOrEmpty(name))
            throw new BudgetPlanNameNullOrEmptyException();

        var access = DataAccess.Create(email);

        var budgetPlan = new BudgetPlanEntity
        {
            Name = name,
            DataAccess = access,
        };

        return budgetPlan;
    }

    public BudgetPlanBase AddBudgetPlanBase(DateOnly dateFrom, DateOnly dateTo)
    {
        if (DataAccessId == null)
            throw new AccessIdNullOrEmptyException();
        
        var budgetPlanBase = new BudgetPlanBase(dateFrom, dateTo, Id, DataAccessId.Value);

        var categories = _transactionCategories.Where(x => x.OverTransactionCategoryId == null && IsActive).ToList();

        foreach (var category in categories)
        {
            budgetPlanBase.AddBudgetPlanDetail(category.Id);
        }

        _budgetPlanBases.Add(budgetPlanBase);
        return budgetPlanBase;
    }
    
    public TransactionCategory AddOverTransactionCategory(string transactionCategoryName,
        TransactionType transactionType)
    {
        var transactionCategory =
            TransactionCategory.CreateOverTransactionCategory(transactionCategoryName, transactionType, DataAccessId.Value);

        _transactionCategories.Add(transactionCategory);

        return transactionCategory;
    }

    public TransactionCategory AddTransactionCategory(Guid requestOverTransactionCategoryId, string requestName)
    {
        var overTransactionCategory =
            _transactionCategories.FirstOrDefault(x => x.Id == requestOverTransactionCategoryId &&
                                                       x.OverTransactionCategoryId == null &&
                                                       x.IsActive);

        if (overTransactionCategory == null)
            throw new OverTransactionCategoryNotFoundException(requestOverTransactionCategoryId);
        
        return overTransactionCategory.AddSubTransactionCategory(requestName);
    }
}