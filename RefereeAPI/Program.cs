using Microsoft.EntityFrameworkCore;
using RefereeAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// End services

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
