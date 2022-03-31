using Microsoft.EntityFrameworkCore;
using Prueba.Web.Data;
using Prueba.Web.Repositories;
using Prueba.Web.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));

builder.Services.AddScoped<IFibonacciNumbersRepository, FibonacciNumbersRepository>();
builder.Services.AddScoped<IOperationsRepository, OperationsRepository>();

builder.Services.AddScoped<IFibonacciNumbersServices, FibonacciNumbersServices>();
builder.Services.AddScoped<IOperationsServices, OperationsServices>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
