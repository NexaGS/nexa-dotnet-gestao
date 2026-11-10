using Microsoft.EntityFrameworkCore;
using Nexa.Dotnet.Client;
using Nexa.Dotnet.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var stringConexao = builder.Configuration.GetConnectionString("OracleConnection");

builder.Services.AddDbContext<NexaDbContext>(options => options.UseOracle(stringConexao));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddHttpClient<IFeriadosHttpClient, FeriadosHttpClient>;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
