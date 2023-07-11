using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Starpholio.Areas.Identity.Data;
using Starpholio.Controllers;
using Starpholio.Data;
using Starpholio.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<StarpholioContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<UserInfo>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<StarpholioContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<UserManager<UserInfo>>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var dbContext = services.GetRequiredService<StarpholioContext>();
var scopeFactory = services.GetRequiredService<IServiceScopeFactory>();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();

    // Call SeedData method
    DatabaseSeeder.SeedData(dbContext, scopeFactory);
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "LoggedIn",
    pattern: "LoggedIn/Index",
    defaults: new { controller = "LoggedIN", action = nameof(LoggedINController.Index) }
);

app.UseDeveloperExceptionPage();
app.Run(); // Add this line to keep the application running
