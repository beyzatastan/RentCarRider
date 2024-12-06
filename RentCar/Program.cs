using Microsoft.EntityFrameworkCore;
using RentCar.Data;
using RentCar.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container."

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRentCarService, RentCarService>();
builder.Services.AddDbContext<DataContext>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();