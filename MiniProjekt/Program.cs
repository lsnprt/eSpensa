using Microsoft.EntityFrameworkCore;
using MiniProjekt.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDataService, DataService>();

var connString = builder.Configuration
    .GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>
    (o => o.UseSqlServer(connString));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(o => o.MapControllers());
app.Run();
