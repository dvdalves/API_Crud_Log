using Microsoft.AspNetCore.Mvc;

namespace API_Crud_Log.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogsTestController : ControllerBase
{
    private readonly ILogger<LogsTestController> _logger;

    public LogsTestController(ILogger<LogsTestController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public string Get()
    {
        // Trace log: Used for very detailed diagnostic information.
        // This log level is typically used for tracing code execution and is very verbose.
        _logger.LogTrace("This is a trace log.");

        // Debug log: Used for detailed development information.
        // This log level is useful during development and debugging of the application.
        _logger.LogDebug("This is a debug log.");

        // Information log: Used for general information about the execution of the application.
        // This log level is used to track the general flow of the application.
        _logger.LogInformation("This is an information log.");

        // Warning log: Used for potential issues or unexpected situations that do not cause the application to fail.
        // This log level is used for situations that might need attention in the future.
        _logger.LogWarning("This is a warning log.");

        // Error log: Used for errors that occur during the execution of the application.
        // This log level is used to track failures that need to be fixed.
        _logger.LogError("This is an error log.");

        // Critical log: Used for critical failures that require immediate attention.
        // This log level is used to track severe failures that might cause the application to stop running.
        _logger.LogCritical("This is a critical log.");

        // Returns a message indicating that the logs have been written.
        return "Logs written.";
    }
}