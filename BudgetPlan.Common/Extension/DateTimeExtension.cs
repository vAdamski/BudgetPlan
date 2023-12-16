namespace BudgetPlan.Common.Extension;

public static class DateTimeExtension
{
    public static DateOnly ToDateOnly(this DateTime dateTime)
    {
        return new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
    }
}