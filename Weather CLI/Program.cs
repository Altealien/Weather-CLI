//A console app that fetches weather data, parses JSON with Newtonsoft.Json, and logs with Serilog.
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Weather CLI is starting...");


Console.Write("Enter a city: ");
string city = Console.ReadLine()!;
string secretsJson = File.ReadAllText("C:\\Users\\subom\\Desktop\\C# for Backend\\Weather CLI\\Weather CLI\\secrets.json");
var secrets = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(secretsJson);
string apiKey = secrets!.ApiKey;

string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

using HttpClient client = new();
string response = await client.GetStringAsync(url);

var weather = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response);
Log.Information($"City: {weather!.name} || Temperature: {weather.main.temp} || Description: {weather.weather[0].description}");

Log.CloseAndFlush();