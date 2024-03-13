using BudgetPlan.Domain.Common;

namespace BudgetPlan.Common.Extension;

public static class QueryableAuditableEntityExtensions
{
    public static IQueryable<T> IsActive<T>(this IQueryable<T> entities)
        where T : AuditableEntity
    {
        return entities.Where(e => e.StatusId == 1);
    }
}