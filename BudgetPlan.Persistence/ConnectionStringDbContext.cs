namespace BudgetPlan.Persistence;

public static class ConnectionStringDbContext
{
    public static string GetConnectionString()
    {
        var connectionString =
            "Server=tcp:budgetplan.database.windows.net,1433;Initial Catalog=budgetPlan;Persist Security Info=False;User ID=budgetplan_admin;Password=U9VVTmZaWhxsqpvX7ptV;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        return connectionString;
    }
}