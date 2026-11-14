using Microsoft.EntityFrameworkCore;
using Nexa.Dotnet.Client;
using Nexa.Dotnet.Config;
using Nexa.Dotnet.Data;
using Nexa.Dotnet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var stringConexao = builder.Configuration.GetConnectionString("OracleConnection");

builder.Services.AddDbContext<NexaDbContext>(options => options.UseOracle(stringConexao));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<UnidadesSaudeService>();
builder.Services.AddScoped<ConfiguracaoOperacionalService>();

builder.Services.AddSingleton<FeriadosConfig>();

builder.Services.AddHttpClient<IFeriadosHttpClient, FeriadosHttpClient>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(); // Disponível em: http://localhost:5000/swagger/index.html
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
