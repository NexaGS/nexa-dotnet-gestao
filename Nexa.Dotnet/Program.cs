using Microsoft.EntityFrameworkCore;
using Nexa.Dotnet.Data;
using Nexa.Dotnet.Notifications;
using Nexa.Dotnet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var stringConexao = builder.Configuration.GetConnectionString("OracleConnection");

builder.Services.AddDbContext<NexaDbContext>(options => options.UseOracle(stringConexao));

builder.Services.AddControllers();

builder.Services.AddScoped<UnidadesSaudeService>();
builder.Services.AddScoped<ConfiguracaoOperacionalService>();

builder.Services.AddScoped<NotificationContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Disponível em: http://localhost:5094/swagger/index.html
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
