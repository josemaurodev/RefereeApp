using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RefereeAPI.Data;
using RefereeAPI.Extensions;
using RefereeAPI.Interfaces;
using RefereeAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);


// End services

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

//DO YOU HAVE A VALID TOKEN? 
app.UseAuthentication();

//OKAY, YOU HAVE A VALID TOKEN, BUT WHAT ARE YOU ALLOWED TO DO?
app.UseAuthorization();

app.MapControllers();

app.Run();
