using EShop.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EShopDbContext>(options =>
{
    var connectionString = "server=192.168.1.108;uid=root;pwd=123456789;database=eshop";
    options.UseMySql(connectionString, new MySqlServerVersion(MySqlServerVersion.AutoDetect(connectionString)));

});

builder.Services.AddControllers();
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

app.MapControllers();

app.Run();