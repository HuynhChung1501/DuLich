

using Dulich.Domain.AutoMapper;
using Dulich.Infrastructure;
using Dulich.Service.Interface;
using Dulich.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DASContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DuLichContext"));
});
builder.Services.AddDbContext<DASContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(); // This line adds authorization services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Scoped
builder.Services.AddScoped<IMenu, MenuService>();

//Model Mapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

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
