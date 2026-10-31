using DataAccessLayer.Irepo;
using DataAccessLayer.Models;
using DataAccessLayer.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr"));
});
builder.Services.AddScoped<Iproduct,ProductRepo>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ProductApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("ProductApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
