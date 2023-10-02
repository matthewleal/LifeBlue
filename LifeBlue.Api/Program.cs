using LifeBlue.Api.Middleware;
using LifeBlue.Api.Profiles;
using LifeBlue.Core.Interfaces;
using LifeBlue.Core.Services;
using LifeBlue.Dal.Contexts;
using LifeBlue.Dal.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("SQLCONNSTR_LIFEBLUE");

builder.Services.AddDbContext<LifeBlueContext>(options => options.UseSqlServer(connection));

// Add services to the container.
//Repositories
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IVistorInfoService, VisitorInfoService>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new VisitorInfoProfile());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.ConfigureExceptionMiddleware();

app.MapControllers();

app.Run();
