using Microsoft.Extensions.Configuration;

namespace BudgetPlan.Common.Helpers;

public static class ConnectionStringGetter
{
	public static string GetConnectionString(IConfiguration configuration, string environmentVariableName = "DB_CONNECTION_STRING")
	{
		string connectionString = EnvironmentVariables.GetEnvironmentVariable(environmentVariableName);
		
		if (string.IsNullOrEmpty(connectionString))
		{
			connectionString = configuration.GetConnectionString("DefaultConnection");
		}
		
		if (string.IsNullOrEmpty(connectionString))
		{
			throw new Exception("Connection string is not set.");
		}
		
		return connectionString;
	}
}