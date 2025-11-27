using GestorProposta.Application.Services;
using GestorProposta.Domain.Ports;
using GestorProposta.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // <<--- Adicione esta linha

var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

builder.Services.AddDbContext<GestorPropostasDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IPropostaRepository, PropostaRepositoryPostgres>();

// Application Services
builder.Services.AddScoped<CriarPropostaService>();
builder.Services.AddScoped<ListarPropostasService>();
builder.Services.AddScoped<ObterPropostaService>();
builder.Services.AddScoped<AtualizarStatusPropostaService>();
builder.Services.AddScoped<DeletarPropostaService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // <<--- Adicione esta linha

// Pipeline de execução
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
