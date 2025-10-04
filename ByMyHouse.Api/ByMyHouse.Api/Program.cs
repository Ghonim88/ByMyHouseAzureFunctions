using BuyMyHouse.Api;
using BuyMyHouse.Api.DAL;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services for controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Use JsonSerializerOptions, not SerializerOptions
        options.JsonSerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
    });

// Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ByMyHouse API", Version = "v1" });
});
builder.Services.AddSingleton<IMortgageApplicationDAL, MortgageApplicationDAL>();
builder.Services.AddSingleton<IHousesDAL, HousesDAL>();

var app = builder.Build();

// Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ByMyHouse API v1");
    });
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();