

using DuLich.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("DuLichContext");
builder.Services.AddDbContext<DASContext>(options =>
{
options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("DuLich.Infrastructure"));
options.UseSqlServer(connectionString);
});
builder.Services.AddDbContext<DASContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(); // This line adds authorization services

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization(); // This line ensures that authorization middleware is used

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
