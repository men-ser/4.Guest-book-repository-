using Microsoft.EntityFrameworkCore;
using Guest_book.Models;
using Guest_book.Repository;
using NuGet.Protocol.Core.Types;

var builder = WebApplication.CreateBuilder(args);
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddDbContext<GuestBookContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IRepository, GuestBookRepository>();

var app = builder.Build();


app.UseStaticFiles();
app.UseSession();
//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
