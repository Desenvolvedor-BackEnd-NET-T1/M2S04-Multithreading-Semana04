using Microsoft.EntityFrameworkCore;
using PizzariaByte.Api.Data;
using PizzariaByte.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PizzariaContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Pizzaria")));

builder.Services.AddScoped<IEntregaService, EntregaService>();
builder.Services.AddScoped<IPromocaoService, PromocaoService>();
builder.Services.AddScoped<CardapioService>();

var app = builder.Build();

// Cria o banco com o cardápio inicial, se ainda não existir.
// (No projeto de vocês, usem migrations: dotnet ef database update)
using (var escopo = app.Services.CreateScope())
{
    var contexto = escopo.ServiceProvider
        .GetRequiredService<PizzariaContext>();
    contexto.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
