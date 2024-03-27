namespace BudgetPlan.Common.Extension;

public static class DateOnlyExtension
{
    public static DateTime ToDateTime(this DateOnly dateOnly)
    {
        return new DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day);
    }
}