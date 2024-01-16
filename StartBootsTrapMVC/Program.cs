using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StartBootsTrapMVC.Context;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StartDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<StartDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Detail}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
