using BudgetPlan.Domain.Common;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Domain.Exceptions;

namespace BudgetPlan.Domain.Entities;

public class BudgetPlanBase : AuditableEntity
{
    private List<BudgetPlanDetails> _budgetPlanDetailsList = new();

    public DateOnly DateFrom { get; private set; }
    public DateOnly DateTo { get; private set; }

    public Guid? BudgetPlanEntityId { get; private set; }
    public BudgetPlanEntity? BudgetPlanEntity { get; private set; }

    public Guid? DataAccessId { get; private set; }
    public DataAccess? DataAccess { get; private set; }

    public IReadOnlyCollection<BudgetPlanDetails> BudgetPlanDetailsList => _budgetPlanDetailsList.AsReadOnly();

    private BudgetPlanBase()
    {
    }

    public BudgetPlanBase(DateOnly dateFrom, DateOnly dateTo, Guid budgetPlanEntityId, Guid dataAccessId)
    {
        if (dateFrom > dateTo)
            throw new InvalidDateRangeException();

        BudgetPlanEntityId = budgetPlanEntityId;

        DataAccessId = dataAccessId;

        DateFrom = dateFrom;
        DateTo = dateTo;
    }

    public void AddBudgetPlanDetail(Guid categoryId)
    {
        if (DataAccessId == null)
            throw new AccessIdNullOrEmptyException();

        var budgetPlanDetail = new BudgetPlanDetails(0, BudgetPlanType.Monthly, Id, categoryId, DataAccessId.Value);

        _budgetPlanDetailsList.Add(budgetPlanDetail);
    }
}