namespace BudgetPlan.Api.Middlewares;

public class IncomingRequestLoggerMiddleware(ILogger<IncomingRequestLoggerMiddleware> logger) : IMiddleware
{
	public Task InvokeAsync(HttpContext context, RequestDelegate next)
	{
		var request = context.Request;
		var requestMethod = request.Method;
		var requestPath = request.Path;
		var requestQueryString = request.QueryString;
		var requestBody = string.Empty;

		if (request.ContentLength > 0)
		{
			request.EnableBuffering();
			requestBody = new StreamReader(request.Body).ReadToEnd();
			request.Body.Position = 0;
		}

		logger.LogDebug($"Incoming request: {requestMethod} {requestPath}{requestQueryString}");
		logger.LogDebug($"Request body: {requestBody}");

		return next(context);
	}
}