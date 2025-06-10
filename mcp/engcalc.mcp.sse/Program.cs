using engcalc.mcp.shared.Clients;
using engcalc.mcp.shared.Tools;
using ModelContextProtocol.Protocol;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole(options =>
{
    options.LogToStandardErrorThreshold = LogLevel.Debug;
});

builder.Configuration.AddEnvironmentVariables();

var serverInfo = new Implementation { Name = "EngCalc MCP Server", Version = "1.0.0" };
builder.Services
    .AddMcpServer(mcp =>
    {
        mcp.ServerInfo = serverInfo;
    })
    .WithHttpTransport()
    .WithToolsFromAssembly(typeof(EngCalcTools).Assembly);

builder.Services.AddHttpClient<EngcalcApiClient>(client =>
{
    client.BaseAddress = new Uri("https://engcalc-api.devluan.com/");
});

var app = builder.Build();


app.UseHttpsRedirection();

app.MapMcp();

app.Run();
