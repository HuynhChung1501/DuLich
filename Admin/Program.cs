

using Dulich.Domain.AutoMapper;
using Dulich.Domain.Interface;
using Dulich.Infrastructure;
using Dulich.Infrastructure.Repositories;
using Dulich.Service.Interface;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Travel.Application.InterfaceService;
using Travel.Application.Services;
using Travel.Domain.Interface;
using Travel.Domain.Models;
using Travel.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DASContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DuLichContext"));
});
builder.Services.AddDbContext<DASContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(); // This line adds authorization services
builder.Services.AddLogging();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<IEmailSenderService, EmailSenderService>();


//Scoped
builder.Services.AddScoped<IPhuongTienService, PhuongTienService>();
builder.Services.AddScoped<IThongTinChuyenDiService, ThongTinChuyenDiService>();
builder.Services.AddScoped<IMenuServices, MenuService>();
builder.Services.AddScoped<ITravelRepositoryWrapper, TraveRepositoryWrapper>();
//builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
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
