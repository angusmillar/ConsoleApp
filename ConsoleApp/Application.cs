using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConsoleApp;

public class Application(
    ILogger<Application> logger, 
    IOptions<ApplicationConfiguration> appConfig)
{
    public void Run()
    {
        logger.LogInformation("Running: {ApplicationName}", appConfig.Value.ApplicationName);
    }
}