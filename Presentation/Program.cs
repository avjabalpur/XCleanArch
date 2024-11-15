using XcdifyConnect.Infrastructure.DbContext;
using XcdifyConnect.Application;
using XcdifyConnect.Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Azure.Identity;
using XcdifyConnect.Domain.Services;
using XcdifyConnect.Infrastructure.ExternalServices;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<DapperDbContext>();

builder.Services.AddOptions<GraphApiOptions>()
					  .Bind(configuration.GetSection(nameof(GraphApiOptions)));
// Add services to the container.

// Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add AutoMapper (if you're using it)
//builder.Services.AddAutoMapper(typeof(XcdifyConnect.Application.Mappers.AxisBankTransactionProfile)); // Correct namespace for your AutoMapper profile

builder.Services.AddScoped<IMicrosoftGraphService, MicrosoftGraphService>();

// Add repository and service dependencies
//builder.Services.AddScoped<IAxisBankTransactionRepository, AxisBankTransactionRepository>();
builder.Services.AddApplicationLayer();

// Add Controllers
builder.Services.AddControllers();

builder.Services.AddScoped<GraphServiceClient>(provider =>
{
	var options = provider.GetRequiredService<IOptions<GraphApiOptions>>();
	var clientSecretCredential = new ClientSecretCredential(
		options.Value.TenantId,
		options.Value.ClientId,
		options.Value.ClientSecret
	);
	return new GraphServiceClient(clientSecretCredential, new[] { "https://graph.microsoft.com/.default" });
});

var app = builder.Build();

// Use Swagger if in the development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Other middleware
app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
