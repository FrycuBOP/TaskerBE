using Microsoft.AspNetCore.OData;
using Tasker.Host.Extensions;
using Tasker.Shared.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc().AddOData();
builder.Services.AddRouting();

var modulesSettings = new ModulesSettings();
builder.Configuration.GetSection("ModulesSettings").Bind(modulesSettings);
builder.Services.AddModules(modulesSettings);
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseReDoc(opt =>
{
    opt.RoutePrefix = "docs";
    opt.SpecUrl("/swagger/v1/swagger.json");
    opt.DocumentTitle = "Tasker Doc";
});
app.UseRouting();
app.UseModlues(modulesSettings);
app.MapGet("/", () =>
{
    return "Tasker Host Api";
});
app.MapGet("/healthCheck", () =>
{
    return "Healthy";
});

app.Run();

