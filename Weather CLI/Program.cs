//A console app that fetches weather data, parses JSON with Newtonsoft.Json, and logs with Serilog.
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Weather CLI is starting...");
Log.CloseAndFlush();