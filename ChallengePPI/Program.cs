using Core.Interfaces;
using Core.Services;
using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkRepository.Generic;
using UnitOfWorkRepository.Repository.Models;
using Microsoft.Extensions.DependencyInjection;
using Infraestructura.Profiles;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ChallengePPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrdenService, OrdenService>();
builder.Services.AddScoped<ActivoService>();

builder.Services.AddScoped<IOrdenRepository, OrdenRepository>();
builder.Services.AddScoped<IActivoRepository, ActivoRepository>();

Mapper.AddAutoMapper(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
