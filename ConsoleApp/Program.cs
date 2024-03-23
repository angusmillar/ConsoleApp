using ConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .Build();
    
IServiceCollection services = new ServiceCollection();

services.AddLogging();

//Configuration
services.AddOptions<ApplicationConfiguration>().Bind(configuration.GetSection(ApplicationConfiguration.SectionName));

//Add Services
services.AddSingleton<Application>();

var serviceProvider = services.BuildServiceProvider();

serviceProvider.GetRequiredService<ILoggerFactory>()
    .AddSerilog();

var application = serviceProvider.GetRequiredService<Application>();

application.Run();


