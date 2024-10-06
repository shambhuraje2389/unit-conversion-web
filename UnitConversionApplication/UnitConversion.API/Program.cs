using Microsoft.EntityFrameworkCore;
using System;
using UnitConversion.Data;
using UnitConversion.Data.Interfaces;
using UnitConversion.Data.Repositories;
using UnitConversion.Services.Interfaces;
using UnitConversion.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UnitConversionContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitRepository,UnitRepository>();
builder.Services.AddScoped<IConversionRateRepositery, ConversionRateRepositery>();
builder.Services.AddScoped<IConversionHistoryRepositery, ConversionHistoryRepositery>();


builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IConversionService, ConversionService>();

var app = builder.Build();

app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
