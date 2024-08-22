namespace BudgetPlan.Common.Helpers;

public static class EnvironmentVariables
{
	public static string GetEnvironmentVariable(string variableName)
	{
		// if the environment variable not exists, return null
		return Environment.GetEnvironmentVariable(variableName);
	}
}