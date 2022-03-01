var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddShopDbContext(configuration);
builder.Services.AddDependencyInjections();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();