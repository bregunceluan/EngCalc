using engcalc.mcp.shared.Clients;
using engcalc.mcp.shared.Tools;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Protocol;

var builder = Host.CreateApplicationBuilder(args);

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
    .WithStdioServerTransport()
    .WithToolsFromAssembly(typeof(EngCalcTools).Assembly);

builder.Services.AddHttpClient<EngcalcApiClient>(client =>
{
    client.BaseAddress = new Uri("https://engcalc-api.devluan.com/");
});

var app = builder.Build();
await app.RunAsync();