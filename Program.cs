#region folder Models
global using System.ComponentModel.DataAnnotations.Schema;
global using System.ComponentModel.DataAnnotations;
global using Microsoft.AspNetCore.Mvc;
global using System.Diagnostics.CodeAnalysis;
#endregion



using CourseSignupSystemServer.Data;
using Microsoft.EntityFrameworkCore;
using CourseSignupSystemServer.Controllers;
using CourseSignupSystemServer.Models;
using CourseSignupSystemServer.Interfaces;
using CourseSignupSystemServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//cho phép mọi thiết bị kết nối đến API
builder.Services.AddCors(option => option.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

//tạo lk database
builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CourseSignup"));
});

// Đăng ký interface IExistAlreadyService và thực hiện các chức năng của nó trong file ExistAlreadyService
builder.Services.AddScoped<IExistAlreadyService, ExistAlreadyService>();

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
