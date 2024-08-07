

using Dulich.Domain.AutoMapper;
using Dulich.Domain.Interface;
using Dulich.Infrastructure;
using Dulich.Infrastructure.Repositories;
using Dulich.Service.Interface;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Travel.Application.Services;
using Travel.Domain.Interface;
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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("V1", new OpenApiInfo { Title = "swagger", Version = "V1" });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "swagger");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();