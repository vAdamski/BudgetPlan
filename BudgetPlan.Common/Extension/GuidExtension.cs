namespace BudgetPlan.Common.Extension;

public static class GuidExtension
{
    public static bool IsNullOrEmpty(this Guid? guid) => guid == null || guid == Guid.Empty;
    public static bool IsNullOrEmpty(this Guid guid) => guid == null || guid == Guid.Empty;
}