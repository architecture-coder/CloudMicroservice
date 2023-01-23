using Basket.API.Repositories;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.
//var con = builder.Services.AddStackExchangeRedisCache(options => { options.Configuration = configuration["CacheSettings;ConnectionString"]; });
var connection = builder.Configuration["CacheSettings:ConnectionString"];
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = connection;
});

builder.Services.AddScoped<IBasketRepository,BasketRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket API"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();
