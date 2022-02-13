using EShop.Application;
using EShop.Domain.AggregatesModel.CategoryAggregateModel;
using EShop.Domain.AggregatesModel.SellerAggregateModel;
using EShop.Infrastructure;
using EShop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddDbContext<EShopDbContext>(options =>
{
    var connectionString = configuration.GetConnectionString("MySQLConnectionString");
    options.UseMySql(connectionString, new MySqlServerVersion(MySqlServerVersion.AutoDetect(connectionString)));

});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(ApplicationAssemblyLoader));
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();